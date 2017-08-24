Imports VariablesGlobales
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class DualDatafield
    Inherits Datafield

#Region "Variables"
    Private _Desc_DBTable As String 'tabla con la que se rellena el campo descripcion
    Private _Desc_DBPK As String 'referencia de la tabla descripcion (el textbox editable)
    Private _Desc_Datafield As String 'referencia de la tabla descripcion (el textbox editable)
    Private myWhere As String 'filtro extra en la consulta
    Private myWhereObliga As String 'filtro extra en la consulta obligatorio, para casos en los que el valor depende de una 2ª cond (ej Cta contable funciona por Cod + Emp)
    Private _requery As Boolean = False 'si tiene que volver a tirar la query (se pone en true cuando el texto cambia)
    Private _queryOnTextChanged As Boolean = True 'si tira la query cada vez que el texto cambia o espera al lost focus, si por defecto
    Protected _txtDataWidth As Integer
    Private _extraSQL As String = ""
    Private _lupa As String
    Private _form As String

    Private _db As New ASADB.Connection

    Private _descripcionEditable As Boolean = False

    Public Event QueryThrown(dts As DataSet)
    Public Event Texto_Changing(Sender As Object)
    Public Event Texto_Changed(Sender As Object)
    Public Event AbrirLupaExtraBefore(Sender As Object)
    Public Event AbrirLupaExtraAfter(Sender As Object)

#End Region

#Region "Propiedades"
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

    Property Desc_WhereObligatoria As String
        Get
            Return myWhereObliga
        End Get
        Set(value As String)
            myWhereObliga = value
        End Set
    End Property

    Property Text_Width As Integer
        Get
            Return _txtDataWidth
        End Get
        Set(value As Integer)
            _txtDataWidth = value

            Text_Width_Change()
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

    Protected Overridable Sub Text_Width_Change()
        txtData.Width = _txtDataWidth
        dtfDesc.Location = New System.Drawing.Point(_txtDataWidth + 6, dtfDesc.Location.Y)
        dtfDesc.Width = Me.Width - (_txtDataWidth + 6)
    End Sub

    Property ExtraSQL As String
        Get
            Return _extraSQL
        End Get
        Set(value As String)
            _extraSQL = value
        End Set
    End Property

    Property Lupa As String
        Get
            Return _lupa
        End Get
        Set(value As String)
            _lupa = value
        End Set
    End Property

    Property Formulario As String
        Get
            Return _form
        End Get
        Set(value As String)
            _form = value
        End Set
    End Property

    Public Property Text_Data_Desc As String
        Get
            Return dtfDesc.Text_Data
        End Get
        Set(value As String)
            dtfDesc.Text_Data = value
        End Set
    End Property

    Shadows Property DB As ASADB.Connection
        Get
            Return _db
        End Get
        Set(value As ASADB.Connection)
            _db = value
        End Set
    End Property

    Public Property ReQuery As Boolean
        Get
            Return _requery
        End Get
        Set(value As Boolean)
            _requery = value
        End Set
    End Property

#End Region

#Region "Eventos"

    Protected Overrides Sub Text_Changed()
        RaiseEvent Texto_Changing(Me)
        _requery = True
        If _queryOnTextChanged Then
            queryDesc()
            RaiseEvent Texto_Changed(Me)
        End If
    End Sub

    Protected Overrides Sub Text_Validating()
        If _requery Then
            queryDesc()
        End If
    End Sub

    Protected Overrides Sub change_theme()
        MyBase.change_theme()
        If Theme = ThemeType.Plain Then
            dtfDesc.Theme = ThemeType.Plain
        Else
            dtfDesc.Theme = ThemeType.Crystal
        End If
    End Sub

    Protected Overrides Sub size_changed()
        'Text_Width_Change()
        'dtfDesc.Width = Me.Width - dtfDesc.Location.X
    End Sub

    Private Sub DualDatafield_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F4 Then
            abrirLupa()
        End If
    End Sub

#End Region

#Region "Funciones de Validacion"
    Protected Overrides Function ValidateExtra() As Boolean
        'si se intenta relacionar con un registro que no existe da un error
        If _requery Then
            queryDesc()
        End If
        If dtfDesc.Text_Data = "Inexistente." Then
            _MensajeIncorrecto = "No existe el registro al que se hace referencia."
            Return False
        End If
        Return True
    End Function
#End Region

#Region "Funciones de Acceso a Datos"
    Protected Sub queryDesc(Optional ByVal ignoreWhere As Boolean = False)
        'lanza la query para resolver la descripción
        _requery = False
        If txtData.Text <> "" And _Desc_Datafield <> "" And _Desc_DBTable <> "" And _Desc_DBPK <> "" Then

            Dim mySql As String = "select " & _Desc_Datafield & IIf(_extraSQL <> "", ", " & _extraSQL, "") & " from " & _Desc_DBTable & " where " & _Desc_DBPK & " = '" & txtData.Text & "'"
            If Not IsNothing(myWhere) And myWhere <> "" And Not ignoreWhere Then
                mySql = mySql & " and " & myWhere
            End If
            If Not IsNothing(myWhereObliga) And myWhereObliga <> "" Then
                mySql = mySql & " and " & myWhereObliga
            End If

            Dim dts As New DataSet
            'Me.DataField = ""
            dts = _db.fillDts(mySql)

            Dim tmp As String
            Try
                tmp = dts.Tables(0).Rows(0).Item(0)
            Catch
                tmp = ""
            End Try
            If tmp <> "" Then
                dtfDesc.Text_Data = tmp
            Else
                dtfDesc.Text_Data = "Inexistente."
            End If
            RaiseEvent QueryThrown(dts)
        Else
            dtfDesc.Text_Data = ""
        End If
    End Sub

    Protected Overrides Sub bindingExtra(ByRef dataAdapter As Object)
        'lanza la query cuando se bindea el campo para cargar datos
        ' se fuerza a que ignore las wheres para que recupere los datos en cualquiera de los casos
        Try
            Dim str As String = ""
            Select Case dataAdapter.GetType
                Case GetType(DataSet)
                    str = IIf(Not IsDBNull(CType(dataAdapter, DataSet).Tables(Me.DataTable).Rows(0).Item(Me.DataField)), CType(dataAdapter, DataSet).Tables(Me.DataTable).Rows(0).Item(Me.DataField), "")
                Case GetType(DataTable)
                Case GetType(BindingSource)
            End Select
            'If Not IsDBNull() Then
            txtData.Text = str
        Catch
        End Try
        'queryDesc(True)
    End Sub

    Protected Overrides Sub ClearExtra()
        dtfDesc.Clear()
    End Sub

    Public Sub forceQuery(Optional ByVal ignoreWhere As Boolean = False)
        queryDesc(ignoreWhere)
    End Sub
#End Region

    Protected Sub abrirLupa()
        Try
            If _lupa <> "" Then
                Dim frmLupa As Object
                RaiseEvent AbrirLupaExtraBefore(Me)
                frmLupa = OpenForm(_lupa)
                frmLupa.MarcarFilas = False
                frmLupa.OpenFormNuevo = _form
                frmLupa.OpenDialog()
                If frmLupa.AbrirFrm Then
                    If _form <> "" Then
                        VariablesGlobales.OpenTab(_form, "")
                    End If
                Else
                    Dim tmp As Boolean = _queryOnTextChanged
                    _queryOnTextChanged = False
                    txtData.Text = frmLupa.dtsResult.Tables(0).Rows(0).Item(_Desc_DBPK)
                    _queryOnTextChanged = tmp
                    queryDesc(True)
                End If
                RaiseEvent AbrirLupaExtraAfter(Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DualDatafield_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        'Text_Width_Change()
    End Sub
End Class
