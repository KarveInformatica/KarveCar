﻿using System;
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

namespace BookingModule.Views
{
    /// <summary>
    /// Interaction logic for BookingMail.xaml
    /// </summary>
    public partial class BookingMail : UserControl
    {
        public BookingMail()
        {
            InitializeComponent();
        }

        public string Header { get; internal set; }
    }
}
