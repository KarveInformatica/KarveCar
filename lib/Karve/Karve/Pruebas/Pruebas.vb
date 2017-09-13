Imports VariablesGlobales
Imports Karve.ConfiguracionApp
Imports Telerik.WinControls.UI

Public Class Pruebas

    Protected db As New ASADB.Connection

    Private Sub Pruebas_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dts As New DataSet
        Dim dtsL As New DataSet
        dts = db.fillDts("SELECT TOP 100 numerO_fac, FECHA_FAC, CLIENTE_FAC, (SELECT LIST(DESCRIP_LIF, CHAR(13)) FROM LIFAC WHERE NUMERO_LIF = NUMERO_FAC) AS LIF  FROM FACTURAS ORDER BY FECHA_FAC DESC ")
        dtsL = db.fillDts("SELECT CONCEPTO_LIF, DESCRIP_LIF, NUMERO_LIF FROM LIFAC")

        Grid.ShowFilteringRow = True
        Grid.EnableFiltering = True

        Grid.DataSource = dts.Tables(0)

        Dim template As New GridViewTemplate()
        template.DataSource = dtsL.Tables(0)
        Grid.MasterTemplate.Templates.Add(template)

        Dim relation As New GridViewRelation(Grid.MasterTemplate)
        relation.ChildTemplate = template
        relation.RelationName = "FAC_LIFAC"
        relation.ParentColumnNames.Add("NUMERO_FAC")
        relation.ChildColumnNames.Add("NUMERO_LIF")
        Grid.Relations.Add(relation)
    End Sub
End Class