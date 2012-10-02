Imports System.Windows.Forms

Public Class frmPrincipal
    Private cont As Integer
    Private MsgEnvioEmail As String
    Private frmConsultNfse As frmConsultaNfse
    Private Property m_ChildFormNumber As Integer


    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, btAbrirLote.Click

        If ParametrosCarregados = False Then
            MsgBox(strMsgParametros, vbExclamation, "Atenção")
        Else
            Dim frm As New frmGerenciarLotes
            frm.MdiParent = Me
            frm.Show()
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MnuSair.Click, btSair.Click
        If ProcessoEnvioEmailAtivo = False Then
            If MsgBox("Tem certeza que deseja sair do sistema?", vbQuestion + vbYesNo, "Confirmação") = vbYes Then
                End
            End If
        Else
            MsgBox("O sistema está enviando e-mail aos clientes. Favor aguardar o processamento antes de utilizar esta função", vbExclamation, "Atenção")
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

    Private Sub frmPrincipal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ProcessoEnvioEmailAtivo = False Then
            If MsgBox("Tem certeza que deseja sair do sistema?", vbQuestion + vbYesNo, "Confirmação") = vbYes Then
                End
            Else
                e.Cancel = True
            End If
        Else
            MsgBox("O sistema está enviando e-mail aos clientes. Favor aguardar o processamento antes de utilizar esta função", vbExclamation, "Atenção")
            e.Cancel = True
        End If

    End Sub


    Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Define/atribui as variáveis globais que serão utilizadas no sistema
        CarregarParametrosSistema()
    End Sub

    Private Sub ConsultarNfse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarNfse.Click, btConsultarNfse.Click
        If ProcessoEnvioEmailAtivo = False Then
            Dim frm As New frmLocalizarNfse
            frm.MdiParent = Me
            frm.Show()
        Else
            MsgBox("O sistema está enviando e-mail aos clientes. Favor aguardar o processamento antes de utilizar esta função", vbExclamation, "Atenção")
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim frmSobre As New frmSobreSistema
        frmSobre.MdiParent = Me
        frmSobre.Show()
    End Sub

    Private Sub MnuCadUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuCadUsuarios.Click
        Dim frmUsuarios As New frmCadUsuarios
        frmUsuarios.MdiParent = Me
        frmUsuarios.Show()
    End Sub


    Public Sub IniciarEnvioEmailCliente(ByVal frm As frmConsultaNfse)
        frmConsultNfse = New frmConsultaNfse
        frmConsultNfse = frm
        'Executa em segundo plano
        Timer1.Enabled = True
        BarraStatus.Visible = True
        BarraStatus.Style = ProgressBarStyle.Marquee
        Application.DoEvents()
        BGW.WorkerReportsProgress = True
        BGW.WorkerSupportsCancellation = True
        BGW.RunWorkerAsync()
    End Sub

    Private Sub BGW_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW.DoWork
        lblMensagemStatus.Text = "Enviando e-mails"
        Dim enviarEmail As New EnviarEmailCliente
        enviarEmail.GridView = frmConsultNfse.Grid
        MsgEnvioEmail = "Inicio"
        MsgEnvioEmail = enviarEmail.Enviar()
    End Sub

    Private Sub BGW_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW.RunWorkerCompleted

        If MsgEnvioEmail = "" Then
            lblMensagemStatus.Text = "E-mails enviados com sucesso"
            frmConsultNfse.Close()
            MsgBox("Os e-mails foram enviados com sucesso!", vbInformation, "Confirmação")
        Else
            lblMensagemStatus.ForeColor = Color.Red
            lblMensagemStatus.Text = "Ocorreu um erro ao enviar os e-mails"
            frmConsultNfse.WindowState = FormWindowState.Normal
            frmConsultNfse.ControlBox = True
            MsgBox(MsgEnvioEmail, vbExclamation, "Atenção")
            lblMensagemStatus.ForeColor = Color.Blue
        End If
        BarraStatus.Style = ProgressBarStyle.Blocks
        BarraStatus.Visible = False
        ProcessoEnvioEmailAtivo = False
        lblMensagemStatus.Text = ""
        Timer1.Enabled = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            If BGW.WorkerReportsProgress = True Then
                BGW.ReportProgress(cont * 1)
                cont = cont + 1
            End If

            If lblMensagemStatus.Visible = True Then
                lblMensagemStatus.Visible = False
            Else
                lblMensagemStatus.Visible = True
            End If
        Catch ex As Exception
            Timer1.Enabled = False
            Err.Clear()
        End Try

    End Sub

    Private Sub MnuLogOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuLogOff.Click, btLogOff.Click
        If ProcessoEnvioEmailAtivo = False Then
            If MsgBox("Tem certeza que deseja efetuar logoff?", vbQuestion + vbYesNo, "Confirmação") = vbYes Then
                Me.Hide()
                frmLogin.Show()
            End If
        Else
            MsgBox("O sistema está enviando e-mail aos clientes. Favor aguardar o processamento antes de utilizar esta função", vbExclamation, "Atenção")
        End If
    End Sub

End Class
