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

    // base part of class
    public static partial class Vocabulary
    {
        /* */
        private static Dictionary<string, Card> engRus = new Dictionary<string, Card>();
        /* */
        private static Dictionary<string, Card> storedVocabulary = new Dictionary<string, Card>();
        // key of current card
        private static string currentKey;

        public static bool isBinary { set; get; } = true;
        public static int NounsCount { private set; get; } = 0;
        public static int AdjectivesCount { private set; get; } = 0;
        public static int AVGLength { private set; get; } = 0;

        // add new card to dictionary
        public static void addCard(Card card)
        {
            if (!engRus.ContainsKey(card.Word) )
                engRus.Add(card.Word, card);                
        }

        // get current card
        public static Card getCurrentCard()
        {
            if (engRus.Count == 0)
                throw new VocabularyException("Empty vocabulary");

            if (currentKey == null)
                throw new VocabularyException("Key is null");

            return engRus[currentKey];
        }

        // get next card
        public static Card getNextCard()
        {
            if (engRus.Count == 0)
                throw new VocabularyException("Empty vocabulary");
            
            bool IsBreak = false;
            foreach (var item in engRus)
            {
                if (IsBreak || currentKey == null)
                {
                    currentKey = item.Key;
                    break;
                }
                
                if (currentKey == item.Key)
                    IsBreak = true;
            }

            return engRus[currentKey];
        }

        // get previous card
        public static Card getPreviousCard()
        {
            if (engRus.Count == 0)
                throw new VocabularyException("Empty vocabulary");

            string previousKey = currentKey;
            foreach (var item in engRus)
            {
                if (currentKey == null)
                {
                    previousKey = item.Key;
                    break;
                }

                if (currentKey == item.Key)
                    break;

                previousKey = item.Key;
            }

            currentKey = previousKey;
            return engRus[currentKey];
        }

        // remove current card
        public static void removeCard()
        {
            if (engRus.Count == 0)
                throw new VocabularyException("Empty vocabulary");

            if (engRus.Count == 1)
            {
                engRus.Remove(currentKey);
                currentKey = null;
                return;
            }

            string keyToRemove = currentKey;
            if (keyToRemove != getNextCard().Word)
            {
                engRus.Remove(keyToRemove);
                return;
            }

            keyToRemove = currentKey;
            if (keyToRemove != getPreviousCard().Word)
                engRus.Remove(keyToRemove);
        }

        // Save vocabulary
        public static void save()
        {
            if (engRus.Count == 0)
                throw new VocabularyException("Empty vocabulary");

            SaveFileDialog saveFileD = new SaveFileDialog();
            saveFileD.FileName = defaultFilename;

            if (saveFileD.ShowDialog() != DialogResult.OK)
                return;

            Stream stream = new FileStream(saveFileD.FileName, FileMode.Create);
            
            if (isBinary)
                serializeBin(stream, new List<Card>(engRus.Values));
            else
                serializeXml(stream, new List<Card>(engRus.Values));

            stream.Close();
        }

        // Save in binary format
        private static void serializeBin(Stream stream, List<Card> cards)
        {
            if (stream == null)
                return;

            try
            {
                IFormatter iBinFormatter = new BinaryFormatter();
                iBinFormatter.Serialize(stream, cards);
            }
            catch (SerializationException)
            {
            }
        }

        // Save in XML format
        private static void serializeXml(Stream stream, List<Card> cards)
        {
            if (stream == null)
                return;

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Card>));
                xmlSerializer.Serialize(stream, cards);
            }
            catch (InvalidOperationException)
            {
            }
        }

        // load vocabulary from file
        public static void open()
        {
            OpenFileDialog openFileD = new OpenFileDialog();
            openFileD.Filter = "binary files (*.bin)|*.bin|xml files (*.xml)|*.xml";
            openFileD.FilterIndex = 1;

            if (openFileD.ShowDialog() != DialogResult.OK)
                return;

            Stream stream = new FileStream(openFileD.FileName, FileMode.Open);

            if (openFileD.FilterIndex == 1)
                openBinary(stream);
            else
                openXML(stream);

            stream.Close();
        }

        // load vocabulary from binary file
        private static void openBinary(Stream stream)
        {
            if (stream == null)
                return;

            IFormatter iBinFormatter = new BinaryFormatter();
            try
            {
                List<Card> c = (List<Card>)iBinFormatter.Deserialize(stream);
                listToDictionary(c);
            }
            catch (SerializationException e)
            {
            }
        }

        // load vocabulary from xml file
        private static void openXML(Stream stream)
        {
            if (stream == null)
                return;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Card>));
            try
            {
                List<Card> c = (List<Card>)xmlSerializer.Deserialize(stream);
                listToDictionary(c);
            }
            catch (Exception)
            {
            }
        }

        private static void listToDictionary(List<Card> c)
        {

            if (c.Count == 0)
                return;

            engRus = c.ToDictionary(
                x => x.Word, x => new Card()
                {
                    Word = x.Word,
                    Translate = x.Translate,
                    partName = x.partName
                });
            
            currentKey = null;
        }

        private static string defaultExtension
        {
            get { return isBinary ? ".bin" : ".xml"; }
        }

        private static string defaultFilename
        {
            get { return "engrus_" + DateTime.Now.ToShortDateString() + defaultExtension; }
        }

        // Calculate statistic
        public static void staticticCals()
        {
            AVGLength = AdjectivesCount = NounsCount = 0;
            int lengthSum = 0;

            foreach (var item in engRus)
            {
                if (item.Value.partName.Equals(PartOfSpeech.NOUN))
                    NounsCount++;

                if (item.Value.partName.Equals(PartOfSpeech.ADJECTIVE))
                    AdjectivesCount++;

                lengthSum += item.Key.Length;
            }
            // exception if we click statistic when app is started
            AVGLength = lengthSum / engRus.Count;
        }

        public static int WordsCount
        {
            get{ return engRus.Count; }
        }
    }
}
