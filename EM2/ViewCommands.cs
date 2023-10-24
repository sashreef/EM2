using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EM3
{
    internal class ViewCommands
    {
        private MainWindow codeWin;
        private Commands commands;
        public ViewCommands(Commands commands, MainWindow codeWin)
        {
            this.codeWin = codeWin;
            this.commands = commands;
            Subscribe();
        }
        private void Subscribe()
        {
            commands.PropertyChanged += PropertyChangedEventHandler;
            commands.PropertyChangedInputArr += PropertyChangedEventHandlerInputArr;
            commands.PropertyChangedOutputArr += PropertyChangedEventHandlerOutputArr;
        }
        private void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            int counter = 1;
            int addr = int.Parse(e.PropertyName.Split(" ")[0]);
            foreach (var item in codeWin.codeDataGrid.Items.OfType<TableRow>())
            {
                if (counter == addr)
                { 
                    item.adress = addr.ToString();
                    item.command = e.PropertyName.Split(" ")[1];
                    item.a1 = e.PropertyName.Split(" ")[2];
                    item.a2 = e.PropertyName.Split(" ")[3];
                    break;
                }
                counter++;
            }
            codeWin.codeDataGrid.Items.Refresh();
        }
        private void PropertyChangedEventHandlerInputArr(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "000")
                codeWin.inputLb1.Items.Add(e.PropertyName);
        }
        private void PropertyChangedEventHandlerOutputArr(object sender, PropertyChangedEventArgs e)
        {
            codeWin.outputLb.Items.Add(e.PropertyName);
        }
    }
}
