# CardGameWar

Dit project is een voorbeelduitwerking voor studenten en docenten van de Academie ICT. Middels dit project wordt getoond hoe een software ontwerp en realisatie eruit zouden *kunnen* zien. Voor zowel ontwerp als realisatie geldt dat er meerdere oplossingen mogelijk zijn. In dit project wordt aangegeven hoe de docenten van de academie *verwachten* dat je het moet doen en hoe het werk van een student dus beoordeeld wordt. Zie het als een afspraak zoals bij een bedrijf: dit is zoals we het nu doen, er zijn echter ook andere manieren maar die laten we even buiten beschouwing om diverse redenen.

Deze afspraken gelden voor de development onderwijs eenheden van de Academie ICT in het eerste en tweede leerjaar.

|Code|Omschrijving|
|:-|:-|
|A1D1|Programming Concepts|
|B1C2|Introduction to development|
|A2D1|Web application development|
|B2C2|Web applications|
|A2D2|Mobile application development|
|B2C4|Mobile|


> Leesaanwijzing: 
> Alle gewone tekst geeft aan hoe het software ontwerp eruit ziet. Alle tekst in dit soort blokken geeft een extra toelichting betreffende de manier waarop beoordeeld wordt.


## Speluitleg
Oorlog is een kaartspel dat meestal door twee spelers wordt gespeeld en het doel is om alle kaarten te verzamelen. Hier zijn de regels voor het kaartspel oorlog:

- Het spel wordt gespeeld met een standaard deck van 52 kaarten zonder jokers. De kaarten worden geschud en verdeeld over de twee spelers.
- De spelers draaien elk de bovenste kaart van hun stapel om. De speler met de hoogste kaart wint de ronde en verzamelt de twee kaarten. De kaartwaarden worden als volgt gerangschikt: Aas (hoogste kaart), Koning, Vrouw, Boer, 10, 9, 8, 7, 6, 5, 4, 3, 2.
- Als beide spelers kaarten hebben van gelijke waarde, dan begint er een "oorlog". Elke speler legt dan drie kaarten met de rug naar boven op de tafel en draait de vierde kaart om. De speler met de hoogste kaart wint de oorlog en verzamelt alle kaarten van die ronde. Als de kaarten weer gelijk zijn, dan wordt dit proces herhaald.
- Het spel gaat door totdat één speler alle kaarten heeft verzameld. Die speler wint het spel.

Oorlog is een zeer eenvoudig spel zonder veel strategie of tactiek, maar het is leuk om te spelen voor kinderen en beginners die net beginnen met het spelen van kaartspellen.

## Requirements

> Requirements worden opgehaald bij de opdrachtgever, of zelf samengesteld op basis van informatie die beschikbaar is (onderzoek naar andere systemen, opdrachtomschrijving, etc). In dit geval de omschrijving van het spel zoals hierboven vermeld.
>
> Het opstellen van requirements is reeds in een eerdere onderwijs eenheid behandeld en is dus een herhaling. Er wordt niet opnieuw aandacht besteed aan de theorie betreffende het maken van requirements.
> 
> Requirements:
> - zijn opgesplitst in randvoorwaarden, functionele- en niet funcionele requirements
> - zijn uniek identificeerbaar
> - zijn grammaticaal correct
> - beginnen met een actor en hebbenminimaal één werkwoord
> - zijn atomair
> - bevatten geen ontwerpaspecten
> - zijn meetbaar
> - zijn onderling consistent
> - zijn geprioriteerd
> - zijn traceerbaar
> 
> De requirements die door de student worden opgesteld dienen effectief te zijn voor de vervolgstappen van het ontwerp en dus ondersteunend te zijn aan het proces. De  docent zal nooit alle requirements op de letter controleren en goedkeuren, maar zal wel kijken of er consistentie is en de juiste requirements leiden tot de juiste usecases (bijvoorbeeld).

### Randvoorwaarden

- Gegevens worden opgeslagen in Microsoft SQL server
- De applicatie wordt geprogrammeerd in dotnet core met winforms
- Geldende wetgeving wordt nageleefd (eigenlijk overbodig te vermelden)

### Functionele requirements

- Requirements geïdentificeerd door nummering met afkorting betekenend: **P**layer, **G**ame, **T**urn, **O**verall
- Prioritisering middels MoSCoW. Zie ook:[MoSCoW](https://nl.wikipedia.org/wiki/MoSCoW-methode). 
- Opdrachtgever is eigenaar van alle requirements.
- Requirements vloeien allen voort uit de bovenstaande speluitleg en doelstelling van het project.

> In dit voorbeeld wordt MoSCoW gebruikt als methode om te prioriteren. Deze methode wordt gebruikt om te bepalen wat een stakeholder belangrijk vindt. Verschillende stakeholders kunnen verschillende zaken belangrijk vinden dus de student wordt uitgenodigd een andere manier van prioriteren te kiezen.

| Identificatie | Beschrijving | MoSCoW |
|:- |:- |:-|
|P1|De speler voert een unieke naam in|**S**hould have|
|P2|De speler slaat zijn unieke naam op|**S**hould have|
|G1|De speler beëindigt het spel|**C**ould have|
|G2|De speler kiest een tegenspeler|**M**ust have|
|G3|De speler start een nieuw spel|**M**ust have|
|G4|Het spel heeft een standaard deck van 52 kaarten zonder jokers|**M**ust have|
|G5|De kaarten in het deck hebben een oplopende waarde van 2, 3, 4, 5, 6, 7, 8, 9, 10, B, V, H, A.|**M**ust have|
|G6|De kaarten worden evenredig random verdeeld|**M**ust have|
|G8|Het spel bepaalt random de startspeler|**S**hould have|
|G9|Het spel eindigt zodra één speler geen kaarten meer heeft|**M**ust have|
|G10|Het spel roept de winnaar uit|**M**ust have|
|G11|Het spel werkt de persoonlijke score van de speler bij|**S**hould have|
|T1|De speler speelt de eerste kaart van zijn stapel op tafel|**M**ust have|
|T2|De speler met de hoogste kaart wint alle kaarten op tafel|**M**ust have|
|T3|De gespeelde kaart is van gelijke waarde waardoor oorlog wordt gevoerd|**M**ust have|
|T3.1|De speler speelt vier kaarten van zijn stapel bij het voeren van oorlog|**M**ust have|
|T3.2|De waarde van de vierde kaart bepaalt wie de winnaar is|**M**ust have|
|T4|De speler legt alle gewonnen kaarten onderaan zijn stapel speelkaarten|**M**ust have|
|T5|Een speler kan vals spelen|**C**ould have|
|T5.1|De valsspeler speelt in zijn beurt indien beschikbaar een kaart uit zijn stapel die hoger is dan de door de tegenstander gespeelde kaart|**C**ould have|
|O1|De speler bekijkt de score van alle spelers van hoge score naar lage score|**C**ould have|
|O2|Het spel kan automatisch gespeeld worden zonder gebruikers interactie (kaarten worden automatisch gelegd)|**C**ould have|
|O3|De speler slaat het spel tussentijds op|**C**ould have|
|O4|De speler laadt een eerder opgeslagen spel|**C**ould have|

### Niet functionele requirements
> Niet functionele requirements gaan over kwaliteitskenmerken zoals omschreven in [ISO25010](https://nl.wikipedia.org/wiki/ISO_25010). Alle requirements die hier genoemd worden dienen dus te passen bij de genoemde kwaliteitskenmerken.
> Als voorbeeld de requirement "Een gebruiker moet inloggen": dit is een niet functionele requirement en tevens een ontwerpaspect. De requirements zou bijvoorbeeld moeten gaan over tracability: "Het systeem moet loggen welke gebruiker de actie heeft uitgevoerd". Dit zorgt ervoor dat in het ontwerp waarschijnlijk ergens de keuze wordt gemaakt om een login te maken.

- De code is herbruikbaar voor een toekomstige web applicatie (reusability)

## Ontwerp
Ontwerpen zijn gemaakt met UMLet en opgeslagen in de map "Design".
### Conceptueel class diagram
![Conceptueel class diagram](ClassDiagramConceptueel.jpg)

### Implementatie class diagram
![Implementatie class diagram](ClassDiagram.jpg)

### Usecase diagram
![Usacase diagram](UsecaseDiagram.jpg)

### Usecase desciptions
| Usecase | UC1: Register ||
|:------------- |:-------------|:-|
| **Beschrijving**  | Speler registreert een unieke naam|
| **Actor** |Speler|
| **Trigger(s)** |De speler klikt op de button "Create new player"|
| **Pre-Conditions** | - Er is geen lopend spel|
| **Post-Conditions** | - Spleler is opgeslagen met een unieke naam||
| **Stappen** |**Actor speler**|**Systeem**|
| |1. Speler klikt op de button "Create new player"||
| ||2. Systeem toont de nieuwe speler dialog 
| |3. Speler vult een unieke naam in||
| |4. Speler klikt op ok||
| ||5. Systeem controleert of unieke naam al bestaat
| ||6. Systeem slaat de gegevens op
| ||7. Systeem geeft resultaat succes melding
| |8. Speler klikt op cancel||
| ||9. Systeem geeft foutmelding
| **Main success scenario**|1, 2, 3, 4, 5, 6, 7|
| **Alternatieve scenario's**|1, 8 <br> 1, 2, 3, 4, 5, 9|

| Usecase | UC2: Start game ||
|:------------- |:-------------|:-|
| **Beschrijving**  |Speler start het spel|
| **Actor** |Speler|
| **Trigger(s)** |De speler wilt een spel starten|
| **Pre-Conditions** |- Er is geen lopend spel <br> - Er zijn minimaal twee spelers aangemaakt|
| **Post-Conditions** |||
| **Stappen** |**Actor**|**Systeem**|
| |1. Speler kiest twee spelers ||
| |2. Speler klikt op "Create game" om het spel aan te maken ||
| ||3. Het systeem maakt het spel aan
| |4. Speler klikt op "start game" om het spel te starten ||
| ||5. Het systeem schudt het deck
| ||6. Het systeem deelt de kaarten
| **Main success scenario**| 1, 2, 3, 4, 5, 6|
| **Alternatieve scenario's**||

### Sequence diagrams
![Sequence diagram](SequenceDiagrams.jpg)


### Wireframes
// todo

## Verdieping
Verdiepingsopdrachten voor studenten.
Maak een fork van deze repository en kies één van de onderstaande opdrachten. Idealiter 
- Implementeer requirement T5 en T5.1, de valsspeler (oefenen met afgeleide classes en polymorfisme)
- Implementeer requirement O3 en O4, savegame (oefenen met database en DAL)
