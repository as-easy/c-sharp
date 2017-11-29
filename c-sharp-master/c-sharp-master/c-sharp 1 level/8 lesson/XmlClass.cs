using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace _8_lesson
{
    class XmlClass
    {
        public void SaveAsXmlFormat(List<Elements> obj, string fileName)
        {            
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Elements>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);         
            xmlFormat.Serialize(fStream, obj);
            fStream.Close();
        }
    }
}
