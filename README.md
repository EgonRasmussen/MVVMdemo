# 4.Messaging

Den indbyggede MessagingCenter klasse benyttes i ShowAgeCommand (med Person som parameter) og i AnswerToLife (med string som parameter). Her ses de to Commands i constructoren:

```csharp
ShowAgeCommand = new Command(
    execute: () => MessagingCenter.Send(this, "AgeButtonClicked", PersonSelectedItem),
    canExecute: () => _personSelectedItem != null
    );

AnswerToLife = new Command<string>(
    execute: (string param) => MessagingCenter.Send(this, "AnswerToLifeClicked", param)
    );
```

&nbsp;

Der abonneres på begge Message med begge parameter-typer i constructoren for View'et, som vist her:

```csharp
MessagingCenter.Subscribe<MainPageViewModel, Person>(new MainPageViewModel(),
    "AgeButtonClicked", (sender, arg) =>
    {
        DisplayAlert("Age", $"{arg.Name} er {arg.Age} år!", "OK");
    });

MessagingCenter.Subscribe<MainPageViewModel, string>(new MainPageViewModel(),
    "AnswerToLifeClicked", (sender, arg) =>
    {
        DisplayAlert("Answer to Life", $"The answer is {arg}!", "OK");
    });
```