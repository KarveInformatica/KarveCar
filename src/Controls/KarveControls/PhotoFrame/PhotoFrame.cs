using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Prism.Commands;
using Syncfusion.Windows.Controls.Input;

namespace KarveControls.PhotoFrame
{

    /// <summary>
    /// Control that displays a photo
    /// </summary>
    /// 
    [TemplatePart(Name = "PART_ImageFile", Type = typeof(Image))]
    [TemplatePart(Name = "PART_LoadButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_ImageText", Type = typeof(SfTextBoxExt))]

    public class PhotoFrame : Control
    {

        private string currentFile;
        private MemoryStream _imageSource = new MemoryStream();

        private Image _imageFile = new Image();
        private Button _loadButton;
        private SfTextBoxExt _imageText;

        /// <summary>
        ///  Public class for press algorithms.
        /// </summary>
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

        public ICommand LoadCommand { set; get; }
        private enum ComponentStates
        {
            InitState,
            ImageModifiedState
        };

        /// <summary>
        ///  Private componentstates.
        /// </summary>
        private ComponentStates _componentState = ComponentStates.InitState;


        #region Dependency Properties

        /// <summary>
        /// ImageBinarySourceDependencyProperty.
        /// </summary>
        public static readonly DependencyProperty ImageBinarySourceDependencyProperty = DependencyProperty.Register("ImageBinarySource",
            typeof(MemoryStream),
            typeof(PhotoFrame),
            new PropertyMetadata(null, ImageBinarySourceCallback));

        /// <summary>
        /// ImageBinarySource dependency properties.
        /// </summary>
        public MemoryStream ImageBinarySource
        {
            get { return (MemoryStream)GetValue(ImageBinarySourceDependencyProperty); }
            set
            {
                SetValue(ImageBinarySourceDependencyProperty, value);
            }
        }
        private static void ImageBinarySourceCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // here we have the callback for the image binary source.
            PhotoFrame pf = d as PhotoFrame;
            pf.UpdateImageBinarySource(e);
        }

        /// <summary>
        ///  Update Image Binary source.
        /// </summary>
        /// <param name="d"></param>
        private void UpdateImageBinarySource(DependencyPropertyChangedEventArgs d)
        {
            // load an image from a memory stream.
            MemoryStream ms = d.NewValue as MemoryStream;
            if (ms != null)
            {
                _imageFile.Source = ByteToArrayImage(ms.ToArray());
            }
        }

        /// <summary>
        ///  This put just an image changed dependnecy property.
        /// </summary>
        public static readonly DependencyProperty ImageChangedDependencyProperty = DependencyProperty.Register("ImageChanged",
            typeof(ICommand), typeof(PhotoFrame), new PropertyMetadata(null, ChangedImageCallback));

        private static void ChangedImageCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PhotoFrame pf = d as PhotoFrame;
            if (pf != null)
            {
                pf.RegisterImageCallback(e);
            }
        }

        private void RegisterImageCallback(DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            this._imageFile.Loaded += ImageFile_Loaded;
        }

        private void ImageFile_Loaded(object sender, RoutedEventArgs e)
        {
            // here i load the image.
            if (_componentState == ComponentStates.ImageModifiedState)
            {
                // ok here i have to change the image.
                IDictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("ImageLabel", ImageLabel);
                dictionary.Add("ImageSource", _imageSource);
                if (ImageCommandChanged != null)
                {
                    ImageCommandChanged.Execute(dictionary);
                }

            }
        }

        /// <summary>
        ///  This is a readonly dependency property.
        /// </summary>
        public static readonly DependencyProperty IsReadOnlyDependencyProperty = DependencyProperty.Register("IsReadOnly",
            typeof(bool), typeof(PhotoFrame), new PropertyMetadata(false, OnReadOnlyCallback));
        /// <summary>
        ///  Label of the image.
        /// </summary>
        public static readonly DependencyProperty ImageLabelDependencyProperty = DependencyProperty.Register("ImageLabel",
                                                                                    typeof(string), typeof(PhotoFrame), new PropertyMetadata(string.Empty));
        /// <summary>
        ///  ImageLabel dependency property.
        /// </summary>
        public string ImageLabel
        {
            get { return (string)GetValue(ImageLabelDependencyProperty); }
            set { SetValue(ImageLabelDependencyProperty, value); }
        }
        /// <summary>
        ///  IsReadOnly stuff.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return (bool)GetValue(IsReadOnlyDependencyProperty);
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
                bool isReadOnly = (bool)value;
                _loadButton.IsEnabled = !isReadOnly;
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
                ICommand retValue = (ICommand)GetValue(ImageChangedDependencyProperty);
                return retValue;
            }
        }
        /// <summary>
        /// Photo images  
        /// </summary>
        public static readonly DependencyProperty ImageArrayDependencyProperty =
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
                return (List<ImageSource>)GetValue(ImageArrayDependencyProperty);
            }
        }
        /// <summary>
        /// PhotoName
        /// </summary>
        public string PhotoName
        {
            get { return "Photo"; }
        }

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
                _imageFile.Source = _sourceImages[0];

            }
        }

        #endregion

        private List<ImageSource> _images = new List<ImageSource>();


        /// <summary>
        /// Save the image in a byte for the image.
        /// </summary>
        /// <returns></returns>
        private bool SaveImage(out byte[] byteValue)
        {
            bool retValue = false;
            byteValue = new byte[1];
            BitmapEncoder encoder = new PngBitmapEncoder();
            MemoryStream ms = new MemoryStream();
            if (_images.Count > 0)
            {
                BitmapSource bitmapSource = _images[0] as BitmapSource;
                if (bitmapSource != null)
                {
                    encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

                    using (var stream = new MemoryStream())
                    {
                        encoder.Save(stream);
                        byteValue = stream.ToArray();
                        retValue = true;
                    }
                }
            }
            return retValue;
        }
        /// <summary>
        ///  Returns a byte to array image
        /// </summary>
        /// <param name="byteArrayIn">Input bytes in the image</param>
        /// <returns>Image crafted from the bytes or a null value</returns>

        private ImageSource ByteToArrayImage(byte[] byteArrayIn)
        {
            ImageSource img = null;
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


            return img;
        }

        /// <summary>
        ///  PhotoFrame Control. Display a photo.
        /// </summary>
        public PhotoFrame()
        {
            LoadCommand = new DelegateCommand(OnPhotoLoad);
        }
        static PhotoFrame()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PhotoFrame), new FrameworkPropertyMetadata(typeof(PhotoFrame)));

        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _imageFile = GetTemplateChild("PART_ImageFile") as Image;
            _loadButton = GetTemplateChild("PART_LoadButton") as Button;
            _imageText = GetTemplateChild("PART_ImageText") as SfTextBoxExt;
         
            if (_loadButton != null)
            {
                _loadButton.Click += ImageButton_Click;
            }
            if (_imageText != null)
            {
                _imageText.PreviewKeyDown += ImageText_PreviewKeyDown;
            }
          
        }

        private void ImageText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (File.Exists(_imageText.Text))
                {
                    ImageSource source = CreateImageSource(_imageText.Text, true);
                    if (source != null)
                    {
                        _imageFile.Source = source;
                        _sourceImages.Clear();
                        _sourceImages.Add(source);
                        ImageArray = _sourceImages;
                    }
                }
            }
        }

        private void LoadAutoComplete(string pathFile)
        {
            try
            {
                var path = Path.GetDirectoryName(pathFile);
                string[] filePaths = Directory.GetFiles(path);
                if (filePaths.Count() > 0)
                {
                    _imageText.AutoCompleteMode = AutoCompleteMode.Suggest;
                    _imageText.AutoCompleteSource = filePaths;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void OnPhotoLoad()
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            string openImageFile = "Abres File";
            dlg.Filter = openImageFile + "(*.bmp, *.jpg, *.png) | *.bmp; *.jpg;*.png";
            dlg.Title = "Nueva imagen";
            dlg.DefaultExt = ".png"; // Default file extension
            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                // at this point i shall check if the file is not empty
                if ((!string.IsNullOrEmpty(filename)) && (File.Exists(filename)))
                {
                    // ok in this case the file exists.
                    // we can load it.
                    currentFile = dlg.FileName;
                    _imageText.Text = currentFile;
                    LoadAutoComplete(_imageText.Text);
                    ImageSource source = CreateImageSource(dlg.FileName, true);
                    if (source != null)
                    {
                        _imageFile.Source = source;

                        _sourceImages.Clear();
                        _sourceImages.Add(source);
                        ImageArray = _sourceImages;
                    }
                }
                else
                {
                    MessageBox.Show("Fichero corrupto", "Error en la carga",MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string openImageFile = "Abres File";
            openFileDialog.Filter = openImageFile + "(*.bmp, *.jpg, *.png) | *.bmp; *.jpg;*.png";
            openFileDialog.Title = "Nueva imagen";
            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    if (File.Exists(openFileDialog.FileName))
                    {
                        currentFile = openFileDialog.FileName;
                        _imageText.Text = currentFile;
                        LoadAutoComplete(_imageText.Text);
                        
                        ImageSource source = CreateImageSource(openFileDialog.FileName, true);
                        if (source != null)
                        {
                            _sourceImages.Clear();
                            _sourceImages.Add(source);
                            _imageFile.Source = source;
                            ImageArray = _sourceImages;
                        }
                    }

                }
            }
            catch (Exception cException)
            {
                MessageBox.Show("The selected image is invalid: " + cException.Message);
                //throw new PhotoFrameException("Cannot open the file.", cException.InnerException);
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
            var src = new BitmapImage();

            if (forcePreLoad)
            {
                try
                {
                    src.BeginInit();
                    src.UriSource = new Uri(file, UriKind.Absolute);
                    src.CacheOption = BitmapCacheOption.OnLoad;
                    src.EndInit();
                    src.Freeze();
                } catch (NotSupportedException ex)
                {
                    MessageBox.Show("Not supported format");
                    return null;
                }
                return src;
            }
            else
            {
                src = new BitmapImage(new Uri(file, UriKind.Absolute));
                src.Freeze();
                return src;
            }
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
