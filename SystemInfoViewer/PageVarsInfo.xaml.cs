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
    /// Interaction logic for PageVarsInfo.xaml
    /// </summary>
    public partial class PageVarsInfo : Page
    {
        private VarsInfo vi;

        public PageVarsInfo()
        {
            InitializeComponent();
            vi = new VarsInfo();
            SetValues();
        }

        private void SetValues()
        {
            TextBlockPath.Text = vi.PATH;
            LabelTmp.Content = vi.TMP;
            LabelTemp.Content = vi.TEMP;
            LabelOS.Content = vi.OS;
            LabelUsername.Content = vi.USERNAME;
        }
    }
}
