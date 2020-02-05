using WindowsFormsAero.TaskDialog;

namespace Bluepill.UI.Aero
{
    public class Aero : BluepillProgressInterface
    {
        TaskDialog dlg;

        public void Close()
        {
            TaskDialog newDlg = new TaskDialog("Installation complete.", "Bluepill", "You can now log off and log back on.");
            newDlg.CustomButtons = new CustomButton[]
            {
                        new CustomButton(CommonButtonResult.Cancel, "Close")
            };
            dlg.Navigate(newDlg);
        }

        public void Initialize()
        {
            dlg = new TaskDialog("Applying Bluepill", "Bluepill");
            dlg.AllowDialogCancellation = false;
            dlg.ShowProgressBar = true;
            dlg.ProgressBarMaxRange = 100;
            dlg.CustomButtons = new CustomButton[]
            {
                new CustomButton(CommonButtonResult.Cancel, "Cancel")
            };
            dlg.EnableButton(2, false);
        }

        public void ReportProgress(int ProgressPercentage, string StatusMessage)
        {
            dlg.Content = StatusMessage;
            dlg.ProgressBarPosition = ProgressPercentage;
            dlg.SetMarqueeProgressBar(ProgressPercentage == 0);
        }

        public void Show()
        {
            dlg.Show();
        }
    }
}
