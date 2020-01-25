using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WebImageViewer
{
    public class Images : INotifyPropertyChanged
    {
        private static Images imagesInstance = new Images();
        private static List<ImageSource> images = new List<ImageSource>();
        private static int currentItem = 0;
        private ImageSource _ImageSrc;

        public event PropertyChangedEventHandler PropertyChanged;
        public ImageSource ImageSrc
        {
            get
            {
                return _ImageSrc;
            }
            set
            {
                _ImageSrc = value;
                OnPropertyChanged("ImageSrc");
            }
        }

        private Images()
        {
        }

        private void SetItem()
        {
            this.ImageSrc = images[currentItem];
        }

        public void Add(ImageSource imgSrc)
        {
            images.Add(imgSrc);

            if (this.ImageSrc == null)
            {
                currentItem = 1;
                SetItem();
            }
                
        }

        public void Next()
        {
            if (currentItem + 1 >= images.Count)
                currentItem = 1;
            else
                currentItem++;

            SetItem();
        }

        public void Prev()
        {
            if (currentItem - 1 <= 0)
                currentItem = images.Count - 1;
            else
                currentItem--;

            SetItem();
        }

        public static Images GetInstance()
        {
            return imagesInstance;
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
