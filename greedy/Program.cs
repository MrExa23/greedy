using System.Runtime.Serialization;
using System.Security.Authentication.ExtendedProtection;

class Solution
{
    static void Main()
    {
        Random rnd = new Random();
        int pocetSperku = rnd.Next(1000,10000);
        List<(int cena,int objem)> listSperku = new List<(int,int)>();
        Taska taska = new Taska(rnd.Next(100,1000));
        int objem = taska.objem;
        int objemSperku = 0;
        

        for (int i = 0; i < pocetSperku; i++)
        {
            listSperku.Add((rnd.Next(100, 1000000), rnd.Next(7,100)));
        }

        while (true)
        {
            (int pomer, int cena, int objem, int index) dalsiSperk = (0, 0, 0, 0);
            for (int i = 0; i < listSperku.Count; i++)
            {
                if (listSperku[i].objem > taska.objem)
                {
                    continue;
                }
                if (dalsiSperk.pomer <= listSperku[i].cena / listSperku[i].objem)
                {
                    dalsiSperk.cena = listSperku[i].cena;
                    dalsiSperk.objem = listSperku[i].objem;
                    dalsiSperk.index = i;
                    
                }
            }
            if (dalsiSperk==(0, 0, 0, 0))
            {
                break;
            }
            if (taska.objem >= dalsiSperk.pomer)
            {
                taska.ukradenySperky.Add((dalsiSperk.pomer, dalsiSperk.cena, dalsiSperk.objem));
                taska.objem=taska.objem - dalsiSperk.objem;
                taska.cena=taska.cena + dalsiSperk.cena;
                objemSperku = objemSperku + dalsiSperk.objem;
            }
            listSperku.Remove(listSperku[dalsiSperk.index]);
        }
        Console.WriteLine("cena je " +taska.cena);
        Console.WriteLine("objem sperku je " + objemSperku);
        Console.WriteLine("pocet ukradenych sperku je " + taska.ukradenySperky.Count);
        Console.WriteLine("objem tasky je "+ objem);
        Console.WriteLine("pocetsperku je "+ pocetSperku);



    }
}



class Taska
{
    public List<(int, int, int)> ukradenySperky = new();
    public int objem { get; set;}
    public int cena = 0;
    public Taska(int objem)
    {
        this.objem = objem;
    }
}
