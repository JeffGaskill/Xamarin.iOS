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
    [Register ("UserCellStyle")]
    partial class UserCustomTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView UserImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UserNameLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (UserImage != null) {
                UserImage.Dispose ();
                UserImage = null;
            }

            if (UserNameLabel != null) {
                UserNameLabel.Dispose ();
                UserNameLabel = null;
            }
        }
    }
}