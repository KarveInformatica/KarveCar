using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace KarveControls.PhotoFrame
{
	/// <summary>
	/// Control that displays a photo slideshow using Ken Burns effects
	/// </summary>
    public partial class PhotoFrame : UserControl
    {
        #region Dependency Properties
        /// <summary>
		/// Gets or sets the interval at which the photos will be switched.
		/// </summary>
		public TimeSpan Interval
		{
			get { return (TimeSpan)GetValue(IntervalProperty); }
			set { SetValue(IntervalProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Interval.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IntervalProperty =
			DependencyProperty.Register("Interval", typeof(TimeSpan), typeof(PhotoFrame), new UIPropertyMetadata(TimeSpan.FromSeconds(5), new PropertyChangedCallback(HandleIntervalChanged)));

		/// <summary>
		/// Gets or sets the folder containing the images that should be displayed. If the value 
        /// isn't rooted (according to <see cref="System.IO.Path.IsPathRooted"/>), then it is assumed to be relative to the current working directory.
		/// </summary>
		/// <value>The image folder, either absolute path or relative to the current working directory.</value>
		public string ImageFolder
		{
			get { return (string)GetValue(ImageFolderProperty); }
			set { SetValue(ImageFolderProperty, value); }
		}

		// Using a DependencyProperty as the backing store for ImageFolder.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ImageFolderProperty =
			DependencyProperty.Register("ImageFolder", typeof(string), typeof(PhotoFrame), new UIPropertyMetadata(null, new PropertyChangedCallback(HandleImageFolderChanged)));

		static void HandleIntervalChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			var ctrl = (PhotoFrame)sender;
            ctrl.InitializeStoryboards();
            ctrl.m_switchImageTimer.Interval = ctrl.Interval;
            // Force a load of the next image to make sure the switch timer and storyboards have the same duration
            ctrl.LoadNextImage();
		}

		static void HandleImageFolderChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			var ctrl = (PhotoFrame)sender;
			ctrl.LoadFolder((string)e.NewValue);
			//if (e.OldValue == null)
				ctrl.LoadNextImage();
		}
        #endregion

        private List<ImageSource> m_images = new List<ImageSource>();
		private int m_currentSourceIndex;
		private int m_currentCtrlIndex;
		private static string[] ValidExtensions = new[] { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };
		private Image[] m_imageControls;
		private Storyboard m_moveStoryboard;
		private DispatcherTimer m_switchImageTimer;
        /// <summary>
        ///  PhotoFrame Control. Display a photo.
        /// </summary>
		public PhotoFrame()
		{
			InitializeComponent();
			InitializeStoryboards();
			m_imageControls = new [] { c_image1, c_image2 };

			m_switchImageTimer = new DispatcherTimer();
			m_switchImageTimer.Interval = Interval;
			m_switchImageTimer.Tick += (s, e) => LoadNextImage();
			if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) == false)
			{
				this.Loaded += (s, e) => m_switchImageTimer.Start();
				this.Unloaded += (s, e) => m_switchImageTimer.Stop();
			}
		}

        /// <summary>
        /// Initializes the storyboards and sets their duration
        /// </summary>
		private void InitializeStoryboards()
		{
			m_moveStoryboard = (Storyboard)FindResource("MoveStoryboard");
            m_moveStoryboard.Duration = new Duration(Interval.Add(TimeSpan.FromSeconds(1)));
			foreach (var child in m_moveStoryboard.Children)
			{
                child.Duration = m_moveStoryboard.Duration;
				Storyboard.SetTargetName(child, "");
			}
		}

        /// <summary>
        /// Changes image to the next in the queue. Image transition is faded
        /// </summary>
		private void LoadNextImage()
		{
			if (m_images.Count == 0)
				return;
			var oldCtrlIndex = m_currentCtrlIndex;
			m_currentCtrlIndex = (m_currentCtrlIndex + 1) % 2;
			m_currentSourceIndex = (m_currentSourceIndex + 1) % m_images.Count;

			Image oldImage = m_imageControls[oldCtrlIndex];
			Image newImage = m_imageControls[m_currentCtrlIndex];
			ImageSource newSource = m_images[m_currentSourceIndex];
			newImage.Source = newSource;
			if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) == false)
			{
				BeginFadeInImage(newImage);
				BeginFadeOutImage(oldImage);
                CreateAndStartKenBurnsEffect(newImage);
			} 
		}

        /// <summary>
        /// Starts the fade-in animation of the specified image control. 
        /// </summary>
        /// <param name="img">The image control that is faded in (and will be shown for the next 'Interval' time)</param>
		private void BeginFadeInImage(Image img)
		{            
			var fadeIn = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(2.0)));
			fadeIn.Freeze();
			img.BeginAnimation(UIElement.OpacityProperty, fadeIn);
		}

        /// <summary>
        /// Starts the fade-out animation of the specified image control
        /// </summary>
        /// <param name="img">The image control to fade out</param>
        private void BeginFadeOutImage(Image img)
        {
            var fadeOut = new DoubleAnimation(1.0, 0.0, new Duration(TimeSpan.FromSeconds(2.0)));
            fadeOut.Freeze();
            img.BeginAnimation(UIElement.OpacityProperty, fadeOut);
        }

        /// <summary>
        /// Creates the ken burns effect animations and applies them to the specified image control.
        /// </summary>
        /// <param name="img">The image control to apply the effect on.</param>
        private void CreateAndStartKenBurnsEffect(Image img)
        {
            var rand = new Random();
            double scaleFrom = rand.Next(1100, 1500) / 1000.0;
            double scaleTo = rand.Next(1100, 1500) / 1000.0;
            foreach (var child in m_moveStoryboard.Children)
            {
                var dblAnim = child as DoubleAnimation;
                if (dblAnim != null)
                {
                    // Randomize the translation to create a more live effect
                    if (dblAnim.Name == "moveX" || dblAnim.Name == "moveY")
                        dblAnim.To = rand.Next(-50, 50);
                    else if (dblAnim.Name == "scaleX" || dblAnim.Name == "scaleY")
                    {
                        dblAnim.To = scaleTo;
                        dblAnim.From = scaleFrom;
                    }
                    // make sure the child animations has the same duration as the storyboard (since it could have changed since last time)
                    dblAnim.Duration = m_moveStoryboard.Duration;
                }
                Storyboard.SetTarget(child, img);
            }
            m_moveStoryboard.Begin(img, true);
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

        /// <summary>
        /// Loads all images from the specified folder.
        /// </summary>
        /// <remarks>
        /// This method, even though it parallelizes itself to multiple background threads, still waits for all results to complete at the end. 
        /// It should really be called done asynchronously to avoid blocking the UI during this time. (With big enough files, this method can take several seconds)
        /// </remarks>
        private void LoadFolder(string folder)
		{
            c_errorText.Visibility = Visibility.Collapsed;
            var sw = System.Diagnostics.Stopwatch.StartNew();
			if (!System.IO.Path.IsPathRooted(folder))
				folder = System.IO.Path.Combine(Environment.CurrentDirectory, folder);
            if (!System.IO.Directory.Exists(folder))
            {
                c_errorText.Text = "The specified folder does not exist: " + Environment.NewLine + folder;
                c_errorText.Visibility = Visibility.Visible;
                return;
            }
			Random r = new Random();
            var sources = from file in new System.IO.DirectoryInfo(folder).GetFiles().AsParallel()
                          where ValidExtensions.Contains(file.Extension, StringComparer.InvariantCultureIgnoreCase)
                          orderby r.Next()
                          select CreateImageSource(file.FullName, true);
            m_images.Clear();
			m_images.AddRange(sources);
            sw.Stop();
            Console.WriteLine("Total time to load {0} images: {1}ms", m_images.Count, sw.ElapsedMilliseconds);
		}

	}
}
