using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace EM3
{
    internal class Commands : INotifyPropertyChanged
    {
        private Registers registers;
        private InputWin inputWin = new InputWin();
        public Commands(Registers registers)
        {
            this.registers = registers;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler? PropertyChangedInputArr;
        private void OnPropertyChangedInputArr([CallerMemberName] string propertyName = "")
        {
            if (PropertyChangedInputArr != null)
                PropertyChangedInputArr(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler? PropertyChangedOutputArr;
        private void OnPropertyChangedOutputArr([CallerMemberName] string propertyName = "")
        {
            if (PropertyChangedOutputArr != null)
                PropertyChangedOutputArr(this, new PropertyChangedEventArgs(propertyName));
        }
        public void MoveOp(string A1, string A2)
        {
            if (A1 == "000" || A2 == "000") { registers.regsChanged(); return; }
            registers.regsChanged();
            OnPropertyChanged(A1 + " TFR 000 " + A2);
            
        }
        public void AddIntOp(string A1, string R1, string R2)
        {
            int temp = int.Parse(R1) + int.Parse(R2);
            registers.R1 = int.Parse(R1); registers.R2 = int.Parse(R2);
            if (temp < 0) { registers.Z = 0; registers.w = 1; registers.S = 1; }
            else if (temp > 0) {registers.Z = 0; registers.w = 2; registers.S = 0; }
            else { registers.Z = 1; registers.w = 0; registers.S = 0; }
            registers.regsChanged();
            OnPropertyChanged(A1 + " TFR 000 " + temp);
        }
        public void AddFloatOp(string A1, string R1, string R2)
        {
            decimal final = decimal.Parse(R1) + decimal.Parse(R2);
            if (final < 0) { registers.Z = 0; registers.w = 1; registers.S = 1; }
            else if (final > 0) { registers.Z = 0; registers.w = 2; registers.S = 0; }
            else { registers.Z = 1; registers.w = 0; registers.S = 0; }
            registers.R1 = decimal.Parse(R1); registers.R2 = decimal.Parse(R2);
            registers.regsChanged();
            OnPropertyChanged(A1 + " TFR 000 " + final);
        }
        public void SubFloatOp(string A1, string R1, string R2)
        {
            decimal final = decimal.Parse(R1) - decimal.Parse(R2);
            if (final < 0) { registers.Z = 0; registers.w = 1; registers.S = 1; }
            else if (final > 0) { registers.Z = 0; registers.w = 2; registers.S = 0; }
            else { registers.Z = 1; registers.w = 0; registers.S = 0; }
            registers.R1 = decimal.Parse(R1); registers.R2 = decimal.Parse(R2);
            registers.regsChanged();
            OnPropertyChanged(A1 + " TFR 000 " + final);
        }
        public void MulFloatOp(string A1, string R1, string R2)
        {
            decimal final = Convert.ToDecimal(R1) * Convert.ToDecimal(R2);
            if (final < 0) { registers.Z = 0; registers.w = 1; registers.S = 1; }
            else if (final > 0) { registers.Z = 0; registers.w = 2; registers.S = 0; }
            else { registers.Z = 1; registers.w = 0; registers.S = 0; }
            registers.R1 = Convert.ToDecimal(R1); registers.R2 = Convert.ToDecimal(R2);
            registers.regsChanged();
            OnPropertyChanged(A1 + " TFR 000 " + final);
        }
        public void DivFloatOp(string A1, string R1, string R2)
        {
            decimal final = decimal.Parse(R1) / decimal.Parse(R2);
            if (final < 0) { registers.Z = 0; registers.w = 1; registers.S = 1; }
            else if (final > 0) { registers.Z = 0; registers.w = 2; registers.S = 0; }
            else { registers.Z = 1; registers.w = 0; registers.S = 0; }
            registers.R1 = decimal.Parse(R1); registers.R2 = decimal.Parse(R2);
            registers.regsChanged();
            OnPropertyChanged(A1 + " TFR 000 " + final);
        }
        public void InputFloatArr(string A1, string A2)
        {
            inputWin.enterSomeNumber.Content = "Enter a real number";
            for (int i = 0; i < int.Parse(A2); i++)
            {
                inputWin.ShowDialog();
                bool hascomma = false;
                int counter = 0;
                foreach (char c in inputWin.temp)              
                    if (c == '.' || c == ',')
                    {
                        counter++;
                        hascomma = true;
                    }                                 
                if (!hascomma && inputWin.temp != "000") inputWin.temp += ".0";
                if (counter > 1 || inputWin.temp.Contains('ю') || inputWin.temp.Contains('б'))
                    throw new ArgumentException("Invalid number entered");
                inputWin.temp = inputWin.temp.Replace('.', ',');
                OnPropertyChanged(A1 + " TFR 000 " + inputWin.temp);
                A1 = (Convert.ToInt32(A1) + 1).ToString();
                OnPropertyChangedInputArr(inputWin.temp);
            }
        }
        public void InputIntArr(string A1, string A2)
        {
            inputWin.enterSomeNumber.Content = "Input an integer";
            for (int i = 0; i < int.Parse(A2); i++)
            {
                inputWin.ShowDialog();
                OnPropertyChanged(A1 + " TFR 000 " + inputWin.temp);
                A1 = (Convert.ToInt32(A1) + 1).ToString();
                OnPropertyChangedInputArr(inputWin.temp);
            }
        }
        public void GoTo(string A2)
        {
            registers.RA = int.Parse(A2);
            registers.regsChanged();
        }
        public void FloatToInt(string A1, string A2)
        {
            A2 = A2.Replace('.', ',');
            int a = Decimal.ToInt32(decimal.Parse(A2));
            OnPropertyChanged(A1 + " TFR 000 " + a.ToString());
        }
        public void SubIntOp(string A1, string R1, string R2)
        {
            int temp = int.Parse(R1) - int.Parse(R2);
            registers.R1 = int.Parse(R1); registers.R2 = int.Parse(R2);
            if (temp < 0) { registers.Z = 0; registers.w = 1; registers.S = 1; }
            else if (temp > 0) { registers.Z = 0; registers.w = 2; registers.S = 0; }
            else { registers.Z = 1; registers.w = 0; registers.S = 0; }
            registers.regsChanged();
            OnPropertyChanged(A1 + " TFR 000 " + temp);
        }
        public void MulIntOp(string A1, string R1, string R2)
        {
            int temp = int.Parse(R1) * int.Parse(R2);
            registers.R1 = int.Parse(R1); registers.R2 = int.Parse(R2);
            if (temp < 0) { registers.Z = 0; registers.w = 1; registers.S = 1; }
            else if (temp > 0) { registers.Z = 0; registers.w = 2; registers.S = 0; }
            else { registers.Z = 1; registers.w = 0; registers.S = 0; }
            registers.regsChanged();
            OnPropertyChanged(A1 + " TFR 000 " + temp);
        }
        public void DivIntOp(string A1, string R1, string R2)
        {
            int temp = int.Parse(R1) / int.Parse(R2);
            registers.R1 = int.Parse(R1); registers.R2 = int.Parse(R2);
            if (temp < 0) { registers.Z = 0; registers.w = 1; registers.S = 1; }
            else if (temp > 0) { registers.Z = 0; registers.w = 2; registers.S = 0; }
            else { registers.Z = 1; registers.w = 0; registers.S = 0; }
            registers.regsChanged();
            OnPropertyChanged(A1 + " TFR 000 " + temp);
        }
        public void PrintFloat(List<TableRow> output)
        {
            for (int i = 0; i < output.Count; i++)
                OnPropertyChangedOutputArr(output[i].a2);
        }
        public void PrintInt(List<TableRow> output)
        {
            for (int i = 0; i < output.Count; i++) 
            {
                OnPropertyChangedOutputArr(output[i].a2.ToString());
            }
        }
        public void wGoTo(string A1, string A2)
        {
            if (registers.w == 0 || registers.w == 2)
                registers.RA = int.Parse(A1);
            else if (registers.w == 1) registers.RA = int.Parse(A2);
        }
        public void IntToFloat(string A1, string A2)
        {
            A2 += ".0";
            OnPropertyChanged(A1 + " TFR 000 " + A2);
        }
        public void IntDivRemainOp(string A1, string R1, string R2)
        {
            registers.R1 = int.Parse(R1); registers.R2 = int.Parse(R2);
            int temp = Math.Abs(int.Parse(R1)) % Math.Abs(int.Parse(R2));
            registers.regsChanged();
            OnPropertyChanged(A1 + " TFR 000 " + temp.ToString());
        }
        public void ArrIterator(TableRow A1, string A2)
        {
            int temp = int.Parse(A1.a1) + int.Parse(A2);
            OnPropertyChanged(A1.adress + " " + A1.command + " " + temp + " " + A1.a2);
        }
        public void zGoTo(string A1, string A2)
        {
            if (registers.Z == 0)
                registers.RA = int.Parse(A1);
            else registers.RA = int.Parse(A2);
        }
    }
}
