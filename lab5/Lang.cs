using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace lab5
{
    public class Lang
    {
        public string Name { set; get; }
        public uint BirthYear { set; get; }
        public string Author { set; get; }
        public float Rating { set; get; }
        [XmlIgnore]
        public Bitmap Pic { set; get; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("Pic")]
        public byte[] LargeIconSerialized
        {
            // serialize
            get
            { 
                if (Pic == null) return null;
                using (MemoryStream ms = new MemoryStream())
                {
                    Pic.Save(ms, ImageFormat.Png); //Pic.Save(ms, ImageFormat.Bmp);
                    return ms.ToArray();
                }
            }

            // deserialize
            set
            { 
                if (value == null)
                {
                    Pic = null;
                }
                else
                {
                    using (MemoryStream ms = new MemoryStream(value))
                    {
                        Pic = new Bitmap(ms);
                    }
                }
            }
        }
    }
}
