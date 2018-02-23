Imports CustomControls
Imports Karve.ConfiguracionApp
Imports VariablesGlobales

Public Class ReglasCtasContables

    Public Function CtasContablesEmp() As DataGridRule
        Dim RL As DataGridRule
        RL = New DataGridRule
        With RL
            .Name = "EMPRESA"
            .Criterio = DataGridRule.euCriterio.Igual
            .Campo = "SUBLICEN"
            .Tabla = "CTA"
            .Valor = IIf(CK.GStr("EMP_PLANCTA") <> "", CK.GStr("EMP_PLANCTA"), IIf((sEmpresaCons = ""), CE.GStr("EMPRESA"), sEmpresaCons))
        End With

        Return RL
    End Function

End Class
