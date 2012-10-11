Imports System.Xml
Imports WsNfs_e
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports xmlNFSe
Imports System.Data.SqlClient

Public Class ServicosWs
    Implements IDisposable
#Region "Variáveis"
    Private cont As Integer
    Private ws As New WsNfse
    Private strRetorno As String = ""
    Private _item As ListViewItem
    Private _servico As WsNfse.TipoServico
    Private _certificado As X509Certificate2
    Private codStatus As Integer
    Private conBd As ConexaoBd
    Private transaction As SqlTransaction
#End Region

#Region "Construtor"

    Public Sub New(ByVal Servico As WsNfse.TipoServico, ByVal itemListView As ListViewItem, ByVal Certificado As X509Certificate2)
        _servico = New WsNfse.TipoServico
        _servico = Servico

        _item = New ListViewItem
        _item = itemListView

        _certificado = New X509Certificate2
        _certificado = Certificado

        conBd = New ConexaoBd
    End Sub
#End Region

#Region "Estruturas"

    Private Structure Retorno
        Dim codigo As String
        Dim mensagem As String
        Dim NumLote As String
        Dim NumRps As String
    End Structure

    'Estrutura utilizada para fazer a leitura do xml de Retorno e salvar no banco de dados
    Private Structure InfNfse
        Dim NumLote As String
        Dim NumRps As String
        Dim CodVerificacao As String
        Dim NumNota As String
        Dim DataEmissao As DateTime
        Dim Serie As String
        Dim Competencia As DateTime
        Dim Tomador As String
        Dim Intermediario As String
        Dim OrgaoGerador As String
        Dim ValorServico As Double
        Dim CodObra As String
        Dim xmlNfse As String
        Dim EmailTomador As String
        Dim StatusEnvioEmail As String
        Dim StatusNfse As String
    End Structure

#End Region

#Region "Métodos publicos"
    'Função principal desta classe. Tem a função de identificar o tipo de serviço solicitado
    'e faz a comunicação com o WebService. Identifica os tipos de retorno bem como a situação
    'do lote em referência
    Public Sub EnviarRequisicao()

        Try

            Select Case _servico

                Case WsNfse.TipoServico.RECEPCAO_PROCESSAMENTO_LOTE_RPS

                    'Carrega o Xml do lote e transforma em string
                    Dim xmlAssinado As New XmlDocument
                    xmlAssinado.PreserveWhitespace = False
                    xmlAssinado.Load(strDiretorioNFSe & "\" & _item.SubItems(4).Text)
                    Dim strXmlAssinado As String = Funcoes.XmlDocumentToString(xmlAssinado)
                    xmlAssinado = Nothing

                    Dim objXml As New xmlNFSe.xmlNFSe
                    'Carrega o cabeçalho de envio WebService
                    Dim strCabecalhoWebService As String = objXml.GerarXmlCabecalho(MunicipioEmissao)
                    objXml = Nothing


                    'Envia a requisão via WebService
                    strRetorno = ws.EnviarRequisicao(AmbienteWebService, _servico, _certificado, strCabecalhoWebService, strXmlAssinado, "", "", "", "", "")

                    'Verifica se retorno mensagem de erro ou documento xml
                    If Left(strRetorno, 8) = "Mensagem" Then
                        Throw New Exception(strRetorno)
                    End If

                    'Transforma o retorno em xml
                    Dim xmlRetorno As New XmlDocument
                    xmlRetorno.PreserveWhitespace = False
                    xmlRetorno.LoadXml(strRetorno)

                    Dim _listaRetorno As New List(Of Retorno)
                    Dim retorno As New Retorno

                    '///Verifica se houve mensagem de retorno ou se o arquivo foi protocolado
                    If xmlRetorno.GetElementsByTagName("Protocolo").Count = 0 Then 'Não foi protocolado

                        _listaRetorno = ListaMensagemRetorno(xmlRetorno)
                        'Atualiza o banco de dados e salva as mensagens de retorno
                        InserirTabelaLote(_item.SubItems(3).Text, 1, "", "", _listaRetorno)

                        RetornoMsg.MsgRetorno = "Arquivo não foi recepcionado pela prefeitura! Ver mensagem de retorno."
                        RetornoMsg.TituloMsg = "Atenção"
                        RetornoMsg.StyleMsgBox = vbExclamation

                    Else 'Foi protocolado

                        'Atualiza o banco de dados e salva as mensagens de retorno
                        retorno.codigo = "002"
                        retorno.NumLote = _item.SubItems(3).Text
                        retorno.mensagem = "Arquivo recepcionado pela prefeitura"
                        _listaRetorno.Add(retorno)
                        InserirTabelaLote(_item.SubItems(3).Text, 2, xmlRetorno.GetElementsByTagName("Protocolo").Item(0).InnerText, Format(Date.Now, "dd/MM/yyyy hh:mm:ss"), _listaRetorno)

                        RetornoMsg.MsgRetorno = "Arquivo recepcionado e protocolado pela prefeitura!"
                        RetornoMsg.TituloMsg = "Confirmação"
                        RetornoMsg.StyleMsgBox = vbInformation

                    End If

                    xmlRetorno = Nothing
                    retorno = Nothing
                    _listaRetorno = Nothing

                Case WsNfse.TipoServico.CONSULTA_SITUACAO_LOTE_RPS

                    'Obtem o xml de consulta situação
                    Dim objXml As New xmlNFSe.xmlNFSe
                    Dim strXml As String = objXml.GerarXmlConsultaSituacaoLoteRps(MunicipioEmissao, CnpjDoEmitente, InscricaoMunicipalDoEmitente, _item.SubItems(8).Text, _certificado)
                    'Carrega o cabeçalho de envio WebService
                    Dim strCabecalhoWebService As String = objXml.GerarXmlCabecalho(MunicipioEmissao)
                    objXml = Nothing


                    'Envia a requisição via WebService
                    strRetorno = ws.EnviarRequisicao(AmbienteWebService, _servico, _certificado, strCabecalhoWebService, strXml, "", "", "", "", "")

                    'Verifica se retorno mensagem de erro ou documento xml
                    If Left(strRetorno, 8) = "Mensagem" Then
                        Throw New Exception(strRetorno)
                    End If

                    'Transforma o retorno em xml
                    Dim xmlRetorno As New XmlDocument
                    xmlRetorno.PreserveWhitespace = False
                    xmlRetorno.LoadXml(strRetorno)

                    'Pega as mensagens de retorno
                    Dim MensagensRetorno As New List(Of Retorno)
                    MensagensRetorno = ListaMensagemRetorno(xmlRetorno)

                    'Atualiza o banco de dados e salva as mensagens de retorno
                    InserirTabelaLote(_item.SubItems(3).Text, codStatus, _item.SubItems(8).Text, _item.SubItems(7).Text, MensagensRetorno)

                    'Personalisa a mensagem de retorno para o usuário
                    If codStatus = 1 Then
                        RetornoMsg.MsgRetorno = "Arquivo não foi recepcionado pela prefeitura!"
                        RetornoMsg.TituloMsg = "Atenção"
                        RetornoMsg.StyleMsgBox = vbExclamation
                        RetornoMsg.Situacao = 1
                    ElseIf codStatus = 2 Then
                        RetornoMsg.MsgRetorno = "Arquivo não processado pela prefeitura!"
                        RetornoMsg.TituloMsg = "Atenção"
                        RetornoMsg.StyleMsgBox = vbExclamation
                        RetornoMsg.Situacao = 2
                    ElseIf codStatus = 3 Then

                        If RetornoMsg.Situacao = 3 Then
                            RetornoMsg.MsgRetorno = "O arquivo foi processado e apresenta erros!" & Chr(13) & "Deseja importar as mensagens de retorno?"
                            RetornoMsg.StyleMsgBox = vbQuestion + vbYesNo
                        Else
                            RetornoMsg.MsgRetorno = "O arquivo foi processado e apresenta erros!" & Chr(13) & "Verifique as mensagens de retorno"
                            RetornoMsg.StyleMsgBox = vbExclamation
                        End If
                        RetornoMsg.TituloMsg = "Atenção"
                    ElseIf codStatus = 4 Then
                        RetornoMsg.MsgRetorno = "O arquivo foi processado com sucesso!" & Chr(13) & "Deseja importar as notas?"
                        RetornoMsg.TituloMsg = "Confirmação"
                        RetornoMsg.StyleMsgBox = vbInformation + vbYesNo
                        RetornoMsg.Situacao = 4
                    End If

                    xmlRetorno = Nothing

                Case WsNfse.TipoServico.CONSULTA_LOTE_RPS



                    'Obtem o xml de consulta lote Rps
                    Dim objXml As New xmlNFSe.xmlNFSe
                    Dim strXml As String = objXml.GerarXmlConsultaLoteRps(MunicipioEmissao, CnpjDoEmitente, InscricaoMunicipalDoEmitente, _item.SubItems(8).Text, _certificado)
                    'Carrega o cabeçalho de envio WebService
                    Dim strCabecalhoWebService As String = objXml.GerarXmlCabecalho(MunicipioEmissao)
                    objXml = Nothing

                    'Envia requisição via WebService
                    strRetorno = ws.EnviarRequisicao(AmbienteWebService, _servico, _certificado, strCabecalhoWebService, strXml, "", "", "", "", "")

                    'Verifica se retorno mensagem de erro ou documento xml
                    If Left(strRetorno, 8) = "Mensagem" Then
                        Throw New Exception(strRetorno)
                    End If

                    'Transforma o retorno em xml
                    Dim xmlRetorno As New XmlDocument
                    xmlRetorno.PreserveWhitespace = False
                    xmlRetorno.LoadXml(strRetorno)


                    'Atualiza o banco de dados e salva as mensagens de retorno
                    InserirTabelaLote(_item.SubItems(3).Text, RetornoMsg.Situacao, _item.SubItems(8).Text, _item.SubItems(7).Text, ListaMensagemRetornoLote(xmlRetorno))

                    'Personalisa a mensagem de retorno para o usuário
                    If RetornoMsg.Situacao = 6 Then
                        RetornoMsg.MsgRetorno = "Mensagens de retorno importadas com sucesso!"
                        RetornoMsg.TituloMsg = "Confirmação"
                        RetornoMsg.StyleMsgBox = vbInformation
                        RetornoMsg.Situacao = 0
                    ElseIf RetornoMsg.Situacao = 5 Then
                        RetornoMsg.MsgRetorno = "Importação de Nfs-e realizada com sucesso!"
                        RetornoMsg.TituloMsg = "Confirmação"
                        RetornoMsg.StyleMsgBox = vbInformation
                        RetornoMsg.Situacao = 0
                    End If

            End Select

        Catch ex As Exception

            'Seguração para msg de retorno para o usuário
            RetornoMsg.MsgRetorno = ex.Message
            RetornoMsg.TituloMsg = "Erro"
            RetornoMsg.StyleMsgBox = vbCritical
            RetornoMsg.Situacao = 0

            Throw New Exception(ex.Message)

        End Try
    End Sub

#End Region

#Region "Metodos privados"

    'Lista as mensagens de retorno da situação do lote
    'So é executada nos serviços RECEPCAO_PROCESSAMENTO_LOTE_RPS e CONSULTA_SITUACAO_LOTE_RPS
    Private Function ListaMensagemRetorno(ByVal xmlDoc As XmlDocument) As List(Of Retorno)
        Dim _listaRetorno As New List(Of Retorno)
        Dim retorno As New Retorno


        'Pega o código da situação (status) do lote
        If xmlDoc.GetElementsByTagName("Situacao").Count <> 0 Then
            codStatus = Int(xmlDoc.GetElementsByTagName("Situacao").Item(0).InnerText)
        ElseIf xmlDoc.GetElementsByTagName("ListaMensagemRetorno").Count <> 0 Then
            codStatus = 3
        End If

        'Verifica se a prefeitura retornou as mensagems
        If xmlDoc.GetElementsByTagName("ListaMensagemRetorno").Count <> 0 Then 'Retornou

            RetornoMsg.Situacao = 6 'Importado Erros

            'Faz um loop procurando os erros
            Dim nodeListaMensagem As XmlNodeList = xmlDoc.GetElementsByTagName("ListaMensagemRetorno").Item(0).ChildNodes
            For Each infMensagem As XmlElement In nodeListaMensagem
                retorno.NumRps = ""
                retorno.NumLote = _item.SubItems(3).Text
                retorno.codigo = infMensagem.GetElementsByTagName("Codigo").Item(0).InnerText
                retorno.mensagem = infMensagem.GetElementsByTagName("Mensagem").Item(0).InnerText.Replace("'", "")
                _listaRetorno.Add(retorno)
            Next
            nodeListaMensagem = Nothing

        Else 'Não retornou

            RetornoMsg.Situacao = 3

            'Personalisa a mensagem de retorno para o usuário
            retorno.NumRps = ""
            retorno.NumLote = _item.SubItems(3).Text
            If codStatus = 1 Then
                retorno.codigo = "001"
                retorno.mensagem = "O Lote ainda não foi recepcionado pela prefeitura"
            ElseIf codStatus = 2 Then
                retorno.codigo = "002"
                retorno.mensagem = "O Lote ainda não foi processado pela prefeitura"
            ElseIf codStatus = 3 Then
                retorno.codigo = "003"
                retorno.mensagem = "O Lote foi processado com erro"
            ElseIf codStatus = 4 Then
                retorno.codigo = "004"
                retorno.mensagem = "A prefeitura processou o arquivo com sucesso!"
            End If
            _listaRetorno.Add(retorno)

        End If

        Return _listaRetorno
    End Function

    'Lista as mensagens de retorno do Lote identificando se retornou erro ou Nfs-e.
    'So é executada no serviço CONSULTAR_LOTE_RPS
    Private Function ListaMensagemRetornoLote(ByVal xmlDoc As XmlDocument) As List(Of Retorno)

        Dim _listaRetorno As New List(Of Retorno)
        Dim retorno As New Retorno

        'Verifica se a prefeitura retornou as mensagems de erro ou de NFS-e
        If xmlDoc.GetElementsByTagName("ListaNfse").Count = 0 Then 'Retornou Msg Erro

            RetornoMsg.Situacao = 6 'Importado Erros

            If xmlDoc.GetElementsByTagName("ListaMensagemRetornoLote").Count <> 0 Then
                'Faz um loop procurando os erros
                Dim nodeListaMensagem As XmlNodeList = xmlDoc.GetElementsByTagName("ListaMensagemRetornoLote").Item(0).ChildNodes
                For Each infMensagem As XmlElement In nodeListaMensagem

                    Dim infIdentRps As XmlElement = infMensagem.GetElementsByTagName("IdentificacaoRps").Item(0)
                    retorno.NumRps = "Rps: " & infIdentRps.GetElementsByTagName("Numero").Item(0).InnerText & "-"
                    retorno.NumLote = _item.SubItems(3).Text
                    retorno.codigo = infMensagem.GetElementsByTagName("Codigo").Item(0).InnerText
                    retorno.mensagem = retorno.NumRps & infMensagem.GetElementsByTagName("Mensagem").Item(0).InnerText.Replace("'", "")
                    _listaRetorno.Add(retorno)

                Next
                nodeListaMensagem = Nothing
            Else
                _listaRetorno = ListaMensagemRetorno(xmlDoc)
            End If

        Else 'Retornou Nfs-e (Realiza importação)

            RetornoMsg.Situacao = 5 'Importado Nfs-e
            retorno.NumRps = ""
            retorno.NumLote = _item.SubItems(3).Text
            retorno.codigo = "005"
            retorno.mensagem = "Notas importadas"
            _listaRetorno.Add(retorno)
        End If

        Return _listaRetorno
    End Function

    'Insere/atualiza as informações do lote e se for o caso inicia a importação das Nfs-e para o banco de dados
    Private Sub InserirTabelaLote(ByVal _numLote As Integer, ByVal _status As Integer, ByVal _protocolo As String, ByVal _dataProtocolo As String, ByVal _listRetorno As List(Of Retorno))
        'Primeiro verifica se o lote já não está sendo controlado pela tabela tb_Lote
        'Caso não esteja sendo contralado inclui o registro na tabela para controle
        'Caso esteja sendo controlado so atualiza as informações
        Dim Sql As String
        Dim SqlConsultar As String = "Select Id from tb_Lote where NumLote = '" & _numLote & "'"
        Dim dt As DataTable = conBd.Consultar(SqlConsultar, "tb_Lote")

        If dt.Rows.Count <= 0 Then
            Sql = "Insert into tb_Lote(NumLote,DataEnvio,Status,Protocolo,DataProtocolo) values" & _
                    "('" & _numLote & "','" & Format(Date.Now, "dd/MM/yyyy hh:mm:ss") & "','" & _status & "','" & _protocolo & "','" & _dataProtocolo & "')"
        Else
            Sql = "Update tb_Lote set DataEnvio = '" & Format(Date.Now, "dd/MM/yyyy hh:mm:ss") & "', Status = '" & _status & "',Protocolo = '" & _protocolo & "',DataProtocolo = '" & _dataProtocolo & "' where NumLote = '" & _numLote & "'"
        End If

        'INICIAR TRANSAÇÃO DE BANCO DE DADOS AQUI
        transaction = conBd.ConnBd.BeginTransaction
        Try
            conBd.ExecutarSqlTransacao(Sql, transaction)
            InserirMsgLoteResposta(_listRetorno)

            'Verifica se é para salvar as Nfs-e no banco de dados
            If RetornoMsg.Situacao = 5 Then
                ImportarNfse()
            End If

            'EFETUA COMMIT NA TRANSÃO E SALVA AS ALTERAÇÕES
            transaction.Commit()
        Catch ex As Exception
            'SE OCORREU UM ERRO DESFAZAR AS ALTERAÇÕES
            transaction.Rollback()
            Throw New Exception("Erro ao inserir/atualizar no banco de dados" & Chr(13) & ex.Message)
        End Try


    End Sub

    'Insere a mensagens de retorno no bando de dados
    Private Sub InserirMsgLoteResposta(ByVal _listRetorno As List(Of Retorno))

        Try
            Dim Sql As String = ""

            'Antes de inserir deleta todas as mensagem já existentes para o lote em referência
            Sql = "Delete from tb_MensagemLote where Numlote = '" & _listRetorno.Item(0).NumLote & "'"
            conBd.ExecutarSqlTransacao(Sql, transaction)

            'Faz um loop inserindo as novas mensagens no banco de dados
            For Each _retorno As Retorno In _listRetorno
                Sql = "Insert into tb_MensagemLote(NumLote,CodMensagem,Mensagem) values" & _
                    "('" & CType(_retorno.NumLote, Integer) & "','" & _retorno.codigo & "','" & _retorno.mensagem & "')"
                conBd.ExecutarSqlTransacao(Sql, transaction)
            Next

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar inserir as mensagens de retorno" & Chr(13) & ex.Message)
        End Try

    End Sub

    'Importa/insere as Notas no bando de dados
    Private Sub ImportarNfse()

        'Carrega o retorno para um documento xml
        Dim xmlRetorno As New XmlDocument
        xmlRetorno.PreserveWhitespace = False
        xmlRetorno.LoadXml(strRetorno)

        Dim _infNfse As New InfNfse
        Dim _ListaInfNfse As New List(Of InfNfse)
        Dim xmlInfNfse As XmlElement
        Dim xmlIdRps As XmlElement
        Dim xmlServico As XmlElement
        Dim xmlValorServico As XmlElement
        Dim xmlTomador As XmlElement
        Dim xmlIntermediario As XmlElement
        Dim xmlConstrucaoCivil As XmlElement
        Dim xmlOrgaoGerador As XmlElement
        Dim strData As String

        'Faz um loop identificando as Notas
        Dim ListaNfse As XmlNodeList = xmlRetorno.GetElementsByTagName("ListaNfse").Item(0).ChildNodes
        For Each CompNfse As XmlElement In ListaNfse


            xmlInfNfse = CompNfse.GetElementsByTagName("Nfse").Item(0)

            _infNfse.NumLote = Trim(_item.SubItems(3).Text)
            _infNfse.NumNota = Trim(xmlInfNfse.GetElementsByTagName("Numero").Item(0).InnerText)
            _infNfse.CodVerificacao = Trim(xmlInfNfse.GetElementsByTagName("CodigoVerificacao").Item(0).InnerText)

            'Data de Emissão e Competencia
            strData = Trim(xmlInfNfse.GetElementsByTagName("DataEmissao").Item(0).InnerText)
            strData = Mid(strData, 1, 10) & " " & Mid(strData, 12)
            _infNfse.DataEmissao = FormatDateTime(strData)

            strData = Trim(xmlInfNfse.GetElementsByTagName("Competencia").Item(0).InnerText)
            strData = Mid(strData, 1, 10) & " " & Mid(strData, 12)
            _infNfse.Competencia = FormatDateTime(strData)


            'Identificação do RPS (se houver)
            If xmlInfNfse.GetElementsByTagName("IdentificacaoRps").Count <> 0 Then
                xmlIdRps = xmlInfNfse.GetElementsByTagName("IdentificacaoRps").Item(0)
                _infNfse.NumRps = Trim(xmlIdRps.GetElementsByTagName("Numero").Item(0).InnerText)
                _infNfse.Serie = Trim(xmlIdRps.GetElementsByTagName("Serie").Item(0).InnerText)
            Else
                _infNfse.NumRps = ""
                _infNfse.Serie = ""
            End If


            'Identificação do valor do serviço
            xmlServico = xmlInfNfse.GetElementsByTagName("Servico").Item(0)
            xmlValorServico = xmlServico.GetElementsByTagName("Valores").Item(0)
            _infNfse.ValorServico = CType(Trim(xmlValorServico.GetElementsByTagName("ValorServicos").Item(0).InnerText.Replace(".", ",")), Double)

            'Identificação do tomador do servico
            xmlTomador = xmlInfNfse.GetElementsByTagName("TomadorServico").Item(0)
            _infNfse.Tomador = Trim(xmlTomador.GetElementsByTagName("RazaoSocial").Item(0).InnerText)

            If xmlTomador.GetElementsByTagName("Email").Count <> 0 Then
                _infNfse.EmailTomador = xmlTomador.GetElementsByTagName("Email").Item(0).InnerText
            Else
                _infNfse.EmailTomador = ""
            End If


            'Identificacao do Intermediário (se houver)
            If xmlInfNfse.GetElementsByTagName("IntermediarioServico").Count <> 0 Then
                xmlIntermediario = xmlInfNfse.GetElementsByTagName("IntermediarioServico").Item(0)
                _infNfse.Intermediario = Trim(xmlIntermediario.GetElementsByTagName("RazaoSocial").Item(0).InnerText)
            Else
                _infNfse.Intermediario = ""
            End If

            'Identificação da Construção Civil (se houver)
            If xmlInfNfse.GetElementsByTagName("ConstrucaoCivil").Count <> 0 Then
                xmlConstrucaoCivil = xmlInfNfse.GetElementsByTagName("ConstrucaoCivil").Item(0)
                _infNfse.CodObra = Trim(xmlConstrucaoCivil.GetElementsByTagName("CodigoObra").Item(0).InnerText)
            Else
                _infNfse.CodObra = ""
            End If

            'Identificação do orgão gerador
            xmlOrgaoGerador = xmlInfNfse.GetElementsByTagName("OrgaoGerador").Item(0)
            _infNfse.OrgaoGerador = Trim(xmlOrgaoGerador.GetElementsByTagName("CodigoMunicipio").Item(0).InnerText)

            'Xml da Nfse
            _infNfse.xmlNfse = CompNfse.OuterXml

            _infNfse.StatusEnvioEmail = "NÃO ENVIADO"
            _infNfse.StatusNfse = "NORMAL"

            'Incluir os dados da Nfse na lista de dados Nfse
            _ListaInfNfse.Add(_infNfse)
        Next

        'Insere o xml da nota e demais informações no banco de dados
        InserirNotasNoBanco(_ListaInfNfse)


        'Destroi as variávies utilizadas liberando memória
        xmlRetorno = Nothing
        _infNfse = Nothing
        _ListaInfNfse = Nothing
        xmlIdRps = Nothing
        xmlServico = Nothing
        xmlValorServico = Nothing
        xmlTomador = Nothing
        xmlIntermediario = Nothing
        xmlConstrucaoCivil = Nothing
        xmlOrgaoGerador = Nothing
    End Sub

    'Insere as notas importadas no banco de dados
    Private Sub InserirNotasNoBanco(ByVal _listaInfNfse As List(Of InfNfse))

        Try
            Dim Sql As String = ""


            'Deleta todas as notas existentes com o respectivo número do lote
            Sql = "Delete from tb_Nfse where NumLote = '" & Trim(_item.SubItems(3).Text) & "'"
            conBd.ExecutarSqlTransacao(Sql, transaction)


            'Faz um loop inserindo as notas no banco de dados
            For Each _infNfse As InfNfse In _listaInfNfse
                'Insere na tabela tb_Nfse

                Sql = "Insert into tb_Nfse(NumRps,NumNota,DataEmissao,NumLote,Serie,Competencia,Tomador," & _
                "Intermediario,OrgaoGerador,CodigoVerificacao,ValorServico,CodigoObra,EmailTomador,StatusEnvioEmail,StatusNfse) values" & _
                "('" & _infNfse.NumRps & "','" & _infNfse.NumNota & "'," & _
                "@DataEmissao,'" & _infNfse.NumLote & "','" & _infNfse.Serie & "'," & _
                "@Competencia,'" & _infNfse.Tomador & "','" & _infNfse.Intermediario & "'," & _
                "'" & _infNfse.OrgaoGerador & "','" & _infNfse.CodVerificacao & "','" & _infNfse.ValorServico & "'," & _
                "'" & _infNfse.CodObra & "','" & _infNfse.EmailTomador & "','" & _infNfse.StatusEnvioEmail & "','" & _infNfse.StatusNfse & "')"
                conBd.ExecutarSqlNfse(Sql, transaction, _infNfse.DataEmissao, _infNfse.Competencia)

                'Insere na tabela tb_Xml_Nfse
                Sql = "Insert into tb_Xml_Nfse(NumNota,Xml) values ('" & _infNfse.NumNota & "','" & _infNfse.xmlNfse & "')"
                conBd.ExecutarSqlTransacao(Sql, transaction)

                'Muda o status do Lote para 5 - Notas importadas
                Sql = "Update tb_Lote set Status = 5 where NumLote = '" & CType(_infNfse.NumLote, Integer) & "' "
                conBd.ExecutarSqlTransacao(Sql, transaction)
            Next
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar inserir as notas no banco de dados" & Chr(13) & ex.Message)
        End Try

    End Sub

#End Region

#Region "Metodos sobrescritos"

    Protected Overridable Sub Dispose() Implements IDisposable.Dispose
        'Destroi variáveis
        ws = Nothing
        _servico = Nothing
        strRetorno = Nothing
        conBd = Nothing
    End Sub

    Protected Overrides Sub Finalize()
        Me.Dispose()
    End Sub

#End Region

End Class
