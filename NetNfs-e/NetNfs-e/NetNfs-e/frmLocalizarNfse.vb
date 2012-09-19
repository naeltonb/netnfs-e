Public Class frmLocalizarNfse

    Private Sub btLocalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLocalizar.Click
        Dim strCamposNfse As String = ""
        Dim conBd As New ConexaoBd
        Dim Dt_Config As New DataTable
        Dim Dt_Nfse As New DataTable
        Dim Sql As String = "Select Nome_Coluna,Index_Coluna,Coluna_Visivel from tb_ConfigGridNfse order by Index_Coluna"
        Dt_Config = conBd.Consultar(Sql, "tb_ConfigGridNfse")

        If Dt_Config.Rows.Count > 0 Then
            For Each dr As DataRow In Dt_Config.Rows
                If dr("Coluna_Visivel") = "SIM" Then
                    If strCamposNfse = "" Then
                        strCamposNfse = dr("Nome_Coluna")
                    Else
                        strCamposNfse = strCamposNfse & "," & dr("Nome_Coluna")
                    End If
                End If
            Next
            Sql = "Select " & strCamposNfse & " from tb_Nfse"
        Else
            Sql = "Select * from tb_Nfse"
        End If

        Dt_Nfse = conBd.Consultar(Sql, "tb_Nfse")

        'Chama o formulário de Consulta Nfse
        Dim frm As New frmConsultaNfse(Dt_Nfse)
        frm.MdiParent = frmPrincipal
        frm.Show()

        'Destroi variáveis e libera memória
        strCamposNfse = Nothing
        conBd = Nothing
        Dt_Config = Nothing
        Dt_Nfse = Nothing
        Sql = Nothing

        Me.Close()


    End Sub

    Private Sub frmLocalizarNfse_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CentralizarForm(Me)
    End Sub

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Me.Close()
    End Sub
End Class