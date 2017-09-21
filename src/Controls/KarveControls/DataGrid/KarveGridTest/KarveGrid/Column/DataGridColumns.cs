using System.Collections;

namespace KarveGrid.Column
{
    public class DataGridColumns : System.Collections.Hashtable
    {

        public void Add(object Columna)
        {
            try {
                Columna.Item = this.Count;
                base.Add(Columna.Name, Columna);
            } catch {
            }
        }

        public ArrayList ToArray()
        {
            dynamic HC = (from c in this.Valuesorderby c.Itemc);
            ArrayList RS = new ArrayList();
            foreach (object ctr in HC) {
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
