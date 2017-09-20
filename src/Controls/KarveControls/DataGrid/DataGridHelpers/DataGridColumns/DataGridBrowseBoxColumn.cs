
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Media;
using Telerik.WinControls.UI;

public class DataGridBrowseBoxColumn : GridViewBrowseColumn
{

    #region "Variables"
    protected int _Item;
    protected string _Campo;
    protected string _Tabla;
    protected string _ExpresionBd;
    protected GridViewDataColumn _relatedColumn;

   // protected System.Drawing.Color _BackColor = Drawing.Color.White;
    private string _Desc_Datafield;
    //tabla con la que se rellena el campo descripcion
    private string _Desc_DBTable;
    //referencia de la tabla descripcion (el textbox editable)
    private string _Desc_DBPK;
    //filtro extra en la consulta
    private string myWhere;
    //si tiene que volver a tirar la query (se pone en true cuando el texto cambia)
    private bool _requery = true;
    //si tira la query cada vez que el texto cambia o espera al lost focus, si por defecto
    private bool _queryOnTextChanged = true;
    protected int _txtDataWidth;
    private string _extraSQL = "";
    private System.Drawing.Color _BackColor;

    public event QueryThrownEventHandler QueryThrown;
    public delegate void QueryThrownEventHandler(DataSet dts);
    #endregion

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
                //_BackColor = ColorSel;
            }
        }
    }

    public GridViewDataColumn RelatedColumn
    {
        get { return _relatedColumn; }
        set { _relatedColumn = value; }
    }

    public string Desc_Datafield
    {
        get { return _Desc_Datafield; }
        set { _Desc_Datafield = value; }
    }

    public string Desc_DBTable
    {
        get { return _Desc_DBTable; }
        set { _Desc_DBTable = value; }
    }

    public string Desc_DBPK
    {
        get { return _Desc_DBPK; }
        set { _Desc_DBPK = value; }
    }

    public string Desc_Where
    {
        get { return myWhere; }
        set { myWhere = value; }
    }

    public bool Query_on_Text_Changed
    {
        get { return _queryOnTextChanged; }
        set { _queryOnTextChanged = value; }
    }

    public string ExtraSQL
    {
        get { return _extraSQL; }
        set { _extraSQL = value; }
    }

    public bool Requery
    {
        get { return _requery; }
        set { _requery = value; }
    }
    #endregion


    public string queryDesc(string codigo)
    {
        /*
         * TODO: Describe the quert.
         */
        string functionReturnValue = null;

        /*
        string functionReturnValue = null;
        //lanza la query para resolver la descripción
        _requery = false;
        if (!string.IsNullOrEmpty(codigo))
        {
            ASADB.Connection db = new ASADB.Connection();
            string mySql = "select " + _Desc_Datafield + (!string.IsNullOrEmpty(_extraSQL) ? ", " + _extraSQL : "") + " from " + _Desc_DBTable + " where " + _Desc_DBPK + " = '" + codigo + "'";
            if ((myWhere != null) & !string.IsNullOrEmpty(myWhere))
            {
                mySql = mySql + " and " + myWhere;
            }
            DataSet dts = new DataSet();
            dts = db.fillDts(mySql);
            string tmp = null;
            try
            {
                tmp = dts.Tables(0).Rows(0).Item(0);
            }
            catch
            {
                tmp = "";
            }
            if (!string.IsNullOrEmpty(tmp))
            {
                functionReturnValue = tmp;
            }
            else
            {
                functionReturnValue = "Inexistente.";
            }
            if (QueryThrown != null)
            {
                QueryThrown(dts);
            }
        }
        else
        {
            functionReturnValue = "";
        }
       */
        return functionReturnValue;
    }

}
