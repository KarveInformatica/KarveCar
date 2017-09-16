using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prism.Mvvm;
using KarveDataAccessLayer.DataObjects;
using KarveCommon;
using KarveCommon.Services;
using Prism.Regions;
using System.Windows.Input;
using Prism.Commands;
using KarveDataServices.DataObjects;
using System.Windows;

namespace ProvidersModule.ViewModels
{
    public class BasicEditorViewModel: TabViewModelBase
    {
        public ICommand FontFamilyChanged { set; get; }
        public ICommand FontSizeChanged { set; get; }
        public ICommand TextChangedCommand { set; get; }
        public BasicEditorViewModel()
        {
            MessageBox.Show("Navigated view model.");
            Header = "Notes";
        }
        
    }
}
