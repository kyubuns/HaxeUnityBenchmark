using Jint;
using Jint.Native.Object;

namespace HaxeUnityBenchmark
{
    public class JavaScriptJintExecutor : IExecutor
    {
        private readonly Engine engine;
        private readonly ObjectInstance mainClass;

        public JavaScriptJintExecutor(string jsSource)
        {
            engine = new Engine();
            engine.Execute(jsSource);

            var benchNameSpace = engine.GetValue("bench");
            mainClass = (ObjectInstance) benchNameSpace.Get("Main");
        }

        public string Test1()
        {
            return mainClass.Get("test1").Invoke().AsString();
        }

        public string Test2(int n)
        {
            return mainClass.Get("test2").Invoke(n).AsString();
        }
    }
}
