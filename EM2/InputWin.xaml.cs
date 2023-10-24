using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EM3
{
    /// <summary>
    /// Логика взаимодействия для InputWin.xaml
    /// </summary>
    public partial class InputWin : Window
    {
        public string temp { get; set; }
        public InputWin()
        {
            InitializeComponent();
            inputFloatBox.Focus();
            temp = "";
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            temp = inputFloatBox.Text;
            if (temp == "")
                temp = "000";
            inputFloatBox.Clear();
            Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            temp = "000";
            inputFloatBox.Clear();
            Hide();
        }

        private void inputFloatBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) 
                & e.Key != Key.Back & e.Key != Key.OemComma & e.Key != Key.OemPeriod & e.Key != Key.OemMinus)
                e.Handled = true;
        }
    }
}
