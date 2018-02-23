Imports System.Windows.Forms
Imports CustomControls
Imports VariablesGlobales
Imports Karve.ConfiguracionApp
Imports Telerik.WinControls.UI
Imports Karve.Theme
Imports Karve.Definiciones
Imports System.ComponentModel

' DEPRECATED
Public Class frmBase_old
    ' SIZE = 1388; 787
    Public Sub New()
        InitializeComponent()
        fillCtrList()
    End Sub
    Dim pnl As New System.Windows.Forms.Panel
    Private Duals As New List(Of DualDatafield)


#Region "Variables"
    Const CatKarve As String = "Karve"
    Protected dtsEdit As DataSet 'dataset en el ue se encuentran todas las tablas de cabeceras que se van a actualizar, las tablas de linias se encontraran en el control
    Private mySqlEdit As String = "" 'sql usada para generar el dataset de edicion y para guardarla (no se debe modificar a  mano bajo ningun concepto)
    Protected db As New ASADB.Connection 'conexion a la bbdd

    Protected tablasEdit As New List(Of TablaEdit) 'array donde se deben indicar las tablas de cabeceras
    Private tableAlias As New ArrayList() 'se indican los alias que queremos que tengan las tablas del dataset
    Protected idEdit As String 'el ID del registro que queremos editar

    Protected tablaUltmodi As New TablaEdit 'para guardar ultmodi
    Protected tablaUsumodi As New TablaEdit 'para guardar usumodi

    Protected tablaOficina As New TablaEdit 'para guardar oficina
    Protected tablaEmpresa As New TablaEdit 'para guardar empresa

    Protected _Titulo As String
    Protected _sNombreReg As String
    Protected _sEstadoReg As String

    Private kMsgBox As New CustomControls.kMsgBox

    Protected datosIncorrectos As Boolean
    Protected mensajeIncorrectos As String
    Protected newReg As Boolean = False

    Protected dtr As DataRow
    Protected dtrIndex As String

    Protected _estado As EstadoForm = EstadoForm.Abriendo
    Protected Event EstadoChanged(estado As EstadoForm)

    Protected reportPath As String
    Protected reportWhere As String
    Protected reportName As String

    Public Event datosGuardados(ByVal sender As Object, ByVal e As EventArgs)
    Shadows Event PropertyChanged As PropertyChangedEventHandler

    Dim _Desplazamiento As New Desplazamiento(db)
    Dim _iDesplaza As Integer = 0

    Private _image As System.Drawing.Bitmap
    Private oCtrFocoControlEnAgregar As Control
    Private rbnExtra As New Object

    Protected Enum AccionForm
        Agregar
        Binding
        Limpiar
        Traduc
        Validar
        SetEvents
    End Enum

    Protected Enum EstadoForm
        Abriendo
        Agregar
        Cargando
        Editar
        Guardando
        Eliminando
        Bloqueado
        Cancelando
    End Enum

#End Region

#Region "Propiedades"

    <Category(CatKarve)> _
    Public Property NombreRegistro As String
        Get
            Return _sNombreReg
        End Get
        Set(value As String)
            _sNombreReg = Microsoft.VisualBasic.Left(value, 10) & "..."
            SetTitulo()
        End Set
    End Property

    <Category(CatKarve)> _
    Public Property Titulo As String
        Get
            Return _Titulo
        End Get
        Set(value As String)
            _Titulo = value
        End Set
    End Property

    <Category(CatKarve)> _
    Property Tablas As CustomControls.DataGridTables
        Get
            Return _Desplazamiento.Tablas
        End Get
        Set(value As CustomControls.DataGridTables)
            _Desplazamiento.Tablas = value
        End Set
    End Property

    <Category(CatKarve)> _
    Property Reglas As CustomControls.DataGridRules
        Get
            Return _Desplazamiento.Reglas
        End Get
        Set(value As CustomControls.DataGridRules)
            _Desplazamiento.Reglas = value
        End Set
    End Property

    <Category(CatKarve)> _
    Property Ordenes As CustomControls.DataGridOrdenColumnas
        Get
            Return _Desplazamiento.Ordenes
        End Get
        Set(value As CustomControls.DataGridOrdenColumnas)
            _Desplazamiento.Ordenes = value
        End Set
    End Property

    <Category(CatKarve)> _
    Protected Property Estado As EstadoForm
        Get
            Return _estado
        End Get
        Set(value As EstadoForm)
            _estado = value
            cambiarEstado()
            RaiseEvent EstadoChanged(_estado)
        End Set
    End Property

    <Category(CatKarve)> _
    Property CodigoEdicion As String
        Get
            Return idEdit
        End Get
        Set(value As String)
            idEdit = value
        End Set
    End Property

    <Category(CatKarve)> _
    ReadOnly Property CodigoRegistro As String
        Get
            Return idEdit
        End Get
    End Property

    <Category(CatKarve)> _
    Property Image As System.Drawing.Bitmap
        Get
            Return _image
        End Get
        Set(value As System.Drawing.Bitmap)
            _image = value
        End Set
    End Property

    Public Property Ribbon_Bar As CustomControls.RibbonBar
        Get
            Return rbnAction
        End Get
        Set(value As CustomControls.RibbonBar)
            rbnAction = value
        End Set
    End Property

    Public Property addTab As String
        Get
            Return ""
        End Get
        Set(value As String)
            If value <> "" Then

            End If
        End Set
    End Property

    Public ReadOnly Property Tablas_Edit As List(Of TablaEdit)
        Get
            Return tablasEdit
        End Get
    End Property

#End Region

#Region "Eventos"

    Public Event SelectedPageChanging(sender As Object, e As RadPageViewCancelEventArgs)
    Public Event SelectedPageChanged(sender As Object, e As EventArgs)

    Private Sub frmBase_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Try
            If Not blocked Then
                stopBloqueo()
            End If
            VGribbonMDI.CommandTabs.Clear()
            For Each cmdTab In VGribbonMDICopy.CommandTabs
                VGribbonMDI.CommandTabs.Add(cmdTab)
            Next
        Catch
        Finally

        End Try
    End Sub

    Private Sub frmBase_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        If Not DesignMode Then
            setTables()
            setControles()
            setLupas()
            setOpenForm()
            setIconos()
        End If
    End Sub

    Private Sub setIconos()
        If DesignMode = False Then
            Me.btnAdd.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Add_Ic)
            Me.btnSave.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Save_Ic)
            Me.btnRecargar.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Refresh_Ic)
            Me.btnDelete.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Delete_Ic)

            Me.btnPrimero.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Start_Ic)
            Me.btnAnterior.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Previus_Ic)
            Me.btnSiguiente.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Next_Ic)
            Me.btnUltimo.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.End_Ic)

            btnImprimir.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Print_Ic)
            btnMail.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Mail_Ic)
            setIconosExtra()
            ConfiguraCintaEdicion(rbnAction)
        End If
    End Sub

    Protected Overridable Sub setIconosExtra()

    End Sub

    Protected Overridable Sub setControles()

    End Sub

    Protected Overridable Sub setTables()

    End Sub

    Protected Overridable Sub setLupas()

    End Sub

    Protected Overridable Sub setOpenForm()

    End Sub

    Protected Overridable Sub Estado_Editar()

    End Sub

    Private Sub frmBase_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not DesignMode Then
            pvwBase.Hide()
            For Each page As RadPageViewPage In pvwBase.Pages
                ' sirve para precargar los controles que hay en cada página y así el binding se realize correctamente sin haver mostrado la página
                page.Show()
                page.Hide()
                page.AutoScroll = True
            Next
            pnlBlock.Location = New Drawing.Point(0, Me.Height - pnlBlock.Height)
            traducirForm()
            RecorrerForm(AccionForm.SetEvents)
        End If
    End Sub

    Private Sub frmBase_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If Not DesignMode Then
            ' añadimos un panel como cortinilla para esconder la carga de controles
            Dim pnl As New System.Windows.Forms.Panel
            Me.Controls.Add(pnl)
            pnl.Dock = DockStyle.Fill
            pnl.BringToFront()
            Try
                pvwBase.Visible = True
                pvwBase.Refresh()
                For Each page As RadPageViewPage In pvwBase.Pages
                    'sirve para redimensionar los paneles de las páginas
                    pvwBase.SelectedPage = page
                    page.Refresh()
                    tabSizeChange(page)
                Next
                ' se selecciona la primera página y se muestra
                If pvwBase.Pages.Count = 1 Then pvwBase.Pages(0).Show()
                pvwBase.SelectedPage = pvwBase.Pages(0)
                If Estado = EstadoForm.Agregar Or Estado = EstadoForm.Editar Then
                    If Not oCtrFocoControlEnAgregar Is Nothing Then oCtrFocoControlEnAgregar.Focus()
                End If
                ' quitamos la cortinilla
            Catch ex As Exception
                'MsgBox(ex.Message)
            Finally
                Me.Controls.Remove(pnl)
                Me.Refresh()
            End Try
        End If

    End Sub

    Private Sub pvwBase_SelectedPageChanged(sender As Object, e As EventArgs) Handles pvwBase.SelectedPageChanged
        RaiseEvent SelectedPageChanged(sender, e)
    End Sub

    Private Sub pvwBase_SelectedPageChanging(sender As Object, e As RadPageViewCancelEventArgs) Handles pvwBase.SelectedPageChanging
        'sizeChange() 'buscar otra manera
        RaiseEvent SelectedPageChanging(sender, e)
    End Sub

    Private Sub pvwBase_SizeChanged(sender As Object, e As EventArgs) Handles pvwBase.SizeChanged
        ' cuando el formulario cambia de tamaño hay que redibujar los paneles y ajustarlos al nuevo tamaño
        sizeChange()
    End Sub

    Private Sub sizeChange()
        For Each page As RadPageViewPage In pvwBase.Pages
            tabSizeChange(page)
        Next
        pvwBase.Refresh()
        Me.Refresh()
    End Sub

    Private Sub tabSizeChange(ByRef page As RadPageViewPage)
        If IsNothing(page) Then Exit Sub

        For Each ctr As Control In page.Controls
            If ctr.GetType Is GetType(CustomControls.Panel) Then
                If CType(ctr, CustomControls.Panel).ChangeDock Then
                    If pvwBase.Width < (930 + 125) Then
                        CType(ctr, CustomControls.Panel).Dock = DockStyle.Top
                    Else
                        CType(ctr, CustomControls.Panel).Dock = DockStyle.Left
                        ctr.Width = page.Width / 2 - 1
                    End If
                    ctr.Refresh()
                End If
            End If
        Next
        page.Refresh()
    End Sub

#End Region

#Region "Funciones de Acceso a Datos"

    'FUNCIONES DE PREPARACION DE SQL Y DATASET
    Private Sub prepareSql(ByVal codEdit As String)
        mySqlEdit = ""
        If Not IsNothing(tablasEdit) Then
            tableAlias.Clear()
            For Each table As TablaEdit In tablasEdit
                If table.CampoID <> "" And IsNothing(table.CamposID) Then
                    mySqlEdit &= "select * from " & table.Tabla & " where " & table.CampoID & " = '" & codEdit & "'" & IIf(table.ExtraWhere <> "", " and " & Replace(table.ExtraWhere, "%codEdit%", codEdit), "") & "; "
                Else
                    mySqlEdit &= "select * from " & table.Tabla & " where " '& table.CampoID & " = '" & codEdit & "'" & IIf(table.ExtraWhere <> "", " and " & Replace(table.ExtraWhere, "%codEdit%", codEdit), "") & "; "

                    Dim i As Integer = table.CamposID.Count
                    For Each pk As PrimaryKey In table.CamposID
                        mySqlEdit &= pk.CampoID & " = '" & pk.CodEdit & "'"
                        If i > 1 Then
                            mySqlEdit &= " and "
                        End If
                        i -= 1
                    Next
                    mySqlEdit &= "; "
                End If

                tableAlias.Add(table.TableAlias)
            Next
        End If
    End Sub
    Private Sub prepareSqlAgregar()
        mySqlEdit = ""
        If Not IsNothing(tablasEdit) Then
            tableAlias.Clear()
            For Each table As TablaEdit In tablasEdit
                mySqlEdit &= "select * from " & table.Tabla & " where 0 = 1; "
                tableAlias.Add(table.TableAlias)
            Next
        End If
    End Sub

    Private Sub loadDts()
        Try
            datosIncorrectos = False
            newReg = False
            mensajeIncorrectos = ""
            dtsEdit = db.fillDts(mySqlEdit, tableAlias)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    'FUNCIONES DE CARGA
    Private Sub LoadReg()
        Try
            Dim cambios As Boolean? = guardarCambios()
            If Not IsNothing(cambios) Then
                If cambios Then
                    SaveReg()
                End If
                CancelReg()
                prepareSql(idEdit)
                db.beginTransaction()
                loadDts()
                errorRF = False
                RecorrerForm(AccionForm.Binding)
                dbBlock.beginTransaction()
                checkBloqueoRegistro()
                newReg = False
                LoadExtra()
                db.commitTransaction()
                dbBlock.commitTransaction()
                loadDescrip()
                If errorRF Then
                    kMsgBox.Print("La informacion de los siguientes campos no se ha vinculado a la base de datos y no será actualizada.", _
                                  CustomControls.kMsgBox.kMsgBoxStyle.Information, msgErrorRF)
                    errorRF = False
                End If
            End If
        Catch ex As Exception
            db.rollbackTransaction()
            dbBlock.rollbackTransaction()
            kMsgBox.Print("Error al cargar los datos.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message)
        Finally
            LoadDesplazamiento()
        End Try
    End Sub
    Protected Overridable Sub LoadExtra()

    End Sub

    Protected Overridable Sub LoadDescripciones()

    End Sub

    Private Sub loadDescrip()
        Dim sqlTmp As String = ""
        Dim dtsTmp As DataSet
        Dim dualsRellenar As New List(Of DualDatafield)

        For i = 0 To Duals.Count - 1
            Try
                If Duals(i).Desc_DBTable <> "" And Duals(i).Desc_DBPK <> "" And Duals(i).Text_Data <> "" Then
                    sqlTmp &= "(select " & Duals(i).Desc_Datafield & " from " & Duals(i).Desc_DBTable & " where " & Duals(i).Desc_DBPK & " = '" & Duals(i).Text_Data & "'"
                    If Duals(i).Desc_WhereObligatoria <> "" Then sqlTmp &= " and " & Duals(i).Desc_WhereObligatoria
                    sqlTmp &= "), "
                    Duals(i).Query_on_Text_Changed = False
                    Duals(i).ReQuery = False
                    dualsRellenar.Add(Duals(i))
                End If
            Catch
            End Try
        Next

        If sqlTmp <> "" Then
            sqlTmp = " select " & sqlTmp
            sqlTmp = sqlTmp.Substring(1, sqlTmp.Length - 3)
            dtsTmp = db.fillDts(sqlTmp)

            For i = 0 To dualsRellenar.Count - 1
                Try
                    dualsRellenar(i).Text_Data_Desc = IIf(Not IsDBNull(dtsTmp.Tables(0).Rows(0).Item(i)), dtsTmp.Tables(0).Rows(0).Item(i), "")
                    dualsRellenar(i).Query_on_Text_Changed = True
                    dualsRellenar(i).ReQuery = False
                Catch
                End Try
            Next
        End If

        LoadDescripciones()
    End Sub

    Private Sub ActivaDescrip()
        For Each Ctr In Duals
            Ctr.Query_on_Text_Changed = True
        Next
    End Sub

    'FUNCIONES DE AGREGADO
    Private Sub AddReg()
        Try
            Dim cambios As Boolean? = guardarCambios()
            If Not IsNothing(cambios) Then
                If cambios Then
                    SaveReg()
                End If
                CancelReg()
                prepareSqlAgregar()
                loadDts()
                dtsEdit.EnforceConstraints = False
                For Each table As DataTable In dtsEdit.Tables
                    dtr = table.NewRow
                    table.Rows.Add(dtr)
                Next
                RecorrerForm(AccionForm.Binding)
                ActivaDescrip()
                newReg = True
                AddExtra()
            End If
        Catch ex As Exception
            kMsgBox.Print("Ha ocurrido un error inesperado.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message)
        Finally
            LoadDesplazamiento()
        End Try
    End Sub
    Protected Overridable Sub AddExtra()

    End Sub

    'FUNCIONES DE GUARDADO
    Private Sub SaveReg()
        Try
            If IsNothing(dtsEdit) Then
                Throw New Exception("Edition DTS is empty")
            End If
            ValidateBefore()
            RecorrerForm(AccionForm.Validar)
            ValidateExtra()
            If Not datosIncorrectos Then

                If newReg Then
                    Dim sSQL As String = " SELECT " & tablasEdit(0).CampoID & " FROM " & tablasEdit(0).Tabla & " WHERE " & tablasEdit(0).CampoID & " = '" & dtsEdit.Tables(tablasEdit(0).TableAlias).Rows(0).Item(tablasEdit(0).CampoID) & "'"
                    If db.executeQuery(sSQL) <> "" Then
                        kMsgBox.Print("No se pueden guardar los datos." & vbCrLf & "Ya existe un registro con el mismo codigo.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation)
                        Exit Sub
                    End If
                End If

                db.beginTransaction()
                SaveBefore(newReg)
                If newReg Then
                    errorRF = False
                    For Each table As TablaEdit In tablasEdit
                        dtsEdit.Tables(table.TableAlias).Rows(0).Item(table.CampoID) = idEdit
                    Next
                    If errorRF Then
                        kMsgBox.Print("La informacion de los siguientes campos no se ha vinculado a la base de datos y no será actualizada.", _
                                      CustomControls.kMsgBox.kMsgBoxStyle.Information, msgErrorRF)
                        errorRF = False
                    End If
                End If
                guardarUltmodi()
                db.updateDts(mySqlEdit, dtsEdit)
                SaveExtra(newReg)
                db.commitTransaction()
                If newReg Then
                    dtsEdit.EnforceConstraints = True
                    prepareSql(idEdit)
                End If
                newReg = False
                loadAfterSave()
                RaiseEvent datosGuardados(idEdit, New EventArgs)
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("CodigoRegistro"))
                dtsEdit.AcceptChanges()
                kMsgBox.Print("Datos guardados.", CustomControls.kMsgBox.kMsgBoxStyle.Information)
            Else
                If mensajeIncorrectos <> "" Then
                    kMsgBox.Print("Es necessario solucionar los problemas con los siguientes campos para guardar los datos.", CustomControls.kMsgBox.kMsgBoxStyle.Information, mensajeIncorrectos)
                End If
                datosIncorrectos = False
                mensajeIncorrectos = ""
            End If
        Catch cons As ConstraintException
            For Each row As DataRow In dtsEdit.Tables(0).GetErrors()
                For Each col As DataColumn In row.GetColumnsInError
                    MsgBox(col.ColumnName & ": " & row.GetColumnError(col))
                Next
            Next
        Catch ex As Exception
            db.rollbackTransaction()
            kMsgBox.Print("Error al guardar los datos.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message)
        End Try
    End Sub
    Private Sub guardarUltmodi()
        If ValidaTablaUltUsumodi(tablaUltmodi) Then dtsEdit.Tables(tablaUltmodi.TableAlias).Rows(0).Item(tablaUltmodi.CampoID) = Date.Now.ToString("yyyyMMddhh:mm")
        If ValidaTablaUltUsumodi(tablaUsumodi) Then dtsEdit.Tables(tablaUsumodi.TableAlias).Rows(0).Item(tablaUsumodi.CampoID) = US.GStr("CODIGO")
    End Sub

    Private Function ValidaTablaUltUsumodi(TB As TablaEdit) As Boolean
        Dim ok As Boolean
        If Not IsNothing(TB) Then
            With TB
                ok = VD.getString(.TableAlias) <> "" And VD.getString(.CampoID) <> ""
            End With
        End If
        Return ok
    End Function

    Protected Overridable Sub SaveExtra(ByVal newReg As Boolean)

    End Sub
    Protected Overridable Sub SaveBefore(ByVal newReg As Boolean)

    End Sub
    Protected Overridable Sub loadAfterSave()

    End Sub
    Protected Overridable Sub ValidateBefore()

    End Sub
    Protected Overridable Sub ValidateExtra()

    End Sub

    'FUNCIONES DE CANCELACION
    Private Sub CancelReg()
        Try
            RecorrerForm(AccionForm.Limpiar)
            dtsEdit = Nothing
            mySqlEdit = ""
            CancelExtra()
        Catch ex As Exception
            kMsgBox.Print("Ha ocurrido un error inesperado", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message)
        End Try
    End Sub
    Protected Overridable Sub CancelExtra()

    End Sub

    'FUNCIONES DE ELIMINACION
    Private Sub DeleteReg()
        Try
            db.beginTransaction()
            For Each table As DataTable In dtsEdit.Tables
                table.Rows(0).Delete()
            Next
            Me.BindingContext(dtsEdit).EndCurrentEdit()
            DeleteBefore()
            db.updateDts(mySqlEdit, dtsEdit)
            DeleteExtra()
            db.commitTransaction()
            CancelReg()
            stopBloqueo()
        Catch ex As Exception
            db.rollbackTransaction()
            kMsgBox.Print("Error al borrar los datos.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message)
        End Try
    End Sub
    Protected Overridable Sub DeleteBefore()

    End Sub
    Protected Overridable Sub DeleteExtra()

    End Sub

    'FUNCIONES AUXILIARES
    Private Function guardarCambios() As Boolean?
        If IsNothing(dtsEdit) Then
            Return False
        End If
        If dtsEdit.HasChanges() Or getExtraChanges() Then
            kMsgBox.Print("Desea guardar los cambios antes de continuar?", CustomControls.kMsgBox.kMsgBoxStyle.Question)
            If kMsgBox.DialogResult = Windows.Forms.DialogResult.Yes Then
                Return True
            ElseIf kMsgBox.DialogResult = Windows.Forms.DialogResult.No Then
                Return False
            ElseIf kMsgBox.DialogResult = Windows.Forms.DialogResult.Cancel Then
                Return Nothing
            End If
        End If
        Return False
    End Function
    Protected Overridable Function getExtraChanges() As Boolean
        Return False
    End Function

    Protected Sub reBind()
        RecorrerForm(AccionForm.Binding)
        loadDescrip()
    End Sub

    Protected Sub limpiar()
        RecorrerForm(AccionForm.Limpiar)
    End Sub
#End Region 'FUNCIONA CORRECTAMENTE CON LOS CONTROLES EXISTENTES

#Region "Recorrer Controles"
    Private msgErrorRF As String
    Private errorRF As Boolean = False

    Private Sub RecorrerForm(ByVal accion As AccionForm, Optional ByRef ctrList As Object = Nothing)
        Try
            If IsNothing(ctrList) Then
                ctrList = Me.Controls
            End If
            For Each ctr In ctrList
                If ctr.GetType() Is GetType(TabControl) Then 'si es un tab control se recorre los tabs
                    For Each tmp In CType(ctr, TabControl).TabPages
                        RecorrerForm(accion, tmp.Controls)
                    Next

                ElseIf ctr.GetType() Is GetType(RadPageView) Then 'si es un page view se recorre las páginas
                    For Each page As RadPageViewPage In CType(ctr, RadPageView).Pages
                        RecorrerForm(accion, page.Controls)
                    Next

                ElseIf ControlesDataField(ctr) Then  'Si pertenece a la lista de custom controls
                    AccionControl(accion, ctr) 'realiza la accion
                    If ctr.GetType() Is GetType(CustomControls.RadioGroup) Then 'si es un radiogroup tambien se recorre los controles que contenga
                        RecorrerForm(accion, ctr.Controls)
                    End If

                Else 'si no se sigue recorriendo los controles
                    RecorrerForm(accion, ctr.Controls)

                End If
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private ctrList As New List(Of Type)
    Private ctrWRibbonList As New List(Of Type)

    Private Sub fillCtrList()
        ctrList.Add(GetType(Datafield))
        ctrList.Add(GetType(DatafieldLabel))
        ctrList.Add(GetType(DataFieldLabelColor))
        ctrList.Add(GetType(DualDatafield))
        ctrList.Add(GetType(DualDatafieldLabel))
        ctrList.Add(GetType(DualDataFieldEditable))
        ctrList.Add(GetType(DualDataFieldEditableLabel))
        ctrList.Add(GetType(DataCheck))
        ctrList.Add(GetType(RadioGroup))
        ctrList.Add(GetType(DataArea))
        ctrList.Add(GetType(DataAreaLabel))
        ctrList.Add(GetType(DataDate))
        ctrList.Add(GetType(DataDateLabel))
        ctrList.Add(GetType(DataTime))
        ctrList.Add(GetType(DataTimeLabel))
        ctrList.Add(GetType(DataDir))
        ctrList.Add(GetType(DataLabel))
        ctrList.Add(GetType(EmpresaOficina))
        ctrList.Add(GetType(MaskedDataField))

        ctrWRibbonList.Add(GetType(DataArea))
        ctrWRibbonList.Add(GetType(DataAreaLabel))
    End Sub 'AÑADIR AQUI LOS NUEVOS CONTROLES

    Private Function ControlesDataField(ByRef ctr As Control) As Boolean
        Return ctrList.Contains(ctr.GetType)
    End Function

    Public Function Controles_DataField(ByRef ctr As Control)
        Return ControlesDataField(ctr)
    End Function


    Private Sub AccionControl(ByVal accion As AccionForm, ByRef ctr As Control)
        Select Case accion
            Case AccionForm.Agregar

            Case AccionForm.Binding
                Binding(ctr)
            Case AccionForm.Limpiar
                limpiar(ctr)
            Case AccionForm.Traduc
                Traduc(ctr)
            Case AccionForm.Validar
                Validar(ctr)
            Case AccionForm.SetEvents
                SetEvents(ctr)
                SetControlFoco(ctr)
        End Select
    End Sub

    Private Sub Binding(ByRef ctr As Control)
        Try
            If ctr.GetType() Is GetType(DualDatafield) Or ctr.GetType() Is GetType(DualDatafieldLabel) Then
                Dim ctrTmp As DualDatafield = CType(ctr, DualDatafield)
                ctrTmp.DB = db
                ctrTmp.Query_on_Text_Changed = False
                Duals.Add(ctrTmp)
            End If

            CObj(ctr).setBinding(dtsEdit)
        Catch ex As Exception
            errorRF = True
            msgErrorRF &= "- " & CObj(ctr).Descripcion & ": " & ex.Message & vbCrLf
        End Try
    End Sub

    Private Sub Limpiar(ByRef ctr As Control)
        Try
            CObj(ctr).Clear()
        Catch ex As Exception
            errorRF = True
            msgErrorRF &= "- " & CObj(ctr).Descripcion & ": " & ex.Message & vbCrLf
        End Try
    End Sub

    Private Sub Validar(ByRef ctr As Control)
        Try
            CObj(ctr).EndEdit()
            CObj(ctr).Validar()
            If CObj(ctr).Incorrecto Then
                datosIncorrectos = True
                Try
                    mensajeIncorrectos &= CObj(ctr).Descripcion & ": "
                Catch
                End Try
                mensajeIncorrectos &= CObj(ctr).MensajeIncorrecto & vbCrLf
            End If
        Catch ex As Exception
            errorRF = True
            msgErrorRF &= "- " & CObj(ctr).Descripcion & ": " & ex.Message & vbCrLf
        End Try
    End Sub

    Private Sub Traduc(ByRef ctr As Control)
        Try
            CObj(ctr).traduc()
        Catch
        End Try
    End Sub ' Intentara llamar a la funcion traduc de todos los controles de la pantalla

    Private Sub SetEvents(ByRef ctr As Control)
        If ctrWRibbonList.Contains(ctr.GetType) Then
            AddHandler CType(ctr, Control).Enter, AddressOf setRibbon
        Else
            AddHandler CType(ctr, Control).Enter, AddressOf clearRibbon
        End If
    End Sub

    Private Sub SetControlFoco(ByRef ctr As Control)
        Try
            If Not oCtrFocoControlEnAgregar Is Nothing Then Exit Sub
            If ControlesDataField(ctr) Then
                If CType(ctr, ctrBase).FocoEnAgregar Then
                    oCtrFocoControlEnAgregar = ctr
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub setRibbon(sender As Object, e As EventArgs)
        Try
            clearRibbon(sender, e)
            Dim selectedTab As RibbonTab = Nothing
            rbnExtra = CType(sender, CustomControls.DataRichField).getRibbon
            For Each cmdTab As RibbonTab In rbnExtra.CommandTabs
                Try
                    VGribbonMDI.CommandTabs.Add(cmdTab)
                    If cmdTab.Tag = 1 Then selectedTab = cmdTab
                Catch
                End Try
            Next
            Try
                selectedTab.IsSelected = True
            Catch
            End Try
        Catch
        End Try
    End Sub

    Private Sub clearRibbon(sender As Object, e As EventArgs)
        Try
            For Each cmdTab In rbnExtra.CommandTabs
                Try
                    VGribbonMDI.CommandTabs.Remove(cmdTab)
                Catch
                End Try
            Next
        Catch
        End Try
    End Sub

#End Region 'FUNCIONA CORRECTAMENTE CON LOS CONTROLES EXISTENTES

#Region "Accion Form"

    Private Sub frmBase_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.S Then
            Save_Reg()
        ElseIf e.Control And e.KeyCode = Keys.N Then
            Add_Reg()
        ElseIf e.Control And e.KeyCode = Keys.W Then
            Me.Close()
        ElseIf e.Control And e.KeyCode = Keys.Delete Then
            Delete_Reg()
        ElseIf e.Control And e.KeyCode = Keys.R Then
            UndoReg()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            PrintReg()
        ElseIf e.Control And e.KeyCode = Keys.PageUp Then
            NextReg()
        ElseIf e.Control And e.KeyCode = Keys.PageDown Then
            BackReg()
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Save_Reg()
    End Sub
    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        UndoReg()
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Add_Reg()
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Delete_Reg()
    End Sub

    Private Sub frmBase_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim cambios As Boolean? = guardarCambios()
        If Not IsNothing(cambios) Then
            If cambios Then
                Save_Reg()
            End If
            Cancel_Reg()
        Else
            e.Cancel = True
        End If
    End Sub

    Public Sub Load_Reg()
        If Estado <> EstadoForm.Cargando Then
            Estado = EstadoForm.Cargando
            reloadBloqueos()

            LoadReg()

            If Estado <> EstadoForm.Bloqueado Then Estado = EstadoForm.Editar
        End If
    End Sub
    Public Sub Add_Reg()
        Estado = EstadoForm.Cargando
        reloadBloqueos()
        AddReg()
        Estado = EstadoForm.Agregar
    End Sub
    Protected Sub Save_Reg()
        If Estado <> EstadoForm.Guardando And Estado <> EstadoForm.Bloqueado Then
            If Not blocked Then
                Estado = EstadoForm.Guardando
                SaveReg()
                If newReg Then
                    Estado = EstadoForm.Agregar
                Else
                    Estado = EstadoForm.Editar
                End If
            Else
                kMsgBox.Print("No puede Guardar." & vbCrLf & "El registro esta bloqueado.", CustomControls.kMsgBox.kMsgBoxStyle.Information)
            End If
        End If
    End Sub
    Protected Sub Cancel_Reg()
        If Estado <> EstadoForm.Cancelando Then
            stopBloqueo()
            Me.Estado = EstadoForm.Cancelando
            CancelReg()
        End If
    End Sub
    Protected Sub Delete_Reg()
        If Estado <> EstadoForm.Eliminando And Estado <> EstadoForm.Bloqueado Then
            If Not blocked Then
                Estado = EstadoForm.Eliminando
                DeleteReg()
            Else

            End If
        End If
    End Sub

    Private Sub NextReg()

    End Sub
    Private Sub BackReg()

    End Sub
    Private Sub PrintReg()

    End Sub
    Private Sub UndoReg()
        Try
            If IsNothing(dtsEdit) Then
                Exit Sub
            End If
            If dtsEdit.HasChanges() Or getExtraChanges() Then
                kMsgBox.Print("Desea desacer los cambios?", CustomControls.kMsgBox.kMsgBoxStyle.Question)
                If kMsgBox.DialogResult = Windows.Forms.DialogResult.Yes Then
                    dtsEdit.RejectChanges()
                    UndoExtra()
                End If
            Else
                kMsgBox.Print("No ha habido cambios.", CustomControls.kMsgBox.kMsgBoxStyle.Information)
            End If
        Catch ex As Exception
            kMsgBox.Print("Error inesperado.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message)
        End Try
    End Sub
    Protected Overridable Sub UndoExtra()
    End Sub

#Region "Traduccion"
    Private Sub traducirForm()
        If US.GStr("idiomaprg") <> "" Then
            Try
                Me.Text = Translate(Me.Text)
                _Titulo = Me.Text
                For Each page As RadPageViewPage In pvwBase.Pages
                    page.Text = Translate(page.Text)
                Next
                RecorrerForm(AccionForm.Traduc)
                blockInfo.traduc()
                traducirRibbon()
                traducirExtra()
            Catch ex As Exception
                kMsgBox.Print("Ha ocurrido un error durante la traducción.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message)
            End Try
        End If

    End Sub

    Private Sub traducirRibbon()
        For Each cmdTab As RibbonTab In rbnAction.CommandTabs
            For Each rbg As RadRibbonBarGroup In cmdTab.Items
                For Each btn As RadButtonElement In rbg.Items
                    btn.Text = Translate(btn.Text)
                Next
                rbg.Text = Translate(rbg.Text)
            Next
            cmdTab.Text = Translate(cmdTab.Text)
        Next
    End Sub

    Protected Overridable Sub traducirExtra()

    End Sub
#End Region

#End Region

#Region "Estado Form"
    Private Sub cambiarEstado()
        Select Case _estado
            Case EstadoForm.Agregar
                estadoAgregar()
            Case EstadoForm.Cargando
                estadoBloqueado()
            Case EstadoForm.Editar
                estadoEditar()
            Case EstadoForm.Guardando
                estadoBloqueado()
            Case EstadoForm.Eliminando
                estadoBloqueado()
            Case EstadoForm.Bloqueado
                estadoBloqueado()
            Case EstadoForm.Cancelando
                estadoBloqueado()
        End Select
    End Sub

    Private Sub estadoAgregar()
        btnSave.Enabled = True
        btnDelete.Enabled = False
        _sEstadoReg = "Agregar"
        If Not oCtrFocoControlEnAgregar Is Nothing Then oCtrFocoControlEnAgregar.Focus()
        SetTitulo()
    End Sub

    Private Sub SetTitulo()
        If Me.Name <> "cargaControles" Then
            If IsNothing(_sEstadoReg) And Not IsNothing(tablasEdit(0).CamposID) Then
                _sEstadoReg = ""
                Dim i As Integer = tablasEdit(0).CamposID.Count
                For Each pk As PrimaryKey In tablasEdit(0).CamposID
                    _sEstadoReg &= pk.CodEdit
                    If i > 1 Then
                        _sEstadoReg &= " - "
                    End If
                    i -= 1
                Next
            End If
            Me.Text = _Titulo & vbNewLine & "[" & _sEstadoReg & "]. " & _sNombreReg
            If VGdockMDI.ActiveWindow.ActiveControl Is Nothing Then Exit Sub
            If Me.Name = VGdockMDI.ActiveWindow.ActiveControl.Name Then VGdockMDI.ActiveWindow.Text = Me.Text
        End If
    End Sub

    Private Sub estadoEditar()
        btnSave.Enabled = True
        btnDelete.Enabled = True
        If Not oCtrFocoControlEnAgregar Is Nothing Then oCtrFocoControlEnAgregar.Focus()
        _sEstadoReg = idEdit
        SetTitulo()
        Estado_Editar()
    End Sub

    Private Sub estadoBloqueado()
        btnSave.Enabled = False
        btnDelete.Enabled = False

        _sEstadoReg = idEdit
        SetTitulo()
        estadoEditar()
    End Sub

    Public Sub AgregarReg()
        Add_Reg()
    End Sub

#End Region 'A MEDIAS

#Region "Bloqueo de Registro"
    Private dbBlock As New ASADB.Connection
    Private dtsBlock As New DataSet
    Private mySqlBlock As String
    Private blocked As Boolean = False
    Public WithEvents blockInfo As New pnlBloqueo

    Private Sub checkBloqueoRegistro()
        mySqlBlock = "select NOMBRE, INICIO from CONTROL_BLOQUEO_REGISTROS as C inner join USURE as U on C.USUARIO = U.CODIGO " & _
            "where C.TABLA = '" & tablasEdit(0).Tabla & "' and C.REGISTRO = '" & idEdit & "'"
        dtsBlock = dbBlock.fillDts(mySqlBlock)
        If dtsBlock.Tables(0).Rows.Count = 0 Then
            strBloqueo()
            tmrUpdBloqueo.Start()
        Else
            blockedMode()
            tmrChkBloqueo.Start()
        End If
    End Sub

    Private Sub strBloqueo()
        Dim insert As String = "insert into CONTROL_BLOQUEO_REGISTROS " & _
                                "(TABLA, REGISTRO, USUARIO, INICIO, CONTROL) values " & _
                                "('" & tablasEdit(0).Tabla & "', '" & idEdit & "', '" & US.GStr("CODIGO") & "', getdate(), getdate())"
        dbBlock.executeDirect(insert)
    End Sub
    Private Sub updBloqueo()
        Dim update As String = "update CONTROL_BLOQUEO_REGISTROS " & _
                                "set CONTROL = getdate() " & _
                                "where tabla = '" & tablasEdit(0).Tabla & "' and registro = '" & idEdit & "'"
        dbBlock.executeDirect(update)
    End Sub
    Private Sub stopBloqueo()
        If Estado <> EstadoForm.Bloqueado And Not IsNothing(dtsEdit) Then
            tmrChkBloqueo.Stop()
            Dim delete As String = "delete from CONTROL_BLOQUEO_REGISTROS " & _
                                  "where tabla = '" & tablasEdit(0).Tabla & "' and registro = '" & idEdit & "'"
            dbBlock.executeDirect(delete)
        End If
    End Sub

    Private Sub chkBloqueo()
        dtsBlock = dbBlock.fillDts(mySqlBlock)
        If dtsBlock.Tables(0).Rows.Count = 0 Then
            editMode()
        Else
            blockedMode()
        End If
    End Sub

    Private Sub tmrChkBloqueo_Tick(sender As Object, e As EventArgs) Handles tmrChkBloqueo.Tick
        chkBloqueo()
    End Sub
    Private Sub tmrUpdBloqueo_Tick(sender As Object, e As EventArgs) Handles tmrUpdBloqueo.Tick
        updBloqueo()
    End Sub

    Private Sub blockedMode()

        Estado = EstadoForm.Bloqueado
        blockInfo.blockMode()
        blockInfo.Usuario = dtsBlock.Tables(0).Rows(0).Item("NOMBRE")
        blockInfo.Desde = dtsBlock.Tables(0).Rows(0).Item("INICIO")
        pnlBlock.Controls.Add(blockInfo)
    End Sub
    Private Sub editMode()
        blockInfo.editMode()
    End Sub

    Private Sub blockInfo_enterEditMode() Handles blockInfo.enterEditMode
        reloadBloqueos()
        Load_Reg()
        btnSave.Enabled = True
    End Sub

    Private Sub reloadBloqueos()
        tmrChkBloqueo.Stop()
        tmrUpdBloqueo.Stop()
        Try
            pnlBlock.Controls.Remove(blockInfo)
        Catch
        End Try
    End Sub

#End Region 'FUNCIONA CORRECTAMENTE

#Region "   .   Configuracion Cinta.  "



#End Region

#Region "   .   Función Desplazamiento.  "

    Public Sub LoadDesplazamiento()
        If _Desplazamiento.Tablas.ToArray.Count <> 0 Then
            Dim _Pk As String = DamePk()
            _Desplazamiento.ClaveBuscar = _Pk
            _iDesplaza = _Desplazamiento.RegistroActual(CodigoEdicion)
        End If
        Me.btnPrimero.Enabled = _iDesplaza <> 0
        Me.btnAnterior.Enabled = _iDesplaza <> 0
        Me.btnSiguiente.Enabled = _iDesplaza <> 0
        Me.btnUltimo.Enabled = _iDesplaza <> 0

    End Sub

    Private Function DamePk() As String
        Dim TBL As New DataGridTable
        Dim _Pk As String = ""
        TBL = _Desplazamiento.Tablas.ToArray.Item(0)
        If TBL.AliasTabla <> "" Then _Pk = TBL.AliasTabla & "."
        _Pk = _Pk & tablasEdit(0).CampoID
        Return _Pk
    End Function

    Private Sub Desplaza_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dim sCod As String = ""
        Select Case sender.name
            Case "btnPrimero" : sCod = _Desplazamiento.Primero
            Case "btnAnterior" : sCod = _Desplazamiento.Anterior
            Case "btnSiguiente" : sCod = _Desplazamiento.Siguiente
            Case "btnUltimo" : sCod = _Desplazamiento.Ultimo
        End Select
        If CodigoEdicion <> sCod And sCod <> "" Then
            Cancel_Reg()
            CodigoEdicion = sCod
            Load_Reg()
        End If
    End Sub

#End Region

#Region "Crystal Reports"
    Protected Overridable Sub setCrystalProperties()

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim frm As New RadForm

        frm = OpenForm("Karve.CrystalPreview.CrystalViewer")
        setCrystalProperties()
        CType(frm, Karve.CrystalPreview.CrystalViewer).reportPath = reportPath '"euros/Factura.rpt"
        CType(frm, Karve.CrystalPreview.CrystalViewer).reportWhere = reportWhere '"{F.NUMERO_FAC} = 'C100000141'"
        CType(frm, Karve.CrystalPreview.CrystalViewer).reportName = reportName '"Factura_C100000141"
        OpenTab(frm)
    End Sub

    Private Sub bntMail_Click(sender As Object, e As EventArgs) Handles btnMail.Click
        Dim frm As New RadForm

        frm = OpenForm("Karve.EnvioMail.EnvioMail")
        setCrystalProperties()
        CType(frm, Karve.EnvioMail.EnvioMail).reportPath = reportPath '"euros/Factura.rpt"
        CType(frm, Karve.EnvioMail.EnvioMail).reportWhere = reportWhere '"{F.NUMERO_FAC} = 'C100000141'"
        CType(frm, Karve.EnvioMail.EnvioMail).reportName = reportName '"Factura_C100000141"
        OpenTab(frm)
    End Sub
#End Region

End Class