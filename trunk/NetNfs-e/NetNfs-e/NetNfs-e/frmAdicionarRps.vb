Imports System.Data
Public Class frmAdicionarRps
    Public _grid As New System.Windows.Forms.DataGridView
    Public _row As DataRow
    Public dtSet As New DataSet



    Private Sub frmAdicionarRps_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim cont As Integer
        For cont = 0 To 4

            _row = dtSet.Tables(0).NewRow

            'CHAVE DA TABELA
            _row("ID") = dtSet.Tables(0).Rows.Count

            'IDENTIFICAÇÃO E DADOS DO RPS
            _row("Num Rps") = cont
            _row("Serie Rps") = 12345
            _row("Tipo Rps") = txtTipoRps.Text
            _row("Data Emissão") = Date.Now
            _row("Natureza Operação") = 1
            _row("Regime Especial Tributação") = txtRegEspTributacao.Text
            _row("Optante simples nacional") = txtOptSimplesNacional.Text
            _row("Incentivador cultural") = txtIncCultural.Text
            _row("Status") = 1

            'RSP SUBSTITUIDO
            _row("Num Rps substituido") = cont
            _row("Serie Rps substituido") = "ABS" & cont
            _row("Tipo Rps substituido") = "GG"

            'SERVIÇO
            _row("Valor serviço") = "1000111,02"
            _row("Valor deduções") = 10
            _row("Valor PIS") = 10
            _row("Valor CONFINS") = 10
            _row("Valor INSS") = 10
            _row("Valor IR") = 10
            _row("Valor CSLL") = 10
            _row("ISS Retido") = 1
            _row("Valor ISS") = 10
            _row("Outras retenções") = 10
            _row("Base Calculo") = 1000
            _row("Aliquota") = 5
            _row("Valor liquido NFSE") = 995
            _row("Valor ISS Retido") = 10
            _row("Desconto incodicionado") = 10
            _row("Desconto codicionado") = 10
            _row("Item lista Serviço") = "11.01"
            _row("Código CNAE") = "58457"
            _row("Código tributação municipio") = "522310000"
            _row("Discriminação") = "Produto teste de lançamento " & cont
            _row("Código municipio") = "545454"

            'PRESTADOR SERVIÇO
            _row("Prestador") = "Josimar" & cont
            _row("Cnpj Prestador") = "00.000.000/000-00"
            _row("Inscrição Municipal Prestador") = "0000000000000"
            _row("Logradouro prestador") = "Av Costa e Silva"
            _row("Nº prestador") = "230"
            _row("Complemento prestador") = "CASA"
            _row("Bairro prestador") = "MENEZES"
            _row("Cod Municipio prestador") = "0101"
            _row("Uf prestador") = "MG"
            _row("CEP prestador") = "33913440"
            _row("E-mail prestador") = "josimar@hotmail.com"
            _row("Tel prestador") = "3197586469"

            'TOMADOR SERVIÇO
            _row("Tomador") = "NETSYSTEMAS TECNOLOGIA" & cont
            _row("Tipo pessoa tomador") = "Física" 'F=Fisica J=Jurídica
            _row("Cnpj/Cpf tomador") = "00.000.000/000-00"
            _row("Inscrição Municipal Tomador") = "111111111111111111"
            _row("Logradouro tomador") = "Av Padre Pedro Pinto"
            _row("Nº tomador") = "1652"
            _row("Complemento tomador") = "Loja 1"
            _row("Bairro tomador") = "Venda Nova"
            _row("Cod Municipio tomador") = "54554"
            _row("Uf tomador") = "MG"
            _row("CEP tomador") = "33916442"

            'INTERMEDIARIO SERVIÇO
            _row("Intermediario") = "Mateus Luiz de oliveira"
            _row("Tipo pessoa intermediario") = "Física"
            _row("Cnpj/Cpf intermediario") = "023.007.568-65"
            _row("Inscrição Municipal intermediario") = "3232323232333"

            'CONSTRUÇÃO CIVIL
            _row("Codigo obra") = cont + 10
            _row("Art construção civil") = cont + 1524

            dtSet.Tables(0).Rows.Add(_row)
            _grid.Refresh()
        Next
        Me.Close()

    End Sub
End Class