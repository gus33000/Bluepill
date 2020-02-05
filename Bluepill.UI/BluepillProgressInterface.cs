using System.ComponentModel;

namespace Bluepill.UI
{
    public interface BluepillProgressInterface
    {
        void Initialize();
        void Show();
        void ReportProgress(int ProgressPercentage, string StatusMessage);
        void Close();
    }
}
