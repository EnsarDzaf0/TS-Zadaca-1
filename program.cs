using System;

// Ensar Dzafo
enum Lokacija
{
    Gradsko,
    Prigradsko,
}

class Stan
{
    public int brojKvadrata { get; set; }
    public Lokacija lokacija { get; set; }
    public bool namjesten { get; set; }
    public bool internet { get; set; }

    public Stan(int brojKvadrata, Lokacija lokacija, bool namjesten, bool internet)
    {
        this.brojKvadrata = brojKvadrata;
        this.lokacija = lokacija;
        this.namjesten = namjesten;
        this.internet = internet;
    }

    public virtual void Ispisi()
    {
        Console.Write($"{brojKvadrata,-2}, {lokacija,-9}, {namjesten,-8}, {internet,-7}");
    }

    public virtual double ObracnuajCijenuNajma()
    {
        double cijena = (Lokacija == Lokacija.Gradsko) ? 200 : 150;
        cijena += brojKvadrata * 1;
        if (namjesten && internet)
        {
            cijena += cijena * 0.01;
        }
        else if (!namjesten && internet)
        {
            cijena += cijena * 0.02;
        }

        return cijena;
    }
}

// Nenamjesten stan klasa

// Namjesten stan klasa

class Program
{
    static void Main(string[] args)
    {
        Stan[] stanovi = new Stan[4];
        stanovi[0] = new NenamjestenStan(50, Lokacija.Gradsko, true);
        stanovi[1] = new NenamjestenStan(80, Lokacija.Prigradsko, true);
        stanovi[2] = new NamjestenStan(40, Lokacija.Prigradsko, true, 2000, 2);
        stanovi[3] = new NamjestenStan(80, Lokacija.Gradsko, false, 3000, 6);
        Console.WriteLine("Površina Lokacija Namješten Internet Vrijednost namještaja Broj aparata");
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
        while (!Int32.TryParse(Console.ReadLine(), out maxPovrsina) || minPovrsina < 0)
        {
            Console.WriteLine("Unos nije ispravan");
        }
        foreach (Stan stan in stanovi)
        {
            if (stan.BrojKvadrata >= minPovrsina && stan.BrojKvadrata <= maxPovrsina)
            {
                stan.Ispisi();
                Console.WriteLine("Ukupna cijena najma stana je {0:F2}.", stan.ObracunajCijenuNajma());
            }
        }
        Console.ReadLine();
    }

}