<Serializable()> _
Public Class Horario
    Private hIni As TimeSpan
    Private hFin As TimeSpan

    Public Sub New()
        Me.hIni = New TimeSpan(0, 0, 0)
        Me.hFin = New TimeSpan(23, 59, 0)
    End Sub

    Public Sub New(ByVal HoraInicio As TimeSpan, ByVal HoraFinal As TimeSpan)
        Me.hIni = HoraInicio
        Me.hFin = HoraFinal
    End Sub

    Property HoraInicio As TimeSpan
        Get
            Return hIni
        End Get
        Set(value As TimeSpan)
            hIni = value
        End Set
    End Property

    Property HoraFinal As TimeSpan
        Get
            Return hFin
        End Get
        Set(value As TimeSpan)
            hFin = value
        End Set
    End Property
End Class
