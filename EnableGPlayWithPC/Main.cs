using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using SharpAdbClient;
using SharpAdbClient.DeviceCommands;

namespace EnableGPlayWithPC
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // それぞれのTextBoxにデフォルトのパスを入れておく
            FileSelector_Vending.Init(Path.Combine(appDir, Apks.Vending));
            FileSelector_GMS.Init(Path.Combine(appDir, Apks.GMS));
            FileSelector_GSF.Init(Path.Combine(appDir, Apks.GSF));
            FileSelector_GSFLogin.Init(Path.Combine(appDir, Apks.GSFLogin));
        }

        private void Button_Process_Click(object sender, EventArgs e)
        {
            foreach (var path in GetSelectedPath())
            {
                if (!File.Exists(path))
                {
                    ErrorDialog.ShowError(string.Format(Properties.Resources.Dialog_404_Inst, path),
                        string.Format(Properties.Resources.Dialog_404_Desc, path), Handle);
                    return;
                }
            }


            var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var adb = new AdbServer();

            try
            {
                var result = adb.StartServer(Path.Combine(appDir, Properties.Resources.AdbPath), true);
            }
            catch (Exception)
            {
                ErrorDialog.ShowError(Properties.Resources.Dialog_Adb404_Inst,
                    Properties.Resources.Dialog_Adb404_Desc, Handle);
                return;
            }

            try
            {
                var device = AdbClient.Instance.GetDevices().First();

                if (AdbClient.Instance.GetDevices().Count > 1)
                {
                    ErrorDialog.ShowError(Properties.Resources.Dialog_TooManyDevices_Inst,
                        Properties.Resources.Dialog_TooManyDevices_Desc, Handle);
                    return;
                }

                var packageManager = new PackageManager(device);

                // それぞれアンインストール
                foreach (var pkg in Packages.PackageNames)
                {
                    try
                    {
                        packageManager.UninstallPackage(pkg);
                    }
                    catch (Exception)
                    {

                    }
                }

                // パスを取得
                var apks = GetSelectedPath();
                // それぞれインストール
                Array.ForEach(apks, apk => packageManager.InstallPackage(apk, false));

                // Play ストアに権限付与
                foreach (var perm in Permissions.Vending)
                {
                    var cmd = $"pm grant {Packages.Vending} {Permissions.Prefix}{perm}";
                    AdbClient.Instance.ExecuteRemoteCommand(cmd, device, null);
                }

                // GooglePlay開発者サービスに権限付与
                foreach (var perm in Permissions.GMS)
                {
                    var cmd = $"pm grant {Packages.GMS} {Permissions.Prefix}{perm}";
                    AdbClient.Instance.ExecuteRemoteCommand(cmd, device, null);
                }
            }
            catch (Exception)
            {
                ErrorDialog.ShowError(Properties.Resources.Dialog_UnableToConnect_Inst,
                    Properties.Resources.Dialog_UnableToConnect_Desc, this.Handle);
                return;
            }

            var dialog = new TaskDialog();
            dialog.Caption = "Enable GPlay With PC";
            dialog.InstructionText = Properties.Resources.Dialog_Successed_Inst;
            dialog.Text = Properties.Resources.Dialog_Successed_Desc;
            dialog.Icon = TaskDialogStandardIcon.Information;
            dialog.OwnerWindowHandle = Handle;
            dialog.Show();
        }

        private string[] GetSelectedPath()
        {
            var files = new FileSelector[] { FileSelector_Vending, FileSelector_GMS, FileSelector_GSF, FileSelector_GSFLogin };
            return files.Select(f => f.GetPath()).ToArray();
        }

        private void LinkLabel_Repo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://github.com/AioiLight/EnableGPlayWithPC");
        }
    }
}
