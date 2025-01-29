# H2-OOP-OPG

## Projektoversigt

Dette projekt er en konsolapplikation til administration af sommerhusudlejning. Applikationen giver mulighed for at håndtere ejere, sommerhuse, udlejninger, områder, sæsonkategorier og inspektører.

### Funktioner

- **Login og Brugeradministration**: Administratorer kan logge ind og oprette nye brugere.
- **Ejeradministration**: Opret, rediger, slet og vis ejere af sommerhuse.
- **Sommerhusadministration**: Opret, rediger, slet og vis sommerhuse.
- **Udlejningsadministration**: Opret, rediger, slet og vis udlejninger.
- **Områdeadministration**: Opret, rediger, slet og vis områder.
- **Sæsonkategoriadministration**: Opret, rediger, slet og vis sæsonkategorier.
- **Inspektøradministration**: Opret, rediger, slet og vis inspektører.

### Teknologier

- **.NET 9.0**: Applikationen er bygget med .NET 9.0.
- **MySQL**: Database til lagring af data.
- **MySqlConnector**: Bruges til at forbinde og interagere med MySQL-databasen.
- **Microsoft.Extensions.Configuration.Json**: Bruges til at indlæse konfigurationsindstillinger fra en JSON-fil.

### Mappestruktur

- **Enums**: Indeholder enum-typer brugt i applikationen.
- **Models**: Indeholder modelklasser, der repræsenterer dataobjekter.
- **Data**: Indeholder databaseforbindelsesklasser.
- **Menus**: Indeholder klasser til håndtering af menuer og brugerinteraktion.
- **Parsing**: Indeholder klasser til parsing af data mellem SQL og applikationsmodeller.
- **Root**: Indeholder hovedprogrammet og administrative funktioner.

### Konfiguration

Applikationen kræver en `appsettings.json`-fil med databaseforbindelsesstrengen. Se afsnittet "App Setting" for detaljer.

### App Setting

Filnavn: `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=yourServerAddress;Database=yourDataBase;User=yourUser;Password=yourPassword;"
  }
}
```

### ⚙️ Installation og Brug

#### Forudsætninger

- .NET SDK (6.0 eller nyere) skal være installeret.
- En terminal eller kommandoprompt.

#### Sådan Kører Du Programmet

1. Klon repository:
   ```sh
   git clone https://github.com/Magnus1231212/H2-OOP-OPG
   cd H2-OOP-OPG
   dotnet build
   dotnet run
   ```
