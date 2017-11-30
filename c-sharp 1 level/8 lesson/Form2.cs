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
    public partial class Form2 : Form
    {

        List<Elements> questions = new List<Elements>();
        const string xmlfail = "questionDB.xml";
        private RadioButton selectedrb;
        public Form2()
        {
            InitializeComponent();

            selectedrb = null;
            //selectedrb.Text = "Выберите \"TRUE\" или \"FALSE\"";
            //button1.Click += new EventHandler(this.mybutton1_click);

            this.radioButton1.Text = "TRUE";
            this.radioButton1.CheckedChanged += new EventHandler(radioButton_CheckedChanged);

            this.radioButton2.Text = "FALSE";
            this.radioButton2.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
                       
            this.button1.Click += new EventHandler(getSelectedRB_Click);

            textBox1.Multiline = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.AcceptsReturn = true;
            textBox1.AcceptsTab = true;
            textBox1.WordWrap = true;
        }

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

        /// <summary>
        /// Метод для добавление вопроса в список вопросов
        /// </summary>
        /// <param name="sender">Принимает RadioButton объект</param>
        /// <param name="e">Принимает событие выбранного RadioButton</param>
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

        /// <summary>
        /// Выгрузка списка вопросов в xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            XmlClass xmlquestions = new XmlClass();


            foreach (var el in questions)
            {
                textBox2.Text += el.question + Environment.NewLine;
                textBox2.Text += el.truefalse.ToString() + Environment.NewLine + Environment.NewLine;
            }

            xmlquestions.SaveAsXmlFormat(questions, xmlfail);
        }
        
    }
}
