using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using TheFinalProjectMUOD.Models;
using TheFinalProjectMUOD.Services;
using Xamarin.Forms;
using TheFinalProjectMUOD.Views;

namespace TheFinalProjectMUOD.ViewModels
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        //  public void OnPropertyChanged(SignupViewModels signUpPageViewModel, [CallerMemberName] string email = "") =>
        //  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(email));

        private string _errorMessge;
        public string ErrorMessage
        {
            get { return this._errorMessge; }
            set { this._errorMessge = value; }
        }
        private SignUpService Services;
        public Command AddUserCommand { get; }
        private ObservableCollection<SignUp> _users = new ObservableCollection<SignUp>();
        public ObservableCollection<SignUp> users
        {
            get { return _users; }
            set
            {
                _users = value;

                //  OnPropertyChanged();
            }
        }


        public SignUpViewModel()
        {
            Services = new SignUpService();
            users = Services.getPerson();
            AddUserCommand = new Command(async () =>
              await AddUserAsync(Name, Email, Password));
        }


        private async Task AddUserAsync(string name, string email, string password)
        {
            if (string.IsNullOrEmpty(name))
            {
                ErrorMessage = "Name is Empty";
            }
            else if (string.IsNullOrEmpty(email))
            {
                ErrorMessage = "email is Empty";
            }
            else if (string.IsNullOrEmpty(password))
            {
                ErrorMessage = "password is Empty";
            }
            else
            {
                await Services.Addperson(name, email, password);
                //  await Application.Current.MainPage.DisplayAlert("Hey", email + " ,Welcome in MUOD ", "Ok");
                await Application.Current.MainPage.Navigation.PushAsync(new Views.Tabbed1());

            }
        }

    }
}
