using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_lesson
{
    public partial class Form1 : Form
    {
        
       
        List<Elements> questions = new List<Elements>();
        
        private RadioButton selectedrb;

        public Form1()
        {
            InitializeComponent();

            selectedrb = null;
            //selectedrb.Text = "Выберите \"TRUE\" или \"FALSE\"";
            //button1.Click += new EventHandler(this.mybutton1_click);

            this.radioButton2.Text = "Choice 2";
            this.radioButton2.CheckedChanged += new EventHandler(radioButton_CheckedChanged);

            this.radioButton1.Text = "Choice 1";
            this.radioButton1.CheckedChanged += new EventHandler(radioButton_CheckedChanged);

            this.button1.Text = "Get selected RadioButton";
            this.button1.Click += new EventHandler(getSelectedRB_Click);

            textBox1.Multiline = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.AcceptsReturn = true;
            textBox1.AcceptsTab = true;            
            textBox1.WordWrap = true;
        }


        //private void mybutton1_click(object sender, EventArgs e)
        //{
        //    if (textBox1.Text.Length > 6)
        //    {
        //        questions.Add(textBox1.Text);
        //        textBox1.Clear();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Введите вопрос минимум из семи знаков!");
        //    }
        //}

        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }           
                        
            if (rb.Checked)
            {
                selectedrb = rb;
                
            }
        }

        // Show the text of the selected RadioButton.
        void getSelectedRB_Click(object sender, EventArgs e)
        {
            if (selectedrb == null)
            {
                MessageBox.Show("Выберите \"TRUE\" или \"FALSE\"");
                return;
            }

            if (textBox1.Text.Length < 7)
            {
                MessageBox.Show("Введите вопрос минимум из семи знаков!");
                return;
            }

            questions.Add(new Elements(textBox1.Text, selectedrb == radioButton1 ? true : false));
            textBox1.Clear();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();

            int i = 0;

            foreach(var el in questions)
            {
                textBox2.Text += el.Str + Environment.NewLine;
                textBox2.Text += el.Truefalse.ToString() + Environment.NewLine + Environment.NewLine;
            }
           
        }
    }
}
