using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElVegetarianoFurio.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ElVegetarianoFurio
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DishesPage : ContentPage
	{
	    private readonly Category _category;

	    public DishesPage (Category category)
	    {
	        _category = category;
	        InitializeComponent ();
	    }

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        using (var db = new VegiContext())
	        {
	            DishesListView.ItemsSource = db.Dishes.Where(x => x.CategoryId== _category.Id).ToList();
	        }
        }
	}
}