Imports System.Windows.Forms
Imports System.Drawing.Font
Imports Bases
Imports Telerik.WinControls.RichTextBox.FormatProviders.Txt
Imports CustomControls
Imports Karve.ConfiguracionApp
Imports Telerik.WinControls.UI

Imports VariablesGlobales

Public Class Form3
    Inherits frmBase
    Dim Rs As New DataGridRules

    Private Sub Form3_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated

        rbnAction.CommandTabs.Add(RibbonTab2)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'idEdit = "C100003435"
        'Load_Reg()
        'DataTime1.setBinding(dtsEdit)
        OpenTab("Proveedores.Proveedores")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim ts As New TimeSpan(17, 5, 0)
        'dtsEdit.Tables(0).Rows(0).Item("hretor_con1") = ts
        'DataDateLabel1.Min_Value = New Date(2014, 10, 22)
        'DataTime1.Time = Nothing
        Dim h As New VariablesGlobales.Horario(New TimeSpan(10, 0, 0), New TimeSpan(12, 0, 0))
        DataTime1.Horarios.Add(h)
    End Sub

    Protected Overrides Sub SaveExtra(newReg As Boolean)
        DataTime1.EndEdit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataTime1.Incorrecto Then
            MsgBox(DataTime1.MensajeIncorrecto)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim msg As New kMsgBox
        'MsgBox("a", MsgBoxStyle.Information)
        msg.Print("a", CustomControls.kMsgBox.kMsgBoxStyle.Exclamation)
        msg.Print("a", CustomControls.kMsgBox.kMsgBoxStyle.Question)
        msg.Print("a", CustomControls.kMsgBox.kMsgBoxStyle.OkOnly)
        msg.Print("a", CustomControls.kMsgBox.kMsgBoxStyle.Information)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Dim suma As Integer = 0
        'For i = 0 To 1000000000 Step 1
        '    suma = i / 10 * 2 - i / 100
        'Next
    End Sub

#Region "LOAD TREE"
    Private tvwBase As New RadTreeView
    Private nodeList As New ArrayList
    Private nodeListSearch As New ArrayList

    Private Sub treeAlqLoad()
        Dim nodes As New ArrayList
        Dim nodes2 As New List(Of RadTreeNode)
        nodeList = New ArrayList
        loadCarTree()
        tvwAlq.Nodes.Clear()
        For Each node In nodeList
            tvwAlq.Nodes.Add(node)
        Next


        tvwAlq.Refresh()
    End Sub

    Private Sub loadCarTree()
        nodeList.Add(Maestros())
        nodeList.Add(Reservas())
        nodeList.Add(Contratos())
    End Sub

    Private Function Maestros() As CustomControls.TreeNode
        Maestros = New CustomControls.TreeNode("Maestros", CustomControls.TreeNode.nodeType.container)
        Dim list As New ArrayList()
        Maestros.Nodes.Add(New CustomControls.TreeNode("Clientes", CustomControls.TreeNode.nodeType.node, "Clientes.Clientes"))
        If CK.GBool("BDCONTACTOS") Then Maestros.Nodes.Add(New CustomControls.TreeNode("Potenciales", CustomControls.TreeNode.nodeType.node, ""))
        Maestros.Nodes.Add(New CustomControls.TreeNode("Vehículos", CustomControls.TreeNode.nodeType.node, "KarvePruebas.Form2"))
        Maestros.Nodes.Add(New CustomControls.TreeNode("Comisionistas", CustomControls.TreeNode.nodeType.node, ""))
        Maestros.Nodes.Add(New CustomControls.TreeNode("Proveedores", CustomControls.TreeNode.nodeType.node, ""))
    End Function

    Private Function Reservas() As CustomControls.TreeNode
        Reservas = New CustomControls.TreeNode("Reservas", CustomControls.TreeNode.nodeType.container)
        Reservas.Nodes.Add(New CustomControls.TreeNode("Reservas", CustomControls.TreeNode.nodeType.node, "KarvePruebas.Form3"))
        Reservas.Nodes.Add(New CustomControls.TreeNode("Clientes", CustomControls.TreeNode.nodeType.node, "Clientes.Clientes"))
    End Function

    Private Function Contratos() As CustomControls.TreeNode
        Contratos = New CustomControls.TreeNode("Contratos", CustomControls.TreeNode.nodeType.container)
    End Function

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles Me.Load
        treeAlqLoad()

    End Sub

#End Region

    Private Sub searchNodes()
        If TextBox1.Text <> "" Then
            nodeListSearch = New ArrayList
            FindNodeRecursive(tvwBase.Nodes, TextBox1.Text)
            tvwAlq.Nodes.Clear()
            For Each node In nodeListSearch
                tvwAlq.Nodes.Add(node)
            Next
            tvwAlq.Refresh()
        Else
            tvwAlq = tvwBase
            tvwAlq.Refresh()
        End If
    End Sub

    Private Sub FindNodeRecursive(ByVal nodes As RadTreeNodeCollection, ByVal value As String)
        For Each node As CustomControls.TreeNode In nodes
            If InStr(node.Name, value, CompareMethod.Text) > 0 And node.Type = CustomControls.TreeNode.nodeType.node Then
                nodeListSearch.Add(node)
            ElseIf node.Nodes.Count > 0 And node.Type = CustomControls.TreeNode.nodeType.container Then
                FindNodeRecursive(node.Nodes, value)
            End If
        Next
    End Sub

    Private Sub Datafield1_TextChanged() Handles TextBox1.TextChanged
        searchNodes()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim i As Integer = 10
        Dim s As String = "TEST"
        Dim msg As String = "Este es mi %v numero %v;" & s & ";" & i
        MsgBox(TranslateVars(msg))
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        'MsgBox(RadRibbonBarGroup1.Parent.Parent.Parent.Parent.Parent)
    End Sub

    Private Sub RadCheckBoxElement1_Click(sender As Object, e As EventArgs) Handles RadCheckBoxElement1.CheckStateChanged
        If RadCheckBoxElement1.Checked Then
            PnlBrowser1.myWhere = "BAJA is not null"
        Else
            PnlBrowser1.myWhere = "BAJA is null"
        End If
    End Sub

    Protected Overrides Sub AddExtra()
        MsgBox("hola")
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim db As New ASADB.Connection
        Dim dts As New DataSet
        Dim col As DataGridColumn
        Dim Tablas As New DataGridDefinicion
        Dim Tb As DataGridTable
        'Dim ba As New Telerik.WinControls.UI.BaseFormattingObject
        'Dim BA As New ExpressionFormattingObject("numero_cli", "", False)
        'BA.CellBackColor = System.Drawing.Color.SkyBlue


        'ba.Enabled = True

        col = New DataGridColumn
        col.Campo = "NOMBRE"
        col.Tabla = "C1"
        col.HeaderText = "NAME HEADER"
        col.AliasCampo = "cli_nombre"
        col.AllowFiltering = True
        col.BackColor = Drawing.Color.Aquamarine

        Tablas.Columnas.Add(col)

        col = New DataGridColumn
        col.Name = "CODIGO"
        col.HeaderText = "CODIGO"
        col.AliasCampo = "numero_cli"


        Tablas.Columnas.Add(col)
        '*-------------------------------------------------------
        Tb = New DataGridTable
        Tb.Table = "CLIENTES1"
        Tb.AliasTabla = "C1"

        Tablas.TablasQuery.Add(Tb)
        Tablas.LoadGrid(Me.DataGrid1)
        '*-------------------------------------------------------
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim db As New ASADB.Connection
        Dim dts As New DataSet
        Dim col As DataGridColumn
        Dim Tablas As New DataGridDefinicion
        Dim Tb As DataGridTable


        col = New DataGridColumn
        col.HeaderText = "Número"
        col.AliasCampo = "NUMERO_CLI"
        col.Tabla = "C1"
        col.AllowFiltering = True
        Tablas.Columnas.Add(col)

        col = New DataGridColumn
        col.Tabla = "C1"
        col.HeaderText = "Nombre Cliente"
        col.AliasCampo = "NOMBRE"
        col.AllowFiltering = True

        Tablas.Columnas.Add(col)

        col = New DataGridColumn
        col.Tabla = "C2"
        col.HeaderText = "Fecha Alta"
        col.AliasCampo = "ALTA"
        col.ExpresionBd = " DATEFORMAT(ALTA, 'dd/mm/yyyy') "
        col.AllowFiltering = True

        Tablas.Columnas.Add(col)

        Tb = New DataGridTable
        Tb.Table = "CLIENTES1"
        Tb.AliasTabla = "C1"

        Tablas.TablasQuery.Add(Tb)

        Tb = New DataGridTable
        Tb.Table = "CLIENTES2"
        Tb.Criterio = "ON C1.NUMERO_CLI = C2.NUMERO_CLI"
        Tb.Join = DataGridTable.euCriteriosJoin.InnerJoin
        Tb.AliasTabla = "C2"

        Tablas.TablasQuery.Add(Tb)

        Tablas.LoadGrid(Me.DataGrid1)
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles btnVirtualFrom.Click
        Dim db As New ASADB.Connection
        Dim dts As New DataSet
        Dim col As New DataGridColumn
        Dim Tablas As New DataGridDefinicion
        Dim Tb As DataGridTable
        Dim Tb1 As DataGridTable
        Dim C1 As DataGridColumnVirtual

        Tb = New DataGridTable
        Tb.Table = ""
        Tb.AliasTabla = "C1"

        col = New DataGridColumn
        col.HeaderText = "Número"
        col.AliasCampo = "NUMERO_CLI"
        col.Tabla = "C1"
        col.AllowFiltering = True
        col.Width = 100
        Tablas.Columnas.Add(col)

        col = New DataGridColumn
        col.Tabla = "C1"
        col.HeaderText = "Nombre Cliente"
        col.AliasCampo = "NOMBRE"
        col.AllowFiltering = True
        col.Width = 200
        col.BackColor = Drawing.Color.Azure

        Tablas.Columnas.Add(col)

        col = New DataGridColumn
        col.Tabla = "C1"
        col.HeaderText = "Direccion"
        col.AliasCampo = "DIRECCION"
        col.AllowFiltering = True
        col.Width = 200
        col.BackColor = Drawing.Color.Brown

        Tablas.Columnas.Add(col)

        Tb1 = New DataGridTable 'Virtual
        Tb1.Table = "CLIENTES1"
        Tb1.AliasTabla = "Cx"
        '*---------------------------------
        '*  Las columnas cuelgan de la ppal, al igual que las tablas xa montar la consulta virtual
        C1 = New DataGridColumnVirtual
        C1.Name = "NUMERO_CLI"
        C1.AliasCampo = "NUMERO_CLI"

        Tb.ColumnasTablaVirtual.Add(C1)

        C1 = New DataGridColumnVirtual
        C1.Name = "NOMBRE"

        Tb.ColumnasTablaVirtual.Add(C1)

        C1 = New DataGridColumnVirtual
        C1.Name = "DIR_POB"
        C1.AliasCampo = "DIRECCION"
        C1.Expresion = "ISNULL(DIRECCION, '') + ' ' + ISNULL(POBLACION, '')"

        Tb.ColumnasTablaVirtual.Add(C1)
        '*---------------------------------
        Tb.TablasVirtual.Add(Tb1)

        Tablas.TablasQuery.Add(Tb)

        Tablas.LoadGrid(Me.DataGrid1)
    End Sub

    Private Sub btn2Virtual_Click(sender As Object, e As EventArgs) Handles btn2Virtual.Click
        Dim db As New ASADB.Connection
        Dim dts As New DataSet
        Dim col As DataGridColumn
        Dim Tablas As New DataGridDefinicion
        Dim Tb As DataGridTable
        Dim Tb1 As DataGridTable
        Dim C1 As DataGridColumnVirtual
        '*------------------------------------------------------------------------

        col = New DataGridColumn
        col.HeaderText = "Número"
        col.AliasCampo = "NUMERO_CLI"
        col.Tabla = "C1"
        col.AllowFiltering = True
        Tablas.Columnas.Add(col)

        col = New DataGridColumn
        col.Tabla = "C1"
        col.HeaderText = "Nombre Cliente"
        col.AliasCampo = "NOMBRE"
        col.AllowFiltering = True

        Tablas.Columnas.Add(col)

        Tb = New DataGridTable
        Tb.AliasTabla = "C1"
        Tb.Table = "CLIENTES1"
        Tablas.TablasQuery.Add(Tb)

        Tb = New DataGridTable
        Tb.AliasTabla = "C2"    'VIRTUAL
        Tb.Criterio = " ON C1.NUMERO_CLI = C2.NUMERO_CLI"
        Tb.Table = ""
        Tb.Join = DataGridTable.euCriteriosJoin.InnerJoin

        Tb1 = New DataGridTable
        Tb1.Table = "CLIENTES1"
        Tb1.AliasTabla = "CX1"

        Tb.TablasVirtual.Add(Tb1)   'ADD CLIENTES1

        Tb1 = New DataGridTable
        Tb1.Table = "CLIENTES2"
        Tb1.AliasTabla = "CX2"
        Tb1.Criterio = "ON CX1.NUMERO_CLI = CX2.NUMERO_CLI"
        Tb1.Join = DataGridTable.euCriteriosJoin.InnerJoin

        Tb.TablasVirtual.Add(Tb1)   'ADD CLIENTES2

        C1 = New DataGridColumnVirtual
        C1.Name = "ALTA"

        C1 = New DataGridColumnVirtual
        C1.Name = "NUMERO_CLI"
        C1.AliasTabla = "CX1"

        Tb.ColumnasTablaVirtual.Add(C1) 'ADD COL ALTA

        C1 = New DataGridColumnVirtual
        C1.Name = "VENDEDOR"

        Tb.ColumnasTablaVirtual.Add(C1) 'ADD COL VENDEDOR

        C1 = New DataGridColumnVirtual
        C1.Name = "ALTA_VENDE"
        C1.AliasCampo = "ALTA_VENDE"
        C1.Expresion = " (CAST(ALTA AS CHAR(10)) + '; ' + VENDEDOR) "

        Tb.ColumnasTablaVirtual.Add(C1) 'ADD COL VENDEDOR

        Tablas.TablasQuery.Add(Tb)

        Tablas.LoadGrid(Me.DataGrid1)
    End Sub


    Private Sub Browser_Click(sender As Object, e As EventArgs) Handles Browser.Click
        
    End Sub

    Private Sub Lupa_Click(sender As Object, e As EventArgs) Handles Lupa.Click
        'CDC = OpenForm("Bases.Consulta")
        'CDC.ShowDialog()
    End Sub

    Private Sub Button14_Click_1(sender As Object, e As EventArgs) Handles Button14.Click
        Dim CDC As New Bases.Consulta
        CDC = OpenForm(lupaClientes)
        CDC.MarcarFilas = False
        CDC.OpenDialog()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        OpenTab(lupaClientes)
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim frm As New frmBase
        frm = OpenForm(frmClientes)
        frm.CodigoEdicion = TextBox1.Text
        OpenTab(frm)
        frm.Load_Reg()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim str As String
        str = String.Format("{0:####/##/## ##:##}", CLng(TextBox2.Text))

    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click

        MsgBox(RadPageViewPage2.Width)
        MsgBox(RadPageViewPage2.Height)
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Dim frm As Object = OpenForm(lupaClientes)
        frm.OpenDialog()
        If frm.DialogResult = DialogResult.OK Then
            'MsgBox(frm.dtsResult)
        End If
    End Sub

    Private Sub R1_Click(sender As Object, e As EventArgs) Handles R1.Click
        Dim R1 As New DataGridRule
        With R1
            .Name = "CLIENTE"
            .Campo = "C1.CLIENTE"
            .Criterio = DataGridRule.euCriterio.Distinto
            .Valor = "0000001"
        End With
        If Not Rs.Existe(R1.Name) Then
            Rs.Add(R1)
        Else : Rs.Modify(R1)
        End If
    End Sub

    Private Sub R2_Click(sender As Object, e As EventArgs) Handles R2.Click
        Dim R2 As New DataGridRule
        With R2
            .Name = "NOMBRE"
            .Campo = "C1.NOMBRE"
            .Criterio = DataGridRule.euCriterio.Distinto
            .Valor = "MARCA"
        End With
        If Not Rs.Existe(R2.Name) Then
            Rs.Add(R2)
        Else : Rs.Modify(R2)
        End If
    End Sub

    Private Sub R3_Click(sender As Object, e As EventArgs) Handles R3.Click
        Dim R3 As New DataGridRule
        With R3
            .Name = "APELLIDO"
            .Campo = "C1.APELLIDO"
            .Criterio = DataGridRule.euCriterio.Distinto
            .Valor = "MARCA2"
        End With
        If Not Rs.Existe(R3.Name) Then
            Rs.Add(R3)
        Else : Rs.Modify(R3)
        End If
    End Sub

    Private Sub RC_Click(sender As Object, e As EventArgs) Handles RC.Click
        Rs.Clear()
    End Sub
    
End Class