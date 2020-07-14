using BridgeJsCore;
using UnityEngine;

namespace HaxeUnityBenchmark
{
    public class BridgeJsCoreExecutor : IExecutor
    {
        private Engine engine;

        public BridgeJsCoreExecutor(string jsSource)
        {
            engine = new Engine();
            engine.EvaluateScript(jsSource);
        }

        public string Test1()
        {
            var (result, error1) = engine.EvaluateScript("bench.Main.test1()");
            if (!string.IsNullOrWhiteSpace(error1)) Debug.LogError($"error1 {error1}");

            return result.ToString();
        }

        public string Test2(int n)
        {
            var (result, error2) = engine.EvaluateScript($"bench.Main.test2({n})");
            if (!string.IsNullOrWhiteSpace(error2)) Debug.LogError($"error2 {error2}");

            return result.ToString();
        }
    }
}
