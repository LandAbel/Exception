using System;

namespace Exceptions
{
    class Urhajo
    {
        string nev;
        public string Nev { get {return nev; } }
        int uresTomeg;
        public int UresTomeg { get { return uresTomeg; } }
        int aktualisTeljesitmeny;
        public int AktualisTeljesitmeny { get {return aktualisTeljesitmeny; } }
        UrhajoKategoria kategoria;
        public UrhajoKategoria Kategoria { get {return kategoria; } }
        IKomponens[] komponensek;

        public Urhajo(string nev, int uresTomeg, UrhajoKategoria kategoria)
        {
            this.nev = nev;
            this.uresTomeg = uresTomeg;
            this.kategoria = kategoria;
            if (uresTomeg<=0)
            {
                throw new ArgumentOutOfRangeException(nameof(uresTomeg), "Az üres tömeg nem lehet negatív!");
            }
            if (nev==null)
            {
                throw new ArgumentNullException(nameof(nev));
            }
            if (kategoria==UrhajoKategoria.Yacht)
            {
                komponensek = new IKomponens[2];
            }
            else if (kategoria==UrhajoKategoria.Korvett)
            {
                komponensek = new IKomponens[4];
            }
            else if (kategoria == UrhajoKategoria.Fregatt)
            {
                komponensek = new IKomponens[6];
            }
            else if (kategoria == UrhajoKategoria.Rombolo)
            {
                komponensek = new IKomponens[8];
            }
            else if (kategoria == UrhajoKategoria.Teher)
            {
                komponensek = new IKomponens[8];
            }
            else
            {
                komponensek = new IKomponens[20];
            }

            Console.WriteLine($"{nev} letrehozva");
        }
        public void KomponensFelszerel(IKomponens komp)
        {
            int dbsz = 0;
            while (dbsz < komponensek.Length && komponensek[dbsz]!=null)
            {
                dbsz++;
            }
            if (dbsz==komponensek.Length)
            {
                throw new KomponensNemFerElKivetel("A komponens nem fér fel", komp);
            }
            komponensek[dbsz] = komp;
            Console.WriteLine($"[Hozzaadas] {komp.GetType().Name} hozzadva a(z) {Nev}");
        }
        public void KomponensLeszerel(int db)
        {
            if (komponensek[db]==null)
            {
                throw new KomponensNemTalalhatoKivetel("Itt nincs komponens!");
            }
            komponensek[db] = null;
            Console.WriteLine($"[Leszereles] {komponensek[db].GetType().Name} hozzadva a(z) {Nev}");
        }
        public void Padlogaz()
        {
            for (int i = 0; i < komponensek.Length; i++)
            {
                Hajtomu power = komponensek[i] as Hajtomu;
                if (power !=null && power.Allapot==false)
                {
                    power.Aktival();
                    aktualisTeljesitmeny -= power.Teljesitmeny;
                }
            }
            if (aktualisTeljesitmeny < 0)
            {
                int deficit = -aktualisTeljesitmeny;
                for (int i = 0; i < komponensek.Length; i++)
                {
                    Hajtomu ultrapower = komponensek[i] as Hajtomu;
                    if (ultrapower != null && ultrapower.Allapot == false)
                    {
                        aktualisTeljesitmeny += ultrapower.Teljesitmeny;
                        ultrapower.Deaktival();
                    }
                }
                throw new NincsElegEnergiaKivetel(deficit);
            }
            Console.WriteLine($"[Padlogaz] A(z) {nev} urhajo padlogazon megy.");
        }
        public void Beindit()
        {
            for (int i = 0; i < komponensek.Length; i++)
            {
                Reaktor psu = komponensek[i] as Reaktor;
                if (psu!=null)
                {
                    try
                    {
                        psu.Aktival();
                        aktualisTeljesitmeny += psu.Teljesitmeny;
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("[HIBA] Egy reaktor már müködik");
                    }
                    catch (NotSupportedException)
                    {
                        KomponensLeszerel(i);
                    }
                }
            }
            Console.WriteLine($"[Beinditas] A(z) {nev} urhajo beröfentve.");
        }
        public void Leallit()
        {
            try
            {
                for (int i = 0; i < komponensek.Length; i++)
                {
                    if (komponensek[i]!=null)
                    {
                        komponensek[i].Deaktival();
                    }
                }
            }
            catch (Exception ed)
            {
                throw new NemDeaktivalhatoKivetel("Egy komponens nem deaktiválható", ed);
            }
            finally
            {
                Console.WriteLine($"[Leallitas] A(z) {nev} urhajo leallitasa meghívva.");
            }
        }
    }
}
