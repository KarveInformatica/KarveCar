Imports Telerik.WinControls.UI
Imports VariablesGlobales
Imports System.Windows.Forms
Imports System.Drawing
Public Class Panel
    Inherits RadPanel

#Region "Variables"
    'Protected _Theme As ThemeType = ThemeType.Plain
    Private WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme = New Telerik.WinControls.Themes.Windows8Theme()
    Protected _isSpace As Boolean = False
    Protected _numRows As Integer = 0
    Protected _reorder As Boolean = True
    Protected _controlResize As Boolean = False
    Private WidthBefore As Integer
    Private _AutoSize As Boolean = False

    Private _ChangeDock As Boolean = True
#End Region

#Region "Propiedades"
    'Property Theme As ThemeType
    '    Get
    '        Return _Theme
    '    End Get
    '    Set(value As ThemeType)
    '        _Theme = value
    '        If _Theme = ThemeType.Plain Then
    '            Me.ThemeName = "Windows8"
    '            'Me.BackColor = Drawing.SystemColors.Control
    '            'Me.PanelElement.PanelBorder.ForeColor = Drawing.SystemColors.Control
    '        Else
    '            Me.ThemeName = "Windows7"
    '            'Me.BackColor = Drawing.SystemColors.Control
    '            'Me.PanelElement.PanelBorder.ForeColor = Drawing.Color.Black
    '        End If
    '    End Set
    'End Property

    Property Control_Resize As Boolean
        Get
            Return _controlResize
        End Get
        Set(value As Boolean)
            _controlResize = value
        End Set
    End Property

    Property isSpace As Boolean
        Get
            Return _isSpace
        End Get
        Set(value As Boolean)
            _isSpace = value
            If _isSpace Then
                Me.Width = 6
                Me.Height = 26
            End If
        End Set
    End Property

    Property numRows As Integer
        Get
            Return _numRows
        End Get
        Set(value As Integer)
            _numRows = value
            If _numRows > 0 Then
                Me.Height = _numRows * 26
            End If
        End Set
    End Property

    Property Reorder As Boolean
        Get
            Return _reorder
        End Get
        Set(value As Boolean)
            _reorder = value
        End Set
    End Property

    Property BorderColor As Drawing.Color
        Get
            Return Me.PanelElement.PanelBorder.ForeColor
        End Get
        Set(value As Drawing.Color)
            Me.PanelElement.PanelBorder.ForeColor = value
            Me.PanelElement.PanelBorder.TopColor = value
            Me.PanelElement.PanelBorder.BottomColor = value
            Me.PanelElement.PanelBorder.RightColor = value
            Me.PanelElement.PanelBorder.LeftColor = value
        End Set
    End Property

    Property Auto_Size As Boolean
        Get
            Return _AutoSize
        End Get
        Set(value As Boolean)
            _AutoSize = value
        End Set
    End Property

    Property ChangeDock As Boolean
        Get
            Return _ChangeDock
        End Get
        Set(value As Boolean)
            _ChangeDock = value
        End Set
    End Property

#End Region

#Region "Eventos"

    Private Sub Panel_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        If _reorder Then
            TabReorder()
        End If
        Me.PanelElement.PanelBorder.ForeColor = SystemColors.Control
        Me.PanelElement.PanelBorder.TopColor = SystemColors.Control
        Me.PanelElement.PanelBorder.BottomColor = SystemColors.Control
        Me.PanelElement.PanelBorder.RightColor = SystemColors.Control
        Me.PanelElement.PanelBorder.LeftColor = SystemColors.Control
        If Not DesignMode And isSpace Then
            Me.BackColor = SystemColors.Control
        End If
    End Sub

    Public Sub New()
        Me.Text = ""
        'Me.BackColor = Drawing.SystemColors.Control
    End Sub

    Private Sub Panel_Initialized(sender As Object, e As EventArgs) Handles Me.Initialized
        Me.Text = ""
        'Me.BackColor = Drawing.SystemColors.Control
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If _AutoSize Then
            AutoResize()
        End If
    End Sub

    Private Sub Panel_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If _controlResize Then
            CtrResize()
            WidthBefore = Me.Width
        End If
    End Sub
#End Region

#Region "Funciones"
    Public Sub TabReorder()
        Dim result = From c As Control In Me.Controls
                     Where c.Visible = True
                     Order By c.Location.Y, c.Location.X
                     Select c

        Dim i As Integer = 0
        For Each ctr As Control In result
            ctr.TabIndex = i
            i += 1
        Next

    End Sub

    Public Sub PosReorder()
        Dim result = From c As Control In Me.Controls
                     Where c.Visible = True
                     Order By c.Location.Y
                     Select c

        Dim YAnt As Integer = 0
        Dim ctrAnt As Control = Nothing
        Dim i = 0
        For Each ctr As Control In result
            If YAnt <> 0 Then
                If ctr.Location.Y = YAnt Then
                    YAnt = ctr.Location.Y
                    ctr.Location = New Drawing.Point(ctr.Location.X, ctrAnt.Location.Y)
                Else
                    YAnt = ctr.Location.Y
                    ctr.Location = New Drawing.Point(ctr.Location.X, ctrAnt.Location.Y + ctrAnt.Height + 6)
                End If
            Else
                YAnt = ctr.Location.Y
            End If
            ctr.TabIndex = i
            ctrAnt = ctr
            i += 1
        Next
    End Sub

    Public Sub CtrResize()

        Dim spaceQuery = From c As Control In Me.Controls
                     Where c.Visible = True _
                     And c.GetType = GetType(CustomControls.Panel)
                     Order By c.Location.Y, c.Location.X
                     Select c

        Dim space As Integer = spaceQuery.Where(Function(c) CType(c, CustomControls.Panel).isSpace = True).Sum(Function(c) c.Width)

        Dim totalWidth As Integer = Me.Width - space

        Dim oldWidthQuery = From c As Control In Me.Controls
                     Where c.Visible = True
                     Order By c.Location.Y, c.Location.X
                     Select c

        Dim oldWidth As Integer = oldWidthQuery.Sum(Function(c) c.Width) - space

        If totalWidth <> 0 And oldWidth <> 0 And totalWidth <> oldWidth Then
            Dim variacion As Double = Me.Width / WidthBefore
            variacion = Math.Round(variacion, 2)

            For Each ctr As CustomControls.Panel In spaceQuery
                If Not CType(ctr, CustomControls.Panel).isSpace Then
                    ctr.Width = ctr.Width * variacion
                End If
            Next

            Dim ctrQuery = From c As Control In Me.Controls
                     Where c.Visible = True _
                     And c.GetType <> GetType(CustomControls.Panel) _
                     And c.Dock <> DockStyle.Top And Dock <> DockStyle.None
                     Order By c.Location.Y, c.Location.X
                     Select c

            For Each ctr As Control In ctrQuery
                ctr.Width = ctr.Width * variacion
            Next
        End If
    End Sub

    Public Sub AutoResize()
        Dim heightQuery = (From c As Control In Me.Controls
                     Where c.Visible = True _
                     Select c.Height).Sum

        Me.Height = heightQuery
    End Sub
#End Region
   
    
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class