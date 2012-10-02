Imports WsNfs_e
Imports System.Security.Cryptography.X509Certificates
Public Class frmExecutar
    Implements IDisposable

#Region "Variáveis"
    Private cont As Integer
    Private strErro As String = ""
    Private _tipoServico As New WsNfse.TipoServico
    Private _itemListView As New ListViewItem
    Private _frmGerenciar As frmGerenciarLotes
    Private _certificado As New X509Certificate2
#End Region

#Region "Propriedades"
    Public WriteOnly Property TipoServico As WsNfse.TipoServico
        Set(ByVal value As WsNfse.TipoServico)
            _tipoServico = value
        End Set
    End Property

    Public WriteOnly Property ItemListView As ListViewItem
        Set(ByVal value As ListViewItem)
            _itemListView = value
        End Set
    End Property

    Public WriteOnly Property frmGerenciar As frmGerenciarLotes
        Set(ByVal value As frmGerenciarLotes)
            _frmGerenciar = value
        End Set
    End Property

    Public WriteOnly Property Certificado As X509Certificate2
        Set(ByVal value As X509Certificate2)
            _certificado = value
        End Set
    End Property
#End Region

#Region "Funções Privadas"
    Private Sub frmExecutar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Centraliza os componentes
        Dim Px As Double
        Dim Py As Double
        cont = 1
        Px = (Me.Width - Barra.Width) / 2
        Py = (Me.Height - Barra.Height) / 2
        Barra.Location = New Point(Px, Py)
        Label2.Location = New Point(Px, (Py - 24))

        'Executa em segundo plano
        Barra.Style = ProgressBarStyle.Marquee
        Application.DoEvents()
        BGW.WorkerReportsProgress = True
        BGW.WorkerSupportsCancellation = True
        BGW.RunWorkerAsync()
    End Sub

    Private Sub BGW_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW.DoWork
        Try
            Dim servicos As New ServicosWs(_tipoServico, _itemListView, _certificado)
            servicos.EnviarRequisicao()
        Catch ex As Exception
            strErro = ex.Message
        End Try
    End Sub

    Private Sub BGW_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW.RunWorkerCompleted
        Timer1.Enabled = False
        Me.Visible = False
        If strErro = "" Then
            _frmGerenciar.CarregarLista(strDiretorioNFSe)

            If RetornoMsg.Situacao = 3 Or RetornoMsg.Situacao = 4 Then
                If MsgBox(RetornoMsg.MsgRetorno, RetornoMsg.StyleMsgBox, RetornoMsg.TituloMsg) = vbYes Then
                    Me.Visible = True
                    Me._tipoServico = WsNfse.TipoServico.CONSULTA_LOTE_RPS
                    BGW.RunWorkerAsync()
                Else
                    Me.Close()
                    Me.Finalize()
                End If
            Else
                MsgBox(RetornoMsg.MsgRetorno, RetornoMsg.StyleMsgBox, RetornoMsg.TituloMsg)
                Me.Close()
                Me.Finalize()
            End If
        Else
            MsgBox(strErro, MsgBoxStyle.Critical, "Erro")
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If BGW.WorkerReportsProgress = True Then
            BGW.ReportProgress(cont * 1)
            cont = cont + 1
        End If
    End Sub

    'Destroi as variáveis liberando memória
    Protected Overrides Sub Finalize()
        cont = Nothing
        strErro = Nothing
        _tipoServico = Nothing
        _itemListView = Nothing
        _frmGerenciar = Nothing
        _certificado = Nothing
    End Sub
#End Region

End Class