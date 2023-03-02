# CardGameOorlog

## Speluitleg
Oorlog is een kaartspel dat meestal door twee spelers wordt gespeeld en het doel is om alle kaarten te verzamelen. Hier zijn de regels voor het kaartspel oorlog:

- Het spel wordt gespeeld met een standaard deck van 52 kaarten zonder jokers. De kaarten worden geschud en verdeeld over de twee spelers.
- De spelers draaien elk de bovenste kaart van hun stapel om. De speler met de hoogste kaart wint de ronde en verzamelt de twee kaarten. De kaartwaarden worden als volgt gerangschikt: Aas (hoogste kaart), Koning, Vrouw, Boer, 10, 9, 8, 7, 6, 5, 4, 3, 2.
- Als beide spelers kaarten hebben van gelijke waarde, dan begint er een "oorlog". Elke speler legt dan drie kaarten met de rug naar boven op de tafel en draait de vierde kaart om. De speler met de hoogste kaart wint de oorlog en verzamelt alle kaarten van die ronde. Als de kaarten weer gelijk zijn, dan wordt dit proces herhaald.
- Het spel gaat door totdat één speler alle kaarten heeft verzameld. Die speler wint het spel.

Oorlog is een zeer eenvoudig spel zonder veel strategie of tactiek, maar het is leuk om te spelen voor kinderen en beginners die net beginnen met het spelen van kaartspellen.

## Requirements
### Functionele requirements
MoSCoW in afkorting toegevoegd
- (S) De speler registreert een unieke naam
- (S) De gegevens van de speler worden opgeslagen
- (M) Een speler start een nieuw spel
- (C) Een speler beindigt een lopend spel
- (M) De speler kiest een tegenspeler voor het spel
- (M) Het spel wordt gespeeld met een kaarspel
- (M) Het kaartspel bestaat uit een standaard deck van 52 kaarten zonder jokers
- (M) Voor het spel geldt dat 2 de laagste kaart is, gevolgd door 3, 4, 5, 6, 7, 8, 9, 10, B, V, H, A. Kleur is niet relevant
- (M) De kaarten worden random verdeeld tussen de twee spelers bij aanvang van het spel
- (M) Een speler heeft een stapel kaarten om mee te spelen waar de volgorde niet van veranderd wordt tijdens het spel
- (S) De startspeler wordt random bepaald
- (M) Een speler heeft een eigen speelplek in het spel waar hij kaarten kan leggen
- (M) Een speler speelt een kaart op zijn speelplek als het zijn beurt is
- (M) De speler met de hoogste kaart wint alle kaarten op de speelplekken van alle spelers op tafel
- (M) De speler legt alle gewonnen kaarten onderaan zijn stapel kaarten bij winst waarbij eerst die van de tegenspeler en dan de eigen kaarten worden gelegd
- (M) Bij gelijkspel wordt oorlog gevoerd om te bepalen welke speler wint
- (M) De speler speelt vier kaarten bij het voeren van oorlog
- (M) Bij het voeren van oorlog telt te waarde van de vierde kaart om te bepalen wie de winnaar is
- (M) Het spel eindigt zodra één speler geen kaarten meer heeft
- (M) De speler met alle kaarten in zijn bezit is de winnaar van het spel
- (M) Het spel roept de winnaar uit 
- (S) Het spel werkt de persoonlijke score van de speler bij
- (C) De speler bekijkt een ranking met alle spelers en hun score van hoge score naar lage score
- (C) Het spel kan automatisch gespeeld worden zonder gebruikers interactie (kaarten worden automatisch gelegd)
- (C) Een speler kan een valsspeler zijn
- (C) De valsspeler maakt bij het spelen van een kaart een kaart aan die hoger is dan de door de tegenstander gespeelde kaart en speelt deze


### Niet functionele requirements
- De applicatie is gebruikersvriendelijk
- Gegevens worden opgeslagen in een database
- Bij de opslag van gegevens wordt de AVG in acht genomen
- SQL server dient als database server
- De applicatie wordt geprogrammeerd in dotnet core met winforms
- Het moet mogelijk te zijn in de toekomst een web applicatie van het spel te maken, de code moet herbruikbaar zijn

## Ontwerp
### Class diagram

### Usecase diagram

### Sequence diagrams
