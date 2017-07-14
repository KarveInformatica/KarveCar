using KRibbon.View;
using Microsoft.Windows.Controls.Ribbon;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using static KRibbon.Model.Generic.RecopilatorioEnumerations;

namespace KRibbon.Logic.Generic
{
    public partial class AddTab : MainWindow
    {
        public static void AddRibbonTabAcciones(Ribbon rbInicio)
        {
            //var list = new ObservableCollection<MyRibbonButton>();
            //list.Add(new MyRibbonButton { Label = "Nuevo",      KeyTip = "N", Img = "new",      Name = "btntbitNuevo" });
            //list.Add(new MyRibbonButton { Label = "Guardar",    KeyTip = "G", Img = "save",     Name = "btntbitGuardar" });
            //list.Add(new MyRibbonButton { Label = "Cancelar",   KeyTip = "B", Img = "cancel",   Name = "btntbitCancelar" });
            //list.Add(new MyRibbonButton { Label = "Imprimir",   KeyTip = "I", Img = "print",    Name = "btntbitImprimir" });
            //list.Add(new MyRibbonButton { Label = "Eliminar",   KeyTip = "D", Img = "delete",   Name = "btntbitEliminar" });
            //list.Add(new MyRibbonButton { Label = "Siguiente",  KeyTip = "S", Img = "next",     Name = "btntbitSiguiente" });
            //list.Add(new MyRibbonButton { Label = "Anterior",   KeyTip = "A", Img = "previous", Name = "btntbitAnterior" });
            //list.Add(new MyRibbonButton { Label = "Salir",      KeyTip = "Q", Img = "exit",     Name = "btntbitSalir" });

            //RibbonTab tbAcciones = new RibbonTab();
            //tbAcciones.SetValue(FrameworkElement.NameProperty, "tbAcciones");
            //tbAcciones.Header = "Acciones";
            //tbAcciones.KeyTip = "N";
            ////tbAcciones.ContextualTabGroupHeader = "Acciones";

            //RibbonGroup tbgrAcciones = new RibbonGroup();
            //tbgrAcciones.SetValue(FrameworkElement.NameProperty, "tbgrAcciones");
            //tbgrAcciones.Header = "Acciones";

            //RibbonButton rbButton = null;
            //foreach (MyRibbonButton item in list)
            //{
            //    rbButton = new RibbonButton();
            //    rbButton.Label = item.Label;
            //    rbButton.KeyTip = item.KeyTip;
            //    rbButton.LargeImageSource = new BitmapImage(new Uri(@"Images\" + item.Img + ".png", UriKind.Relative));
            //    rbButton.SetValue(FrameworkElement.NameProperty, item.Name);
            //    tbgrAcciones.Items.Add(rbButton);
            //}
            
            //tbAcciones.Items.Add(tbgrAcciones);
            ////rbInicio.Items.Add(tbAcciones); //Añade la Tab al final del todo
            //rbInicio.Items.Insert(0, tbAcciones); //añade la Tab en la posición que deseemos
        }

        public static void AddRibbonTabFavoritos(Ribbon rbInicio)
        {
            //Random rd = new Random();
            //RibbonTab mytab = new RibbonTab();
            //RibbonGroup mygroup = null;
            //RibbonMenuButton mymenu = null;
            //RibbonButton mybutton = null;
            //mytab.Header = "Favoritos";

            //for (int i = 0; i < 5; i++)
            //{
            //    mygroup = new RibbonGroup();
            //    mygroup.Header = "Grupo " + (i + 1);
            //    int aux = rd.Next(1, 7);

            //    for (int j = 0; j < aux; j++)
            //    {
            //        if (j == 3)
            //        {
            //            mymenu = new RibbonMenuButton();
            //            mymenu.Label = "MenuButton " + (j + 1);
            //            mymenu.LargeImageSource = new BitmapImage(new Uri(@"Images\new.png", UriKind.Relative));

            //            mybutton = new RibbonButton();
            //            mybutton.Label = "Button " + (j + 1);
            //            mybutton.SmallImageSource = new BitmapImage(new Uri(@"Images\open.png", UriKind.Relative));

            //            mymenu.Items.Add(mybutton);
            //            mygroup.Items.Add(mymenu);
            //        }
            //        else
            //        {
            //            mybutton = new RibbonButton();
            //            mybutton.Label = "Button " + (j + 1);
            //            mybutton.SmallImageSource = new BitmapImage(new Uri(@"Images\open.png", UriKind.Relative));
            //            mybutton.SetValue(FrameworkElement.NameProperty, "btnButton");
            //            mybutton.Click += new RoutedEventHandler(((MainWindow)Application.Current.MainWindow).btnHelp_Click);

            //            mygroup.Items.Add(mybutton);
            //        }
            //    }
            //    mytab.Items.Add(mygroup);
            //}
            //rbInicio.Items.Add(mytab);
        }

        public static void AddTabItem(EOpcion tipoauxiliar)
        {
            ////Se comprueba que la tab ya no esté mostrada
            //if (tabitemdictionary.Where(p => p.TipoAuxiliar == tipoauxiliar).Count() == 0)
            //{
            //    TabItem tbitem = new TabItem();
            //    tbitem.Header = ribbonbuttondictionary.Where(z => z.Key == tipoauxiliar).FirstOrDefault().Value.propertiesresources;
            //    //tabitemdictionary.Add(tipoauxiliar, tbitem);
            //    ((MainWindow)Application.Current.MainWindow).tbControl.Items.Add(tbitem);
            //    tbitem.Focus();

            //    genericobscollection = new ObservableCollection<object>();

            //    switch (tipoauxiliar)
            //    {
            //        case EOpcion.rbtnFormaPagoProveedor:
            //            //FormaPagoProveedorCollection fpp = new FormaPagoProveedorCollection();
            //            //VariablesGlobales.genericobscollection = fpp.GetFormaPagoProveedor();
            //            break;
            //        case EOpcion.rbtnGruposTarifa:
            //            //GrupoTarifaCollection gtr = new GrupoTarifaCollection();
            //            //VariablesGlobales.genericobscollection = gtr.GetGruposTarifa();
            //            break;
            //        case EOpcion.rbtnTipoComisionista:
            //            //TipoComisionistaCollection tc = new TipoComisionistaCollection();
            //            //VariablesGlobales.genericobscollection = tc.GetTiposComisionista();
            //            break;
            //        default:
            //            break;
            //    }
            //    LoadDataItem(tbitem, genericobscollection, tipoauxiliar);
            //}
            //else
            //{   //Si el TabItem del tipo de auxiliar ya se está mostrado, no se carga
            //    //de nuevo, simplemente se establece el foco en ese TabItem
            //    foreach (var item in tabitemdictionary)
            //    {
            //        if (item.TipoAuxiliar.Equals(tipoauxiliar))
            //        {
            //            //TabItem tabitem = tabitemdictionary[item.TbItem];
            //            //tabitem.Focus();
            //            item.TbItem.Focus();
            //        }
            //    }
            //}
        }
        
        private static void LoadDataItem(TabItem tbitem, ObservableCollection<object> tabitemslist, EOpcion aux)
        {
            //DataGrid datagrid = new DataGrid();
            //datagrid.Width = 400;
            //datagrid.HorizontalAlignment = HorizontalAlignment.Left;
            //datagrid.CanUserResizeColumns = true;
            //datagrid.AlternatingRowBackground = Brushes.LightGray;
            //DataGridTextColumn col = new DataGridTextColumn();
            //col.Header = Properties.Resources.lrbtnEmpresas.Trim();
            //col.Binding = new Binding("Codigo");
            //col.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            //datagrid.Columns.Add(col);
            //col = new DataGridTextColumn();
            //col.Header = Properties.Resources.lrrCentrosAlquiler.Trim();
            //col.Binding = new Binding("Nombre");
            //col.Width = new DataGridLength(3, DataGridLengthUnitType.Star);
            //datagrid.Columns.Add(col);
            //foreach (var item in tabitemslist)
            //{
            //    datagrid.Items.Add(item);
            //}
            //tbitem.Content = datagrid;         
        }
    }
}
