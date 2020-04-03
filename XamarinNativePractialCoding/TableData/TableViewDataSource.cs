using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CoreFoundation;
using Foundation;
using UIKit;
using Xamarin.Essentials;
using XamarinNativePractialCoding.Models;

namespace XamarinNativePractialCoding.TableData
{
    public class TableViewDataSource : UITableViewSource
    {
        static readonly NSString CellIdentifier = new NSString("UserCellStyle");
        readonly List<Person> people = new List<Person>();
        readonly UITableViewController controller;

        public TableViewDataSource(UITableViewController controller)
        {
            this.controller = controller;

        }

        public IList<Person> People
        {
            get { return people; }
        }



        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return people.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UserCustomTableViewCell cell = (UserCustomTableViewCell)tableView.DequeueReusableCell(CellIdentifier);
            Person person = People[indexPath.Row];

            cell.UpdateCellData($"{person.Lastname},{person.Firstname} ({person.Title})", UIImage.FromBundle("person"));

            return cell;
        }



        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {
            if (editingStyle == UITableViewCellEditingStyle.Delete)
            {
                DataService.SaveDataToDisk(People[indexPath.Row], true);
                people.RemoveAt(indexPath.Row);
                controller.TableView.DeleteRows(new[] { indexPath }, UITableViewRowAnimation.Fade);
            }

        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            string password = Xamarin.Essentials.SecureStorage.GetAsync(people[indexPath.Row].Id.ToString()).Result;

            var alert = UIAlertController.Create("Details", $"Password for {people[indexPath.Row].Firstname} is {password}", UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            controller.PresentViewController(alert, true, null);
        }

    }
}
