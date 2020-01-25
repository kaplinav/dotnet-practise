using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebImageViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Images im;
        public MainWindow()
        {
            InitializeComponent();
            im = Images.GetInstance();
            DataContext = im;

        }
        
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;

            if (TextSearchRequest.Text == null || TextSearchRequest.Text == String.Empty)
            {
                return;
            }

            Client.Get(TextSearchRequest.Text);
        }

        private void ButtonPrev_Click(object sender, RoutedEventArgs e)
        {
            Images.GetInstance().Prev();
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            Images.GetInstance().Next();
        }
    }
}