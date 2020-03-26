using System;
using System.Windows.Forms.VisualStyles;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace EnableGPlayWithPC
{
    internal static class Dialog
    {
        internal static void Error(string instruction, string desc, IntPtr handle)
        {
            var dialog = new TaskDialog();
            dialog.Caption = "Enable GPlay With PC";
            dialog.InstructionText = instruction;
            dialog.Text = desc;
            dialog.Icon = TaskDialogStandardIcon.Error;
            dialog.OwnerWindowHandle = handle;
            dialog.Show();
        }

        /// <summary>
        /// trueが返されると続行、falseが返されるとキャンセル。
        /// </summary>
        /// <param name="instruction"></param>
        /// <param name="desc"></param>
        /// <param name="detail"></param>
        /// <param name="handle"></param>
        /// <returns></returns>
        internal static bool NotGranted(string instruction, string desc, string detail, IntPtr handle)
        {
            var dialog = new TaskDialog();
            dialog.Caption = "Enable GPlay With PC";
            dialog.InstructionText = instruction;
            dialog.Text = desc;
            dialog.Icon = TaskDialogStandardIcon.Error;
            dialog.OwnerWindowHandle = handle;

            dialog.DetailsCollapsedLabel = Properties.Resources.NotGranted_ShowDetail;
            dialog.DetailsExpandedLabel = Properties.Resources.NotGranted_HideDetail;
            dialog.DetailsExpandedText = detail;
            dialog.DetailsExpanded = false;
            dialog.ExpansionMode = TaskDialogExpandedDetailsLocation.ExpandFooter;

            var continueButton = new TaskDialogCommandLink("continue", Properties.Resources.NotGranted_Continue);
            continueButton.Default = true;
            continueButton.Click += (sender, e) => dialog.Close(TaskDialogResult.Ok);
            dialog.Controls.Add(continueButton);

            var cancelButton = new TaskDialogCommandLink("cancel", Properties.Resources.NotGranted_Cancel);
            cancelButton.Click += (sender, e) => dialog.Close(TaskDialogResult.Cancel);
            dialog.Controls.Add(cancelButton);

            return dialog.Show() == TaskDialogResult.Ok ? true : false;
        }
    }
}
