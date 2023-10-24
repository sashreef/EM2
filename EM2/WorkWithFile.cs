using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace EM3
{
    internal class WorkWithFile
    {
        public string openFileName { get; set; }
        private string saveAsFileName { get; set; }
        public void SaveFile(List<string> fileInput)
        {
            if (openFileName == null)
            {
                SaveAs(fileInput);
            }
            else File.WriteAllLines(openFileName, fileInput);

        }
        public void SaveAs(List<string> fileInput)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllLines(saveFileDialog.FileName, fileInput);
                saveAsFileName = saveFileDialog.FileName;
            }
        }
        public List<TableRow> OpenFile()
        {
            List<TableRow> tableList = new List<TableRow>();
            string[] fileOtnput = new string[513];
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                openFileName = openFileDialog.FileName;
                fileOtnput = File.ReadAllLines(openFileName);
            }
            else { return tableList; }
            for (int i = 0; i < 512; i++)
            {
                string[] temp = fileOtnput[i].Split(' ');
                tableList.Add(new TableRow(temp[0], temp[1], temp[2], temp[3]));
            }
            return tableList;
        }
    }
}
