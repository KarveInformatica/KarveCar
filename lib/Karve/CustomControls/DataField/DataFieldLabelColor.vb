Imports System.Drawing
Imports Karve.ConfiguracionApp
Imports Karve.Theme
Imports VariablesGlobales
Imports Telerik.WinControls.UI

Public Class DataFieldLabelColor
    Inherits DatafieldLabel

    Public Overrides Property ReadOnly_Data As Boolean
        Get
            Return MyBase.ReadOnly_Data
        End Get
        Set(value As Boolean)
            MyBase.ReadOnly_Data = value
            If value Then txtData.BackColor = Color.Empty
        End Set
    End Property


    Private Sub DataFieldLabelColor_btnActionClick() Handles Me.btnActionClick
        If Theme = ThemeType.Plain Then
            CType(RCD.ColorDialogForm, RadColorDialogForm).ThemeName = "Windows8"
        Else
            CType(RCD.ColorDialogForm, RadColorDialogForm).ThemeName = "Windows7"
        End If

        RCD.SelectedColor = Me.txtData.BackColor
        If RCD.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtData.Text = RCD.SelectedColor.ToArgb
        End If
    End Sub

    Private Sub btnColorLimpiar_Click(sender As Object, e As EventArgs) Handles btnColorLimpiar.Click
        txtData.BackColor = Color.Empty
        txtData.Text = ""
    End Sub

    Private Sub txtData_TextChanged(sender As Object, e As EventArgs) Handles txtData.TextChanged
        If txtData.Text = "" Then
            txtData.BackColor = Color.Empty
            txtData.ForeColor = Color.Empty
        Else
            txtData.BackColor = Color.FromArgb(VD.getInt(txtData.Text))
            txtData.TextBoxElement.ForeColor = Color.FromArgb(VD.getInt(txtData.Text))
        End If
    End Sub

    Private Sub DataFieldLabelColor_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not DesignMode Then
            If TemaAplicacion.IconosMini.Count > 0 Then btnAction.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.Color_Ic)
            If TemaAplicacion.IconosMini.Count > 0 Then btnColorLimpiar.Image = TemaAplicacion.IconosMini(Theme_Definicion.euIconosMini.Del_Ic)
        Else
            btnAction.Image = Nothing
        End If
    End Sub

    Protected Overrides Sub change_width()
        txtData.Width = Me.Width - (Label_Space + 27 * 2)
    End Sub


End Class
