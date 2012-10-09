Imports Microsoft.Reporting
Imports Microsoft.Reporting.WinForms
Imports System.Xml
Imports System.IO
Imports System.Net.Mail

Public Class frmImpressaoNfse
#Region "Variáveis"

    Private XmlNfse As XmlDocument
    Dim xmlInfNfse As XmlElement
    Dim xmlIdRps As XmlElement
    Dim xmlServico As XmlElement
    Dim xmlPrestador As XmlElement
    Dim xmlValorServico As XmlElement
    Dim xmlTomador As XmlElement
    Dim xmlTomadorEndereco As XmlElement
    Dim xmlIntermediario As XmlElement
    Dim xmlConstrucaoCivil As XmlElement
    Dim xmlOrgaoGerador As XmlElement

#End Region

#Region "Construtor"
    Public Sub New(ByVal xml As XmlDocument)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        XmlNfse = New XmlDocument
        XmlNfse = xml
    End Sub
#End Region

#Region "Métodos privados"

    Private Sub frmImpressaoNfse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Definir como visualização de leitura como padrão
        Relatorio.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

        'Definindo ZOOM de 150% como padrão
        Relatorio.ZoomMode = ZoomMode.PageWidth

        'Habilitando imagens externas no relatório
        Relatorio.LocalReport.EnableExternalImages = True

        'vincula os parâmentos no relatório
        VincularParametros()

    End Sub

    Private Sub VincularParametros()

        Try


            xmlInfNfse = XmlNfse.GetElementsByTagName("Nfse").Item(0)
            xmlIdRps = XmlNfse.GetElementsByTagName("IdentificacaoRps").Item(0)
            xmlServico = XmlNfse.GetElementsByTagName("Servico").Item(0)
            xmlValorServico = xmlServico.GetElementsByTagName("Valores").Item(0)
            xmlPrestador = XmlNfse.GetElementsByTagName("PrestadorServico").Item(0)
            xmlTomador = XmlNfse.GetElementsByTagName("TomadorServico").Item(0)
            xmlTomadorEndereco = xmlTomador.GetElementsByTagName("Endereco").Item(0)

            If XmlNfse.GetElementsByTagName("IntermediarioServico").Count > 0 Then
                xmlIntermediario = XmlNfse.GetElementsByTagName("IntermediarioServico").Item(0)
            End If

            If XmlNfse.GetElementsByTagName("ConstrucaoCivil").Count > 0 Then
                xmlConstrucaoCivil = XmlNfse.GetElementsByTagName("ConstrucaoCivil").Item(0)
            End If

            If XmlNfse.GetElementsByTagName("OrgaoGerador").Count > 0 Then
                xmlOrgaoGerador = XmlNfse.GetElementsByTagName("OrgaoGerador").Item(0)
            End If

            Dim conBd As New ConexaoBd
            Dim SqlConsultar As String = "Select * from tb_CadEmpresa"
            Dim dt As DataTable = conBd.Consultar(SqlConsultar, "tb_CadEmpresa")


            Dim dr As DataRow = dt.Rows(0)

            Dim Parametro As ReportParameter() = New ReportParameter(51) {}

            Parametro(0) = New ReportParameter("NumeroNfs", xmlInfNfse.GetElementsByTagName("Numero").Item(0).InnerText)
            Parametro(1) = New ReportParameter("DtEmissao", xmlInfNfse.GetElementsByTagName("DataEmissao").Item(0).InnerText)
            Parametro(2) = New ReportParameter("DtCompetencia", xmlInfNfse.GetElementsByTagName("Competencia").Item(0).InnerText)
            Parametro(3) = New ReportParameter("CodigoVerificacao", xmlInfNfse.GetElementsByTagName("CodigoVerificacao").Item(0).InnerText)

            ''Informações do Prestador de serviço sendo retidadas do cadastro da empresa
            Parametro(4) = New ReportParameter("PrestadorRazaoSocial", dr("RazaoSocial").ToString())
            Parametro(5) = New ReportParameter("PrestadorCpfCnpj", dr("Cnpj").ToString())
            Parametro(6) = New ReportParameter("PrestadorInscricaoMunicipal", dr("InscricaoMunicipal").ToString())
            Parametro(7) = New ReportParameter("PrestadorCep", dr("Cep").ToString())
            Parametro(8) = New ReportParameter("PrestadorEmail", dr("Email").ToString())
            Parametro(9) = New ReportParameter("PrestadorCidade", dr("Cidade").ToString())
            Parametro(10) = New ReportParameter("PrestadorUf", dr("Uf").ToString())
            Parametro(11) = New ReportParameter("PrestadorTelefone", dr("Telefone").ToString())
            Parametro(12) = New ReportParameter("PrestadorEndereco", dr("Logradouro").ToString() & ", " & dr("Numero").ToString() & ", " & dr("Complemento").ToString() & ", " & dr("Bairro").ToString())

            'Informações do Tomador de serviço
            Parametro(13) = New ReportParameter("TomadorRazaoSocial", xmlTomador.GetElementsByTagName("RazaoSocial").Item(0).InnerText)

            ''Formata CPF e CNPJ
            Dim cpfCnpjTomador, NovoCpfCnpjTomador As String

            If xmlTomador.GetElementsByTagName("Cnpj").Count > 0 Then
                cpfCnpjTomador = xmlTomador.GetElementsByTagName("Cnpj").Item(0).InnerText
                cpfCnpjTomador = cpfCnpjTomador.Replace(".", "")
                cpfCnpjTomador = cpfCnpjTomador.Replace("/", "")
                cpfCnpjTomador = cpfCnpjTomador.Replace("-", "")
                NovoCpfCnpjTomador = cpfCnpjTomador.Substring(0, 2)
                NovoCpfCnpjTomador = NovoCpfCnpjTomador + "."
                NovoCpfCnpjTomador = NovoCpfCnpjTomador + cpfCnpjTomador.Substring(2, 3)
                NovoCpfCnpjTomador = NovoCpfCnpjTomador + "."
                NovoCpfCnpjTomador = NovoCpfCnpjTomador + cpfCnpjTomador.Substring(5, 3)
                NovoCpfCnpjTomador = NovoCpfCnpjTomador + "/"
                NovoCpfCnpjTomador = NovoCpfCnpjTomador + cpfCnpjTomador.Substring(8, 4)
                NovoCpfCnpjTomador = NovoCpfCnpjTomador + "-"
                NovoCpfCnpjTomador = NovoCpfCnpjTomador + cpfCnpjTomador.Substring(12)

            Else
                cpfCnpjTomador = xmlTomador.GetElementsByTagName("Cpf").Item(0).InnerText
                cpfCnpjTomador = cpfCnpjTomador.Replace(".", "")
                cpfCnpjTomador = cpfCnpjTomador.Replace("-", "")
                NovoCpfCnpjTomador = cpfCnpjTomador.Substring(0, 3)
                NovoCpfCnpjTomador = NovoCpfCnpjTomador + "."
                NovoCpfCnpjTomador = NovoCpfCnpjTomador + cpfCnpjTomador.Substring(3, 3)
                NovoCpfCnpjTomador = NovoCpfCnpjTomador + "."
                NovoCpfCnpjTomador = NovoCpfCnpjTomador + cpfCnpjTomador.Substring(6, 3)
                NovoCpfCnpjTomador = NovoCpfCnpjTomador + "-"
                NovoCpfCnpjTomador = NovoCpfCnpjTomador + cpfCnpjTomador.Substring(9)

            End If

            Parametro(14) = New ReportParameter("TomadorCpfCnpj", NovoCpfCnpjTomador)


            'INFORMAÇÕES DO TOMADOR
            Dim Endereco, Numero, Complemento As String

            If xmlTomadorEndereco.GetElementsByTagName("Endereco").Count > 0 Then
                Endereco = xmlTomadorEndereco.GetElementsByTagName("Endereco").Item(0).InnerText & ","
            Else
                Endereco = ""
            End If

            If xmlTomadorEndereco.GetElementsByTagName("Numero").Count > 0 Then
                Numero = xmlTomadorEndereco.GetElementsByTagName("Numero").Item(0).InnerText & ","
            Else
                Numero = ""
            End If

            If xmlTomadorEndereco.GetElementsByTagName("Complemento").Count > 0 Then
                Complemento = xmlTomadorEndereco.GetElementsByTagName("Complemento").Item(0).InnerText
            Else
                Complemento = ""
            End If

            If xmlTomador.GetElementsByTagName("Endereco").Count > 0 Then
                Parametro(15) = New ReportParameter("TomadorEndereco", Endereco & " " & Numero & " " & Complemento)
            Else
                Parametro(15) = New ReportParameter("TomadorEndereco", "")
            End If

            Parametro(16) = New ReportParameter("TomadorCep", xmlTomadorEndereco.GetElementsByTagName("Cep").Item(0).InnerText)

            If xmlTomador.GetElementsByTagName("Telefone").Count > 0 Then
                Parametro(17) = New ReportParameter("TomadorTelefone", xmlTomador.GetElementsByTagName("Telefone").Item(0).InnerText)
            Else
                Parametro(17) = New ReportParameter("TomadorTelefone", "")
            End If

            If xmlTomador.GetElementsByTagName("Email").Count > 0 Then
                Parametro(17) = New ReportParameter("TomadorEmail", xmlTomador.GetElementsByTagName("Email").Item(0).InnerText)
            Else
                Parametro(17) = New ReportParameter("TomadorEmail", "")
            End If

            If xmlTomador.GetElementsByTagName("InscricaoMunicipal").Count > 0 Then
                Parametro(17) = New ReportParameter("TomadorInscricaoMunicipal", xmlTomador.GetElementsByTagName("InscricaoMunicipal").Item(0).InnerText)
            Else
                Parametro(17) = New ReportParameter("TomadorInscricaoMunicipal", "")
            End If

            If xmlTomador.GetElementsByTagName("Uf").Count > 0 Then
                Parametro(18) = New ReportParameter("TomadorUf", xmlTomador.GetElementsByTagName("Uf").Item(0).InnerText)
            Else
                Parametro(18) = New ReportParameter("TomadorUf", "")
            End If

            SqlConsultar = "Select Municipio from tb_Municipio where CodigoMunicipio = '" & xmlTomadorEndereco.GetElementsByTagName("CodigoMunicipio").Item(0).InnerText & "'"
            Dim dtMunicipio As DataTable = conBd.Consultar(SqlConsultar, "tb_CadEmpresa")
            Parametro(19) = New ReportParameter("TomadorCidade", dtMunicipio.Rows(0).Item("Municipio").ToString())

            If xmlTomador.GetElementsByTagName("Email").Count > 0 Then
                Parametro(20) = New ReportParameter("TomadorEmail", xmlTomador.GetElementsByTagName("Email").Item(0).InnerText)
            Else
                Parametro(20) = New ReportParameter("TomadorEmail", "")
            End If

            If xmlTomador.GetElementsByTagName("Complemento").Count > 0 Then
                Parametro(21) = New ReportParameter("TomadorComplemento", xmlTomador.GetElementsByTagName("Complemento").Item(0).InnerText)
            Else
                Parametro(21) = New ReportParameter("TomadorComplemento", "")
            End If

            If xmlServico.GetElementsByTagName("Discriminacao").Count > 0 Then
                Parametro(22) = New ReportParameter("NfsDescriminacaoServico", xmlServico.GetElementsByTagName("Discriminacao").Item(0).InnerText)
            Else
                Parametro(22) = New ReportParameter("NfsDescriminacaoServico", "")
            End If

            'INICIO DE PREENCHIMENTO DE INFORMAÇÕES DO INTERMEDIARIO
            If XmlNfse.GetElementsByTagName("IntermediarioServico").Count > 0 Then
                If xmlIntermediario.GetElementsByTagName("RazaoSocial").Count > 0 Then
                    Parametro(23) = New ReportParameter("IntermediarioRazaoSocial", xmlIntermediario.GetElementsByTagName("RazaoSocial").Item(0).InnerText)
                Else
                    Parametro(23) = New ReportParameter("IntermediarioRazaoSocial", "")
                End If

                ''Formata CPF e CNPJ
                Dim cpfCnpjIntermediario, NovoCpfCnpjIntermediario As String

                If xmlIntermediario.GetElementsByTagName("Cnpj").Count > 0 Then
                    cpfCnpjIntermediario = xmlIntermediario.GetElementsByTagName("Cnpj").Item(0).InnerText
                    cpfCnpjIntermediario = cpfCnpjIntermediario.Replace(".", "")
                    cpfCnpjIntermediario = cpfCnpjIntermediario.Replace("/", "")
                    cpfCnpjIntermediario = cpfCnpjIntermediario.Replace("-", "")
                    NovoCpfCnpjIntermediario = cpfCnpjIntermediario.Substring(0, 2)
                    NovoCpfCnpjIntermediario = NovoCpfCnpjIntermediario + "."
                    NovoCpfCnpjIntermediario = NovoCpfCnpjIntermediario + cpfCnpjIntermediario.Substring(2, 3)
                    NovoCpfCnpjIntermediario = NovoCpfCnpjIntermediario + "."
                    NovoCpfCnpjIntermediario = NovoCpfCnpjIntermediario + cpfCnpjIntermediario.Substring(5, 3)
                    NovoCpfCnpjIntermediario = NovoCpfCnpjIntermediario + "/"
                    NovoCpfCnpjIntermediario = NovoCpfCnpjIntermediario + cpfCnpjIntermediario.Substring(8, 4)
                    NovoCpfCnpjIntermediario = NovoCpfCnpjIntermediario + "-"
                    NovoCpfCnpjIntermediario = NovoCpfCnpjIntermediario + cpfCnpjIntermediario.Substring(12)

                ElseIf xmlIntermediario.GetElementsByTagName("Cpf").Count > 0 Then
                    cpfCnpjIntermediario = xmlIntermediario.GetElementsByTagName("Cpf").Item(0).InnerText
                    cpfCnpjIntermediario = cpfCnpjIntermediario.Replace(".", "")
                    cpfCnpjIntermediario = cpfCnpjIntermediario.Replace("-", "")
                    NovoCpfCnpjIntermediario = cpfCnpjIntermediario.Substring(0, 3)
                    NovoCpfCnpjIntermediario = NovoCpfCnpjIntermediario + "."
                    NovoCpfCnpjIntermediario = NovoCpfCnpjIntermediario + cpfCnpjIntermediario.Substring(3, 3)
                    NovoCpfCnpjIntermediario = NovoCpfCnpjIntermediario + "."
                    NovoCpfCnpjIntermediario = NovoCpfCnpjIntermediario + cpfCnpjIntermediario.Substring(6, 3)
                    NovoCpfCnpjIntermediario = NovoCpfCnpjIntermediario + "-"
                    NovoCpfCnpjIntermediario = NovoCpfCnpjIntermediario + cpfCnpjIntermediario.Substring(9)
                Else
                    NovoCpfCnpjIntermediario = ""
                End If

                Parametro(24) = New ReportParameter("IntermediarioCpfCnpj", NovoCpfCnpjIntermediario)


                If xmlIntermediario.GetElementsByTagName("InscricaoMunicipal").Count > 0 Then
                    Parametro(25) = New ReportParameter("IntermediarioInscricaoMunicipal", xmlIntermediario.GetElementsByTagName("InscricaoMunicipal").Item(0).InnerText)
                Else
                    Parametro(25) = New ReportParameter("IntermediarioInscricaoMunicipal", "")
                End If
            Else
                Parametro(23) = New ReportParameter("IntermediarioRazaoSocial", "")
                Parametro(24) = New ReportParameter("IntermediarioCpfCnpj", "")
                Parametro(25) = New ReportParameter("IntermediarioInscricaoMunicipal", "")
            End If
            'FIM DE PREENCHIMENTO DE INFORMAÇÕES DO INTERMEDIARIO

            'INICIO INFORMAÇÕES CONSTRUCAO CIVIL
            If XmlNfse.GetElementsByTagName("ConstrucaoCivil").Count > 0 Then
                If xmlConstrucaoCivil.GetElementsByTagName("CodigoObra").Count > 0 Then
                    Parametro(26) = New ReportParameter("ObraCodigo", xmlConstrucaoCivil.GetElementsByTagName("CodigoObra").Item(0).InnerText)
                Else
                    Parametro(26) = New ReportParameter("ObraCodigo", "")
                End If

                If xmlConstrucaoCivil.GetElementsByTagName("Art").Count > 0 Then
                    Parametro(27) = New ReportParameter("ObraArt", xmlConstrucaoCivil.GetElementsByTagName("Art").Item(0).InnerText)
                Else
                    Parametro(27) = New ReportParameter("ObraArt", "")
                End If
            Else
                Parametro(26) = New ReportParameter("ObraCodigo", "")
                Parametro(27) = New ReportParameter("ObraArt", "")
            End If
            'FIM INFORMAÇÕES CONSTRUCAO CIVIL


            'INICIO OUTRAS INFORMACOES
            Dim numeroRps, serie, tipo As String

            numeroRps = xmlIdRps.GetElementsByTagName("Numero").Item(0).InnerText
            serie = xmlIdRps.GetElementsByTagName("Serie").Item(0).InnerText
            tipo = xmlIdRps.GetElementsByTagName("Tipo").Item(0).InnerText


            If XmlNfse.GetElementsByTagName("OutrasInformacoes").Count > 0 Then
                Parametro(28) = New ReportParameter("OutrasInformacoes", "RPS:" & numeroRps & " Série:" & serie & " Tipo:" & tipo & " | " & XmlNfse.GetElementsByTagName("OutrasInformacoes").Item(0).InnerText)
            Else
                Parametro(28) = New ReportParameter("OutrasInformacoes", "RPS:" & numeroRps & " Série:" & serie & " Tipo:" & tipo & " |")
            End If
            'FIM OUTRAS INFORMACOES


            If xmlServico.GetElementsByTagName("DescontoCondicionado").Count > 0 Then
                Parametro(29) = New ReportParameter("ValorDesconto", FormatCurrency(XmlNfse.GetElementsByTagName("DescontoCondicionado").Item(0).InnerText.Replace(".", ",")))
            Else
                Parametro(29) = New ReportParameter("ValorDesconto", "R$ 0,00")
            End If

            'PREENCHIMENTO DOS VALORES DA NFSE

            'SOMANDO VALORES PARA OBTER AS RETENÇÕES FEDERAIS
            Dim pis, cofins, csll, irrf, inss, RetencoesFederais As Decimal

            If xmlValorServico.GetElementsByTagName("ValorPis").Count > 0 Then
                pis = FormatCurrency(Replace(xmlValorServico.GetElementsByTagName("ValorPis").Item(0).InnerText, ".", ","), 2)
            End If

            If xmlValorServico.GetElementsByTagName("ValorCofins").Count > 0 Then
                cofins = FormatCurrency(Replace(xmlValorServico.GetElementsByTagName("ValorCofins").Item(0).InnerText, ".", ","), 2)
            End If

            If xmlValorServico.GetElementsByTagName("ValorCsll").Count > 0 Then
                csll = FormatCurrency(Replace(xmlValorServico.GetElementsByTagName("ValorCsll").Item(0).InnerText, ".", ","), 2)
            End If

            If xmlValorServico.GetElementsByTagName("ValorIr").Count > 0 Then
                irrf = FormatCurrency(Replace(xmlValorServico.GetElementsByTagName("ValorIr").Item(0).InnerText, ".", ","), 2)
            End If

            If xmlValorServico.GetElementsByTagName("ValorInss").Count > 0 Then
                inss = FormatCurrency(Replace(xmlValorServico.GetElementsByTagName("ValorInss").Item(0).InnerText, ".", ","), 2)
            End If
            RetencoesFederais = pis + cofins + csll + irrf
            Parametro(30) = New ReportParameter("ValorRetencoesFederais", "R$ " & RetencoesFederais)

            If xmlValorServico.GetElementsByTagName("ValorIssRetido").Count > 0 Then
                Parametro(31) = New ReportParameter("ValorIssRetidoNaFonte", FormatCurrency(xmlValorServico.GetElementsByTagName("ValorIssRetido").Item(0).InnerText.Replace(".", ",")))
            Else
                Parametro(31) = New ReportParameter("ValorIssRetidoNaFonte", "R$ 0,00")
            End If

            Parametro(32) = New ReportParameter("ValorLiquido", FormatCurrency(xmlValorServico.GetElementsByTagName("ValorLiquidoNfse").Item(0).InnerText.Replace(".", ",")))

            If xmlValorServico.GetElementsByTagName("ValorDeducoes").Count > 0 Then
                Parametro(33) = New ReportParameter("ValorDeducoes", FormatCurrency(xmlValorServico.GetElementsByTagName("ValorDeducoes").Item(0).InnerText.Replace(".", ",")))
            Else
                Parametro(33) = New ReportParameter("ValorDeducoes", "R$ 0,00")
            End If

            If xmlValorServico.GetElementsByTagName("DescontoIncondicionado").Count > 0 Then
                Parametro(34) = New ReportParameter("ValorDescontoIncondicionado", FormatCurrency(xmlValorServico.GetElementsByTagName("DescontoIncondicionado").Item(0).InnerText.Replace(".", ",")))
            Else
                Parametro(34) = New ReportParameter("ValorDescontoIncondicionado", "R$ 0,00")
            End If

            Parametro(35) = New ReportParameter("ValorBaseDeCalculo", FormatCurrency(xmlValorServico.GetElementsByTagName("BaseCalculo").Item(0).InnerText.Replace(".", ",")))

            If xmlValorServico.GetElementsByTagName("Aliquota").Count > 0 Then
                Dim SAliquotaIss As String
                Dim AliquotaIss As Decimal
                SAliquotaIss = xmlValorServico.GetElementsByTagName("Aliquota").Item(0).InnerText
                AliquotaIss = Convert.ToDecimal(SAliquotaIss)
                Parametro(36) = New ReportParameter("ValorAliquota", "% " & AliquotaIss)
            Else
                Parametro(36) = New ReportParameter("ValorAliquota", "")
            End If

            If xmlValorServico.GetElementsByTagName("ValorIss").Count > 0 Then
                Parametro(37) = New ReportParameter("ValorDoIss", FormatCurrency(xmlValorServico.GetElementsByTagName("ValorIss").Item(0).InnerText.Replace(".", ",")))
            Else
                Parametro(37) = New ReportParameter("ValorDoIss", "R$ " & "0")
            End If
            If xmlServico.GetElementsByTagName("CodigoTributacaoMunicipio").Count > 0 Then
                Parametro(38) = New ReportParameter("CtIssCodigo", xmlServico.GetElementsByTagName("CodigoTributacaoMunicipio").Item(0).InnerText)
                Dim SqlConsultarTributacaoMunicipio As String = "Select * from tb_TributacaoMunicipio where Codigo = '" & xmlServico.GetElementsByTagName("CodigoTributacaoMunicipio").Item(0).InnerText & "'"
                Dim dtTributacaoMunicipio As DataTable = conBd.Consultar(SqlConsultarTributacaoMunicipio, "tb_TributacaoMunicipio")
                Parametro(39) = New ReportParameter("CtIssDescricao", dtTributacaoMunicipio.Rows(0).Item("Descricao").ToString())
            Else
                Parametro(38) = New ReportParameter("CtIssCodigo", "")
                Parametro(39) = New ReportParameter("CtIssDescricao", "")

            End If

            Parametro(40) = New ReportParameter("SubItemCodigo", xmlServico.GetElementsByTagName("ItemListaServico").Item(0).InnerText)

            Dim SqlConsultarItemListaServico As String = "Select * from tb_ItemListaServico where CodigoServico = '" & xmlServico.GetElementsByTagName("ItemListaServico").Item(0).InnerText & "'"
            Dim dtListstaServico As DataTable = conBd.Consultar(SqlConsultarItemListaServico, "tb_ItemListaServico")
            Parametro(41) = New ReportParameter("SubItemDescricao", dtListstaServico.Rows(0).Item("DescricaoServico").ToString())


            'INFORMAÇÕES DO MUNICIPIO
            Parametro(42) = New ReportParameter("MunicipioCodigo", xmlServico.GetElementsByTagName("CodigoMunicipio").Item(0).InnerText)
            Dim SqlMunicipioEmissao As String = "Select * from tb_Municipio where CodigoMunicipio = " + xmlServico.GetElementsByTagName("CodigoMunicipio").Item(0).InnerText + ""
            Dim dtMunicipioEmissao As DataTable = conBd.Consultar(SqlMunicipioEmissao, "tb_Municipio")
            Parametro(43) = New ReportParameter("MunicipioNome", dtMunicipioEmissao.Rows(0).Item("Municipio").ToString())

            'NATUREZA DE OPERAÇÃO
            Parametro(44) = New ReportParameter("NaturezaOperacaoCodigo", xmlInfNfse.GetElementsByTagName("NaturezaOperacao").Item(0).InnerText)
            Dim SqlNaturezaOperacao As String = "Select * from tb_NaturezaOperacao where Id = " + xmlInfNfse.GetElementsByTagName("NaturezaOperacao").Item(0).InnerText + ""
            Dim dtNaturezaOperacao As DataTable = conBd.Consultar(SqlNaturezaOperacao, "tb_NaturezaOperacao")
            Parametro(45) = New ReportParameter("NaturezaOperacaoDescricao", dtNaturezaOperacao.Rows(0).Item("Descricao").ToString())

            'VALOR DOS SERVIÇOS
            Parametro(46) = New ReportParameter("ValorDosServicos", FormatCurrency(xmlValorServico.GetElementsByTagName("ValorServicos").Item(0).InnerText.Replace(".", ",")))

            'DESCRICAO DAS RETENCOES FEDERAIS
            Parametro(47) = New ReportParameter("DescricaoRetencoesFederais", "PIS: R$ " & pis & " - COFINS: R$ " & cofins & " - CSLL: R$ " & csll & " - IRRF: R$ " & irrf)


            Dim diretorio1 As New DirectoryInfo(My.Application.Info.DirectoryPath & "\LogoPrestador")
            Dim arquivos1() As FileInfo = diretorio1.GetFiles
            For Each _arquivo As FileInfo In arquivos1
                Parametro(48) = New ReportParameter("LogoPrestador", "file:" & My.Application.Info.DirectoryPath & "\LogoPrestador\" & _arquivo.Name)
            Next

            Dim diretorio2 As New DirectoryInfo(My.Application.Info.DirectoryPath & "\LogoMunicipio")
            Dim arquivos2() As FileInfo = diretorio2.GetFiles
            For Each _arquivo As FileInfo In arquivos2
                Parametro(49) = New ReportParameter("LogoMunicipio", "file:" & My.Application.Info.DirectoryPath & "\LogoMunicipio\" & _arquivo.Name)
            Next

            If xmlTomadorEndereco.GetElementsByTagName("Bairro").Count > 0 Then
                Parametro(50) = New ReportParameter("TomadorBairro", xmlTomadorEndereco.GetElementsByTagName("Bairro").Item(0).InnerText)
            Else
                Parametro(50) = New ReportParameter("TomadorBairro", "")
            End If


            If xmlPrestador.GetElementsByTagName("Bairro").Count > 0 Then
                Parametro(51) = New ReportParameter("PrestadorBairro", xmlPrestador.GetElementsByTagName("Bairro").Item(0).InnerText)
            Else
                Parametro(51) = New ReportParameter("PrestadorBairro", "")
            End If



            Relatorio.LocalReport.SetParameters(Parametro)
            Me.Relatorio.RefreshReport()

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro vincular os parâmetros no relatório!" & ex.Message)
        End Try
    End Sub

#End Region

#Region "Métodos publicos"
    Public Sub EnviarEmail()
        Try

            Dim conBd As New ConexaoBd
            Dim Sql As String = "Select EmailRemetente,AssuntoEmail,MensagemEmail,UtilizarNumNfseNoAssunto,UtilizarEmailCliente,EmailDestinatarioPadrao,EnderecoSmtp,PortaSmtp,SenhaEmail,EnviarCopiaEmail,EmailCopia from tb_Parametros"
            Dim dt As DataTable = conBd.Consultar(Sql, "tb_Parametros")


            Dim numeroNfse As String = XmlNfse.GetElementsByTagName("Numero").Item(0).InnerText

            Dim CaminhoArquivoPDF, CaminhoArquivoXML As String
            CaminhoArquivoPDF = My.Application.Info.DirectoryPath & "\Temp\NFSE-" & numeroNfse & ".pdf"
            CaminhoArquivoXML = My.Application.Info.DirectoryPath & "\Temp\NFSE-" & numeroNfse & ".xml"

            Dim warnings As Warning() = Nothing
            Dim streamids As String() = Nothing
            Dim mimeType As String = Nothing
            Dim encoding As String = Nothing
            Dim fileNameExtension As String = Nothing

            Dim exportBytesPDF() As Byte = Relatorio.LocalReport.Render("PDF", Nothing, mimeType, encoding, fileNameExtension, streamids, warnings)

            'Salva arquivo pdf na pasta Temp
            Dim bytesPDF As Byte()
            bytesPDF = Relatorio.LocalReport.Render("PDF", Nothing, mimeType, encoding, fileNameExtension, streamids, warnings)
            Dim fs As New FileStream(CaminhoArquivoPDF, FileMode.Create)
            fs.Write(bytesPDF, 0, bytesPDF.Length)
            fs.Close()

            'Salva arquivo xml na pasta Temp
            XmlNfse.Save(CaminhoArquivoXML)

            'create the mail message
            Dim mail As New MailMessage()


            'set the addresses
            mail.From = New MailAddress(dt.Rows(0).Item("EmailRemetente"))

            'E-mail do destinatário
            If dt.Rows(0).Item("UtilizarEmailCliente") = "NAO" Then
                mail.To.Add(dt.Rows(0).Item("EmailDestinatarioPadrao"))
            Else
                mail.To.Add(xmlTomador.GetElementsByTagName("Email").Item(0).InnerText)
            End If

            'E-mail com cópia para
            If dt.Rows(0).Item("EnviarCopiaEmail") = "SIM" Then
                mail.CC.Add(dt.Rows(0).Item("EmailCopia"))
            End If

            If dt.Rows(0).Item("UtilizarNumNfseNoAssunto") = "NAO" Then
                mail.Subject = dt.Rows(0).Item("AssuntoEmail")
            Else
                mail.Subject = dt.Rows(0).Item("AssuntoEmail") & numeroNfse
            End If

            mail.Body = dt.Rows(0).Item("MensagemEmail")

            'Adiciona os anexos a mensagem
            mail.Attachments.Add(New Attachment(CaminhoArquivoPDF))
            mail.Attachments.Add(New Attachment(CaminhoArquivoXML))

            'Configura o cliente smtp definindo remetente, porta smtp e senha do e-mail
            Dim smtp As New SmtpClient(dt.Rows(0).Item("EnderecoSmtp"), dt.Rows(0).Item("PortaSmtp"))
            'Descriptografa a senha do e-mail
            Dim Decifrado As New ClsCrypto
            Dim Passaword As String = Decifrado.clsCrypto(dt.Rows(0).Item("SenhaEmail").ToString, False)

            smtp.Credentials = New System.Net.NetworkCredential(dt.Rows(0).Item("EmailRemetente").ToString, Passaword)

            smtp.Send(mail)

            'Atualiza tabela tb_Nfse, campo status envio e-mail
            Sql = "Update tb_Nfse set StatusEnvioEmail = 'ENVIADO' where NumNota = '" & numeroNfse & "'"
            conBd.ExecutarSql(Sql)

        Catch exSend As Exception
            Throw New Exception("Ocorreu um erro ao enviar e-mails. " & exSend.Message)
        End Try
    End Sub
#End Region

End Class