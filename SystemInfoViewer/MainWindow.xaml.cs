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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] Items = { "Variables", "System", "Processor", "Folders" };
        private SystemInfo si = new SystemInfo();
        private PageVarsInfo PageVarsInfo = new PageVarsInfo();
        private PageSysInfo pageSysInfo = new PageSysInfo();
        private PageCPUInfo pageCPUInfo = new PageCPUInfo();
        private PageFoldsInfo PageFoldsInfo = new PageFoldsInfo();
        
        public MainWindow()
        {
            InitializeComponent();
            ComboBoxMain.ItemsSource = Items;
            ComboBoxMain.SelectedIndex = 1;
        }

        private void ComboBoxMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // call needed function 
            switch (Items[ComboBoxMain.SelectedIndex])
            {
                case "Variables":
                    FrameMain.Content = PageVarsInfo;
                    break;
                case "System":
                    FrameMain.Content = pageSysInfo; 
                    break;
                case "Processor":
                    FrameMain.Content = pageCPUInfo;
                    break;
                case "Folders":
                    FrameMain.Content = PageFoldsInfo;
                    break;
                default:
                    break;
            }
        }
    }
}