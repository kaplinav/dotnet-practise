using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyConsole
{
    public enum PartOfSpeech
    {
        NOUN,
        PRONOUN,
        ADJECTIVE,
        VERB,
        ADVERB,
        PREPOSITION,
        CONJUNCTION,
        INTERJECTION
    }

    [Serializable]
    public class Card
    {
        public string Word { get; set; }
        public string[] Translate { get; set; }
        public PartOfSpeech partName { get; set; }

        public override string ToString()
        {
            return Word + " " + String.Concat(Translate) + " " + partName;
        }

    }
}
