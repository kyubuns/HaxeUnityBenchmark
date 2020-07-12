using JavaScriptCore;

namespace HaxeUnityBenchmark
{
    public class JavaScriptCoreExecutor : IExecutor
    {
        public JavaScriptCoreExecutor(string jsSource)
        {
            Engine.EvaluateScript(jsSource);
        }

        public string Test1()
        {
            return Engine.CallFunction("test1");
        }

        public string Test2(int n)
        {
            return Engine.CallFunction("test2", n);
        }
    }
}
