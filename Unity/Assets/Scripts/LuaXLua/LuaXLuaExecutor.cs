using XLua;

namespace HaxeUnityBenchmark
{
    public class LuaXLuaExecutor : IExecutor
    {
        private readonly LuaEnv luaenv;
        private readonly LuaTable mainClass;

        public LuaXLuaExecutor(string luaSource)
        {
            luaenv = new LuaEnv();
            var exports = (LuaTable) luaenv.DoString(luaSource)[0];

            var benchNameSpace = exports.Get<LuaTable>("bench");
            mainClass = benchNameSpace.Get<LuaTable>("Main");
        }

        public string Test1()
        {
            return (string) mainClass.Get<LuaFunction>("test1").Call()[0];
        }

        public string Test2(int n)
        {
            return (string) mainClass.Get<LuaFunction>("test2").Call(n)[0];
        }
    }
}
