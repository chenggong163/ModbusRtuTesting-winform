using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRtuTesting
{
    internal class ExceptionMessage : ApplicationException
    {
        public ExceptionMessage() { }

        public ExceptionMessage(string message) 
        {
            Console.Write(message);
        }

    }
}
