using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using XamarinNativePractialCoding.Models;
using System.Linq;
using XamarinNativePractialCoding.TableData;
using System.Threading.Tasks;
using XamarinNativePractialCoding.ExtensionMethods;

namespace XamarinNativePractialCoding
{
    public partial class UsersTableViewController : UITableViewController
    {
        readonly TableViewDataSource dataSource;

        public UsersTableViewController(IntPtr handle) : base(handle)
        {
            TableView.Source = dataSource = new TableViewDataSource(this);
        }

        public void AddUser(string firstname, string lastname, string title, string password)
        {
            int lastIndex = dataSource.People.IndexOf(dataSource.People?.LastOrDefault()) + 1;

            Person newPerson = new Person
            {
                Id = Guid.NewGuid().ToString(),
                Firstname = firstname.Replace(Global.DELIMITTER, string.Empty),
                Lastname = lastname.Replace(Global.DELIMITTER, string.Empty),
                Title = title.Replace(Global.DELIMITTER, string.Empty),
                Password = password
            };

            dataSource.People.Insert(lastIndex, newPerson);

            DataService.SaveDataToDisk(newPerson);

            Xamarin.Essentials.SecureStorage.SetAsync(newPerson.Id.ToString(), newPerson.Password);

            using (var indexPath = NSIndexPath.FromRowSection(lastIndex, 0))
                TableView.InsertRows(new[] { indexPath }, UITableViewRowAnimation.Automatic);
        }

        private void AddUsersFromStorage()
        {
            if (string.IsNullOrEmpty(Global.PersistedData)) { return; }

            string[] users = Global.PersistedData.Split("\r".ToCharArray());


            for (int i = 0; i < users.Length; i++)
            {
                if (!string.IsNullOrEmpty(users[i]))
                {
                    Person person = users[i].ToPerson();
                    person.Password = Xamarin.Essentials.SecureStorage.GetAsync(person.Id).Result;
                    dataSource.People.Insert(i, users[i].ToPerson());
                    using (var indexPath = NSIndexPath.FromRowSection(i, 0))
                        TableView.InsertRows(new[] { indexPath }, UITableViewRowAnimation.Automatic);
                }

            }

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            AddUsersFromStorage();

        }

    }
}