using System.ComponentModel;

namespace Bluepill.UI
{
    public class BluepillProgress
    {
        private BackgroundWorker worker = new BackgroundWorker();
        private BluepillProgressInterface progressclass;

        public BluepillProgress(DoWorkEventHandler DoWork, BluepillProgressInterface progressclass)
        {
            this.progressclass = progressclass;
            worker.DoWork += DoWork;
            progressclass.Initialize();
            worker.RunWorkerAsync();
            progressclass.Show();
        }
    }
}