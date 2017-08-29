using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using LinqToVisualTree;
using System.Diagnostics;

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            LayoutUpdated += new EventHandler(MainPage_LayoutUpdated);

            // example #1 - descendants

            // all items within the visual tree
            IEnumerable<DependencyObject> allDescendants = this.Descendants();
            OutputResults(allDescendants);
            Debug.WriteLine("");

            // all items within the visual tree of 'GridTwo'
            var descendantsOfGridTwo = GridTwo.Descendants();
            OutputResults(descendantsOfGridTwo);
            Debug.WriteLine("");

            // all items within the visual tree of 'GridTwo' that are textboxes
            var textBoxDescendantsOfGridTwo = GridTwo.Descendants()
                                                     .Where(i => i is TextBox);
            OutputResults(textBoxDescendantsOfGridTwo);
            Debug.WriteLine("");

            // all items within the visual tree of 'GridTwo' that are textboxes
            var textBoxDescendantsOfGridTwo2 = GridTwo.Descendants<TextBox>();
            OutputResults(textBoxDescendantsOfGridTwo2);
            Debug.WriteLine("");

            // example #2 - elements

            var userControlChildren = this.Elements();
            OutputResults(userControlChildren);
            Debug.WriteLine("");

            var stackPanelChildren = GridTwo.Elements<StackPanel>();
            OutputResults(stackPanelChildren);
            Debug.WriteLine("");


            // example #3 - ancestors

            // the ancestors for 'TextBoxFour'
            var ancestors = TextBoxFour.Ancestors();
            OutputResults(ancestors);
            Debug.WriteLine("");

            // the ancestors for 'TextBoxFour' that are StackPanels
            var stackPanelAncestors = TextBoxFour.Ancestors<StackPanel>();
            OutputResults(stackPanelAncestors);
            Debug.WriteLine("");


            // get all the TextBox's which have a Grid as direct parent
            var itemsFluent = this.Descendants<TextBox>()
                                  .Where(i => i.Ancestors().FirstOrDefault() is Grid);

            var itemsQuery = from v in this.Descendants<TextBox>()
                             where v.Ancestors().FirstOrDefault() is Grid
                             select v;

            OutputResults(itemsFluent);
            Debug.WriteLine("");

            // get all the StackPanels that are within another StackPanel visual tree
            var items2Fluent = this.Descendants<StackPanel>()
                                   .Descendants<StackPanel>();

            var items2Query = from i in
                                  (from v in this.Descendants<StackPanel>()
                                   select v).Descendants<StackPanel>()
                              select i;

            OutputResults(items2Fluent);
            Debug.WriteLine("");


        }

        void MainPage_LayoutUpdated(object sender, EventArgs e)
        {

            // output a tree!
            string tree = this.DescendantsAndSelf().Aggregate("",
                (bc, n) => bc + n.Ancestors().Aggregate("", (ac, m) => (m.ElementsAfterSelf().Any() ? "| " : "  ") + ac,
                ac => ac + (n.ElementsAfterSelf().Any() ? "+-" : "\\-")) + n.GetType().Name + "\n");
            Debug.WriteLine(tree);
        }

        /// <summary>
        /// Outputs the list of items, giving their index, type and name
        /// </summary>
        /// <param name="result"></param>
        private void OutputResults(IEnumerable<DependencyObject> result)
        {
            int i = 0;
            foreach (var obj in result)
            {
                var fe = obj as FrameworkElement;
                Debug.WriteLine(i++ + " {" + obj.GetType().Name +
                    "} \t" + (fe != null ? "[" + fe.Name + "]" : "[]"));
            }
        }
    }
}
