using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;

namespace TestClient.UserControls
{
    /// <summary>
    /// Interaction logic for CodeViewer.xaml
    /// </summary>
    public partial class CodeViewer : UserControl
    {
        public CodeViewer()
        {
            InitializeComponent();
        }
        public void LoadData(string name)
        {
            string cSharpFile = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                                                       "UserControls\\"+name + ".xaml.cs");
            textEditor.Document.Text = System.IO.File.ReadAllText(cSharpFile);
            string xamlFile = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                                                       "UserControls\\" + name + ".xaml");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xamlFile);
            vXMLViwer.xmlDocument = xmlDoc;
        }

    }
}
