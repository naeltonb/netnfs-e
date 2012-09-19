Imports System.Windows.Forms

Public Class frmPrincipal

    Private Property m_ChildFormNumber As Integer

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, btNovoLote.Click
        ' Create a new instance of the child form.
        'Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        'ChildForm.MdiParent = Me

        'm_ChildFormNumber += 1
        'ChildForm.Text = "Window " & m_ChildFormNumber

        'ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, btAbrirLote.Click
        If ParametrosCarregados = False Then
            MsgBox(strMsgParametros, vbExclamation, "Atenção")
        Else
            Dim frm As New frmGerenciarLotes
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MnuSair.Click, btSair.Click
        If MsgBox("Tem certeza que deseja sair do sistema?", vbQuestion + vbYesNo, "Confirmação") = vbYes Then
            End
        End If
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Dim frm As New frmCadEmpresa
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub MnuParametrosSistema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuParametrosSistema.Click
        Dim frm As New frmCadParametros
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Define/atribui as variáveis globais que serão utilizadas no sistema
        CarregarParametrosSistema()
    End Sub

    Private Sub ConsultarNfse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarNfse.Click, btConsultarNfse.Click
        Dim frm As New frmLocalizarNfse
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class
