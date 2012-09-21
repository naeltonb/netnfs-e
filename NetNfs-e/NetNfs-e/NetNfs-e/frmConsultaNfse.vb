Imports System.Xml
Public Class frmConsultaNfse
    Private Dt_Nfse As DataTable

    Public Sub New(ByVal Dt As DataTable)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dt_Nfse = New DataTable
        Dt_Nfse = Dt
    End Sub

    Private Sub frmConsultaNfse_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Define o tamanho do formulário
        Me.Height = frmPrincipal.Height - 170
        Me.Width = frmPrincipal.Width - 60
        CentralizarForm(Me)
        Grid.DataSource = Dt_Nfse
        ConfigurarGrid()
    End Sub

    Private Sub btNovaConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNovaConsulta.Click
        Dim frm As New frmLocalizarNfse
        frm.MdiParent = frmPrincipal
        Me.Close()
        frm.Show()
    End Sub

    Private Sub ConfigurarGrid()

        Dim icol As Integer = Grid.Columns.Count
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

            End Select
        Next


    End Sub

    Private Sub btConfigTela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btConfigTela.Click
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
            xmlNfse.Save("C:\Temp\teste.xml")
            Dim form = New frmVisualizarXml("C:\Temp\teste.xml")
            form.Show()


        End If


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
            Dim frm As New frmImpressaoNfse(xmlNfse, "N")
            frm.Show()
        End If
    End Sub

    Private Sub btEnviarEmail_Click(sender As System.Object, e As System.EventArgs) Handles btEnviarEmail.Click

        Dim linhas As Integer
        linhas = Grid.SelectedRows.Count - 1

        If Grid.SelectedRows.Count <= 0 Then
            MsgBox("Nenhum registro selecionado!", vbExclamation, "Atenção")
        Else
            For index = 0 To linhas
                'Consulta a o xml da Nfse e carrega em um arquivo xmlDocument
                Dim Sql As String = "Select Xml from tb_Xml_Nfse where NumNota = '" & Grid.SelectedRows(index).Cells("NumNota").Value & "'"
                Dim conBd As New ConexaoBd
                Dim Dt As New DataTable
                Dt = conBd.Consultar(Sql, "tb_Xml_Nfse")
                Dim dr As DataRow = Dt.Rows(0)
                Dim xmlNfse As New XmlDocument
                xmlNfse.LoadXml(dr("Xml"))
                Dim frm As New frmImpressaoNfse(xmlNfse, "S")
                frm.WindowState = FormWindowState.Minimized
                frm.Show()
                frm.Close()
            Next
        End If
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class