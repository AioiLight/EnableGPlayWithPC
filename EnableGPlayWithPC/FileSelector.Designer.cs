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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSelector));
            this.Button_FileOpen = new System.Windows.Forms.Button();
            this.TextBox_Path = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Button_FileOpen
            // 
            resources.ApplyResources(this.Button_FileOpen, "Button_FileOpen");
            this.Button_FileOpen.Name = "Button_FileOpen";
            this.Button_FileOpen.UseVisualStyleBackColor = true;
            this.Button_FileOpen.Click += new System.EventHandler(this.Button_FileOpen_Click);
            // 
            // TextBox_Path
            // 
            resources.ApplyResources(this.TextBox_Path, "TextBox_Path");
            this.TextBox_Path.Name = "TextBox_Path";
            this.TextBox_Path.ReadOnly = true;
            // 
            // FileSelector
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBox_Path);
            this.Controls.Add(this.Button_FileOpen);
            this.Name = "FileSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_FileOpen;
        private System.Windows.Forms.TextBox TextBox_Path;
    }
}
