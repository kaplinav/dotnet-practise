using System;
using System.Collections.Generic;
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

namespace SystemInfoViewer
{
    /// <summary>
    /// Interaction logic for PageFoldsInfo.xaml
    /// </summary>
    public partial class PageFoldsInfo : Page
    {
        private FoldsInfo fi;

        public PageFoldsInfo()
        {
            InitializeComponent();
            fi = new FoldsInfo();
            SetLabelValues();
        }

        private void SetLabelValues()
        {
            LabelWindowsDirectory.Content = fi.WindowsDirectory;
            LabelSystemDirectory.Content = fi.SystemDirectory;
            LabelSystemWindowsDirectory.Content = fi.SystemWindowsDirectory;
        }
    }
}
