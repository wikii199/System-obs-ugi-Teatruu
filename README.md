TEATR


WYMAGANIA : Korzystanie z aplikacji wymaga jedynie pakietu ASP.NET Core 6.


INSTALACJA:
1.Wypakuj pliki projektu do wybranego katalogu.
2.Otwórz terminal w katalogu Bazar.
3.Zainstaluj narzędzie dotnet df za pomocą polecenia: dotnet tool install --global dotnet-ef
4.Stwórz bazę danych: dotnet ef database update
5.Uruchom aplikację używając: dotnet run



DANE LOGOWANIA:
Strona znajduje się pod adresem: https://localhost:7294,
aby zalogować się jako kupujący należy wybrać z menu nawigacyjnego 
opcję Login Client i wprowadzić następujące dane logowania: Login: andrzej Hasło: andrzej,
aby zalogować się jako teatr należy wybrać z menu nawigacyjnego 
opcję Login Teatr i wprowadzić następujące dane logowania: Login: Bagatella Hasło: Bagatella



Opis projektu:
Rejestracja uzytkownika
klient ma dostęp do strony https://localhost:7294/Users/SignInForUser na której w formularzu zostawia dane logowania: adres email i hasło.
![image](https://user-images.githubusercontent.com/92157161/215565133-d592aeac-e90a-469c-b84c-9a603e7e4e67.png)
Rejestracja teatru
teatr ma dostęp do strony https://localhost:7294/Theaters/SignInForTheater na której w formularzu zostawia dane logowania: adres email i hasło.
![image](https://user-images.githubusercontent.com/92157161/215565297-00738483-b009-44ae-8466-bfacb18cea81.png)




Rejestracja
klient ma dostęp do strony https://localhost:7294/Users/Create na której w formularzu zostawia dane logowania: adres email i hasło.
![image](https://user-images.githubusercontent.com/92157161/215565447-84b6cbf8-4558-4fbe-b5e5-5459f166e914.png)
teatr ma dostęp do strony https://localhost:7294/Theaters/Create na której w formularzu zostawia dane logowania: adres email i hasło.
![image](https://user-images.githubusercontent.com/92157161/215565535-2c3f9ec5-2b30-44f4-9d55-f07a78310432.png)




Po wysłaniu formularza w przypadku ustawienia poprawnych danych klient jak i teatr musi przejsc do strony z formularzem logowania za pomocą przyciusku https://localhost:7294/Theaters/SignInForTheater,https://localhost:7294/Users/SignInForUser.




Dodawanie sztuki przez teatr
teatr posiadjący konto w serwisie może dodawać nowe oferty. Wystawienie przedmiotu znajduje się w zakładce 
all act list albo home pod adresem: https://localhost:7294/Shows/Create.
![image](https://user-images.githubusercontent.com/92157161/215566919-00791b84-c90e-4266-b624-6f5d62e190fe.png)




Sprawdanie ilosci kupiony/zarezerwownych biletow
Teatr moze sprawdzic ile biletow zostalo zakupionych/zabookowanych pod tym adresem: https://localhost:7294/Bookings/SoldTickets
![image](https://user-images.githubusercontent.com/92157161/215568330-5819777a-6a0b-4bbf-88ce-be58a7fdebb4.png)




Kupowanie biletów przez klienta
Klient musi udac sie do zakladki home (https://localhost:7294), następnie wybrac sztuke na którą chce sie udać, wpisac nazwę sztuki
![image](https://user-images.githubusercontent.com/92157161/215567866-cf44d46e-7255-43b5-a486-88d2a851560a.png)
oraz kliknąć przycisk Buy Tickets




Edytowanie danych w profilu klienta 
Klient w razie pomyłki może edytować swoje dane po zalogowaniu się i wybraniu zakladki Profile Of... https://localhost:7294/Users/Profile
![image](https://user-images.githubusercontent.com/92157161/215568640-990d6865-bf47-4ca9-8e6d-157f26ea0fd0.png)



i kliknięciu przycisku "Edit"
![image](https://user-images.githubusercontent.com/92157161/215568753-634d070f-5553-4405-af4d-9a31ad9847a9.png)





a następnie zapisaniu przyciskiem "Save"



