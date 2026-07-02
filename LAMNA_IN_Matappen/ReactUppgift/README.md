# Matappen

## Vad applikationen gör

Matappen är en frontend Single Page Application byggd med React. Den visar en
startsida och en menysida med maträtter som hämtas från mitt API i
systemintegrationsprojektet, **Matapi**.

På menysidan visas:

- maträttens namn
- beskrivning
- kategori
- pris i SEK

## Koppling mot API

React-applikationen anropar följande endpoint:

```text
GET http://localhost:5037/api/Mat
```

Endpointen returnerar maträtter med fälten `id`, `namn`, `beskrivning`,
`kategori` och `pris`.

Om API:t inte är startat visar applikationen ett felmeddelande i stället för
att krascha.

## Hur man kör applikationen

### Starta API:t

Öppna terminalen i mappen där `Matapi.csproj` finns och kör:

```powershell
dotnet run
```

API:t ska vara tillgängligt på:

```text
http://localhost:5037
```

Du kan kontrollera API:t genom att öppna:

```text
http://localhost:5037/api/Mat
```

### Starta React-applikationen

Öppna en ny terminal i mappen för React-projektet och kör:

```powershell
npm.cmd install
npm.cmd run dev
```

Öppna sedan adressen som visas i terminalen, vanligtvis:

```text
http://localhost:5173
```

Klicka på **Mat** i navigeringen för att se information som hämtats från API:t.

## Struktur

```text
src/
  assets/
    homepage.jpg       Bild på startsidan
  components/
    Home.jsx           Startsidan
    Mat.jsx            API-anrop och visning av maträtter
    Navbar.jsx         Navigering mellan vyerna
  App.jsx              Applikationens routes
  index.css            Sidans design
  main.jsx             Startar React-applikationen
```

## AI-användning

Jag har använt AI som stöd för att rätta fel efter återkopplingen på den
tidigare inlämningen.

AI har hjälpt till med:

- att hitta att startsidan försökte ladda en bildfil som saknades
- att göra API-hämtningen stabilare med laddnings- och felmeddelande
- att avgränsa applikationen till mat, eftersom integrationen sker mot Matapi
- att strukturera denna README

Jag har anpassat materialet till mitt projekt genom att använda min egen
endpoint `http://localhost:5037/api/Mat` och de fält som finns i mitt API.
Utseendet är fortsatt enkelt med startsida, navigation och en tabell för
maträtter.

## Annat som används

Projektet använder React Router för navigering mellan startsidan och
menysidan utan att hela applikationen behöver laddas om. Detta används för att
applikationen ska fungera som en SPA.

