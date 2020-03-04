namespace EnableGPlayWithPC
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.Label_Vending = new System.Windows.Forms.Label();
            this.Label_GMS = new System.Windows.Forms.Label();
            this.FileSelector_Vending = new EnableGPlayWithPC.FileSelector();
            this.FileSelector_GMS = new EnableGPlayWithPC.FileSelector();
            this.FileSelector_GSF = new EnableGPlayWithPC.FileSelector();
            this.Label_GSF = new System.Windows.Forms.Label();
            this.Label_GSFLogin = new System.Windows.Forms.Label();
            this.FileSelector_GSFLogin = new EnableGPlayWithPC.FileSelector();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label_Vending
            // 
            this.Label_Vending.AutoSize = true;
            this.Label_Vending.Location = new System.Drawing.Point(40, 34);
            this.Label_Vending.Name = "Label_Vending";
            this.Label_Vending.Size = new System.Drawing.Size(89, 20);
            this.Label_Vending.TabIndex = 4;
            this.Label_Vending.Text = "Google Play:";
            this.Label_Vending.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label_GMS
            // 
            this.Label_GMS.AutoSize = true;
            this.Label_GMS.Location = new System.Drawing.Point(28, 64);
            this.Label_GMS.Name = "Label_GMS";
            this.Label_GMS.Size = new System.Drawing.Size(101, 40);
            this.Label_GMS.TabIndex = 5;
            this.Label_GMS.Text = "Google Mobile\r\nService(GMS):";
            this.Label_GMS.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FileSelector_Vending
            // 
            this.FileSelector_Vending.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FileSelector_Vending.Location = new System.Drawing.Point(136, 14);
            this.FileSelector_Vending.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FileSelector_Vending.Name = "FileSelector_Vending";
            this.FileSelector_Vending.Size = new System.Drawing.Size(600, 40);
            this.FileSelector_Vending.TabIndex = 6;
            // 
            // FileSelector_GMS
            // 
            this.FileSelector_GMS.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FileSelector_GMS.Location = new System.Drawing.Point(136, 64);
            this.FileSelector_GMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FileSelector_GMS.Name = "FileSelector_GMS";
            this.FileSelector_GMS.Size = new System.Drawing.Size(600, 40);
            this.FileSelector_GMS.TabIndex = 7;
            // 
            // FileSelector_GSF
            // 
            this.FileSelector_GSF.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FileSelector_GSF.Location = new System.Drawing.Point(136, 114);
            this.FileSelector_GSF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FileSelector_GSF.Name = "FileSelector_GSF";
            this.FileSelector_GSF.Size = new System.Drawing.Size(600, 40);
            this.FileSelector_GSF.TabIndex = 8;
            // 
            // Label_GSF
            // 
            this.Label_GSF.AutoSize = true;
            this.Label_GSF.Location = new System.Drawing.Point(20, 114);
            this.Label_GSF.Name = "Label_GSF";
            this.Label_GSF.Size = new System.Drawing.Size(109, 40);
            this.Label_GSF.TabIndex = 9;
            this.Label_GSF.Text = "Google Services\r\nFramework:";
            this.Label_GSF.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label_GSFLogin
            // 
            this.Label_GSFLogin.AutoSize = true;
            this.Label_GSFLogin.Location = new System.Drawing.Point(38, 164);
            this.Label_GSFLogin.Name = "Label_GSFLogin";
            this.Label_GSFLogin.Size = new System.Drawing.Size(91, 40);
            this.Label_GSFLogin.TabIndex = 10;
            this.Label_GSFLogin.Text = "Google Login\r\nService:";
            this.Label_GSFLogin.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FileSelector_GSFLogin
            // 
            this.FileSelector_GSFLogin.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FileSelector_GSFLogin.Location = new System.Drawing.Point(136, 164);
            this.FileSelector_GSFLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FileSelector_GSFLogin.Name = "FileSelector_GSFLogin";
            this.FileSelector_GSFLogin.Size = new System.Drawing.Size(600, 40);
            this.FileSelector_GSFLogin.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 60);
            this.label1.TabIndex = 12;
            this.label1.Text = "When clicked \"Process\", Your ChallengePad\'s some apps will be uninstalled.\r\nAfter" +
    " that, those apps are re-installed.\r\nDo not touch your device until processed!!";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(591, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 57);
            this.button1.TabIndex = 13;
            this.button1.Text = "Process";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 313);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileSelector_GSFLogin);
            this.Controls.Add(this.Label_GSFLogin);
            this.Controls.Add(this.Label_GSF);
            this.Controls.Add(this.FileSelector_GSF);
            this.Controls.Add(this.FileSelector_GMS);
            this.Controls.Add(this.FileSelector_Vending);
            this.Controls.Add(this.Label_GMS);
            this.Controls.Add(this.Label_Vending);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
            this.Text = "Enable GPlay With PC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Label_Vending;
        private System.Windows.Forms.Label Label_GMS;
        private FileSelector FileSelector_Vending;
        private FileSelector FileSelector_GMS;
        private FileSelector FileSelector_GSF;
        private System.Windows.Forms.Label Label_GSF;
        private System.Windows.Forms.Label Label_GSFLogin;
        private FileSelector FileSelector_GSFLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

