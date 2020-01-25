using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        private BindingSource bs = new BindingSource();
        //private List<Lang> langs = new List<Lang>();

        public Form1()
        {
            InitializeComponent();
            InitializeBinding();
            SetupComponents();
        }

        private void InitializeBinding()
        {
            bs.DataSource = new List<Lang>();
            pictureBox1.DataBindings.Add("Image", bs, "Pic", true);
            dataGridView1.DataSource = bs;
            bindingNavigator1.BindingSource = bs;
            propertyGrid1.DataBindings.Add("SelectedObject", bs, "");
            chart1.DataSource = bs;
            bs.CurrentChanged += (o, e) => chart1.DataBind();
            toolStripComboBox1.ComboBox.Items.AddRange(dataGridView1.Columns.Cast<DataGridViewColumn>().Select(x => x.Name).ToArray());
            toolStripComboBox1.SelectedIndex = 0;
        }

        private void SetupComponents()
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            
            dataGridView1.Columns["Pic"].Visible = false;

            chart1.Series[0].XValueMember = "Name";
            chart1.Series[0].YValueMembers = "Rating";
            chart1.Legends.Clear();
            chart1.Titles.Add("TIOBE Index");
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            bs.Clear();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            XmlWorker.Save((List<Lang>)bs.DataSource);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            XmlWorker.Open();
            if (XmlWorker.List != null)
            {
                if (XmlWorker.List.Count > 0)
                    bs.DataSource = XmlWorker.List;
            }
        }

        private void findToolStripButton_Click(object sender, EventArgs e)
        {
            if (findToolStripTextBox.Text == String.Empty)
                // please type your search request 
                return;

            if (bs.Count == 0)
                // source list is empty
                return;

            var list = bs.List.OfType<Lang>().ToList();

            try
            {
                object findedObject = null;
                switch (toolStripComboBox1.SelectedIndex)
                {
                    case 0: // Name
                        findedObject = bs.List.OfType<Lang>().ToList().Find(
                            x => x.Name.Equals(findToolStripTextBox.Text.Trim(' ')));
                        break;
                    case 1: // Birth year
                        int intInput = 0;
                        if (int.TryParse(findToolStripTextBox.Text.Trim(' '), out intInput))
                        {
                            findedObject = bs.List.OfType<Lang>().ToList().Find(
                            x => x.BirthYear == intInput);
                        }
                        break;
                    case 2: // Author
                        findedObject = bs.List.OfType<Lang>().ToList().Find(
                            x => x.Author.Equals(findToolStripTextBox.Text.Trim(' ')));
                        break;
                    case 3:
                        float floatInput = 0;
                        if (float.TryParse(findToolStripTextBox.Text.Trim(' '), out floatInput))
                        {
                            findedObject = bs.List.OfType<Lang>().ToList().Find(
                            x => x.Rating == floatInput);
                        }
                        break;
                    default:
                        break;
                }
                int position = bs.IndexOf(findedObject);

                if (position > -1)
                    bs.Position = position;
            }
            catch (NullReferenceException)
            {
            }
            
        }

        public static string ColumnToString(DataGridViewColumn column)
        {
            return column.Name;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // if column "Name" or "Author" trim spaces
            if (e.ColumnIndex == 0 || e.ColumnIndex == 2)
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim(' ');
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null)
                PopUp.Show(this, e.Exception.Message);

            e.Cancel = true;
        }
    }
}
