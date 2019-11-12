using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace lab4
{

    public partial class Form1 : Form
    {
        private const string TITLE_VIEW = "Eng.Rus - View";
        private const string TITLE_TESTING = "Eng.Rus - Testing";
        
        // form for adding words to vocabulary
        FormAdd formAdd = new FormAdd();
        // form for tune 
        Options formOptions = new Options();
        // form for show statuistic
        Statistics formStat = new Statistics();
        // FALSE for view mode, TRUE for testing
        private bool isTesting = false;
        // part of speech 
        private Label labelPartOfSpeech = new Label();
        // english word 
        private Label labelWord = new Label();
        // multiline text box with russian translate
        private TextBox textTranslate = new TextBox();
        // question ( for test mode )
        private Label labelQuestion = new Label();
        // user answer ( for test mode )
        private TextBox textAnswer = new TextBox();
        // Button "answer"
        Button buttonAnswer = new Button();
        // 
        TableLayoutPanel table = new TableLayoutPanel();

        public Form1()
        {
            InitializeComponent();
            this.Text = TITLE_VIEW;
            Icon = lab4.Properties.Resources.vimeo;
            // Table panel for adding controls
            InitTablePanel();
            groupCard.Controls.Add(table);
            //view - components
            InitViewComponents();
            //testing - components
            InitTestingComponents();
            // start app in view mode
            setViewMode();

            // set action handlers
            this.statusLabelCount.Text += Vocabulary.WordsCount;
            this.Activated += new EventHandler(ActivatedHandler);
            buttonAnswer.Click += new EventHandler(buttonAnswer_Click);
        }

        // Table Panel
        private void InitTablePanel()
        {
            table.ColumnCount = 2;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            table.RowCount = 3;
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
        }

        //view - components
        private void InitViewComponents()
        {
            // part of speech
            labelPartOfSpeech.Font = new Font("Microsoft Sans Serif", 9);
            labelPartOfSpeech.Dock = DockStyle.Bottom;

            // english word
            labelWord.AutoSize = true;
            labelWord.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            labelWord.Dock = DockStyle.Fill;

            // multiline text box with russian translate
            textTranslate.ReadOnly = true;
            textTranslate.Dock = DockStyle.Fill;
            textTranslate.Multiline = true;
            textTranslate.BorderStyle = BorderStyle.None;
            textTranslate.Font = new Font("Microsoft Sans Serif", 10);
        }

        //testing - components
        private void InitTestingComponents()
        {
            // text box with answer
            textAnswer.Dock = DockStyle.Fill;
            textAnswer.BorderStyle = BorderStyle.FixedSingle;
            textAnswer.Font = new Font("Microsoft Sans Serif", 12);

            // Button "answer"
            buttonAnswer.Text = "Answer";
            buttonAnswer.TextAlign = ContentAlignment.MiddleCenter;
            buttonAnswer.Size = new Size(80, 25);
        }

            // Clear the card
            private void Clear()
        {
            labelWord.Text = String.Empty;
            textTranslate.Lines = Array.Empty<String>();
            labelPartOfSpeech.Text = String.Empty;
        }

        /* Change mode: view <-> testing */
        private void ChangeMode()
        {
            if (isTesting)
            {
                int errors = Vocabulary.EndTest(acceptedWords);
                PopUp.Show(this, 
                    "All: " + acceptedWords.Count + ". " +
                    "Right: " + (acceptedWords.Count - errors) + ". " +
                    "Wrong: " + errors);
                setViewMode();
                this.textAnswer.Enabled = true;
                this.textAnswer.Text = String.Empty;
                this.buttonAnswer.Enabled = true;
            }
            else
            {
                if (Vocabulary.WordsCount == 0)
                {
                    PopUp.Show(this, "Empty vocabulary");
                    return;
                }

                setTestMode();
                Vocabulary.StartTest();
                
                this.labelWord.Text = String.Empty;
                setIfEmpty();
            }
        }

        // load from file
        private void open()
        {
            Vocabulary.open();
            setRemoveItemStatus();
            setSaveItemStatus();

            if (Vocabulary.WordsCount > 0)
                Clear();

            setIfEmpty();
            // Get actual count of words
            this.statusLabelCount.Text = "Count: " + Vocabulary.WordsCount;
        }

        // add new card to vocabulary
        private void addCard()
        {
            formAdd.ShowDialog(this);
            setRemoveItemStatus();
            setSaveItemStatus();
            setIfEmpty();
        }

        // set card after loading or adding card
        private void setIfEmpty()
        {
            if (labelWord.Text == String.Empty)
            {
                if (Vocabulary.WordsCount > 0)
                    getNextCard();
            }
        }

        // remove current card from vocabulary
        private void removeCard()
        {
            if (Vocabulary.WordsCount == 0)
            {
                PopUp.Show(this, "Empty vocabulary");
                return;
            }

            // answer
            if (!PopUp.ShowYesNo(this, "Remove this card?"))
                return;

            // remove current card
            Vocabulary.removeCard();
            // disable the remove menu item if vocabulary is empty
            setRemoveItemStatus();
            // disable the sava menu item if vocabulary is empty
            setSaveItemStatus();
            // Get actual count of words
            this.statusLabelCount.Text = "Count: " + Vocabulary.WordsCount;

            try
            {
                Card card = Vocabulary.getCurrentCard();
                labelWord.Text = card.Word;
                textTranslate.Lines = card.Translate;
                labelPartOfSpeech.Text = card.partName.ToString();
            }
            catch (VocabularyException)
            {
                labelWord.Text = String.Empty;
                textTranslate.Clear();
                labelPartOfSpeech.Text = String.Empty;
            }
        }

        private void getNextCard()
        {
            try
            {
                Card card = Vocabulary.getNextCard();
                labelWord.Text = card.Word;
                labelPartOfSpeech.Text = card.partName.ToString().ToLower();
                textTranslate.Lines = card.Translate;
            }
            catch (VocabularyException ex)
            {
                PopUp.Show(this, ex.Message);
                return;
            }
        }

        private void getPrevCard()
        {
            try
            {
                Card card = Vocabulary.getPreviousCard();
                labelWord.Text = card.Word;
                labelPartOfSpeech.Text = card.partName.ToString().ToLower();
                textTranslate.Lines = card.Translate;
            }
            catch (VocabularyException ex)
            {
                PopUp.Show(this, ex.Message);
                return;
            }
        }

        private void setTestMode()
        {
            isTesting = true;
            acceptedWords.Clear();
            this.testingToolStripMenuItem.Text = "End test";
            this.Text = TITLE_TESTING;
            addToolStripMenuItem.Enabled = false;
            // disable or enable open, save, remove menu items
            setItemsStatus();
            // add controls to table panel
            table.Controls.Clear();
            table.Controls.Add(labelWord, 0, 0);
            table.Controls.Add(textAnswer, 0, 1);
            table.Controls.Add(buttonAnswer, 0, 2);
            table.Dock = DockStyle.Fill;
        }

        private void setViewMode()
        {
            isTesting = false;
            this.testingToolStripMenuItem.Text = "Testing";
            this.Text = TITLE_VIEW;
            addToolStripMenuItem.Enabled = true;
            // disable or enable open, save, remove menu items
            setItemsStatus();
            // add controls to table panel
            table.Controls.Clear();
            table.Controls.Add(labelPartOfSpeech, 0, 0);
            table.Controls.Add(labelWord, 0, 1);
            table.Controls.Add(textTranslate, 0, 2);
            table.Dock = DockStyle.Fill;
        }

        /* change menu item status when mode switch */
        private void setItemsStatus()
        {
            setOpenItemStatus();
            setRemoveItemStatus();
            setSaveItemStatus();
            setOptionItemStatus();
            setStatisticItemStatus();
        }

        private void setOpenItemStatus()
        {
            openToolStripMenuItem.Enabled = isTesting ? false : true;
        }

        private void setRemoveItemStatus()
        {
            removeToolStripMenuItem.Enabled = isTesting ? false : ((Vocabulary.WordsCount > 0) ? true : false) ;
        }

        private void setSaveItemStatus()
        {
            saveToolStripMenuItem.Enabled = isTesting ? false : ((Vocabulary.WordsCount > 0) ? true : false);
        }

        private void setOptionItemStatus()
        {
            optionsToolStripMenuItem.Enabled = isTesting ? false : true;
        }

        private void setStatisticItemStatus()
        {
            statisticToolStripMenuItem.Enabled = isTesting ? false : true;
        }
    }
}
