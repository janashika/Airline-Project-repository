using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFlightModelLibrary
{
    public class NoFlightInDatabaseException : ApplicationException
    {
        string myMsg;
        public NoFlightInDatabaseException()
        {
            myMsg = "no such a for the destination flight data present";
        }
        public override string Message => myMsg;
    }
}
