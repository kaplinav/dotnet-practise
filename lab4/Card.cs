using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    [Serializable]
    public class Card
    {
        public string Word { get; set; }
        public string[] Translate { get; set; }
        public PartOfSpeech partName { get; set; }
    }
}
