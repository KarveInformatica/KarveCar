Public Class ThemeBotonCinta

    Dim _AutoSize As Boolean
    Dim _Height As Integer
    Dim _Width As Integer
    Dim _HoritzontalAutoSize As Boolean
    Dim _HoritzontalHeight As Integer
    Dim _HoritzontalWidth As Integer

    Public Property AutoSize As Boolean
        Get
            Return _AutoSize
        End Get
        Set(value As Boolean)
            _AutoSize = value
        End Set
    End Property

    Public Property Height As Integer
        Get
            Return _Height
        End Get
        Set(value As Integer)
            _Height = value
        End Set
    End Property

    Public Property Width As Integer
        Get
            Return _Width
        End Get
        Set(value As Integer)
            _Width = value
        End Set
    End Property

    Public Property HoritzontalAutoSize As Boolean
        Get
            Return _HoritzontalAutoSize
        End Get
        Set(value As Boolean)
            _HoritzontalAutoSize = value
        End Set
    End Property

    Public Property HoritzontalHeight As Integer
        Get
            Return _HoritzontalHeight
        End Get
        Set(value As Integer)
            _HoritzontalHeight = value
        End Set
    End Property

    Public Property HoritzontalWidth As Integer
        Get
            Return _HoritzontalWidth
        End Get
        Set(value As Integer)
            _HoritzontalWidth = value
        End Set
    End Property

End Class
