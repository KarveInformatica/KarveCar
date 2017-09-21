using Telerik.WinControls.UI;

namespace KarveControls.DataGrid.DataGridHelpers
{
    public class DataGridDecimalColumn : GridViewDecimalColumn
    {

        public DataGridDecimalColumn()
        {
            this.NumeroDecimales = 2;
        }

        #region "Variables"

        int _Item;
        string _Campo;
        string _Tabla;
        string _ExpresionBd;
        #endregion
        System.Drawing.Color _BackColor = System.Drawing.Color.White;

        #region "Propiedades"

        public int Item
        {
            get { return _Item; }
            set { _Item = value; }
        }

        public string Tabla
        {
            get { return _Tabla; }
            set { _Tabla = value; }
        }

        public string Campo
        {
            get { return _Campo; }
            set { _Campo = value; }
        }

        public string AliasCampo
        {
            get { return FieldName; }
            set { FieldName = value; }
        }

        public string ExpresionBd
        {
            get { return _ExpresionBd; }
            set { _ExpresionBd = value; }
        }

        public System.Drawing.Color BackColor
        {
            get { return _BackColor; }
            set { _BackColor = value; }
        }

        public override bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                base.ReadOnly = value;
                if (value)
                {
//                _BackColor = ColorSel;
                }
            }
        }

        public int NumeroDecimales
        {
            get { return this.DecimalPlaces; }
            set
            {
                this.DecimalPlaces = value;
                this.FormatString = "{0:N" + value + "}";
            }
        }
        #endregion

    }
}


