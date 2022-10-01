using System;

namespace Exceptions
{
    class KomponensNemFerElKivetel : Exception
    {
        IKomponens komponens;

        public IKomponens Komponens { get { return komponens; } }

        public KomponensNemFerElKivetel(string message, IKomponens k) : base(message)
        {
            this.komponens = k;
        }
    }
}
