using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Media;
using Telerik.WinControls.UI;

namespace KarveControls
{
    public class DataGridColumn : GridViewDataColumn
    {

        public enum eTipoColumn
        {
            Pk,
            Fecha,
            Hora,
            Texto,
            Observaciones,
            Numerico
        }

        int _Item;
        string _Campo;
        string _Tabla;
        string _ExpresionBd;
        System.Drawing.Color _BackColor = System.Drawing.Color.White;

        eTipoColumn _eTipoColumn;

        public int Item
        {
            get { return _Item; }
            set { _Item = value; }
        }

        public string Campo
        {
            get { return _Campo; }
            set { _Campo = value; }
        }

        public string ExpresionBd
        {
            get { return _ExpresionBd; }
            set { _ExpresionBd = value; }
        }

        public string Tabla
        {
            get { return _Tabla; }
            set { _Tabla = value; }
        }

        public string AliasCampo
        {
            get { return FieldName; }
            set { FieldName = value; }
        }

        public System.Drawing.Color BackColor
        {
            get { return _BackColor; }
            set { _BackColor = value; }
        }

        public eTipoColumn TipoColumna
        {
            get { return _eTipoColumn; }
            set
            {
                _eTipoColumn = value;
                EstablecePropiedadesTipoColumna();
            }
        }

        private void EstablecePropiedadesTipoColumna()
        {
            switch (_eTipoColumn)
            {
                case eTipoColumn.Pk:
                    ColumnaPk();
                    break;
                case eTipoColumn.Fecha:
                    ColumnaFecha();
                    break;
            }

        }

        private void ColumnaPk()
        {
//            _BackColor = Drawing.Color.SkyBlue;
            base.Width = 80;
        }

        private void ColumnaFecha()
        {
            string sAlias = _Tabla;
            if (!string.IsNullOrEmpty(sAlias))
                sAlias = sAlias + ".";
            _ExpresionBd = " DATEFORMAT(" + sAlias + base.FieldName + ", 'dd/mm/yyyy') ";
            base.Width = 100;
            base.AllowResize = false;
        }

    }
}