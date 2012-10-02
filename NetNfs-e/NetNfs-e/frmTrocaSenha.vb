
Public Class frmTrocaSenha
    Private Dt_Usuario As DataTable
    Public Sub New(ByVal Dt As DataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dt_Usuario = New DataTable
        Dt_Usuario = Dt

        lblUsuario.Text = Dt_Usuario.Rows(0).Item("Nome")
    End Sub

    Private Sub btSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSalvar.Click
        If VerificarPreenchimentoObrigatorio(GroupDados) = True Then

            Dim Crypto As New ClsCrypto
            Dim strSenhaAtualCryp As String = Crypto.clsCrypto(txtSenhaAtual.Text, True)

            If strSenhaAtualCryp <> Dt_Usuario.Rows(0).Item("Senha") Then
                MsgBox("Senha atual inválida!", vbExclamation, "Atenção")
                txtSenhaAtual.Text = ""
                txtSenhaAtual.Focus()
            ElseIf txtSenhaAtual.Text = txtNovaSenha.Text Then
                MsgBox("A nova senha deve ser diferente da senha atual!", vbExclamation, "Atenção")
                txtNovaSenha.Text = ""
                txtConfirmaSenha.Text = ""
                txtNovaSenha.Focus()
            ElseIf Len(txtNovaSenha.Text) < 4 Then
                MsgBox("A nova senha deve ter no mínimo quatro caracteres!", vbExclamation, "Atenção")
                txtNovaSenha.Text = ""
                txtConfirmaSenha.Text = ""
                txtNovaSenha.Focus()
            ElseIf txtNovaSenha.Text <> txtConfirmaSenha.Text Then
                MsgBox("Nova senha não confere!", vbExclamation, "Atenção")
                txtNovaSenha.Text = ""
                txtConfirmaSenha.Text = ""
                txtNovaSenha.Focus()
            Else
                Dim strSenhaNovaCryp As String = Crypto.clsCrypto(txtNovaSenha.Text, True)
                Dim conBd As New ConexaoBd
                Dim Sql As String = "Update tb_Usuarios set Senha = '" & strSenhaNovaCryp & "',Alterar_Senha = 'NAO' where Id = '" & Dt_Usuario.Rows(0).Item("Id") & "'"
                Dim RegAft As Integer = conBd.ExecutarSql(Sql)
                If RegAft > 0 Then
                    MsgBox("Senha alterada com sucesso!", vbInformation, "Confirmação")
                    Me.Close()
                    frmLogin.Show()
                Else
                    MsgBox("Nenhum registo afetado!", vbExclamation, "Atenção")
                    End
                End If
            End If
        End If
    End Sub

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        End
    End Sub

End Class