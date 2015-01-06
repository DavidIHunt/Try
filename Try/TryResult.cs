using System;

namespace Tryer
{
    public class TryResult
    {
        public Exception Exception { get; set; }

        public bool Error
        {
            get { return Exception != null; }
        }
    }

    public class TryResult<T> : TryResult
    {
        public T Value { get; set; }
    }
}