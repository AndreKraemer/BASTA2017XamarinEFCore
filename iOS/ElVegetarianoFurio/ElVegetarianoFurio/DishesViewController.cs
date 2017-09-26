using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using ElVegetarianoFurio.Models;
using UIKit;

namespace ElVegetarianoFurio
{
    public partial class DishesViewController : UITableViewController
    {
        private VegiContext _db;
        private List<Dish> _dishes;
        public Category Category { get; set; }
        public DishesViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            _db = new VegiContext();
            _dishes = _db.Dishes.Where(x => x.CategoryId == Category.Id).ToList();
            TableView.Source = new DishesDataSource(_dishes);
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

    internal class DishesDataSource : UITableViewSource
    {
        private readonly List<Dish> _items;

        public DishesDataSource(List<Dish> items)
        {
            _items = items;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(new NSString("DishesCell"));
            var item = _items[indexPath.Row];
            cell.TextLabel.Text = item.Name;
            cell.DetailTextLabel.Text = item.Description;
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _items.Count;
        }
    }
}