namespace KarveGrid.Column.Types.DataGridDecimalColumn_Subtypes
{
    public class DataGridPercentageColumn : DataGridDecimalColumn
    {
        public DataGridPercentageColumn()
        {
            this.DecimalFormattedPlaces = DataGridDecimalColumn.DecimalPercentage;
        }
    }
}