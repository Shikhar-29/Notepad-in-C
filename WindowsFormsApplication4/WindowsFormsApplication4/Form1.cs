using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Corner Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fdlg.FileName;
            }
            string text = System.IO.File.ReadAllText(fdlg.FileName);
            textBox1.Text = text;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.OpenFile()))
                {
                    sw.Write(textBox1.Text);
                }
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                Font font = fontDialog1.Font;
                this.textBox1.Font = font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                this.textBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String s="This project is made by the group of three people \n SHIKHAR SAXENA  15BIT0260 \n YASH TYAGI   15BIT0269 \n APURV GUPTA   15BIT0273 \n   IN CASE OF ANY QUERY PLEASE CONTACT THEM";
            textBox1.Text=s;
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter the string to search in the file", "Title", "Default", 0, 0);
            string z = textBox1.Text;
            if (z.Contains(input))
            {
                string s = "String found in position"+z.IndexOf(input).ToString();
                MessageBox.Show(s);
            }
        }

        private void findReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input1 = Microsoft.VisualBasic.Interaction.InputBox("Enter the string to be searched in the file", "Title", "Default", 0, 0);
            string input2 = Microsoft.VisualBasic.Interaction.InputBox("Enter the new string to be replaced with the old word in the file", "Title", "Default", 0, 0);
            
            string z = textBox1.Text;
            if (z.Contains(input1))
            {
                z = z.Replace(input1, input2);
                textBox1.Text = z;
            }
        }

       
    }
}
