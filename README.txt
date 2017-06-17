Autor: Mateusz Rymuszka (C1)

Program jest modyfikacją poprzedniego projektu (funkcjonalności dotyczące ustawiania ograniczeń na krawędziach zostały wycofane). 
Użytkownik ma możliwość dodawania, przesuwania oraz usuwania wielokątów, a także możliwość przesuwania i usuwania poszczególnych wierzchołków.

Program jest dość prosty w obsłudze - klawiatura gra tutaj niewielką rolę (tak jak w moim projekcie numer 1):
- lewy przycisk myszy - służy do tworzenia nowych wierzchołków (puste miejsce) oraz przesuwania
obecnych (wierzchołek)
- środkowy przycisk myszy - służy do przesuwania całego wielokątu (wierzchołek)
- prawy przycisk myszy - uruchamia menu kontekstowe (po naciśnięciu na wierzchołek)

Dostępne opcje menu kontekstowego (wierzchołek):
- zamknięcie wielokąta
- usunięcie wierzchołka
- usunięcie wielokąta
- dodanie/usunięcie wielokąta z łączenia - aby połączyć wielokąty, należy najpierw wybrać jeden, a potem drugi. Dwukrotnie wybranie tego samego wielokątu nie spowoduje zmian (może być
użyte do cofania zmian).

Po prawej stronie znajduje się panel w dość przejrzystej formie, który umożliwia:
- wybór tła dla naszych wielokątów: brak, jednolity kolor, bitmapa
- wybór światła padającego na obiekty: brak (tzn. domyślny widok), liniowe oraz animowane, a także koloru źródła
- wybór elipsy świetlnej: ustawienie ogniska okręgu, promienia oraz wysokości od bitmapy (względem "zera") oraz jej zresetowanie
- wybór powierzchni wyznaczającą normalne dla tekstury: płaszczyzna, stożek, paraboloida i paraboloida hiperboliczna (ze względu na 
	czytelność i efektywność, współczynniki nachylenia tych płaszczyzn są ustalone z góry, na podstawie obserwacji)
- wybór mapy nierowności do zaburzania wektora normalnych