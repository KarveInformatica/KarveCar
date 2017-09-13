Imports System.Windows.Forms
Imports CustomControls
Imports VariablesGlobales

Public Class pnlBase
#Region "Variables"
    Private dtsEdit As DataSet
    Private mySqlEdit As String = ""
    Protected db As New ASADB.Connection

    Public tablasEdit As New ArrayList()
    Public idEdit As String = ""
    Public campoId As String = ""

    Public campoOficina As String = ""
    Public tablaOficina As Integer = 0
    Public campoEmpresa As String = ""
    Public tablaEmpresa As Integer = 0
    Public campoUltmodi As String = ""
    Public tablaUltmodi As Integer = 0
    Public campoUsusmodi As String = ""
    Public tablaUsumodi As Integer = 0

    Private msgBoxError As New VariablesGlobales.MsgBoxError

    Private datosIncorrectos As Boolean
    Private mensajeIncorrectos As String
    Private newReg As Boolean = False

    Private dtr As DataRow
    Private dtrIndex As Integer

    Private Enum AccionForm
        Agregar
        Binding
        Limpiar
        Traduc
        Validar
    End Enum
#End Region

#Region "Propiedades"
#End Region

#Region "Funciones de Acceso a Datos"
    Private Sub prepareSql(ByVal campoEdit As String, ByVal codEdit As String)
        mySqlEdit = ""
        If Not IsNothing(tablasEdit) Then
            For Each tabla As String In tablasEdit
                mySqlEdit &= "select * from " & tabla & " where " & campoEdit & " = '" & codEdit & "'; "
            Next
        End If
    End Sub

    Private Sub loadDts()
        Try
            datosIncorrectos = False
            newReg = False
            mensajeIncorrectos = ""
            dtsEdit = db.fillDts(mySqlEdit)
        Catch ex As Exception
            msgBoxError.Print("Error al cargar los datos.", ex.Message)
        End Try
    End Sub

    Public Sub LoadReg()
        Try
            prepareSql(campoId, idEdit)
            RecorrerForm(AccionForm.Limpiar)
            loadDts()
            RecorrerForm(AccionForm.Binding)
            newReg = False
            LoadExtra()
        Catch ex As Exception
            msgBoxError.Print("Error al cargar los datos.", ex.Message)
        End Try
    End Sub
    Protected Overridable Sub LoadExtra()

    End Sub

    Public Sub AddReg()
        prepareSql("0", "1")
        RecorrerForm(AccionForm.Limpiar)
        loadDts()
        newReg = True
        AddExtra()
    End Sub
    Protected Overridable Sub AddExtra()

    End Sub

    Public Sub SaveReg()
        Try
            If IsNothing(dtsEdit) Then
                Throw New Exception("Edition DTS is empty")
            End If
            RecorrerForm(AccionForm.Validar)
            If Not datosIncorrectos Then
                db.beginTransaction()
                SaveBefore(newReg)
                If newReg Then
                    Dim i = 0
                    For Each table As DataTable In dtsEdit.Tables
                        dtr = table.NewRow
                        dtrIndex = i
                        dtr.Item(campoId) = idEdit
                        RecorrerForm(AccionForm.Agregar)
                        table.Rows.Add(dtr)
                        i += 1
                    Next
                End If
                db.updateDts(mySqlEdit, dtsEdit)
                SaveExtra(newReg)
                db.commitTransaction()
                newReg = False
                MsgBox("Datos guardados.", MsgBoxStyle.Information, "Karve")
            Else
                msgBoxError.Print("Es necessario solucionar los problemas con los siguientes campos para guardar los datos.", mensajeIncorrectos, "Advertencia")
                datosIncorrectos = False
                mensajeIncorrectos = ""
            End If
        Catch ex As Exception
            db.rollbackTransaction()
            msgBoxError.Print("Error al guardar los datos.", ex.Message)
        End Try
    End Sub
    Protected Overridable Sub SaveExtra(ByVal newReg As Boolean)

    End Sub
    Protected Overridable Sub SaveBefore(ByVal newReg As Boolean)

    End Sub

    Public Sub CancelReg()
        RecorrerForm(AccionForm.Limpiar)
        dtsEdit = Nothing
        mySqlEdit = ""
        CancelExtra()
    End Sub
    Protected Overridable Sub CancelExtra()

    End Sub

    Public Sub DeleteReg()
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
            RecorrerForm(AccionForm.Limpiar)
        Catch ex As Exception
            db.rollbackTransaction()
            msgBoxError.Print("Error al borrar los datos.", ex.Message)
        End Try
    End Sub
    Protected Overridable Sub DeleteBefore()

    End Sub
    Protected Overridable Sub DeleteExtra()

    End Sub
#End Region

#Region "Recorrer Controles"
    Private Sub RecorrerForm(ByVal accion As AccionForm, Optional ByRef ctrList As ControlCollection = Nothing)
        Try
            If IsNothing(ctrList) Then
                ctrList = Me.Controls
            End If
            For Each ctr In ctrList
                If ctr.GetType() Is GetType(TabControl) Then
                    For Each tmp In CType(ctr, TabControl).TabPages
                        RecorrerForm(accion, tmp.Controls)
                    Next
                ElseIf ctr.GetType() Is GetType(CustomControls.GroupBox) Or ctr.GetType() Is GetType(CustomControls.Panel) Then
                    RecorrerForm(accion, ctr.Controls)
                Else
                    Select Case accion
                        Case AccionForm.Agregar
                            Agregar(ctr)
                        Case AccionForm.Binding
                            Binding(ctr)
                        Case AccionForm.Limpiar
                            Limpiar(ctr)
                        Case AccionForm.Traduc
                            Traduc(ctr)
                        Case AccionForm.Validar
                            Validar(ctr)
                    End Select
                End If
            Next
        Catch ex As Exception
            msgBoxError.Print("Error inesperado.", ex.Message)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub Agregar(ctr As Control)
        If ctr.GetType() Is GetType(Datafield) Or ctr.GetType() Is GetType(DatafieldLabel) Or ctr.GetType() Is GetType(DualDatafield) Or ctr.GetType() Is GetType(DualDatafieldLabel) Then
            If CType(ctr, Datafield).DataTable = dtrIndex Then
                dtr.Item(CType(ctr, Datafield).DataField) = CType(ctr, Datafield).Text_Data
            End If
        ElseIf ctr.GetType() Is GetType(DataCheck) Then
            If CType(ctr, DataCheck).DataTable = dtrIndex Then
                dtr.Item(CType(ctr, DataCheck).DataField) = CType(ctr, DataCheck).Value
            End If
        ElseIf ctr.GetType() Is GetType(RadioGroup) Then
            If CType(ctr, RadioGroup).DataTable = dtrIndex Then
                dtr.Item(CType(ctr, RadioGroup).DataField) = CType(ctr, RadioGroup).Index
            End If
        ElseIf ctr.GetType() Is GetType(DataArea) Or ctr.GetType() Is GetType(DataAreaLabel) Then
            If CType(ctr, DataArea).DataTable = dtrIndex Then
                dtr.Item(CType(ctr, DataArea).DataField) = CType(ctr, DataArea).Text_Data
            End If
        ElseIf ctr.GetType() Is GetType(DataDate) Or ctr.GetType() Is GetType(DataDateLabel) Then
            If CType(ctr, DataDate).DataTable = dtrIndex Then
                    dtr.Item(CType(ctr, DataDate).DataField) = CType(ctr, DataDate).Value_Data
                End If
        End If
    End Sub

    Private Sub Binding(ctr As Control)
        If ctr.GetType() Is GetType(Datafield) Or ctr.GetType() Is GetType(DatafieldLabel) Then
            CType(ctr, Datafield).setBinding(dtsEdit)
        ElseIf ctr.GetType() Is GetType(DualDatafield) Or ctr.GetType() Is GetType(DualDatafieldLabel) Then
            CType(ctr, DualDatafield).setBinding(dtsEdit)
        ElseIf ctr.GetType() Is GetType(DataCheck) Then
            CType(ctr, DataCheck).setBinding(dtsEdit)
        ElseIf ctr.GetType() Is GetType(RadioGroup) Then
            CType(ctr, RadioGroup).setBinding(dtsEdit)
        ElseIf ctr.GetType() Is GetType(DataArea) Or ctr.GetType() Is GetType(DataAreaLabel) Then
            CType(ctr, DataArea).setBinding(dtsEdit)
        ElseIf ctr.GetType() Is GetType(DataDate) Or ctr.GetType() Is GetType(DataDateLabel) Then
            CType(ctr, DataDate).setBinding(dtsEdit)
        End If
    End Sub

    Private Sub Limpiar(ctr As Control)
        If ctr.GetType() Is GetType(Datafield) Or ctr.GetType() Is GetType(DatafieldLabel) Then
            CType(ctr, Datafield).Clear()
        ElseIf ctr.GetType() Is GetType(DualDatafield) Or ctr.GetType() Is GetType(DualDatafieldLabel) Then
            CType(ctr, DualDatafield).Clear()
        ElseIf ctr.GetType() Is GetType(DataCheck) Then
            CType(ctr, DataCheck).Clear()
        ElseIf ctr.GetType() Is GetType(RadioGroup) Then
            CType(ctr, RadioGroup).Clear()
        ElseIf ctr.GetType() Is GetType(DataArea) Or ctr.GetType() Is GetType(DataAreaLabel) Then
            CType(ctr, DataArea).Clear()
        ElseIf ctr.GetType() Is GetType(DataDate) Or ctr.GetType() Is GetType(DataDateLabel) Then
            CType(ctr, DataDate).Clear()
        End If
    End Sub

    Private Sub Validar(ctr As Control)
        If ctr.GetType() Is GetType(Datafield) Or ctr.GetType() Is GetType(DatafieldLabel) Then
            CType(ctr, Datafield).EndEdit()
            CType(ctr, Datafield).Validar()
            If CType(ctr, Datafield).Incorrecto Then
                datosIncorrectos = True
                mensajeIncorrectos &= CType(ctr, Datafield).Descripcion & ": " & CType(ctr, Datafield).MensajeIncorrecto & vbCrLf
            End If
        ElseIf ctr.GetType() Is GetType(DualDatafield) Or ctr.GetType() Is GetType(DualDatafieldLabel) Then
            CType(ctr, DualDatafield).EndEdit()
            CType(ctr, DualDatafield).Validar()
            If CType(ctr, DualDatafield).Incorrecto Then
                datosIncorrectos = True
                mensajeIncorrectos &= CType(ctr, DualDatafield).Descripcion & ": " & CType(ctr, DualDatafield).MensajeIncorrecto & vbCrLf
            End If
        ElseIf ctr.GetType() Is GetType(DataArea) Or ctr.GetType() Is GetType(DataAreaLabel) Then
            CType(ctr, DataArea).EndEdit()
            CType(ctr, DataArea).Validar()
            If CType(ctr, DataArea).Incorrecto Then
                datosIncorrectos = True
                mensajeIncorrectos &= CType(ctr, DataArea).Descripcion & ": " & CType(ctr, DataArea).MensajeIncorrecto & vbCrLf
            End If
        ElseIf ctr.GetType() Is GetType(DataDate) Or ctr.GetType() Is GetType(DataDateLabel) Then
            CType(ctr, DataDate).EndEdit()
            CType(ctr, DataDate).Validar()
            If CType(ctr, DataDate).Incorrecto Then
                datosIncorrectos = True
                mensajeIncorrectos &= CType(ctr, DataDate).Descripcion & ": " & CType(ctr, DataDate).MensajeIncorrecto & vbCrLf
            End If
        End If
    End Sub

    Private Sub Traduc(ctr As Control)
        If ctr.GetType() Is GetType(DatafieldLabel) Then

        ElseIf ctr.GetType() Is GetType(DualDatafieldLabel) Then

        ElseIf ctr.GetType() Is GetType(DataCheck) Then

        ElseIf ctr.GetType() Is GetType(DataAreaLabel) Then

        ElseIf ctr.GetType() Is GetType(RadioGroup) Then

        End If
    End Sub

#End Region
End Class
