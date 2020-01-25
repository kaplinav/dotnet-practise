using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTextFiles
{
    public class Result : INotifyPropertyChanged
    {
        private SortedList<int, int> _WordsFreq = new SortedList<int, int>();
        public int WordLength
        {
            set
            {
                if (_WordsFreq.ContainsKey(value))
                    _WordsFreq[value]++;
                else
                    _WordsFreq.Add(value, 1);
            }
        }

        public SortedList<int, int> WordsFreq
        {
            get
            {
                return _WordsFreq;
            }
        }

        private static Result Instance = new Result();

        public event PropertyChangedEventHandler PropertyChanged;

        private string _Time;
        public string Time
        {
            get
            {
                return _Time;
            }
            set
            {
                _Time = value + "ms";
                OnPropertyChanged("Time");
            }
        }

        private Result()
        {
        }

        public static Result GetInstance()
        {
            return Instance;
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}