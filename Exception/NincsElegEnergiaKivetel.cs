using System;

namespace Exceptions
{
    class NincsElegEnergiaKivetel : Exception
    {
        int hianyMerteke;
        public int HianyMerteke { get; }

        public NincsElegEnergiaKivetel(int hianyMerteke):base($"Nincs elég teljesítmény, {hianyMerteke} MW hiányzik")
        {
            this.hianyMerteke = hianyMerteke;
        }
    }
}
