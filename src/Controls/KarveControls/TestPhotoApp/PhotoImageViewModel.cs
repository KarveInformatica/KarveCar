using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Prism.Mvvm;

namespace TestPhotoApp
{
   /// <summary>
   ///  View model of the image array.
   /// </summary>
    public class PhotoImageViewModel: BindableBase
    {
        /// <summary>
        ///  Array data of a photo image.
        /// </summary>
        private List<ImageSource> _imageArray = new List<ImageSource>();

        /// <summary>
        /// Image array
        /// </summary>
        public List<ImageSource> Image
        {
            set { _imageArray =   value;
                RaisePropertyChanged();
            }
            get { return _imageArray; }
        }

        public PhotoImageViewModel()
        {
            try
            {
                using (FileStream file = File.OpenRead(@"C:\Users\Usuario\Documents\KarveSnapshots\KarveLast\KarveCar\src\Controls\KarveControls\TestPhotoApp\Images\Ferrari.png"))
                {
                    int len = Convert.ToInt32(file.Length);
                    byte[] fileBytes = new byte[file.Length];
                    file.Read(fileBytes, 0, len);
                    using (MemoryStream myMemoryStream= new MemoryStream(fileBytes))
                    {
                        BitmapImage myBitmapImage = new BitmapImage();
                        myBitmapImage.BeginInit();
                        // this important because i close and dispose the stream. It forces a copy.
                        myBitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        myBitmapImage.StreamSource = myMemoryStream;
                        myBitmapImage.EndInit();
                        _imageArray.Add(myBitmapImage);
                        Image = _imageArray;
                    }
                    
                }
                using (FileStream file = File.OpenRead(@"C:\Users\Usuario\Documents\KarveSnapshots\KarveLast\KarveCar\src\Controls\KarveControls\TestPhotoApp\Images\Ferrari2.png"))
                {
                    int len = Convert.ToInt32(file.Length);
                    byte[] fileBytes = new byte[file.Length];
                    file.Read(fileBytes, 0, len);
                    using (MemoryStream myMemoryStream = new MemoryStream(fileBytes))
                    {
                        BitmapImage myBitmapImage = new BitmapImage();
                        myBitmapImage.BeginInit();
                        // this important because i close and dispose the stream. It forces a copy.
                        myBitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        myBitmapImage.StreamSource = myMemoryStream;
                        myBitmapImage.EndInit();
                        _imageArray.Add(myBitmapImage);
                        Image = _imageArray;
                    }

                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error message" + e.Message);
            }
        }


    }
}
