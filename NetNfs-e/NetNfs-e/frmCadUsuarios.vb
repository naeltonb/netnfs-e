Public Class frmCadUsuarios
    Private bIncluir As Boolean = False
    Private bLoad As Boolean = True

    Private Sub CarregarDados(ByRef Id As Integer)
        Try

            Dim conBd As New ConexaoBd
            Dim SqlConsultar As String = "Select Id,Nome,Login,Senha,Id_Perfil,Alterar_Senha from tb_Usuarios where Id = '" & Id.ToString & "'"
            Dim dt As DataTable = conBd.Consultar(SqlConsultar, "tb_Usuarios")

            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                txtNome.SelectedValue = dr("Id")
                txtLogin.Text = dr("Login")
                txtPerfil.SelectedValue = dr("Id_Perfil")

                Dim decifrado As New ClsCrypto
                txtSenha.Text = decifrado.clsCrypto(dr("Senha"), False)
                txtConfirmaSenha.Text = txtSenha.Text

                If dr("Alterar_Senha") = "SIM" Then
                    OptSim.Checked = True
                Else
                    OptNao.Checked = True
                End If
                dr = Nothing
            Else
                txtNome.Text = ""
                txtLogin.Text = ""
                txtPerfil.Text = ""
                txtSenha.Text = ""
                txtConfirmaSenha.Text = ""
            End If

            'Destroi as variáveis utilizadas
            conBd = Nothing
            SqlConsultar = Nothing
            dt = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub CarregarComboBox()
        Dim Sql As String = ""
        Dim conBd As New ConexaoBd

        Sql = "Select * from tb_Perfil"
        Dim dt As DataTable = conBd.Consultar(Sql, "tb_Perfil")
        txtPerfil.DataSource = dt
        txtPerfil.DisplayMember = "Nome_Perfil"
        txtPerfil.ValueMember = "Id"

        Sql = "Select Id,Nome from tb_Usuarios"
        Dim dt1 As DataTable = conBd.Consultar(Sql, "tb_Usuarios")
        txtNome.DataSource = dt1
        txtNome.DisplayMember = "Nome"
        txtNome.ValueMember = "Id"

        'Destroi as variáveis utilizadas
        Sql = Nothing
        conBd = Nothing
        dt = Nothing
        dt1 = Nothing

    End Sub

    Private Sub frmCadUsuarios_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmCadUsuarios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CentralizarForm(Me)
        CarregarComboBox()

        Dim conBd As New ConexaoBd
        Dim SqlConsultar As String = "Select Id from tb_Usuarios order by Nome"
        Dim dt As DataTable = conBd.Consultar(SqlConsultar, "tb_CadUsuarios")
        If dt.Rows.Count > 0 Then
            CarregarDados(dt.Rows(0).Item("Id"))
        End If
        GrupoDados.Enabled = False
        bLoad = False
    End Sub

    Private Sub btEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEditar.Click
        bIncluir = False
        GrupoDados.Enabled = True
        txtNome.DropDownStyle = ComboBoxStyle.DropDownList
        txtNome.Focus()
    End Sub

    Private Sub btIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btIncluir.Click
        bIncluir = True
        GrupoDados.Enabled = True
        txtNome.DropDownStyle = ComboBoxStyle.Simple
        txtNome.AutoCompleteMode = AutoCompleteMode.None
        txtNome.Text = ""
        txtLogin.Text = ""
        txtPerfil.Text = ""
        txtSenha.Text = ""
        txtConfirmaSenha.Text = ""
        txtNome.Focus()

    End Sub

    Private Sub btSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSalvar.Click
        If ConfirmarSenhar() = True Then
            If VerificarPreenchimentoObrigatorio(GrupoDados) = True Then
                If MsgBox("Tem certeza que deseja salvar?", vbQuestion + vbYesNo, "Confirmação") = vbYes Then
                    Salvar()
                End If
            End If
        Else
            txtConfirmaSenha.Text = ""
            txtConfirmaSenha.Focus()
            MsgBox("Senha não confirmada! O campo Confirma Senha deve ser igual ao campo Senha.", vbExclamation, "Atenção")
        End If


    End Sub

    Private Sub Salvar()
        Dim Sql As String
        Dim conBd As New ConexaoBd

        Dim strMensagem As String = ""

        Dim cifrado As New ClsCrypto
        txtSenha.Text = cifrado.clsCrypto(txtSenha.Text, True)

        If bIncluir = True Then
            Sql = "Insert into tb_Usuarios(Nome,Login,Senha,Id_Perfil,Alterar_Senha) values ('" & UCase(Trim(txtNome.Text)) & "','" & Trim(txtLogin.Text) & "','" & txtSenha.Text & "','" & txtPerfil.SelectedValue & "','" & lblAlterar.Text & "')"
            strMensagem = "Usuário incluido com sucesso!"
        Else
            Sql = "Update tb_Usuarios set Login = '" & Trim(txtLogin.Text) & "',Senha = '" & Trim(txtSenha.Text) & "',Id_Perfil = '" & txtPerfil.SelectedValue & "',Alterar_Senha = '" & lblAlterar.Text & "' where Id = '" & txtNome.SelectedValue & "' "
            strMensagem = "Dados do usuário alterados com sucesso!"
        End If

        Try
            'INICIAR TRANSAÇÃO DE BANCO DE DADOS AQUI
            conBd.ExecutarSql(Sql)
            CarregarComboBox()
            AtualizarDados()
            'FINALIZAR TRANSAÇÃO DE BANDO DE DADOS AQUI
            GrupoDados.Enabled = False
            txtNome.DropDownStyle = ComboBoxStyle.DropDownList
            MsgBox(strMensagem, vbInformation, "Confirmação")
        Catch ex As Exception
            GrupoDados.Enabled = True
            MsgBox("Ocorreu um erro durante a inserção/atualização dos dados" & Chr(13) & ex.Message, vbCritical, "Atenção")
            Err.Clear()
        End Try

        'Destroi as variáveis utilizadas
        conBd = Nothing
        Sql = Nothing
        strMensagem = Nothing

    End Sub

    Private Sub OptSim_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptSim.CheckedChanged
        lblAlterar.Text = "SIM"
    End Sub

    Private Sub OptNao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptNao.CheckedChanged
        lblAlterar.Text = "NAO"
    End Sub

    Private Sub txtNome_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNome.LostFocus
        txtNome.Text = UCase(txtNome.Text)
    End Sub

    Private Sub txtNome_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNome.SelectedValueChanged
        If bLoad = False Then
            CarregarDados(txtNome.SelectedValue)
        End If
    End Sub

    Private Sub txtNome_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNome.SelectedIndexChanged

    End Sub

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        AtualizarDados()
    End Sub

    Private Sub AtualizarDados()
        CarregarComboBox()

        Dim conBd As New ConexaoBd
        Dim SqlConsultar As String = "Select Id from tb_Usuarios order by Nome"
        Dim dt As DataTable = conBd.Consultar(SqlConsultar, "tb_CadUsuarios")
        txtNome.DropDownStyle = ComboBoxStyle.DropDownList
        If dt.Rows.Count > 0 Then
            CarregarDados(dt.Rows(0).Item("Id"))
        Else
            txtNome.Text = ""
            txtLogin.Text = ""
            txtSenha.Text = ""
            txtConfirmaSenha.Text = ""
            OptSim.Checked = False
            OptNao.Checked = False
        End If
        GrupoDados.Enabled = False
    End Sub

    Private Sub btExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcluir.Click
        If GrupoDados.Enabled = True Then
            If bIncluir = True Then
                MsgBox("Operação não permitida para este contexto!" & Chr(13) & "Não é possível excluir um registro em um situação de inclusão.", vbExclamation, "Atenção")
            Else
                If MsgBox("Tem certeza que deseja excluir este usuário?", vbQuestion + vbYesNo, "Confirmação") = vbYes Then

                    Try
                        Dim Sql As String
                        Dim conBd As New ConexaoBd

                        Sql = "Delete from tb_Usuarios where Id = '" & txtNome.SelectedValue & "'"
                        Dim Reg As Integer = conBd.ExecutarSql(Sql)
                        If Reg > 0 Then
                            MsgBox("Usuário excluido com sucesso!", vbInformation, "Confirmação")
                        Else
                            MsgBox("Nehum usuário foi excluido com sucesso!", vbInformation, "Confirmação")
                        End If
                        AtualizarDados()
                    Catch ex As Exception
                        MsgBox("Ocorreu um erro durante a operação!" & Chr(13) & ex.Message, vbCritical, "Erro")
                        Err.Clear()
                    End Try

                End If
            End If
        End If
    End Sub

    Private Sub txtConfirmaSenha_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtConfirmaSenha.LostFocus
        If txtConfirmaSenha.Text <> "" Then
            If ConfirmarSenhar() = False Then
                txtConfirmaSenha.Text = ""
                txtConfirmaSenha.Focus()
                MsgBox("Senha não confirmada! O campo Confirma Senha deve ser igual ao campo Senha.", vbExclamation, "Atenção")
            End If
        End If
    End Sub

    Private Function ConfirmarSenhar() As Boolean
        If txtConfirmaSenha.Text <> txtSenha.Text Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSair.Click
        Me.Close()
    End Sub
End Class