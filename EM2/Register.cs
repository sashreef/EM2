using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EM3
{
    internal class Registers : INotifyPropertyChanged
    {
        public int RA { get; set; } = 1;
        public decimal R1 { get; set; } = 0;
        public decimal R2 { get; set; } = 0;
        public int RK { get; set; } = 0;
        public int w { get; set; } = 0;
        public int Err { get; set; } = 0;
        public int S { get; set; } = 0;
        public int C { get; set; } = 0;
        public int Z { get; set; } = 0;
        public int T { get; set; } = 0;
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public void regsChanged()
        {
            OnPropertyChanged();
        }
        public Registers()
        {
            RA = 1; RK = 0;
        }
        public Registers(int RA, int RK, int R1, int R2, int w, int Err, int S, int Z, int T, int C)
        {
            this.RA = RA;
            this.RK = RK;
            this.R1 = R1;
            this.R2 = R2;
            this.w = w;
            this.Err = Err;
            this.S = S;
            this.Z = Z;
            this.T = T;
            this.C = C;
        }
        public void ResetRegisters()
        {
            RA = 1; RK = 0;
            R1 = 0; R2 = 0;
            w = 0; Z = 0; T = 0;
            C = 0; S = 0; Err = 0;
        }
    }
}
