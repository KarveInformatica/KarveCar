Imports System.Windows.Forms
Imports VariablesGlobales
Imports Karve.ConfiguracionApp

Public Class DataDir
    Inherits ctrBase
#Region "Varibles"
    Private mySql As String
    Private dts As DataSet
    Private requery As Boolean = False
    Private _showDir2L As Boolean = False
    Private _showGps As Boolean = False
    Private _showPais As Boolean = True
    Private _readOnly As Boolean = False
    Private _descripcion As String

    Protected _Incorrecto As Boolean = False
    Protected _MensajeIncorrecto As String
#End Region

#Region "Propiedades"
#Region "Datafields/Datatables"
    Property Datafield_Direccion As String
        Get
            Return dtfDireccion.DataField
        End Get
        Set(value As String)
            dtfDireccion.DataField = value
        End Set
    End Property

    Property Datafield_Direccion2L As String
        Get
            Return dtfDireccion2L.DataField
        End Get
        Set(value As String)
            dtfDireccion2L.DataField = value
        End Set
    End Property

    Property Datafield_GPS As String
        Get
            Return dtfGPS.DataField
        End Get
        Set(value As String)
            dtfGPS.DataField = value
        End Set
    End Property

    Property Datafield_CP As String
        Get
            Return dtfCP.DataField
        End Get
        Set(value As String)
            dtfCP.DataField = value
        End Set
    End Property

    Property Datafield_Poblacion As String
        Get
            Return dtfPoblacion.DataField
        End Get
        Set(value As String)
            dtfPoblacion.DataField = value
        End Set
    End Property

    Property Datafield_Provincia As String
        Get
            Return dtfProvincia.DataField
        End Get
        Set(value As String)
            dtfProvincia.DataField = value
        End Set
    End Property

    Property Datafield_Pais As String
        Get
            Return dtfPais.DataField
        End Get
        Set(value As String)
            dtfPais.DataField = value
        End Set
    End Property

    Property Datatable_Direccion As String
        Get
            Return dtfDireccion.DataTable
        End Get
        Set(value As String)
            dtfDireccion.DataTable = value
        End Set
    End Property

    Property Datatable_Direccion2L As String
        Get
            Return dtfDireccion2L.DataTable
        End Get
        Set(value As String)
            dtfDireccion2L.DataTable = value
        End Set
    End Property

    Property Datatable_GPS As String
        Get
            Return dtfGPS.DataTable
        End Get
        Set(value As String)
            dtfGPS.DataTable = value
        End Set
    End Property

    Property Datatable_CP As String
        Get
            Return dtfCP.DataTable
        End Get
        Set(value As String)
            dtfCP.DataTable = value
        End Set
    End Property

    Property Datatable_Poblacion As String
        Get
            Return dtfPoblacion.DataTable
        End Get
        Set(value As String)
            dtfPoblacion.DataTable = value
        End Set
    End Property

    Property Datatable_Provincia As String
        Get
            Return dtfProvincia.DataTable
        End Get
        Set(value As String)
            dtfProvincia.DataTable = value
        End Set
    End Property

    Property Datatable_Pais As String
        Get
            Return dtfPais.DataTable
        End Get
        Set(value As String)
            dtfPais.DataTable = value
        End Set
    End Property
#End Region

#Region "Text_Data"
    Property Text_Data_Direccion As String
        Get
            Return dtfDireccion.Text_Data
        End Get
        Set(value As String)
            dtfDireccion.Text_Data = value
        End Set
    End Property

    Property Text_Data_Direccion2L As String
        Get
            Return dtfDireccion2L.Text_Data
        End Get
        Set(value As String)
            dtfDireccion2L.Text_Data = value
        End Set
    End Property

    Property Text_Data_GPS As String
        Get
            Return dtfGPS.Text_Data
        End Get
        Set(value As String)
            dtfGPS.Text_Data = value
        End Set
    End Property

    Property Text_Data_CP As String
        Get
            Return dtfCP.Text_Data
        End Get
        Set(value As String)
            dtfCP.Text_Data = value
        End Set
    End Property

    Property Text_Data_Poblacion As String
        Get
            Return dtfPoblacion.Text_Data
        End Get
        Set(value As String)
            dtfPoblacion.Text_Data = value
        End Set
    End Property

    Property Text_Data_Provincia As String
        Get
            Return dtfProvincia.Text_Data
        End Get
        Set(value As String)
            dtfProvincia.Text_Data = value
        End Set
    End Property

    Property Text_Data_Pais As String
        Get
            Return dtfPais.Text_Data
        End Get
        Set(value As String)
            dtfPais.Text_Data = value
        End Set
    End Property
#End Region

    Property Show_Dir2L As Boolean
        Get
            Return _showDir2L
        End Get
        Set(value As Boolean)
            _showDir2L = value
            dtfDireccion2L.Visible = _showDir2L
        End Set
    End Property

    Property Show_GPS As Boolean
        Get
            Return _showGps
        End Get
        Set(value As Boolean)
            _showGps = value
            dtfGPS.Visible = _showGps
        End Set
    End Property

    Property Show_Pais As Boolean
        Get
            Return _showPais
        End Get
        Set(value As Boolean)
            _showPais = value
            dtfPais.Visible = _showPais
        End Set
    End Property

    Property Label_Space As Integer
        Get
            Return dtfDireccion.Label_Space
        End Get
        Set(value As Integer)
            dtfDireccion.Label_Space = value
            dtfDireccion2L.Label_Space = value
            dtfGPS.Label_Space = value
            dtfCP.Label_Space = value
            dtfCP.Width = 152 + (value - 75)
            dtfPoblacion.Label_Space = value
            dtfProvincia.Label_Space = value
            dtfPais.Label_Space = value
        End Set
    End Property

    Public Overrides Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property

    Overrides ReadOnly Property Incorrecto As Boolean
        Get
            Return _Incorrecto
        End Get
    End Property

    Overrides ReadOnly Property MensajeIncorrecto As String
        Get
            Return Translate(_MensajeIncorrecto)
        End Get
    End Property

    Property ReadOnly_Data As Boolean
        Get
            Return _readOnly
        End Get
        Set(value As Boolean)
            _readOnly = value
            setReadOnly()
        End Set
    End Property

    Shadows Property requeryCP As Boolean
        Get
            Return requery
        End Get
        Set(value As Boolean)
            requery = value
        End Set
    End Property

#End Region

#Region "Eventos"

    Private Sub DataDir_Load(sender As Object, e As EventArgs) Handles Me.Load
        dtfCP.Width = 1
        dtfCP.Width = 137 + (dtfCP.Label_Space - 60)
        dtfDireccion2L.Visible = _showDir2L
        dtfGPS.Visible = _showGps
        dtfPais.Visible = _showPais

        dtfPais.Lupa = lupaPais
        dtfProvincia.Lupa = lupaProvincia
    End Sub

    Private Sub dtfCP_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dtfCP.Validating
        If requery Then
            queryDesc()
        End If
    End Sub

    Private Sub dtfCP_TextChanged() Handles dtfCP.TextChanged
        requery = True
    End Sub
#End Region

#Region "Funciones de Acceso a Datos"
#Region "Bindings"
    'Funciones de bindeo con sobrecarga en funcion del donde se guarden los datos
    Public Overrides Sub setBinding(ByRef dta As DataTable)
        dtfDireccion.setBinding(dta)
        If dtfDireccion2L.Visible Then dtfDireccion2L.setBinding(dta)
        If dtfGPS.Visible Then dtfGPS.setBinding(dta)
        dtfCP.setBinding(dta)
        dtfPoblacion.setBinding(dta)
        dtfProvincia.setBinding(dta)
        If dtfPais.Visible Then dtfPais.setBinding(dta)
        requery = False
    End Sub

    Public Overrides Sub setBinding(ByRef dts As DataSet)
        dtfDireccion.setBinding(dts)
        If _showDir2L Then dtfDireccion2L.setBinding(dts)
        If _showGps Then dtfGPS.setBinding(dts)
        dtfCP.setBinding(dts)
        dtfPoblacion.setBinding(dts)
        dtfProvincia.setBinding(dts)
        If dtfPais.Visible Then dtfPais.setBinding(dts)
        requery = False
    End Sub

    Public Overrides Sub setBinding(ByRef bs As BindingSource)
        dtfDireccion.setBinding(bs)
        If dtfDireccion2L.Visible Then dtfDireccion2L.setBinding(bs)
        If dtfGPS.Visible Then dtfGPS.setBinding(bs)
        dtfCP.setBinding(bs)
        dtfPoblacion.setBinding(bs)
        dtfProvincia.setBinding(bs)
        If dtfPais.Visible Then dtfPais.setBinding(bs)
        requery = False
    End Sub
#End Region

    Public Overrides Sub Clear()
        dtfDireccion.Clear()
        If dtfDireccion2L.Visible Then dtfDireccion2L.Clear()
        If dtfGPS.Visible Then dtfGPS.Clear()
        dtfCP.Clear()
        dtfPoblacion.Clear()
        dtfProvincia.Clear()
        If dtfPais.Visible Then dtfPais.Clear()
    End Sub

    Public Overrides Sub EndEdit()
        dtfDireccion.EndEdit()
        If dtfDireccion2L.Visible Then dtfDireccion2L.EndEdit()
        If dtfGPS.Visible Then dtfGPS.EndEdit()
        dtfCP.EndEdit()
        dtfPoblacion.EndEdit()
        dtfProvincia.EndEdit()
        If dtfPais.Visible Then dtfPais.EndEdit()
    End Sub

    Private Sub queryDesc()
        'lanza la query para resolver la descripción
        requery = False
        If dtfCP.Text_Data <> "" Then
            Dim db As New ASADB.Connection
            Dim mySql As String = "select pob.pobla , prov.siglas, pob.pais " & _
                                "from poblaciones as pob " & _
                                "left outer join provincia as prov on prov.cp = left(pob.cp, 2) " & _
                                "where pob.cp = '" & dtfCP.Text_Data & "'"
            
            dts = db.fillDts(mySql)
            If dts.Tables(0).Rows.Count = 1 Then
                dtfPoblacion.Text_Data = dts.Tables(0).Rows(0).Item(0)
                dtfProvincia.Text_Data = dts.Tables(0).Rows(0).Item(1)
                If dtfPais.Visible Then dtfPais.Text_Data = dts.Tables(0).Rows(0).Item(2)
            Else

            End If
        Else

        End If
    End Sub
#End Region

#Region "Funciones"
    Public Overrides Sub Validar()
        _Incorrecto = False
        _MensajeIncorrecto = ""

        If requery Then
            queryDesc()
        End If

        dtfDireccion.Validar()
        If dtfDireccion.Incorrecto Then
            _Incorrecto = True
            _MensajeIncorrecto &= dtfDireccion.Descripcion & ": " & dtfDireccion.MensajeIncorrecto & vbCrLf
        End If

        If dtfDireccion2L.Visible Then
            dtfDireccion2L.Validar()
            If dtfDireccion2L.Incorrecto Then
                _Incorrecto = True
                _MensajeIncorrecto &= dtfDireccion2L.Descripcion & ": " & dtfDireccion2L.MensajeIncorrecto & vbCrLf
            End If
        End If

        If dtfGPS.Visible Then
            dtfGPS.Validar()
            If dtfGPS.Incorrecto Then
                _Incorrecto = True
                _MensajeIncorrecto &= dtfGPS.Descripcion & ": " & dtfGPS.MensajeIncorrecto & vbCrLf
            End If
        End If

        dtfCP.Validar()
        If dtfCP.Incorrecto Then
            _Incorrecto = False
            _MensajeIncorrecto &= dtfCP.Descripcion & ": " & dtfCP.MensajeIncorrecto & vbCrLf
        End If

        dtfPoblacion.Validar()
        If dtfPoblacion.Incorrecto Then
            _Incorrecto = True
            _MensajeIncorrecto &= dtfPoblacion.Descripcion & ": " & dtfPoblacion.MensajeIncorrecto & vbCrLf
        End If

        dtfProvincia.Validar()
        If dtfProvincia.Incorrecto Then
            _Incorrecto = True
            _MensajeIncorrecto &= dtfProvincia.Descripcion & ": " & dtfProvincia.MensajeIncorrecto & vbCrLf
        End If

        If dtfPais.Visible Then
            dtfPais.Validar()
            If dtfPais.Incorrecto Then
                _Incorrecto = True
                _MensajeIncorrecto &= dtfPais.Descripcion & ": " & dtfPais.MensajeIncorrecto & vbCrLf
            End If
        End If

    End Sub

    Public Overrides Sub traduc()
        dtfDireccion.traduc()
        dtfDireccion2L.traduc()
        dtfGPS.traduc()
        dtfCP.traduc()
        dtfPoblacion.traduc()
        dtfProvincia.traduc()
        dtfPais.traduc()
    End Sub

    Private Sub setReadOnly()
        dtfDireccion.ReadOnly_Data = _readOnly
        dtfDireccion2L.ReadOnly_Data = _readOnly
        dtfGPS.ReadOnly_Data = _readOnly
        dtfCP.ReadOnly_Data = _readOnly
        dtfPoblacion.ReadOnly_Data = _readOnly
        dtfProvincia.ReadOnly_Data = _readOnly
        dtfPais.ReadOnly_Data = _readOnly
    End Sub

#End Region

End Class
