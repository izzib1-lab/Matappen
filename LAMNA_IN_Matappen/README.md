# Inlamning - Matappen

Denna mapp innehaller bada delarna som behovs for att visa integrationen:

- `Matapi` - API-projektet som returnerar matratter.
- `ReactUppgift` - React-applikationen som visar matratter fran API:t.

## Starta projektet

Oppna tva terminalfonster.

I det forsta terminalfonstret:

```powershell
cd Matapi
dotnet run
```

API:t startar pa:

```text
http://localhost:5037
```

I det andra terminalfonstret:

```powershell
cd ReactUppgift
npm.cmd install
npm.cmd run dev
```

Oppna sedan adressen som Vite visar, vanligtvis:

```text
http://localhost:5173
```

Klicka pa **Mat** for att visa informationen fran API:t.

## Viktigt

Mappar som `node_modules`, `bin`, `obj` och `dist` ar inte inkluderade i
inlamningen. De skapas lokalt nar projekten installeras eller kors.

Mer dokumentation om React-applikationen och AI-anvandning finns i
`ReactUppgift/README.md`.
