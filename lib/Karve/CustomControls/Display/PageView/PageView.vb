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

<Designer(DesignerConsts.RadPageViewDesignerString)> _
<TelerikToolboxCategory(ToolboxGroupStrings.ContainersGroup)> _
Public Class PageView
    Inherits RadPageView

    Public Property AddPage As String
        Get
            Return ""
        End Get
        Set(value As String)
            If value <> "" Then
                Dim host As IDesignerHost
                host = CType(Me.GetService(GetType(IDesignerHost)), IDesignerHost)
                If IsNothing(host) Then Return
                Dim page As New PageViewPage
                page = CType(host.CreateComponent(GetType(PageViewPage)), PageViewPage)
                page.Text = page.Name
                Me.Pages.Add(page)
                Me.RootElement.UpdateLayout()
                Me.SelectedPage = page
            End If
        End Set
    End Property

    Private pnlCabezera As CustomControls.Panel

    Public Property PanelCabezera As CustomControls.Panel
        Get
            Return pnlCabezera
        End Get
        Set(value As CustomControls.Panel)
            pnlCabezera = TryCast(value, CustomControls.Panel)
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Me.ThemeClassName = "Telerik.WinControls.UI.RadPageView"
    End Sub

    Private Sub PageView_SelectedPageChanging(sender As Object, e As RadPageViewCancelEventArgs) Handles Me.SelectedPageChanging
        If Not DesignMode Then
            Try
                Dim page As PageViewPage = CType(e.Page, PageViewPage)
                If Not IsNothing(pnlCabezera) And Not IsNothing(page.PanelCabezeraContainer) Then
                    page.PanelCabezeraContainer.Controls.Add(pnlCabezera)
                End If
            Catch
            End Try
        End If
    End Sub
End Class
