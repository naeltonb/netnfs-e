Imports System.IO

Public Class frmCadParametros

    Private Sub frmCadParametros_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmCadParametros_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CentralizarForm(Me)
        CarregarComboBox()
        CarregarDados()
    End Sub

    Private Sub HabilitarCampos()
        GroupRps.Enabled = True
        GroupImpostos.Enabled = True
        GroupDemaisParamentros.Enabled = True
        GroupEmail.Enabled = True
    End Sub

    Private Sub InativarCampos()
        GroupRps.Enabled = False
        GroupImpostos.Enabled = False
        GroupDemaisParamentros.Enabled = False
        GroupEmail.Enabled = False
    End Sub

    Private Sub Salvar()
        'Primeiro verifica se já existe registro. Isso irá determinar se é para salvar ou atualizar
        Dim Sql As String
        Dim conBd As New ConexaoBd
        Dim SqlConsultar As String = "Select Id from tb_Parametros"
        Dim dt As DataTable = conBd.Consultar(SqlConsultar, "tb_Parametros")
        Dim strMensagem As String = ""

        Dim cifrado As New ClsCrypto
        txtSenhaEmail.Text = cifrado.clsCrypto(txtSenhaEmail.Text, True)
        cifrado = Nothing

        If dt.Rows.Count <= 0 Then

            Sql = "Insert into tb_Parametros(TipoRps,NumRps,NaturezaOperacao,RegimeEspTributacao,OptanteSimples,IncentivadorCultural,ItemListaServico,CodigoTributacao,NumNota,DiretorioLoteRps,NumLote,Serie,CodigoMunicipio,PIS,COFINS,CSLL,AliquotaIRRF,ValorLimiteImpostoIRRF,AcumulaImposto,AcumulaIRRF,Ambiente,ConverterPadraoAbrasf,EmailRemente,AssuntoEmail,MensagemEmail,UtilizarNumNfseNoAssunto,UtilizarEmailCliente,EmailDestinatarioPadrao,EnderecoSmtp,PortaSmtp,SenhaEmail,EnviarCopiaEmail,EmailCopia) values" & _
                    "('" & txtTipoRps.SelectedValue & "','" & Trim(txtNumRps.Text) & "','" & txtNaturezaOpercao.SelectedValue & "','" & txtRegimeEspTributacao.SelectedValue & "','" & lblSimples.Text & "','" & lblInsCultural.Text & "','" & txtListaServiços.SelectedValue & "'," & _
                    "'" & Trim(txtCodigoTributacao.Text) & "','" & Trim(txtNumNfse.Text) & "','" & Trim(txtDiretorioLoteRps.Text) & "','" & Trim(txtNumLoteRps.Text) & "','" & Trim(txtSerie.Text) & "','" & txtMunicipio.SelectedValue & "',@PIS,@COFINS,@CSLL," & _
                    "@AliquotaIRRF,@AliquotaISS,@ValorLimiteImpostoIRRF,'" & lblAcumlaImposto.Text & "','" & lblAcumulaIRRF.Text & "', '" & txtAmbiente.Text & "','" & lblConversorAbrasf.Text & "','" & Trim(txtEmailRemetente.Text) & "','" & txtAssuntoEmail.Text & "' )" & _
                    "'" & txtMensagemEmail.Text & "','" & lblNfseNoAssunto.Text & "','" & lblEmailDestinatario.Text & "','" & txtEmailPadrao.Text & "','" & txtEnderecoSmpt.Text & "','" & txtPortaSmtp.Text & "','" & txtSenhaEmail.Text & "','" & lblEnviarCopiaEmail.Text & "','" & txtCopiaEmail.Text & "'"
            strMensagem = "Dados incluidos com sucesso!"
        Else
            Sql = "Update tb_Parametros set TipoRps = '" & txtTipoRps.SelectedValue & "', NumRps = '" & Trim(txtNumRps.Text) & "',NaturezaOperacao = '" & txtNaturezaOpercao.SelectedValue & "',RegimeEspTributacao = '" & txtRegimeEspTributacao.SelectedValue & "',OptanteSimples = '" & lblSimples.Text & "'," & _
                "IncentivadorCultural = '" & lblInsCultural.Text & "',ItemListaServico = '" & txtListaServiços.SelectedValue & "', CodigoTributacao = '" & Trim(txtCodigoTributacao.Text) & "',NumNota = '" & Trim(txtNumNfse.Text) & "',DiretorioLoteRps = '" & Trim(txtDiretorioLoteRps.Text) & "',NumLote = '" & Trim(txtNumLoteRps.Text) & "'," & _
                "Serie = '" & Trim(txtSerie.Text) & "',CodigoMunicipio = '" & txtMunicipio.SelectedValue & "',PIS = @PIS,COFINS = @COFINS,CSLL = @CSLL,AliquotaIRRF = @AliquotaIRRF,AliquotaISS = @AliquotaISS,ValorLimiteImpostoIRRF = @ValorLimiteImpostoIRRF,AcumulaImposto = '" & lblAcumlaImposto.Text & "',AcumulaIRRF = '" & lblAcumulaIRRF.Text & "',Ambiente ='" & txtAmbiente.Text & "',ConverterPadraoAbrasf = '" & lblConversorAbrasf.Text & "'," & _
                "EmailRemetente = '" & Trim(txtEmailRemetente.Text) & "',AssuntoEmail = '" & txtAssuntoEmail.Text & "',MensagemEmail = '" & txtMensagemEmail.Text & "',UtilizarNumNfseNoAssunto = '" & lblNfseNoAssunto.Text & "',UtilizarEmailCliente = '" & lblEmailDestinatario.Text & "',EmailDestinatarioPadrao = '" & Trim(txtEmailPadrao.Text) & "',EnderecoSmtp = '" & Trim(txtEnderecoSmpt.Text) & "',PortaSmtp = '" & txtPortaSmtp.Text & "',SenhaEmail = '" & txtSenhaEmail.Text & "',EnviarCopiaEmail = '" & lblEnviarCopiaEmail.Text & "',EmailCopia = '" & txtCopiaEmail.Text & "'"
            strMensagem = "Dados atualizados com sucesso!"
        End If

        Dim impostos As New Impostos
        impostos.PIS = txtPIS.Text
        impostos.COFINS = txtCOFINS.Text
        impostos.CSLL = txtCSLL.Text
        impostos.AliquotaIRRF = txtAliquotaIRRF.Text
        impostos.AliquotaISS = txtAliquotaISS.Text
        impostos.ValorLimiteIRRF = txtValorLimiteImposto.Text

        Try
            'INICIAR TRANSAÇÃO DE BANCO DE DADOS AQUI
            conBd.ExecutarSqlParametros(Sql, impostos)
            CarregarDados()
            'FINALIZAR TRANSAÇÃO DE BANDO DE DADOS AQUI
            InativarCampos()
            CarregarParametrosSistema()
            MsgBox(strMensagem, vbInformation, "Confirmação")
        Catch ex As Exception
            HabilitarCampos()
            MsgBox("Ocorreu um erro durante a inserção/atualização dos dados" & Chr(13) & ex.Message, vbCritical, "Atenção")
        End Try

        'Destroi as variáveis utilizadas
        conBd = Nothing
        Sql = Nothing
        SqlConsultar = Nothing
        dt = Nothing
        strMensagem = Nothing
        impostos = Nothing

    End Sub

    Private Sub CarregarDados()

        Dim conBd As New ConexaoBd
        Dim SqlConsultar As String = "Select * from tb_Parametros"
        Dim dt As DataTable = conBd.Consultar(SqlConsultar, "tb_Parametros")

        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            txtTipoRps.SelectedValue = dr("TipoRps")
            txtNumRps.Text = dr("NumRps")
            txtNaturezaOpercao.SelectedValue = dr("NaturezaOperacao")
            txtRegimeEspTributacao.SelectedValue = dr("RegimeEspTributacao")

            If dr("OptanteSimples") = "SIM" Then
                OptSimplesSim.Checked = True
            Else
                OptSimplesNao.Checked = True
            End If

            If dr("IncentivadorCultural") = "SIM" Then
                OptIncenCulturalSim.Checked = True
            Else
                OptInceCulturalNao.Checked = True
            End If

            txtListaServiços.SelectedValue = dr("ItemListaServico")
            txtCodigoTributacao.Text = dr("CodigoTributacao")
            txtNumNfse.Text = dr("NumNota")
            txtDiretorioLoteRps.Text = dr("DiretorioLoteRps")
            txtNumLoteRps.Text = dr("NumLote")
            txtSerie.Text = dr("Serie")
            txtMunicipio.SelectedValue = dr("CodigoMunicipio")
            txtPIS.Text = dr("PIS")
            txtCOFINS.Text = dr("COFINS")
            txtCSLL.Text = dr("CSLL")
            txtAliquotaIRRF.Text = dr("AliquotaIRRF")
            txtAliquotaISS.Text = dr("AliquotaISS")
            txtValorLimiteImposto.Text = FormatNumber(dr("ValorLimiteImpostoIRRF"))

            If dr("AcumulaImposto") = "SIM" Then
                OptAcumImpostosSim.Checked = True
            Else
                OptAcumImpostosNao.Checked = True
            End If

            If dr("AcumulaIRRF") = "SIM" Then
                OptAcumIRRFSim.Checked = True
            Else
                OptAcumIRRFNao.Checked = True
            End If

            txtAmbiente.Text = dr("Ambiente")

            If dr("ConverterPadraoAbrasf") = "SIM" Then
                OptConversorAbrasfSim.Checked = True
            Else
                OptConversorAbrasfNao.Checked = True
            End If

            txtEmailRemetente.Text = dr("EmailRemetente")
            txtAssuntoEmail.Text = dr("AssuntoEmail")
            txtMensagemEmail.Text = dr("MensagemEmail")

            If dr("UtilizarNumNfseNoAssunto") = "SIM" Then
                OptNfseNoAssuntoSim.Checked = True
            Else
                OptNfseNoAssuntoNao.Checked = False
            End If

            If dr("UtilizarEmailCliente") = "SIM" Then
                optEmailDestCliente.Checked = True
            Else
                optEmailDestPadrao.Checked = True
            End If

            txtEmailPadrao.Text = dr("EmailDestinatarioPadrao")
            txtEnderecoSmpt.Text = dr("EnderecoSmtp")
            txtPortaSmtp.Text = dr("PortaSmtp")

            If Trim(dr("SenhaEmail")) = "" Then
                txtSenhaEmail.Text = dr("SenhaEmail")
            Else
                Dim Decifrado As New ClsCrypto
                txtSenhaEmail.Text = Decifrado.clsCrypto(dr("SenhaEmail"), False)
                Decifrado = Nothing
            End If


            If dr("EnviarCopiaEmail") = "SIM" Then
                ChkEnviarCopiaEmail.Checked = True
            Else
                ChkEnviarCopiaEmail.Checked = False
            End If
            txtCopiaEmail.Text = dr("EmailCopia")



            Dim diretorio As New DirectoryInfo(My.Application.Info.DirectoryPath & "\LogoPrestador")
            Dim arquivos() As FileInfo = diretorio.GetFiles
            For Each _arquivo As FileInfo In arquivos
                PicLogo.Load(My.Application.Info.DirectoryPath & "\LogoPrestador\" & _arquivo.Name)
            Next

            dr = Nothing
            InativarCampos()
        Else
            HabilitarCampos()
        End If

        'Destroi as variáveis utilizadas
        conBd = Nothing
        SqlConsultar = Nothing
        dt = Nothing
    End Sub

    Private Sub CarregarComboBox()
        Dim Sql As String = ""
        Dim conBd As New ConexaoBd

        'Tipo Rps
        Sql = "Select * from tb_TipoRps"
        Dim dt As DataTable = conBd.Consultar(Sql, "tb_TipoRps")
        txtTipoRps.DataSource = dt
        txtTipoRps.DisplayMember = "Descricao"
        txtTipoRps.ValueMember = "Id"


        'Tipo Natureza Operação
        Sql = "Select * from tb_NaturezaOperacao"
        Dim dt1 As DataTable = conBd.Consultar(Sql, "tb_NaturezaOperacao")
        txtNaturezaOpercao.DataSource = dt1
        txtNaturezaOpercao.DisplayMember = "Descricao"
        txtNaturezaOpercao.ValueMember = "Id"

        'Tipo Regime Especial Tributação

        Sql = "Select * from tb_RegimeEspTributacao"
        Dim dt2 As DataTable = conBd.Consultar(Sql, "tb_RegimeEspTributacao")
        txtRegimeEspTributacao.DataSource = dt2
        txtRegimeEspTributacao.DisplayMember = "Descricao"
        txtRegimeEspTributacao.ValueMember = "Id"


        'Municipios
        Sql = "Select * from tb_Municipio"
        Dim dt3 As DataTable = conBd.Consultar(Sql, "tb_Municipio")
        txtMunicipio.DataSource = dt3
        txtMunicipio.DisplayMember = "Municipio"
        txtMunicipio.ValueMember = "CodigoMunicipio"

        'Lista de serviços
        Sql = "Select CodigoServico,(CodigoServico + '-' + DescricaoServico) as ItemLista from tb_ItemListaServico"
        Dim dt4 As DataTable = conBd.Consultar(Sql, "tb_ItemListaServico")
        txtListaServiços.DataSource = dt4
        txtListaServiços.DisplayMember = "ItemLista"
        txtListaServiços.ValueMember = "CodigoServico"

        'Destroi as variáveis utilizadas
        Sql = Nothing
        conBd = Nothing
        dt = Nothing
        dt1 = Nothing
        dt2 = Nothing

    End Sub

    Private Sub txtPIS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SoNumeros(txtPIS)
    End Sub

    Private Sub txtCOFINS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCOFINS.TextChanged
        SoNumeros(txtCOFINS)
    End Sub

    Private Sub txtCSLL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCSLL.TextChanged
        SoNumeros(txtCSLL)
    End Sub

    Private Sub txtAliquotaIRRF_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAliquotaIRRF.TextChanged
        SoNumeros(txtAliquotaIRRF)
    End Sub

    Private Sub txtAliquotaISS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAliquotaISS.TextChanged
        SoNumeros(txtAliquotaISS)
    End Sub

    Private Sub txtValorLimiteImposto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValorLimiteImposto.LostFocus
        If Trim(txtValorLimiteImposto.Text) <> "" Then
            txtValorLimiteImposto.Text = FormatNumber(txtValorLimiteImposto.Text)
        End If
    End Sub

    Private Sub txtValorLimiteImposto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValorLimiteImposto.TextChanged
        SoNumeros(txtValorLimiteImposto)
    End Sub

    Private Sub OptSimplesSim_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptSimplesSim.CheckedChanged
        lblSimples.Text = "SIM"
    End Sub

    Private Sub OptSimplesNao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptSimplesNao.CheckedChanged
        lblSimples.Text = "NÃO"
    End Sub

    Private Sub OptIncenCulturalSim_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptIncenCulturalSim.CheckedChanged
        lblInsCultural.Text = "SIM"
    End Sub

    Private Sub OptInceCulturalNao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptInceCulturalNao.CheckedChanged
        lblInsCultural.Text = "NAO"
    End Sub

    Private Sub OptAcumImpostosSim_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptAcumImpostosSim.CheckedChanged
        lblAcumlaImposto.Text = "SIM"
    End Sub

    Private Sub OptAcumImpostosNao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptAcumImpostosNao.CheckedChanged
        lblAcumlaImposto.Text = "NÃO"
    End Sub

    Private Sub OptAcumIRRFSim_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptAcumIRRFSim.CheckedChanged
        lblAcumulaIRRF.Text = "SIM"
    End Sub

    Private Sub OptAcumIRRFNao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptAcumIRRFNao.CheckedChanged
        lblAcumulaIRRF.Text = "NÃO"
    End Sub

    Private Sub btSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSalvar.Click
        If VerificarPreenchimentoObrigatorio(GroupRps) = True Then
            If VerificarPreenchimentoObrigatorio(GroupImpostos) = True Then

                If VerificarPreenchimentoObrigatorio(GroupDemaisParamentros) = True Then
                    If VerificarPreenchimentoObrigatorio(GroupEmail) = True Then
                        If MsgBox("Tem certeza que deseja incluir/atualizar os parâmetros do sistema?", vbQuestion + vbYesNo, "Confirmação") = vbYes Then
                            Salvar()
                        End If
                    End If
                Else
                    TabControl1.SelectTab(2)
                End If
            Else
                TabControl1.SelectTab(1)
            End If
        Else
            TabControl1.SelectTab(0)
        End If
    End Sub

    Private Sub bt_LocalizarPasta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_LocalizarPasta.Click
        Dim OpenDialog As New FolderBrowserDialog
        OpenDialog.Description = "Selecione a pasta onde ficam armazenados os lotes de Rps"
        OpenDialog.ShowDialog()
        If IsNothing(OpenDialog.SelectedPath) = False Then
            txtDiretorioLoteRps.Text = OpenDialog.SelectedPath
        Else
            txtDiretorioLoteRps.Text = ""
        End If
    End Sub

    Private Sub btEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEditar.Click
        HabilitarCampos()
    End Sub

    Private Sub OptConversorAbrasfSim_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptConversorAbrasfSim.CheckedChanged
        lblConversorAbrasf.Text = "SIM"
    End Sub

    Private Sub OptConversorAbrasfNao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptConversorAbrasfNao.CheckedChanged
        lblConversorAbrasf.Text = "NÃO"
    End Sub

    Private Sub txtPortaSmtp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPortaSmtp.TextChanged
        SoNumeros(txtPortaSmtp)
    End Sub

    Private Sub optEmailDestCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optEmailDestCliente.CheckedChanged
        lblEmailDestinatario.Text = "SIM"
        txtEmailPadrao.Enabled = False
        txtEmailPadrao.Tag = "NÃO"
    End Sub

    Private Sub optEmailDestPadrao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optEmailDestPadrao.CheckedChanged
        lblEmailDestinatario.Text = "NAO"
        txtEmailPadrao.Enabled = True
        txtEmailPadrao.Tag = "SIM"
    End Sub

    Private Sub OptNfseNoAssuntoSim_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptNfseNoAssuntoSim.CheckedChanged
        lblNfseNoAssunto.Text = "SIM"
    End Sub

    Private Sub OptNfseNoAssuntoNao_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptNfseNoAssuntoNao.CheckedChanged
        lblNfseNoAssunto.Text = "NAO"
    End Sub

    Private Sub btLocalizarLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLocalizarLogo.Click
        Dim OpenDialog As New OpenFileDialog
        OpenDialog.ShowDialog()
        If IsNothing(OpenDialog.FileName) = False Then

            Dim diretorioLogo As New DirectoryInfo(My.Application.Info.DirectoryPath & "\LogoPrestador")
            Dim arquivo As New FileInfo(OpenDialog.FileName)


            If Not diretorioLogo.Exists Then 'Se for a primeira vez cria o diretório \LogoPrestador
                diretorioLogo.Create()
            End If
            arquivo.CopyTo(Path.Combine(diretorioLogo.FullName, "LogoPrestador" & arquivo.Extension), True)
            PicLogo.Load(OpenDialog.FileName)
        End If
    End Sub


    Private Sub ChkEnviarCopiaEmail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkEnviarCopiaEmail.CheckedChanged
        If ChkEnviarCopiaEmail.Checked = False Then
            txtCopiaEmail.Enabled = False
            lblEnviarCopiaEmail.Text = "NÃO"
            txtCopiaEmail.Tag = "NAO"
        Else
            txtCopiaEmail.Enabled = True
            lblEnviarCopiaEmail.Text = "SIM"
            txtCopiaEmail.Tag = "SIM"
        End If
    End Sub


End Class