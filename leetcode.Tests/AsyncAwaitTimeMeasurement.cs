using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Algo.Tests
{
    public class AsyncAwaitTimeMeasurement
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public AsyncAwaitTimeMeasurement(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2008:Do not create tasks without passing a TaskScheduler", Justification = "<Pending>")]
        public async Task Test()
        {
            var sw = Stopwatch.StartNew();

            var res = await Method1().ContinueWith(x =>
            {
                sw.Stop();
                _testOutputHelper.WriteLine($"Elapsed milliseconds: {sw.ElapsedMilliseconds}");

                return x.Result;
            }).ConfigureAwait(false);

            _testOutputHelper.WriteLine($"res: {res}");
        }

        public async Task<int> Method1()
        {
            await Task.Delay(2000).ConfigureAwait(false);
            return 100500;
        }
    }
}
