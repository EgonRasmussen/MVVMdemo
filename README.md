## MVVM ##
### 3.Commanding ###

Her er tilføjet Commanding Properties, som der bindes til
i View'et. Bemærk at DeleteCommand er lavet med en anonymous 
Der er dog et problem med ShowAgeCommand, som skal åbne en 
DisplayAlert i View'et - Her er lavet en "hård" afhængighed ved at benytte
`Application.Current.MainPage.DisplayAlert()`.

Her har vi brug for **Messaging**.