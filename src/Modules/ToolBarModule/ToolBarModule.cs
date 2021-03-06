﻿using KarveCommon.Services;
using KarveCommon.Generic;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Windows;
using NLog;

namespace ToolBarModule
{
    public class ToolBarModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        public static string NAME = "ToolBarModule";

        public ToolBarModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        protected void RegisterViewsAndServices()
        {
            _container.RegisterType<IToolBarViewModel, KarveToolBarViewModel>();
            _container.RegisterType<IToolBarView, KarveToolBarView>();
        }
        public void Initialize()
        {
            try
            {
                RegisterViewsAndServices();
                _regionManager.RegisterViewWithRegion("KarveToolBar", typeof(KarveToolBarView));
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


        }
    }
}
