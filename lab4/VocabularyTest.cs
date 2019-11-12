using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace lab4
{
    // Part of class Vocabulary for testing
    public static partial class Vocabulary
    {
        public static bool isOnlyAllTestingMode { private set; get; } = true;
        public static bool isAllMode { set; get; } = true;
        
        private static List<string> errorAnswers = new List<string>();

        public static void StartTest()
        {
            storedVocabulary = new Dictionary<string, Card>(engRus);
            engRus.Clear();

            if (isAllMode)
            {
                Random rand = new Random();
                engRus = storedVocabulary.OrderBy(x => rand.Next()).ToDictionary(item => item.Key, item => item.Value);
            }
            else
            {
                engRus = errorAnswers.ToDictionary(item => item, item => new Card() {
                    Word = item,
                    Translate = Array.Empty<string>(),
                    partName = PartOfSpeech.ADJECTIVE });
            }

            currentKey = null;
        }

        public static bool ToAnswer(string answer)
        {
            foreach (string translate in engRus[currentKey].Translate)
                if (translate.ToLower().Trim(' ') == answer.ToLower().Trim(' '))
                    return true;

            return false;
        }

        public static int EndTest(Dictionary<string, string> userAnswers)
        {
            engRus = storedVocabulary;
            errorAnswers.Clear();
            
            foreach (var item in userAnswers)
            {
                foreach (var translate in engRus[item.Key].Translate)
                {
                    // true is answer is right
                    if (!item.Value.Equals(translate))
                        errorAnswers.Add(item.Key);
                }
            }

            isOnlyAllTestingMode = errorAnswers.Count > 0 ? false : true;
            return errorAnswers.Count;
        }
    }
}
