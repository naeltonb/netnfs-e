Public Class frmLogin
    Private strSenhaCryp As String

    Private Sub btOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOk.Click
        If Trim(txtLogin.Text) = "" Then
            MsgBox("Digite o nome do usuário!", vbExclamation, "Atenção")
            txtLogin.Focus()
        ElseIf Trim(txtSenha.Text) = "" Then
            MsgBox("Digite a senha de acesso!", vbExclamation, "Atenção")
            txtSenha.Focus()
        Else

            Dim conBd As New ConexaoBd
            Dim Crypto As New ClsCrypto
            strSenhaCryp = Crypto.clsCrypto(txtSenha.Text, True)
            Dim Sql As String = "Select * from tb_Usuarios where Login = '" & txtLogin.Text & "' and Senha = '" & strSenhaCryp & "'"
            Dim dt As DataTable = conBd.Consultar(Sql, "tb_Usuarios")
            If dt.Rows.Count <= 0 Then
                MsgBox("Login e/ou senha inválidos!", vbExclamation, "Acesso negado!")
                txtLogin.Text = ""
                txtSenha.Text = ""
                txtLogin.Focus()
            Else

                'Verifica se é para trocar a senha
                If dt.Rows(0).Item("Alterar_Senha") = "SIM" Then
                    Dim frmTroca As New frmTrocaSenha(dt)
                    txtLogin.Text = ""
                    txtSenha.Text = ""
                    txtLogin.Focus()
                    Me.Hide()
                    frmTroca.Show()
                Else
                    'Deleta os arquivos da pasta temporária utilizados pelo sistema
                    Try
                        DeletarArquivos(My.Application.Info.DirectoryPath & "\Temp")
                    Catch ex As Exception
                        Err.Clear()
                    End Try
                    txtLogin.Text = ""
                    txtSenha.Text = ""
                    txtLogin.Focus()
                    Me.Hide()
                    frmPrincipal.Show()
                    frmPrincipal.BarraStatusUsuario.Text = "Usuário logado: " & dt.Rows(0).Item("Nome").ToString
                End If

            End If
        End If
    End Sub

    Private Sub btCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancel.Click
        End
    End Sub
End Class
