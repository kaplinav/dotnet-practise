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
    /// Interaction logic for PageCPUInfo.xaml
    /// </summary>
    public partial class PageCPUInfo : Page
    {
        private CPUInfo ci = new CPUInfo();

        public PageCPUInfo()
        {
            InitializeComponent();
            SetValues();
        }

        private void SetValues()
        {
            CheckFloatingPointPrecisionErrata.IsChecked = ci.FloatingPointPrecisionErrata;
            CheckFloatingPointEmulated.IsChecked = ci.FloatingPointEmulated;
            CheckCompareExchangeDouble.IsChecked = ci.CompareExchangeDouble;
            CheckInstructionsMMXAvailable.IsChecked = ci.InstructionsMMXAvailable;
            CheckInstructionsXMMIAvailable.IsChecked = ci.InstructionsXMMIAvailable;
            CheckIs3DNow.IsChecked = ci.Instruction3DNowAvailable;
            CheckInstructionRDTSCAvailable.IsChecked = ci.InstructionRDTSCAvailable;
            CheckPAEEnabled.IsChecked = ci.PAEEnabled;
            CheckInstructionsXMMI64Available.IsChecked = ci.InstructionsXMMI64Available;
            CheckNXEnabled.IsChecked = ci.NXEnabled;
            CheckInstructionsSSE3Available.IsChecked = ci.InstructionsSSE3Available;
            CheckCompareExchange128.IsChecked = ci.CompareExchange128;
            CheckCompare64Exchange128.IsChecked = ci.Compare64Exchange128;
            CheckChannelsEnabled.IsChecked = ci.ChannelsEnabled;
        }
    }
}