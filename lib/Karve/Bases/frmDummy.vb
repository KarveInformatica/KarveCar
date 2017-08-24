Public Class frmDummy
    Inherits frmBase

    Protected Overrides Sub setTables() ' funcion utiizada para setear las tablas de edicion, ultmodi, oficina y empresa
        'Dim table As Bases.TablaEdit

        'table = New Bases.TablaEdit
        'table.Tabla = "CLIENTES1"
        'table.CampoID = "NUMERO_CLI"
        'table.TableAlias = "CL1"
        'tablasEdit.Add(table)

        'table = New Bases.TablaEdit
        'table.Tabla = "CLIENTES2"
        'table.CampoID = "NUMERO_CLI"
        'table.TableAlias = "CL2"
        'tablasEdit.Add(table)

        'tablaUltmodi.TableAlias = "CL2"
        'tablaUltmodi.CampoID = "ULTMODI"

        'tablaUsumodi.TableAlias = "CL2"
        'tablaUsumodi.CampoID = "USUARIO"

        'tablaOficina.TableAlias = "CL2"
        'tablaOficina.CampoID = "OFICINA"

        'tablaEmpresa.TableAlias = "CL2"
        'tablaEmpresa.CampoID = "SUBLICEN"
    End Sub

    Protected Overrides Sub LoadExtra() ' funcion utilizada para cargar datos extra en la pantalla
        ' P.E.: cargar la grid de lineas una vez cargada la cabezera
    End Sub

    Protected Overrides Sub AddExtra() ' funcion utilizada para añadir cosas cuando se crea un nuevo registro
        ' P.E.: poner "AGREGAR" en el campo codigo
    End Sub

    Protected Overrides Sub SaveExtra(ByVal newReg As Boolean) ' funcion utilizada para guardar datos extras una vez guardada la cabecera
        ' el parametro newReg esta a true si estamos añadiendo un registro
        ' P.E.: guardar la grid de lineas
    End Sub

    Protected Overrides Sub SaveBefore(ByVal newReg As Boolean) ' funcion utilizada para guardar datos extras antes de guardar la cabecera
        ' el parametro newReg esta a true si estamos añadiendo un registro
        ' P.E.: asignar el id cuando se añade un nuevo registro
    End Sub

    Protected Overrides Sub loadAfterSave() ' funcion utilizada para cargar datos tras guardar

    End Sub

    Protected Overrides Sub CancelExtra() ' funcion utilizada para limpiar datos extra
        ' P.E.: limpiar la grid
    End Sub

    Protected Overrides Sub DeleteBefore() ' funcion utilizada para borrar datos extras antes de borrar la cabecera

    End Sub

    Protected Overrides Sub DeleteExtra() ' funcion utilizada para borrar datos extras una vez borrada la cabecera

    End Sub

    Protected Overrides Function getExtraChanges() As Boolean
        Return False
    End Function

    Protected Overrides Sub UndoExtra()

    End Sub

    Protected Overrides Sub traducirExtra() ' funcion ultilizada para traducir cosas que no traduzca la base

    End Sub
End Class