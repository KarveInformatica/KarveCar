Imports Telerik.WinControls.UI
Imports Telerik.WinControls.UI.Docking
Imports Karve.ConfiguracionApp
Imports VariablesGlobales
Imports CustomControls

Public Class MDI

#Region "Variables"
    Private kMsgBox As New CustomControls.kMsgBox

#End Region

#Region "HandleCreated"

    Private Sub MDI_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Dim frm As New cargaControles
        Arranca.Main()
        frm.Opacity = 0
        frm.Show()
        ribbonText()
        unLoadTrees()
        OptionsExitRibbon()
        ToolWindowsLoad()
        LoadAccesoRapido()
        RibbonLoad()
        loadTrees()
        LoadListaTemas()
        frm.Close()
    End Sub

    Private Sub LoadListaTemas()
        Me.rmcboTemas.Text = "Seleccionar Tema"
        Me.rmcboTemas.Items.Add("Defecto")
        Me.rmcboTemas.Items.Add("Karve")
    End Sub

    Private Sub MDI_Load(sender As Object, e As EventArgs) Handles Me.Load
        traducirForm()
    End Sub

    Private Sub ribbonText()
        Me.Text = "KARVE - " & CO.GStr("OFICINA") & " [" & ConfiguracionApp.oficina & "] - " & _
            CE.GStr("EMPRESA") & " [" & CE.GStr("RAZON") & "] - " & _
            US.GStr("NOMBRE")
    End Sub

    Private Sub OptionsExitRibbon()
        ribbonMDI.OptionsButton.Text = "Cerrar Sesión"
        ribbonMDI.OptionsButton.ForeColor = Color.Black
        ribbonMDI.OptionsButton.ButtonElement.AutoSize = False
        ribbonMDI.OptionsButton.ButtonElement.Size = New Size(105, 20)
        AddHandler ribbonMDI.OptionsButton.Click, AddressOf optionsButtonClick

        ribbonMDI.ExitButton.Text = "Salir"
        ribbonMDI.ExitButton.ForeColor = Color.Black
        ribbonMDI.ExitButton.ButtonElement.AutoSize = False
        ribbonMDI.ExitButton.ButtonElement.Size = New Size(75, 20)
        AddHandler ribbonMDI.ExitButton.Click, AddressOf exitButtonClick
    End Sub

    Private Sub exitButtonClick()
        Me.Close()
    End Sub
    Private Sub optionsButtonClick()
        If MsgBox("Desea Cerrar la Sesión?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        For Each window As DocumentWindow In docContainer.DockManager.DockWindows.DocumentWindows
            window.Close()
        Next
        unLoadTrees()

        desTraducirForm()

        Relogin()

        OptionsExitRibbon()
        ToolWindowsLoad()
        RibbonLoad()
        ribbonText()
        loadTrees()
        traducirForm()
    End Sub

    Private Sub ToolWindowsLoad()
        twdAlq.AllowedDockState = AllowedDockState.All And Not AllowedDockState.Floating _
           And Not AllowedDockState.Hidden And Not AllowedDockState.TabbedDocument
        twdTaller.AllowedDockState = AllowedDockState.All And Not AllowedDockState.Floating _
            And Not AllowedDockState.Hidden And Not AllowedDockState.TabbedDocument
        twdConta.AllowedDockState = AllowedDockState.All And Not AllowedDockState.Floating _
            And Not AllowedDockState.Hidden And Not AllowedDockState.TabbedDocument
    End Sub

    Private Sub RibbonLoad()
        ConfiguraCintaEdicion(ribbonMDI)
        VGribbonMDI = ribbonMDI
        VGribbonMDICopy = New RadRibbonBar
        For Each cmdTab As RibbonTab In ribbonMDI.CommandTabs
            If cmdTab.IsSelected Then
                cmdTab.BackColor = Color.FromArgb(41, 167, 235)
            Else
                cmdTab.BackColor = SystemColors.Control
            End If
            VGribbonMDICopy.CommandTabs.Add(cmdTab)
        Next
        dockMDI.DocumentManager.DocumentInsertOrder = DockWindowInsertOrder.ToBack
        VGdockMDI = dockMDI
        VMenu = Me.ttsMenu
        VStatus = Me.stbMDI
        ribbonMDI.CommandTabs.Clear()
        For Each cmdTab As RibbonTab In VGribbonMDICopy.CommandTabs
            ribbonMDI.CommandTabs.Add(cmdTab)
        Next
    End Sub
#End Region

    Private Sub dockMDI_ActiveWindowChanged(sender As Object, e As DockWindowEventArgs) Handles dockMDI.ActiveWindowChanged
        Try
            If dockMDI.ActiveWindow.DockType <> DockType.ToolWindow Then
                ribbonMDI.CommandTabs.Clear()
                For Each cmdTab As RibbonTab In VGribbonMDICopy.CommandTabs
                    ribbonMDI.CommandTabs.Add(cmdTab)
                Next

                For Each ctr In dockMDI.ActiveWindow.Controls
                    For Each ct In ctr.controls
                        If ct.GetType Is GetType(RadRibbonBar) Or ct.GetType Is GetType(RibbonBar) Then
                            For Each cmdTab As RibbonTab In CType(ct, RadRibbonBar).CommandTabs
                                ribbonMDI.CommandTabs.Add(cmdTab)
                                If cmdTab.Tag = 1 Then
                                    cmdTab.IsSelected = True
                                    cmdTab.BackColor = Color.FromArgb(41, 167, 235)
                                End If
                            Next
                            Exit For
                        End If
                    Next
                Next

            End If
        Catch
        End Try

        Try
            stbMDI.Items.Clear()

            For Each ctr In dockMDI.ActiveWindow.Controls
                For Each ct In ctr.controls
                    If ct.GetType Is GetType(RadStatusStrip) Then
                        For Each it In CType(ct, RadStatusStrip).Items
                            stbMDI.Items.Add(it)
                        Next
                        Exit For
                    End If
                Next
            Next
        Catch
        End Try
    End Sub

    Private Sub ribbonMDI_CommandTabSelected(sender As Object, args As CommandTabEventArgs) Handles ribbonMDI.CommandTabSelected
        For Each cmdTab As RibbonTab In ribbonMDI.CommandTabs
            If cmdTab.IsSelected Then
                cmdTab.BackColor = Color.FromArgb(41, 167, 235)
            Else
                cmdTab.BackColor = SystemColors.Control
            End If
        Next
    End Sub

    Private Sub MDI_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Desea Salir?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) <> MsgBoxResult.Yes Then
            e.Cancel = True
        End If
    End Sub

    Private Sub dockMDI_DockWindowClosing(sender As Object, e As DockWindowCancelEventArgs) Handles dockMDI.DockWindowClosing
        Try
            For Each ctr In dockMDI.ActiveWindow.Controls
                CType(ctr, Bases.frmBase).Close()
            Next
            If dockMDI.ActiveWindow.Controls.Count > 0 Then
                e.Cancel = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbeArchivo_DoubleClick1(sender As Object, e As EventArgs) Handles rbeIcon.DoubleClick
        MsgBox("a")
        Me.Close()
    End Sub

    Private Sub MDI_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F6 Then
            selectSearch()
        End If
    End Sub

#Region "TreeView"

    Private tvwBaseAlq As New ArrayList
    Private tvwBaseTaller As New ArrayList
    Private tvwBaseConta As New ArrayList
    Private nodeListSearch As New ArrayList

    Private Sub openNode(ByVal node As CustomControls.TreeNode)
        Try
            Dim nomForm As String = CType(node, CustomControls.TreeNode).Form()
            If nomForm <> "" Then
                VariablesGlobales.OpenTab(nomForm)
            End If
        Catch
        End Try
    End Sub

    Private Sub tvwMDI_NodeMouseClick(sender As Object, e As RadTreeViewEventArgs) Handles tvwAlq.NodeMouseClick
        Try
            openNode(e.Node)
        Catch
        End Try
    End Sub

    Private Sub unLoadTrees()
        twdAlq.Text = ""
        twdTaller.Text = ""
        twdConta.Text = ""
        ttsMenu.Controls.Remove(twdAlq)
        ttsMenu.Controls.Remove(twdTaller)
        ttsMenu.Controls.Remove(twdConta)
    End Sub
    Private Sub loadTrees()
        treeAlqLoad()
        twdAlq.Text = "Alquiler"
        twdTaller.Text = "Taller"
        twdConta.Text = "Contabilidad"
        ttsMenu.Controls.Add(twdAlq)
        ttsMenu.Controls.Add(twdTaller)
        ttsMenu.Controls.Add(twdConta)
        twdAlq.Select()
    End Sub
    Private Sub treeAlqLoad()
        Dim nodes As New ArrayList
        If CK.GBool("RENTACAR_PROG") Then
            Dim carTree As New CarTree
            nodes = carTree.getNodes
        ElseIf CK.GBool("CARRE_PROG") Then

        ElseIf CK.GBool("ALQ_OP_PROG") Then

        ElseIf CK.GBool("MULTIRENT_PROG") Then

        End If
        tvwBaseAlq = nodes
        tvwAlq.Nodes.Clear()
        For Each node In nodes
            tvwAlq.Nodes.Add(node)
        Next
        tvwAlq.Refresh()
    End Sub

#Region "TREEVIEW SEARCH"

    Private Sub selectSearch()
        If ttsMenu.ActiveWindow.Text = twdAlq.Text Then
            dtfSearchAlq.Select()
        ElseIf ttsMenu.ActiveWindow.Text = twdTaller.Text Then
            dtfSearchTaller.Select()
        ElseIf ttsMenu.ActiveWindow.Text = twdConta.Text Then
            dtfSearchConta.Select()
        End If
    End Sub

    Private Sub dtfSearchAlq_TextChanged() Handles dtfSearchAlq.TextChanged
        If dtfSearchAlq.Text_Data <> "" Then
            tvwSearch(tvwAlq, tvwBaseAlq, dtfSearchAlq.Text_Data)
        Else
            treeAlqLoad()
        End If
    End Sub

    Private Sub dtfSearchAlq_KeyDown(sender As Object, e As KeyEventArgs) Handles dtfSearchAlq.KeyDown
        If e.KeyCode = Keys.Escape Then
            dtfSearchAlq.Text_Data = ""
        ElseIf e.KeyCode = Keys.Enter Then
            If tvwAlq.Nodes.Count > 0 And dtfSearchAlq.Text_Data.Length > 0 Then
                Try
                    openNode(tvwAlq.Nodes(0))
                Catch
                End Try
            End If
        End If
    End Sub

    Private Sub dtfSearchTaller_TextChanged() Handles dtfSearchTaller.TextChanged
        If dtfSearchTaller.Text_Data <> "" Then
            tvwSearch(tvwTaller, tvwBaseTaller, dtfSearchTaller.Text_Data)
        Else

        End If
    End Sub

    Private Sub dtfSearchTaller_KeyDown(sender As Object, e As KeyEventArgs) Handles dtfSearchTaller.KeyDown
        If e.KeyCode = Keys.Escape Then
            dtfSearchTaller.Text_Data = ""
        ElseIf e.KeyCode = Keys.Enter Then
            If tvwAlq.Nodes.Count > 0 And dtfSearchAlq.Text_Data.Length > 0 Then
                Try
                    openNode(tvwAlq.Nodes(0))
                Catch
                End Try
            End If
        End If
    End Sub

    Private Sub dtfSearchConta_TextChanged() Handles dtfSearchConta.TextChanged
        If dtfSearchConta.Text_Data <> "" Then
            tvwSearch(tvwConta, tvwBaseConta, dtfSearchConta.Text_Data)
        Else

        End If
    End Sub

    Private Sub dtfSearchConta_KeyDown(sender As Object, e As KeyEventArgs) Handles dtfSearchConta.KeyDown
        If e.KeyCode = Keys.Escape Then
            dtfSearchConta.Text_Data = ""
        ElseIf e.KeyCode = Keys.Enter Then
            If tvwAlq.Nodes.Count > 0 And dtfSearchAlq.Text_Data.Length > 0 Then
                Try
                    openNode(tvwAlq.Nodes(0))
                Catch
                End Try
            End If
        End If
    End Sub

    Private Sub tvwSearch(ByRef tvw As RadTreeView, ByRef tvwBase As ArrayList, ByVal search As String)
        tvw.Nodes.Clear()
        nodeListSearch = New ArrayList
        FindNodeRecursive(tvwBase, search)
        For Each node In nodeListSearch
            tvw.Nodes.Add(node)
        Next
        tvw.Refresh()
    End Sub ' FUNCIONA CORRECTAMENTE

    Private Sub FindNodeRecursive(ByVal nodes As Object, ByVal value As String)
        For Each node As CustomControls.TreeNode In nodes
            If node.Type = CustomControls.TreeNode.nodeType.node Then
                Dim tmp As String
                tmp = deleteAccents(node.Text)
                If InStr(deleteAccents(node.Text), deleteAccents(value), CompareMethod.Text) = 1 Then
                    nodeListSearch.Add(node)
                ElseIf InStr(deleteAccents(node.Text), deleteAccents(Strings.Right(value, value.Length - 1)), CompareMethod.Text) > 0 And InStr(value, "%", CompareMethod.Text) = 1 Then
                    nodeListSearch.Add(node)
                End If
            ElseIf node.Nodes.Count > 0 And node.Type = CustomControls.TreeNode.nodeType.container Then
                FindNodeRecursive(node.Nodes, value)
            End If
        Next
    End Sub ' FUNCIONA CORRECTAMENTE

#End Region ' FUNCIONA CORRECTAMENTE

#End Region

#Region "   Acceso Rápido"

    Private Sub LoadAccesoRapido()
        Dim AR As New AccesoRapido
    End Sub

#End Region

#Region "TRADUC MDI"


    Private Sub traducirForm()
        Try
            If US.GStr("idiomaprg") <> "" Then
                ' TRADUCIR RIBBON Y STARTMENU
                traducirRibbon()
                traducirMenu()
                ribbonMDI.OptionsButton.Text = Translate(ribbonMDI.OptionsButton.Text)
                ribbonMDI.ExitButton.Text = Translate(ribbonMDI.ExitButton.Text)

                ' TRADUCIR TREE ALQUILER
                twdAlq.Text = Translate(twdAlq.Text)
                traducirTree(tvwBaseAlq)
                ' TRADUCIR TREE TALLER
                twdTaller.Text = Translate(twdTaller.Text)
                traducirTree(tvwBaseTaller)
                ' TRADUCIR TREE CONTA
                twdConta.Text = Translate(twdConta.Text)
                traducirTree(tvwBaseConta)

                'tvwSearch(tvwAlq, tvwBaseAlq, "") ' no se si hace falta
                'tvwSearch(tvwTaller, tvwBaseTaller, "")
                'tvwSearch(tvwConta, tvwBaseConta, "")
            End If
        Catch ex As Exception
            kMsgBox.Print("Ha ocurrido un error durante la traducción.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message)
        End Try
    End Sub

    Private Sub desTraducirForm()
        Try
            If US.GStr("idiomaprg") <> "" Then
                desTraducirRibbon()
                desTraducirMenu()
            End If
        Catch ex As Exception
            kMsgBox.Print("Ha ocurrido un error durante la traducción.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message)
        End Try
    End Sub

    Private Sub traducirMenu() 'se traducen todos los items del menu, para las 2 columnas
        For Each mnIt In ribbonMDI.StartMenuItems
            traducirMenuItem(mnIt)
        Next
        For Each mnIt In ribbonMDI.StartMenuRightColumnItems
            traducirMenuItem(mnIt)
        Next
    End Sub ' FUNCIONA CORRECTAMENTE / NO TRADUCE TOOLTIPS

    Private Sub traducirMenuItem(menuItem As Object) 'recursivamente se traducen los items y sus subitems / se pasan como objetos para traducir tanto los items como los buttons
        menuItem.Text = Translate(menuItem.Text)
        If TieneItems(menuItem) Then
            For Each mnIt In menuItem.Items
                traducirMenuItem(mnIt)
            Next
        End If
    End Sub ' FUNCIONA CORRECTAMENTE / NO TRADUCE TOOLTIPS

    Private Function TieneItems(menuItem As Object) As Boolean
        Try
            menuItem.Items.ToString()
            Return True
        Catch : Return False
        End Try
    End Function

    Private Sub traducirTree(ByRef nodes As Object)
        For Each node As CustomControls.TreeNode In nodes
            node.Text = Translate(node.Text)
            If node.Type = CustomControls.TreeNode.nodeType.container Then
                traducirTree(node.Nodes)
            End If
        Next
    End Sub ' FUNCIONA CORRECTAMENTE

    Private Sub traducirRibbon()
        For Each cmdTab As RibbonTab In ribbonMDI.CommandTabs
            For Each rbg As RadRibbonBarGroup In cmdTab.Items
                For Each btn As RadButtonElement In rbg.Items
                    btn.Text = Translate(btn.Text)
                Next
                rbg.Text = Translate(rbg.Text)
            Next
            cmdTab.Text = Translate(cmdTab.Text)
        Next
    End Sub ' FUNCIONA CORRECTAMENTE

    Private Sub desTraducirRibbon()
        For Each cmdTab As RibbonTab In ribbonMDI.CommandTabs
            For Each rbg As RadRibbonBarGroup In cmdTab.Items
                For Each btn As RadButtonElement In rbg.Items
                    btn.Text = deTranslate(btn.Text)
                Next
                rbg.Text = deTranslate(rbg.Text)
            Next
            cmdTab.Text = deTranslate(cmdTab.Text)
        Next
    End Sub ' FUNCIONA CORRECTAMENTE

    Private Sub desTraducirMenu() 'se traducen todos los items del menu, para las 2 columnas
        For Each mnIt In ribbonMDI.StartMenuItems
            desTraducirMenuItem(mnIt)
        Next
        For Each mnIt In ribbonMDI.StartMenuRightColumnItems
            desTraducirMenuItem(mnIt)
        Next
    End Sub ' FUNCIONA CORRECTAMENTE / NO TRADUCE TOOLTIPS

    Private Sub desTraducirMenuItem(menuItem As Object) 'recursivamente se traducen los items y sus subitems / se pasan como objetos para traducir tanto los items como los buttons
        menuItem.Text = deTranslate(menuItem.Text)
        For Each mnIt In menuItem.Items
            desTraducirMenuItem(mnIt)
        Next
    End Sub ' FUNCIONA CORRECTAMENTE / NO TRADUCE TOOLTIPS

#End Region ' A MEDIA IMPLEMENTACION 

    
    Private Sub rmiThemas_Click(sender As Object, e As EventArgs)

    End Sub
End Class
