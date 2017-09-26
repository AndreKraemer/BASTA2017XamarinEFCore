using ElVegetarianoFurio.Models;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Android.Content.Res;

namespace ElVegetarianoFurio
{
    public class DbInitializer
    {
        public static void Initialize(VegiContext db, AssetManager assetManager)
        {

            db.Database.EnsureCreated();

            if (db.Categories.Any() || db.Dishes.Any())
            {
                return;
            }

            string dishesJson;
            using (var streamReader = new StreamReader(assetManager.Open("dishes.json")))
            {
                dishesJson = streamReader.ReadToEnd();
            }

            string categoriesJson;
            using (var streamReader = new StreamReader(assetManager.Open("categories.json")))
            {
                categoriesJson = streamReader.ReadToEnd();
            }

            var dishes = JsonConvert.DeserializeObject<List<Dish>>(dishesJson);
            var categories = JsonConvert.DeserializeObject<List<Category>>(categoriesJson);

            foreach (var category in categories)
            {
                foreach (var dish in dishes.Where(x => x.CategoryId == category.Id))
                {
                    category.Dishes.Add(dish);
                }
                db.Categories.Add(category);
            }
            db.SaveChanges();
        }
    }
}
