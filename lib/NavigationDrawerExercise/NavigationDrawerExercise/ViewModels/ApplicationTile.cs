using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NavigationDrawerExercise.ViewModels
{
    public class ApplicationTile : NotificationObject
    {

        private string _name;
        private string _icon;
        private string _description;
        private string _color;
        private string _header;
        private string _slideImage;
        private bool _canSlide;
        private FrameworkElement _frameworkElement;



        //  Name = "Proveedores", Color = "#FF4DAEB5",  Header = "Maestro: Proveedores", Icon = "/Images/su.png" 

       /// <summary>
       ///  Get or Set the name.
       /// </summary>
        public string Name {
            get { return _name; } 
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            } }
        /// <summary>
        ///  Get or Set the Icon.
        /// </summary>
        public string Icon {
            get {
                return _icon;
            }
            set
            {
                _icon = value;
                RaisePropertyChanged("Icon");
            }
        }
        /// <summary>
        /// Get or set the description.
        /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }
        /// <summary>
        ///  Get or Set the color
        /// </summary>
        public string Color {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                RaisePropertyChanged("Color");
            }
        }

        public string Header {
            get
            {
                return _header;
            }
            set {
                _header = value;
                RaisePropertyChanged("Header");
            }
        }
        public string SlideImage
        {
            get
            {
                return _slideImage;

            }
            set
            {
                _slideImage = value;
                RaisePropertyChanged("SlideImage");
            }
        }

        public bool CanSlide {
            get
            {
                return _canSlide;
            }
            set {
                _canSlide = true;
                RaisePropertyChanged("CanSlide");
            }
        }
        public FrameworkElement View { get; set; }
        

    }
}
