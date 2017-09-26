using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Views;
using ElVegetarianoFurio.Models;

namespace ElVegetarianoFurio
{
    [Activity(Label = "ElVegetarianoFurio", MainLauncher = true)]
    public class MainActivity : ListActivity
    {
        private readonly VegiContext _vegiContext = new VegiContext();
        private List<Category> _categories;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            DbInitializer.Initialize(_vegiContext, Assets);
            _categories = _vegiContext.Categories.ToList();
            ListAdapter = new CategoriesAdapter(this, _categories);

        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var category = _categories[position];
            var intent = new Intent(this, typeof(DishesActivity));
            intent.PutExtra("CategoryId", category.Id);
            StartActivity(intent);
        }
    }

    public class CategoriesAdapter : BaseAdapter<Category>
    {
        private readonly MainActivity _context;
        private readonly List<Category> _items;

        public CategoriesAdapter(MainActivity context, List<Category> items)
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

        public override Category this[int position] => _items[position];

    }
}

