using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using ElVegetarianoFurio.Models;

namespace ElVegetarianoFurio
{
    [Activity]
    public class DishesActivity : ListActivity
    {
        private readonly VegiContext _vegiContext = new VegiContext();
        private List<Dish> _dishes;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var categoryId = Intent.GetIntExtra("CategoryId",0);
            _dishes = _vegiContext.Dishes.Where(x => x.CategoryId == categoryId).ToList();
            ListAdapter = new DishesAdapter(this, _dishes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _vegiContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class DishesAdapter : BaseAdapter<Dish>
    {
        private readonly DishesActivity _context;
        private readonly List<Dish> _items;

        public DishesAdapter(DishesActivity context, List<Dish> items)
        {
            _context = context;
            _items = items;
        }

        public override long GetItemId(int position)
        {
            return _items[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this[position];
            var view = convertView ??
                       _context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Name;
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = item.Description;

            return view;
        }

        public override int Count => _items.Count;

        public override Dish this[int position] => _items[position];

    }
}