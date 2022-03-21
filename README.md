## MVVM ##
### 3.Commanding ###

Her er tilføjet *Commanding Properties*, som der bindes til i View'et. 
Her er dels anvendt explicit method i første eksempel, mens resten er lavet med anonymous methods.
Der er dog et problem med ShowAgeCommand, som skal åbne en 
*DisplayAlert* i View'et - Her er lavet en "hård" afhængighed ved at benytte
`Application.Current.MainPage.DisplayAlert()`.

Det er dog ikke nogen god løsning! Så er det godt at vi har *Messages*!