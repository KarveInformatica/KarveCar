using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Windows;
using DataAccessLayer;
using KarveCar.View;

namespace KarveCar
{
    class Bootstrapper : UnityBootstrapper
        {
            protected override DependencyObject CreateShell()
            {
                return Container.Resolve<MainWindow>();
            }

            protected override void InitializeShell()
            {
                Application.Current.MainWindow.Show();
                this.Container.RegisterType<IDalLocator, DalLocator>();

            //_container.RegisterType<IArticleView, ArticleView>();

            /*
                {
                    _container.RegisterType<INewsFeedService, NewsFeedService>(new ContainerControlledLifetimeManager());
                    _container.RegisterType<INewsController, NewsController>(new ContainerControlledLifetimeManager());
                    _container.RegisterType<IArticleView, ArticleView>();
                    _container.RegisterType<IArticlePresenter, ArticlePresenter>();
                    _container.RegisterType<INewsReaderView, NewsReader>();
                    _container.RegisterType<INewsReaderPresenter, NewsReaderPresenter>();
                }

           */
        }
    }
    
}
