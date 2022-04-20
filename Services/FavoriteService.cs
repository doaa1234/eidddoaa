using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProjectMUOD.Models;

namespace TheFinalProjectMUOD.Services
{
    public class FavoriteService
    {
        FirebaseClient client;

        public FavoriteService()
        {
            client = new FirebaseClient("https://last-a8571-default-rtdb.firebaseio.com/");

        }
        public async Task<List<Drink>> getDrinksAsync()
        {

            var AllDrinks = (await client.Child("Drinks").OnceAsync<Drink>()).Select(d => new Drink
            {
                Id = d.Object.Id,
                Name = d.Object.Name,
                Description = d.Object.Description,
                Image = d.Object.Image,
                ParentId = d.Object.ParentId,
                IsFavorate = d.Object.IsFavorate,
            }).ToList();

            return AllDrinks;
        }

        public async Task<ObservableCollection<Drink>> GetFavoriteDrinks()
        {
            var FavoriteDrinks = new ObservableCollection<Drink>();
            var Drinks = (await getDrinksAsync()).Where(a => a.IsFavorate == true).ToList();
            foreach (var drink in Drinks)
            {
                FavoriteDrinks.Add(drink);
            }
            return FavoriteDrinks;
        }
    }
}
