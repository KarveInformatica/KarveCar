<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class kEnvioMail
    Inherits Karve.EnvioMail.EnvioMail

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.RadRibbonFormBehavior1 = New Telerik.WinControls.UI.RadRibbonFormBehavior()
        CType(Me.pnlRpt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlMail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMail.SuspendLayout()
        CType(Me.stbStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'drfBody
        '
        Me.drfBody.Location = New System.Drawing.Point(10, 159)
        Me.drfBody.Size = New System.Drawing.Size(635, 354)
        '
        'dtfSubject
        '
        Me.dtfSubject.Location = New System.Drawing.Point(10, 55)
        Me.dtfSubject.Size = New System.Drawing.Size(635, 26)
        '
        'dtfRcpt
        '
        Me.dtfRcpt.Location = New System.Drawing.Point(10, 29)
        Me.dtfRcpt.Show_Button = False
        Me.dtfRcpt.Size = New System.Drawing.Size(635, 26)
        '
        'dtfFrom
        '
        Me.dtfFrom.Location = New System.Drawing.Point(10, 3)
        Me.dtfFrom.Show_Button = False
        Me.dtfFrom.Size = New System.Drawing.Size(635, 26)
        '
        'dtfTextoEstandar
        '
        Me.dtfTextoEstandar.Location = New System.Drawing.Point(10, 133)
        Me.dtfTextoEstandar.Size = New System.Drawing.Size(635, 26)
        '
        'flsAttachments
        '
        Me.flsAttachments.Location = New System.Drawing.Point(10, 81)
        Me.flsAttachments.Size = New System.Drawing.Size(635, 52)
        '
        'pnlRpt
        '
        Me.pnlRpt.Location = New System.Drawing.Point(648, 162)
        Me.pnlRpt.Padding = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.pnlRpt.Size = New System.Drawing.Size(648, 516)
        '
        'pnlMail
        '
        Me.pnlMail.Location = New System.Drawing.Point(0, 162)
        Me.pnlMail.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.pnlMail.Size = New System.Drawing.Size(648, 516)
        '
        'rbgImpresion
        '
        Me.rbgImpresion.Bounds = New System.Drawing.Rectangle(0, 0, 126, 94)
        Me.rbgImpresion.Margin = New System.Windows.Forms.Padding(2)
        Me.rbgImpresion.MaxSize = New System.Drawing.Size(0, 100)
        Me.rbgImpresion.MinSize = New System.Drawing.Size(20, 86)
        '
        'btnPrint
        '
        Me.btnPrint.Bounds = New System.Drawing.Rectangle(0, 0, 52, 72)
        '
        'btnExport
        '
        Me.btnExport.Bounds = New System.Drawing.Rectangle(0, 0, 52, 72)
        '
        'rbgNavegacion
        '
        Me.rbgNavegacion.Bounds = New System.Drawing.Rectangle(0, 0, 218, 94)
        Me.rbgNavegacion.Margin = New System.Windows.Forms.Padding(2)
        Me.rbgNavegacion.MaxSize = New System.Drawing.Size(0, 100)
        Me.rbgNavegacion.MinSize = New System.Drawing.Size(20, 86)
        '
        'btnFirstPage
        '
        Me.btnFirstPage.Bounds = New System.Drawing.Rectangle(0, 0, 45, 72)
        '
        'btnPrevPage
        '
        Me.btnPrevPage.Bounds = New System.Drawing.Rectangle(0, 0, 47, 72)
        '
        'btnNextPage
        '
        Me.btnNextPage.Bounds = New System.Drawing.Rectangle(0, 0, 53, 72)
        '
        'btnLastPage
        '
        Me.btnLastPage.Bounds = New System.Drawing.Rectangle(0, 0, 39, 72)
        '
        'RadRibbonBarGroup3
        '
        Me.RadRibbonBarGroup3.Bounds = New System.Drawing.Rectangle(0, 0, 174, 94)
        Me.RadRibbonBarGroup3.Margin = New System.Windows.Forms.Padding(2)
        Me.RadRibbonBarGroup3.MaxSize = New System.Drawing.Size(0, 100)
        Me.RadRibbonBarGroup3.MinSize = New System.Drawing.Size(20, 86)
        '
        'btnBuscar
        '
        Me.btnBuscar.Bounds = New System.Drawing.Rectangle(0, 0, 65, 22)
        '
        'cbxZoom
        '
        Me.cbxZoom.Bounds = New System.Drawing.Rectangle(0, 0, 70, 22)
        '
        'btnRefresh
        '
        Me.btnRefresh.Bounds = New System.Drawing.Rectangle(0, 0, 75, 22)
        '
        'lblPagAct
        '
        Me.lblPagAct.Bounds = New System.Drawing.Rectangle(0, 0, 135, 17)
        Me.stbStatus.SetSpring(Me.lblPagAct, False)
        '
        'lblMaxPag
        '
        Me.lblMaxPag.Bounds = New System.Drawing.Rectangle(0, 0, 133, 17)
        Me.stbStatus.SetSpring(Me.lblMaxPag, False)
        '
        'lblZoom
        '
        Me.lblZoom.Bounds = New System.Drawing.Rectangle(0, 0, 82, 17)
        Me.stbStatus.SetSpring(Me.lblZoom, False)
        '
        'rbtImpresion
        '
        Me.rbtImpresion.AutoEllipsis = True
        Me.rbtImpresion.Bounds = New System.Drawing.Rectangle(0, 0, 46, 28)
        '
        'stbStatus
        '
        Me.stbStatus.Location = New System.Drawing.Point(0, 678)
        Me.stbStatus.Size = New System.Drawing.Size(1291, 25)
        '
        'RadRibbonFormBehavior1
        '
        Me.RadRibbonFormBehavior1.Form = Me
        '
        'kEnvioMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1291, 703)
        Me.FormBehavior = Me.RadRibbonFormBehavior1
        Me.IconScaling = Telerik.WinControls.Enumerations.ImageScaling.None
        Me.Name = "kEnvioMail"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Envio Mail"
        CType(Me.pnlRpt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlMail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMail.ResumeLayout(False)
        CType(Me.stbStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme
    Friend WithEvents RadRibbonFormBehavior1 As Telerik.WinControls.UI.RadRibbonFormBehavior
End Class

