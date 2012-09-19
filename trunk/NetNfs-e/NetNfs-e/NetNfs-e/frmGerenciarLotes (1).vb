Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.IO
Imports System.Xml
Imports System.Data.SqlClient
Imports WsNfs_e
Imports System.Security.Cryptography.X509Certificates

Public Class frmGerenciarLotes

#Region "Variáveis"

    Private _docXml As XmlDocument
    Private _infLote As infLote
    Private QutArquivosSel As Integer = 0
    Private BytAssinandoLote As Byte = 0 'Serve para identificar quando está ocorrendo um assinatura de arquivo

#End Region

#Region "Estruturas"

    Private Structure infLote
        Dim Status As String
        Dim DataComando As String
        Dim DataProtocolo As String
        Dim Protocolo As String
        Dim Mensagem As String
    End Structure

#End Region

#Region "Métodos públicos"


    Public Sub CarregarLista(ByVal _diretorio As String)
        Dim diretorio As New DirectoryInfo(_diretorio)
        Dim arquivos() As FileInfo = diretorio.GetFiles
        Dim item As ListViewItem
        Dim subItem As ListViewItem.ListViewSubItem

        List.Items.Clear()
        List.View = View.Details
        List.BeginUpdate()

        Try
            Dim _arquivo As FileInfo
            For Each _arquivo In arquivos
                item = New ListViewItem
                item.ImageKey = "kcmx"

                _docXml = New XmlDocument
                _docXml.Load(_arquivo.DirectoryName & "\" & _arquivo.Name)

                informacoesLote(_docXml.GetElementsByTagName("NumeroLote").Item(0).InnerText)

                'Analise se o arquivo esta assinado ou não
                subItem = New ListViewItem.ListViewSubItem
                If _docXml.GetElementsByTagName("Signature").Count = 0 Then
                    item.UseItemStyleForSubItems = False
                    subItem.ForeColor = Color.Red
                    subItem.Text = "Não assinado"
                Else
                    item.UseItemStyleForSubItems = False
                    subItem.ForeColor = Color.Blue
                    subItem.Text = "Assinado"
                End If
                item.SubItems.Add(subItem)


                'Analise o status do arquivo e define as cores para cada situação
                subItem = New ListViewItem.ListViewSubItem
                item.UseItemStyleForSubItems = False
                Select Case _infLote.Status
                    Case "Não recebido"
                        subItem.ForeColor = Color.Red
                    Case "Não processado"
                        subItem.ForeColor = Color.Orange
                    Case "Processado com erro"
                        subItem.ForeColor = Color.Red
                    Case "Processado com sucesso"
                        subItem.ForeColor = Color.Green
                    Case "Notas importadas"
                        subItem.ForeColor = Color.Blue


                End Select
                subItem.Text = _infLote.Status
                item.SubItems.Add(subItem)

                'Pega o número do lote
                subItem = New ListViewItem.ListViewSubItem
                subItem.Text = _docXml.GetElementsByTagName("NumeroLote").Item(0).InnerText
                item.SubItems.Add(subItem)

                'Pega o nome do arquivo
                subItem = New ListViewItem.ListViewSubItem
                subItem.Text = _arquivo.Name
                item.SubItems.Add(subItem)

                'Pega a data de criação do arquivo
                subItem = New ListViewItem.ListViewSubItem
                subItem.Text = _arquivo.LastAccessTime
                item.SubItems.Add(subItem)

                'Pega a data de envio do arquivo
                subItem = New ListViewItem.ListViewSubItem
                subItem.Text = _infLote.DataComando
                item.SubItems.Add(subItem)

                'Pega a data do protocolo
                subItem = New ListViewItem.ListViewSubItem
                subItem.Text = _infLote.DataProtocolo
                item.SubItems.Add(subItem)

                'Pega o protocolo de entrega
                subItem = New ListViewItem.ListViewSubItem
                subItem.Text = _infLote.Protocolo
                item.SubItems.Add(subItem)

                'Pega a mensagem
                subItem = New ListViewItem.ListViewSubItem
                subItem.Text = _infLote.Mensagem
                item.SubItems.Add(subItem)


                List.Items.Add(item)
            Next
            List.EndUpdate()
            QutArquivosSel = 0
        Catch ex As Exception
            MsgBox("Ocorreu um erro inesperado" & Chr(13) & ex.Message, vbCritical, "Erro")
            Err.Clear()
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Métodos privados"

    Private Sub frmGerenciarLotes_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        CentralizarForm(Me)
    End Sub

    Private Sub frmGerenciarLotes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Define o tamanho do formulário
        Me.Height = frmPrincipal.Height - 170
        Me.Width = frmPrincipal.Width - 60

        CarregarLista(strDiretorioNFSe)
    End Sub

    Private Sub informacoesLote(ByVal numLote As Integer)

        Dim conBd As New ConexaoBd
        _infLote = New infLote
        Dim strSql As String = "Select Id,NumLote,DataEnvio,DataProtocolo," & _
            "(select descricao from tb_Status where Id = L.Status) as Status, protocolo " & _
            "from tb_Lote L where NumLote = '" & numLote & "'"

        Dim strSqlMensagem As String = "Select CodMensagem,Mensagem " & _
            "from tb_MensagemLote where NumLote = '" & numLote & "'"

        Dim dt As DataTable = conBd.Consultar(strSql, "tb_Lote")
        Dim dtm As DataTable = conBd.Consultar(strSqlMensagem, "tb_MensagemLote")


        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            Dim drm As DataRow
            _infLote.Status = dr("Status")
            _infLote.DataComando = dr("DataEnvio")
            _infLote.DataProtocolo = dr("DataProtocolo")
            _infLote.Protocolo = dr("Protocolo")
            '/// Captura as mensagens de retorno
            If dtm.Rows.Count > 0 Then
                For i As Integer = 0 To dtm.Rows.Count - 1
                    drm = dtm.Rows(i)
                    If i = 0 Then
                        _infLote.Mensagem = drm("CodMensagem") & ":" & drm("Mensagem")
                    Else
                        _infLote.Mensagem = _infLote.Mensagem & ";" & drm("CodMensagem") & ":" & drm("Mensagem")
                    End If
                Next
            Else
                _infLote.Mensagem = ""
            End If
            '/// Fim das mensagens de retorno
        Else
            _infLote.Status = "Não recebido"
            _infLote.DataComando = ""
            _infLote.DataProtocolo = ""
            _infLote.Protocolo = ""
            _infLote.Mensagem = "Arquivo não foi enviado para prefeitura"
        End If
    End Sub



    Private Sub btArquivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btArquivar.Click
        If QutArquivosSel <= 0 Then
            MsgBox("Nenhum registro selecionado!", vbExclamation, "Atenção")
        ElseIf MsgBox("Tem certeza que deseja arquivar os lotes selecionados?" & Chr(13) & "Comando válido somente para status Processado com Sucesso ou Notas Importadas", vbQuestion + vbYesNo + vbDefaultButton2, "Confirmação") = vbYes Then
            ExecutarComandoLote("Arquivar")
        End If
    End Sub

    Private Sub DeletarLote(ByVal item As ListViewItem)
        Dim arquivo As New FileInfo(strDiretorioNFSe & "\" & item.SubItems(4).Text)
        arquivo.Delete()
    End Sub

    Private Sub btAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAtualizar.Click
        CarregarLista(strDiretorioNFSe)
    End Sub

    Private Sub btAssinarLote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAssinarLote.Click
        If QutArquivosSel <= 0 Then
            MsgBox("Nenhum registro selecionado!", vbExclamation, "Atenção")
        ElseIf QutArquivosSel > 1 Then
            MsgBox("Para esta operação selecione somente um registro!", vbExclamation, "Atenção")
        Else
            If MsgBox("Tem certeza que deseja assinar o arquivo selecionado com certificado digital?", vbQuestion + vbYesNo, "Confirmação") = vbYes Then
                ExecutarComandoLote("Assinar")
            End If
        End If
    End Sub

    Private Sub btEnviarLote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEnviarLote.Click
        If QutArquivosSel <= 0 Then
            MsgBox("Nenhum registro selecionado!", vbExclamation, "Atenção")
        ElseIf QutArquivosSel > 1 Then
            MsgBox("Para esta operação selecione somente um registro!", vbExclamation, "Atenção")
        Else
            If MsgBox("Tem certeza que deseja enviar o arquivo selecionado via WebService?", vbQuestion + vbYesNo, "Confirmação") = vbYes Then
                ExecutarComandoLote("Enviar")
            End If
        End If
    End Sub

    Private Sub btVerificarLote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btVerificarLote.Click
        If QutArquivosSel <= 0 Then
            MsgBox("Nenhum registro selecionado!", vbExclamation, "Atenção")
        ElseIf QutArquivosSel > 1 Then
            MsgBox("Para esta operação selecione somente um registro!", vbExclamation, "Atenção")
        Else
            If MsgBox("Tem certeza que deseja consultar o status do arquivo selecionado via WebService?", vbQuestion + vbYesNo, "Confirmação") = vbYes Then
                ExecutarComandoLote("Verificar")
            End If
        End If
    End Sub


    Private Sub btImportarMensagens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImportarMensagens.Click
        If QutArquivosSel <= 0 Then
            MsgBox("Nenhum registro selecionado!", vbExclamation, "Atenção")
        ElseIf QutArquivosSel > 1 Then
            MsgBox("Para esta operação selecione somente um registro!", vbExclamation, "Atenção")
        Else
            If MsgBox("Tem certeza que deseja importar as mensagens de retorno?", vbQuestion + vbYesNo, "Confirmação") = vbYes Then
                ExecutarComandoLote("ImportarMensagens")
            End If
        End If
    End Sub

    Private Sub btImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImportar.Click
        If QutArquivosSel <= 0 Then
            MsgBox("Nenhum registro selecionado!", vbExclamation, "Atenção")
        ElseIf QutArquivosSel > 1 Then
            MsgBox("Para esta operação selecione somente um registro!", vbExclamation, "Atenção")
        Else
            If MsgBox("Tem certeza que deseja importar todas as notas geradas por esse lote?", vbQuestion + vbYesNo, "Confirmação") = vbYes Then
                ExecutarComandoLote("Importar")
            End If
        End If
    End Sub

    Private Sub btExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcluir.Click
        If QutArquivosSel <= 0 Then
            MsgBox("Nenhum registro selecionado!", vbExclamation, "Atenção")
        ElseIf MsgBox("Tem certeza que deseja excluir os arquivos selecionados?" & Chr(13) & "Comando válido somente para status diferente de Não Processado", vbQuestion + vbYesNo + vbDefaultButton2, "Confirmação") = vbYes Then
            ExecutarComandoLote("Deletar")
        End If
    End Sub

    Private Sub AssinarLoteRps(ByVal item As ListViewItem)
        Dim fCertificado As New CertificadoDigital
        Dim cert As X509Certificate2 = fCertificado.SelecionarCertificado("")
        Dim ObjXml As New xmlNFSe.xmlNFSe
        Dim xmlNaoAssinado As New XmlDocument
        xmlNaoAssinado.Load(strDiretorioNFSe & "\" & item.SubItems(4).Text)
        BytAssinandoLote = 1
        ObjXml.frmAssinarXml(MunicipioEmissao, xmlNaoAssinado.OuterXml, cert, strDiretorioNFSe, item.SubItems(3).Text)

        'Destroi as variáveis
        ObjXml = Nothing
        cert = Nothing
        xmlNaoAssinado = Nothing
        fCertificado = Nothing
    End Sub


    Private Sub ServicoEnviarLoteRps_Envio(ByVal item As ListViewItem)
        Dim fCertificado As New CertificadoDigital
        Dim cert As X509Certificate2 = fCertificado.SelecionarCertificado("")
        Dim frmEnviarLoteRps_Envio As New frmExecutar()
        frmEnviarLoteRps_Envio.TipoServico = WsNfse.TipoServico.RECEPCAO_PROCESSAMENTO_LOTE_RPS
        frmEnviarLoteRps_Envio.ItemListView = item
        frmEnviarLoteRps_Envio.frmGerenciar = Me
        frmEnviarLoteRps_Envio.Certificado = cert
        frmEnviarLoteRps_Envio.Show()
        fCertificado = Nothing
        cert = Nothing
    End Sub

    Private Sub ServicoConsultarSitacaoLote_Envio(ByVal item As ListViewItem)
        Dim fCertificado As New CertificadoDigital
        Dim cert As X509Certificate2 = fCertificado.SelecionarCertificado("")
        Dim frmConSitLote_Envio As New frmExecutar()
        frmConSitLote_Envio.TipoServico = WsNfse.TipoServico.CONSULTA_SITUACAO_LOTE_RPS
        frmConSitLote_Envio.ItemListView = item
        frmConSitLote_Envio.frmGerenciar = Me
        frmConSitLote_Envio.Certificado = cert
        frmConSitLote_Envio.Show()
        cert = Nothing
    End Sub

    Private Sub ServicoConsultarLote_Envio(ByVal item As ListViewItem)
        Dim fCertificado As New CertificadoDigital
        Dim cert As X509Certificate2 = fCertificado.SelecionarCertificado("")
        Dim frmConLote_Envio As New frmExecutar()
        frmConLote_Envio.TipoServico = WsNfse.TipoServico.CONSULTA_LOTE_RPS
        frmConLote_Envio.ItemListView = item
        frmConLote_Envio.frmGerenciar = Me
        frmConLote_Envio.Certificado = cert
        frmConLote_Envio.Show()
        cert = Nothing
    End Sub


    Private Sub ExecutarComandoLote(ByVal cmd As String)
        Try
            Dim ArqSelecionado As Boolean = False
            Dim CmdExecutado As Boolean = False
            Dim conBd As New ConexaoBd
            Dim item As ListViewItem

            For Each item In List.Items
                If item.Checked = True Then
                    ArqSelecionado = True
                    Select Case cmd
                        'ASSINAR COM CERTIFICADO DIGITAL
                        Case "Assinar"
                            If item.SubItems(1).Text <> "Assinado" Then
                                CmdExecutado = True
                                AssinarLoteRps(item)
                            End If

                            'ENVIAR LOTE PARA PREFEITURA
                        Case "Enviar"
                            Select Case item.SubItems(2).Text
                                Case "Não recebido"
                                    If item.SubItems(1).Text = "Assinado" Then
                                        CmdExecutado = True
                                        ServicoEnviarLoteRps_Envio(item)
                                    End If
                            End Select

                            'VERIFICAR STATUS DE PROCESSAMENTO DO LOTE
                        Case "Verificar"
                            Select Case item.SubItems(2).Text
                                Case "Não processado"
                                    CmdExecutado = True
                                    ServicoConsultarSitacaoLote_Envio(item)
                            End Select

                            'IMPORTA AS MENSAGENS DE RETORNO 
                        Case "ImportarMensagens"

                            If item.SubItems(2).Text = "Processado com erro" Then
                                CmdExecutado = True
                                RetornoMsg.Situacao = 3
                                ServicoConsultarLote_Envio(item)
                            Else
                                MsgBox("Para essa opção o Status do lote deve ser = Processado com erro", vbExclamation, "Atenção")
                            End If

                            'IMPORTA AS NOTAS GERADAS PELO RESPECTIVO LOTE ImportarMensagens
                        Case "Importar"

                            If item.SubItems(2).Text = "Processado com sucesso" Then
                                CmdExecutado = True
                                RetornoMsg.Situacao = 4
                                ServicoConsultarLote_Envio(item)
                            Else
                                MsgBox("Para essa opção o Status do lote deve ser = Processado com sucesso", vbExclamation, "Atenção")
                            End If

                            'ARQUIVA OS REGISTRO SELECIONADOS NA PASTA \ARQUIVO SÓ PERMITE PARA O STATUS "PROCESSADO COM SUCESSO"
                        Case "Arquivar"
                            If item.SubItems(2).Text = "Processado com sucesso" Or item.SubItems(2).Text = "Notas importadas" Then
                                CmdExecutado = True
                                ArquivarLotes(item)
                            End If
                            'DELETA O ARQUIVO XML DA PASTA. NÃO PERMITE DELETAR LOTES COM STATUS ARGUARDANDO PROCESSAMENTO
                        Case "Deletar"

                            Select Case item.SubItems(2).Text
                                Case Is <> "Não processado"
                                    CmdExecutado = True
                                    DeletarLote(item)
                            End Select
                    End Select
                End If
            Next

            'Personalisa a mensagem para o usuários nas função de Deletar e arquivar
            'As demais mensagens de retorno são dadas pelas respectivas funções
            If CmdExecutado = True Then
                If cmd = "Deletar" Then
                    CarregarLista(strDiretorioNFSe)
                    MsgBox("Arquivos deletados com sucesso!", vbInformation, "Confirmação")

                ElseIf cmd = "Arquivar" Then
                    CarregarLista(strDiretorioNFSe)
                    MsgBox("Lotes arquivados com sucesso!", vbInformation, "Confirmação")
                End If
            End If


        Catch ex As Exception
            MsgBox("Ocorreu um erro inesperado durante a operação" & Chr(13) & ex.Message, vbCritical, "Erro")
            Err.Clear()
        End Try
    End Sub

    'Arquiva todos os lotes selecionados na pasta Arquivo
    Private Sub ArquivarLotes(ByVal item As ListViewItem)
        Dim diretorioDestino As New DirectoryInfo(strDiretorioNFSe & "\Arquivo")
        Dim arquivo As New FileInfo(strDiretorioNFSe & "\" & item.SubItems(4).Text)

        If Not diretorioDestino.Exists Then 'Se for a primeira vez cria o diretório \Arquivo
            diretorioDestino.Create()
        End If
        arquivo.CopyTo(Path.Combine(diretorioDestino.FullName, arquivo.Name), True)
        arquivo.Delete()
    End Sub

    'Toda vez que o usuário marcar ou desmacar no ListView armazena a quantidade de itens selecionados
    Private Sub List_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles List.ItemChecked
        If e.Item.Checked = True Then
            QutArquivosSel += 1
        Else
            QutArquivosSel -= 1
        End If
    End Sub

#End Region

#Region "GAMBI'S"

    '// GAMBI - Tem a função de atualizar a lista de lotes depois de executar o procedimento
    '// de assinar lote. Essa GAMBI foi necessária pois o procedimento de assinatura do lote
    '// é executado pelo componente xmlNfse que por sua vez é executo em segundo plano, ou seja,
    '// é executa em um Thead separada. Assim não era possível identificar quando o procedimento
    '// de assinatura era concluído viabilizando a atualização da lista.
    Private Sub List_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles List.MouseMove
        If BytAssinandoLote = 1 Then
            BytAssinandoLote = 0
            CarregarLista(strDiretorioNFSe)
        End If
    End Sub
#End Region

End Class
