using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EM3
{
    internal class ViewRegisters
    {
        private MainWindow codeWin;
        private Registers registers;
        public ViewRegisters(Registers registers, MainWindow codeWin)
        {
            this.codeWin = codeWin;
            this.registers = registers;
            Subscribe();
        }
        private void Subscribe()
        {
            registers.PropertyChanged += PropertyChangedEventHandler;
        }
        private void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e) // RA RK R1 R2 w Err S Z O
        {
            List<Registers> regs = new List<Registers>();
            regs.Add(registers);
            codeWin.registersList.ItemsSource = regs;
            codeWin.registersList2.ItemsSource = regs;
        }
    }
}
