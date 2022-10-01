using System;

namespace Exceptions
{
    class NemDeaktivalhatoKivetel :Exception
    {
        public NemDeaktivalhatoKivetel(string message, Exception e) : base(message, e) { }
    }
}
