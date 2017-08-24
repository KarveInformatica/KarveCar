Imports System.Data.Odbc

Friend Class ODBC
    Inherits ConnBase

#Region "Variables"
    Private cnx As OdbcConnection
    Private dta As OdbcDataAdapter
    Private cmb As OdbcCommandBuilder
    Private cmd As OdbcCommand
    Private tns As OdbcTransaction
#End Region

    Public Sub New(cnxString As String)
        Try
            cnx = New OdbcConnection(cnxString)
            tns = Nothing
        Catch ex As Exception
            msgBoxError.Print("Ha ocurrido un error inesperado en la Base de Datos.", ex.Message, "Error de la Base de Datos")
        End Try
    End Sub

#Region "Connection"
    Public Overrides Function TestConnection() As Boolean
        Try
            cnx.Open()
            cnxClose()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Protected Overrides Sub cnxOpen()
        Try
            If cnx.State <> ConnectionState.Open Then
                cnx.Open()
            End If
        Catch
        End Try
    End Sub

    Protected Overrides Sub cnxClose()
        Try
            If cnx.State <> ConnectionState.Closed Then
                cnx.Close()
            End If
        Catch
        End Try
    End Sub
#End Region

#Region "Transaction"
    Public Overrides Sub beginTransaction()
        Try
            cnxOpen()
            tns = cnx.BeginTransaction()
        Catch
        End Try
    End Sub

    Public Overrides Sub commitTransaction()
        Try
            If Not IsNothing(tns) Then
                tns.Commit()
                tns = Nothing
            End If
            cnxClose()
        Catch
        End Try
    End Sub

    Public Overrides Sub rollbackTransaction()
        Try
            If Not IsNothing(tns) Then
                tns.Rollback()
                tns = Nothing
            End If
            cnxClose()
        Catch
        End Try
    End Sub
#End Region

    Public Overrides Function fillDts(ByVal mySql As String) As DataSet

        Dim dts As New DataSet

        Try
            If IsNothing(tns) Then
                cnxOpen()
                cmd = New OdbcCommand(mySql, cnx)
            Else
                cmd = New OdbcCommand(mySql, cnx, tns)
            End If
            dta = New OdbcDataAdapter(cmd)
            cmb = New OdbcCommandBuilder(dta)
            dta.FillSchema(dts, SchemaType.Source)
            dta.Fill(dts)
            If IsNothing(tns) Then
                cnxClose()
            End If

        Catch ex As Exception
            If Not IsNothing(tns) Then
                tns.Rollback()
            End If
            msgBoxError.Print("Ha ocurrido un error inesperado en la Base de Datos.", ex.Message, "Error de la Base de Datos")
            Throw New Exception(ex.Message, ex.InnerException)
        Finally
            If IsNothing(tns) Then
                cnxClose()
            End If
        End Try

        Return dts

    End Function

    Public Overrides Function fillDts(ByVal mySql As String, ByVal tableAlias As ArrayList) As DataSet
        Dim dts As New DataSet
        dts = fillDts(mySql)
        If Not IsNothing(tableAlias) Then
            Dim i As Integer = 0
            For Each table As DataTable In dts.Tables
                table.TableName = tableAlias(i)
                i += 1
            Next table
        End If
        Return dts
    End Function

    Public Overrides Sub updateDts(ByVal mySql As String, ByRef dts As DataSet)
        Try
            If IsNothing(tns) Then
                cnxOpen()
            End If
            If dts.HasChanges Then
                Dim mySqlArray As Array = Split(mySql, ";")
                Dim i As Integer = 0
                For Each table As DataTable In dts.Tables
                    If IsNothing(tns) Then
                        cmd = New OdbcCommand(mySqlArray(i), cnx)
                    Else
                        cmd = New OdbcCommand(mySqlArray(i), cnx, tns)
                    End If
                    dta = New OdbcDataAdapter(cmd)
                    cmb = New OdbcCommandBuilder(dta)
                    dta.Update(table)
                    i += 1
                Next table
            End If
            If IsNothing(tns) Then
                cnxClose()
            End If
        Catch ex As Exception
            If Not IsNothing(tns) Then
                tns.Rollback()
            End If
            msgBoxError.Print("Ha ocurrido un error inesperado en la Base de Datos.", ex.Message, "Error de la Base de Datos")
            Throw New Exception(ex.Message, ex.InnerException)
        Finally
            If IsNothing(tns) Then
                cnxClose()
            End If
        End Try

    End Sub

    Public Overrides Sub callSp(ByVal spName As String, ByVal spParams As Array)

        Try
            Dim mySql As String = ""
            Dim mySqlParams As String = ""
            For Each param In spParams
                If mySqlParams <> "" Then
                    mySqlParams = mySqlParams & ", "
                End If
                mySqlParams = mySqlParams & "'" & param & "'"
            Next
            mySql = "call " & spName & " (" & mySqlParams & ")"

            If IsNothing(tns) Then
                cnxOpen()
                cmd = New OdbcCommand(mySql, cnx)
            Else
                cmd = New OdbcCommand(mySql, cnx, tns)
            End If
            If Not IsDBNull(cmd) Then
                cmd.ExecuteScalar()
            End If
            If IsNothing(tns) Then
                cnxClose()
            End If

        Catch ex As Exception
            If Not IsNothing(tns) Then
                tns.Rollback()
            End If
            msgBoxError.Print("Ha ocurrido un error inesperado en la Base de Datos.", ex.Message, "Error de la Base de Datos")
            Throw New Exception(ex.Message, ex.InnerException)
        Finally
            If IsNothing(tns) Then
                cnxClose()
            End If
        End Try
    End Sub

    Public Overrides Sub callSp(ByVal spName As String, ByVal ParamArray spParams() As String)

    End Sub

    Public Overrides Function callSpResults(ByVal spName As String, ByVal spParams As Array) As DataSet

        Dim dts As New DataSet

        Try
            Dim mySql As String = ""
            Dim mySqlParams As String = ""
            For Each param In spParams
                If mySqlParams <> "" Then
                    mySqlParams = mySqlParams & ", "
                End If
                mySqlParams = mySqlParams & "'" & param & "'"
            Next
            mySql = "call " & spName & " (" & mySqlParams & ")"

            dts = fillDts(mySql)

        Catch ex As Exception
            msgBoxError.Print("Ha ocurrido un error inesperado en la Base de Datos.", ex.Message, "Error de la Base de Datos")
        End Try

        Return dts
    End Function

    Public Overrides Function callSpResults(ByVal spName As String, ByVal ParamArray spParams() As String) As DataSet
        Return Nothing
    End Function

    Public Overrides Function selectSpResults(ByVal spName As String, ByVal spParams As Array) As DataSet

        Dim dts As New DataSet

        Try
            Dim mySql As String = ""
            Dim mySqlParams As String = ""
            For Each param In spParams
                If mySqlParams <> "" Then
                    mySqlParams = mySqlParams & ", "
                End If
                mySqlParams = mySqlParams & "'" & param & "'"
            Next
            mySql = "select " & spName & " (" & mySqlParams & ")"

            dts = fillDts(mySql)

        Catch ex As Exception
            msgBoxError.Print("Ha ocurrido un error inesperado en la Base de Datos.", ex.Message, "Error de la Base de Datos")
        End Try

        Return dts
    End Function

    Public Overrides Function selectSpResults(ByVal spName As String, ByVal ParamArray spParams() As String) As DataSet
        Dim dts As New DataSet

        Try
            Dim mySql As String = ""
            Dim mySqlParams As String = ""
            For Each param In spParams
                If mySqlParams <> "" Then
                    mySqlParams = mySqlParams & ", "
                End If
                mySqlParams = mySqlParams & "'" & param & "'"
            Next
            mySql = "select " & spName & " (" & mySqlParams & ")"

            dts = fillDts(mySql)

        Catch ex As Exception
            msgBoxError.Print("Ha ocurrido un error inesperado en la Base de Datos.", ex.Message, "Error de la Base de Datos")
        End Try

        Return dts
    End Function

    Public Overrides Sub executeDirect(ByVal mySql As String)

        Try
            If IsNothing(tns) Then
                cnxOpen()
                cmd = New OdbcCommand(mySql, cnx)
            Else
                cmd = New OdbcCommand(mySql, cnx, tns)
            End If
            If Not IsDBNull(cmd) Then
                cmd.ExecuteScalar()
            End If
            If IsNothing(tns) Then
                cnxClose()
            End If

        Catch ex As Exception
            If Not IsNothing(tns) Then
                tns.Rollback()
            End If
            msgBoxError.Print("Ha ocurrido un error inesperado en la Base de Datos.", ex.Message, "Error de la Base de Datos")
            Throw New Exception(ex.Message, ex.InnerException)
        Finally
            If IsNothing(tns) Then
                cnxClose()
            End If
        End Try
    End Sub

    Public Overrides Function executeQuery(ByVal mySql As String) As String
        Try
            executeQuery = fillDts(mySql).Tables(0).Rows(0).Item(0)
        Catch
            executeQuery = ""
        End Try
    End Function

    Public Overrides Function ColumnaIgual(Tabla As String, _
                                 Columna As String, _
                                 Where As String) As Boolean
        Dim mySql As String = " SELECT " & Columna & _
                              " FROM " & Tabla & " " & _
                              Where
        Return executeQuery(mySql) <> ""
    End Function

End Class
