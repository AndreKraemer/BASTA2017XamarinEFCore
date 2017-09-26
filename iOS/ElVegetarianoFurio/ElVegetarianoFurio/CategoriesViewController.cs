using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using ElVegetarianoFurio.Models;
using UIKit;

namespace ElVegetarianoFurio
{
    public partial class CategoriesViewController : UITableViewController
    {
        private VegiContext _db;



        public CategoriesViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            _db = new VegiContext();
            TableView.Source = new CategoriesDataSource(_db.Categories.ToList());
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.DestinationViewController is DishesViewController dishesViewController)
            {
                var dataSource = TableView.Source as CategoriesDataSource;
                var rowPath = TableView.IndexPathForSelectedRow;
                var item = dataSource?[rowPath.Row];
                dishesViewController.Category = item;
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    internal class CategoriesDataSource : UITableViewSource
    {
        private readonly List<Category> _items;

        public CategoriesDataSource(List<Category> items)
        {
            _items = items;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(new NSString("CategoriesCell"));
            var item = _items[indexPath.Row];
            cell.TextLabel.Text = item.Name;
            cell.DetailTextLabel.Text = item.Description;
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _items.Count;
        }

        public Category this[int id] => _items[id];
    }

}