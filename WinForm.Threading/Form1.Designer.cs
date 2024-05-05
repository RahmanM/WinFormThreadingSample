namespace WinForm.Threading
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdLongJobOnThreadCallback = new System.Windows.Forms.Button();
            this.cmdLongRunningThreadContinueWith = new System.Windows.Forms.Button();
            this.cmdTaskCompletionSource = new System.Windows.Forms.Button();
            this.cmdAsyncTaskCancelation = new System.Windows.Forms.Button();
            this.cmdAsyncTaskResult = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdLongJobOnThreadCallback
            // 
            this.cmdLongJobOnThreadCallback.Location = new System.Drawing.Point(9, 10);
            this.cmdLongJobOnThreadCallback.Margin = new System.Windows.Forms.Padding(2);
            this.cmdLongJobOnThreadCallback.Name = "cmdLongJobOnThreadCallback";
            this.cmdLongJobOnThreadCallback.Size = new System.Drawing.Size(378, 30);
            this.cmdLongJobOnThreadCallback.TabIndex = 0;
            this.cmdLongJobOnThreadCallback.Text = "Run long job on thread";
            this.cmdLongJobOnThreadCallback.UseVisualStyleBackColor = true;
            this.cmdLongJobOnThreadCallback.Click += new System.EventHandler(this.cmdLongJobOnThread_Click);
            // 
            // cmdLongRunningThreadContinueWith
            // 
            this.cmdLongRunningThreadContinueWith.Location = new System.Drawing.Point(9, 45);
            this.cmdLongRunningThreadContinueWith.Margin = new System.Windows.Forms.Padding(2);
            this.cmdLongRunningThreadContinueWith.Name = "cmdLongRunningThreadContinueWith";
            this.cmdLongRunningThreadContinueWith.Size = new System.Drawing.Size(378, 30);
            this.cmdLongRunningThreadContinueWith.TabIndex = 1;
            this.cmdLongRunningThreadContinueWith.Text = "Run long job on thread 2";
            this.cmdLongRunningThreadContinueWith.UseVisualStyleBackColor = true;
            this.cmdLongRunningThreadContinueWith.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdTaskCompletionSource
            // 
            this.cmdTaskCompletionSource.Location = new System.Drawing.Point(9, 88);
            this.cmdTaskCompletionSource.Margin = new System.Windows.Forms.Padding(2);
            this.cmdTaskCompletionSource.Name = "cmdTaskCompletionSource";
            this.cmdTaskCompletionSource.Size = new System.Drawing.Size(378, 27);
            this.cmdTaskCompletionSource.TabIndex = 2;
            this.cmdTaskCompletionSource.Text = "Run long running task using Task Completion Source                       ";
            this.cmdTaskCompletionSource.UseVisualStyleBackColor = true;
            this.cmdTaskCompletionSource.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmdAsyncTaskCancelation
            // 
            this.cmdAsyncTaskCancelation.Location = new System.Drawing.Point(9, 130);
            this.cmdAsyncTaskCancelation.Margin = new System.Windows.Forms.Padding(2);
            this.cmdAsyncTaskCancelation.Name = "cmdAsyncTaskCancelation";
            this.cmdAsyncTaskCancelation.Size = new System.Drawing.Size(364, 20);
            this.cmdAsyncTaskCancelation.TabIndex = 3;
            this.cmdAsyncTaskCancelation.Text = "Async Task cancellation";
            this.cmdAsyncTaskCancelation.UseVisualStyleBackColor = true;
            this.cmdAsyncTaskCancelation.Click += new System.EventHandler(this.button3_Click);
            // 
            // cmdAsyncTaskResult
            // 
            this.cmdAsyncTaskResult.Location = new System.Drawing.Point(14, 166);
            this.cmdAsyncTaskResult.Margin = new System.Windows.Forms.Padding(2);
            this.cmdAsyncTaskResult.Name = "cmdAsyncTaskResult";
            this.cmdAsyncTaskResult.Size = new System.Drawing.Size(359, 27);
            this.cmdAsyncTaskResult.TabIndex = 4;
            this.cmdAsyncTaskResult.Text = "Async task result";
            this.cmdAsyncTaskResult.UseVisualStyleBackColor = true;
            this.cmdAsyncTaskResult.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(14, 198);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(370, 177);
            this.txtResult.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 375);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.cmdAsyncTaskResult);
            this.Controls.Add(this.cmdAsyncTaskCancelation);
            this.Controls.Add(this.cmdTaskCompletionSource);
            this.Controls.Add(this.cmdLongRunningThreadContinueWith);
            this.Controls.Add(this.cmdLongJobOnThreadCallback);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdLongJobOnThreadCallback;
        private System.Windows.Forms.Button cmdLongRunningThreadContinueWith;
        private System.Windows.Forms.Button cmdTaskCompletionSource;
        private System.Windows.Forms.Button cmdAsyncTaskCancelation;
        private System.Windows.Forms.Button cmdAsyncTaskResult;
        private System.Windows.Forms.TextBox txtResult;
    }
}

