using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace _8_lesson
{
    /// <summary>
    /// Класс служит для сохранения и загрузки данных из предлагаемого файла xml
    /// </summary>
    class XmlClass
    {
        public void SaveAsXmlFormat(List<Elements> obj, string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Elements>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, obj);
            fStream.Close();
        }

        public List<Elements> LoadAsXmlFormat(string fileName)
        {
            XmlSerializer xmlformat = new XmlSerializer(typeof(List<Elements>));            
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            List<Elements> objxml = (List<Elements>)xmlformat.Deserialize(fStream);
            fStream.Close();
            return objxml;            
        }
    }
}
