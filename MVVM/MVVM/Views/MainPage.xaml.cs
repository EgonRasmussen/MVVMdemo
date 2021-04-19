using MVVM.Models;
using MVVM.ViewModels;
using Xamarin.Forms;

namespace MVVM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();

            MessagingCenter.Subscribe<MainPageViewModel, Person>(this, "AgeButtonClicked", (sender, arg) =>
            {
                DisplayAlert("Age", $"{arg.Name} er {arg.Age} år!", "OK");
            });

            MessagingCenter.Subscribe<MainPageViewModel, string>(this, "AnswerToLifeClicked", (sender, arg) =>
            {
                DisplayAlert("Answer to Life", $"The answer is {arg}!", "OK");
            });
        }
    }
}
