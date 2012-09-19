Imports System.Type
Imports System.Data
Public Class frmGerarXml
    Public DtSet As DataSet
    Public DtTable As DataTable

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim objXML As New xmlNFSe.xmlNFSe
        Dim _row As DataRow
        Dim cont As Integer
        Dim lRps As xmlNFSe.InfRps

        objXML.infNFSe.Emit.xRazaoSocial = "Inforteck Sistemas"
        objXML.infNFSe.numLote = 1 'Sequencial número para identificar o número do lote enviado
        objXML.infNFSe.Emit.cnpj = "07.159.920/0001-04" 'CNPJ por ser informado com ou sem formatação. Deve-se respeitar o zero a esquerda. A própria Dll trata a validação
        objXML.infNFSe.Emit.inscrMunicipal = "123456789999999"
        objXML.infNFSe.qutRps = DtSet.Tables(0).Rows.Count

        For cont = 1 To DtSet.Tables(0).Rows.Count
            DtSet.Tables(0).Select("ID=" & cont)
            _row = DtSet.Tables(0).Rows(cont - 1)
            lRps = New xmlNFSe.InfRps
            lRps.Id = cont
            lRps.numero = cont

            'IDENTIFICAÇÃO E DADOS DO RPS
            lRps.numero = _row("Num Rps") 'Sequencial numérico crescente de controle do contribuinte
            lRps.serie = _row("Serie Rps")
            lRps.tipo = xmlNFSe.TipoRps.RPS
            lRps.dataEmissao = _row("Data Emissão")
            lRps.natOperacao = xmlNFSe.NaturezaOperacao.TributacaoForaDoMunicipio '= _row("Natureza Operação")
            lRps.regEspTributacao = xmlNFSe.RegimeEspTributacao.MEI_SimplesNacional
            lRps.optSimpNacional = xmlNFSe.OptanteSimplesNacional.Nao '= _row("Optante simples nacional")
            lRps.incentCultural = xmlNFSe.IncentivadorCultural.Nao '_row("Incentivador cultural")
            lRps.status = xmlNFSe.StatusRps.Normal '_row("Status")

            'RSP SUBSTITUIDO
            lRps.rpsSubstituido = xmlNFSe.RpsSubstituido.Nao 'Define se o RPS é substituidor ou não
            lRps.numeroRpsSubstituido = _row("Num Rps substituido")
            lRps.serieRpsSubstituido = _row("Serie Rps substituido")
            lRps.tipoRpsSubstituido = xmlNFSe.TipoRps.RPS '_row("Tipo Rps substituido")

            'SERVIÇO
            lRps.servico.valorServicos = "50,46" '_row("Valor serviço")
            lRps.servico.valorDeducoes = "50,10" '_row("Valor deduções")
            lRps.servico.valorPis = "10" '_row("Valor PIS")
            lRps.servico.valorCofins = "10" '_row("Valor CONFINS")
            lRps.servico.valorInss = "10" '_row("Valor INSS")
            lRps.servico.valorIr = "10" '_row("Valor IR")
            lRps.servico.valorCsll = "10" '_row("Valor CSLL")
            lRps.servico.issRetido = xmlNFSe.ISSRetido.Sim '_row("ISS Retido")
            lRps.servico.valorIss = "20" '_row("Valor ISS")
            lRps.servico.outrasRetencoes = "10" '_row("Outras retenções")
            lRps.servico.baseCalculo = "10" '_row("Base Calculo")
            lRps.servico.aliquota = "10" '_row("Aliquota")
            lRps.servico.valorLiquidoNfse = "10" '_row("Valor liquido NFSE")
            lRps.servico.valorIssRetido = "19,55" '_row("Valor ISS Retido")
            lRps.servico.descontoIncondicionado = "10" '_row("Desconto incodicionado")
            lRps.servico.descontoCondicionado = "10" '_row("Desconto codicionado")
            lRps.servico.itemListaServico = "11.11" '_row("Item lista Serviço")
            lRps.servico.codigoCnae = "5487548" '_row("Código CNAE")
            lRps.servico.codTributacaoMunicipal = "2121-1-1-1-" '_row("Código tributação municipio")
            lRps.servico.discriminacao = "descrição do serviço - teste de xml em loté" '_row("Discriminação")
            lRps.servico.codMunicipio = "12-1212-8" '_row("Código municipio")

            'PRESTADOR

            lRps.prestadorServico.cnpj = "07.159.920/0001-04" '_row("Cnpj Prestador")
            lRps.prestadorServico.inscrMunicipal = "123456789874545" '_row("Inscrição Municipal Prestador")



            'TOMADOR SERVIÇO
            lRps.tomadorServico.tipoPessoa = xmlNFSe.TipoPessoa.Fisica 'Indica se é Pessoa Físcia ou Jurídica
            lRps.tomadorServico.cpf = "049.008.796-57" '_row("Cnpj/Cpf tomador")
            lRps.tomadorServico.cnpj = "07.159.920/0001-04" '_row("Cnpj/Cpf tomador")
            lRps.tomadorServico.inscrMunicipal = "12.3456789/5454-54" '_row("Inscrição Municipal Tomador")
            lRps.tomadorServico.razaoSocial = "josimar cordeiro da sílva" '_row("Tomador")
            lRps.tomadorServico.enderecoTomador.logradouro = "av costa e silva" '_row("Logradouro tomador")
            lRps.tomadorServico.enderecoTomador.numero = "230" '_row("Nº tomador")
            lRps.tomadorServico.enderecoTomador.complemento = "apt 1023" '_row("Complemento tomador")
            lRps.tomadorServico.enderecoTomador.bairro = "menezes" '_row("Bairro tomador")
            lRps.tomadorServico.enderecoTomador.codMunicipio = "12312" '_row("Cod Municipio tomador")
            lRps.tomadorServico.enderecoTomador.uf = "MG" '_row("Uf tomador")
            lRps.tomadorServico.enderecoTomador.cep = "12345-678" '_row("CEP tomador")
            lRps.tomadorServico.emailContato = "josimar@hotmail.com" '_row("E-mail prestador")
            lRps.tomadorServico.telefoneContato = "031-9585-1813" '_row("Tel prestador")

            'INTERMEDIARIO SERVIÇO
            lRps.intermediarioServico.razaoSocial = "mateus luiz de oliveira" '_row("Intermediario")
            lRps.intermediarioServico.tipoPessoa = xmlNFSe.TipoPessoa.Fisica 'Indica se é Pessoa Físcia ou Jurídica
            lRps.intermediarioServico.cpf = "049.008.796-57" '_row("Cnpj/Cpf intermediario")
            lRps.intermediarioServico.cnpj = "000.000.000-00" '_row("Cnpj/Cpf intermediario")
            lRps.intermediarioServico.inscrMunicipal = "1233" '_row("Inscrição Municipal intermediario")

            'CONSTRUÇÃO CIVIL
            lRps.construcaoCivil.codObra = _row("Codigo obra")
            lRps.construcaoCivil.art = _row("Art construção civil")

            objXML.incluirNaListaRps(lRps)
        Next

        objXML.GerarXmlLoteRps(objXML, My.Application.Info.DirectoryPath)
    End Sub


    Private Sub frmGerarXml_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'GridRps.Rows.Add()
        ConfigurarTabelaVirtual()
    End Sub


    Private Sub ConfigurarTabelaVirtual()
        DtTable = New DataTable("tbRps")
        DtSet = New DataSet

        'CHAVE DA TABELA
        DtTable.Columns.Add("ID")

        'IDENTIFICAÇÃO E DADOS DO RPS
        DtTable.Columns.Add("Num Rps")
        DtTable.Columns.Add("Serie Rps")
        DtTable.Columns.Add("Tipo Rps")
        DtTable.Columns.Add("Data Emissão")
        DtTable.Columns.Add("Natureza Operação")
        DtTable.Columns.Add("Regime Especial Tributação")
        DtTable.Columns.Add("Optante simples nacional")
        DtTable.Columns.Add("Incentivador cultural")
        DtTable.Columns.Add("Status")

        'RSP SUBSTITUIDO
        DtTable.Columns.Add("Num Rps substituido")
        DtTable.Columns.Add("Serie Rps substituido")
        DtTable.Columns.Add("Tipo Rps substituido")

        'SERVIÇO
        DtTable.Columns.Add("Valor serviço")
        DtTable.Columns.Add("Valor deduções")
        DtTable.Columns.Add("Valor PIS")
        DtTable.Columns.Add("Valor CONFINS")
        DtTable.Columns.Add("Valor INSS")
        DtTable.Columns.Add("Valor IR")
        DtTable.Columns.Add("Valor CSLL")
        DtTable.Columns.Add("ISS Retido")
        DtTable.Columns.Add("Valor ISS")
        DtTable.Columns.Add("Outras retenções")
        DtTable.Columns.Add("Base Calculo")
        DtTable.Columns.Add("Aliquota")
        DtTable.Columns.Add("Valor liquido NFSE")
        DtTable.Columns.Add("Valor ISS Retido")
        DtTable.Columns.Add("Desconto incodicionado")
        DtTable.Columns.Add("Desconto codicionado")
        DtTable.Columns.Add("Item lista Serviço")
        DtTable.Columns.Add("Código CNAE")
        DtTable.Columns.Add("Código tributação municipio")
        DtTable.Columns.Add("Discriminação")
        DtTable.Columns.Add("Código municipio")

        'PRESTADOR SERVIÇO
        DtTable.Columns.Add("Prestador")
        DtTable.Columns.Add("Cnpj Prestador")
        DtTable.Columns.Add("Inscrição Municipal Prestador")
        DtTable.Columns.Add("Logradouro prestador")
        DtTable.Columns.Add("Nº prestador")
        DtTable.Columns.Add("Complemento prestador")
        DtTable.Columns.Add("Bairro prestador")
        DtTable.Columns.Add("Cod Municipio prestador")
        DtTable.Columns.Add("Uf prestador")
        DtTable.Columns.Add("CEP prestador")
        DtTable.Columns.Add("E-mail prestador")
        DtTable.Columns.Add("Tel prestador")

        'TOMADOR SERVIÇO
        DtTable.Columns.Add("Tomador")
        DtTable.Columns.Add("Tipo pessoa tomador")
        DtTable.Columns.Add("Cnpj/Cpf tomador")
        DtTable.Columns.Add("Inscrição Municipal Tomador")
        DtTable.Columns.Add("Logradouro tomador")
        DtTable.Columns.Add("Nº tomador")
        DtTable.Columns.Add("Complemento tomador")
        DtTable.Columns.Add("Bairro tomador")
        DtTable.Columns.Add("Cod Municipio tomador")
        DtTable.Columns.Add("Uf tomador")
        DtTable.Columns.Add("CEP tomador")

        'INTERMEDIARIO SERVIÇO
        DtTable.Columns.Add("Intermediario")
        DtTable.Columns.Add("Tipo pessoa intermediario")
        DtTable.Columns.Add("Cnpj/Cpf intermediario")
        DtTable.Columns.Add("Inscrição Municipal intermediario")

        'CONSTRUÇÃO CIVIL
        DtTable.Columns.Add("Codigo obra")
        DtTable.Columns.Add("Art construção civil")






        DtSet.Tables.Add(DtTable)

        GridRps.DataSource = DtSet.Tables(0)
        'GridRps.Rows.Add()
        GridRps.Refresh()

    End Sub


    Private Sub btAddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAddRow.Click
        Dim frmAdicionar As New frmAdicionarRps
        frmAdicionar._grid = GridRps
        frmAdicionar.dtSet = DtSet
        frmAdicionar.Show()
    End Sub
End Class