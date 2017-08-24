Imports Telerik.WinControls.UI

Public Class GridTramos
    Inherits CustomControls.DataGrid

    Protected Overrides Sub DefineGrid()

        Dim definition As New Definiciones.defGridTramosTari

        dgcColumnas = definition.Columns
        ColRel = definition.ColumnRel

        dgtTablas = definition.Tables
        TablaEdit = definition.TablaEdit

        dgrClausulas = definition.Rules

    End Sub

    Protected Overrides Sub loadExtra()
        Me.AllowSearchRow = False
        Me.AddNewRowPosition = SystemRowPosition.Bottom
        Me.AllowColumnChooser = False
        Me.AllowRowReorder = False
    End Sub

    Private Sub InitializeComponent()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridTramos
        '
        Me.DataGridType = CustomControls.DataGrid.GridType.Edit
        '
        '
        '
        Me.MasterTemplate.EnableFiltering = True
        Me.MasterTemplate.MultiSelect = True
        Me.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect
        CType(Me.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
