using Foundation;
using System;
using UIKit;

namespace XamarinNativePractialCoding
{
    public partial class UserCustomTableViewCell : UITableViewCell
    {
        public UserCustomTableViewCell(IntPtr handle) : base(handle) { }

        public UserCustomTableViewCell(NSString cellId, string displayText, UIImage personIcon) : base(UITableViewCellStyle.Default, cellId)
        {
            UserNameLabel.Text = displayText;
            UserImage.Image = personIcon;
        }

        public void UpdateCellData(string displayText, UIImage personIcon)
        {
            UserNameLabel.Text = displayText;
            UserImage.Image = personIcon;
        }
    }
}