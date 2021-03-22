# 1.BasicViewModel

Viser MVVM organisering og databinding.

I **ViewModels** folderen oprettes en ViewModel klasse pr. Page. Constructoren indlæser data i properties, som View'et kan binde til. Der laves Change-notification til relevante properties.

I **Views** folderen placeres alle Pages. Code-behind indeholder kun en oprettelse af ViewModel objektet:

```csharp
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
        }
    }
}
```

