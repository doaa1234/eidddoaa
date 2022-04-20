using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalProjectMUOD.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheFinalProjectMUOD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrinkDetails : ContentPage
    {
        public DrinkDetails()
        {
            InitializeComponent();
          //  BindingContext = new DrinkDetailsViewModel();
        }
    }
}