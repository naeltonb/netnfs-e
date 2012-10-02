Public NotInheritable Class frmSobreSistema

    Private Sub frmSobreSistema_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmSobreSistema_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CentralizarForm(Me)
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = My.Application.Info.Version.ToString
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://www.netsystemas.com.br")
    End Sub
End Class
