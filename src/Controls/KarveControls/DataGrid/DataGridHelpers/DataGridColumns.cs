using System.Collections;

namespace KarveControls.DataGrid.DataGridHelpers
{
    public class DataGridColumns : System.Collections.Hashtable
    {

        public void Add(DataGridColumn Columna)
        {
            try
            {
                Columna.Item = this.Count;
                base.Add(Columna.Name, Columna);
            }
            catch
            {
            }
        }

        public ArrayList ToArray()
        {

            dynamic HC = base.Keys;
            ArrayList RS = new ArrayList();
            foreach (object ctr in HC)
            {
                RS.Add(ctr);
            }
            return RS;
        }

    }
}
