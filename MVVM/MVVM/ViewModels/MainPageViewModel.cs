// En simpel ViewModel, der benytter Change Property Notification, men ikke Commanding.
// Der laves en instans af VM i View'ets constructor.

using MVVM.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
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
        public Person PersonSelectedItem
        {
            set
            {
                Name = value.Name;
                Age = value.Age;
                OnPropertyChanged();
            }
        }

        string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        int _age;
        public int Age
        {
            get => _age;
            set
            {
                if (value != _age)
                {
                    _age = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion


        #region INPC
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

    }
}
