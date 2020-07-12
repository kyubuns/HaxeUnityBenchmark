using JavaScriptCore;

namespace HaxeUnityBenchmark
{
    public class JavaScriptCoreExecutor : IExecutor
    {
        private readonly Engine engine;

        public JavaScriptCoreExecutor(string jsSource)
        {
            engine = new Engine();
            engine.EvaluateScript(jsSource);
        }

        public string Test1()
        {
            return engine.CallFunction("test1");
        }

        public string Test2(int n)
        {
            return engine.CallFunction("test2", n);
        }
    }
}
