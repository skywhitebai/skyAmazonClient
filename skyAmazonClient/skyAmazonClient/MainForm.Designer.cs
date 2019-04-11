namespace skyAmazonClient
{
    partial class MainForm
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
            this.lbCurrentUserInfo = new System.Windows.Forms.Label();
            this.lvTask = new System.Windows.Forms.ListView();
            this.taskName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lastExecuteTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.executeTimes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.synDataNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dealInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lbCurrentUserInfo
            // 
            this.lbCurrentUserInfo.AutoSize = true;
            this.lbCurrentUserInfo.Location = new System.Drawing.Point(29, 20);
            this.lbCurrentUserInfo.Name = "lbCurrentUserInfo";
            this.lbCurrentUserInfo.Size = new System.Drawing.Size(112, 15);
            this.lbCurrentUserInfo.TabIndex = 0;
            this.lbCurrentUserInfo.Text = "登录用户名信息";
            // 
            // lvTask
            // 
            this.lvTask.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.taskName,
            this.lastExecuteTime,
            this.executeTimes,
            this.synDataNumber,
            this.status,
            this.dealInfo});
            this.lvTask.Location = new System.Drawing.Point(12, 55);
            this.lvTask.Name = "lvTask";
            this.lvTask.Size = new System.Drawing.Size(887, 361);
            this.lvTask.TabIndex = 1;
            this.lvTask.UseCompatibleStateImageBehavior = false;
            this.lvTask.View = System.Windows.Forms.View.Details;
            // 
            // taskName
            // 
            this.taskName.Text = "任务名称";
            // 
            // lastExecuteTime
            // 
            this.lastExecuteTime.Text = "最后一次执行时间";
            this.lastExecuteTime.Width = 130;
            // 
            // executeTimes
            // 
            this.executeTimes.Text = "执行次数";
            // 
            // synDataNumber
            // 
            this.synDataNumber.Text = "同步数量";
            // 
            // status
            // 
            this.status.Text = "状态";
            this.status.Width = 40;
            // 
            // dealInfo
            // 
            this.dealInfo.Text = "处理信息";
            this.dealInfo.Width = 300;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 442);
            this.Controls.Add(this.lvTask);
            this.Controls.Add(this.lbCurrentUserInfo);
            this.Name = "MainForm";
            this.Text = "点点通数据助手";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCurrentUserInfo;
        private System.Windows.Forms.ListView lvTask;
        private System.Windows.Forms.ColumnHeader taskName;
        private System.Windows.Forms.ColumnHeader lastExecuteTime;
        private System.Windows.Forms.ColumnHeader executeTimes;
        private System.Windows.Forms.ColumnHeader synDataNumber;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.ColumnHeader dealInfo;
    }
}