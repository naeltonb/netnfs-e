
Imports NetNfs_e
Imports System.Security.Cryptography.X509Certificates
Public Module Funcoes
    Friend fAuto As FuncoesAutomaticas
    Friend _certificado As New X509Certificate2

    Friend Sub CarregarParametrosAutomaticos()
        Dim fCert As New CertificadoDigital
        'Carrega os parâmetros do sistema AutoNfs-e
        Dim conBd As New ConexaoBd
        Dim Sql As String = "Select * from tb_ConfigAutomatico"
        Dim dt As DataTable = conBd.Consultar(Sql, "tb_ConfigAutomatico")
        If dt.Rows.Count > 0 Then
            fAuto.Assinar = dt.Rows(0).Item("Assinar")
            fAuto.Enviar = dt.Rows(0).Item("Enviar")
            fAuto.Verificar = dt.Rows(0).Item("Verificar")
            fAuto.Importar = dt.Rows(0).Item("Importar")
            fAuto.EmailAuto = dt.Rows(0).Item("EmailAuto")
            fAuto.Arquivar = dt.Rows(0).Item("Arquivar")
            _certificado = fCert.SelecionarCertificado(SerieCertificadoCliente)

        Else
            fAuto.Assinar = "NÃO"
            fAuto.Enviar = "NÃO"
            fAuto.Verificar = "NÃO"
            fAuto.Importar = "NÃO"
            fAuto.EmailAuto = "NÃO"
            fAuto.Arquivar = "NÃO"
            _certificado = fCert.SelecionarCertificado("")
        End If
    End Sub


    Friend Structure FuncoesAutomaticas
        Dim Assinar As String
        Dim Enviar As String
        Dim Verificar As String
        Dim Importar As String
        Dim EmailAuto As String
        Dim Arquivar As String
    End Structure

End Module
