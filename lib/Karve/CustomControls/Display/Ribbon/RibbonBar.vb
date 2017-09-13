Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports Telerik.WinControls.Design
Imports System.ComponentModel.Design
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.UI.Design
Imports System.Windows.Forms.Design
Imports Telerik.WinControls

<TelerikToolboxCategory(ToolboxGroupStrings.MenuAndToolbarsGroup)> _
<Designer(DesignerConsts.RadRibbonBarDesignerString)> _
<ToolboxItem(True)> _
Public Class RibbonBar
    Inherits Telerik.WinControls.UI.RadRibbonBar

    Public Sub New()
        MyBase.New()
        Me.ThemeClassName = "Telerik.WinControls.UI.RadRibbonBar"
    End Sub

    Public Sub addNewTab()

    End Sub

    Public Property Change As String
        Get
            Return True
        End Get
        Set(value As String)
            Me.Text = value
        End Set
    End Property

    'Public Sub addNewTab()
    '    Dim host As IDesignerHost = CType(GetService(GetType(IDesignerHost)), IDesignerHost)

    '    Dim selectionService As ISelectionService = CType(GetService(GetType(ISelectionService)), ISelectionService)
    '    Dim newItem As RibbonTab = CType(host.CreateComponent(GetType(RibbonTab)), RibbonTab)

    '    Dim text As String = newItem.Site.Name
    '    newItem.SetValueAtDesignTime(RadItem.TextProperty, text)
    '    Dim ribbonBar As RadRibbonBar = CType(Me, RadRibbonBar)

    '    ribbonBar.CommandTabs.Insert(ribbonBar.CommandTabs.Count - 1, newItem)
    '    'selectionService.SetSelectedComponents(new IComponent[] { newItem })
    'End Sub
End Class
