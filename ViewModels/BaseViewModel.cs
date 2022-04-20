using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TheFinalProjectMUOD.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        
            public event PropertyChangedEventHandler PropertyChanged;

            public void OnPropertyChanged([CallerMemberName] string email = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(email));

       }
    
}
