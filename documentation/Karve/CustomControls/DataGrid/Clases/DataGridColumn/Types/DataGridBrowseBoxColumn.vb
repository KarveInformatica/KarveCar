Imports Telerik.WinControls.UI
Imports VariablesGlobales

Public Class DataGridBrowseBoxColumn
    Inherits GridViewBrowseColumn

#Region "Variables"
    Protected _Item As Integer
    Protected _Campo As String
    Protected _Tabla As String
    Protected _ExpresionBd As String
    Protected _relatedColumn As GridViewDataColumn
    Protected _BackColor As System.Drawing.Color = Drawing.Color.White

    Private _Desc_Datafield As String
    Private _Desc_DBTable As String 'tabla con la que se rellena el campo descripcion
    Private _Desc_DBPK As String 'referencia de la tabla descripcion (el textbox editable)
    Private myWhere As String 'filtro extra en la consulta
    Private _requery As Boolean = True 'si tiene que volver a tirar la query (se pone en true cuando el texto cambia)
    Private _queryOnTextChanged As Boolean = True 'si tira la query cada vez que el texto cambia o espera al lost focus, si por defecto
    Protected _txtDataWidth As Integer
    Private _extraSQL As String = ""
    Public Event QueryThrown(dts As DataSet)
#End Region

#Region "Propiedades"
    Property Item As Integer
        Get
            Return _Item
        End Get
        Set(value As Integer)
            _Item = value
        End Set
    End Property

    Property Tabla As String
        Get
            Return _Tabla
        End Get
        Set(value As String)
            _Tabla = value
        End Set
    End Property

    Property Campo As String
        Get
            Return _Campo
        End Get
        Set(value As String)
            _Campo = value
        End Set
    End Property

    Property AliasCampo As String
        Get
            Return FieldName
        End Get
        Set(value As String)
            FieldName = value
        End Set
    End Property

    Property ExpresionBd As String
        Get
            Return _ExpresionBd
        End Get
        Set(value As String)
            _ExpresionBd = value
        End Set
    End Property

    Property BackColor As System.Drawing.Color
        Get
            Return _BackColor
        End Get
        Set(value As System.Drawing.Color)
            _BackColor = value
        End Set
    End Property

    Public Overrides Property [ReadOnly] As Boolean
        Get
            Return MyBase.[ReadOnly]
        End Get
        Set(value As Boolean)
            MyBase.[ReadOnly] = value
            If value Then
                _BackColor = ColorSel
            End If
        End Set
    End Property

    Property RelatedColumn As GridViewDataColumn
        Get
            Return _relatedColumn
        End Get
        Set(value As GridViewDataColumn)
            _relatedColumn = value
        End Set
    End Property

    Property Desc_Datafield As String
        Get
            Return _Desc_Datafield
        End Get
        Set(value As String)
            _Desc_Datafield = value
        End Set
    End Property

    Property Desc_DBTable As String
        Get
            Return _Desc_DBTable
        End Get
        Set(value As String)
            _Desc_DBTable = value
        End Set
    End Property

    Property Desc_DBPK As String
        Get
            Return _Desc_DBPK
        End Get
        Set(value As String)
            _Desc_DBPK = value
        End Set
    End Property

    Property Desc_Where As String
        Get
            Return myWhere
        End Get
        Set(value As String)
            myWhere = value
        End Set
    End Property

    Property Query_on_Text_Changed As Boolean
        Get
            Return _queryOnTextChanged
        End Get
        Set(value As Boolean)
            _queryOnTextChanged = value
        End Set
    End Property

    Property ExtraSQL As String
        Get
            Return _extraSQL
        End Get
        Set(value As String)
            _extraSQL = value
        End Set
    End Property

    Property Requery As Boolean
        Get
            Return _requery
        End Get
        Set(value As Boolean)
            _requery = value
        End Set
    End Property
#End Region


    Public Function queryDesc(ByVal codigo As String) As String
        'lanza la query para resolver la descripción
        _requery = False
        If codigo <> "" Then
            Dim db As New ASADB.Connection
            Dim mySql As String = "select " & _Desc_Datafield & IIf(_extraSQL <> "", ", " & _extraSQL, "") & " from " & _Desc_DBTable & " where " & _Desc_DBPK & " = '" & codigo & "'"
            If Not IsNothing(myWhere) And myWhere <> "" Then
                mySql = mySql & " and " & myWhere
            End If
            Dim dts As New DataSet
            dts = db.fillDts(mySql)
            Dim tmp As String
            Try
                tmp = dts.Tables(0).Rows(0).Item(0)
            Catch
                tmp = ""
            End Try
            If tmp <> "" Then
                queryDesc = tmp
            Else
                queryDesc = "Inexistente."
            End If
            RaiseEvent QueryThrown(dts)
        Else
            queryDesc = ""
        End If
    End Function

End Class
