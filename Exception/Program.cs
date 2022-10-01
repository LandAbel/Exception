using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Urhajo Discovery = new Urhajo("Discovery", 13500000, UrhajoKategoria.Rombolo);
            Urhajo Imperial = new Urhajo("Imperial", 1000000000, UrhajoKategoria.Allomas);
            Urhajo DarthVader = new Urhajo("DarthVader", 50000, UrhajoKategoria.Fregatt);
            Urhajo CR90Corvette = new Urhajo("CR90Corvette", 50000, UrhajoKategoria.Korvett);
            try
            {
                Urhajo problem1 = new Urhajo("Test1", -500, UrhajoKategoria.Yacht);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[KIVETEL] {ex.Message}");
            }
            try
            {
                Urhajo problem2 = new Urhajo(null, 5000, UrhajoKategoria.Yacht);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[KIVETEL] {ex.Message}");
            }
            try
            {
                CR90Corvette.KomponensFelszerel(new Hajtomu(600));
                CR90Corvette.KomponensFelszerel(new Reaktor(300));
                Imperial.KomponensFelszerel(new Hajtomu(5000));
                Imperial.KomponensFelszerel(new Hajtomu(10000));
                Imperial.KomponensFelszerel(new Reaktor(5000));
                DarthVader.KomponensFelszerel(new Hajtomu(500));
                Discovery.KomponensFelszerel(new Hajtomu(500));
                Discovery.KomponensFelszerel(new Hajtomu(600));
                Discovery.KomponensFelszerel(new Hajtomu(500));
                Discovery.KomponensFelszerel(new Hajtomu(600));
                Discovery.KomponensFelszerel(new Hajtomu(500));
                Discovery.KomponensFelszerel(new Hajtomu(600));
                Discovery.KomponensFelszerel(new Reaktor(1800));
                Discovery.KomponensFelszerel(new Reaktor(4200));

            }
            catch (Exception ed)
            {
                Console.WriteLine($"[KIVETEL] {ed.Message}");
            }
            try
            {
                Discovery.KomponensLeszerel(1);
                Discovery.KomponensLeszerel(1);
            }
            catch (Exception ef)
            {
                Console.WriteLine($"[KIVETEL] {ef.Message}");
            }
            try
            {
                Discovery.Beindit();
            }
            catch (Exception eg)
            {
                Console.WriteLine($"[KIVETEL] {eg.Message}");
            }
            try
            {
                Discovery.Beindit();
            }
            catch (Exception eh)
            {
                Console.WriteLine($"[KIVETEL] {eh.Message}");
            }
            try
            {
                Discovery.Padlogaz();
            }
            catch (Exception ei)
            {
                Console.WriteLine($"[KIVETEL] {ei.Message}");
            }
            try
            {
                Discovery.Leallit();
            }
            catch (Exception ej)
            {
                Console.WriteLine($"[KIVETEL] {ej.Message}");
            }
            try
            {
                Imperial.Leallit();
            }
            catch (Exception ek)
            {
                Console.WriteLine($"[KIVETEL] {ek.Message}");
                Console.WriteLine($"[BELSO KIVETEL]: {ek.InnerException.Message}");
            }

        }
    }
    public enum UrhajoKategoria
    {
        Yacht,
        Korvett,
        Fregatt,
        Rombolo,
        Teher,
        Allomas
    }
    interface IKomponens
    {
        int Teljesitmeny { get; set; }
        bool Allapot { get; set; }
        void Aktival();
        void Deaktival();
    }
}
