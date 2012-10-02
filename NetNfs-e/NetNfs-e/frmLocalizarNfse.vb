Public Class frmLocalizarNfse

    Private Sub frmLocalizarNfse_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = 27 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmLocalizarNfse_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CentralizarForm(Me)
        CarregarComboBox()
    End Sub


    Private Sub btLocalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLocalizar.Click
        Dim strCamposNfse As String = ""
        Dim conBd As New ConexaoBd
        Dim Dt_Config As New DataTable
        Dim Sql As String = "Select Nome_Coluna,Index_Coluna,Coluna_Visivel from tb_ConfigGridNfse order by Index_Coluna"
        Dt_Config = conBd.Consultar(Sql, "tb_ConfigGridNfse")

        If Dt_Config.Rows.Count > 0 Then
            For Each dr As DataRow In Dt_Config.Rows
                If dr("Coluna_Visivel") = "SIM" Then
                    If strCamposNfse = "" Then
                        strCamposNfse = dr("Nome_Coluna")
                    Else
                        strCamposNfse = strCamposNfse & "," & dr("Nome_Coluna")
                    End If
                End If
            Next
            Sql = "Select " & strCamposNfse & " from tb_Nfse"
        Else
            Sql = "Select * from tb_Nfse"
        End If

        Sql = Sql & ClausulaWhere()



        'Chama o formulário de Consulta Nfse
        Dim frm As New frmConsultaNfse(Sql)
        frm.MdiParent = frmPrincipal
        frm.Show()

        'Destroi variáveis e libera memória
        strCamposNfse = Nothing
        conBd = Nothing
        Dt_Config = Nothing
        Sql = Nothing

        Me.Close()
    End Sub

    Private Sub CarregarComboBox()
        Dim Sql As String = ""
        Dim conBd As New ConexaoBd

        Sql = "Select Tomador from tb_Nfse group by Tomador order by Tomador"
        Dim dt As DataTable = conBd.Consultar(Sql, "tb_Nfse")
        txtTomador.DataSource = dt
        txtTomador.DisplayMember = "Tomador"
        txtTomador.ValueMember = "Tomador"

        txtTomador.AutoCompleteMode = AutoCompleteMode.Suggest
        txtTomador.AutoCompleteSource = AutoCompleteSource.ListItems
        txtTomador.Text = ""

    End Sub

    Private Function ClausulaWhere() As String
        Dim strString As String = ""
        Dim bVer As Boolean = False

        If txtNumRps.Text <> "" Then
            If bVer = False Then
                strString = "NumRps = '" & txtNumRps.Text & "'"
                bVer = True
            End If
        End If

        If txtNumLote.Text <> "" Then
            If bVer = False Then
                strString = "NumLote = '" & txtNumLote.Text & "'"
                bVer = True
            Else
                strString = strString & " and NumLote = '" & txtNumLote.Text & "'"
            End If
        End If

        If txtNumNfse.Text <> "" Then
            If bVer = False Then
                strString = "NumNota = '" & txtNumNfse.Text & "'"
                bVer = True
            Else
                strString = strString & " and NumNota = '" & txtNumNfse.Text & "'"
            End If
        End If


        If txtDataEmissao1.Text <> "  /  /" And txtDataEmissao2.Text <> "  /  /" Then
            If bVer = False Then
                strString = "Convert(char(10),DataEmissao,103) >= '" & txtDataEmissao1.Text & "' and Convert(char(10),DataEmissao,103) <= '" & txtDataEmissao2.Text & "'"
                bVer = True
            Else
                strString = strString & " and Convert(char(10),DataEmissao,103) >= '" & txtDataEmissao1.Text & "' and Convert(char(10),DataEmissao,103) <= '" & txtDataEmissao2.Text & "'"
            End If
        ElseIf txtDataEmissao1.Text <> "  /  /" Then
            If bVer = False Then
                strString = "Convert(char(10),DataEmissao,103) = '" & txtDataEmissao1.Text & "'"
                bVer = True
            Else
                strString = strString & " and Convert(char(10),DataEmissao,103) = '" & txtDataEmissao1.Text & "'"
            End If
        ElseIf txtDataEmissao2.Text <> "  /  /" Then
            If bVer = False Then
                strString = "Convert(char(10),DataEmissao,103) = '" & txtDataEmissao2.Text & "'"
                bVer = True
            Else
                strString = strString & " and Convert(char(10),DataEmissao,103) = '" & txtDataEmissao2.Text & "'"
            End If
        End If



        If txtDataCompetencia1.Text <> "  /  /" And txtDataCompetencia2.Text <> "  /  /" Then
            If bVer = False Then
                strString = "Convert(char(10),Competencia,103) >= '" & txtDataCompetencia1.Text & "' and Convert(char(10),Competencia,103) <= '" & txtDataCompetencia2.Text & "'"
                bVer = True
            Else
                strString = strString & " and Convert(char(10),Competencia,103) >= '" & txtDataCompetencia1.Text & "' and Convert(char(10),Competencia,103) <= '" & txtDataCompetencia2.Text & "'"
            End If
        ElseIf txtDataCompetencia1.Text <> "  /  /" Then
            If bVer = False Then
                strString = "Convert(char(10),Competencia,103) = '" & txtDataCompetencia1.Text & "'"
                bVer = True
            Else
                strString = strString & " and Convert(char(10),Competencia,103) = '" & txtDataCompetencia1.Text & "'"
            End If
        ElseIf txtDataCompetencia2.Text <> "  /  /" Then
            If bVer = False Then
                strString = "Convert(char(10),Competencia,103) = '" & txtDataCompetencia2.Text & "'"
                bVer = True
            Else
                strString = strString & " and Convert(char(10),Competencia,103) = '" & txtDataCompetencia2.Text & "'"
            End If
        End If

        If txtStatusEmail.Text <> "" Then
            If bVer = False Then
                strString = "StatusEnvioEmail = '" & txtStatusEmail.Text & "'"
                bVer = True
            Else
                strString = strString & " and StatusEnvioEmail = '" & txtStatusEmail.Text & "'"
            End If
        End If

        If txtStatusNfse.Text <> "" Then
            If bVer = False Then
                strString = "StatusNfse = '" & txtStatusNfse.Text & "'"
                bVer = True
            Else
                strString = strString & " and StatusNfse = '" & txtStatusNfse.Text & "'"
            End If
        End If



        If txtTomador.Text <> "" Then
            If bVer = False Then
                strString = "Tomador = '" & txtTomador.Text & "'"
                bVer = True
            Else
                strString = strString & " and Tomador = '" & txtTomador.Text & "'"
            End If
        End If

        If bVer = True Then
            strString = " Where " & strString
        End If

        Return strString

    End Function

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtDataEmissao1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDataEmissao1.LostFocus
        ValidarData(txtDataEmissao1)
    End Sub

    Private Sub txtDataEmissao2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDataEmissao2.LostFocus
        ValidarData(txtDataEmissao2)
    End Sub

    Private Sub txtDataCompetencia1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDataCompetencia1.LostFocus
        ValidarData(txtDataCompetencia1)
    End Sub

    Private Sub txtDataCompetencia2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDataCompetencia2.LostFocus
        ValidarData(txtDataCompetencia2)
    End Sub

    Private Sub txtTomador_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTomador.LostFocus
        txtTomador.Text = UCase(txtTomador.Text)
    End Sub

End Class