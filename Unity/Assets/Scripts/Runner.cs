using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace HaxeUnityBenchmark
{
    public class Runner : MonoBehaviour
    {
        [SerializeField] private Text resultText = default;

        public void Run()
        {
            resultText.text = "";
            Log($"Start {DateTime.Now}");

            Execute("cs", new CsharpExecutor());

            Log($"Finish {DateTime.Now}");
        }

        private void Log(string message)
        {
            resultText.text = $"{resultText.text}\n{message}";
        }

        private void Execute(string id, IExecutor executor)
        {
            {
                var stopwatch = Stopwatch.StartNew();
                for (var i = 0; i < 10000; ++i)
                {
                    executor.Test1();
                }
                stopwatch.Stop();
                Log($"{id} test1 {stopwatch.Elapsed.TotalSeconds:0.00}s");
            }

            {
                var stopwatch = Stopwatch.StartNew();
                for (var i = 0; i < 10000; ++i)
                {
                    executor.Test2(10000);
                }
                stopwatch.Stop();
                Log($"{id} test2 {stopwatch.Elapsed.TotalSeconds:0.00}s");
            }
        }
    }
}
