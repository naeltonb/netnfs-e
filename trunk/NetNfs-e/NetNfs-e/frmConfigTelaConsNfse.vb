Public Class frmConfigTelaConsNfse

    Private Sub frmConfigTelaConsNfse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CentralizarForm(Me)

        'Carrega os itens na lista na sua respectiva ordem
        Dim Sql As String = "Select Nome_Coluna,Titulo_Coluna,Coluna_Visivel from tb_ConfigGridNfse order by Index_Coluna"
        Dim conBd As New ConexaoBd
        Dim Dt_Config As New DataTable
        Dt_Config = conBd.Consultar(Sql, "tb_ConfigGridNfse")

        For Each dr As DataRow In Dt_Config.Rows
            Dim item As New ListViewItem
            item.Text = dr("Titulo_Coluna")
            item.Tag = dr("Nome_Coluna")

            If dr("Coluna_Visivel") = "SIM" Then
                item.Checked = True
            Else
                item.Checked = False
            End If

            List.Items.Add(item)
        Next
    End Sub

    Private Sub btSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSair.Click

        'Salva as alteraço e fecha e formulário
        Dim Sql As String = ""
        Dim strVisivel As String = ""
        Dim conBd As New ConexaoBd
        For i As Integer = 0 To List.Items.Count - 1
            Try
                If List.Items(i).Checked = True Then
                    strVisivel = "SIM"
                Else
                    strVisivel = "NÃO"
                End If


                Sql = "Update tb_ConfigGridNfse set Index_Coluna = '" & i & "',Coluna_Visivel = '" & strVisivel & "' where Nome_Coluna = '" & List.Items(i).Tag & "'"
                conBd.ExecutarSql(Sql)
            Catch ex As Exception
                MsgBox("Erro ao tentar atualizar as configurações" & Chr(13) & ex.Message)
                Exit For
            End Try
        Next

        'Força a visualização do campo NumNota
        Sql = "Update tb_ConfigGridNfse set Coluna_Visivel = 'SIM' where Nome_Coluna = 'NumNota'"
        conBd.ExecutarSql(Sql)


        Me.Close()
    End Sub

    Private Sub bt1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt1.Click

        If (List.SelectedItems.Count > 0) Then
            ' Se houver, pego o primeiro item selecionado. Ele é quem vai
            ' subir uma posição na lista
            Dim lvi As ListViewItem = List.SelectedItems(0)
            ' Para subir uma posição, pego a posição atual dele na lista
            ' e tiro 1
            Dim pos As Integer = List.Items.IndexOf(lvi) - 1
            ' Se o item já for o primeiro da lista, não faço nada
            If pos >= 0 Then
                ' senão, removo ele da posição atual...
                List.Items.Remove(lvi)
                ' ... e o adiciono na posição imediatamente acima 
                List.Items.Insert(pos, lvi)
                List.Select()
            End If
        End If
    End Sub

    Private Sub bt2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt2.Click
        If (List.SelectedItems.Count > 0) Then
            Dim lvi As ListViewItem = List.SelectedItems(0)
            ' ... eu somar uma posição aqui, para ele ir para baixo...
            Dim pos As Integer = List.Items.IndexOf(lvi) + 1
            ' ... e verificar se já não está na ultima posição
            If pos < List.Items.Count Then
                List.Items.Remove(lvi)
                List.Items.Insert(pos, lvi)
                List.Select()
            End If
        End If
    End Sub

End Class