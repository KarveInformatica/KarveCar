<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBase
    Inherits Telerik.WinControls.UI.RadForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBase))
        Me.Windows7Theme1 = New Telerik.WinControls.Themes.Windows7Theme()
        Me.CustomShape1 = New Telerik.WinControls.OldShapeEditor.CustomShape()
        Me.tmrUpdBloqueo = New System.Windows.Forms.Timer(Me.components)
        Me.tmrChkBloqueo = New System.Windows.Forms.Timer(Me.components)
        Me.pnlBlock = New Telerik.WinControls.UI.RadPanel()
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.stbBase = New Telerik.WinControls.UI.RadStatusStrip()
        Me.rbnAction = New CustomControls.RibbonBar()
        Me.rbtEdicion = New Telerik.WinControls.UI.RibbonTab()
        Me.rbgEdicion = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.btnAdd = New Telerik.WinControls.UI.RadButtonElement()
        Me.btnSave = New Telerik.WinControls.UI.RadButtonElement()
        Me.btnRecargar = New Telerik.WinControls.UI.RadButtonElement()
        Me.btnDelete = New Telerik.WinControls.UI.RadButtonElement()
        Me.rbgDesplaza = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.btnPrimero = New Telerik.WinControls.UI.RadButtonElement()
        Me.btnAnterior = New Telerik.WinControls.UI.RadButtonElement()
        Me.btnSiguiente = New Telerik.WinControls.UI.RadButtonElement()
        Me.btnUltimo = New Telerik.WinControls.UI.RadButtonElement()
        Me.rbgImpresion = New Telerik.WinControls.UI.RadRibbonBarGroup()
        Me.btnImprimir = New Telerik.WinControls.UI.RadButtonElement()
        Me.btnMail = New Telerik.WinControls.UI.RadButtonElement()
        Me.pvwBase = New CustomControls.PageView()
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rbnAction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomShape1
        '
        Me.CustomShape1.Dimension = New System.Drawing.Rectangle(0, 0, 0, 0)
        '
        'tmrUpdBloqueo
        '
        Me.tmrUpdBloqueo.Interval = 60000
        '
        'tmrChkBloqueo
        '
        Me.tmrChkBloqueo.Interval = 15000
        '
        'pnlBlock
        '
        Me.pnlBlock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlBlock.BackColor = System.Drawing.SystemColors.Control
        Me.pnlBlock.ForeColor = System.Drawing.Color.Black
        Me.pnlBlock.Location = New System.Drawing.Point(0, 473)
        Me.pnlBlock.Name = "pnlBlock"
        Me.pnlBlock.Size = New System.Drawing.Size(123, 125)
        Me.pnlBlock.TabIndex = 1
        Me.pnlBlock.ThemeName = "Windows8"
        CType(Me.pnlBlock.GetChildAt(0), Telerik.WinControls.UI.RadPanelElement).ForeColor = System.Drawing.Color.Black
        CType(Me.pnlBlock.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).LeftColor = System.Drawing.SystemColors.Control
        CType(Me.pnlBlock.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).TopColor = System.Drawing.SystemColors.Control
        CType(Me.pnlBlock.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).RightColor = System.Drawing.SystemColors.Control
        CType(Me.pnlBlock.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).BottomColor = System.Drawing.SystemColors.Control
        CType(Me.pnlBlock.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor2 = System.Drawing.SystemColors.Control
        CType(Me.pnlBlock.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor3 = System.Drawing.SystemColors.Control
        CType(Me.pnlBlock.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor4 = System.Drawing.SystemColors.Control
        CType(Me.pnlBlock.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).InnerColor = System.Drawing.SystemColors.Control
        CType(Me.pnlBlock.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).InnerColor3 = System.Drawing.SystemColors.Control
        CType(Me.pnlBlock.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).InnerColor4 = System.Drawing.SystemColors.Control
        CType(Me.pnlBlock.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.SystemColors.Control
        '
        'stbBase
        '
        Me.stbBase.Location = New System.Drawing.Point(0, 569)
        Me.stbBase.Name = "stbBase"
        Me.stbBase.Size = New System.Drawing.Size(1380, 25)
        Me.stbBase.TabIndex = 2
        Me.stbBase.ThemeName = "Windows8"
        Me.stbBase.Visible = False
        '
        'rbnAction
        '
        Me.rbnAction.CommandTabs.AddRange(New Telerik.WinControls.RadItem() {Me.rbtEdicion})
        Me.rbnAction.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rbnAction.Location = New System.Drawing.Point(0, 594)
        Me.rbnAction.Name = "rbnAction"
        Me.rbnAction.Size = New System.Drawing.Size(1380, 160)
        Me.rbnAction.StartButtonImage = CType(resources.GetObject("rbnAction.StartButtonImage"), System.Drawing.Image)
        Me.rbnAction.TabIndex = 0
        Me.rbnAction.Tag = "1"
        Me.rbnAction.Text = "RadRibbonBar1"
        Me.rbnAction.ThemeName = "Windows8"
        Me.rbnAction.Visible = False
        '
        'rbtEdicion
        '
        Me.rbtEdicion.AccessibleDescription = "Edicion"
        Me.rbtEdicion.AccessibleName = "Edicion"
        Me.rbtEdicion.AutoEllipsis = False
        Me.rbtEdicion.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.rbtEdicion.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.rbtEdicion.IsSelected = True
        Me.rbtEdicion.Items.AddRange(New Telerik.WinControls.RadItem() {Me.rbgEdicion, Me.rbgDesplaza, Me.rbgImpresion})
        Me.rbtEdicion.Name = "rbtEdicion"
        Me.rbtEdicion.Tag = "1"
        Me.rbtEdicion.Text = "Edición"
        Me.rbtEdicion.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.rbtEdicion.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbgEdicion
        '
        Me.rbgEdicion.AccessibleDescription = "a"
        Me.rbgEdicion.AccessibleName = "a"
        Me.rbgEdicion.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.rbgEdicion.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnAdd, Me.btnSave, Me.btnRecargar, Me.btnDelete})
        Me.rbgEdicion.Margin = New System.Windows.Forms.Padding(0)
        Me.rbgEdicion.MaxSize = New System.Drawing.Size(0, 0)
        Me.rbgEdicion.MinSize = New System.Drawing.Size(0, 0)
        Me.rbgEdicion.Name = "rbgEdicion"
        Me.rbgEdicion.Text = "Edición"
        Me.rbgEdicion.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnAdd
        '
        Me.btnAdd.AccessibleDescription = "RadButtonElement1"
        Me.btnAdd.AccessibleName = "RadButtonElement1"
        Me.btnAdd.AutoSize = True
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = Global.Bases.My.Resources.Resources.Add
        Me.btnAdd.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Text = "Agregar"
        Me.btnAdd.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAdd.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnSave
        '
        Me.btnSave.AccessibleDescription = "RadButtonElement2"
        Me.btnSave.AccessibleName = "RadButtonElement2"
        Me.btnSave.AutoSize = True
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.Bases.My.Resources.Resources.Save
        Me.btnSave.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Shape = Nothing
        Me.btnSave.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.[Default]
        Me.btnSave.Text = "Guardar"
        Me.btnSave.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSave.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnRecargar
        '
        Me.btnRecargar.AccessibleDescription = "RadButtonElement3"
        Me.btnRecargar.AccessibleName = "RadButtonElement3"
        Me.btnRecargar.AutoSize = True
        Me.btnRecargar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecargar.Image = Global.Bases.My.Resources.Resources.Refresh
        Me.btnRecargar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnRecargar.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnRecargar.Name = "btnRecargar"
        Me.btnRecargar.Text = "Recargar"
        Me.btnRecargar.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRecargar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnRecargar.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleDescription = "Eliminar"
        Me.btnDelete.AccessibleName = "Eliminar"
        Me.btnDelete.AutoSize = True
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = Global.Bases.My.Resources.Resources.Delete
        Me.btnDelete.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Text = "Eliminar"
        Me.btnDelete.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDelete.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbgDesplaza
        '
        Me.rbgDesplaza.AccessibleDescription = "Desplazamiento"
        Me.rbgDesplaza.AccessibleName = "Desplazamiento"
        Me.rbgDesplaza.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnPrimero, Me.btnAnterior, Me.btnSiguiente, Me.btnUltimo})
        Me.rbgDesplaza.Name = "rbgDesplaza"
        Me.rbgDesplaza.Text = "Desplazamiento"
        Me.rbgDesplaza.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnPrimero
        '
        Me.btnPrimero.AccessibleDescription = "Primero"
        Me.btnPrimero.AccessibleName = "Primero"
        Me.btnPrimero.AutoSize = True
        Me.btnPrimero.Image = Global.Bases.My.Resources.Resources.Start_Def
        Me.btnPrimero.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnPrimero.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Text = "Primero"
        Me.btnPrimero.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrimero.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPrimero.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnAnterior
        '
        Me.btnAnterior.AccessibleDescription = "Anterior"
        Me.btnAnterior.AccessibleName = "Anterior"
        Me.btnAnterior.AutoSize = True
        Me.btnAnterior.Image = Global.Bases.My.Resources.Resources.Previus_Def
        Me.btnAnterior.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAnterior.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Text = "Anterior"
        Me.btnAnterior.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAnterior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAnterior.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnSiguiente
        '
        Me.btnSiguiente.AccessibleDescription = "Siguiente"
        Me.btnSiguiente.AccessibleName = "Siguiente"
        Me.btnSiguiente.AutoSize = True
        Me.btnSiguiente.Image = Global.Bases.My.Resources.Resources.Next_Def
        Me.btnSiguiente.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnSiguiente.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Text = "Siguiente"
        Me.btnSiguiente.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSiguiente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSiguiente.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnUltimo
        '
        Me.btnUltimo.AccessibleDescription = "Último"
        Me.btnUltimo.AccessibleName = "Último"
        Me.btnUltimo.AutoSize = True
        Me.btnUltimo.Image = Global.Bases.My.Resources.Resources.End_Def
        Me.btnUltimo.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnUltimo.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Text = "Último"
        Me.btnUltimo.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnUltimo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnUltimo.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'rbgImpresion
        '
        Me.rbgImpresion.AccessibleDescription = "Impresion"
        Me.rbgImpresion.AccessibleName = "Impresion"
        Me.rbgImpresion.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnImprimir, Me.btnMail})
        Me.rbgImpresion.Name = "rbgImpresion"
        Me.rbgImpresion.Text = "Impresion"
        Me.rbgImpresion.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnImprimir
        '
        Me.btnImprimir.AccessibleDescription = "Imprimir"
        Me.btnImprimir.AccessibleName = "Imprimir"
        Me.btnImprimir.AutoSize = True
        Me.btnImprimir.Image = Global.Bases.My.Resources.Resources.Print_Def
        Me.btnImprimir.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnImprimir.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'btnMail
        '
        Me.btnMail.AccessibleDescription = "eMail"
        Me.btnMail.AccessibleName = "eMail"
        Me.btnMail.Image = Global.Bases.My.Resources.Resources.Mail_Def
        Me.btnMail.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnMail.Name = "btnMail"
        Me.btnMail.Text = "eMail"
        Me.btnMail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnMail.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'pvwBase
        '
        Me.pvwBase.AddPage = ""
        Me.pvwBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pvwBase.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.pvwBase.Location = New System.Drawing.Point(0, 0)
        Me.pvwBase.Name = "pvwBase"
        Me.pvwBase.PageBackColor = System.Drawing.SystemColors.Control
        Me.pvwBase.PanelCabezera = Nothing
        Me.pvwBase.Size = New System.Drawing.Size(1380, 569)
        Me.pvwBase.TabIndex = 0
        Me.pvwBase.Text = "RadPageView1"
        Me.pvwBase.ThemeName = "Windows8"
        Me.pvwBase.ViewMode = Telerik.WinControls.UI.PageViewMode.Backstage
        CType(Me.pvwBase.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.StripViewItemContainer).MinSize = New System.Drawing.Size(125, 0)
        '
        'frmBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1380, 754)
        Me.Controls.Add(Me.pnlBlock)
        Me.Controls.Add(Me.pvwBase)
        Me.Controls.Add(Me.stbBase)
        Me.Controls.Add(Me.rbnAction)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.KeyPreview = True
        Me.Name = "frmBase"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "RadRibbonBar1"
        Me.ThemeName = "Windows8"
        CType(Me.pnlBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.stbBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rbnAction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pvwBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CustomShape1 As Telerik.WinControls.OldShapeEditor.CustomShape
    Friend WithEvents tmrUpdBloqueo As System.Windows.Forms.Timer
    Friend WithEvents tmrChkBloqueo As System.Windows.Forms.Timer
    Protected Friend WithEvents pnlBlock As Telerik.WinControls.UI.RadPanel
    Public WithEvents pvwBase As CustomControls.PageView
    Protected Friend WithEvents stbBase As Telerik.WinControls.UI.RadStatusStrip
    Protected WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme
    Protected WithEvents Windows7Theme1 As Telerik.WinControls.Themes.Windows7Theme
    Protected WithEvents rbtEdicion As Telerik.WinControls.UI.RibbonTab
    Protected WithEvents btnAdd As Telerik.WinControls.UI.RadButtonElement
    Protected WithEvents btnSave As Telerik.WinControls.UI.RadButtonElement
    Protected WithEvents btnRecargar As Telerik.WinControls.UI.RadButtonElement
    Protected WithEvents btnDelete As Telerik.WinControls.UI.RadButtonElement
    Protected WithEvents rbgEdicion As Telerik.WinControls.UI.RadRibbonBarGroup
    Protected WithEvents rbgDesplaza As Telerik.WinControls.UI.RadRibbonBarGroup
    Protected WithEvents btnPrimero As Telerik.WinControls.UI.RadButtonElement
    Protected WithEvents btnAnterior As Telerik.WinControls.UI.RadButtonElement
    Protected WithEvents btnSiguiente As Telerik.WinControls.UI.RadButtonElement
    Protected WithEvents btnUltimo As Telerik.WinControls.UI.RadButtonElement
    Protected WithEvents rbgImpresion As Telerik.WinControls.UI.RadRibbonBarGroup
    Protected WithEvents btnImprimir As Telerik.WinControls.UI.RadButtonElement
    Protected WithEvents btnMail As Telerik.WinControls.UI.RadButtonElement
    Protected WithEvents rbnAction As CustomControls.RibbonBar
End Class

