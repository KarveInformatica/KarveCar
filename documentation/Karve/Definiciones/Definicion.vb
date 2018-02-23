Imports CustomControls

Public MustInherit Class Definicion

#Region "Variables"

    Private dgcColumns As New DataGridColumns
    Private dgtTables As New DataGridTables
    Private dgrRules As New DataGridRules
    Private dgoOrdenes As New DataGridOrdenColumnas
    Private colRelation As DataGridTextBoxColumn
    Private tbEdit As New DataGridTable
    Private dgcgGroups As New DataGridColumnGroups

#End Region

#Region "Propiedades"

    ReadOnly Property Columns As DataGridColumns
        Get
            Return dgcColumns
        End Get
    End Property

    ReadOnly Property Tables As DataGridTables
        Get
            Return dgtTables
        End Get
    End Property

    ReadOnly Property Rules As DataGridRules
        Get
            Return dgrRules
        End Get
    End Property

    ReadOnly Property Ordenes As DataGridOrdenColumnas
        Get
            Return dgoOrdenes
        End Get
    End Property

    ReadOnly Property ColumnRel As DataGridTextBoxColumn
        Get
            Return colRelation
        End Get
    End Property

    ReadOnly Property TablaEdit As DataGridTable
        Get
            Return tbEdit
        End Get
    End Property

    ReadOnly Property Groups As DataGridColumnGroups
        Get
            Return dgcgGroups
        End Get
    End Property
#End Region

#Region "Funciones"
    Public Sub New()
        SetColumns(dgcColumns, colRelation, dgcgGroups)
        SetTables(dgtTables, tbEdit)
        SetRules(dgrRules)
        SetOrdenes(dgoOrdenes)
    End Sub

    Protected MustOverride Sub SetColumns(ByRef dgcColumns As DataGridColumns, ByRef colRelation As DataGridTextBoxColumn, ByRef dgcgGroups As DataGridColumnGroups)

    Protected MustOverride Sub SetTables(ByRef dgtTables As DataGridTables, ByRef tbEdit As DataGridTable)

    Protected MustOverride Sub SetRules(ByRef dgrRules As DataGridRules)

    Protected MustOverride Sub SetOrdenes(ByRef dgoOrdenes As DataGridOrdenColumnas)

#End Region
    
End Class
