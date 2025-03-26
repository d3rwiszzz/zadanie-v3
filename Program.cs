// polskie znaki(ą, ć, ę, ł, ń, ó, ś, ź, ż)
class Program
{
    class Produkt
    {
        public string Nazwa { get; set; }
        public int Ilosc { get; set; }
        public double Cena { get; set; }

        public Produkt(string nazwa, int ilosc, double cena)
        {
            Nazwa = nazwa;
            Ilosc = ilosc;
            Cena = cena;
        }
    }

    static List<Produkt> magazyn = new List<Produkt>(); 

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Dodaj produkt");
            Console.WriteLine("2. Usuń produkt");
            Console.WriteLine("3. Wyświetl listę produktów");
            Console.WriteLine("4. Aktualizuj produkt");
            Console.WriteLine("5. Oblicz wartość magazynu");
            Console.WriteLine("6. Wyjście");
            Console.Write("Wybierz opcję: ");

            string? wybor = Console.ReadLine();// "? - oznacza, że zmienna może być nullem" - github copilot
            if (string.IsNullOrEmpty(wybor))
            {
                Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                continue;
            }

            switch (wybor)
            {
                case "1":
                    DodajProdukt();
                    break;
                case "2":
                    UsunProdukt();
                    break;
                case "3":
                    WyswietlProdukty();
                    break;
                case "4":
                    AktualizujProdukt();
                    break;
                case "5":
                    ObliczWartoscMagazynu();
                    break;
                case "6":
                    Console.WriteLine("Zamykanie programu...");
                    return;
                default:
                    Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                    break;
            }
        }
    }

    static void DodajProdukt()
    {
        Console.Write("Podaj nazwę produktu: ");
        string? nazwa = Console.ReadLine();
        if (string.IsNullOrEmpty(nazwa))
        {
            Console.WriteLine("Nazwa produktu nie może być pusta!");
            return;
        }

        Console.Write("Podaj ilość: ");
        if (!int.TryParse(Console.ReadLine(), out int ilosc))
        {
            Console.WriteLine("Błędna wartość dla ilości!");
            return;
        }

        Console.Write("Podaj cenę jednostkową: ");
        if (!double.TryParse(Console.ReadLine(), out double cena))
        {
            Console.WriteLine("Błędna wartość dla ceny!");
            return;
        }

        magazyn.Add(new Produkt(nazwa, ilosc, cena));
        Console.WriteLine("Produkt dodany pomyślnie!");
    }

    static void UsunProdukt()
    {
        Console.Write("Podaj nazwę produktu do usunięcia: ");
        string? nazwa = Console.ReadLine();
        if (string.IsNullOrEmpty(nazwa))
        {
            Console.WriteLine("Nazwa produktu nie może być pusta!");
            return;
        }

        Produkt? produkt = magazyn.FirstOrDefault(p => p.Nazwa.Equals(nazwa, StringComparison.OrdinalIgnoreCase));

        if (produkt != null)
        {
            magazyn.Remove(produkt);
            Console.WriteLine("Produkt został usunięty.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono produktu.");
        }
    }

    static void WyswietlProdukty()
    {
        if (magazyn.Count == 0)
        {
            Console.WriteLine("Magazyn jest pusty.");
            return;
        }

        Console.WriteLine("\nLista produktów:");
        foreach (var produkt in magazyn)
        {
            Console.WriteLine($"Nazwa: {produkt.Nazwa}, Ilość: {produkt.Ilosc}, Cena: {produkt.Cena} zł");
        }
    }

    static void AktualizujProdukt()
    {
        Console.Write("Podaj nazwę produktu do aktualizacji: ");
        string? nazwa = Console.ReadLine();
        if (string.IsNullOrEmpty(nazwa))
        {
            Console.WriteLine("Nazwa produktu nie może być pusta!");
            return;
        }

        Produkt? produkt = magazyn.FirstOrDefault(p => p.Nazwa.Equals(nazwa, StringComparison.OrdinalIgnoreCase));// ? naprawilo warning
        if (produkt == null)
        {
            Console.WriteLine("Nie znaleziono produktu.");
            return;
        }

        Console.WriteLine("Co chcesz zaktualizować?");
        Console.WriteLine("1. Ilość");
        Console.WriteLine("2. Cenę");
        Console.WriteLine("3. Obie wartości");
        Console.Write("Wybierz opcję: ");
        string? opcja = Console.ReadLine();
        if (string.IsNullOrEmpty(opcja))
        {
            Console.WriteLine("Niepoprawny wybór.");
            return;
        }

        switch (opcja)
        {
            case "1":
                Console.Write("Podaj nową ilość: ");
                if (int.TryParse(Console.ReadLine(), out int nowaIlosc))
                {
                    produkt.Ilosc = nowaIlosc;
                    Console.WriteLine("Ilość zaktualizowana.");
                }
                else
                {
                    Console.WriteLine("Błędna wartość.");
                }
                break;

            case "2":
                Console.Write("Podaj nową cenę: ");
                if (double.TryParse(Console.ReadLine(), out double nowaCena))
                {
                    produkt.Cena = nowaCena;
                    Console.WriteLine("Cena zaktualizowana.");
                }
                else
                {
                    Console.WriteLine("Błędna wartość.");
                }
                break;

            case "3":
                Console.Write("Podaj nową ilość: ");
                if (int.TryParse(Console.ReadLine(), out nowaIlosc))
                {
                    produkt.Ilosc = nowaIlosc;
                }
                else
                {
                    Console.WriteLine("Błędna wartość dla ilości.");
                    return;
                }

                Console.Write("Podaj nową cenę: ");
                if (double.TryParse(Console.ReadLine(), out nowaCena))
                {
                    produkt.Cena = nowaCena;
                }
                else
                {
                    Console.WriteLine("Błędna wartość dla ceny.");
                    return;
                }

                Console.WriteLine("Produkt został zaktualizowany.");
                break;

            default:
                Console.WriteLine("Niepoprawny wybór.");
                break;
        }
    }

    static void ObliczWartoscMagazynu()
    {
        double wartoscMagazynu = magazyn.Sum(p => p.Ilosc * p.Cena);
        Console.WriteLine($"Łączna wartość magazynu: {wartoscMagazynu} zł");
    }
}
