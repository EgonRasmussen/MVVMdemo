## MVVM ##
### 3.Commanding ###

Her er tilføjet *Commanding Properties*, som der bindes til
i View'et. Bemærk at `DeleteCommand` er lavet med en anonymous metode, hvor imod alle de andre er lavet med en normal metode.
Der er dog et problem med ShowAgeCommand, som skal åbne en 
*DisplayAlert* i View'et - Her er lavet en "hård" afhængighed ved at benytte
`Application.Current.MainPage.DisplayAlert()`.

Det er dog ikke nogen god løsning! Så er det godt at vi har *Messages*!