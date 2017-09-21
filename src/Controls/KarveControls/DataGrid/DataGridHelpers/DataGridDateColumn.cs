using Telerik.WinControls.UI;

namespace KarveControls.DataGrid.DataGridHelpers
{
    public class DataGridDateColumn : GridViewDateTimeColumn
    {

        int _Item;
        string _Campo;
        string _Tabla;
        string _ExpresionBd;

        System.Drawing.Color _BackColor = System.Drawing.Color.White;
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
            get
            {
                if (!string.IsNullOrEmpty(_ExpresionBd))
                {
                    return _ExpresionBd;
                }
                else
                {
                    if (string.IsNullOrEmpty(_Campo))
                        _Campo = AliasCampo;
//Return " DATEFORMAT(" & _Tabla & "." & _Campo & ", 'yyyy/mm/dd') "
                    return "";
                }
            }
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
//_BackColor = ColorSel;
                }
            }
        }
    }
}

