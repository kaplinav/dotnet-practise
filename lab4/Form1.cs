using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {
        /* Accepted  words */
        private Dictionary<string, string> acceptedWords = new Dictionary<string, string>();

        private void ActivatedHandler(object sender, EventArgs e)
        {
            // Get actual count of words
            this.statusLabelCount.Text = "Count: " + Vocabulary.WordsCount;
        }

        // close app
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // open vocabulary from file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open();
        }

        // save vocabulary to file
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Vocabulary.save();
            }
            catch (VocabularyException)
            {
                PopUp.Show(this, "Vocabulary is empty. Nothing to save");
            }
            
        }

        // Change mode: view <-> testing
        private void testingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeMode();
        }

        // add new card
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addCard();
        }

        // remove this card
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeCard();
        }

        // to next card
        private void buttonNext_Click(object sender, EventArgs e)
        {
            getNextCard();

            if (isTesting)
                ProcessTestControls();
        }

        // to previous card
        private void buttonPrev_Click(object sender, EventArgs e)
        {
            getPrevCard();

            if (isTesting)
                ProcessTestControls();
        }

        // to form "Options"
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formOptions.ShowDialog(this);
        }

        // show "Statistic" form
        private void statisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formStat.ShowDialog(this);
        }

        // button "Answer" handler (for testing mode)
        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            /* add word if user gave answer */
            acceptedWords.Add(labelWord.Text, textAnswer.Text.ToLower().Trim(' '));
            /* disable if user answered */
            ProcessTestControls();
        }

        private void ProcessTestControls()
        {
            /* disable if user answered */
            if (acceptedWords.ContainsKey(labelWord.Text))
            {
                textAnswer.Text = acceptedWords[labelWord.Text];
                textAnswer.Enabled = false;
                buttonAnswer.Enabled = false;
            }
            else
            {
                textAnswer.Text = String.Empty;
                textAnswer.Enabled = true;
                buttonAnswer.Enabled = true;
            }
        }
    }
}
