Imports System.Windows.Forms
Imports CustomControls
Imports VariablesGlobales
Imports Karve.ConfiguracionApp
Imports Telerik.WinControls.UI
Imports System.ComponentModel
Imports Karve.Theme
Imports Karve
Imports Telerik.WinControls.UI.Docking

Public Class Consulta

#Region "Variables"
    Public Event CintaClick(sender As Object, e As EventArgs)
    Public dtsResult As New DataSet
    Protected dgtTables As New DataGridTables
    Protected dgcColumns As New DataGridColumns
    Protected dgrRules As New DataGridRules
    Protected dgoOrdenes As New DataGridOrdenColumnas
    Protected colRelation As CustomControls.DataGridTextBoxColumn

    Public _OpenDialog As Boolean
    Private kMsgBox As New CustomControls.kMsgBox
    Protected db As New ASADB.Connection
    Dim _OpenForm As String
    Dim _MarcarFilas As Boolean
    Dim _AbrirFrm As Boolean
    Dim _dtsVistaSel As New DataSet
    Dim _dtsVistaColsSel As New DataSet

    Private _image As System.Drawing.Bitmap

    Public Event OpenMenu(Sender As Object, e As ContextMenuOpeningEventArgs)

#End Region

#Region "Propiedades"

    <DefaultValue(False)> _
Public Property MarcarFilas As Boolean
        Get
            CintaMarcarFilasVisible()
            Return _MarcarFilas
        End Get
        Set(value As Boolean)
            _MarcarFilas = value
            Grid.MarcarFilas = _MarcarFilas
            CintaMarcarFilasVisible()
        End Set
    End Property

    Public ReadOnly Property AbrirFrm As String
        Get
            Return _AbrirFrm
        End Get
    End Property

    Public Property OpenFormNuevo As String
        Get
            Return _OpenForm
        End Get
        Set(value As String)
            _OpenForm = value
        End Set
    End Property

    Public Property ColSelectFilter As String
        Get
            Return Grid.ColSelectFilter
        End Get
        Set(value As String)
            Grid.ColSelectFilter = value
        End Set
    End Property

    Public ReadOnly Property IsOpenDialog As Boolean
        Get
            Return _OpenDialog
        End Get
    End Property

    Property Image As System.Drawing.Bitmap
        Get
            Return _image
        End Get
        Set(value As System.Drawing.Bitmap)
            _image = value
        End Set
    End Property

#End Region

#Region "   .   EVENTOS.    "

#Region "   .   EVENTOS FORMULARIO.    "

    Private Sub Consulta_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Me.IsMdiChild = False Then
            Me.Opacity = 0
            Me.Cinta.Visible = True
            Me.Cinta.MaximizeButton = False
            Me.Cinta.MinimizeButton = False
            Me.Opacity = 100
        End If
    End Sub

    Private Sub Consulta_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Dim iWh As Integer = 0
        Grid.Columns.Clear()
        Grid.Rows.Clear()
        CintaMarcarFilasVisible()
        rbtEdicion.Select()
        setIconos()
        If IsOpenDialog Then

            If VMenu.Collapsed Then
                iWh = 28
            Else
                iWh = VMenu.Width
            End If

            Dim Loc As New System.Drawing.Point
            Loc.Y = VGdockMDI.FindForm.Top + VGdockMDI.Top
            Loc.X = VGdockMDI.FindForm.Left + iWh + VGdockMDI.Left + 10

            Me.Top = Loc.Y
            Me.Left = Loc.X
            Me.Height = VGdockMDI.Height
            Me.Width = VGdockMDI.Width - (iWh + 3)


            VMenu.Enabled = False
            VGribbonMDI.Enabled = False
        End If
    End Sub

    Private Sub setIconos()
        If DesignMode = False Then
            Me.rbAceptar.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Aceptar_Ic)
            Me.rbCancelar.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Cancelar_Ic)
            Me.rbNuevo.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Add_Ic)
            Me.rbBuscar.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Buscar_Ic)
            Me.rbSMSelected.Image = TemaAplicacion.IconosTree(Theme_Definicion.euIconosTree.Check_Ict)
            Me.rbSMDesSelected.Image = TemaAplicacion.IconosTree(Theme_Definicion.euIconosTree.UnCheck_Ict)
            Me.rbGuardar.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Save_Ic)
            Me.rbOpenForm.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Add_Ic)

            ConfiguraCintaEdicion(Cinta)
        End If
    End Sub

    Private Sub Consulta_Load(sender As Object, e As EventArgs) Handles Me.Load
        If DesignMode = False Then
            Grid.DBConnection = db
            DefineLupa()
            LoadCons()

        End If
    End Sub

    Private Sub Consulta_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Try
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            VGribbonMDI.CommandTabs.Clear()
            For Each cmdTab In VGribbonMDICopy.CommandTabs
                VGribbonMDI.CommandTabs.Add(cmdTab)
            Next
        Catch
        End Try
    End Sub

#End Region

#Region "   .   EVENTOS CINTA.  "

    Private Sub Cinta_Click(sender As Object, e As EventArgs) Handles Cinta.Click

    End Sub

    Private Sub rbBuscar_Click(sender As Object, e As EventArgs) Handles rbBuscar.Click
        Grid.LoadCons()
    End Sub

    Private Sub rbSMSelected_Click(sender As Object, e As EventArgs) Handles rbSMSelected.Click
        Grid.MarcarFilasEnGrid(True)
    End Sub

    Private Sub rbSMDesSelected_Click(sender As Object, e As EventArgs) Handles rbSMDesSelected.Click
        Grid.MarcarFilasEnGrid(False)
    End Sub

    Private Sub rbNuevo_Click(sender As Object, e As EventArgs) Handles rbNuevo.Click
        If _OpenForm <> "" Then
            If IsOpenDialog Then
                Me.Close()
                _AbrirFrm = True
            Else : VariablesGlobales.OpenTab(_OpenForm, "")
            End If
        End If
    End Sub

    Private Sub rbOpenForm_Click(sender As Object, e As EventArgs) Handles rbOpenForm.Click
        Grid.ShowColumnChooser()
    End Sub

    Private Sub rbGuardar_Click(sender As Object, e As EventArgs) Handles rbGuardar.Click
        '*-------------------------------------------------------------------------------
        Try
            db.beginTransaction()
            Dim dtr As DataRow = DameNuevaVista("Básica")
            If _dtsVistaSel.Tables(0).Rows.Count = 0 Then _dtsVistaSel.Tables(0).Rows.Add(dtr)
            '*-------------------------------------------------------------------------------
            For Each Columna In Grid.Columns
                With Columna
                    ColumnasVista(.Name, .IsVisible, .Width, .Index)
                End With
            Next
            '*-------------------------------------------------------------------------------
            db.updateDts("SELECT FIRST * FROM USER_LUPAS WHERE 0 = 1", _dtsVistaSel)
            db.updateDts("SELECT FIRST * FROM USER_LUPAS_COLUMNAS WHERE 0 = 1", _dtsVistaColsSel)
            db.commitTransaction()
            kMsgBox.Print("Datos guardados.", CustomControls.kMsgBox.kMsgBoxStyle.Information)
        Catch ex As Exception
            db.rollbackTransaction()
            kMsgBox.Print("Error al Guardar Configuración Lupa.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message)
        End Try
    End Sub

    Private Sub rbAceptar_click(sender As Object, e As EventArgs) Handles rbAceptar.Click, Grid.CellDoubleClick
        setResult()
        RaiseEvent CintaClick(sender, e)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub rbCancelar_click(sender As Object, e As EventArgs) Handles rbCancelar.Click
        RaiseEvent CintaClick(sender, e)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

#End Region

#End Region

    Private Sub CintaMarcarFilasVisible()
        If _MarcarFilas Then
            rbgSelectMult.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Else
            rbgSelectMult.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        End If
    End Sub

    Protected Overridable Sub setResult()
        Dim dtt As New DataTable
        dtt = Grid.DataSource
        dtsResult = New DataSet
        dtsResult = dtt.DataSet.Clone
        For Each RW As GridViewRowInfo In Grid.SelectedRows
            Dim dtr As DataRow
            dtr = dtsResult.Tables(0).NewRow
            For Each col As Object In Grid.Columns
                If col.AliasCampo = "" Then col.AliasCampo = col.campo
                dtr.Item(col.AliasCampo) = RW.Cells(col.Name).Value
            Next
            dtsResult.Tables(0).Rows.Add(dtr)
        Next
    End Sub

    Public Sub LoadCons()
        DameVista()
        MergeColumnas()
        Grid.Columnas = dgcColumns
        Grid.Tablas = dgtTables
        Grid.Ordenes = dgoOrdenes
        Grid.Clausulas = dgrRules
        setRules()

        Grid.generateGrid()
        Grid.loadGrid()
        Grid.LoadFiltros()
        Grid.LoadOrdenes()
    End Sub

    Protected Overridable Sub setRules()

    End Sub

    Public Sub OpenDialog()
        _OpenDialog = True
        OpenCuadroDialog()
    End Sub

    Private Sub OpenCuadroDialog()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'Me.StartPosition = FormStartPosition.CenterScreen
        Me.StartPosition = FormStartPosition.Manual
        Me.ShowDialog()
    End Sub

    Private Sub DockingLupa()
        Dim docWindow As New DocumentWindow
        Me.Dock = DockStyle.Fill
        Me.TopLevel = False
        Me.FormBorderStyle = FormBorderStyle.None
        docWindow.Controls.Add(Me)
        docWindow.Text = Me.Text

        docWindow.Text = Me.Text ' se asigna aqui porque es cuando ya esta traducido
        VGdockMDI.AddDocument(docWindow)
        VGdockMDI.ActiveWindow = docWindow

        Me.ShowDialog()
        Try
            docWindow.Image = CObj(Me).Image
        Catch
        End Try


    End Sub

    Protected Overridable Sub DefineLupa()

    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click

    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As GridViewCellEventArgs) Handles Grid.CellDoubleClick
        setResult()
    End Sub

    Private Sub frmBase_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.W Then
            Me.Close()
        End If
    End Sub



    Private Sub ColumnasVista(Name As String, IsVisible As Boolean, Width As Integer, Index As Integer)
        Dim bExiste As Boolean
        '*===============================================================================
        For Each Fila As DataRow In _dtsVistaColsSel.Tables(0).Rows
            If Fila.Item("COLUMNA_NOMBRE") = Name Then
                ActualizaColumnaVista(Fila, Name, IsVisible, Width, Index)
                bExiste = True
                Exit Sub
            End If
        Next
        If Not bExiste Then
            Dim dtr As DataRow
            dtr = _dtsVistaColsSel.Tables(0).NewRow()
            ActualizaColumnaVista(dtr, Name, IsVisible, Width, Index)
            _dtsVistaColsSel.Tables(0).Rows.Add(dtr)
        End If
    End Sub

    Private Sub ActualizaColumnaVista(dtr As DataRow, Name As String, IsVisible As Boolean, Width As Integer, Index As Integer)
        With dtr
            'ID_LUPA,COLUMNA_NOMBRE,VISIBLE,POSICION,ANCHO
            .Item("ID_LUPA") = _dtsVistaSel.Tables(0).Rows(0).Item("ID")
            .Item("COLUMNA_NOMBRE") = Name
            .Item("VISIBLE") = IIf(IsVisible, 1, 0)
            .Item("POSICION") = Index
            .Item("ANCHO") = Width
        End With
    End Sub

    Private Function DameNuevaVista(Nombre As String) As DataRow
        Dim dtr As DataRow
        If _dtsVistaSel.Tables(0).Rows.Count = 0 Then
            dtr = _dtsVistaSel.Tables(0).NewRow
        Else : dtr = _dtsVistaSel.Tables(0).Rows(0)
        End If
        '*--------------------------------------------------------------------
        If Nombre = "" Then Nombre = "Básica"
        With dtr
            If .Item("ID").ToString = "" Then .Item("ID") = Karve.ConfiguracionApp.Modulo_ConfiguracionApp.dameCodigoMax(db, "USER_LUPAS", "ID")
            .Item("USUARIO") = US.GStr("CODIGO")
            .Item("NOMBRE") = Nombre
            .Item("LUPA") = Me.ToString
            .Item("DEFECTO") = 1
            .Item("PUBLICA") = 0
            .Item("ULTMODI") = Date.Now.ToString("yyyyMMddhh:mm")
        End With
        Return dtr
    End Function

    Private Sub DameVista()
        If Me.DesignMode = True Then Exit Sub
        Dim VG As New VariablesGlobales.ValidateData
        Dim Id As Integer = 0
        Dim sSQL As String = " SELECT FIRST * FROM USER_LUPAS " & vbNewLine & _
                             " WHERE LUPA = " & VG.setApostrofa(Me.ToString) & vbNewLine & _
                             " AND (USUARIO = " & VG.setApostrofa(US.GStr("CODIGO")) & " OR ISNULL(PUBLICA, 0) <> 0 )" & vbNewLine & _
                             " AND ISNULL(DEFECTO, 0) <> 0 "
        _dtsVistaSel = db.fillDts(sSQL)

        If _dtsVistaSel.Tables(0).Rows.Count <> 0 Then
            Id = _dtsVistaSel.Tables(0).Rows(0).Item("ID").ToString
        End If
        sSQL = " SELECT *  " & vbNewLine & _
                " FROM USER_LUPAS_COLUMNAS   " & vbNewLine & _
                " WHERE ID_LUPA = " & Id
        _dtsVistaColsSel = db.fillDts(sSQL)

    End Sub

    Private Sub MergeColumnas()
        If Me.DesignMode = True Then Exit Sub
        Dim VG As New VariablesGlobales.ValidateData
        For Each Row As DataRow In _dtsVistaColsSel.Tables(0).Rows
            Dim dtCol As New Object
            dtCol = dgcColumns.Item(Row.Item("COLUMNA_NOMBRE"))
            With dtCol
                If Not dtCol Is Nothing Then
                    .Item = VG.getInt(Row.Item("POSICION"))
                    .IsVisible = VG.getInt(Row.Item("VISIBLE")) <> 0
                    .Width = VG.getInt(Row.Item("ANCHO"))
                End If
            End With
        Next
    End Sub

    Private Sub Grid_LanzaConsulta(Clausulas As DataGridRules) Handles Grid.LanzaConsulta
        dgrRules = Clausulas
    End Sub


    Private Sub rbAceptar_click(sender As Object, e As GridViewCellEventArgs)

    End Sub

    Private Sub Grid_OpenMenu(sender As Object, e As ContextMenuOpeningEventArgs) Handles Grid.OpenMenu
        RaiseEvent OpenMenu(sender, e)
    End Sub

    Private Sub Consulta_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        If IsOpenDialog Then
            VMenu.Enabled = True
            VGribbonMDI.Enabled = True
        End If
    End Sub

    Protected Sub LoadReg()
        Try
            'Dim antes As DateTime
            'Dim despues As TimeSpan = DateTime.Now - antes
            'antes = DateTime.Now

            Dim frm As New Bases.frmBase
            frm = OpenForm(_OpenForm)
            OpenTab(frm)

            For Each table In frm.Tablas_Edit
                For Each pk As Definiciones.PrimaryKey In table.CamposID
                    pk.CodEdit = dtsResult.Tables(0).Rows(0).Item(pk.CampoGrid).ToString
                Next
            Next

            frm.Tablas = dgtTables
            frm.Ordenes = dgoOrdenes
            frm.Reglas = dgrRules
            frm.Load_Reg()

            'despues = DateTime.Now - antes
            'MsgBox(despues.TotalMilliseconds)
        Catch
        End Try
    End Sub

    Private Sub Consulta_CintaClick(sender As Object, e As EventArgs) Handles Me.CintaClick
        If Not IsOpenDialog Then
            LoadReg()
        End If
    End Sub
End Class