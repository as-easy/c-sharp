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
        public Form1()
        {
            InitializeComponent();
            
        }
               
        static string Encod(string s)
        {
           Encoding utf8 = Encoding.UTF8;
           // Encoding ascii = encod;
            Encoding unicode = Encoding.Unicode;

            // Convert the string into a byte array.
            byte[] unicodeBytes = unicode.GetBytes(s);

            // Perform the conversion from one encoding to the other.
            byte[] utf8Bytes = Encoding.Convert(unicode, utf8, unicodeBytes);

            // Convert the new byte[] into a char[] and then into a string.
            char[] utf8Chars = new char[utf8.GetCharCount(utf8Bytes, 0, utf8Bytes.Length)];
            utf8.GetChars(utf8Bytes, 0, utf8Bytes.Length, utf8Chars, 0);

            return s = new string(utf8Chars);
        }

        struct Element
        {
            public string tag;
            public string str;

            public Element(string tag, string newString)
            {
                this.tag = tag;
                str = newString;
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Element> element = new List<Element>
            {
                new Element("name1", "ООО 'Дружба'"),
                new Element("name2", "Иванову И.И."),
                new Element("name3", "менеджера по продажам"),
                new Element("name4", "Сидорова А.А."),
                new Element("name5", "Сидоров А.А."),
                new Element("data1", "01.06.16"),
                new Element("data2", "14.06.16"),
                new Element("data3", "20.04.16"),
            };
                     
            StreamReader shablon = new StreamReader(new FileStream("shablon3.rtf", FileMode.Open));
            StreamWriter newfail = new StreamWriter(new FileStream("furlough.rtf", FileMode.Truncate, FileAccess.Write));


            // Заполним массив элементов, сопоставив тегам соответствующий текст


            while (!shablon.EndOfStream)
            {
                string s = shablon.ReadLine();                          

                foreach (var el in element)
                {
                    Regex reg = new Regex("<" + el.tag + ">");
                    
                    s = reg.Replace(s, Encod(el.str)) + "\r\n";
                }              
                
                newfail.WriteLine(s);
            }
            
            newfail.Close();
            shablon.Close();
                  
        }
    }
}
