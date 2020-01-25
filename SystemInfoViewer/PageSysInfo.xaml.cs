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
    /// Interaction logic for PageSysInfo.xaml
    /// </summary>
    public partial class PageSysInfo : Page
    {
        private SystemInfo si;

        public PageSysInfo()
        {
            InitializeComponent();
            si = new SystemInfo();
            SetLabelValues();
        }

        private void SetLabelValues()
        {
            LabelNumOfCPUs.Content = si.NumberOfCPUs;
            LabelPageSize.Content = si.PageSize;
            LabelCPUType.Content = si.CPUType;
            LabelMinAddress.Content = si.MinAppAddress;
            LabelMaxAddress.Content = si.MaxAppAddress;
            LabelActiveCPUMask.Content = si.ActiveCPUMask;
        }
    }
}
