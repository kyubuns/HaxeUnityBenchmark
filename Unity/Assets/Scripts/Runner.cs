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

            const int count = 5000;
            Execute("Csharp", new CsharpExecutor(), count);
            Execute("JavaScript/Jint", new JavaScriptJintExecutor(jsSource), count);
            Execute("Lua/xLua", new LuaXLuaExecutor(luaSource), count);

            Log($"Finish {DateTime.Now}");
        }

        private void Log(string message)
        {
            resultText.text = $"{resultText.text}\n{message}";
        }

        private void Execute(string id, IExecutor executor, int count)
        {
            Log($"## {id}");
            {
                var stopwatch = Stopwatch.StartNew();
                for (var i = 0; i < count; ++i)
                {
                    var r = executor.Test1();
                    if (i == 0) Debug.Log(r);
                }
                stopwatch.Stop();
                Log($"test1 = {stopwatch.Elapsed.TotalSeconds:0.00}s / {count}回");
            }

            {
                var stopwatch = Stopwatch.StartNew();
                for (var i = 0; i < count; ++i)
                {
                    var r = executor.Test2(10000);
                    if (i == 0) Debug.Log(r);
                }
                stopwatch.Stop();
                Log($"test2 = {stopwatch.Elapsed.TotalSeconds:0.00}s / {count}回");
            }
            Log("");
        }
    }
}
