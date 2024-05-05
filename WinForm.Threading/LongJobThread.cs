using System;
using System.Threading;
using System.Threading.Tasks;

namespace WinForm.Threading
{
    public class LongJobThread<TResult>
    {
        public LongJobThread()
        {
        }

        public LongJobThread(SynchronizationContext context)
        {
            Context = context;
        }


        public void Execute(Func<TResult> func, Action<TResult> callback)
        {
            var task = Task.Run(() => func());
            task.GetAwaiter().OnCompleted(() =>
            {
                var result = task.Result;
                callback(result);
            });
        }

        public Task<TResult> Execute(Func<TResult> func)
        {
            TResult result = default(TResult);
            var task = Task.Run(() => func());

            task.ContinueWith((t) =>
            {
                result = t.Result;
            });

            return task;
        }

        public Task<TResult> ExecuteWithCompletionSource(Func<TResult> func, CancellationToken token)
        {
            var tcs = new TaskCompletionSource<TResult>();

            Task<TResult> tsk = null;
            try
            {
                tsk = Task.Run(() => func(), token);
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }

            tsk.ContinueWith((t) =>
            {
                try
                {
                    tcs.SetResult(t.Result);
                }
                catch (OperationCanceledException)
                {
                    tcs.SetCanceled();
                }
            }, token);

            if (token.IsCancellationRequested)
            {
                tcs.SetCanceled();
            }

            return tcs.Task;
        }

        public SynchronizationContext Context { get; }
    }
}
