Imports System.Xml

Public Class EnviarEmailCliente
    Private Grid As DataGridView

    Public WriteOnly Property GridView As DataGridView
        Set(ByVal value As DataGridView)
            Grid = value
        End Set
    End Property


    Friend Function Enviar() As String
        Try
            Dim linhas As Integer = Grid.SelectedRows.Count - 1
            For index = 0 To linhas
                'Consulta a o xml da Nfse e carrega em um arquivo xmlDocument
                Dim Sql As String = "Select Xml from tb_Xml_Nfse where NumNota = '" & Grid.SelectedRows(index).Cells("NumNota").Value & "'"
                Dim conBd As New ConexaoBd
                Dim Dt As New DataTable
                Dt = conBd.Consultar(Sql, "tb_Xml_Nfse")
                Dim dr As DataRow = Dt.Rows(0)
                Dim xmlNfse As New XmlDocument
                xmlNfse.LoadXml(dr("Xml"))
                Dim frm As New frmImpressaoNfse(xmlNfse)
                frm.WindowState = FormWindowState.Minimized
                frm.Show()
                frm.EnviarEmail()
                frm.Close()
            Next

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
End Class
