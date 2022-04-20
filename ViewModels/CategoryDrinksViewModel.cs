using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TheFinalProjectMUOD.Models;
using TheFinalProjectMUOD.Services;
using TheFinalProjectMUOD.Views;
using Xamarin.Forms;
using Command = Xamarin.Forms.Command;

namespace TheFinalProjectMUOD.ViewModels
{
    public class CategoryDrinksViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public bool IsFavorate { get; set; }

        public ObservableCollection<Drink> Drinks { get; set; }

        // Note should Rename to selected Drink
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
        public string CategoryName { get; set; }
        public CategoryDrinksViewModel(int CatId, string CatyName)
        {

            CategoryName = CatyName;
            Drinks = new ObservableCollection<Drink>();
            GetDrinks(CatId);
        }


        private async void GetDrinks(int CatId)
        {

            var drinks = await new CategoryDrinksService().GetDrinksByCatygoryId(CatId);
            Drinks.Clear();
            foreach (var drink in drinks)
            {
                Drinks.Add(drink);
            }
        }

        public ICommand SelectionCommand => new Command(DisplayDrinkDetail);

        private  void DisplayDrinkDetail()
        {
            //display the drink detail
            if (selectedDrink != null)
            {

                int DrinkId = selectedDrink.Id;
                string DrinkName = selectedDrink.Name;
                string DrinkImage = selectedDrink.Image;
                var viewModel = new DrinkDetailsViewModel(DrinkId, DrinkName, DrinkImage, selectedDrink);
                var DrinkDetails = new DrinkDetails { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                 navigation.PushAsync(DrinkDetails, true);

               // await Shell.Current.GoToAsync("//DrinkDetails");
            }
        }

    }
}
