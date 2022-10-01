namespace Exceptions
{
    class Hajtomu :IKomponens
    {
        int toloero;

        public int Teljesitmeny { get; set; }
        public bool Allapot { get; set;}

        public Hajtomu(int toloero)
        {
            this.toloero = toloero;
        }

        public void Aktival()
        {
            Allapot = true;
            Teljesitmeny = toloero;
        }

        public void Deaktival()
        {
            Allapot = false;
            Teljesitmeny = 0;
        }
    }
}
