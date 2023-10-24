using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM3
{
    internal class TableRow
    {
        public string adress { get; set; }
        public string command { get; set; }
        public string a1 { get; set; }
        public string a2 { get; set; }
        public TableRow(string adress, string command, string a1, string a2)
        {
            this.adress = adress;
            this.command = command;
            this.a1 = a1;
            this.a2 = a2;
        }
        public TableRow()
        {
            this.adress = "0";
            this.command = "TFR";
            this.a1 = "000";
            this.a2 = "000";
        }
    }
}
