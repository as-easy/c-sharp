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
        List<string> questions = new List<string>();
        
        
        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(this.mybutton1_click);
            button2.Click += new EventHandler(this.mybutton2_click);
            questions.Clear();

            // Установите для свойства Multiline значение true. 
            textBox1.Multiline = true;
            // Добавьте вертикальные полосы прокрутки в элемент управления TextBox.
            textBox1.ScrollBars = ScrollBars.Vertical;
            // Разрешить RETURN в элементе управления TextBox. 
            textBox1.AcceptsReturn = true;
            // Разрешить ввод ключа TAB в элементе управления TextBox. 
            textBox1.AcceptsTab = true;
            // Установите WordWrap в значение true, чтобы текст мог переноситься на следующую строку. 
            textBox1.WordWrap = true;

            textBox2.Multiline = true;
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.AcceptsReturn = true;
            textBox2.AcceptsTab = true;
            textBox2.WordWrap = true;
        }

        private void mybutton1_click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 6)
            {
                questions.Add(textBox1.Text);
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Введите вопрос минимум из семи знаков!");
            }
        }

        private void mybutton2_click(object sender, EventArgs e)
        {
            textBox2.Clear();
            questions.ForEach(delegate (String q)
           {
               textBox2.Text += q + Environment.NewLine;
           });

        }
    }
}
