using ElVegetarianoFurio.Models;

using Newtonsoft.Json;

using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace ElVegetarianoFurio
{
    public class DbInitializer
    {
        public static void Initialize(VegiContext db)
        {
            db.Database.EnsureCreated();
            if (db.Categories.Any() || db.Dishes.Any())
            {
                return;
            }

            var dishesJson = File.ReadAllText("Data/dishes.json");
            var categoriesJson = File.ReadAllText("Data/categories.json");

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
