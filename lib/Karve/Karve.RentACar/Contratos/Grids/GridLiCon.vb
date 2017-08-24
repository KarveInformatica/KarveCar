Imports Telerik.WinControls.UI
Imports Karve.Logic
Imports Karve.ConfiguracionApp
Imports VariablesGlobales

Public Class GridLiCon
    Inherits CustomControls.DataGrid

#Region "Variables"
    Private operLineas As New OperacionesLineas
    Private _bases As New DataTable
    Private _bruto As Double
    Private dtaCalculos As New DataTable
    Private i As Integer = 1

    Public Event TotalesChanged()

    Private _grupo As String
    Private _tarifa As String
#End Region

#Region "Propiedades"
    Property Grupo As String
        Get
            Return _grupo
        End Get
        Set(value As String)
            _grupo = value
        End Set
    End Property

    Property Tarifa As String
        Get
            Return _tarifa
        End Get
        Set(value As String)
            _tarifa = value
        End Set
    End Property

    ReadOnly Property Bases As DataTable
        Get
            _bases = operLineas.calculaBases(dtaCalculos)
            Return _bases
        End Get
    End Property

    ReadOnly Property Bruto As Double
        Get
            _bruto = operLineas.calculaBruto(dtaCalculos)
            Return _bruto
        End Get
    End Property

    ReadOnly Property Base As Double
        Get
            Return VD.getDouble(operLineas.calculaBases(dtaCalculos).Compute("SUM(Base)", ""))
        End Get
    End Property

#End Region

    Protected Overrides Sub DefineGrid()

        Dim definition As New Definiciones.defGridLicon

        dgcColumnas = definition.Columns
        ColRel = definition.ColumnRel

        dgtTablas = definition.Tables
        TablaEdit = definition.TablaEdit

        dgrClausulas = definition.Rules

    End Sub

#Region "Eventos"

    Private Sub GridLiCon_CellValueChanged(sender As Object, e As GridViewCellEventArgs) Handles Me.CellValueChanged
        Try
            If e.Row.RowElementType <> GetType(GridFilterRowElement) And e.Row.RowElementType <> GetType(GridNewRowElement) Then
                If e.Column.Name = "Cantidad" Or e.Column.Name = "Precio" Or e.Column.Name = "Dto" Or e.Column.Name = "Iva" Or e.Column.Name = "Incluido" Then
                    calcularSubtotalLin(e.Row)
                    recalcularTotal()
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub GridLiCon_UserAddedRow(sender As Object, e As GridViewRowEventArgs) Handles Me.UserAddedRow
        calcularSubtotalLin(e.Row)
        recalcularTotal()
    End Sub

    Protected Overrides Sub AddExtra(sender As Object, e As GridViewRowCancelEventArgs)
        e.Rows(0).Cells("GRUPO").Value = _grupo
        e.Rows(0).Cells("TARIFA").Value = _tarifa
        i += 1
    End Sub

    Private Sub GridLiCon_UserDeletedRow(sender As Object, e As GridViewRowEventArgs) Handles Me.UserDeletedRow
        recalcularTotal()
    End Sub

#End Region

#Region "Calculo totales"
    Private Sub calcularSubtotalLin(row As GridViewRowInfo)
        Try
            If Not IsNothing(row) Then
                Dim lin As New Linea
                lin.Cantidad = IIf(IsDBNull(row.Cells("Cantidad").Value), 0, row.Cells("Cantidad").Value)
                lin.Precio = IIf(IsDBNull(row.Cells("Precio").Value), 0, row.Cells("Precio").Value)
                lin.DTO = IIf(IsDBNull(row.Cells("Dto").Value), 0, row.Cells("Dto").Value)
                lin.Incluido = IIf(IsDBNull(row.Cells("Incluido").Value), False, row.Cells("Incluido").Value)

                lin.calcularTotalLinea()

                row.Cells("Subtotal").Value = Math.Round(lin.Subtotal, decimalesPrecios)
            End If
        Catch
        End Try
    End Sub

    Public Sub recalcularTotal()
        Try
            Me.EndEdit()

            dtaCalculos = CType(Me.DataSource, DataTable).Copy

            Dim rowsToDelete As New ArrayList
            For Each row As DataRow In dtaCalculos.Rows
                If row.RowState <> DataRowState.Deleted Then
                    If IIf(IsDBNull(row.Item("incluido")), False, row.Item("incluido")) = False Then
                        rowsToDelete.Add(row)
                    End If
                End If
            Next

            For Each row As DataRow In rowsToDelete
                dtaCalculos.Rows.Remove(row)
            Next

            RaiseEvent TotalesChanged()
        Catch ex As Exception
        End Try
    End Sub

    Private recalcular As Boolean = True
    Private Sub GridLiCon_ValueChanging(sender As Object, e As ValueChangingEventArgs) Handles Me.ValueChanging
        If Not IsNothing(CurrentRow) Then
            If CurrentRow.RowElementType <> GetType(GridFilterRowElement) And CurrentRow.RowElementType <> GetType(GridNewRowElement) Then
                If TypeOf Me.ActiveEditor Is RadCheckBoxEditor And recalcular Then
                    recalcular = False
                    Dim row As GridViewRowInfo

                    row = CurrentRow
                    row.Cells("Incluido").Value = e.NewValue

                    calcularSubtotalLin(row)
                    recalcularTotal()
                    recalcular = True
                End If
            End If
        End If
    End Sub

    Public Sub setDias(ByVal dias As Integer)

        For Each row As GridViewRowInfo In Me.Rows
            If row.Cells("Unidad").Value = "DIA" Then
                row.Cells("Cantidad").Value = dias
            End If
        Next
        recalcularTotal()
    End Sub
#End Region

    Public Function addLinea(concepto As String, incluido As Boolean, unidad As String, cantidad As Double, precio As Double, dto As Double, iva As Double, Optional modifica As Boolean = False) As Boolean
        Try
            Dim row As DataRow
            Dim rowFound As Boolean = False
            row = CType(Me.DataSource, DataTable).NewRow()

            row.Item("NUMERO") = _idRel
            row.Item("CONCEPTO") = concepto
            row.Item("DESCCON") = Me.DBConnection.executeQuery("select NOMBRE from CONCEP_FACTUR where CODIGO = " & concepto)
            row.Item("INCLUIDO") = incluido
            row.Item("UNIDAD") = unidad
            row.Item("CANTIDAD") = cantidad
            row.Item("PRECIO") = precio
            row.Item("DTO") = dto
            row.Item("IVA") = iva
            row.Item("GRUPO") = _grupo
            row.Item("TARIFA") = _tarifa
            i += 1

            If modifica Then
                For Each r As DataRow In CType(Me.DataSource, DataTable).Rows
                    If r.RowState <> DataRowState.Deleted Then
                        If r.Item("CONCEPTO") = row.Item("CONCEPTO") Then
                            For Each col As DataColumn In CType(Me.DataSource, DataTable).Columns
                                r.Item(col.ColumnName) = row.Item(col.ColumnName)
                            Next
                            rowFound = True
                            Exit For
                        End If
                    End If
                Next
            End If

            If Not rowFound Then CType(Me.DataSource, DataTable).Rows.Add(row)

            calcularSubtotalLin(Me.Rows(Me.Rows.Count - 1))

            Return True
        Catch
            Return False
        End Try
    End Function

    Public Sub deleteLinea(concepto As String)
        For Each r As DataRow In CType(Me.DataSource, DataTable).Rows
            If r.RowState <> DataRowState.Deleted Then
                If r.Item("CONCEPTO") = concepto Then
                    r.Delete()
                    Exit For
                End If
            End If
        Next
    End Sub
End Class
