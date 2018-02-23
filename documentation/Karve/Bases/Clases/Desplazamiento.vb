Imports VariablesGlobales

Public Class Desplazamiento
    Dim _iDesplaza As Integer
    Dim _pk As String
    Dim SQL As New CustomControls.DataGridDefinicion

    Property Tablas As CustomControls.DataGridTables
        Get
            Return SQL.TablasQuery
        End Get
        Set(value As CustomControls.DataGridTables)
            SQL.TablasQuery = value
        End Set
    End Property

    Property Reglas As CustomControls.DataGridRules
        Get
            Return SQL.Clausulas
        End Get
        Set(value As CustomControls.DataGridRules)
            SQL.Clausulas = value
        End Set
    End Property

    Property Ordenes As CustomControls.DataGridOrdenColumnas
        Get
            Return SQL.Ordenes
        End Get
        Set(value As CustomControls.DataGridOrdenColumnas)
            SQL.Ordenes = value
        End Set
    End Property

    Property ClaveBuscar As String
        Get
            Return _pk
        End Get
        Set(value As String)
            _pk = value
        End Set
    End Property

    Public Function RegistroActual(sValue As String) As Integer
        If SQL.TablasQuery.Count = 0 Then Return 0 : Exit Function
        Dim sBegin As String = SQL.ConstruyeSQLDesplaza(_pk)
        If _pk <> "" And sValue <> "" And sBegin <> "" Then
            'Si tenemos definido valor y campo por el que buscar, y el cuerpo de la consulta para la lista virtual
            Dim sWh As String = " WHERE VALOR = " & vd.setApostrofa(sValue)
            Dim sSQL As String = "  SELECT TOP 1 X " & vbNewLine & _
                                 "  FROM " & vbNewLine & _
                                 "      (   " & vbNewLine & _
                                 sBegin & vbNewLine & _
                                 "      )   X   " & vbNewLine & _
                                 sWh & vbNewLine & _
                                 "  ORDER BY X "

            _iDesplaza = VD.getInt(SQL.DBConnection.executeQuery(sSQL))
        End If
        Return _iDesplaza
    End Function

    Public Function RegistroFinal() As Integer
        Dim sBegin As String = SQL.ConstruyeSQLDesplaza(_pk)
        Dim sSQL As String = "  SELECT MAX(X) ULTIMO " & vbNewLine & _
                             "  FROM " & vbNewLine & _
                             "      (   " & vbNewLine & _
                             sBegin & vbNewLine & _
                             "      )   X   "
        Return VD.getInt(SQL.DBConnection.executeQuery(sSQL))
    End Function

    Private Function ConsultaRegistro(idReg As Integer) As String
        Dim sSQL As String = SQL.ConstruyeSQL(idReg, _pk)
        Return SQL.DBConnection.executeQuery(sSQL)
    End Function

    Public Function Primero() As String
        Return ConsultaRegistro(1)
    End Function

    Public Function Anterior() As String
        If _iDesplaza - 1 > 0 Then
            Return ConsultaRegistro(_iDesplaza - 1)
        Else
            Dim kMsgBox As New CustomControls.kMsgBox
            kMsgBox.Print("Ya está en el Primer Registro de la lista.", _
                        CustomControls.kMsgBox.kMsgBoxStyle.Information)
            Return ConsultaRegistro(_iDesplaza)
        End If
    End Function

    Public Function Siguiente() As String
        If _iDesplaza < RegistroFinal() Then
            Return ConsultaRegistro(_iDesplaza + 1)
        Else
            Dim kMsgBox As New CustomControls.kMsgBox
            kMsgBox.Print("Ya está en el Último Registro de la lista.", _
                        CustomControls.kMsgBox.kMsgBoxStyle.Information)
            Return ConsultaRegistro(RegistroFinal)
        End If
    End Function

    Public Function Ultimo() As String
        Return ConsultaRegistro(RegistroFinal)
    End Function

    Public Sub New(Value As ASADB.Connection)
        SQL.DBConnection = Value
    End Sub

End Class
