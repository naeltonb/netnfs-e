Public Class frmCadEmpresa

    Private Sub frmCadEmpresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CentralizarForm(Me)
        CarregarDados()
    End Sub

    Private Sub txtCnpj_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If removeFormatacao(txtCnpj.Text) <> "" Then
            If ValidarCnpj(txtCnpj.Text) = False Then
                MsgBox("O Cnpj digitado não é válido!", vbExclamation, "Atenção")
                txtCnpj.Text = ""
                txtCnpj.Focus()
            End If
        End If
    End Sub

    Private Sub Salvar()
        'Primeiro verifica se já existe registro. Isso irá determinar se para salvar ou atualizar
        Dim Sql As String
        Dim conBd As New ConexaoBd
        Dim SqlConsultar As String = "Select Id from tb_CadEmpresa"
        Dim dt As DataTable = conBd.Consultar(SqlConsultar, "tb_CadEmpresa")
        Dim strMensagem As String = ""

        If dt.Rows.Count <= 0 Then
            Sql = "Insert into tb_CadEmpresa(RazaoSocial,NomeFantasia,CodigoCnae,Cnpj,InscricaoMunicipal,InscricaoEstadual,Logradouro,Numero,Complemento,Bairro,Cidade,Uf,Cep,Telefone,Email,Contato) values" & _
                    "('" & Trim(txtRazaoSocial.Text) & "','" & Trim(txtNomeFantasia.Text) & "','" & Trim(txtCnae.Text) & "','" & Trim(txtCnpj.Text) & "','" & Trim(txtInscMunicipal.Text) & "','" & Trim(txtInscEstadual.Text) & "','" & Trim(txtLogradouro.Text) & "'," & _
                    "'" & Trim(txtNumero.Text) & "','" & Trim(txtComplemento.Text) & "','" & Trim(txtBairro.Text) & "','" & Trim(txtCidade.Text) & "','" & Trim(txtUf.Text) & "','" & Trim(txtCep.Text) & "','" & Trim(txtTelContato.Text) & "','" & Trim(txtEmail.Text) & "','" & Trim(txtPessoaContato.Text) & "')"
            strMensagem = "Dados incluidos com sucesso!"
        Else
            Sql = "Update tb_CadEmpresa set RazaoSocial = '" & Trim(txtRazaoSocial.Text) & "', NomeFantasia = '" & Trim(txtNomeFantasia.Text) & "',CodigoCnae = '" & Trim(txtCnae.Text) & "',Cnpj = '" & Trim(txtCnpj.Text) & "',InscricaoMunicipal = '" & Trim(txtInscMunicipal.Text) & "'," & _
                "InscricaoEstadual = '" & Trim(txtInscEstadual.Text) & "',Logradouro = '" & Trim(txtLogradouro.Text) & "', Numero = '" & Trim(txtNumero.Text) & "',Complemento = '" & Trim(txtComplemento.Text) & "',Bairro = '" & Trim(txtBairro.Text) & "',Cidade = '" & txtCidade.Text & "'," & _
                " Uf = '" & Trim(txtUf.Text) & "',Cep = '" & Trim(txtCep.Text) & "',Telefone = '" & Trim(txtTelContato.Text) & "',Email = '" & Trim(txtEmail.Text) & "',Contato = '" & Trim(txtPessoaContato.Text) & "'"
            strMensagem = "Dados atualizados com sucesso!"
        End If

        Try
            'INICIAR TRANSAÇÃO DE BANCO DE DADOS AQUI
            conBd.ExecutarSql(Sql)
            CarregarDados()
            CarregarParametrosSistema()
            'FINALIZAR TRANSAÇÃO DE BANDO DE DADOS AQUI
            MsgBox(strMensagem, vbInformation, "Confirmação")
        Catch ex As Exception
            MsgBox("Ocorreu um erro durante a inserção/atualização dos dados" & Chr(13) & ex.Message, vbCritical, "Atenção")
        End Try

        'Destroi as variáveis utilizadas
        conBd = Nothing
        Sql = Nothing
        SqlConsultar = Nothing
        dt = Nothing
        strMensagem = Nothing

    End Sub

    Private Sub CarregarDados()
        'Primeiro verifica se já existe registro.
        Dim conBd As New ConexaoBd
        Dim SqlConsultar As String = "Select * from tb_CadEmpresa"
        Dim dt As DataTable = conBd.Consultar(SqlConsultar, "tb_Lote")

        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            txtId.Text = dr("Id")
            txtRazaoSocial.Text = dr("RazaoSocial")
            txtNomeFantasia.Text = dr("NomeFantasia")
            txtCnae.Text = dr("CodigoCnae")
            txtCnpj.Text = dr("Cnpj")
            txtInscMunicipal.Text = dr("InscricaoMunicipal")
            txtInscEstadual.Text = dr("InscricaoEstadual")
            txtLogradouro.Text = dr("Logradouro")
            txtNumero.Text = dr("Numero")
            txtComplemento.Text = dr("Complemento")
            txtBairro.Text = dr("Bairro")
            txtCidade.Text = dr("Cidade")
            txtUf.Text = dr("Uf")
            txtCep.Text = dr("Cep")
            txtTelContato.Text = dr("Telefone")
            txtEmail.Text = dr("Email")
            txtPessoaContato.Text = dr("Contato")
            GrupoDados.Enabled = False
            dr = Nothing
        End If

        'Destroi as variáveis utilizadas
        conBd = Nothing
        SqlConsultar = Nothing
        dt = Nothing
    End Sub


    Private Sub btEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEditar.Click
        GrupoDados.Enabled = True
        txtRazaoSocial.Focus()
    End Sub

    Private Sub btSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSalvar.Click
        If VerificarPreenchimentoObrigatorio(GrupoDados) = True Then
            If MsgBox("Tem certeza que deseja incluir/atualizar os dados da empresa", vbQuestion + vbYesNo, "Confirmação") = vbYes Then
                Salvar()
            End If
        End If
    End Sub
End Class