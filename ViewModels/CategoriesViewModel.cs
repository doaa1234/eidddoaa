using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TheFinalProjectMUOD.Models;
using TheFinalProjectMUOD.Services;
using TheFinalProjectMUOD.Views;
using Xamarin.Forms;
using Categories = TheFinalProjectMUOD.Models.Categories;
using Command = MvvmHelpers.Commands.Command;

namespace TheFinalProjectMUOD.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public int Id { get; set; }
        public ObservableCollection<Categories> Categories { get; set; }

        public CategoriesViewModel()
        {
            Categories = new ObservableCollection<Categories>();
            GetCategories();
        }

        private async void GetCategories()
        {
            var categories = await new CategoriesService().GetCategoriesAsync();
            Categories.Clear();
            foreach (var category in categories)
            {
                Categories.Add(category);
            }
        }


        private Categories selectedCategory;
        public Categories SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(DisplayDrinks);

        private  void DisplayDrinks()
        {
            //display the drinks of the category
            if (selectedCategory != null)
            {
                int catyId = selectedCategory.Id;
                string catyName = selectedCategory.CategoryName;
                Console.WriteLine(catyId);
                var viewModel = new CategoryDrinksViewModel(catyId, catyName);
                var categoryDrinks = new CategoryDrinks { BindingContext = viewModel };
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(categoryDrinks, true);






            }
        }
    }
}
