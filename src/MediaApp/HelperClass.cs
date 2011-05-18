using System.ComponentModel;

namespace MediaApp
{
    class HelperClass
    {
        public static BackgroundWorker NewBGW()
        {
            return new BackgroundWorker() {WorkerReportsProgress = true, WorkerSupportsCancellation = true};
        }
    }
}
