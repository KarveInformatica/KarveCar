using Telerik.WinControls.UI;

namespace KarveGrid.ColumnGroup
{
    public class DataGridColumnGroups : ColumnGroupsViewDefinition
    {

        public void Add(ref GridViewColumnGroup col)
        {
            this.ColumnGroups.Add(col);
        }

        //Public Overloads Sub Add(ByVal Columna As Object)
        //    Try
        //        Columna.Item = Me.Count
        //        MyBase.Add(Columna.Name, Columna)
        //    Catch
        //    End Try
        //End Sub

        //Public Function ToArray() As ArrayList
        //    Dim HC = (From c As Object In Me.Values Order By c.Item Select c)
        //    Dim RS As New ArrayList
        //    For Each ctr As Object In HC
        //        RS.Add(ctr)
        //    Next
        //    Return RS
        //End Function
    }
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
