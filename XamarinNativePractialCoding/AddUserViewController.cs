using Foundation;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using UIKit;

namespace XamarinNativePractialCoding
{
    public partial class AddUserViewController : UIViewController
    {
        public AddUserViewController(IntPtr handle) : base(handle) { }


        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            FirstNameField.BecomeFirstResponder();
        }

        public static bool ValidatePassword(string password)
        {
            bool isValid;


            bool hasIllegalChars = password.ToCharArray().Any(c => !char.IsLetterOrDigit(c));

            bool hasNumber = password.ToCharArray().Any(c => char.IsDigit(c));

            bool hasLetter = password.ToCharArray().Any(c => char.IsLetter(c));

            bool hasCorrectLength = password.Length >= 5 && password.Length <= 12;

            bool hasNoConsecutiveChars = Regex.IsMatch(password, "([a-zA-Z])\\1{" + (1) + "}");



            isValid = (!hasIllegalChars && hasCorrectLength && !hasNoConsecutiveChars && hasLetter && hasNumber);

            return isValid;

        }

        partial void AddUserButton_TouchUpInside(UIButton sender)
        {
            if (ValidatePassword(PasswordField.Text))
            {
                var usersTab = this.TabBarController?.ViewControllers[0] as UsersTableViewController;
                usersTab.AddUser(FirstNameField.Text = string.IsNullOrEmpty(FirstNameField.Text) ? "<Unknown>" : FirstNameField.Text,
                    LastNameField.Text = string.IsNullOrEmpty(LastNameField.Text) ? "<Unknown>" : LastNameField.Text,
                    TitleField.Text = string.IsNullOrEmpty(TitleField.Text) ? "<Unknown>" : TitleField.Text,
                    PasswordField.Text);
                ClearValuesAndGoHome();


            }
            else
            {
                var alert = UIAlertController.Create("Validation", $"Password is invalid", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(alert, true, null);
                PasswordField.Text = string.Empty;
            }
        }

        private void ClearValuesAndGoHome()
        {
            FirstNameField.Text = string.Empty;
            LastNameField.Text = string.Empty;
            TitleField.Text = string.Empty;
            PasswordField.Text = string.Empty;

            TabBarController.SelectedIndex = 0;
        }

        partial void CancelButton_TouchUpInside(UIButton sender)
        {
            ClearValuesAndGoHome();
        }
    }
}