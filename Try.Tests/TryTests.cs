using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tryer.Tests
{
    [TestFixture]
    public class TryTests
    {
        private readonly Exception _testException = new Exception();

        [Test]
        public void Try_ActionWhichThrows_ReturnsException()
        {
            var tryResult = Try.Action(ThrowingAction);
            ExpectExceptionIsReturned(tryResult);
        }

        [Test]
        public void Try_ActionWhichDoesNotThrow_ReturnsNoException()
        {
            var tryResult = Try.Action(NonThrowingAction);
            ExpectNoExceptionIsReturned(tryResult);
        }

        [Test]
        public void Try_Func_ReturnsFuncValue()
        {
            var tryResult = Try.Func(() => AddTwoNumbers(1, 1));
            Assert.That(tryResult.Value, Is.EqualTo(2));
        }

        [Test]
        public void Try_FuncWhichThrows_ReturnsException()
        {
            var tryResult = Try.Func(ThrowingFunction);
            ExpectExceptionIsReturned(tryResult);
        }

        [Test]
        public void Try_FuncWhichDoesNotThrow_ReturnsNoException()
        {
            var tryResult = Try.Func(NonThrowingFunction);
            ExpectNoExceptionIsReturned(tryResult);
        }

        [Test]
        public async void Try_AwaitTask_ReturnsException()
        {
            var tryResult = await Try.AwaitTask(ThrowingAwaitableTask());
            ExpectExceptionIsReturned(tryResult);
        }

        [Test]
        public async void Try_AwaitTask_ReturnsNoException()
        {
            var tryResult = await Try.AwaitTask(NonThrowingAwaitableTask());
            ExpectNoExceptionIsReturned(tryResult);
        }

        [Test]
        public async void Try_AwaitTaskT_ReturnsTaskValue()
        {
            var tryResult = await Try.AwaitTask(AddTwoNumbersAsync(1, 2));
            Assert.That(tryResult.Value, Is.EqualTo(3));
        }

        [Test]
        public async void Try_AwaitTaskT_ReturnsException()
        {
            var tryResult = await Try.AwaitTask(ThrowingAwaitableTaskT());
            ExpectExceptionIsReturned(tryResult);
        }

        [Test]
        public async void Try_AwaitTaskT_ReturnsNoException()
        {
            var tryResult = await Try.AwaitTask(NonThrowingAwaitableTaskT());
            ExpectNoExceptionIsReturned(tryResult);
        }

        [Test]
        public async void Try_AwaitTask_X_ReturnsException()
        {
            var tryResult = await ThrowingAwaitableTask().TryAwait();
            ExpectExceptionIsReturned(tryResult);
        }

        [Test]
        public async void Try_AwaitTaskT_X_ReturnsException()
        {
            var tryResult = await ThrowingAwaitableTaskT().TryAwait();
            ExpectExceptionIsReturned(tryResult);
        }

        private void ExpectExceptionIsReturned(TryResult tryResult)
        {
            Assert.That(tryResult.Error, Is.True);
            Assert.That(tryResult.Exception, Is.SameAs(_testException));
        }

        private static void ExpectNoExceptionIsReturned(TryResult tryResult)
        {
            Assert.That(tryResult.Error, Is.False);
            Assert.That(tryResult.Exception, Is.Null);
        }

        #region TestMethods

        private void ThrowingAction()
        {
            throw _testException;
        }

        private void NonThrowingAction()
        {
        }

        private int AddTwoNumbers(int first, int second)
        {
            return first + second;
        }

        private int ThrowingFunction()
        {
            throw _testException;
        }

        private string NonThrowingFunction()
        {
            return null;
        }

        private async Task ThrowingAwaitableTask()
        {
            await Task.Yield();
            throw _testException;
        }

        private async Task NonThrowingAwaitableTask()
        {
            await Task.Yield();
        }

        private async Task<int> AddTwoNumbersAsync(int first, int second)
        {
            await Task.Yield();
            return first + second;
        }

        private async Task<int> ThrowingAwaitableTaskT()
        {
            await Task.Yield();
            throw _testException;
        }

        private async Task<string> NonThrowingAwaitableTaskT()
        {
            await Task.Yield();
            return null;
        }

        #endregion
    }
}
