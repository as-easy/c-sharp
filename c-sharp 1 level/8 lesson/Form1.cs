using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace _8_lesson
{
    /// <summary>
    /// Автор - Варанкин Владимир
    /// Задание 2. *Используя полученные знания разработать игру “Верю-Не верю"
    /// Form1 - открывает игру Верю - Не верю
    /// Также присутствует редактор вопросов Form2
    /// </summary>
    public partial class Form1 : Form
    {
        List<Elements> questions = new List<Elements>();
        XmlClass xmlquestions = new XmlClass();
        const string xmlfail = "questionDB.xml";
        private RadioButton selectedrb;
        int index = 0;

        
        public Form1()
        {
            InitializeComponent();
            
            selectedrb = null;            
            
            this.radioButton1.CheckedChanged += new EventHandler(radioButton_CheckedChanged);

            this.radioButton2.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            
            textBox1.Multiline = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.AcceptsReturn = true;
            textBox1.AcceptsTab = true;
            textBox1.WordWrap = true;

        }
        /// <summary>
        /// Метод для выбора RadioButton, чтобы использовать в дальнейшем 
        /// </summary>
        /// <param name="sender">Принимает RadioButton объект</param>
        /// <param name="e">Принимает событие выбранного RadioButton</param>
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
        /// Переход к следующему вопросу и проверка на правильность текущего вопроса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedrb == null)
            {
                MessageBox.Show("Выберите \"Верю\" или \"Не верю\"");
                return;
            }

            if (index < questions.Count)
            {             
                
                if (selectedrb == radioButton1 && questions[index].truefalse == true)
                {
                    label5.Text = (Int32.Parse(label5.Text) + 1).ToString();
                }
                else if (selectedrb == radioButton2 && questions[index].truefalse == false)
                {
                    label5.Text = (Int32.Parse(label5.Text) + 1).ToString();
                }
                else
                {
                    label6.Text = (Int32.Parse(label6.Text) + 1).ToString();
                }
                index++;                
            }
            else
            {
                MessageBox.Show($"Вопросы закончились. Вы ответили правильно {Int32.Parse(label5.Text)} раз(а)");
                return;
            }

            if (index > questions.Count - 1) return;
            groupBox2.Text = "Вопрос " + (index + 1).ToString();
            textBox1.Text = questions[index].question;
        }

        /// <summary>
        /// Импорт базы данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox2.Text = "Вопрос 1";           
            questions = xmlquestions.LoadAsXmlFormat(xmlfail);
            index = 0;
            textBox1.Text = questions[index].question;
            label4.Text = questions.Count.ToString();
            label5.Text = "0";
            label6.Text = "0";          
            
        }
        /// <summary>
        /// Импорт базы данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox2.Text = "Вопрос 1";
            questions = xmlquestions.LoadAsXmlFormat(xmlfail);
            index = 0;
            textBox1.Text = questions[index].question;
            label4.Text = questions.Count.ToString();
            label5.Text = "0";
            label6.Text = "0";
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Открыть "Редактор вопросов"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }
    }
}
