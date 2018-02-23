Public Class Linea

#Region "Variables"

    Private _cantidad As Double = 1
    Private _dias As Double = 1
    Private _precio As Double = 0
    Private _preciobruto = 0
    Private _dto As Double = 0
    Private _subtotal As Double = 0
    Private _iva As Double = 0
    Private _cuota As Double = 0
    Private _total As Double = 0
    Private _incluido As Boolean = True

#End Region


#Region "Propiedades"

    Property Cantidad As Double
        Get
            Return _cantidad
        End Get
        Set(value As Double)
            _cantidad = value
        End Set
    End Property

    Property Dias As Double
        Get
            Return _dias
        End Get
        Set(value As Double)
            _dias = value
        End Set
    End Property

    Property Precio As Double
        Get
            Return _precio
        End Get
        Set(value As Double)
            _precio = value
        End Set
    End Property

    Property DTO As Double
        Get
            Return _dto
        End Get
        Set(value As Double)
            _dto = value
        End Set
    End Property

    Property Subtotal As Double
        Get
            Return _subtotal
        End Get
        Set(value As Double)
            _subtotal = value
        End Set
    End Property

    Property IVA As Double
        Get
            Return _iva
        End Get
        Set(value As Double)
            _iva = value
        End Set
    End Property

    Property Total As Double
        Get
            Return _total
        End Get
        Set(value As Double)
            _total = value
        End Set
    End Property

    Property Incluido As Boolean
        Get
            Return _incluido
        End Get
        Set(value As Boolean)
            _incluido = value
        End Set
    End Property

#End Region

    Public Sub calcularTotalLinea()
        _preciobruto = _cantidad * _dias * _precio
        _subtotal = _preciobruto - (_preciobruto * _dto / 100)
        _cuota = _subtotal * _iva / 100
        _total = _subtotal + _cuota
    End Sub

End Class
