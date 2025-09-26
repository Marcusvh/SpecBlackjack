# SpecBlackjack

## Funktionaliteter
- Oprettelse af spillere, via bruger input af navn på spiller(ne).
- Oprettelse af deck med 4 af hver spillekort uden kulør eg. 4 2'er, 4 damer.
- Automatisk blanding af kort.
- hver rundte får spilleren et kort.
- Spilleren kan så vælge mellem "hit" eller "stand"
- Hvis spilleren vælger "hit" bliver spilleren givet et nyt kort.
- For hvert nyt kort, bliver der udregnet point for hele spillerens hånd.
- Der bliver checked for om spilleren (og dealeren) får bust.
- Dealer trækker kort indtil hånden er ≥ 17
- Dealer vælger automatisk stand ved 17 eller højere
- Automatisk håndtering af dealerens beslutninger
- Hvis spilleren får et es, så kan de beslutte om esset skal give 1 eller 11 point. med mindre at 11 vil give dem bust, vil esset automatisk vil give 1.
- Der understøttes multiplayer.
- Når alle spillere enten er busted eller valgt stand. så går det videre til dealeren automatisk.
- Når alle inklusiv dealer er færdig. kommer der en oversigt over resultaterne og hvem der er busted.

## Notes
- Der har prøvet at være en SOLID pricipperne tilgang.

## Inskrutioner til at køre programmet.
- Program.cs er filen skal skal køres
- Går til mappen hvor Program.cs ligger og kør den.
- Det kan gøres ved `dotnet run programs.cs`
