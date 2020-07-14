using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace HaxeUnityBenchmark
{
    public class Runner : MonoBehaviour
    {
        [SerializeField] private Text resultText = default;

        public void Run()
        {
            resultText.text = "";
            var jsSource = Resources.Load<TextAsset>("bench.js").text;
            var luaSource = Resources.Load<TextAsset>("bench.lua").text;

            Log($"Start {DateTime.Now}");
            Log("");

            var count1 = 1000;
            var count2 = 10000;
            var count3 = 10000;
            if (Application.isEditor)
            {
                Execute("Csharp", () => new CsharpExecutor(), count1, count2, count3);
                Execute("JavaScript/Jint", () => new JavaScriptJintExecutor(jsSource), count1, count2, count3 / 100);
                Execute("Lua/xLua", () => new LuaXLuaExecutor(luaSource), count1, count2, count3);
                Execute("JavaScript/Core", () => new JavaScriptCoreExecutor(jsSource), count1, count2, count3);
                Execute("JavaScript/Bridge", () => new BridgeJsCoreExecutor(jsSource), count1, count2, count3);
            }
            else
            {
                Execute("Csharp", () => new CsharpExecutor(), count1, count2, count3);
                Execute("JavaScript/Jint", () => new JavaScriptJintExecutor(jsSource), count1, count2, count3);
                Execute("Lua/xLua", () => new LuaXLuaExecutor(luaSource), count1, count2, count3);
                Execute("JavaScript/Core", () => new JavaScriptCoreExecutor(jsSource), count1, count2, count3);
                Execute("JavaScript/Bridge", () => new BridgeJsCoreExecutor(jsSource), count1, count2, count3);
            }

            Log($"Finish {DateTime.Now}");
        }

        private void Log(string message)
        {
            resultText.text = $"{resultText.text}\n{message}";
        }

        private void Execute(string id, Func<IExecutor> executorFactory, int count1, int count2, int count3)
        {
            Log($"## {id}");
            var executor = executorFactory();
            {
                var stopwatch = Stopwatch.StartNew();
                for (var i = 0; i < count1; ++i)
                {
                    executorFactory();
                }
                stopwatch.Stop();
                Log($"factory = {stopwatch.Elapsed.TotalSeconds:0.00}s / {count1}回");
            }
            {
                var stopwatch = Stopwatch.StartNew();
                var result = "";
                for (var i = 0; i < count2; ++i)
                {
                    var r = executor.Test1();
                    if (i == 0) result = r;
                }
                stopwatch.Stop();
                Log($"test1({result}) = {stopwatch.Elapsed.TotalSeconds:0.00}s / {count2}回");
            }

            {
                var stopwatch = Stopwatch.StartNew();
                var result = "";
                for (var i = 0; i < count3; ++i)
                {
                    var r = executor.Test2(10000);
                    if (i == 0) result = r;
                }
                stopwatch.Stop();
                Log($"test2({result}) = {stopwatch.Elapsed.TotalSeconds:0.00}s / {count3}回");
            }
            Log("");
        }
    }
}
