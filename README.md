# Transfmarket

Transfmarket to pełnostosowa (Full-Stack) aplikacja webowa typu CRUD, służąca do zarządzania bazą piłkarzy, ich wartościami rynkowymi oraz przynależnością klubową.

## 🛠 Technologie
* **Backend:** .NET 8.0 (C#, ASP.NET Core Web API)
* **Frontend:** Angular 21.2.6
* **Baza danych:** Entity Framework Core / sqlite

### Backend (.NET)
* **Architektura REST API:** Pełna obsługa metod HTTP (GET, POST, PUT, DELETE) dla zasobów `Players` oraz `Clubs`, `Nationalities`.

### Frontend (Angular)
* **Zarządzanie danymi:** Pełna obsługa bazy piłkarzy (CRUD) z opcją filtrowania. Aplikacja automatycznie sumuje wartość rynkową wybranych zawodników.
* **Dynamiczny interfejs:** Natywne animacje CSS gwarantują płynne ładowanie list. Interfejs na bieżąco przelicza ceny z EUR na PLN.
* **Animacje** ładownie wierszy do tabeli czy fade na poczatku

  
## Integracja z zewnętrznymi API
* **Kurs walut (NBP):** Aplikacja pobiera aktualny kurs Euro, automatycznie przeliczając wartość zawodników z EUR na PLN (zawiera zabezpieczenie przed awarią NBP).
* **Flagi państw:** System wykorzystuje zewnętrzne API do dynamicznego pobierania i renderowania flag poszczególnych reprezentacji w tabeli zawodników.
---

## Jak uruchomić projekt lokalnie

Aby uruchomić aplikację, sklonuj to repozytorium do jednego, głównego folderu na swoim dysku:
```bash
git clone <https://github.com/Pawiasty47/transmarket-angular-dotnet>
