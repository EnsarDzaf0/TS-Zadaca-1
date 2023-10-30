using System;

enum Lokacija
{
    Gradsko,
    Prigradsko
}

class Stan
{
    public int BrojKvadrata;
    public Lokacija Lokacija;
    public bool Namjesten;
    public bool Internet;

    // Dodatni podaci o namještaju
    public int BrojNamjestaja;
    public int BrojAparata;

    // Konstruktor za inicijalizaciju podataka o stanu
    public Stan(int brojKvadrata, Lokacija lokacija, bool namjesten, bool internet, int brojNamjestaja, int brojAparata)
    {
        BrojKvadrata = brojKvadrata;
        Lokacija = lokacija;
        Namjesten = namjesten;
        Internet = internet;
        BrojNamjestaja = brojNamjestaja;
        BrojAparata = brojAparata;
    }

    // Metoda za ispis informacija o stanu
    public void Ispisi()
    {
        Console.Write($"{BrojKvadrata,-10} {Lokacija,-10} {Namjesten,-10} {Internet,-10}");

        if (Namjesten)
        {
            Console.WriteLine($"Namještaj: {BrojNamjestaja} aparata: {BrojAparata}");
        }
        else
        {
            Console.WriteLine();
        }
    }

    // Metoda za obračun cijene najma
    public double ObracunajCijenuNajma()
    {
        double osnovnaCijena = (Lokacija == Lokacija.Gradsko) ? 200 : 150;
        double cijenaKvadrata = BrojKvadrata;
        double cijenaNajma = osnovnaCijena + cijenaKvadrata;

        if (!Namjesten)
        {
            cijenaNajma *= 1.02; // povećaj za 2% ako je nenamješten
        }
        else
        {
            cijenaNajma *= 1.01; // povećaj za 1% ako je namješten
        }

        return cijenaNajma;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Stan[] stanovi = new Stan[4];
        stanovi[0] = new Stan(50, Lokacija.Gradsko, true, true, 5, 3);
        stanovi[1] = new Stan(80, Lokacija.Prigradsko, false, true, 0, 2);
        stanovi[2] = new Stan(40, Lokacija.Prigradsko, true, true, 2, 4);
        stanovi[3] = new Stan(80, Lokacija.Gradsko, true, false, 4, 1);

        Console.WriteLine("Površina Lokacija Namješten Internet Namještaj Aparati");
        foreach (Stan stan in stanovi)
        {
            stan.Ispisi();
        }

        int minPovrsina = 0;
        int maxPovrsina = 0;

        Console.WriteLine("Unesite minimalnu zeljenu povrsinu");
        while (!Int32.TryParse(Console.ReadLine(), out minPovrsina) || minPovrsina < 0)
        {
            Console.WriteLine("Unos nije ispravan");
        }

        Console.WriteLine("Unesite maksimalnu zeljenu povrsinu");
        while (!Int32.TryParse(Console.ReadLine(), out maxPovrsina) || maxPovrsina < 0)
        {
            Console.WriteLine("Unos nije ispravan");
        }

        Console.WriteLine("Odaberite podrucje (0 - Gradsko, 1 - Prigradsko):");
        Lokacija selectedLokacija = (Lokacija)Enum.Parse(typeof(Lokacija), Console.ReadLine());

        foreach (Stan stan in stanovi)
        {
            if (stan.BrojKvadrata >= minPovrsina && stan.BrojKvadrata <= maxPovrsina && stan.Lokacija == selectedLokacija)
            {
                stan.Ispisi();
                Console.WriteLine("Ukupna cijena najma stana je {0:F2}.", stan.ObracunajCijenuNajma());
            }
        }

        Console.ReadLine();
    }
}
