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
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            radioBinary.Checked = Vocabulary.isBinary ? true : false;
            radioXml.Checked = Vocabulary.isBinary ? false : true;

            // 
            if (Vocabulary.isOnlyAllTestingMode)
                radioByErrors.Enabled = false;
            else
                radioByErrors.Enabled = true;

            radioAll.Checked = Vocabulary.isAllMode ? true : false;
            radioByErrors.Checked = Vocabulary.isAllMode ? false : true;
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            Vocabulary.isBinary = radioBinary.Checked ? true : false;
            Vocabulary.isAllMode = radioAll.Checked ? true : false;
        }
    }
}
