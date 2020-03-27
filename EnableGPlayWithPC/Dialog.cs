using System;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace EnableGPlayWithPC
{
    internal static class Dialog
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

        internal static TaskDialogResult ShowQuestion(string instruction, string desc, IntPtr handle)
        {
            var dialog = new TaskDialog();
            dialog.Caption = "Enable GPlay With PC";
            dialog.InstructionText = instruction;
            dialog.Text = desc;
            dialog.Icon = TaskDialogStandardIcon.None;
            dialog.OwnerWindowHandle = handle;
            dialog.StandardButtons = TaskDialogStandardButtons.Ok | TaskDialogStandardButtons.Cancel;
            return dialog.Show();
        }
    }
}
