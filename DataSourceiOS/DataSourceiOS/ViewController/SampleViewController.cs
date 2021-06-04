using Foundation;
using Syncfusion.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace DataSourceiOS.ViewController
{
    #region SampleViewController
    class SampleViewController : UIViewController
    {
        #region Fields

        DataSource dataSource;
        UILabel header;
        UITableView tableView;
        #endregion

        #region Constructor
        public SampleViewController()
        {
            dataSource = new DataSource();
            dataSource.Source = new ContactsList();
            dataSource.SortDescriptors.Add(new SortDescriptor("ContactName"));
            dataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "ContactName",
                KeySelector = (object obj1) =>
                {
                    var item = (obj1 as Contacts);
                    return item.ContactName[0].ToString();
                }
            });

            header = new UILabel();
            header.Text = "Contacts List ";
            header.BackgroundColor = UIColor.Gray;
            header.TextAlignment = UITextAlignment.Center;
            header.MinimumFontSize = 12f;


            tableView = new UITableView();
            tableView.AllowsSelection = false;
            tableView.SeparatorColor = UIColor.Clear;
            tableView.RowHeight = 30;
            tableView.EstimatedRowHeight = 30;
            tableView.Source = new TableViewSource(dataSource);
            View.BackgroundColor = UIColor.White;
            this.View.AddSubview(header);
            this.View.AddSubview(tableView);
        }
        #endregion

        #region Override method
        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            header.Frame = new CoreGraphics.CGRect(0, 20, this.View.Frame.Width, 50);
            tableView.Frame = new CoreGraphics.CGRect(0, 72, this.View.Frame.Width, this.View.Frame.Height - 72);
        }
        #endregion
    }
    #endregion
}