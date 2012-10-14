Imports System.Xml
Public Class ConverteAbrasf

#Region "Construtores"
    Public Sub New(ByRef FileNameXml As String, ByVal UtilizarFormNaAssinatura As Boolean)
        FileNameXmlAbrasf = FileNameXml
        UtilizarForm = UtilizarFormNaAssinatura
        XmlAbrasf = New XmlDocument
        XmlAbrasf.Load(FileNameXml)
        InformacoesLote = New InfLote
        ListaRps = New List(Of InfRps)
    End Sub
#End Region

#Region "Variáveis"
    Private UtilizarForm As Boolean
    Private FileNameXmlAbrasf As String
    Private XmlAbrasf As XmlDocument
    Private InformacoesLote As InfLote
    Private ListaRps As List(Of InfRps)
#End Region

#Region "Struturas"

    'Representa o cabeçalho do lote
    Private Structure InfLote
        'Emitente
        Dim RazoSocialEmitente As String
        Dim CnpjEmitente As String
        Dim InscrMunicipalEmitente As String

        'Lote
        Dim NumLote As String
        Dim QutRps As String
    End Structure

    'Representa toda a strutura de um Rps
    Private Structure InfRps

        'Identificação Rps
        Dim IdRps As String
        Dim NumeroRps As String
        Dim SerieRps As String
        Dim TipoRps As xmlNFSe.TipoRps
        Dim DataEmissao As String
        Dim NatOperacao As xmlNFSe.NaturezaOperacao
        Dim RegEspTributacao As xmlNFSe.RegimeEspTributacao
        Dim OptSimplesNacional As xmlNFSe.OptanteSimplesNacional
        Dim IncentCultural As xmlNFSe.IncentivadorCultural
        Dim StatusRps As xmlNFSe.StatusRps

        'Identificação Rps Substituido
        Dim RpsSubstituido As xmlNFSe.RpsSubstituido
        Dim NumeroRpsSubstituido As String
        Dim SerieRpsSubstituido As String
        Dim TipoRpsSubstituido As xmlNFSe.TipoRps

        'Serviço
        Dim ValorServicos As String
        Dim ValorDeducoes As String
        Dim ValorPis As String
        Dim ValorCofins As String
        Dim ValorInss As String
        Dim ValorIr As String
        Dim ValorCsll As String
        Dim IssRetido As xmlNFSe.ISSRetido
        Dim ValorIss As String
        Dim ValorOutrasRetencoes As String
        Dim BaseCalculo As String
        Dim Aliquota As String
        Dim ValorLiquidoNfse As String
        Dim ValorIssRetido As String
        Dim DescontoIncodicionado As String
        Dim DescontoCondicionado As String
        Dim ItemListaServico As String
        Dim CodigoCnae As String
        Dim CodTributacaoMunicipal As String
        Dim Discriminacao As String
        Dim CodMunicipio As String

        'Prestador
        Dim CnpjPrestador As String
        Dim InscrMunicipalPrestador As String

        'Tomador
        Dim TipoPessoaTomador As xmlNFSe.TipoPessoa
        Dim CpfTomador As String
        Dim CnpjTomador As String
        Dim InscrMunicipalTomador As String
        Dim RazaoSocialTomador As String
        Dim LogradouroTomador As String
        Dim EnderecoNumeroTomador As String
        Dim EnderecoComplementoTomador As String
        Dim BairroTomador As String
        Dim CodMunicipioTomador As String
        Dim UfTomador As String
        Dim CepTomador As String
        Dim EmailTomador As String
        Dim TelefoneTomador As String

        'Intermediário Serviço
        Dim TipoPessoaIntermediario As xmlNFSe.TipoPessoa
        Dim RazaoSocialIntermediario As String
        Dim CpfIntermediario As String
        Dim CnpjIntermediario As String
        Dim InscrMunicipalIntermediario As String

        'Construção Civil
        Dim CodObra As String
        Dim Art As String

    End Structure

#End Region

#Region "Métodos públicos"
    Friend Sub ConverterPadraoAbrasf()
        Try
            VincularDadosRps()
            GerarLoteRps()
        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao tentar converter o lote padrão Abrasf!" & Chr(13) & ex.Message)
            Err.Clear()
        End Try

    End Sub
#End Region

#Region "Métodos privados"

    'Captura/vincula os dados para geração do lote
    Private Sub VincularDadosRps()

        Dim _infRps As InfRps

        'Pega informações do Cadastro da Empresa e do Cadastro de Parâmetros
        Dim conBd As New ConexaoBd
        Dim SqlConsultar As String = "Select * from tb_CadEmpresa"
        Dim dt As DataTable = conBd.Consultar(SqlConsultar, "tb_CadEmpresa")
        Dim dr As DataRow = dt.Rows(0)

        SqlConsultar = "Select * from tb_Parametros"
        Dim dt1 As DataTable = conBd.Consultar(SqlConsultar, "tb_Parametros")
        Dim drParametros As DataRow = dt1.Rows(0)

        'Vincula os dados do cabeçalho do lote
        InformacoesLote.RazoSocialEmitente = dr("RazaoSocial")
        InformacoesLote.CnpjEmitente = dr("Cnpj")
        InformacoesLote.InscrMunicipalEmitente = dr("InscricaoMunicipal")

        If XmlAbrasf.GetElementsByTagName("NumeroLote").Count <= 0 Then
            InformacoesLote.NumLote = Nothing
        Else
            InformacoesLote.NumLote = Trim(XmlAbrasf.GetElementsByTagName("NumeroLote").Item(0).InnerText)
        End If

        If XmlAbrasf.GetElementsByTagName("QuantidadeRps").Count <= 0 Then
            InformacoesLote.QutRps = Nothing
        Else
            InformacoesLote.QutRps = Trim(XmlAbrasf.GetElementsByTagName("QuantidadeRps").Item(0).InnerText)
        End If

        'Faz um loop pelo Xml procurando os Rps
        Dim ListaTagInfRps As XmlNodeList = XmlAbrasf.GetElementsByTagName("InfRps")

        For Each TagInfRps As XmlElement In ListaTagInfRps
            _infRps = New InfRps


            'IDENTIFICAÇÃO E DADOS DO RPS

            Dim xmlIdentRps As XmlElement = TagInfRps.GetElementsByTagName("IdentificacaoRps").Item(0)

            _infRps.NumeroRps = Trim(xmlIdentRps.GetElementsByTagName("Numero").Item(0).InnerText)

            '// caso o campo série do Rps não esteja preenchido no XmlAbrasf então joga o valor padrão da tabela de parâmetros
            If xmlIdentRps.GetElementsByTagName("Serie").Count <= 0 Then
                _infRps.SerieRps = Nothing
            Else
                If Trim(xmlIdentRps.GetElementsByTagName("Serie").Item(0).InnerText) = "" Then
                    _infRps.SerieRps = drParametros("Serie")
                Else
                    _infRps.SerieRps = Trim(xmlIdentRps.GetElementsByTagName("Serie").Item(0).InnerText)
                End If
            End If

            '// caso o campo tipo do Rps não esteja preenchido no XmlAbrasf então joga o valor padrão da tabela de parâmetros
            If xmlIdentRps.GetElementsByTagName("Tipo").Count <= 0 Then
                _infRps.TipoRps = Nothing
            Else
                _infRps.TipoRps = Trim(xmlIdentRps.GetElementsByTagName("Tipo").Item(0).InnerText)
            End If

            '// transforma a data de emissão do XmlAbrasf em DataTime
            Dim strData As String = TagInfRps.GetElementsByTagName("DataEmissao").Item(0).InnerText
            strData = strData.Replace("T", " ")
            Dim DataEmissao As Date = strData
            _infRps.DataEmissao = DataEmissao

            '// caso o campo Natureza da Operação do Rps não esteja preenchido no XmlAbrasf então joga o valor padrão da tabela de parâmetros
            If TagInfRps.GetElementsByTagName("NaturezaOperacao").Count <= 0 Then
                _infRps.NatOperacao = Nothing
            Else
                _infRps.NatOperacao = Trim(TagInfRps.GetElementsByTagName("NaturezaOperacao").Item(0).InnerText)
            End If

            '// caso o campo Regime Especial de Tributação do Rps não esteja preenchido no XmlAbrasf então joga o valor padrão da tabela de parâmetros
            If TagInfRps.GetElementsByTagName("RegimeEspecialTributacao").Count <= 0 Then
                _infRps.RegEspTributacao = Nothing
            Else
                _infRps.RegEspTributacao = Trim(TagInfRps.GetElementsByTagName("RegimeEspecialTributacao").Item(0).InnerText)
            End If

            '// caso o campo Optante pelo Simples do Rps não esteja preenchido no XmlAbrasf então joga o valor padrão da tabela de parâmetros
            If TagInfRps.GetElementsByTagName("OptanteSimplesNacional").Count <= 0 Then
                _infRps.OptSimplesNacional = Nothing
            Else
                _infRps.OptSimplesNacional = Trim(TagInfRps.GetElementsByTagName("OptanteSimplesNacional").Item(0).InnerText)
            End If

            '// caso o campo Incentivador Cultural do Rps não esteja preenchido no XmlAbrasf então joga o valor padrão da tabela de parâmetros
            If TagInfRps.GetElementsByTagName("IncentivadorCultural").Count <= 0 Then
                _infRps.IncentCultural = Nothing
            Else
                _infRps.IncentCultural = Trim(TagInfRps.GetElementsByTagName("IncentivadorCultural").Item(0).InnerText)
            End If

            '// caso o campo Status do Rps não esteja preenchido no XmlAbrasf então lança um mensagem de erro para o usuário
            If TagInfRps.GetElementsByTagName("Status").Count <= 0 Then
                _infRps.StatusRps = Nothing
            Else
                _infRps.StatusRps = Trim(TagInfRps.GetElementsByTagName("Status").Item(0).InnerText)
            End If


            'RSP SUBSTITUIDO
            If TagInfRps.GetElementsByTagName("RpsSubstituido").Count <= 0 Then
                _infRps.RpsSubstituido = xmlNFSe.RpsSubstituido.Nao
                _infRps.NumeroRpsSubstituido = Nothing
                _infRps.SerieRpsSubstituido = Nothing
                _infRps.TipoRpsSubstituido = Nothing
            Else
                Dim xmlRpsSubstituido As XmlElement = TagInfRps.GetElementsByTagName("RpsSubstituido").Item(0)
                _infRps.RpsSubstituido = xmlNFSe.RpsSubstituido.Sim
                If xmlRpsSubstituido.GetElementsByTagName("Numero").Count <= 0 Then
                    _infRps.NumeroRpsSubstituido = Nothing
                Else
                    _infRps.NumeroRpsSubstituido = Trim(xmlRpsSubstituido.GetElementsByTagName("Numero").Item(0).InnerText)
                End If

                If xmlRpsSubstituido.GetElementsByTagName("Serie").Count <= 0 Then
                    _infRps.SerieRpsSubstituido = Nothing
                Else
                    _infRps.SerieRpsSubstituido = Trim(xmlRpsSubstituido.GetElementsByTagName("Serie").Item(0).InnerText)
                End If

                If xmlRpsSubstituido.GetElementsByTagName("Tipo").Count <= 0 Then
                    _infRps.TipoRpsSubstituido = Nothing
                Else
                    _infRps.TipoRpsSubstituido = Trim(xmlRpsSubstituido.GetElementsByTagName("Tipo").Item(0).InnerText)
                End If

            End If


            'SERVIÇO
            Dim xmlServico As XmlElement = TagInfRps.GetElementsByTagName("Servico").Item(0)

            '// caso o campo Valor do Serviço não esteja preenchido no XmlAbrasf então lança um mensagem de erro para o usuário
            If xmlServico.GetElementsByTagName("ValorServicos").Count <= 0 Then
                _infRps.ValorServicos = Nothing
            Else
                _infRps.ValorServicos = Trim(xmlServico.GetElementsByTagName("ValorServicos").Item(0).InnerText.Replace(".", ","))
            End If


            '// caso o campo Valor Deduções não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("ValorDeducoes").Count <= 0 Then
                _infRps.ValorDeducoes = Nothing
            Else
                _infRps.ValorDeducoes = Trim(xmlServico.GetElementsByTagName("ValorDeducoes").Item(0).InnerText.Replace(".", ","))
            End If

            '// caso o campo Valor PIS não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("ValorPis").Count <= 0 Then
                _infRps.ValorPis = Nothing
            Else
                _infRps.ValorPis = Trim(xmlServico.GetElementsByTagName("ValorPis").Item(0).InnerText.Replace(".", ","))
            End If

            '// caso o campo Valor COFINS não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("ValorCofins").Count <= 0 Then
                _infRps.ValorCofins = Nothing
            Else
                _infRps.ValorCofins = Trim(xmlServico.GetElementsByTagName("ValorCofins").Item(0).InnerText.Replace(".", ","))
            End If

            '// caso o campo Valor ValorInss não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("ValorInss").Count <= 0 Then
                _infRps.ValorInss = Nothing
            Else
                _infRps.ValorInss = Trim(xmlServico.GetElementsByTagName("ValorInss").Item(0).InnerText.Replace(".", ","))
            End If

            '// caso o campo Valor ValorIr não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("ValorIr").Count <= 0 Then
                _infRps.ValorIr = Nothing
            Else
                _infRps.ValorIr = Trim(xmlServico.GetElementsByTagName("ValorIr").Item(0).InnerText.Replace(".", ","))
            End If

            '// caso o campo Valor ValorCsll não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("ValorCsll").Count <= 0 Then
                _infRps.ValorCsll = Nothing
            Else
                _infRps.ValorCsll = Trim(xmlServico.GetElementsByTagName("ValorCsll").Item(0).InnerText.Replace(".", ","))
            End If

            '// caso o campo Valor IssRetido não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("IssRetido").Count <= 0 Then
                _infRps.IssRetido = Nothing
            Else
                _infRps.IssRetido = Trim(xmlServico.GetElementsByTagName("IssRetido").Item(0).InnerText.Replace(".", ","))
            End If

            '// caso o campo Valor ValorIss não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("ValorIss").Count <= 0 Then
                _infRps.ValorIss = Nothing
            Else
                _infRps.ValorIss = Trim(xmlServico.GetElementsByTagName("ValorIss").Item(0).InnerText.Replace(".", ","))
            End If

            '// caso o campo Valor ValorIss não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("ValorIssRetido").Count <= 0 Then
                _infRps.ValorIssRetido = Nothing
            Else
                _infRps.ValorIssRetido = Trim(xmlServico.GetElementsByTagName("ValorIssRetido").Item(0).InnerText.Replace(".", ","))
            End If


            '// caso o campo Valor OutrasRetencoes não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("OutrasRetencoes").Count <= 0 Then
                _infRps.ValorOutrasRetencoes = Nothing
            Else
                _infRps.ValorOutrasRetencoes = Trim(xmlServico.GetElementsByTagName("OutrasRetencoes").Item(0).InnerText.Replace(".", ","))
            End If

            '// caso o campo Valor BaseCalculo não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("BaseCalculo").Count <= 0 Then
                _infRps.BaseCalculo = Nothing
            Else
                _infRps.BaseCalculo = Trim(xmlServico.GetElementsByTagName("BaseCalculo").Item(0).InnerText.Replace(".", ","))
            End If

            '// caso o campo Valor Aliquota não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("Aliquota").Count <= 0 Then
                _infRps.Aliquota = Nothing
            Else
                _infRps.Aliquota = Trim(xmlServico.GetElementsByTagName("Aliquota").Item(0).InnerText.Replace(".", ","))
                _infRps.Aliquota = CType(_infRps.Aliquota.ToString, Double) * 100
            End If

            '// caso o campo Valor ValorLiquidoNfse não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("ValorLiquidoNfse").Count <= 0 Then
                _infRps.ValorLiquidoNfse = Nothing
            Else
                _infRps.ValorLiquidoNfse = Trim(xmlServico.GetElementsByTagName("ValorLiquidoNfse").Item(0).InnerText.Replace(".", ","))
            End If

            '// caso o campo Valor DescontoIncondicionado não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("DescontoIncondicionado").Count <= 0 Then
                _infRps.DescontoIncodicionado = Nothing
            Else
                _infRps.DescontoIncodicionado = Trim(xmlServico.GetElementsByTagName("DescontoIncondicionado").Item(0).InnerText.Replace(".", ","))
            End If

            '// caso o campo Valor DescontoCondicionado não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("DescontoCondicionado").Count <= 0 Then
                _infRps.DescontoCondicionado = Nothing
            Else
                _infRps.DescontoCondicionado = Trim(xmlServico.GetElementsByTagName("DescontoCondicionado").Item(0).InnerText.Replace(".", ","))
            End If

            '// caso o campo Valor ItemListaServico não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("ItemListaServico").Count <= 0 Then
                _infRps.ItemListaServico = Nothing
            Else
                _infRps.ItemListaServico = Trim(xmlServico.GetElementsByTagName("ItemListaServico").Item(0).InnerText)
            End If

            '// caso o campo Valor CodigoCnae não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("CodigoCnae").Count <= 0 Then
                _infRps.CodigoCnae = dr("CodigoCnae")
            Else
                _infRps.CodigoCnae = Trim(xmlServico.GetElementsByTagName("CodigoCnae").Item(0).InnerText)
            End If


            '// caso o campo Valor DescontoCondicionado não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("CodigoTributacaoMunicipio").Count <= 0 Then
                _infRps.CodTributacaoMunicipal = drParametros("CodigoTributacao")
            Else
                _infRps.CodTributacaoMunicipal = Trim(xmlServico.GetElementsByTagName("CodigoTributacaoMunicipio").Item(0).InnerText)
            End If

            '// caso o campo Valor DescontoCondicionado não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("Discriminacao").Count <= 0 Then
                _infRps.Discriminacao = Nothing
            Else
                _infRps.Discriminacao = Trim(xmlServico.GetElementsByTagName("Discriminacao").Item(0).InnerText)
            End If


            '// caso o campo Valor DescontoCondicionado não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlServico.GetElementsByTagName("CodigoMunicipio").Count <= 0 Then
                _infRps.CodMunicipio = Nothing
            Else
                _infRps.CodMunicipio = Trim(xmlServico.GetElementsByTagName("CodigoMunicipio").Item(0).InnerText)
            End If


            'PRESTADOR DO SERVIÇOS
            _infRps.CnpjPrestador = dr("Cnpj")
            _infRps.InscrMunicipalPrestador = dr("InscricaoMunicipal")

            'TOMADOR DO SERVIÇO
            Dim xmlTomador As XmlElement = TagInfRps.GetElementsByTagName("Tomador").Item(0)

            '// caso o campo Cpf  não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlTomador.GetElementsByTagName("Cpf").Count <= 0 Then
                _infRps.CpfTomador = Nothing
            Else
                _infRps.CpfTomador = Trim(xmlTomador.GetElementsByTagName("Cpf").Item(0).InnerText)
                _infRps.TipoPessoaTomador = xmlNFSe.TipoPessoa.Fisica
            End If

            '// caso o campo Cnpj  não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlTomador.GetElementsByTagName("Cnpj").Count <= 0 Then
                _infRps.CnpjTomador = Nothing
            Else
                _infRps.CnpjTomador = Trim(xmlTomador.GetElementsByTagName("Cnpj").Item(0).InnerText)
                _infRps.TipoPessoaTomador = xmlNFSe.TipoPessoa.Juridica
            End If



            '// caso o campo Cpf  não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlTomador.GetElementsByTagName("InscricaoMunicipal").Count <= 0 Then
                _infRps.InscrMunicipalTomador = Nothing
            Else
                If Trim(xmlTomador.GetElementsByTagName("InscricaoMunicipal").Item(0).InnerText) = "" Then
                    _infRps.InscrMunicipalTomador = Nothing
                Else
                    _infRps.InscrMunicipalTomador = Trim(xmlTomador.GetElementsByTagName("InscricaoMunicipal").Item(0).InnerText)
                End If
            End If

            '// caso o campo RazaoSocial  não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlTomador.GetElementsByTagName("RazaoSocial").Count <= 0 Then
                _infRps.RazaoSocialTomador = Nothing
            Else
                _infRps.RazaoSocialTomador = Trim(xmlTomador.GetElementsByTagName("RazaoSocial").Item(0).InnerText)
            End If

            If xmlTomador.GetElementsByTagName("Endereco").Count > 0 Then
                Dim xmlEnderecoTomador As XmlElement = xmlTomador.GetElementsByTagName("Endereco").Item(0)

                '// caso o campo Endereco não esteja preenchido no XmlAbrasf então joga valor "vazio"
                If xmlEnderecoTomador.GetElementsByTagName("Endereco").Count <= 0 Then
                    _infRps.LogradouroTomador = Nothing
                Else
                    _infRps.LogradouroTomador = Trim(xmlEnderecoTomador.GetElementsByTagName("Endereco").Item(0).InnerText)
                End If

                '// caso o campo Numero não esteja preenchido no XmlAbrasf então joga valor "vazio"
                If xmlEnderecoTomador.GetElementsByTagName("Numero").Count <= 0 Then
                    _infRps.EnderecoNumeroTomador = Nothing
                Else
                    _infRps.EnderecoNumeroTomador = Trim(xmlEnderecoTomador.GetElementsByTagName("Numero").Item(0).InnerText)
                End If

                '// caso o campo Complemento não esteja preenchido no XmlAbrasf então joga valor "vazio"
                If xmlEnderecoTomador.GetElementsByTagName("Complemento").Count <= 0 Then
                    _infRps.EnderecoComplementoTomador = Nothing
                Else
                    _infRps.EnderecoComplementoTomador = Trim(xmlEnderecoTomador.GetElementsByTagName("Complemento").Item(0).InnerText)
                End If

                '// caso o campo Complemento não esteja preenchido no XmlAbrasf então joga valor "vazio"
                If xmlEnderecoTomador.GetElementsByTagName("Bairro").Count <= 0 Then
                    _infRps.BairroTomador = Nothing
                Else
                    _infRps.BairroTomador = Trim(xmlEnderecoTomador.GetElementsByTagName("Bairro").Item(0).InnerText)
                End If

                '// caso o campo CodigoMunicipio não esteja preenchido no XmlAbrasf então joga valor "vazio"
                If xmlEnderecoTomador.GetElementsByTagName("CodigoMunicipio").Count <= 0 Then
                    _infRps.CodMunicipioTomador = Nothing
                Else
                    _infRps.CodMunicipioTomador = Trim(xmlEnderecoTomador.GetElementsByTagName("CodigoMunicipio").Item(0).InnerText)
                End If

                '// caso o campo Uf não esteja preenchido no XmlAbrasf então joga valor "vazio"
                If xmlEnderecoTomador.GetElementsByTagName("Uf").Count <= 0 Then
                    _infRps.UfTomador = Nothing
                Else
                    _infRps.UfTomador = Trim(xmlEnderecoTomador.GetElementsByTagName("Uf").Item(0).InnerText)
                End If

                '// caso o campo Cep não esteja preenchido no XmlAbrasf então joga valor "vazio"
                If xmlEnderecoTomador.GetElementsByTagName("Cep").Count <= 0 Then
                    _infRps.CepTomador = Nothing
                Else
                    _infRps.CepTomador = Trim(xmlEnderecoTomador.GetElementsByTagName("Cep").Item(0).InnerText)
                End If

            Else
                _infRps.LogradouroTomador = Nothing
                _infRps.EnderecoNumeroTomador = Nothing
                _infRps.EnderecoComplementoTomador = Nothing
                _infRps.BairroTomador = Nothing
                _infRps.CodMunicipioTomador = Nothing
                _infRps.UfTomador = Nothing
                _infRps.CepTomador = Nothing
                _infRps.EmailTomador = Nothing
                _infRps.TelefoneTomador = Nothing
            End If

            '// caso o campo Telefone não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlTomador.GetElementsByTagName("Email").Count <= 0 Then
                _infRps.EmailTomador = Nothing
            Else
                _infRps.EmailTomador = Trim(xmlTomador.GetElementsByTagName("Email").Item(0).InnerText)
            End If

            '// caso o campo Telefone não esteja preenchido no XmlAbrasf então joga valor "vazio"
            If xmlTomador.GetElementsByTagName("Telefone").Count <= 0 Then
                _infRps.TelefoneTomador = Nothing
            Else
                _infRps.TelefoneTomador = Trim(xmlTomador.GetElementsByTagName("Telefone").Item(0).InnerText)
            End If



            'INTERMEDIARIO SERVIÇO

            If TagInfRps.GetElementsByTagName("IntermediarioServico").Count > 0 Then

                Dim xmlIntermediario As XmlElement = TagInfRps.GetElementsByTagName("IntermediarioServico").Item(0)

                '// caso o campo RazaoSocial não esteja preenchido no XmlAbrasf então joga valor "vazio"
                If xmlIntermediario.GetElementsByTagName("RazaoSocial").Count <= 0 Then
                    _infRps.RazaoSocialIntermediario = Nothing
                Else
                    _infRps.RazaoSocialIntermediario = Trim(xmlIntermediario.GetElementsByTagName("RazaoSocial").Item(0).InnerText)
                End If

                '// caso o campo Cpf não esteja preenchido no XmlAbrasf então joga valor "vazio"
                If xmlIntermediario.GetElementsByTagName("Cpf").Count <= 0 Then
                    _infRps.CpfIntermediario = Nothing
                Else
                    _infRps.CpfIntermediario = Trim(xmlIntermediario.GetElementsByTagName("Cpf").Item(0).InnerText)
                    _infRps.TipoPessoaIntermediario = xmlNFSe.TipoPessoa.Fisica

                End If

                '// caso o campo Cnpj não esteja preenchido no XmlAbrasf então joga valor "vazio"
                If xmlIntermediario.GetElementsByTagName("Cnpj").Count <= 0 Then
                    _infRps.CnpjIntermediario = Nothing
                Else
                    _infRps.CnpjIntermediario = Trim(xmlIntermediario.GetElementsByTagName("Cnpj").Item(0).InnerText)
                    _infRps.TipoPessoaIntermediario = xmlNFSe.TipoPessoa.Juridica
                End If

                '// caso o campo InscricaoMunicipal não esteja preenchido no XmlAbrasf então joga valor "vazio"
                If xmlIntermediario.GetElementsByTagName("InscricaoMunicipal").Count <= 0 Then
                    _infRps.InscrMunicipalIntermediario = Nothing
                Else
                    If Trim(xmlIntermediario.GetElementsByTagName("InscricaoMunicipal").Item(0).InnerText) = "" Then
                        _infRps.InscrMunicipalIntermediario = Nothing
                    Else
                        _infRps.InscrMunicipalIntermediario = Trim(xmlIntermediario.GetElementsByTagName("InscricaoMunicipal").Item(0).InnerText)
                    End If
                End If

            Else
                _infRps.RazaoSocialIntermediario = Nothing
                _infRps.TipoPessoaIntermediario = Nothing
                _infRps.CpfIntermediario = Nothing
                _infRps.CnpjIntermediario = Nothing
                _infRps.InscrMunicipalIntermediario = Nothing
            End If



            'CONSTRUÇÃO CIVIL
            If TagInfRps.GetElementsByTagName("ConstrucaoCivil").Count > 0 Then
                Dim xmlConstrucaoCivil As XmlElement = TagInfRps.GetElementsByTagName("ConstrucaoCivil").Item(0)

                '// caso o campo CodigoObra não esteja preenchido no XmlAbrasf então joga valor "vazio"
                If xmlConstrucaoCivil.GetElementsByTagName("CodigoObra").Count <= 0 Then
                    _infRps.CodObra = Nothing
                Else
                    _infRps.CodObra = Trim(xmlConstrucaoCivil.GetElementsByTagName("CodigoObra").Item(0).InnerText)
                End If

                '// caso o campo Art não esteja preenchido no XmlAbrasf então joga valor "vazio"
                If xmlConstrucaoCivil.GetElementsByTagName("Art").Count <= 0 Then
                    _infRps.Art = Nothing
                Else
                    _infRps.Art = Trim(xmlConstrucaoCivil.GetElementsByTagName("Art").Item(0).InnerText)
                End If

            Else
                _infRps.CodObra = Nothing
                _infRps.Art = Nothing
            End If


            'Adiciona na lista de Rps
            ListaRps.Add(_infRps)

        Next

    End Sub

    'Gera o lote de acordo com o municipio de emissão
    'Utiliza a Dll xmlNfse para gerar e assinar o lote
    Private Sub GerarLoteRps()

        Dim objXML As New xmlNFSe.xmlNFSe
        Dim lRps As xmlNFSe.InfRps

        objXML.Assinardocumento = True 'Indica se é ou não para assinar o lote

        'Dados do cabeçalho do lote
        objXML.infNFSe.Ambiente = AmbienteWebService
        objXML.infNFSe.MunicipioDeEmissao = MunicipioEmissao
        objXML.infNFSe.Emit.xRazaoSocial = InformacoesLote.RazoSocialEmitente.ToString
        objXML.infNFSe.numLote = InformacoesLote.NumLote.ToString
        objXML.infNFSe.Emit.cnpj = InformacoesLote.CnpjEmitente.ToString
        objXML.infNFSe.Emit.inscrMunicipal = InformacoesLote.InscrMunicipalEmitente.ToString
        objXML.infNFSe.qutRps = InformacoesLote.QutRps.ToString

        'Faz um loop pela lista de Rps
        For Each _infRps As InfRps In ListaRps

            lRps = New xmlNFSe.InfRps

            'IDENTIFICAÇÃO E DADOS DO RPS
            If IsNothing(_infRps.NumeroRps) = False Then lRps.numero = _infRps.NumeroRps.ToString
            If IsNothing(_infRps.SerieRps) = False Then lRps.serie = _infRps.SerieRps.ToString
            If IsNothing(_infRps.TipoRps) = False Then lRps.tipo = _infRps.TipoRps
            If IsNothing(_infRps.DataEmissao) = False Then lRps.dataEmissao = _infRps.DataEmissao.ToString
            If IsNothing(_infRps.NatOperacao) = False Then lRps.natOperacao = _infRps.NatOperacao
            If IsNothing(_infRps.RegEspTributacao) = False Then lRps.regEspTributacao = _infRps.RegEspTributacao
            If IsNothing(_infRps.OptSimplesNacional) = False Then lRps.optSimpNacional = _infRps.OptSimplesNacional
            If IsNothing(_infRps.IncentCultural) = False Then lRps.incentCultural = _infRps.IncentCultural
            If IsNothing(_infRps.StatusRps) = False Then lRps.status = _infRps.StatusRps

            'RSP SUBSTITUIDO
            If IsNothing(_infRps.RpsSubstituido) = False Then lRps.rpsSubstituido = _infRps.RpsSubstituido
            If IsNothing(_infRps.NumeroRpsSubstituido) = False Then lRps.numeroRpsSubstituido = _infRps.NumeroRpsSubstituido.ToString
            If IsNothing(_infRps.SerieRpsSubstituido) = False Then lRps.serieRpsSubstituido = _infRps.SerieRpsSubstituido.ToString
            If IsNothing(_infRps.TipoRpsSubstituido) = False Then lRps.tipoRpsSubstituido = _infRps.TipoRpsSubstituido

            'SERVIÇO
            If IsNothing(_infRps.ValorServicos) = False Then lRps.servico.valorServicos = _infRps.ValorServicos.ToString
            If IsNothing(_infRps.ValorDeducoes) = False Then lRps.servico.valorDeducoes = _infRps.ValorDeducoes.ToString
            If IsNothing(_infRps.ValorPis) = False Then lRps.servico.valorPis = _infRps.ValorPis.ToString
            If IsNothing(_infRps.ValorCofins) = False Then lRps.servico.valorCofins = _infRps.ValorCofins.ToString
            If IsNothing(_infRps.ValorInss) = False Then lRps.servico.valorInss = _infRps.ValorInss.ToString
            If IsNothing(_infRps.ValorIr) = False Then lRps.servico.valorIr = _infRps.ValorIr.ToString
            If IsNothing(_infRps.ValorCsll) = False Then lRps.servico.valorCsll = _infRps.ValorCsll.ToString
            If IsNothing(_infRps.IssRetido) = False Then lRps.servico.issRetido = _infRps.IssRetido
            If IsNothing(_infRps.ValorIss) = False Then lRps.servico.valorIss = _infRps.ValorIss.ToString
            If IsNothing(_infRps.ValorOutrasRetencoes) = False Then lRps.servico.outrasRetencoes = _infRps.ValorOutrasRetencoes.ToString
            If IsNothing(_infRps.BaseCalculo) = False Then lRps.servico.baseCalculo = _infRps.BaseCalculo.ToString
            If IsNothing(_infRps.Aliquota) = False Then lRps.servico.aliquota = _infRps.Aliquota.ToString
            If IsNothing(_infRps.ValorLiquidoNfse) = False Then lRps.servico.valorLiquidoNfse = _infRps.ValorLiquidoNfse.ToString
            If IsNothing(_infRps.ValorIssRetido) = False Then lRps.servico.valorIssRetido = _infRps.ValorIssRetido.ToString
            If IsNothing(_infRps.DescontoIncodicionado) = False Then lRps.servico.descontoIncondicionado = _infRps.DescontoIncodicionado.ToString
            If IsNothing(_infRps.DescontoCondicionado) = False Then lRps.servico.descontoCondicionado = _infRps.DescontoCondicionado.ToString
            If IsNothing(_infRps.ItemListaServico) = False Then lRps.servico.itemListaServico = _infRps.ItemListaServico.ToString
            If IsNothing(_infRps.CodigoCnae) = False Then lRps.servico.codigoCnae = _infRps.CodigoCnae.ToString
            If IsNothing(_infRps.CodTributacaoMunicipal) = False Then lRps.servico.codTributacaoMunicipal = _infRps.CodTributacaoMunicipal.ToString
            If IsNothing(_infRps.Discriminacao) = False Then lRps.servico.discriminacao = _infRps.Discriminacao.ToString
            If IsNothing(_infRps.CodMunicipio) = False Then lRps.servico.codMunicipio = _infRps.CodMunicipio.ToString

            'PRESTADOR
            lRps.prestadorServico.cnpj = _infRps.CnpjPrestador.ToString
            lRps.prestadorServico.inscrMunicipal = _infRps.InscrMunicipalPrestador.ToString


            'TOMADOR SERVIÇO
            lRps.tomadorServico.tipoPessoa = _infRps.TipoPessoaTomador
            If _infRps.TipoPessoaTomador = xmlNFSe.TipoPessoa.Juridica Then
                If IsNothing(_infRps.CnpjTomador) = False Then lRps.tomadorServico.cnpj = _infRps.CnpjTomador.ToString
                If IsNothing(_infRps.InscrMunicipalTomador) = False Then lRps.tomadorServico.inscrMunicipal = _infRps.InscrMunicipalTomador.ToString
            Else
                If IsNothing(_infRps.CpfTomador) = False Then lRps.tomadorServico.cpf = _infRps.CpfTomador.ToString
            End If

            If IsNothing(_infRps.RazaoSocialTomador) = False Then lRps.tomadorServico.razaoSocial = _infRps.RazaoSocialTomador.ToString
            If IsNothing(_infRps.LogradouroTomador) = False Then lRps.tomadorServico.enderecoTomador.logradouro = _infRps.LogradouroTomador.ToString
            If IsNothing(_infRps.EnderecoNumeroTomador) = False Then lRps.tomadorServico.enderecoTomador.numero = _infRps.EnderecoNumeroTomador.ToString
            If IsNothing(_infRps.EnderecoComplementoTomador) = False Then lRps.tomadorServico.enderecoTomador.complemento = _infRps.EnderecoComplementoTomador.ToString
            If IsNothing(_infRps.BairroTomador) = False Then lRps.tomadorServico.enderecoTomador.bairro = _infRps.BairroTomador.ToString
            If IsNothing(_infRps.CodMunicipioTomador) = False Then lRps.tomadorServico.enderecoTomador.codMunicipio = _infRps.CodMunicipioTomador.ToString
            If IsNothing(_infRps.UfTomador) = False Then lRps.tomadorServico.enderecoTomador.uf = _infRps.UfTomador.ToString
            If IsNothing(_infRps.CepTomador) = False Then lRps.tomadorServico.enderecoTomador.cep = _infRps.CepTomador.ToString
            If IsNothing(_infRps.EmailTomador) = False Then lRps.tomadorServico.emailContato = _infRps.EmailTomador.ToString
            If IsNothing(_infRps.TelefoneTomador) = False Then lRps.tomadorServico.telefoneContato = _infRps.TelefoneTomador.ToString


            'INTERMEDIARIO SERVIÇO
            If IsNothing(_infRps.RazaoSocialIntermediario) = False Then lRps.intermediarioServico.razaoSocial = _infRps.RazaoSocialIntermediario.ToString
            If IsNothing(_infRps.TipoPessoaIntermediario) = False Then lRps.intermediarioServico.tipoPessoa = _infRps.TipoPessoaIntermediario

            If _infRps.TipoPessoaIntermediario = xmlNFSe.TipoPessoa.Juridica Then
                If IsNothing(_infRps.CnpjIntermediario) = False Then lRps.intermediarioServico.cnpj = _infRps.CnpjIntermediario.ToString
                If IsNothing(_infRps.InscrMunicipalIntermediario) = False Then lRps.intermediarioServico.inscrMunicipal = _infRps.InscrMunicipalIntermediario.ToString
            Else
                If IsNothing(_infRps.CpfIntermediario) = False Then lRps.intermediarioServico.cpf = _infRps.CpfIntermediario.ToString
            End If


            'CONSTRUÇÃO CIVIL
            If IsNothing(_infRps.CodObra) = False Then lRps.construcaoCivil.codObra = _infRps.CodObra.ToString
            If IsNothing(_infRps.Art) = False Then lRps.construcaoCivil.art = _infRps.Art.ToString


            objXML.incluirNaListaRps(lRps)
        Next

        Try

        Catch ex As Exception

        End Try
        'Utiliza a Dll XmlNfse para Criar/assinar o lote e salvar no diretório
        objXML.GerarXmlLoteRps(objXML, FileNameXmlAbrasf, UtilizarForm, SerieCertificado)

    End Sub
#End Region

End Class
