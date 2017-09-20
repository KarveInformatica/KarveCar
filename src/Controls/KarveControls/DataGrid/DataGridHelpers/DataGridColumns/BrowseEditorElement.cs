using Telerik.WinControls.UI;
using Telerik.WinControls;
using System.Windows.Forms;
using System.Drawing;

namespace KarveControls
{
    internal class BrowseEditorElement : LightVisualElement
    {

        private RadButtonElement button_Renamed;

        private RadTextBoxItem textBox_Renamed;

        public RadTextBoxItem TextBox
        {
            get { return this.textBox_Renamed; }
        }

        public RadButtonElement Button
        {
            get { return this.button_Renamed; }
        }


        protected override void CreateChildElements()
        {

            textBox_Renamed = new RadTextBoxItem();
            textBox_Renamed.Margin = new Padding(2);

            textBox_Renamed.RouteMessages = false;
            button_Renamed = new RadButtonElement("...");
            button_Renamed.Padding = new Padding(2, 0, 2, 0);

            this.Children.Add(textBox_Renamed);
            this.Children.Add(button_Renamed);
        }

        protected override SizeF ArrangeOverride(SizeF finalSize)
        {
            RectangleF clientRect = GetClientRectangle(finalSize);
            RectangleF buttonRect = new RectangleF(clientRect.Right - button_Renamed.DesiredSize.Width, clientRect.Top,
                button_Renamed.DesiredSize.Width, clientRect.Height);
            RectangleF textRect = new RectangleF(clientRect.Left,
                clientRect.Top + (clientRect.Height - textBox_Renamed.DesiredSize.Height) / 2,
                buttonRect.Left - clientRect.Left - 2, textBox_Renamed.DesiredSize.Height);

            foreach (RadElement element in this.Children)
            {
                if (object.ReferenceEquals(element, this.textBox_Renamed))
                {
                    element.Arrange(textRect);
                }
                else if (object.ReferenceEquals(element, this.button_Renamed))
                {
                    element.Arrange(buttonRect);
                }
                else
                {
                    ArrangeElement(element, finalSize);
                }
            }

            return finalSize;
        }

    }
}
