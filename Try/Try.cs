using System;
using System.Threading.Tasks;

namespace Tryer
{
    public static class Try
    {
        public static TryResult Action(Action func)
        {
            var result = new TryResult();

            try
            {
                func.Invoke();
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public static TryResult<T> Func<T>(Func<T> func)
        {
            var result = new TryResult<T>();

            try
            {
                result.Value = func.Invoke();
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public static async Task<TryResult<T>> AwaitTask<T>(Task<T> task)
        {
            var result = new TryResult<T>();

            try
            {
                result.Value = await task;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public static async Task<TryResult> AwaitTask(Task task)
        {
            var result = new TryResult();

            try
            {
                await task;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }
    }
}