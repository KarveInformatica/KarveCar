Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Windows.Forms

Public Class Theme_Definicion

#Region "   .   VARIABLES   .   "

    Public Enum ThemeType
        Plain
        Crystal
        User
    End Enum

    Enum euIconos
        Clientes_Ic
        Proveedores_Ic
        Facturas_Ic
        Contratos_Ic
        Config_Ic
        Add_Ic
        Save_Ic
        Refresh_Ic
        Delete_Ic
        Start_Ic
        Previus_Ic
        Next_Ic
        End_Ic
        Aceptar_Ic
        Cancelar_Ic
        Buscar_Ic
        Print_Ic
        Export_Ic
        Mail_Ic
        Pegar_Ic
        Copiar_Ic
        Cortar_Ic
        MSWord
        HTML_File
        TXT_File
        Image
        AddLink
        InsertTable
        CerrarCtr
        VerCtr
        ReabrirCtr
        ProlongarCtr
        Facturar
        Cobros
        AddCtr
        Reservas_Ic
    End Enum

    Enum euIconosTree
        Auxiliares_Ict
        Auxiliares_Car
        Check_Ict
        UnCheck_Ict
    End Enum

    Enum euIconosMini
        Buscar_Ic
        Lupa_Ic
        Actualizar_Ic
        Mail_Ic
        Color_Ic
        Del_Ic
#Region "texto"
        Pegar_Ic
        Copiar_Ic
        Cortar_Ic
        Bold_Ic
        Italic_Ic
        Underline_Ic
        AlinearIzquierda
        AlinearDerecha
        AlinearCentrar
        AlinearJustificar
        AumentarFuente
        DisminuirFuente
        ColorFuente
        ColorSubrayado
#End Region

    End Enum

    Dim _Theme As ThemeType = ThemeType.Plain
    Dim _ThemeName As String

    Dim _Iconos As New Dictionary(Of Integer, Bitmap)
    Dim _IconosName As euIconos

    Dim _Iconos_Tree As New Dictionary(Of Integer, Bitmap)
    Dim _Iconos_Tree_Name As euIconosTree

    Dim _IconosMini As New Dictionary(Of Integer, Bitmap)
    Dim _IconosMiniName As euIconosMini

    Dim _Test As New List(Of Bitmap)

    Dim _Boton As New ThemeBotonCinta

    Private _font As Font
    Private _titleFont As Font
    Private _TextAlignment As System.Drawing.ContentAlignment
    Private _ImageAlignment As System.Drawing.ContentAlignment

    Private _HoritzontalTextAlignment As System.Drawing.ContentAlignment
    Private _HoritzontalImageAlignment As System.Drawing.ContentAlignment
#End Region

#Region "   .  PROPIEDADES .   "

    Public Property TextAlignment As System.Drawing.ContentAlignment
        Get
            Return _TextAlignment
        End Get
        Set(value As System.Drawing.ContentAlignment)
            _TextAlignment = value
        End Set
    End Property

    Public Property ImageAlignment As System.Drawing.ContentAlignment
        Get
            Return _ImageAlignment
        End Get
        Set(value As System.Drawing.ContentAlignment)
            _ImageAlignment = value
        End Set
    End Property

    Public Property HoritzontalTextAlignment As System.Drawing.ContentAlignment
        Get
            Return _HoritzontalTextAlignment
        End Get
        Set(value As System.Drawing.ContentAlignment)
            _HoritzontalTextAlignment = value
        End Set
    End Property

    Public Property HoritzontalImageAlignment As System.Drawing.ContentAlignment
        Get
            Return _HoritzontalImageAlignment
        End Get
        Set(value As System.Drawing.ContentAlignment)
            _HoritzontalImageAlignment = value
        End Set
    End Property

    Public Property Theme As ThemeType
        Get
            Return _Theme
        End Get
        Set(value As ThemeType)
            _Theme = value
        End Set
    End Property

    Public Property BotonesCinta As ThemeBotonCinta
        Get
            Return _Boton
        End Get
        Set(value As ThemeBotonCinta)
            _Boton = value
        End Set
    End Property

    Public Property ThemeName As String
        Get
            Return _ThemeName
        End Get
        Set(value As String)
            _ThemeName = value
        End Set
    End Property

    Public Property Iconos As Dictionary(Of Integer, Bitmap)
        Get
            Return _Iconos
        End Get
        Set(value As Dictionary(Of Integer, Bitmap))
            _Iconos = value
        End Set
    End Property

    Public Property IconosMini As Dictionary(Of Integer, Bitmap)
        Get
            Return _IconosMini
        End Get
        Set(value As Dictionary(Of Integer, Bitmap))
            _IconosMini = value
        End Set
    End Property

    Public Property IconosTree As Dictionary(Of Integer, Bitmap)
        Get
            Return _Iconos_Tree
        End Get
        Set(value As Dictionary(Of Integer, Bitmap))
            _Iconos_Tree = value
        End Set
    End Property

    Public Property Font As Font
        Get
            Return _font
        End Get
        Set(value As Font)
            _font = value
        End Set
    End Property

    Public Property TitleFont As Font
        Get
            Return _titleFont
        End Get
        Set(value As Font)
            _titleFont = value
        End Set
    End Property

#End Region

    Public Sub New()
        '_Iconos_Tree.ImageSize = New System.Drawing.Size(12, 12)
        _font = New Font("Verdana", 8.25)
        _TextAlignment = ContentAlignment.BottomCenter
        _ImageAlignment = ContentAlignment.MiddleCenter

        '_IconosMini.ImageSize = New System.Drawing.Size(20, 20)
        '_Iconos.ImageSize = New System.Drawing.Size(40, 40)

        BotonesCinta.AutoSize = True
        BotonesCinta.Height = 60
        BotonesCinta.Width = 60

        BotonesCinta.HoritzontalAutoSize = True
        BotonesCinta.HoritzontalHeight = 20
        BotonesCinta.HoritzontalWidth = 20

        _Test.Add(My.Resources.AlignCenter_mini_Def)

        _HoritzontalTextAlignment = ContentAlignment.MiddleLeft
        _HoritzontalImageAlignment = ContentAlignment.MiddleLeft
    End Sub
End Class
