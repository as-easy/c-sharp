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
    class InitializeComponent2
    {
        TextBox[] arrtextbox;
        Label[] arrlabel;
        GroupBox groupBox;
       

        public InitializeComponent2()
        {
            var tags = Elements();            
           
            arrtextbox = new TextBox[tags.Count];
            arrlabel = new Label[tags.Count];

            groupBox = new GroupBox()
            {
                Location = new Point(128, 6),
                Width = 180,
                Height = 30 * tags.Count + 20,
                Text = "Шаблонные значения",
            };            

            int i = 0;
            foreach (var tag in tags)
            {
                arrtextbox[i] = new TextBox()
                {
                    Location = new Point(70, 20 + i * 30),
                    Width = 100,
                    Height = 30,
                    Text = "0",

                };

                arrlabel[i] = new Label()
                {
                    Location = new Point(2, 20 + i * 30),
                    AutoSize = false,
                    Width = 60,
                    Height = 20,
                    Text = tag + ":",
                    TextAlign = ContentAlignment.MiddleRight,


                };

                groupBox.Controls.Add(arrtextbox[i]);
                groupBox.Controls.Add(arrlabel[i]);
                i++;
            } 
        }

        public List<string> Elements()
        {
            List<string> tags = new List<string>
            {
                "name1",
                "name2",
                "name3",
                "name4",
                "name5",
                "data1",
                "data2",
                "data3",
            };
            return tags;
        }

        public GroupBox GroupBoxUser()
        {
            return groupBox;
        }
    }
        
}

