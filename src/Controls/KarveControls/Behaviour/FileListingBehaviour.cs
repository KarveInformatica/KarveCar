using Syncfusion.Windows.Controls.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KarveControls.Behaviour
{
    public class FileListingBehaviour : KarveBehaviorBase<SfTextBoxExt>
    {
        private int state = 0;
        protected override void OnSetup()
        {
            
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
            this.AssociatedObject.LostFocus += AssociatedObject_Loaded;
            
        }

        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var textValue = e.Source as SfTextBoxExt;
            if (sender is SfTextBoxExt ext)
            {
                try
                {
                    var path = Path.GetDirectoryName(ext.Text);
                    string[] filePaths = Directory.GetFiles(path);
                    if (filePaths.Count() > 0)
                    {
                        ext.AutoCompleteMode = AutoCompleteMode.Suggest;
                        ext.AutoCompleteSource = filePaths;
                    }
                    state = 1;
                }
                catch (Exception ex)
                {

                }
            }
        }
        /// <summary>
        ///  OnCleanup. This cleans the stuff.
        /// </summary>
        protected override void OnCleanup()
        {
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            this.AssociatedObject.LostFocus -= AssociatedObject_Loaded;
        }
    }
}
