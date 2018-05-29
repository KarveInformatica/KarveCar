using System;
using System.Collections.Generic;
using Syncfusion.UI.Xaml.Controls.DataPager;
using System.Windows;
using System.Windows.Input;

namespace KarveControls.Behaviour
{

    /// <summary>
    ///  DataPagerBehavior.
    /// </summary>
    public class DataPagerBehavior: KarveBehaviorBase<SfDataPager>
    {
        /// <summary>
        ///  This needs a page size
        /// </summary>
        public const string PageSize = "PAGE_SIZE";
        /// <summary>
        ///  This needs a page index.
        /// </summary>
        public const string StartIndex = "PAGE_INDEX";

        /// <summary>
        ///  This is a property for sending commands.
        /// </summary>
        /// 
        public static readonly DependencyProperty PageCountProperty = DependencyProperty.Register("PageCount", typeof(int), typeof(DataPagerBehavior),
            new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Set or Get the command property.
        /// </summary>
        public int PageCount
        {
            get => (int)GetValue(PageCountProperty);
            set => SetValue(PageCountProperty, value);
        }
        /// <summary>
        ///  Data pager behavior.
        /// </summary>
        public DataPagerBehavior() : base()
        {
        }
        /// <summary>
        ///  OnSetup.
        /// </summary>
        protected override void OnSetup()
        {
            this.AssociatedObject.PageIndexChanging += AssociatedObject_PageIndexChanging;
        }

        private void AssociatedObject_PageIndexChanging(object sender, PageIndexChangingEventArgs e)
        {
            if (e.NewPageIndex < PageCount - 2)
            {
                // trigger new load.
            }
        }
        /// <summary>
        ///  OnCleanup. This cleans the stuff.
        /// </summary>
        protected override void OnCleanup()
        {
        }


    }

}