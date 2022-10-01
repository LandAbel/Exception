using System;

namespace Exceptions
{
    class Reaktor :IKomponens
    {
        int teljesitmeny;

        public int Teljesitmeny { get; set; }
        public bool Allapot { get; set; }

        public Reaktor(int teljesitmeny)
        {
            this.teljesitmeny = teljesitmeny;
        }

        public void Aktival()
        {
            if (Allapot==true)
            {
                throw new InvalidOperationException();
            }
            if (teljesitmeny==0)
            {
                throw new NotSupportedException();
            }
            Allapot = true;
            Teljesitmeny = -teljesitmeny;
        }

        public void Deaktival()
        {
            if (Allapot==false)
            {
                throw new InvalidOperationException();
            }
            Allapot = false;
            Teljesitmeny = 0;
        }
    }
}
