Imports System.Xml
Imports System.Data.SqlClient
Public Class frmConsultaNfse

    Private SqlConsulta As String

    Public Sub New(ByVal Sql As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SqlConsulta = Sql
    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Sub frmConsultaNfse_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub CarregarCrid()
        Dim Dt_Nfse As New DataTable
        Dim conBd As New ConexaoBd
        Dt_Nfse = conBd.Consultar(SqlConsulta, "tb_Nfse")
        Grid.DataSource = Dt_Nfse
        Grid.Refresh()
        ConfigurarGrid()
        conBd = Nothing
        Dt_Nfse = Nothing
    End Sub

    Private Sub frmConsultaNfse_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Define o tamanho do formulário
        Me.Height = frmPrincipal.Height - 170
        Me.Width = frmPrincipal.Width - 60
        CentralizarForm(Me)
        CarregarCrid()
    End Sub

    Private Sub btNovaConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNovaConsulta.Click
        Dim frm As New frmLocalizarNfse
        frm.MdiParent = frmPrincipal
        Me.Close()
        frm.Show()
    End Sub

    Private Sub ConfigurarGrid()

        Dim icol As Integer = Grid.Columns.Count - 1
        For i As Integer = 0 To icol
            Select Case Grid.Columns.Item(i).Name
                Case "NumRps"
                    Grid.Columns.Item(i).HeaderText = "Nº do Rps"
                Case "NumNota"
                    Grid.Columns.Item(i).HeaderText = "Nº da Nota"
                Case "DataEmissao"
                    Grid.Columns.Item(i).HeaderText = "Data emissão"
                Case "NumLote"
                    Grid.Columns.Item(i).HeaderText = "Nº do Lote"
                Case "Serie"
                    Grid.Columns.Item(i).HeaderText = "Série"
                Case "Competencia"
                    Grid.Columns.Item(i).HeaderText = "Competência"
                Case "Tomador"
                    Grid.Columns.Item(i).HeaderText = "Tomador do serviço (cliente)"
                Case "Intermediario"
                    Grid.Columns.Item(i).HeaderText = "Intermediário do serviço"
                Case "OrgaoGerador"
                    Grid.Columns.Item(i).HeaderText = "Município de emissão"
                Case "CodigoObra"
                    Grid.Columns.Item(i).HeaderText = "Código da obra"
                Case "CodigoVerificacao"
                    Grid.Columns.Item(i).HeaderText = "Código de verificação"
                Case "ValorServico"
                    Grid.Columns.Item(i).HeaderText = "Valor do serviço"
                    Grid.Columns.Item(i).DefaultCellStyle.Format = "C2"
                Case "EmailTomador"
                    Grid.Columns.Item(i).HeaderText = "E-mail do tomador (cliente)"
                Case "StatusEnvioEmail"
                    Grid.Columns.Item(i).HeaderText = "Status e-mail"
                Case "StatusNfse"
                    Grid.Columns.Item(i).HeaderText = "Status da nota"

            End Select
        Next


    End Sub

    Private Sub btConfigTela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btConfigTela.Click
        Dim frm As New frmConfigTelaConsNfse
        frm.Show()
    End Sub

    Private Sub btImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimir.Click

        If Grid.SelectedRows.Count <= 0 Then
            MsgBox("Nenhum registro selecionado!", vbExclamation, "Atenção")
        Else

            'Consulta a o xml da Nfse e carrega em um arquivo xmlDocument
            Dim Sql As String = "Select Xml from tb_Xml_Nfse where NumNota = '" & Grid.CurrentRow.Cells("NumNota").Value & "'"
            Dim conBd As New ConexaoBd
            Dim Dt As New DataTable
            Dt = conBd.Consultar(Sql, "tb_Xml_Nfse")
            Dim dr As DataRow = Dt.Rows(0)
            Dim xmlNfse As New XmlDocument
            xmlNfse.LoadXml(dr("Xml"))
            Dim frm As New frmImpressaoNfse(xmlNfse)
            frm.Show()
        End If
    End Sub

    Private Sub btEnviarEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEnviarEmail.Click

        If Grid.SelectedRows.Count <= 0 Then
            MsgBox("Nenhum registro selecionado!", vbExclamation, "Atenção")
        Else
            If MsgBox("Tem certeza que deseja enviar e-mail para os cliente selecionados?", vbQuestion + vbYesNo, "Confirmação") = vbYes Then
                Me.WindowState = FormWindowState.Minimized
                Me.ControlBox = False
                ProcessoEnvioEmailAtivo = True
                frmPrincipal.IniciarEnvioEmailCliente(Me)
            End If
        End If
    End Sub

    Private Sub btVisualizarXml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btVisualizarXml.Click
        If Grid.SelectedRows.Count <= 0 Then
            MsgBox("Nenhum registro selecionado!", vbExclamation, "Atenção")
        ElseIf Grid.SelectedRows.Count > 1 Then
            MsgBox("Selecione somente um registro para visualização!", vbExclamation, "Atenção")
        Else
            'Consulta a o xml da Nfse e carrega em um arquivo xmlDocument
            Dim Sql As String = "Select Xml from tb_Xml_Nfse where NumNota = '" & Grid.CurrentRow.Cells("NumNota").Value & "'"
            Dim conBd As New ConexaoBd
            Dim Dt As New DataTable
            Dt = conBd.Consultar(Sql, "tb_Xml_Nfse")
            Dim dr As DataRow = Dt.Rows(0)
            Dim xmlNfse As New XmlDocument
            xmlNfse.LoadXml(dr("Xml"))
            Dim UrlView As String = My.Application.Info.DirectoryPath & "\Temp\ViewXmlNfse" & Grid.CurrentRow.Cells("NumNota").Value & ".xml"
            xmlNfse.Save(UrlView)
            Dim form = New frmVisualizarXml(UrlView)
            form.Show()
        End If
    End Sub

    Private Sub btExcluirNfse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcluirNfse.Click
        If Grid.SelectedRows.Count <= 0 Then
            MsgBox("Nenhum registro selecionado!", vbExclamation, "Atenção")
        Else
            If MsgBox("Tem certeza que deseja excluir permanentemente as notas selecionadas?", vbQuestion + vbYesNo + vbDefaultButton2, "Confirmação") = vbYes Then
                Dim Sql As String
                Dim conBd As New ConexaoBd
                Dim transaction As SqlTransaction
                'Inicia transação com banco de dados
                transaction = conBd.ConnBd.BeginTransaction
                Try

                    Dim linhas As Integer = Grid.SelectedRows.Count - 1
                    For _index = 0 To linhas
                        Sql = "Delete from tb_Nfse where NumNota = '" & Grid.SelectedRows(_index).Cells("NumNota").Value & "'"
                        conBd.ExecutarSqlTransacao(Sql, transaction)
                    Next
                    transaction.Commit()
                    CarregarCrid()

                    MsgBox("Notas deletadas com sucesso!", vbInformation, "Confirmação")
                Catch ex As Exception
                    transaction.Rollback()
                    MsgBox("Ocorreu um erro tentar deletar as notas" & Chr(13) & ex.Message, vbCritical, "Erro")
                    Err.Clear()
                End Try
            End If
        End If
    End Sub


    Private Sub btAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAtualizar.Click
        CarregarCrid()
    End Sub
End Class