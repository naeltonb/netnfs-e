Imports NetNfs_e
Imports System.Security.Cryptography.X509Certificates
Imports System.ComponentModel

Public Class frmPrincipal

#Region "Variáveis"
    Private frmGerenciar As frmGerenciarLotes
    Private frmGerenciarLote As frmGerenciarLotes
    Private _certificado As New X509Certificate2
    Private fAuto As FuncoesAutomaticas
    Private bProcessoAtivo As Boolean = True
    Private item As ListViewItem
#End Region

#Region "Struturas"
    Private Enum TipoServico
        RECEPCAO_PROCESSAMENTO_LOTE_RPS
        GERACAO_NFSE
        CONSULTA_SITUACAO_LOTE_RPS
        CONSULTA_NFSE_POR_RPS
        CONSULTA_LOTE_RPS
        CONSULTA_NFSE
        CANCELAMENTO_NFSE
    End Enum

    Private Structure FuncoesAutomaticas
        Dim Assinar As String
        Dim Enviar As String
        Dim Verificar As String
        Dim Importar As String
        Dim EmailAuto As String
        Dim Arquivar As String
    End Structure
#End Region

#Region "Thead's segundo plano"

    Private Sub BGW1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW1.DoWork

        frmGerenciar = New frmGerenciarLotes(True)
        frmGerenciar.ShowInTaskbar = False
        frmGerenciar.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmGerenciar.Opacity = 0%
        frmGerenciar.Show()
        frmGerenciar.Hide()


        Dim segundoPlano As BackgroundWorker
        segundoPlano = CType(sender, BackgroundWorker)
        IniciarProcesso(segundoPlano)
        If (segundoPlano.CancellationPending = True) Then e.Cancel = True

        frmGerenciar.Close()

    End Sub

    Private Sub BGW1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW1.RunWorkerCompleted
        If bProcessoAtivo = True Then
            BGW1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BGW_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW.DoWork
        Do While 1 = 1

            If bProcessoAtivo = False Then
                lblMensagemStatus.Text = "Processo aumático interrompido!"
            End If

            System.Threading.Thread.Sleep(1000)
            If lblMensagemStatus.Visible = True Then
                lblMensagemStatus.Visible = False
            Else
                lblMensagemStatus.Visible = True
            End If
        Loop
    End Sub

#End Region


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

        Dim fCert As New CertificadoDigital


        'Carrega os parâmetros do sistema AutoNfs-e
        Dim conBd As New ConexaoBd
        Dim Sql As String = "Select * from tb_ConfigAutomatico"
        Dim dt As DataTable = conBd.Consultar(Sql, "tb_ConfigAutomatico")
        If dt.Rows.Count > 0 Then
            fAuto.Assinar = dt.Rows(0).Item("Assinar")
            fAuto.Enviar = dt.Rows(0).Item("Enviar")
            fAuto.Verificar = dt.Rows(0).Item("Importar")
            fAuto.Importar = dt.Rows(0).Item("EmailAuto")
            fAuto.EmailAuto = dt.Rows(0).Item("Arquivar")
            fAuto.Arquivar = dt.Rows(0).Item("Verificar")
            _certificado = fCert.SelecionarCertificado(dt.Rows(0).Item("SerieCertificado"))
        Else
            fAuto.Assinar = "NÃO"
            fAuto.Enviar = "NÃO"
            fAuto.Verificar = "NÃO"
            fAuto.Importar = "NÃO"
            fAuto.EmailAuto = "NÃO"
            fAuto.Arquivar = "NÃO"
            _certificado = fCert.SelecionarCertificado("")
        End If

        'Carrega os parâmetros do sistema NetNfs-e
        CarregarParametrosSistema()

        frmGerenciarLote = New frmGerenciarLotes(True)
        frmGerenciarLote.MdiParent = Me
        frmGerenciarLote.Show()

        BGW.RunWorkerAsync()
        BGW1.RunWorkerAsync()



        'Habilita o Timer e da início ao processo
        'Timer1.Enabled=True

    End Sub

    Private Sub btSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSair.Click
        Me.Hide()
    End Sub

    Private Sub btInterromper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInterromper.Click
        btInterromper.Visible = False
        btContinuar.Visible = True
        bProcessoAtivo = False
        lblMensagemStatus.ForeColor = Color.Red
        BGW1.CancelAsync()
    End Sub

    Private Sub btContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btContinuar.Click
        btContinuar.Visible = False
        btInterromper.Visible = True
        bProcessoAtivo = True
        lblMensagemStatus.ForeColor = Color.Blue
        BGW1.RunWorkerAsync()

    End Sub

    Private Sub MnuParametrosSistema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuParametrosSistema.Click
        Dim frmConfig As New frmConfiguracoes
        frmConfig.Show()

    End Sub

    Private Sub IniciarProcesso(ByVal processoAtivo As BackgroundWorker)
        Dim cont As Integer = 1
        'faz um loop pelo Listview verificando o status e chamando as funções
        For Each item In frmGerenciar.List.Items

            If (processoAtivo.CancellationPending = True) Then Exit For


            Try
                If item.SubItems(1).Text = "Não assinado" Then
                    If fAuto.Assinar = "SIM" Then
                        lblMensagemStatus.Text = "Assinando lote com certificado digital"

                    End If
                Else

                    Select Case item.SubItems(2).Text

                        Case "Não recebido"
                            If fAuto.Enviar = "SIM" Then
                                lblMensagemStatus.Text = "Enviando lote via WebService"
                                Dim servicos As New ServicosWs(TipoServico.RECEPCAO_PROCESSAMENTO_LOTE_RPS, item, _certificado)
                                servicos.EnviarRequisicao()
                            End If

                        Case "Não processado"

                            If fAuto.Verificar = "SIM" Then
                                lblMensagemStatus.Text = "Verificando status do lote"
                                Dim servicos As New ServicosWs(TipoServico.CONSULTA_SITUACAO_LOTE_RPS, item, _certificado)
                                servicos.EnviarRequisicao()
                            End If

                        Case "Processado com erro"

                            If fAuto.Importar = "SIM" Then
                                lblMensagemStatus.Text = "Importando mensagem de retorno"
                                Dim servicos As New ServicosWs(TipoServico.CONSULTA_LOTE_RPS, item, _certificado)
                                servicos.EnviarRequisicao()
                            End If

                        Case "Processado com sucesso"

                            If fAuto.Importar = "SIM" Then
                                lblMensagemStatus.Text = "Importando notas"
                                Dim servicos As New ServicosWs(TipoServico.CONSULTA_LOTE_RPS, item, _certificado)
                                servicos.EnviarRequisicao()
                            End If

                        Case "Notas importadas"

                            If fAuto.Arquivar = "SIM" Then
                                lblMensagemStatus.Text = "Arquivando lotes"
                                Dim servicos As New ServicosWs(TipoServico.CONSULTA_LOTE_RPS, item, _certificado)
                                servicos.EnviarRequisicao()
                            End If

                    End Select

                End If

            Catch ex As Exception
                lblMensagemStatus.Text = ex.Message
            End Try
        Next


    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        frmGerenciarLote.CarregarLista()
    End Sub
End Class