using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusRtuTesting
{
    internal class ListItem
    {
        ArrayList arrayList = new ArrayList();

        public string[] outBaudRate() 
        {
            string[] baudRate = { "115200", "57600", "38400", "19200", "9600", "4800"};
            return baudRate;
        }

        public string[] outClawKind() 
        {
            string[] clawKind = { "EPG","RG","ECG","EPG-HP","LEPG","ERG32","ERG26","ZRG","ERG08","EVS01","EVS08","EVS10","ELS","JH3","RG-RM"};
            return clawKind;
        }
    }
}
