namespace CodingPatternsTests
{
    public class BaseTest
    {
        protected long Time(Action action)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            action();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}
