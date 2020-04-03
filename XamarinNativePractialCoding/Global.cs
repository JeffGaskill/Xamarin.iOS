using System.Threading;
using System.Threading.Tasks;
using XamarinNativePractialCoding.TableData;

namespace XamarinNativePractialCoding
{
    public static class Global
    {

        public static string PersistedData { get; private set; }
        public const string DELIMITTER = "#";
        public const string DATA_FILE = "users.txt";

        public static void Init()
        {
            SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);
            semaphoreSlim.Wait();

            try
            {
                Task.Run(async () =>
                {
                    PersistedData = await DataService.FetchDataFromDiskAsync();
                });
            }
            finally
            {
                semaphoreSlim.Release();
            }

        }

    }
}