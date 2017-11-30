using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace _8_lesson
{
    [Serializable]
    public class Elements
    {
        public string question;
        public bool truefalse;

        public Elements(string strtemp, bool truefalsetemp)
        {
            question = strtemp;
            truefalse = truefalsetemp;
        }

        public Elements()
        {
        }
    }
}
