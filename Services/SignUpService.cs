using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TheFinalProjectMUOD.Models;

namespace TheFinalProjectMUOD.Services
{
    public class SignUpService
    {

        FirebaseClient person;
        public SignUpService()
        {
            person = new FirebaseClient("https://last-a8571-default-rtdb.firebaseio.com/");


        }
        public ObservableCollection<SignUp> getPerson()
        {
            var PersonData = person.Child("Users").AsObservable<SignUp>().AsObservableCollection();
            return PersonData;
        }
        public async Task Addperson(string name, string email, string password)
        {
            SignUp c = new SignUp() { Name = name, Email = email, Password = password };
            await person.Child("Users").PostAsync(c);
        }


    }
}
