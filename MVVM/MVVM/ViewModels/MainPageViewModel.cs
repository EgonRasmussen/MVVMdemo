// Her er tilføjet Commanding Properties, som der bindes til
// i View'et. Bemærk at DeleteCommand er lavet med en anonymous 
// metode, hvor imod alle de andre er lavet med en normal metode.
// Der er dog et problem med ShowAgeCommand, som skal åbne en 
// DisplayAlert i View'et - men det kan ikke umiddelbart virke.
// Så er det godt at vi har Messages!

using MVVM.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MVVM.ViewModels
{
    public class MainPageViewModel : ViewModelBase
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

            ClearEntriesCommand = new Command(() => ExecuteClearEntriesCommand());  // 1. Command with explicit method

            MakeOlderCommand = new Command(                                         // 2. Command with inline methods
                execute: () =>
                {
                    Age++;
                    _personSelectedItem.Age = Age;
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return _personSelectedItem != null;
                });

            AddCommand = new Command(
               execute: () => Persons.Add(new Person { Name = Name, Age = Age }),
               canExecute: () =>
               {
                   return Name?.Length > 0 && Age > 0;
               });

            ShowAgeCommand = new Command(
                execute: () => Application.Current.MainPage.DisplayAlert("AgeButtonClicked", $"{PersonSelectedItem.Name} er {PersonSelectedItem.Age}", "OK"),
                canExecute: () => _personSelectedItem != null
                );
        }
        #endregion

        #region PROPERTY CHANGE NOTIFICATION
        Person _personSelectedItem;
        public Person PersonSelectedItem
        {
            get { return _personSelectedItem; }
            set
            {
                if (SetProperty(ref _personSelectedItem, value))
                {
                    Name = value.Name;
                    Age = value.Age;
                    RefreshCanExecutes();
                }
            }
        }

        string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); RefreshCanExecutes(); }
        }

        int _age;
        public int Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); RefreshCanExecutes(); }
        }
        #endregion

        #region COMMANDING
        // Properties for implementing commands in constructor.
        public Command ClearEntriesCommand { get; private set; }
        public Command MakeOlderCommand { get; private set; }
        public Command AddCommand { get; private set; }

       
        public Command ShowAgeCommand { get; private set; }

        void ExecuteClearEntriesCommand()
        {
            Name = string.Empty;
            Age = 0;
        }

        
        private Command _onDeleteCommand;                                            // 3. Command with local Property implementation
        public Command DeleteCommand
        {
            get
            {
                return _onDeleteCommand ?? (_onDeleteCommand = new Command(
                    execute: () =>
                    {
                        Persons.Remove(_personSelectedItem ?? null);
                    },
                    canExecute: () =>
                    {
                        return _personSelectedItem != null && Persons.Count > 1;
                    }
                    ));
            }
        }

        void RefreshCanExecutes()
        {
            DeleteCommand.ChangeCanExecute();
            MakeOlderCommand.ChangeCanExecute();
            AddCommand.ChangeCanExecute();
            ShowAgeCommand.ChangeCanExecute();
        }
        #endregion
    }
}
