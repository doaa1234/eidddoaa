using System;
using TheFinalProjectMUOD.Models;
using TheFinalProjectMUOD.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheFinalProjectMUOD
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

             MainPage = new NavigationPage(new SignUP());
         
           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
