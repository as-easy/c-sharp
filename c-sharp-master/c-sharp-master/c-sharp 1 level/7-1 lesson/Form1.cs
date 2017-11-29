using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace _7_lesson
{
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();

        public Form1()
        {
            InitializeComponent();
            InitializeComponent2 IC = new InitializeComponent2();
            
            this.Controls.Add(IC.GroupBoxUser());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = form2.richTextBox1.Text;

            InitializeComponent2 tags = new InitializeComponent2();
            foreach (var tag in tags.Elements())
            {
                Regex reg = new Regex("<" + tag + ">");


                s = reg.Replace(s, TextBox1.Text);  //// Вот здесь я застопорился - времени не хватило
            }
            



        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile1 = new OpenFileDialog();

            // Initialize the OpenFileDialog to look for RTF files.
            openFile1.DefaultExt = "*.rtf";
            openFile1.Filter = "RTF Files|*.rtf";

            // Determine whether the user selected a file from the OpenFileDialog.
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile1.FileName.Length > 0)
            {
                // Load the contents of the file into the RichTextBox.
                
                              

                form2.richTextBox1.LoadFile(openFile1.FileName);
                form2.Show();
            }
        }
    }
}
