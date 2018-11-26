using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BT5._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Login fr = new Login();
            fr.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\";
            theDialog.Multiselect = false;
            DialogResult result = theDialog.ShowDialog();
            string path = theDialog.FileName;         
            if (result == DialogResult.OK)
            {
                string value = ".";
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader rd = new StreamReader(fs);
                txt.Clear();
                while (String.IsNullOrEmpty(value) == false)
                {
                    value = rd.ReadLine();                   
                    txt.Text += value + Environment.NewLine;
                }
                
            }
           
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.FileName = "Name.txt";

            save.Filter = "Text File | *.txt";

            if (save.ShowDialog() == DialogResult.OK)

            {
                StreamWriter writer = new StreamWriter(save.OpenFile());
                for(int i = 0; i < txt.Lines.Count(); i++)
                {
                    writer.WriteLine(txt.Lines[i]);
                }
                             
                writer.Dispose();
                writer.Close();

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login fr = new Login();
            fr.ShowDialog();
            this.Close();
        }

        private void txt_SelectionChanged(object sender, EventArgs e)
        {

            int index =txt.SelectionStart;
            int line = txt.GetLineFromCharIndex(index);

            // Get the column.
            int firstChar = txt.GetFirstCharIndexFromLine(line);
            int column = index - firstChar;

            statusBar.Text = "Line " + line + " Col " + column;
        }
    }
}
