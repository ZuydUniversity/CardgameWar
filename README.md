# CardGameWar

## 📖 Projectbeschrijving

Dit project is een voorbeelduitwerking voor studenten en docenten van de Academie ICT. Het demonstreert hoe een softwareontwerp en -realisatie eruit kunnen zien. Voor zowel ontwerp als realisatie bestaan er meerdere oplossingen. Dit project toont hoe de docenten van de academie verwachten dat je het moet aanpakken en hoe studentenwerk wordt beoordeeld.

Zie het als een afspraak zoals bij een bedrijf: dit is de manier waarop we het nu doen. Er zijn ook andere benaderingen mogelijk, maar die laten we buiten beschouwing om de focus te behouden.

> **💡 Leesaanwijzing:** 
> Alle gewone tekst beschrijft het softwareontwerp. Tekst in deze blokken geeft extra toelichting over de beoordelingscriteria.

## 📑 Inhoudsopgave

- [Speluitleg](#-speluitleg)
- [Requirements](#-requirements)
  - [Randvoorwaarden](#-randvoorwaarden)
  - [Functionele Requirements](#️-functionele-requirements)
  - [Niet-functionele Requirements](#-niet-functionele-requirements)
- [Ontwerp](#-ontwerp)
  - [Conceptueel Klassendiagram](#️-conceptueel-klassendiagram)
  - [Implementatie Klassendiagram](#-implementatie-klassendiagram)
  - [Use Case Diagram](#-use-case-diagram)
  - [Use Case Beschrijvingen](#-use-case-beschrijvingen)
  - [Sequentiediagrammen](#-sequentiediagrammen)
- [Verdiepingsopdrachten](#-verdiepingsopdrachten)


## 🎮 Speluitleg

**War (Oorlog)** is een klassiek kaartspel voor twee spelers waarbij het doel is om alle kaarten te verzamelen.

### Spelregels

1. **Setup**: Het spel wordt gespeeld met een standaarddeck van 52 kaarten (zonder jokers). De kaarten worden geschud en gelijk verdeeld over beide spelers.

2. **Speelronde**: 
   - Beide spelers draaien gelijktijdig de bovenste kaart van hun stapel om
   - De speler met de hoogste kaart wint beide kaarten
   - **Kaartwaarden** (hoogste naar laagste): Aas, Koning, Vrouw, Boer, 10, 9, 8, 7, 6, 5, 4, 3, 2

3. **Oorlog**:
   - Bij gelijke kaartwaarden ontstaat "oorlog"
   - Elke speler legt drie kaarten gedekt neer en draait de vierde kaart om
   - De hoogste vierde kaart wint alle kaarten van die ronde
   - Bij opnieuw gelijke waarden wordt dit proces herhaald

4. **Winnen**: Het spel eindigt wanneer één speler alle kaarten heeft verzameld

### Kenmerken
- Eenvoudig spel zonder strategie of tactiek
- Geschikt voor beginners en kinderen
- Volledig gebaseerd op geluk

## 📋 Requirements

Requirements zijn opgesteld op basis van de speluitleg en projectdoelstellingen. Ze vormen de basis voor het ontwerp en de implementatie.

> **🎯 Beoordelingscriteria voor requirements:**
> - Opgesplitst in randvoorwaarden, functionele en niet-functionele requirements
> - Uniek identificeerbaar en grammaticaal correct
> - Beginnen met een actor en bevatten minimaal één werkwoord
> - Atomair (niet verder op te splitsen)
> - Geen ontwerpaspecten, wel meetbaar
> - Onderling consistent en geprioriteerd
> 
> Requirements moeten effectief zijn voor vervolgstappen in het ontwerpproces. Consistentie en bruikbaarheid voor use cases zijn belangrijker dan perfecte formulering.### 

### 🔧 Randvoorwaarden

- **Database**: Gegevens worden opgeslagen in Microsoft SQL Server
- **Technologie**: De applicatie wordt ontwikkeld in .NET Core met WinForms
- **Compliance**: Geldende wetgeving wordt nageleefd

### ⚙️ Functionele Requirements

**Identificatie en prioritering:**
- **Nummering**: **P**layer, **G**ame, **T**urn, **O**verall
- **Prioritering**: [MoSCoW-methode](https://nl.wikipedia.org/wiki/MoSCoW-methode)
- **Eigenaarschap**: Opdrachtgever is eigenaar van alle requirements
- **Bron**: Gebaseerd op speluitleg en projectdoelstellingen

> **📊 MoSCoW Prioritering:**
> Deze methode bepaalt wat stakeholders belangrijk vinden. Verschillende stakeholders kunnen verschillende prioriteiten hebben. Studenten kunnen alternatieve prioriteringsmethoden kiezen.

| Identificatie | Beschrijving | Prioritering |
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

### 🔧 Niet-functionele Requirements

- **Herbruikbaarheid**: De code is herbruikbaar voor een toekomstige webapplicatie

> **📚 Kwaliteitskenmerken volgens [ISO 25010](https://nl.wikipedia.org/wiki/ISO_25010):**
> Niet-functionele requirements beschrijven kwaliteitsaspecten van het systeem. Ze moeten passen bij gestandaardiseerde kwaliteitskenmerken.
> 
> **Voorbeeld van goede formulering:**
> - ❌ "Een gebruiker moet inloggen" (ontwerpaspect)
> - ✅ "Het systeem moet loggen welke gebruiker acties uitvoert" (kwaliteitseis voor traceerbaarheid)

## 🎨 Ontwerp

Alle diagrammen zijn gemaakt met UMLet en opgeslagen in de map `Design/`.

### 🏗️ Conceptueel Klassendiagram

Een conceptueel klassendiagram toont de abstracte structuur van het informatiesysteem op hoog niveau. Het legt de kernentiteiten en hun onderlinge relaties vast.

> **📐 UML Klassendiagram Richtlijnen:**
> - **Entiteiten**: Rechthoeken met enkelvoudige zelfstandige naamwoorden
> - **Associaties**: Lijnen tussen entiteiten (optioneel met betekenis-labels)
> - **Multipliciteit**: Specifieke getallen, `n` of `*` voor onbepaalde aantallen
> - **Interpretatie**: Geen "juist" diagram bestaat - verschillende interpretaties zijn mogelijk
> 
> **Voorbeeld:** Een speler heeft kaarten "on hand" (0..26), een deck bevat kaarten (0..52). De keuze dat een speler maximaal 1 spel tegelijk speelt is een ontwerpbeslissing.

![Conceptueel Klassendiagram](ClassDiagramConceptueel.jpg)

### 🔧 Implementatie Klassendiagram
![Implementatie Klassendiagram](ClassDiagram.jpg)

### 👤 Use Case Diagram
![Use Case Diagram](UsecaseDiagram.jpg)

### 📝 Use Case Beschrijvingen
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

### 🔄 Sequentiediagrammen
![Sequentiediagrammen](SequenceDiagrams.jpg)

### 🖼️ Wireframes
*Nog te implementeren*

## 🛠️ Technische Details

### Projectstructuur
```
📦 CardGameWar/
├── 📁 Code/
│   ├── 📄 CardgameWar.sln          # Visual Studio Solution
│   ├── 📁 War/                     # Core Game Logic
│   │   ├── 📄 Program.cs
│   │   ├── 📁 Model/               # Domain Models
│   │   ├── 📁 DataAccess/          # Data Access Layer
│   │   └── 📁 Exceptions/          # Custom Exceptions
│   └── 📁 WarUI/                   # WinForms User Interface
├── 📁 DatabaseScripts/             # SQL Database Scripts
├── 📁 Design/                      # UML Design Files
└── 📄 README.md                    # Dit bestand
```

### Technologiestack
- **Framework**: .NET Core
- **UI**: Windows Forms
- **Database**: Microsoft SQL Server
- **Modellering**: UMLet

### 🚀 Ontwikkelomgeving
- **IDE**: Visual Studio 2019/2022
- **Vereisten**: .NET Core SDK, SQL Server

## 🚀 Verdiepingsopdrachten

Voor studenten die hun kennis willen uitbreiden:

### 📥 Aan de slag
1. **Fork** deze repository
2. Kies één van onderstaande opdrachten
3. Implementeer de gekozen functionaliteit

### 🎯 Opdrachten

#### 🃏 **Valsspeler** (Object-Oriented Programming)
- **Requirements**: T5 en T5.1
- **Leerdoelen**: Afgeleide klassen en polymorfisme
- **Beschrijving**: Implementeer een speler die vals kan spelen door strategisch kaarten te kiezen

#### 💾 **Save Game** (Database & Data Access)
- **Requirements**: O3 en O4
- **Leerdoelen**: Database-interactie en Data Access Layer
- **Beschrijving**: Voeg functionaliteit toe om spellen op te slaan en later te hervatten

### 🏆 Beoordelingscriteria
- Code kwaliteit en architectuur
- Correcte implementatie van OOP-principes
- Werkende functionaliteit volgens requirements
- Documentatie van gemaakte keuzes
