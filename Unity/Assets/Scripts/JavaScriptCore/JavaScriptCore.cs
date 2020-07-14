using System.Runtime.InteropServices;

namespace JavaScriptCore
{
    public static class Engine
    {
        [DllImport("__Internal")]
        private static extern void _EvaluateScript(string script);

        [DllImport("__Internal")]
        private static extern string _CallFunction1(string methodName);

        [DllImport("__Internal")]
        private static extern string _CallFunction2(string methodName, int args0);

        [DllImport("__Internal")]
        private static extern string _CallFunction3(string methodName);

        public static void EvaluateScript(string script)
        {
            _EvaluateScript(script);
        }

        public static string CallFunction(string methodName)
        {
            return _CallFunction3($"bench.Main.{methodName}();");
        }

        public static string CallFunction(string methodName, int args0)
        {
            return _CallFunction3($"bench.Main.{methodName}({args0});");
        }
    }
}
