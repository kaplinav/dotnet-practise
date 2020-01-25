using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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


using System.Windows.Forms.DataVisualization.Charting;

namespace ProcessTextFiles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Chart chart = new Chart();
        public string[] axisXData { set; get; }
        public int[] axisYData { set; get; }
        // Parallel or Serial run
        private bool isParallel;
        // work is running
        private bool IsWork;
        // Cancel work
        private bool IsCancel;

        private char[] delimiterChars = { ' ', ',', '.', '!', ':', '\t' };

        public MainWindow()
        {
            InitializeComponent();
            WFHost.Child = chart;
            //chart.Dock = System.Windows.Forms.DockStyle.Fill;
            // Все графики находятся в пределах области построения ChartArea, создадим ее
            chart.ChartAreas.Add(new ChartArea("Default"));

            // Добавим линию, и назначим ее в ранее созданную область "Default"
            chart.Series.Add(new Series("Series1"));
            chart.Series["Series1"].ChartArea = "Default";
            chart.Series["Series1"].ChartType = SeriesChartType.Column;

            //добавим данные линии
            axisXData = new string[] { "a", "b", "c" };
            axisYData = new int[] { 0, 0, 0 };
            chart.Series["Series1"].Points.DataBindXY(axisXData, axisYData);

            Result.GetInstance().Time = "0";
            DataContext = Result.GetInstance();

        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            if (IsWork)
            {
                IsCancel = true;
                return;
            }

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "text files | *.txt";
            openDialog.Multiselect = true;

            if (!openDialog.ShowDialog(this) == true)
                return;

            isParallel = (bool)rbParallel.IsChecked;
            IsCancel = false;
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            ProgressBarMain.IsIndeterminate = true;
            worker.RunWorkerAsync(openDialog.FileNames);
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Completed");
            //LabelTime.Content = e.Result.ToString();
            ProgressBarMain.IsIndeterminate = false;
            IsWork = false;

            chart.Series["Series1"].Points.DataBindXY(axisXData, axisYData);
            WFHost.Child = chart;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBarMain.Value = e.ProgressPercentage;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            IsWork = true;
            Result.GetInstance().WordsFreq.Clear();
            // Runtime timer start 
            var watch = System.Diagnostics.Stopwatch.StartNew();

            string[] files = (string[])e.Argument;
            if (isParallel)
            {
                Parallel.ForEach<string>(files, foo);
            }
            else
            {
                foreach (var item in files)
                    foo(item);
            }

            // Add values for chart
            int count = Result.GetInstance().WordsFreq.Count;
            axisXData = new string[count];
            axisYData = new int[count];
            int index = 0;

            foreach (var item in Result.GetInstance().WordsFreq)
            {
                axisXData[index] = item.Key.ToString();
                axisYData[index] = item.Value;
                index++;
            }

            //Runtime timer stopping
            watch.Stop();
            Result.GetInstance().Time = watch.ElapsedMilliseconds.ToString();
        }

        private void foo(string path)
        {
            string text = File.ReadAllText(path);
            string[] words = text.Split(delimiterChars);

            Dictionary<string, uint> wordsCount = new Dictionary<string, uint>();
            // Key - Length, Value - Frequency
            SortedList<int, int> wordsFreq = new SortedList<int, int>();

            for (int i = 0; i < words.Length; i++)
            {
                //int progressPercentage = words.Length / 100 * i;
                //(sender as BackgroundWorker).ReportProgress(progressPercentage);

                if (IsCancel)
                    break;

                if (words[i] != String.Empty)
                    Result.GetInstance().WordLength = words[i].Length;

                //Thread.Sleep(10);
            }
        }
    }
}
