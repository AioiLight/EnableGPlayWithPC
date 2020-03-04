using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
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
            var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var adb = new AdbServer();

            var result = adb.StartServer(Path.Combine(appDir, Properties.Resources.AdbPath), true);

            var device = AdbClient.Instance.GetDevices().First();

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

        private string[] GetSelectedPath()
        {
            return new string[]
            {
                FileSelector_Vending.Text,
                FileSelector_GMS.Text,
                FileSelector_GSF.Text,
                FileSelector_GSFLogin.Text
            };
        }
    }
}
