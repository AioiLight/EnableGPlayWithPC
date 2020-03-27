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
                    Dialog.Error(string.Format(Properties.Resources.Dialog_404_Inst, path),
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
                Dialog.Error(Properties.Resources.Dialog_Adb404_Inst,
                    Properties.Resources.Dialog_Adb404_Desc, Handle);
                return;
            }

            try
            {
                var device = AdbClient.Instance.GetDevices().First();

                if (AdbClient.Instance.GetDevices().Count > 1)
                {
                    Dialog.Error(Properties.Resources.Dialog_TooManyDevices_Inst,
                        Properties.Resources.Dialog_TooManyDevices_Desc, Handle);
                    return;
                }

                var receiver = new ConsoleOutputReceiver();

                AdbClient.Instance.ExecuteRemoteCommand($"getprop ro.build.product", device, receiver);
                var product = receiver.ToString();
                product = product.Substring(0, product.Length - 2); // 余計な改行は入れさせない

                Console.WriteLine(product.Length);

                if (!BenesseTabs.Names.Contains(product))
                { // 出力が名前にあるか確認
                    var result =
                        Dialog.ShowQuestion(Properties.Resources.Dialog_Not_Benesse_Tab_Inst,
                        string.Format(Properties.Resources.Dialog_Not_Benesse_Tab_Desc, product), Handle);

                    if (result != TaskDialogResult.Ok) return;
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
                    var receiver = new ConsoleOutputReceiver();
                    var cmd = $"pm grant {Packages.Vending} {Permissions.Prefix}{perm}";
                    AdbClient.Instance.ExecuteRemoteCommand(cmd, device, receiver);

                    if (!IsPermissionGranted(receiver.ToString()))
                    {
                        if (!Dialog.NotGranted(
                            string.Format(Properties.Resources.Dialog_PermNotGranted_Inst,
                                Packages.Vending),
                            string.Format(Properties.Resources.Dialog_PermNotGranted_Desc,
                                Packages.Vending,
                                perm),
                            receiver.ToString(),
                            Handle))
                        {
                            // 権限付与に失敗してなおかつキャンセルされた
                            return;
                        }
                    }
                }

                // GooglePlay開発者サービスに権限付与
                foreach (var perm in Permissions.GMS)
                {
                    var receiver = new ConsoleOutputReceiver();
                    var cmd = $"pm grant {Packages.GMS} {Permissions.Prefix}{perm}";
                    AdbClient.Instance.ExecuteRemoteCommand(cmd, device, receiver);

                    if (!IsPermissionGranted(receiver.ToString()))
                    {
                        if (!Dialog.NotGranted(
                            string.Format(Properties.Resources.Dialog_PermNotGranted_Inst,
                                Packages.GMS),
                            string.Format(Properties.Resources.Dialog_PermNotGranted_Desc,
                                Packages.GMS,
                                perm),
                            receiver.ToString(),
                            Handle))
                        {
                            // 権限付与に失敗してなおかつキャンセルされた
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Dialog.Error(Properties.Resources.Dialog_UnableToConnect_Inst,
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

        private bool IsPermissionGranted(string str)
        {
            var lines = str.Split('\n');
            if (lines.Where(s => s.StartsWith("Operation not allowed:")).Any())
            {
                // Operation not allowed:で始まる行が少なくともひとつはある
                return false;
            }
            else
            {
                // パーミション付与に成功している
                return true;
            }
        }

        private void LinkLabel_Repo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://github.com/AioiLight/EnableGPlayWithPC");
        }
    }
}
