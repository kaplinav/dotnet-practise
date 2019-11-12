using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Card c = new Card()
            {
                Word = "WORD",
                Translate = new string[] { "слово", "слово два", "слово три" },
                partName = PartOfSpeech.NOUN

            };


            Stream s = null;
            //IFormatter i = null;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Card));

            s = new FileStream("data.xml", FileMode.Create);
            //i = new BinaryFormatter();
            //i.Serialize(s, c);

            xmlSerializer.Serialize(s, c);
            s.Close();

            //s = new FileStream("data.xml", FileMode.Open);
            //i = new BinaryFormatter();
            //Card d = (Card)i.Deserialize(s);
            //s.Close();

            //Console.WriteLine(d);
            Console.ReadKey();

            


        }
    }
}
