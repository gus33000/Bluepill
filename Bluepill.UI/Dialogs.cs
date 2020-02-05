using System;
using System.Diagnostics;
using WindowsFormsAero.TaskDialog;

namespace Bluepill.UI
{
    public static class Dialogs
    {
        public static void ShowExceptionDialog(Exception ex)
        {
            var dlg = new TaskDialog("An unhandled exception has occured", "Bluepill", "Something unexpected happened and we couldn't handle it. If your computer was in Setup Mode, your computer will now reboot into normal mode. If you were in the out of box experience before Setup Mode, you'll have to reinstall Windows.", CommonButton.Close, CommonIcon.Stop);
            dlg.ShowExpandedInfoInFooter = true;
            dlg.ExpandedControlText = "Details";
            dlg.ExpandedInformation = ex.ToString();

            dlg.Show();
        }

        public enum Choices
        {
            Install,
            Uninstall,
            ViewStatus,
            Close
        }

        public static Choices ShowChoiceDialog()
        {
            TaskDialog dlg = new TaskDialog("What do you want to do?", "Bluepill");
            dlg.CommonIcon = CommonIcon.None;
            dlg.Content = "Please select one option from this list.";
            dlg.UseCommandLinks = true;
            dlg.EnableHyperlinks = true;
            dlg.AllowDialogCancellation = false;
            dlg.CustomButtons = new CustomButton[] {
                new CustomButton(9, "Install Bluepill"),
                new CustomButton(10, "Uninstall Bluepill"),
                new CustomButton(11, "View status of Bluepill"),
                new CustomButton(CommonButtonResult.Cancel, "Close Bluepill")
            };

            TaskDialogResult results = dlg.Show();

            switch (results.ButtonID)
            {
                case 9:
                    {
                        return Choices.Install;
                    }
                case 10:
                    {
                        return Choices.Uninstall;
                    }
                case 11:
                    {
                        return Choices.ViewStatus;
                    }
                default:
                    {
                        return Choices.Close;
                    }
            }
        }
    }
}
