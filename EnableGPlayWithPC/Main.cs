using System;
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

#if !DEBUG
            try
            {
#endif
                var device = AdbClient.Instance.GetDevices().First();

                if (AdbClient.Instance.GetDevices().Count > 1)
                {
                    ErrorDialog.ShowError(Properties.Resources.Dialog_TooManyDevices_Inst,
                        Properties.Resources.Dialog_TooManyDevices_Desc, Handle);
                    return;
                }

                var packageManager = new PackageManager(device);

                // それぞれアンインストール
                Array.ForEach(Packages.PackageNames, pkg => packageManager.UninstallPackage(pkg));

                // パスを取得
                var apks = GetSelectedPath();
                // それぞれインストール
                Array.ForEach(apks, apk => packageManager.InstallPackage(apk, true));

                // Play ストアに権限付与
                foreach (var perm in Permissions.Vending)
                {
                    var cmd = $"pm grant {Packages.Vending} {Permissions.Prefix}{perm}";
                    AdbClient.Instance.ExecuteRemoteCommand(cmd, device, null);
                }

                // GooglePlay開発者サービスはに権限付与
                foreach (var perm in Permissions.GMS)
                {
                    var cmd = $"pm grant {Packages.GMS} {Permissions.Prefix}{perm}";
                    AdbClient.Instance.ExecuteRemoteCommand(cmd, device, null);
                }
#if !DEBUG
        }
            catch (Exception)
            {
                ErrorDialog.ShowError(Properties.Resources.Dialog_UnableToConnect_Inst,
                    Properties.Resources.Dialog_UnableToConnect_Desc, this.Handle);
                return;
            }
#endif

            var dialog = new TaskDialog();
        }

        private string[] GetSelectedPath()
        {
            return new string[]
            {
                FileSelector_Vending.GetPath(),
                FileSelector_GMS.GetPath(),
                FileSelector_GSF.GetPath(),
                FileSelector_GSFLogin.GetPath()
            };
        }
    }
}
