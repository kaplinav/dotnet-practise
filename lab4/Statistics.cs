﻿using System;
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
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            labelCardCount.Text = Vocabulary.WordsCount.ToString();
            Vocabulary.staticticCals();
            labelNounsCount.Text = Vocabulary.NounsCount.ToString();
            labelAdjectivesCount.Text = Vocabulary.AdjectivesCount.ToString();
            labelAVGLength.Text = Vocabulary.AVGLength.ToString();
        }
    }
}
