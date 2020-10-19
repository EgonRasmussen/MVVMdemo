// Nu kan det lade sig gøre at ViewModel kan sende en Message 
// til View'et og bede om at åbne en DisplayAlert. Dette sker både
// i ShowAgeCommand og AnswerToLifeCommand.
// I View'ets constructor laves et "abonnement" på Messages, både
// uden og med en parameter.

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


            MakeOlderCommand = new Command(
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

            ClearEntriesCommand = new Command(
               execute: () =>
               {
                   Name = string.Empty;
                   Age = 0;
               });

            AddCommand = new Command(
               execute: () => Persons.Add(new Person { Name = Name, Age = Age }),
               canExecute: () =>
               {
                   return Name?.Length > 0 && Age > 0;
               });

            ShowAgeCommand = new Command(
                execute: () => MessagingCenter.Send(this, "AgeButtonClicked", PersonSelectedItem),
                canExecute: () => _personSelectedItem != null
                );

            AnswerToLife = new Command<string>(
                execute: (string param) => MessagingCenter.Send(this, "AnswerToLifeClicked", param)
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
        public Command MakeOlderCommand { get; private set; }

        public Command AddCommand { get; private set; }

        public Command ClearEntriesCommand { get; private set; }

        public Command ShowAgeCommand { get; private set; }

        public Command AnswerToLife { get; private set; }


        // Property for local implementation (an alternative syntax).
        public Command _onDeleteCommand;
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
