using System;
using System.Collections.Generic;
using System.Linq;
using SharpAdbClient;

namespace EnableGPlayWithPC
{
    internal static class AndroidDebugBridgeUtils
    {
        /// <summary>
        /// ADBからの文字列を調べて、権限付与に成功しているかどうかチェックする。
        /// </summary>
        /// <param name="str">出力。</param>
        /// <returns>権限付与に成功しているかどうか。</returns>
        internal static bool IsPermissionGranted(string str)
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

        /// <summary>
        /// 権限を付与する。
        /// </summary>
        /// <param name="packageName">パッケージ名。</param>
        /// <param name="perms">権限の一覧。</param>
        /// <param name="device">ADB デバイス。</param>
        /// <param name="handle">ウィンドウハンドル。</param>
        /// <returns>成功したかどうか。</returns>
        internal static bool GrantPermissions(string packageName, IEnumerable<string> perms, DeviceData device, IntPtr handle)
        {
            foreach (var perm in perms)
            {
                var receiver = new ConsoleOutputReceiver();
                var cmd = $"pm grant {packageName} {Permissions.Prefix}{perm}";
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
                        handle))
                    {
                        // 権限付与に失敗してなおかつキャンセルされた
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
