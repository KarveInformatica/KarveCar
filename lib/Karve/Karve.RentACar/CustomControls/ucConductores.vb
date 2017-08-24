Imports Karve.ConfiguracionApp
Imports Karve.Logic
Imports Telerik.WinControls.UI
Imports VariablesGlobales
Imports Karve.Definiciones
Imports Bases.frmBase
Imports Microsoft.VisualBasic

Public Enum OrigenConductores
    Reservas
    Contratos
End Enum

Public Class ucConductores
    Dim _OriCond As OrigenConductores
    Dim _Table As String
    Dim _Sufijo As String

    Private Sub ucConductores_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.dtfConductorDetalles.Lupa = lupaClientes
        Me.dtfConductorDetalles.OpenForm = frmClientes
        Me.dtfTarjetaCond.Lupa = lupaTarjetasCredito
        Me.dtfTarjetaCond.OpenForm = TarjetasCredito
        Me.dtfOtroCond.Lupa = lupaClientes
        Me.dtfOtroCond2.Lupa = lupaClientes
        Me.dtfOtroCond3.Lupa = lupaClientes

        Me.dtfOtroCond.OpenForm = frmClientes
        Me.dtfOtroCond2.OpenForm = frmClientes
        Me.dtfOtroCond3.OpenForm = frmClientes

        LoadFieldOrigen()
    End Sub

    Public Property OrigenBd As OrigenConductores
        Get
            Return _OriCond
        End Get
        Set(value As OrigenConductores)
            _OriCond = value
            LoadFieldOrigen()
        End Set
    End Property

    Private Sub LoadFieldOrigen()
        If _OriCond = OrigenConductores.Contratos Then Exit Sub
        _Table = "R"
        _Sufijo = "_RES"
        RecorreMe(Me.Controls)
        
    End Sub

    Private Sub RecorreMe(Ctr As Object)
        For Each oCtr In Ctr
            Select Case oCtr.GetType
                Case GetType(CustomControls.Datafield), GetType(CustomControls.DatafieldLabel) : LoadDataField(oCtr)
                Case GetType(CustomControls.DualDatafield), GetType(CustomControls.DualDatafieldLabel) : LoadDataField(oCtr)
                Case GetType(CustomControls.DataDateLabel) : LoadDataField(oCtr)
                Case GetType(CustomControls.DualDatafield), GetType(CustomControls.DualDatafieldLabel) : LoadDataField(oCtr)
                Case GetType(CustomControls.MaskedDataField) : LoadDataField(oCtr)
                Case GetType(CustomControls.DualDataFieldEditableLabel) : LoadDualDataFieldEditableLabel(oCtr)
                Case Else
                    RecorreMe(oCtr.controls)
            End Select
        Next
    End Sub

    Private Sub LoadDualDataFieldEditableLabel(Ctr As CustomControls.DualDataFieldEditableLabel)
        With Ctr
            If .DataField <> "" Then
                .DataField = TrataCampo(.DataField)
            End If
            If .DataTable <> "" Then
                .DataTable = Replace(.DataTable, "C", _Table)
            End If
            If .DataField_DescEdit <> "" Then
                .DataField_DescEdit = TrataCampo(.DataField_DescEdit)
            End If
            If .DataTable_DescEdit <> "" Then
                .DataTable_DescEdit = Replace(.DataTable_DescEdit, "C", _Table)
            End If
        End With
    End Sub

    Private Sub LoadDataField(Ctr As Object)
        With Ctr
            If .DataField <> "" Then
                .DataField = TrataCampo(.DataField)
            End If
            If .DataTable <> "" Then
                .DataTable = Replace(.DataTable, "C", _Table)
            End If
        End With
    End Sub

    Private Function TrataCampo(Value As String) As String
        Dim sDataField As String = Microsoft.VisualBasic.Left(Value, Value.Length - 5)
        Dim sReturn As String = ""
        sReturn = sDataField & Replace(Value, "_CON", _Sufijo, Value.Length - 4)
        Return sReturn
    End Function

End Class
