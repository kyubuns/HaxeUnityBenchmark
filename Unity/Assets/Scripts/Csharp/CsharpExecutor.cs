namespace HaxeUnityBenchmark
{
    public class CsharpExecutor : IExecutor
    {
        public string Test1()
        {
            return bench.Main.test1();
        }

        public string Test2(int n)
        {
            return bench.Main.test2(n);
        }
    }
}
