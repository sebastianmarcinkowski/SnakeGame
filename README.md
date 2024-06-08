#Prosta gra konsolowa Snake w języku C#
Jest to klasyczna gra Snake zaimplementowana w C#, w której gracz steruje wężem poruszającym się po planszy. Celem gry jest zdobywanie punktów poprzez zjadanie owoców, jednocześnie unikając kolizji ze ścianami i własnym ciałem.

Sposób uruchamiania
1. Upewnij się, że masz zainstalowane środowisko .NET na swoim komputerze.
2. Pobierz lub sklonuj repozytorium z kodem źródłowym gry.
3. Otwórz projekt w środowisku programistycznym, takim jak Visual Studio lub Visual Studio Code.
4. Skompiluj projekt i uruchom plik wykonywalny. Gra uruchomi się w oknie konsoli.

Sterowanie
Strzałki kierunkowe: Sterowanie wężem (góra, dół, lewo, prawo lub W, S, A, D).

Zasady gry
- Gra zaczyna się po naciśnięciu klawisza Enter.
- Wąż porusza się po planszy w wybranym kierunku (strzałkami kierunkowymi).
- Celem jest zjadanie owoców (symbolizowanych przez *), które losowo pojawiają się na planszy.
- Za każdy zjedzony owoc wąż się wydłuża, a gracz zdobywa punkt.
- Gra kończy się, gdy wąż zderzy się ze ścianą lub swoim ciałem.
- Po zakończeniu gry wyświetlany jest ostatni wynik gracza.

Metody i klasy pomocnicze
- Pixel: Klasa reprezentująca pojedynczy piksel na planszy, zawierająca informacje o pozycji, znaku i kolorze.
- Direction: Enum reprezentujący cztery możliwe kierunki ruchu węża.
- GenerateFood(): Metoda odpowiedzialna za losowe generowanie nowego owocu na planszy.
- DrawBoard(): Metoda odpowiedzialna za rysowanie planszy, węża i owocu.
- ShowScore(): Metoda wyświetlająca aktualny wynik gracza.
- WaitForKey(): Metoda obsługująca wejście od gracza (ruchy strzałkami).
- MoveSnake(): Metoda aktualizująca pozycję węża na podstawie wybranego kierunku.
- CheckCollision(): Metoda sprawdzająca, czy wąż zderzył się ze ścianą lub swoim ciałem.
- CheckFoodCollision(): Metoda sprawdzająca, czy wąż zjadł owoc, oraz wydłużająca węża i generująca nowy owoc.
