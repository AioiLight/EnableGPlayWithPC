namespace EnableGPlayWithPC
{
    partial class FileSelector
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.Button_FileOpen = new System.Windows.Forms.Button();
            this.TextBox_Path = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Button_FileOpen
            // 
            this.Button_FileOpen.Location = new System.Drawing.Point(457, 3);
            this.Button_FileOpen.Name = "Button_FileOpen";
            this.Button_FileOpen.Size = new System.Drawing.Size(140, 36);
            this.Button_FileOpen.TabIndex = 1;
            this.Button_FileOpen.Text = "Open...";
            this.Button_FileOpen.UseVisualStyleBackColor = true;
            this.Button_FileOpen.Click += new System.EventHandler(this.Button_FileOpen_Click);
            // 
            // TextBox_Path
            // 
            this.TextBox_Path.Location = new System.Drawing.Point(3, 8);
            this.TextBox_Path.Name = "TextBox_Path";
            this.TextBox_Path.ReadOnly = true;
            this.TextBox_Path.Size = new System.Drawing.Size(448, 27);
            this.TextBox_Path.TabIndex = 0;
            // 
            // FileSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBox_Path);
            this.Controls.Add(this.Button_FileOpen);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FileSelector";
            this.Size = new System.Drawing.Size(600, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_FileOpen;
        private System.Windows.Forms.TextBox TextBox_Path;
    }
}
