## MVVM ##
### 3.Commanding ###

Her er tilf�jet *Commanding Properties*, som der bindes til
i View'et. Bem�rk at `DeleteCommand` er lavet med en anonymous metode, hvor imod alle de andre er lavet med en normal metode.
Der er dog et problem med ShowAgeCommand, som skal �bne en 
*DisplayAlert* i View'et - Her er lavet en "h�rd" afh�ngighed ved at benytte
`Application.Current.MainPage.DisplayAlert()`.

Det er dog ikke nogen god l�sning! S� er det godt at vi har *Messages*!