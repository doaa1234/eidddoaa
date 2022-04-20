using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TheFinalProjectMUOD.Models;
using TheFinalProjectMUOD.Services;

namespace TheFinalProjectMUOD.ViewModels
{
    public class DrinkDetailsViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Id { get; set; }
        public int ParentId { get; set; }
        public bool IsFavorate { get; set; }
        public int RatingValue { get; set; }

        public string DrinkName { get; set; }
        public string DrinkImage { get; set; }

        public ObservableCollection<Drink> DrinkById { get; set; }

        private int selectedStarValue;
        public int SelectedStarValue
        {
            get { return selectedStarValue; }
            set
            {
                selectedStarValue = value;
                OnPropertyChanged();
            }
        }

        private Drink selectedDrink;
        public Drink SelectedDrink
        {
            get { return selectedDrink; }
            set
            {
                selectedDrink = value;
                OnPropertyChanged();
            }
        }



        public DrinkDetailsViewModel(int drinkId, string drinkName, string drinkImage, Drink selectedDrink)
        {
            DrinkName = drinkName;
            DrinkImage = drinkImage;
            SelectedDrink = selectedDrink;
            DrinkById = new ObservableCollection<Drink>();


            GetDrink(drinkId);
        }
        private async void GetDrink(int id)
        {

            var drinks = await new DrinkDetailsService().GetDrinkById(id);
            DrinkById.Clear();
            foreach (var drink in drinks)
            {
                DrinkById.Add(drink);
            }
        }
    }
}
