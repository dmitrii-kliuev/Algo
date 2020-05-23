using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace Algo.Tests
{
    public class AsyncAwaitTest
    {
        [Fact]
        public async void TestSyncroniously()
        {
            await F1().ConfigureAwait(false);
            await F2().ConfigureAwait(false);
        }

        [Fact]
        public async void TestConcurrently()
        {
            await Task.WhenAll(F1(), F2()).ConfigureAwait(false);
        }

        private async Task F1()
        {
            await Task.Delay(1000).ConfigureAwait(false);
            Debug.WriteLine("1");
        }

        private async Task F2()
        {
            await Task.Delay(1000).ConfigureAwait(false);
            Debug.WriteLine("2");
        }
    }
}
