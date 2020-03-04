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
                    ErrorDialog.ShowError($"{path} is not found",
                        $"{path} is not found.\n" +
                        "Please check to exist that file.", this.Handle);
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
                ErrorDialog.ShowError("adb.exe is not found", "adb.exe is not found.\n" +
                            "Please check adb.exe's path.", this.Handle);
                return;
            }

            try
            {
                var device = AdbClient.Instance.GetDevices().First();

                if (AdbClient.Instance.GetDevices().Count > 1)
                {
                    ErrorDialog.ShowError("Too many connected devices",
                        "Too many connected devices.\n" +
                        "Please connect only one devices.", this.Handle);
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
            }
            catch (Exception)
            {
                ErrorDialog.ShowError("Unable to connect your device",
                    "Unable to connect your device.\n" +
                    "Please check connection.", this.Handle);
                return;
            }

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
