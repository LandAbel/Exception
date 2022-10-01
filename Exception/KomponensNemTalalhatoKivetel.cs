using System;

namespace Exceptions
{
    class KomponensNemTalalhatoKivetel :Exception
    {
        public KomponensNemTalalhatoKivetel() { }
        public KomponensNemTalalhatoKivetel(string message):base(message) { }
    }
}
