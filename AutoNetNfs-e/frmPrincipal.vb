Imports NetNfs_e
Public Class frmPrincipal
    Private frmGerenciar As frmGerenciarLotes
    Private strDiretorioNFSe As String

    Private Sub frmPrincipal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        e.Cancel = True
    End Sub

    Private Sub NotifyIcon_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon.MouseDoubleClick
        Me.Show()
    End Sub

    Private Sub MenuSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSair.Click
        If MsgBox("Tem certeza que deseja sair do sistema?", vbQuestion + vbYesNo + vbDefaultButton2, "Confirmação") = vbYes Then
            End
        End If
    End Sub

    Private Sub MenuAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAbrir.Click
        Me.Show()
    End Sub

    Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Carrega os parâmetros do sistema
        CarregarParametrosSistema()

        'Chama e configura o formulário Gerenciar Lote Rps
        frmGerenciar = New frmGerenciarLotes(True)
        frmGerenciar.MdiParent = Me
        frmGerenciar.Show()

        'Habilita o Timer e da início ao processo
        'Timer1.Enabled=True

    End Sub

    Private Sub btSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSair.Click
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub btInterromper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInterromper.Click
        btInterromper.Visible = False
        btContinuar.Visible = True

    End Sub

    Private Sub btContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btContinuar.Click
        btContinuar.Visible = False
        btInterromper.Visible = True

    End Sub
End Class