Public Class frmVisualizarXml
    Public Sub New(ByVal UrlNota As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.web.Navigate(New Uri(UrlNota))
    End Sub
    Private Sub frmVisualizarXml_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class