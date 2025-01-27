# Instrukcja uruchomienia projektu

1. Przygotowanie bazy danych:
  - W głównym katalogu repozytorium znajduje się skrypt SQL o nazwie `db-setup.sql`.
  - Uruchom skrypt ręcznie, korzystając z odpowiedniego narzędzia do zarządzania bazą danych (np. SQL Server Management Studio, itp.).
  - Po wykonaniu skryptu zostanie utworzona baza danych zawierająca jedną tabelę `Messages`.

2. Instalacja frontendu:
  - Przejdź do katalogu aplikacji frontendowej:
    ```bash
    cd gp-chatbot-app
    ```
  - Zainstaluj zależności przy użyciu `npm`:
    ```bash
    npm install
    ```

3. Uruchomienie frontendu:
  - Aby uruchomić aplikację frontendową, wykonaj polecenie:
    ```bash
    ng serve
    ```
  - Aplikacja powinna być dostępna pod adresem:
    - [http://localhost:4200](http://localhost:4200)

4. Uruchomienie backendu:
  - Ustaw projekt startowy jako: `GiganciProgramowania.Chatbot.API`
  - Uruchom backend. Domyślnie będzie dostępny pod adresem:
    - [https://localhost:7173/](https://localhost:7173/)

5. Finalne kroki:
  - Po wykonaniu powyższych kroków zarówno frontend, jak i backend powinny działać prawidłowo. W tym momencie aplikacja jest gotowa do użytku.

6. Dodatkowe uwagi:
  - W przypadku problemów z uruchomieniem upewnij się, że posiadasz odpowiednie wersje narzędzi takich jak `Node.js`, `npm`, oraz frameworka `Angular`.
  - Sprawdź, czy wszystkie wymagane porty są dostępne i niezajęte przez inne usługi.
  - W razie potrzeby sprawdź szczegóły konfiguracji w plikach projektu.
  - Gdyby była potrzebna pomoc przy uruchomieniu jestem dostępny pod oleksandr.neroda@gmail.com lub +48 799-949-373
