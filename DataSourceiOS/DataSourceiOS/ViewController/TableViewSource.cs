using Foundation;
using Syncfusion.DataSource;
using Syncfusion.DataSource.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace DataSourceiOS
{
    #region TableViewSource
    public class TableViewSource : UITableViewSource
    {
        #region Fields

        DataSource dataSource;
        #endregion

        #region Constructor
        public TableViewSource(DataSource sfDataSource)
        {
            dataSource = sfDataSource;
        }
        #endregion

        #region Override methods
        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var item = dataSource.DisplayItems[indexPath.Row];
            UITableViewCell cell = tableView.DequeueReusableCell("TableCell") as UITableViewCell;

            if (cell == null)
            {
                cell = new UITableViewCell();
            }

            if (item is Contacts)
            {
                cell.TextLabel.MinimumFontSize = 12f;
                cell.TextLabel.Text = (item as Contacts).ContactName;
                cell.TextLabel.BackgroundColor = UIColor.Clear;
                cell.TextLabel.TextAlignment = UITextAlignment.Left;
            }
            else if (item is GroupResult)
            {
                var group = item as GroupResult;
                cell.TextLabel.Font = UIFont.BoldSystemFontOfSize(14);
                cell.TextLabel.Text = group.Key.ToString();
                cell.TextLabel.TextAlignment = UITextAlignment.Center;
                cell.BackgroundColor = UIColor.Gray;
            }
            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return (nint)dataSource.DisplayItems.Count;
        }
        #endregion
    }
    #endregion
}