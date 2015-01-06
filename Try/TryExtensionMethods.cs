using System.Threading.Tasks;

namespace Tryer
{
    public static class TryExtensionMethods
    {
        public static async Task<TryResult> TryAwait(this Task task)
        {
            return await Try.AwaitTask(task);
        }

        public static async Task<TryResult<T>> TryAwait<T>(this Task<T> task)
        {
            return await Try.AwaitTask(task);
        }
    }
}