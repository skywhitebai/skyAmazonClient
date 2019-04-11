namespace skyAmazonClient
{
    partial class DealInfoForm
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
            this.txtDealInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDealInfo
            // 
            this.txtDealInfo.Location = new System.Drawing.Point(30, 25);
            this.txtDealInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtDealInfo.Multiline = true;
            this.txtDealInfo.Name = "txtDealInfo";
            this.txtDealInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDealInfo.Size = new System.Drawing.Size(571, 358);
            this.txtDealInfo.TabIndex = 6;
            // 
            // DealInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 414);
            this.Controls.Add(this.txtDealInfo);
            this.Name = "DealInfoForm";
            this.Text = "处理信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DealInfoForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDealInfo;
    }
}