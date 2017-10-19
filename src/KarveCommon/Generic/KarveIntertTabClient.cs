
using Dragablz;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using Dragablz.Core;
using System.Windows.Controls;

namespace KarveCommon.Generic
{
    public class KarveInterTabClient : DefaultInterTabClient
    {        
       

        public override TabEmptiedResponse TabEmptiedHandler(TabablzControl tabControl, Window window)
        {
            int items = tabControl.Items.Count;
            var viewModel = window.DataContext;

            if (tabControl.Items.Count  >1)
        {
            return TabEmptiedResponse.CloseWindowOrLayoutBranch;
        }
        else
        {
                return TabEmptiedResponse.DoNothing;
        }
         
        }
    }
}