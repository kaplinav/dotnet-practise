using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace lab5
{
    public static class XmlWorker
    {
        static Stream stream;
        static XmlSerializer serializer;
        static FileDialog fileDialog;

        public static List<Lang> List { get; private set; }

        public static void Open()
        {
            fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Environment.CurrentDirectory;
            fileDialog.Filter = "xml|*.xml";

            if (DialogResult.OK != fileDialog.ShowDialog())
                return;

            using (stream = new FileStream(fileDialog.FileName, FileMode.Open))
            {
                serializer = new XmlSerializer(typeof(List<Lang>));
                List = (List<Lang>)serializer.Deserialize(stream);
            }
        }

        public static void Save(List<Lang> list)
        {            
            fileDialog = new SaveFileDialog();
            fileDialog.DefaultExt = "xml";
            fileDialog.FileName = "pl_" + System.DateTime.Now.ToShortDateString();
            fileDialog.InitialDirectory = Environment.CurrentDirectory;

            if (DialogResult.OK != fileDialog.ShowDialog())
                return;

            using (stream = new FileStream(fileDialog.FileName, FileMode.Create))
            {
                serializer = new XmlSerializer(typeof(List<Lang>));
                serializer.Serialize(stream, list);
            }
        }   
    }
}