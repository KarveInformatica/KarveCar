Imports System.Threading
Imports Karve.ConfiguracionApp

Public Class MDI_kv
    Dim b As Button

    Public frmSplash As New Splash

    Private Sub MDI_kv_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        lblUsu.Text = US.GStr("CODIGO")
        lblOfi.Text = CO.GStr("OFICINA")
    End Sub

    Private Sub MDI_kv_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Arranca.Main()
        btnCambioOfi.Enabled = CK.GStr("K_OFI") = ""
    End Sub
    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim r As New Random()
        Static i As Integer
        i += 1
        Dim key As String = "f" + i.ToString()
        'Crea el nuevo form (copia de form2)
        Dim f As New Form
        f.BackColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))
        f.Text = String.Format("Nuevo form {0}", i)
        'Crea el tab que lo contiene
        Me.Tabs.TabPages.Add(key, f.Text)
        f.TopLevel = False
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Dock = DockStyle.Fill
        Me.Tabs.TabPages(key).Controls.Add(f)
        Me.Tabs.SelectedTab = Me.Tabs.TabPages(key)
        'Asigna el nuevo form al tag del tabpage
        Me.Tabs.TabPages(key).Tag = f
        'Por si desde el propio form quieres cerrar y eliminar el tab
        f.Tag = Me.Tabs.TabPages(key)
        f.Show()
        Dim b = New Button
        b.Dock = DockStyle.Left
        b.Width = 100
        b.Text = f.Text
        Panel2.Controls.Add(b)
    End Sub

    Private Sub btnRelogin_Click(sender As Object, e As EventArgs) Handles btnRelogin.Click
        Relogin()
        Me.MDI_kv_Activated(Me, e)
    End Sub

    Private Sub btnCambioOfi_Click(sender As Object, e As EventArgs) Handles btnCambioOfi.Click
        Relogin()
        Me.MDI_kv_Activated(Me, e)
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        VariablesGlobales.OpenForm("KarvePruebas.Form1")
    End Sub
End Class