using System;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace EnableGPlayWithPC
{
    internal static class ErrorDialog
    {
        internal static void ShowError(string instruction, string desc, IntPtr handle)
        {
            var dialog = new TaskDialog();
            dialog.Caption = "Enable GPlay With PC";
            dialog.InstructionText = instruction;
            dialog.Text = desc;
            dialog.Icon = TaskDialogStandardIcon.Error;
            dialog.OwnerWindowHandle = handle;
            dialog.Show();
        }
    }
}
