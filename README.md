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
- Een speler kan worden aangemaakt
- Een speler kan worden verwijderd
- Een speler heeft een unieke naam
- De gegevens van de speler worden opgeslagen in de database voor toekomstig gebruik
- Een nieuw spel kan gestart worden
- Een lopend spel kan tussentijds beeindigd worden
- Bij het starten van het spel worden twee spelers gekozen
- Het spel wordt gespeeld met een kaarspel
- Het kaartspel bestaat uit een standaard deck van 52 kaarten zonder jokers
- De 2 is de laagste kaart, gevolgd door 3, 4, 5, 6, 7, 8, 9, 10, B, V, H, A. Kleur is niet relevant
- De kaarten worden random verdeeld tussen de twee spelers bij aanvang van het spel
- Een speler heeft een stapel kaarten om mee te spelen waar de volgorde niet van veranderd wordt tijdens het spel
- De startspeler wordt random bepaald
- Een speler heeft een eigen speelplek in het spel waar hij kaarten kan leggen
- Een speler speelt een kaart als het zijn beurt is op zijn speelplek
- De speler met de hoogste kaart wint alle kaarten op de speelplekken van alle spelers op tafel
- Bij winst worden alle gewonnen kaarten onderaan de stapel kaarten van de speler gelegd
- Bij gelijkspel wordt oorlog gevoerd om te bepalen welke speler wint
- Bij het voeren van oorlog speelt elke speler vier kaarten
- Bij het voeren van oorlog telt te waarde van de vierde kaart om te bepalen wie de winnaar is
- Het spel eindigt zodra één speler geen kaarten meer heeft
- De winnaar van het spel is de speler met alle kaarten
- Bij het einde van het spel wordt de winnaar uitgeroepen
- Bij elk spel wat een speler wint wordt zijn persoonlijke score opgehoogd
- Er is een ranking met alle spelers en hun score van hoge score naar lage score

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
