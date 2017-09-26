using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElVegetarianoFurio.Models;
using Xamarin.Forms;

namespace ElVegetarianoFurio
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (var db = new VegiContext())
            {
                CategoriesListView.ItemsSource = db.Categories.ToList();
            }
                
        }

        private void CategoriesListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var dishesPage = new DishesPage(e.SelectedItem as Category);
            Navigation.PushAsync(dishesPage);
        }
    }
}
