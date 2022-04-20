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
    public partial class SignUP : ContentPage
    {
        public SignUP()
        {
            InitializeComponent();
            // BindingContext = new SignupViewModels();
            BindingContext = new SignUpViewModel();
        }
        private void ButtonSave_Clicked(object sender, EventArgs e)
        {
            string name = TxtName.Text;
            string email = TxtEmail.Text;
            string password = TxtPassword.Text;
            if (string.IsNullOrEmpty(name))
            {
                DisplayAlert("Warning", "pleas Enter your Name", "Cancel");
                Clear();
            }
            if (string.IsNullOrEmpty(email))
            {
                DisplayAlert("Warning", "pleas Enter your email", "Cancel");
            }
            if (string.IsNullOrEmpty(password))
            {
                DisplayAlert("Warning", "pleas Enter your password", "Cancel");
            }
            else
            {
                DisplayAlert("Hey", email + " ,Welcome in MUOD ", "Ok");
            }
        }
        public void Clear()
        {
            TxtName.Text = string.Empty;
            TxtEmail.Text = string.Empty;
        }
    }
}