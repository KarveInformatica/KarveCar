using KarveCommon;
using System.Windows;
using System.Windows.Controls;

    namespace KarveControls
    {
        /// <summary>
        /// DataField Control definitions. A data field control is simply a couple of label and textbox.
        /// It has associated a Command to notify changes when it loses its focus.
        /// </summary>
       
        [TemplatePart(Name = "PART_LabelField", Type = typeof(TextBlock))]
        [TemplatePart(Name = "PART_Button", Type = typeof(Button))]
        [TemplatePart(Name = "PART_Image", Type = typeof(Image))]

        public class ButtonImage : Button
        {
            /// <summary>
            ///  default ctor.
            /// </summary>
            public ButtonImage() : base()
            {
                Width = 60;
                Height = 60;
            }
            static ButtonImage()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(ButtonImage), new FrameworkPropertyMetadata(typeof(ButtonImage)));
             
            }

            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
            }

        
            public static readonly DependencyProperty LabelProperty =
                DependencyProperty.Register("LabelText", typeof(string), typeof(ButtonImage), new PropertyMetadata(string.Empty));

        /// <summary>
        ///  This returns a data object.
        /// </summary>
        public string LabelText
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
        /// <summary>
        ///  This returns a data object.
        /// </summary>
        public string Icon
            {
                get { return (string)GetValue(IconProperty); }
                set { SetValue(IconProperty, value); }
            }

            public static readonly DependencyProperty IconProperty =
               DependencyProperty.Register("Icon", typeof(string), typeof(DataField), new UIPropertyMetadata("", OnIconChanged));

            private static void OnIconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var control = d as ButtonImage;
                if (control != null)
                {
                    control.IconChange(e);
                }
            }
            private void IconChange(DependencyPropertyChangedEventArgs e)
            {
                var uri = e.NewValue as string;
                var image = GetTemplateChild("PART_Image") as Image;
                if (image != null)
                {
                  //  image.Source = ComponentUtils.CreateImageSource(Icon, true);
                }
            }
          

        }
    }
