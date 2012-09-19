Imports Microsoft.Reporting
Imports Microsoft.Reporting.WinForms
Imports System.Xml
Public Class frmImpressaoNfse

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


    Public Sub New(ByVal xml As XmlDocument)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        XmlNfse = New XmlDocument
        XmlNfse = xml

    End Sub



    Private Sub frmImpressaoNfse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Definir como visualização de leitura como padrão
        Relatorio.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

        'Definindo ZOOM de 150% como padrão
        Relatorio.ZoomPercent = 150


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

            Dim Parametro As ReportParameter() = New ReportParameter(45) {}

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
            Parametro(14) = New ReportParameter("TomadorCpfCnpj", xmlTomador.GetElementsByTagName("Cnpj").Item(0).InnerText)

            'INFORMAÇÕES DO TOMADOR

            Dim Endereco, Numero, Complemento, Bairro As String

            If xmlTomador.GetElementsByTagName("Endereco").Count > 0 Then
                Endereco = xmlTomador.GetElementsByTagName("Endereco").Item(0).InnerText & ","
            Else
                Endereco = ""
            End If

            If xmlTomador.GetElementsByTagName("Numero").Count > 0 Then
                Numero = xmlTomador.GetElementsByTagName("Numero").Item(0).InnerText & ","
            Else
                Numero = ""
            End If

            If xmlTomador.GetElementsByTagName("Complemento").Count > 0 Then
                Complemento = xmlTomador.GetElementsByTagName("Complemento").Item(0).InnerText & ","
            Else
                Complemento = ""
            End If

            If xmlTomador.GetElementsByTagName("Bairro").Count > 0 Then
                Bairro = xmlTomador.GetElementsByTagName("Bairro").Item(0).InnerText & ","
            Else
                Bairro = ""
            End If

            If xmlTomador.GetElementsByTagName("Endereco").Count > 0 Then
                Parametro(15) = New ReportParameter("TomadorEndereco", Endereco & Numero & Complemento & Bairro)
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

                If xmlIntermediario.GetElementsByTagName("Cpf").Count > 0 Then
                    Parametro(24) = New ReportParameter("IntermediarioCpfCnpj", xmlIntermediario.GetElementsByTagName("Cpf").Item(0).InnerText)
                ElseIf xmlIntermediario.GetElementsByTagName("Cnpj").Count > 0 Then
                    Parametro(24) = New ReportParameter("IntermediarioCpfCnpj", xmlIntermediario.GetElementsByTagName("Cnpj").Item(0).InnerText)
                Else
                    Parametro(24) = New ReportParameter("IntermediarioCpfCnpj", "")
                End If

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

            'INICIO INFORMAÇÕES CONSTRUCAO CIVIL

            If XmlNfse.GetElementsByTagName("OutrasInformacoes").Count > 0 Then
                Parametro(28) = New ReportParameter("OutrasInformacoes", XmlNfse.GetElementsByTagName("OutrasInformacoes").Item(0).InnerText)
            Else
                Parametro(28) = New ReportParameter("OutrasInformacoes", "")
            End If

            If xmlServico.GetElementsByTagName("DescontoCondicionado").Count > 0 Then
                Parametro(29) = New ReportParameter("ValorDesconto", XmlNfse.GetElementsByTagName("DescontoCondicionado").Item(0).InnerText)
            Else
                Parametro(29) = New ReportParameter("ValorDesconto", "")
            End If

            'SOMANDO VALORES PARA OBTER AS RETENÇÕES FEDERAIS
            Dim pis, cofins, csll, irrf, inss, RetencoesFederais As Integer

            If xmlValorServico.GetElementsByTagName("ValorPis").Count > 0 Then
                pis = xmlValorServico.GetElementsByTagName("ValorPis").Item(0).InnerText
            End If

            If xmlValorServico.GetElementsByTagName("ValorCofins").Count > 0 Then
                cofins = xmlValorServico.GetElementsByTagName("ValorCofins").Item(0).InnerText
            End If

            If xmlValorServico.GetElementsByTagName("ValorCsll").Count > 0 Then
                csll = xmlValorServico.GetElementsByTagName("ValorCsll").Item(0).InnerText
            End If

            If xmlValorServico.GetElementsByTagName("ValorIr").Count > 0 Then
                irrf = xmlValorServico.GetElementsByTagName("ValorIr").Item(0).InnerText
            End If

            If xmlValorServico.GetElementsByTagName("ValorInss").Count > 0 Then
                inss = xmlValorServico.GetElementsByTagName("ValorInss").Item(0).InnerText
            End If

            RetencoesFederais = pis + cofins + csll + irrf + inss
            Parametro(30) = New ReportParameter("ValorRetencoesFederais", RetencoesFederais)

            If xmlValorServico.GetElementsByTagName("ValorIssRetido").Count > 0 Then
                Parametro(31) = New ReportParameter("ValorIssRetidoNaFonte", xmlValorServico.GetElementsByTagName("ValorIssRetido").Item(0).InnerText)
            Else
                Parametro(31) = New ReportParameter("ValorIssRetidoNaFonte", "0,00")
            End If

            Parametro(32) = New ReportParameter("ValorLiquido", xmlValorServico.GetElementsByTagName("ValorLiquidoNfse").Item(0).InnerText)

            If xmlValorServico.GetElementsByTagName("ValorDeducoes").Count > 0 Then
                Parametro(33) = New ReportParameter("ValorDeducoes", xmlValorServico.GetElementsByTagName("ValorDeducoes").Item(0).InnerText)
            Else
                Parametro(33) = New ReportParameter("ValorDeducoes", "0,00")
            End If

            If xmlValorServico.GetElementsByTagName("DescontoIncondicionado").Count > 0 Then
                Parametro(34) = New ReportParameter("ValorDescontoIncondicionado", xmlValorServico.GetElementsByTagName("DescontoIncondicionado").Item(0).InnerText)
            Else
                Parametro(34) = New ReportParameter("ValorDescontoIncondicionado", "0,00")
            End If

            Parametro(35) = New ReportParameter("ValorBaseDeCalculo", xmlValorServico.GetElementsByTagName("BaseCalculo").Item(0).InnerText)

            Parametro(36) = New ReportParameter("ValorAliquota", xmlValorServico.GetElementsByTagName("Aliquota").Item(0).InnerText)

            Parametro(37) = New ReportParameter("ValorDoIss", xmlValorServico.GetElementsByTagName("ValorIss").Item(0).InnerText)
            Stop
            If xmlServico.GetElementsByTagName("CodigoTributacaoMunicipio").Count > 0 Then
                Parametro(38) = New ReportParameter("CtIssCodigo", xmlServico.GetElementsByTagName("CodigoTributacaoMunicipio").Item(0).InnerText)
                Dim SqlConsultarTributacaoMunicipio As String = "Select * from tb_ItemListaServico where CodigoServico = " & xmlServico.GetElementsByTagName("CodigoTributacaoMunicipio").Item(0).InnerText & ""
                Dim dtTributacaoMunicipio As DataTable = conBd.Consultar(SqlConsultarTributacaoMunicipio, "tb_ItemListaServico")
                Parametro(39) = New ReportParameter("CtIssDescricao", dtMunicipio.Rows(0).Item("DescricaoServico").ToString())
            Else
                Parametro(38) = New ReportParameter("CtIssCodigo", "")
                Parametro(39) = New ReportParameter("CtIssDescricao", "")

            End If

            Parametro(40) = New ReportParameter("SubItemCodigo", xmlValorServico.GetElementsByTagName("ItemListaServico").Item(0).InnerText)

            Dim SqlConsultarItemListaServico As String = "Select * from tb_ItemListaServico where CodigoServico = " & xmlServico.GetElementsByTagName("CodigoTributacaoMunicipio").Item(0).InnerText & ""
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


            Relatorio.LocalReport.SetParameters(Parametro)
            Me.Relatorio.RefreshReport()



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class