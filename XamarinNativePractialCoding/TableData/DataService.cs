using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XamarinNativePractialCoding.ExtensionMethods;
using XamarinNativePractialCoding.Models;

namespace XamarinNativePractialCoding.TableData
{

    public class DataService
    {
        static string appData = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        static string userstxt = Path.Combine(appData, Global.DATA_FILE);

        public static async Task<string> FetchDataFromDiskAsync()
        {

            using (var stream = File.OpenRead(userstxt))
            {
                using (var reader = new StreamReader(stream))
                {
                    var fileContents = await reader.ReadToEndAsync();
                    return fileContents;
                }
            }

        }
        public static void SaveDataToDisk(Person person, bool removeRecord = false)
        {
            if (removeRecord)
            {
                List<string> users = File.ReadAllLines(userstxt).ToList();
                users.Remove(users.Where(u => u.Contains(person.Id)).FirstOrDefault());

                File.Delete(userstxt);

                FileStream fileStream = File.Create(userstxt);

                fileStream.Close();

                File.WriteAllLines(userstxt, users.ToArray());
            }
            else
            {
                File.AppendAllText(userstxt, $"{person.SerializePerson()}\r");
            }

        }

    }
}