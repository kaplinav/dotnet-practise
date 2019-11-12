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
    public partial class FormAdd : Form
    {
        private const string EMPTY_FIELDS = "One or more fields is not filled";

        public FormAdd()
        {
            InitializeComponent();
            // clear input fields after form is closed
            this.FormClosed += new FormClosedEventHandler(FormClosedHandler);
        }

        // clear input fields after form is closed
        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            this.textWord.Text = String.Empty;
            this.textTranslate.Lines = new string[0];
            this.comboPartsOfSpeech.SelectedItem = null;
            this.comboPartsOfSpeech.Text = "Select part of speech";
        }

        // fields need to be filled before add to dictionary
        private bool inputFieldsIsEmpty()
        {
            if (this.textWord.Text == String.Empty)  
                return true;
            else if (this.textTranslate.Lines.Length == 0)
                return true;
            else if (this.comboPartsOfSpeech.SelectedItem == null)
                return true;
            return false;
        }

        // add new card to dictionary
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (inputFieldsIsEmpty())
            {
                PopUp.Show(this, EMPTY_FIELDS);
                return;
            }

            Vocabulary.addCard(new Card() {
                Word = this.textWord.Text.ToUpper(),
                Translate = this.textTranslate.Lines.Take(this.textTranslate.Lines.Length).Select(x => x.ToLower().Trim(' ')).ToArray(),
                partName = (PartOfSpeech)comboPartsOfSpeech.SelectedIndex } );
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
