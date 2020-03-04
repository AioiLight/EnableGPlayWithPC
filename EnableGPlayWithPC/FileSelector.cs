using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace EnableGPlayWithPC
{
    public partial class FileSelector : UserControl
    {
        public FileSelector()
        {
            InitializeComponent();
        }

        internal void Init(string defaultPath)
        {
            TextBox_Path.Text = defaultPath;
        }

        internal string GetPath()
        {
            return TextBox_Path.Text;
        }

        private void Button_FileOpen_Click(object sender, EventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.Title = Properties.Resources.FileSelector_Title;
            // .apkのフィルタ作成
            var filter = new CommonFileDialogFilter(Properties.Resources.FileSelector_Extension, Properties.Resources.FileSelector_Extension);
            dialog.Filters.Add(filter);
            dialog.Multiselect = false;
            // 現在のパスをデフォルトのディレクトリとする
            dialog.InitialDirectory = Path.GetDirectoryName(TextBox_Path.Text);

            var result = dialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                TextBox_Path.Text = dialog.FileName;
            }
        }
    }
}
