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
    public class DrinkDetailsService
    {
        FirebaseClient client;

        public DrinkDetailsService()
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


        public async Task<ObservableCollection<Drink>> GetDrinkById(int DrinkId)
        {
            var DirnkById = new ObservableCollection<Drink>();
            var Drink = (await getDrinksAsync()).Where(d => d.Id == DrinkId).ToList();
            foreach (var drink in Drink)
            {
                DirnkById.Add(drink);
            }
            return DirnkById;
        }
    }
}
