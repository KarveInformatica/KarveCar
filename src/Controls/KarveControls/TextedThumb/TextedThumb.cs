using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace KarveControls
{
    /* 
     * A texted thumb is stylable, thumb custom control
     */
 
    [TemplatePart(Name = "PART_ThumbText", Type = typeof(TextBlock))]
    class TextedThumb: Thumb
    {
        /// <summary>
        ///  Set or Get the first table name.
        /// </summary>
        public static readonly DependencyProperty TextedThumbProperty =
            DependencyProperty.Register(
                "Title",
                typeof(string),
                typeof(TextedThumb),
                new PropertyMetadata(string.Empty));

        /// <summary>
        ///  This is the title to be used inside the thumb
        /// </summary>
        public string Title
        {
            set
            {
                SetValue(TextedThumbProperty, value);
            }
            get
            {
                return (string) GetValue(TextedThumbProperty);
            }
        }
        static TextedThumb()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextedThumb), new FrameworkPropertyMetadata(typeof(TextedThumb)));
           
          
        }
        /// <summary>
        ///  TextedThumb is a constructor thumb
        /// </summary>
        public TextedThumb() : base()
        {  
        }
        /// <summary>
        ///  OnApplyTemplate.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            TextBlock textField = GetTemplateChild("PART_ThumbText") as TextBlock;
            if ((textField!=null) && (Title!=null))
            {
                textField.Text =  KarveLocale.Properties.Resources.TextedThumb_OnApplyTemplate_ConsultaDe+" "+ Title;
            }
        }


    }
}
