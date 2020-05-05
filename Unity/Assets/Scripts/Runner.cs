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

            Log($"Start {DateTime.Now}");

            Execute("Csharp", new CsharpExecutor());
            Execute("JavaScriptJint", new JavaScriptJintExecutor(jsSource));

            Log($"Finish {DateTime.Now}");
        }

        private void Log(string message)
        {
            resultText.text = $"{resultText.text}\n{message}";
        }

        private void Execute(string id, IExecutor executor)
        {
            const int num = 100;
            {
                var stopwatch = Stopwatch.StartNew();
                for (var i = 0; i < num; ++i)
                {
                    var r = executor.Test1();
                    if (i == 0) Debug.Log(r);
                }
                stopwatch.Stop();
                Log($"{id} test1 {stopwatch.Elapsed.TotalSeconds:0.00}s");
            }

            {
                var stopwatch = Stopwatch.StartNew();
                for (var i = 0; i < num; ++i)
                {
                    var r = executor.Test2(10000);
                    if (i == 0) Debug.Log(r);
                }
                stopwatch.Stop();
                Log($"{id} test2 {stopwatch.Elapsed.TotalSeconds:0.00}s");
            }
        }
    }
}
