using System.ComponentModel;

namespace Kolbalt.Client.Data
{
    class HelperClass
    {
        public static BackgroundWorker NewBGW()
        {
            return new BackgroundWorker() {WorkerReportsProgress = true, WorkerSupportsCancellation = true};
        }
    }
}
