## MVVM ##
### 3.Commanding ###

Her er tilf�jet Commanding Properties, som der bindes til
i View'et. Bem�rk at DeleteCommand er lavet med en anonymous 
Der er dog et problem med ShowAgeCommand, som skal �bne en 
DisplayAlert i View'et - Her er lavet en "h�rd" afh�ngighed ved at benytte
`Application.Current.MainPage.DisplayAlert()`.

Her har vi brug for **Messaging**.