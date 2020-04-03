// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XamarinNativePractialCoding
{
    [Register ("AddUserViewController")]
    partial class AddUserViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField FirstNameField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField LastNameField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PasswordField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TitleField { get; set; }

        [Action ("AddUserButton8588_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AddUserButton8588_TouchUpInside (XamarinNativePractialCoding.AddUserButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (FirstNameField != null) {
                FirstNameField.Dispose ();
                FirstNameField = null;
            }

            if (LastNameField != null) {
                LastNameField.Dispose ();
                LastNameField = null;
            }

            if (PasswordField != null) {
                PasswordField.Dispose ();
                PasswordField = null;
            }

            if (TitleField != null) {
                TitleField.Dispose ();
                TitleField = null;
            }
        }
    }
}