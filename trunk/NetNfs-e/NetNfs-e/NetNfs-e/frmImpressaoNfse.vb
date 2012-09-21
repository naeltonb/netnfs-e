Imports Microsoft.Reporting
Imports Microsoft.Reporting.WinForms
Imports System.Xml
Imports System.IO
Imports System.Net.Mail

Public Class frmImpressaoNfse

    Private EnviarPdfXmlEmail As String
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



    Public Sub New(ByVal xml As XmlDocument, ByVal EnviaEmail As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        XmlNfse = New XmlDocument
        XmlNfse = xml
        EnviarPdfXmlEmail = EnviaEmail

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

            Dim Parametro As ReportParameter() = New ReportParameter(47) {}

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
                Parametro(29) = New ReportParameter("ValorDesconto", "R$ " & XmlNfse.GetElementsByTagName("DescontoCondicionado").Item(0).InnerText)
            Else
                Parametro(29) = New ReportParameter("ValorDesconto", "R$ 0.00")
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
                Parametro(31) = New ReportParameter("ValorIssRetidoNaFonte", "R$ " & xmlValorServico.GetElementsByTagName("ValorIssRetido").Item(0).InnerText)
            Else
                Parametro(31) = New ReportParameter("ValorIssRetidoNaFonte", "R$ 0.00")
            End If

            Parametro(32) = New ReportParameter("ValorLiquido", "R$ " & xmlValorServico.GetElementsByTagName("ValorLiquidoNfse").Item(0).InnerText)

            If xmlValorServico.GetElementsByTagName("ValorDeducoes").Count > 0 Then
                Parametro(33) = New ReportParameter("ValorDeducoes", "R$ " & xmlValorServico.GetElementsByTagName("ValorDeducoes").Item(0).InnerText)
            Else
                Parametro(33) = New ReportParameter("ValorDeducoes", "R$ 0.00")
            End If

            If xmlValorServico.GetElementsByTagName("DescontoIncondicionado").Count > 0 Then
                Parametro(34) = New ReportParameter("ValorDescontoIncondicionado", "R$ " & xmlValorServico.GetElementsByTagName("DescontoIncondicionado").Item(0).InnerText)
            Else
                Parametro(34) = New ReportParameter("ValorDescontoIncondicionado", "R$ 0.00")
            End If

            Parametro(35) = New ReportParameter("ValorBaseDeCalculo", "R$ " & xmlValorServico.GetElementsByTagName("BaseCalculo").Item(0).InnerText)

            'SE O ISS FOR RETIDO IMPRIME OS VALORES, CASO NÃO, BUSCA A ALIQUOTA DOS PARAMETROS E IMPRIME
            If xmlValorServico.GetElementsByTagName("Aliquota").Count > 0 Then
                Dim SAliquotaIss As String
                Dim AliquotaIss As Decimal
                SAliquotaIss = xmlValorServico.GetElementsByTagName("Aliquota").Item(0).InnerText
                AliquotaIss = Convert.ToDecimal(SAliquotaIss)
                Parametro(36) = New ReportParameter("ValorAliquota", "% " & AliquotaIss)
            Else
                Parametro(36) = New ReportParameter("ValorAliquota", "% " & "0")
            End If

            If xmlValorServico.GetElementsByTagName("ValorIss").Count > 0 Then
                Parametro(37) = New ReportParameter("ValorDoIss", "R$ " & xmlValorServico.GetElementsByTagName("ValorIss").Item(0).InnerText)
            Else
                Parametro(37) = New ReportParameter("ValorDoIss", "R$ " & "0")
            End If
            If xmlServico.GetElementsByTagName("CodigoTributacaoMunicipio").Count > 0 Then
                Parametro(38) = New ReportParameter("CtIssCodigo", xmlServico.GetElementsByTagName("CodigoTributacaoMunicipio").Item(0).InnerText)
                Dim SqlConsultarTributacaoMunicipio As String = "Select * from tb_ItemListaServico where CodigoServico = '" & xmlServico.GetElementsByTagName("CodigoTributacaoMunicipio").Item(0).InnerText & "'"
                Dim dtTributacaoMunicipio As DataTable = conBd.Consultar(SqlConsultarTributacaoMunicipio, "tb_ItemListaServico")
                Parametro(39) = New ReportParameter("CtIssDescricao", dtTributacaoMunicipio.Rows(0).Item("DescricaoServico").ToString())
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
            Parametro(46) = New ReportParameter("ValorDosServicos", "R$ " & xmlValorServico.GetElementsByTagName("ValorServicos").Item(0).InnerText)

            'DESCRICAO DAS RETENCOES FEDERAIS
            Parametro(47) = New ReportParameter("DescricaoRetencoesFederais", "PIS: R$ " & pis & " - COFINS: R$ " & cofins & " - CSLL: R$ " & csll & " - IRRF: R$ " & irrf)

            Relatorio.LocalReport.SetParameters(Parametro)
            Me.Relatorio.RefreshReport()
            Stop
            If EnviarPdfXmlEmail = "S" Then
                Try
                    Dim numeroNfse As String
                    numeroNfse = XmlNfse.GetElementsByTagName("Numero").Item(0).InnerText

                    Dim SqlConsultarCaminho, CaminhoParametros, CaminhoArquivoPDF, CaminhoArquivoXML As String
                    SqlConsultarCaminho = "Select DiretorioLoteRps from tb_Parametros"
                    Dim dtCaminho As DataTable = conBd.Consultar(SqlConsultarCaminho, "tb_Parametros")
                    CaminhoParametros = dtCaminho.Rows(0).Item("DiretorioLoteRps").ToString() & "\Temp\"

                    CaminhoArquivoPDF = CaminhoParametros & "NFSE-" & numeroNfse & ".pdf"
                    CaminhoArquivoXML = CaminhoParametros & "NFSE-" & numeroNfse & ".xml"

                    Dim warnings As Warning() = Nothing
                    Dim streamids As String() = Nothing
                    Dim mimeType As String = Nothing
                    Dim encoding As String = Nothing
                    Dim fileNameExtension As String = Nothing

                    Dim exportBytesPDF() As Byte = Relatorio.LocalReport.Render("PDF", Nothing, mimeType, encoding, fileNameExtension, streamids, warnings)

                    Dim bytesPDF As Byte()
                    bytesPDF = Relatorio.LocalReport.Render("PDF", Nothing, mimeType, encoding, fileNameExtension, streamids, warnings)
                    Dim fs As New FileStream(CaminhoArquivoPDF, FileMode.Create)
                    fs.Write(bytesPDF, 0, bytesPDF.Length)
                    fs.Close()

                    XmlNfse.Save(CaminhoArquivoXML)

                    'create the mail message
                    Dim mail As New MailMessage()

                    'set the addresses
                    mail.From = New MailAddress("Mateus Luis <mateus@netsystemas.com.br>")
                    mail.To.Add("mateus@rgainfo.com")

                    'set the content
                    mail.Subject = "NOTAS FISCAIS DE SERVIÇO: " & numeroNfse
                    mail.Body = "SEGUE ARQUIVOS REFERENTE A NOTA FISCAL NUMERO: " & numeroNfse

                    'to add additional attachments, simply call .Add(...) again
                    mail.Attachments.Add(New Attachment(CaminhoArquivoPDF))
                    mail.Attachments.Add(New Attachment(CaminhoArquivoXML))

                    'send the message
                    Dim smtp As New SmtpClient("mail.netsystemas.com.br", 25)
                    smtp.Send(mail)

                Catch exSend As Exception
                    MsgBox(exSend.Message)
                End Try


            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Relatorio_Load(sender As System.Object, e As System.EventArgs) Handles Relatorio.Load

    End Sub
End Class