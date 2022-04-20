using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProjectMUOD.Models;

namespace TheFinalProjectMUOD.Services
{
    public class CategoriesService
    {
        FirebaseClient client;

        public CategoriesService()
        {
            client = new FirebaseClient("https://last-a8571-default-rtdb.firebaseio.com/");

        }
        /*
        public ObservableCollection<Categories> getCategories()
        {
            var CategoriesData = client
                .Child("Categories")
                .AsObservable<Categories>()
                .AsObservableCollection();

            return CategoriesData;
        }*/
        public async Task<List<Categories>> GetCategoriesAsync()
        {

            var Categories = (await client.Child("Categories").OnceAsync<Categories>()).Select(C => new Categories
            {
                CategoryName = C.Object.CategoryName,
                Id = C.Object.Id,
                Image = C.Object.Image,
            }).ToList();

            return Categories;
        }
    }
}
