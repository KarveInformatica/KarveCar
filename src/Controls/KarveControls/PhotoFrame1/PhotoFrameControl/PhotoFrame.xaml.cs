using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.Win32;
using Prism;
using Prism.Commands;
using KarveControls;

namespace KarveControls.PhotoFrame
{
  
    /// <summary>
    /// Control that displays a photo
    /// </summary>
    public partial class PhotoFrame : UserControl
    {
        public class PhotoFramePressEventArgs : RoutedEventArgs
        {
            /// <summary>
            /// Constant to access to the tableName in the parameters of the event
            /// </summary>
            /// <summary>
            /// Constant to access to the queries in the parameters of the event
            /// </summary>
            /// <summary>
            /// MagnifierPressEvents. Constructor 
            /// </summary>
            public PhotoFramePressEventArgs() : base()
            {
            }
            /// <summary>
            /// MagnifierPressEventsArgs. Event constructor 
            /// </summary>
            public PhotoFramePressEventArgs(RoutedEvent routedEvent) : base(routedEvent)
            {
            }
            /// <summary>
            ///  Parameters to be conveyed.
            /// </summary>
            public IDictionary<string, string> AssistParameters
            {
                get
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    return dictionary;
                }
            }

            /// <summary>
            /// Set or Get the query.
            /// </summary>
            public ImageSource AssistQuery { get; set; }
            /// <summary>
            /// Set or Get the tableName.
            /// </summary>
            public string TableName { get; set; }
        }


        private List<ImageSource> _sourceImages = new List<ImageSource>();
        
       

        #region Dependency Properties
        
        public static readonly  DependencyProperty ImageChangedDependencyProperty = DependencyProperty.Register("ImageChanging",
            typeof(ICommand), typeof(PhotoFrame));

        public static readonly DependencyProperty IsReadOnlyDependencyProperty = DependencyProperty.Register("IsReadOnly",
            typeof(bool), typeof(PhotoFrame), new PropertyMetadata(false, OnReadOnlyCallback));



        public bool IsReadOnly
        {
            get
            {
                return (bool) GetValue(IsReadOnlyDependencyProperty);
            }
            set
            {
                SetValue(IsReadOnlyDependencyProperty, value);
            }
        }
        private static void OnReadOnlyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PhotoFrame frame = d as PhotoFrame;
            if (frame != null)
            {
                frame.SetReadOnly(e.NewValue);
            }
        }

        private void SetReadOnly(object value)
        {
            if (value != null)
            {
                bool isReadOnly = (bool) value;
                this.ImageButton.IsEnabled = !isReadOnly;
            }
        }

        /// <summary>
        /// ImageCommandChanged.
        /// </summary>
        public ICommand ImageCommandChanged
        {
            set => SetValue(ImageChangedDependencyProperty, value);
            get
            {
                ICommand retValue = (ICommand) GetValue(ImageChangedDependencyProperty);
                return retValue;
            }
        }
        /// <summary>
        /// Photo images  
        /// </summary>
        public static readonly DependencyProperty  ImageArrayDependencyProperty = 
            DependencyProperty.Register("ImageArray", typeof(List<ImageSource>), 
                typeof(PhotoFrame), 
                new UIPropertyMetadata(null, new PropertyChangedCallback(HandleImageArray)));
        /// <summary>
        ///  IEnumerable byte array.
        /// </summary>
        public List<ImageSource> ImageArray
        {
            set
            {
                SetValue(ImageArrayDependencyProperty, value);
            }
            get
            {
                return (List<ImageSource>) GetValue(ImageArrayDependencyProperty);
            }
        }

        public string PhotoName
        {
            get { return PhotoFrameControl.Properties.Resources.PhotoFrame_PhotoName_Foto; }
        }
        public DelegateCommand<object> ImageChanging { get; }

        private static void HandleImageArray(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PhotoFrame photoFrame = d as PhotoFrame;
            if (photoFrame != null)
            {
                photoFrame.LoadImageArray(e);
            }
        }

        private void LoadImageArray(DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            _sourceImages = dependencyPropertyChangedEventArgs.NewValue as List<ImageSource>;
            if (_sourceImages != null)
            {
                this.ImageFile.Source = _sourceImages[0];
                this.ImageSlider.Maximum = _sourceImages.Count -1;
            }
        }
        
        #endregion

        private List<ImageSource> _images = new List<ImageSource>();

        /// <summary>
        ///  Returns a byte to array image
        /// </summary>
        /// <param name="byteArrayIn">Input bytes in the image</param>
        /// <returns>Image crafted from the bytes or a null value</returns>
       
        private ImageSource ByteToArrayImage(byte[] byteArrayIn)
        {
            ImageSource img = null;
            try
            {
                using (var ms = new MemoryStream(byteArrayIn))
                {

                    System.Drawing.Image bitmap = System.Drawing.Image.FromStream(ms);
                    using (var internalMemoryStream = new MemoryStream())
                    {
                        bitmap.Save(internalMemoryStream, System.Drawing.Imaging.ImageFormat.Png);
                        internalMemoryStream.Position = 0;
                        var bi = new BitmapImage();
                        bi.BeginInit();
                        bi.CacheOption = BitmapCacheOption.OnLoad;
                        bi.StreamSource = internalMemoryStream;
                        bi.EndInit();
                        img = bi;
                    }
                }
            }
            catch (Exception e)
            {
                return img;
            }
            return img;
        }
       
        /// <summary>
        ///  PhotoFrame Control. Display a photo.
        /// </summary>
        public PhotoFrame()
		{
			InitializeComponent();
		    this.GridLayout.DataContext = this;
		    this.ImageSlider.Maximum = 1;
            this.ImageSlider.ValueChanged += ImageSlider_ValueChanged;
		    this.ImageFile.Width = this.GridLayout.Width - 10;
            this.ImageButton.Click += ImageButton_Click;
            ImageChanging = new DelegateCommand<object>(OnChangingImage);  
		}
        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string openImageFile = PhotoFrameControl.Properties.Resources.PhotoFrame_ImageButton_Click_ImageFiles;
            openFileDialog.Filter = openImageFile+"(*.bmp, *.jpg, *.png) | *.bmp; *.jpg;*.png"; 
            openFileDialog.Title = PhotoFrameControl.Properties.Resources.PhotoFrame_ImageButton_Click_AñadeUnaNuevaImagen;
            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    if (File.Exists(openFileDialog.FileName))
                    {
                        ImageSource source = CreateImageSource(openFileDialog.FileName, true);
                        _sourceImages.Add(source);
                       
                        ImageArray = _sourceImages;
                        ImageSlider.Maximum = _sourceImages.Count - 1;
                    }

                }
            }
            catch (Exception cException)
            {
                MessageBox.Show(PhotoFrameControl.Properties.Resources.PhotoFrame_ImageButton_Click_NoSePuedeAbrirElFichero + openFileDialog.FileName+ PhotoFrameControl.Properties.Resources.PhotoFrame_ImageButton_Click_Motivacion+ cException.Message);
            }
            
        }
        /// <summary>
        /// Creates an ImageSource object from a file on disk.
        /// </summary>
        /// <param name="file">The full path to the file that should be loaded.</param>
        /// <param name="forcePreLoad">if set to <c>true</c> the image file will be decoded and fully loaded when created.</param>
        /// <returns>A frozen image source object representing the loaded image.</returns>
        private ImageSource CreateImageSource(string file, bool forcePreLoad)
        {
            if (forcePreLoad)
            {
                var src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(file, UriKind.Absolute);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                src.Freeze();
                return src;
            }
            else
            {
                var src = new BitmapImage(new Uri(file, UriKind.Absolute));
                src.Freeze();
                return src;
            }
        }

        private void ImageSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var value = e.NewValue;
            int currentIdx = Convert.ToInt32(value);
            this.ImageFile.Source = _sourceImages[currentIdx];
           
        }

        /// <summary>
        ///  This execute the command provider from the view model.
        /// </summary>
        /// <param name="objectParam"></param>
        private void OnChangingImage(object objectParam)
        {
            if (ImageCommandChanged != null)
            {
                ImageCommandChanged.Execute(objectParam);
            }
        }
    }
}
