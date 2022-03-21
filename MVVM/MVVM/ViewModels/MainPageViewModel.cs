// Nu er der lavet en ViewModelBase klasse, der lader Change Property Notification nedarve til alle ViewModels

using MVVM.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<Person> Persons { get; }


        #region CONSTRUCTOR
        public MainPageViewModel()
        {
            Persons = new ObservableCollection<Person>
                {
                    new Person { Name = "Anna", Age = 27 },
                    new Person { Name = "Christian", Age = 32 },
                    new Person { Name = "Helle", Age = 54 }
                };
        }
        #endregion

        #region PROPERTY CHANGE NOTIFICATION
        Person _personSelectedItem;
        public Person PersonSelectedItem
        {
            get => _personSelectedItem;
            set
            {
                if (SetProperty(ref _personSelectedItem, value))
                {
                    Name = value.Name;
                    Age = value.Age;
                }
            }
        }

        string _name;
        public string Name
        {
            get => _name;
            set { SetProperty(ref _name, value); }
        }

        int _age;
        public int Age { get => _age; set { SetProperty(ref _age, value); }}
        #endregion
    }
}
