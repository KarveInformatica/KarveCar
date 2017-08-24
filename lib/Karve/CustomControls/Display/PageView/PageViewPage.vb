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
Imports Telerik.WinControls


<Designer(DesignerConsts.RadPageViewPageDesignerString)> _
Public Class PageViewPage
    Inherits RadPageViewPage

    Private pnlCabezeraContainer As CustomControls.Panel

    Public Property PanelCabezeraContainer As CustomControls.Panel
        Get
            Return pnlCabezeraContainer
        End Get
        Set(value As CustomControls.Panel)
            pnlCabezeraContainer = TryCast(value, CustomControls.Panel)
        End Set
    End Property

End Class
