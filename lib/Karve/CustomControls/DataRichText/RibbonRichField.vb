Imports Telerik.WinControls.UI
Imports Karve.ConfiguracionApp
Imports Karve.Theme
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class RibbonRichField

    Public Event Paste()
    Public Event Copy()
    Public Event Cut()

    Public Event Bold()
    Public Event Italic()
    Public Event Underline()

    Public Event FontFamily(ByVal font As String)
    Public Event FontSize(ByVal size As Integer)
    Public Event AlignChange(ByVal align As Align)
    Public Event LoadFile(ByVal filePath As String, ByVal fileType As DataRichField.TextType)
    Public Event InsertImage(ByVal filePath As String)
    Public Event InsertLink()
    Public Event InsertTable(ByVal filas As Integer, ByVal columnas As Integer)

    Public Enum Align
        Left
        Center
        Right
    End Enum


    ReadOnly Property CommandTabs As RadRibbonBarCommandTabCollection
        Get
            Return rbnEdicion.CommandTabs
        End Get
    End Property

    Public Sub setRibbon()
        btnPaste.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Pegar_Ic)
        btnCopy.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.Copiar_Ic)
        btnCut.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.Cortar_Ic)

        btnBold.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.Bold_Ic)
        btnItalic.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.Italic_Ic)
        btnUnderline.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.Underline_Ic)

        btnMarker.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.ColorSubrayado)
        btnFontColor.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.ColorFuente)

        btnFontSizeUp.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.AumentarFuente)
        btnFontSizeDown.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.DisminuirFuente)

        btnAlignLeft.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.AlinearIzquierda)
        btnAlignCenter.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.AlinearCentrar)
        btnAlignRight.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.AlinearDerecha)

        btnWord.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.MSWord)
        btnHtml.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.HTML_File)
        btnTxt.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.TXT_File)

        btnImagen.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Image)
        btnLink.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.AddLink)
        btnTable.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.InsertTable)

        ConfiguraCintaEdicion(rbnEdicion)
    End Sub

    Private Sub btnPaste_Click(sender As Object, e As EventArgs) Handles btnPaste.Click
        RaiseEvent Paste()
    End Sub

    Private Sub btnCut_Click(sender As Object, e As EventArgs) Handles btnCut.Click
        RaiseEvent Cut()
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        RaiseEvent Copy()
    End Sub

    Private Sub btnBold_Click(sender As Object, e As EventArgs) Handles btnBold.Click
        RaiseEvent Bold()
    End Sub

    Private Sub btnItalic_Click(sender As Object, e As EventArgs) Handles btnItalic.Click
        RaiseEvent Italic()
    End Sub

    Private Sub btnUnderline_Click(sender As Object, e As EventArgs) Handles btnUnderline.Click
        RaiseEvent Underline()
    End Sub

    Public Sub New()
        InitializeComponent()

        cbxFontFamily.Items.Clear()

        Dim fonts As New InstalledFontCollection
        For Each font As FontFamily In fonts.Families
            cbxFontFamily.Items.Add(font.Name)
        Next
    End Sub

    Private Sub cbxFontFamily_TextChanged(sender As Object, e As EventArgs) Handles cbxFontFamily.SelectedIndexChanged
        RaiseEvent FontFamily(cbxFontFamily.EditableElementText)
    End Sub

    Private Sub cbxFontSize_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles cbxFontSize.KeyPress
        Dim Text_Validated As Match = Regex.Match(e.KeyChar, "[\d\b]")
        If Not Text_Validated.Success Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxFontSize_TextChanged(sender As Object, e As EventArgs) Handles cbxFontSize.SelectedIndexChanged, cbxFontSize.Validated
        If cbxFontSize.EditableElementText <> "" Then
            RaiseEvent FontSize(cbxFontSize.EditableElementText)
        End If
    End Sub

    Private Sub btnFontSizeUp_Click(sender As Object, e As EventArgs) Handles btnFontSizeUp.Click
        If cbxFontSize.EditableElementText <> "" Then
            cbxFontSize.EditableElementText += 1
            RaiseEvent FontSize(cbxFontSize.EditableElementText)
        End If
    End Sub

    Private Sub btnFontSizeDown_Click(sender As Object, e As EventArgs) Handles btnFontSizeDown.Click
        If cbxFontSize.EditableElementText <> "" Then
            cbxFontSize.EditableElementText -= 1
            RaiseEvent FontSize(cbxFontSize.EditableElementText)
        End If
    End Sub

    Private Sub btnAlignLeft_Click(sender As Object, e As EventArgs) Handles btnAlignLeft.Click
        btnAlignLeft.IsChecked = False
        btnAlignCenter.IsChecked = False
        btnAlignRight.IsChecked = False
        RaiseEvent AlignChange(Align.Left)
    End Sub

    Private Sub btnAlignCenter_Click(sender As Object, e As EventArgs) Handles btnAlignCenter.Click
        btnAlignLeft.IsChecked = False
        btnAlignCenter.IsChecked = False
        btnAlignRight.IsChecked = False
        RaiseEvent AlignChange(Align.Center)
    End Sub

    Private Sub btnAlignRight_Click(sender As Object, e As EventArgs) Handles btnAlignRight.Click
        btnAlignLeft.IsChecked = False
        btnAlignCenter.IsChecked = False
        btnAlignRight.IsChecked = False
        RaiseEvent AlignChange(Align.Right)
    End Sub

    Private Sub btnFontColor_Click(sender As Object, e As EventArgs) Handles btnFontColor.Click

    End Sub

    Private Sub cbxFontSize_TextChanged(sender As Object, e As Data.PositionChangedEventArgs)

    End Sub

    Private Sub cbxFontFamily_TextChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cbxFontFamily.SelectedIndexChanged

    End Sub

    Private Sub btnWord_Click(sender As Object, e As EventArgs) Handles btnWord.Click
        Dim ofd As New OpenFileDialog
        ofd.Multiselect = False
        ofd.Filter = "Word (.docx)|*.docx|Word 97-2003 (.doc)|*.doc"
        ofd.FilterIndex = 1
        ofd.ShowDialog()
        If ofd.FileName <> "" Then
            RaiseEvent LoadFile(ofd.FileName, DataRichField.TextType.DOCX)
        End If
    End Sub

    Private Sub btnHtml_Click(sender As Object, e As EventArgs) Handles btnHtml.Click
        Dim ofd As New OpenFileDialog
        ofd.Multiselect = False
        ofd.Filter = "HTML (.html)|*.html|HTM (.htm)|*.htm"
        ofd.FilterIndex = 1
        ofd.ShowDialog()
        If ofd.FileName <> "" Then
            RaiseEvent LoadFile(ofd.FileName, DataRichField.TextType.HTML)
        End If
    End Sub

    Private Sub btnTxt_Click(sender As Object, e As EventArgs) Handles btnTxt.Click
        Dim ofd As New OpenFileDialog
        ofd.Multiselect = False
        ofd.Filter = "TXT (.txt)|*.txt"
        ofd.FilterIndex = 1
        ofd.ShowDialog()
        If ofd.FileName <> "" Then
            RaiseEvent LoadFile(ofd.FileName, DataRichField.TextType.Plain)
        End If
    End Sub

    Private Sub btnImagen_Click(sender As Object, e As EventArgs) Handles btnImagen.Click
        Dim ofd As New OpenFileDialog
        ofd.Multiselect = False
        ofd.Filter = "Todas las imagened (.jpg; .jpeg; .png; .bmp; .gif)|*.jpg; *.jpeg; *.png; *.bmp; *.gif)"
        ofd.FilterIndex = 1
        ofd.ShowDialog()
        If ofd.FileName <> "" Then
            RaiseEvent InsertImage(ofd.FileName)
        End If
    End Sub

    Private Sub btnLink_Click(sender As Object, e As EventArgs) Handles btnLink.Click
        RaiseEvent InsertLink()
    End Sub

    Private Sub btnTable_Click(sender As Object, e As EventArgs) Handles btnTable.Click
        RaiseEvent InsertTable(2, 3)
    End Sub
End Class
