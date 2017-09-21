using System.Collections;

namespace KarveGrid.ColumnVirtual
{
    public class VirtualDataGridColumns : System.Collections.Hashtable
    {

        public void Add(DataGridColumnVirtual TablaQuery)
        {
            base.Add(TablaQuery.Name, TablaQuery);
        }

        public ArrayList Order()
        {
            dynamic HC = (from c in this.Valuesorderby c.Itemc);
            ArrayList RS = new ArrayList();
            foreach (DataGridColumnVirtual ctr in HC) {
                RS.Add(ctr);
            }
            return RS;
        }

    }
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
