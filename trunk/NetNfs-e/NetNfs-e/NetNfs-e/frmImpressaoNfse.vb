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
            xmlPrestador = XmlNfse.GetElementsByTagName("PrestadorServico").Item(0)
            xmlTomador = XmlNfse.GetElementsByTagName("TomadorServico").Item(0)
            xmlTomadorEndereco = xmlTomador.GetElementsByTagName("Endereco").Item(0)
            xmlIntermediario = XmlNfse.GetElementsByTagName("IntermediarioServico").Item(0)
            xmlConstrucaoCivil = XmlNfse.GetElementsByTagName("ConstrucaoCivil").Item(0)
            xmlOrgaoGerador = XmlNfse.GetElementsByTagName("OrgaoGerador").Item(0)

            Dim conBd As New ConexaoBd
            Dim SqlConsultar As String = "Select * from tb_CadEmpresa"
            Dim dt As DataTable = conBd.Consultar(SqlConsultar, "tb_CadEmpresa")


            Dim dr As DataRow = dt.Rows(0)

            Dim Parametro As ReportParameter() = New ReportParameter(20) {}

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


            ''Informações do Tomador de serviço
            Parametro(13) = New ReportParameter("TomadorRazaoSocial", xmlTomador.GetElementsByTagName("RazaoSocial").Item(0).InnerText)
            Parametro(14) = New ReportParameter("TomadorCpfCnpj", xmlTomador.GetElementsByTagName("Cnpj").Item(0).InnerText)
            Parametro(15) = New ReportParameter("TomadorEndereco", xmlTomadorEndereco.GetElementsByTagName("Endereco").Item(0).InnerText & ", " & xmlTomadorEndereco.GetElementsByTagName("Numero").Item(0).InnerText & ", " & xmlTomadorEndereco.GetElementsByTagName("Complemento").Item(0).InnerText & ", " & xmlTomadorEndereco.GetElementsByTagName("Bairro").Item(0).InnerText)
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
            'MATEUS PAROU NO PARAMETRO 17 DE EDIÇÃO

            If xmlTomador.GetElementsByTagName("InscricaoMunicipal").Count > 0 Then
                Parametro(18) = New ReportParameter("TomadorInscricaoMunicipal", xmlTomador.GetElementsByTagName("InscricaoMunicipal").Item(0).InnerText)
            Else
                Parametro(18) = New ReportParameter("TomadorEmail", "")
            End If



            Parametro(18) = New ReportParameter("TomadorInscricaoMunicipal", "INSCRICAO MUN")
            Parametro(19) = New ReportParameter("TomadorUf", xmlTomadorEndereco.GetElementsByTagName("Uf").Item(0).InnerText)

            SqlConsultar = "Select Municipio from tb_Municipio where CodigoMunicipio = '" & xmlTomadorEndereco.GetElementsByTagName("CodigoMunicipio").Item(0).InnerText & "'"
            Dim dtMunicipio As DataTable = conBd.Consultar(SqlConsultar, "tb_CadEmpresa")


            Parametro(20) = New ReportParameter("TomadorCidade", dtMunicipio.Rows(0).Item("Municipio").ToString())



            Relatorio.LocalReport.SetParameters(Parametro)
            Me.Relatorio.RefreshReport()



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class