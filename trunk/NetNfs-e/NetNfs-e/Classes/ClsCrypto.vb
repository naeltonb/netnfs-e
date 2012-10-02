
Imports System.Security.Cryptography
Imports System.Text

Public Class ClsCrypto

#Region "Variávies"
    Private myKey As String
    Private des As New TripleDESCryptoServiceProvider()
    Private hashmd5 As New MD5CryptoServiceProvider()
#End Region

#Region "Construtor"
    Public Sub New()
        'Inserir o codigo de configuração da classe
        myKey = "NetSystemasNfse"
    End Sub
#End Region

#Region "Métodos públicos"
    Friend Function clsCrypto(ByVal texto As String, ByVal Operacao As Boolean) As String
        If Operacao Then
            clsCrypto = Cifra(texto)
        Else
            clsCrypto = DeCifra(texto)
        End If
    End Function

#End Region

#Region "Métodos privados"

    Private Function DeCifra(ByVal texto As String) As String

        des.Key = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(myKey))
        des.Mode = CipherMode.ECB
        Dim desdencrypt As ICryptoTransform = des.CreateDecryptor()
        Dim buff() As Byte = Convert.FromBase64String(texto)
        DeCifra = ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length))

    End Function

    Private Function Cifra(ByVal texto As String) As String
        des.Key = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(myKey))
        des.Mode = CipherMode.ECB
        Dim desdencrypt As ICryptoTransform = des.CreateEncryptor()
        Dim MyASCIIEncoding = New ASCIIEncoding()
        Dim buff() As Byte = ASCIIEncoding.ASCII.GetBytes(texto)
        Cifra = Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length))
    End Function

#End Region

End Class
