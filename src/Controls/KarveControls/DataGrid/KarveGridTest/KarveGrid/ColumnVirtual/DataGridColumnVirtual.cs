namespace KarveGrid.ColumnVirtual
{
    public class DataGridColumnVirtual
    {
        int _Item;
        string _sName;
        string _sExpresion;
        string _sAlias;

        string _sAliasTabla;
        public int Item {
            get { return _Item; }
            set { _Item = value; }
        }

        public string Name {
            get { return _sName; }
            set { _sName = value; }
        }

        public string Expresion {
            get { return _sExpresion; }
            set { _sExpresion = value; }
        }

        public string AliasCampo {
            get { return _sAlias; }
            set { _sAlias = value; }
        }

        public string AliasTabla {
            get { return _sAliasTabla; }
            set { _sAliasTabla = value; }
        }

    }
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
