Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.UI.Docking
Imports System.Drawing

Public Module Modulo_VariablesGlobales
    Public cnxString As String
    Public providerName As String
    Public ColorSel As System.Drawing.Color = Drawing.Color.FromArgb(204, 226, 251)
    Public VGdockMDI As RadDock
    Public VGribbonMDI As Telerik.WinControls.UI.RadRibbonBar
    Public VGribbonMDICopy As Telerik.WinControls.UI.RadRibbonBar
    Public VMenu As Telerik.WinControls.UI.Docking.ToolTabStrip
    Public VStatus As Telerik.WinControls.UI.RadStatusStrip
    Public sEmpresaCons As String
    Public Const cTituloLupas As String = "Consulta de " & vbNewLine
    Public VD As New ValidateData
    Private showErrors As Boolean = True

    Public Enum ThemeType
        Plain
        Crystal
    End Enum

    Private Function check_form(ByRef nom As String, ByRef mdiparent As Form) As Boolean
        check_form = False
        For Each ChildForm As Form In mdiparent.MdiChildren
            If ChildForm.Name = nom Then
                check_form = True
                ChildForm.BringToFront()
                ChildForm.Focus()
                Exit Function
            End If
        Next
    End Function

    Public Function OpenForm(ByVal nomForm As String) As RadForm
        Dim dllName As String = nomForm.Substring(0, nomForm.LastIndexOf("."))
        Dim dllPath As String = Application.StartupPath & "/" & dllName & ".dll"
        Dim extAssembly As System.Reflection.Assembly = System.Reflection.Assembly.LoadFrom(dllPath)
        Dim extForm As Form = extAssembly.CreateInstance(nomForm, True)
        Return extForm
    End Function

    Public Sub OpenTab(ByVal nomForm As String)
        Dim frm As RadForm = OpenForm(nomForm)
        OpenTab(frm)
    End Sub

    Public Sub OpenTab(ByVal nomForm As String, Value As String)
        Dim frm As RadForm = OpenForm(nomForm)
        OpenTab(frm, Value)
    End Sub

    Public Sub OpenTab(ByVal frm As RadForm, Value As String)

        Try
            Cursor.Current = Cursors.WaitCursor
            Dim docWindow As New DocumentWindow
            Dim frmX As New Object
            frm.Dock = DockStyle.Fill
            frm.TopLevel = False
            frm.FormBorderStyle = FormBorderStyle.None
            docWindow.Controls.Add(frm)
            docWindow.Text = frm.Text
            AddHandler frm.FormClosed, AddressOf CloseTab
            frmX = CType(frm, Object)
            frmX.Show()
            frmX.CodigoEdicion = Value
            Try
                docWindow.Image = frmX.Image
            Catch
            End Try
            docWindow.Text = frmX.Text ' se asigna aqui porque es cuando ya esta traducido
            VGdockMDI.AddDocument(docWindow)
            VGdockMDI.ActiveWindow = docWindow
            If Value <> "" Then
                frmX.Load_Reg()
            Else : frmX.AgregarReg()
            End If
        Catch ex As Exception
            If showErrors Then
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End If
        Finally
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Public Sub OpenTab(ByVal frm As RadForm)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim docWindow As New DocumentWindow
            frm.Dock = DockStyle.Fill
            frm.TopLevel = False
            frm.FormBorderStyle = FormBorderStyle.None
            docWindow.Controls.Add(frm)
            docWindow.Text = frm.Text
            AddHandler frm.FormClosed, AddressOf CloseTab
            frm.Show()
            Try
                docWindow.Image = CObj(frm).Image
            Catch
            End Try
            frm.Refresh()
            docWindow.Text = frm.Text ' se asigna aqui porque es cuando ya esta traducido
            VGdockMDI.AddDocument(docWindow)
            VGdockMDI.ActiveWindow = docWindow
        Catch ex As Exception
            If showErrors Then
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End If
        Finally
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Public Sub CloseTab(sender As Object, e As FormClosedEventArgs)
        Try
            Dim frm As RadForm = CType(sender, RadForm)
            Dim doc As DocumentWindow = frm.Parent
            frm.Dispose()
            doc.Close()
            System.GC.Collect()
        Catch ex As Exception
            If showErrors Then
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End If
        End Try
    End Sub

    Public Function OpenDialog(ByVal nomForm As String) As DialogResult
        Cursor.Current = Cursors.WaitCursor
        Dim frm As RadForm = OpenForm(nomForm)
        frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frm.StartPosition = FormStartPosition.CenterScreen
        OpenDialog = frm.ShowDialog()
        Cursor.Current = Cursors.Arrow
    End Function

End Module
