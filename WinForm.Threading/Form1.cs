using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm.Threading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region "UI Actions"

        private void cmdLongJobOnThread_Click(object sender, EventArgs e)
        {
            var taskRunner = new LongJobThread<List<int>>();
            taskRunner.Execute(() => MyLongRunningFunction(), (callback) =>
            {
                string message = "Long running on thread: " + callback.Count().ToString();
                //ShowMessage(message);
                ShowMessage(message);
            });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var taskRunner = new LongJobThread<List<int>>();
            var task = taskRunner.Execute(() => MyLongRunningFunction());
            task.ContinueWith((t) =>
            {
                ShowMessage("Long running on thread 2: " + t.Result.Count().ToString());
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var taskRunner = new LongJobThread<List<int>>();

            var tcs = new CancellationTokenSource();
            //tcs.CancelAfter(500); // if you want to cancel after few seconds
            var task = taskRunner.ExecuteWithCompletionSource(() => MyLongRunningFunctionWithCancel(tcs.Token), tcs.Token);
            if (task.IsCanceled)
            {
                ShowMessage("Task was cancelled.");
                return;
            }

            task.ContinueWith((t) =>
            {
                ShowMessage("Task completion source: " + t.Result.Sum().ToString());
            }).ContinueWith((a, b) =>
            {
                ShowMessage("Task was cancelled.");
            }, tcs.Token, TaskContinuationOptions.OnlyOnCanceled);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var tcs = new CancellationTokenSource();
                tcs.CancelAfter(500);
                await MyLongRunningFunctionWithCancelAsync(tcs.Token);
            }
            catch (OperationCanceledException oce)
            {
                ShowMessage("Task automatically cancels after 500ms: " + oce.Message);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }


        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var tcs = new CancellationTokenSource();
                // tcs.CancelAfter(1500);
                var result = await MyLongRunningFunctionWithCancelAsync(tcs.Token);
                ShowMessage("Using Async and Await: " + result.Count.ToString());
            }
            catch (OperationCanceledException oce)
            {
                ShowMessage(oce.Message);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }


        #endregion

        #region "Helper functions"


        private void ShowMessage(string message)
        {
            txtResult.InvokeRequired(s =>
            {
                s.Text += message + Environment.NewLine;
            });

            //MessageBox.Show(message);
        }
        private List<int> MyLongRunningFunction()
        {
            Thread.Sleep(5000);
            return new List<int>()
            {
                1,
                2,
                3,
                4
            };
        }

        private List<int> MyLongRunningFunctionWithCancel(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            Thread.Sleep(5000);
            token.ThrowIfCancellationRequested();

            return new List<int>()
            {
                1,
                2,
                3,
                4
            };
        }

        private async Task<List<int>> MyLongRunningFunctionWithCancelAsync(CancellationToken token)
        {
            await Task.Delay(2000, token);

            token.Register(() =>
            {
                throw new Exception("User has cancelled!");
            });

            token.ThrowIfCancellationRequested();

            return new List<int>()
            {
                1,
                2,
                3,
                4
            };
        }

        #endregion
    }
}
