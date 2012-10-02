Imports System.Xml
Public Class frmVisualizarXml
    Private _UrlNota As String
    Public Sub New(ByVal UrlNota As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Web.Navigate(New Uri(UrlNota))
        _UrlNota = UrlNota

    End Sub

    Private Sub btExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExportar.Click

        Dim salvarComo As SaveFileDialog = New SaveFileDialog()
        Dim caminho As DialogResult
        Dim Arquivo As String

        salvarComo.CheckFileExists = False
        salvarComo.Title = "Exportando arquivo Xml"
        salvarComo.Filter = "Arquivos xml (*.xml)|*.xml"
        caminho = salvarComo.ShowDialog
        Arquivo = salvarComo.FileName

        If Trim(Arquivo) <> "" Then
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(_UrlNota)
            xmlDoc.Save(Arquivo)
            MsgBox("Arquivo exportado com sucesso!", vbInformation, "Confirmação")
        End If

    End Sub

    Private Sub btSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSair.Click
        Me.Close()
    End Sub
End Class