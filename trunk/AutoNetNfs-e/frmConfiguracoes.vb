Imports NetNfs_e
Imports System.Security.Cryptography.X509Certificates
Public Class frmConfiguracoes

#Region "Eventos"

    Private Sub frmConfiguracoes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CarregarDados()
    End Sub

    Private Sub chkAssinar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAssinar.CheckedChanged
        If chkAssinar.Checked = True Then
            chkAssinar.Tag = "SIM"
        Else
            chkAssinar.Tag = "NAO"
        End If
    End Sub

    Private Sub chkEnviar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnviar.CheckedChanged
        If chkEnviar.Checked = True Then
            chkEnviar.Tag = "SIM"
        Else
            chkEnviar.Tag = "NAO"
        End If
    End Sub

    Private Sub chkVerificar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVerificar.CheckedChanged
        If chkVerificar.Checked = True Then
            chkVerificar.Tag = "SIM"
        Else
            chkVerificar.Tag = "NAO"
        End If
    End Sub

    Private Sub chkImportar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkImportar.CheckedChanged
        If chkImportar.Checked = True Then
            chkImportar.Tag = "SIM"
        Else
            chkImportar.Tag = "NAO"
        End If
    End Sub

    Private Sub chkEmail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEmail.CheckedChanged
        If chkEmail.Checked = True Then
            chkEmail.Tag = "SIM"
        Else
            chkEmail.Tag = "NAO"
        End If
    End Sub

    Private Sub chkArquivar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkArquivar.CheckedChanged
        If chkArquivar.Checked = True Then
            chkArquivar.Tag = "SIM"
        Else
            chkArquivar.Tag = "NAO"
        End If
    End Sub

#End Region


    Private Sub CarregarDados()
        Try

            Dim conBd As New ConexaoBd
            Dim Sql As String = "Select * from tb_ConfigAutomatico"
            Dim dt As DataTable = conBd.Consultar(Sql, "tb_ConfigAutomatico")

            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)

                If dr("Assinar") = "SIM" Then
                    chkAssinar.Checked = True
                Else
                    chkAssinar.Checked = False
                End If

                If dr("Enviar") = "SIM" Then
                    chkEnviar.Checked = True
                Else
                    chkEnviar.Checked = False
                End If

                If dr("Verificar") = "SIM" Then
                    chkVerificar.Checked = True
                Else
                    chkVerificar.Checked = False
                End If

                If dr("Importar") = "SIM" Then
                    chkImportar.Checked = True
                Else
                    chkImportar.Checked = False
                End If

                If dr("EmailAuto") = "SIM" Then
                    chkEmail.Checked = True
                Else
                    chkEmail.Checked = False
                End If

                If dr("Arquivar") = "SIM" Then
                    chkArquivar.Checked = True
                Else
                    chkArquivar.Checked = False
                End If

                txtSerieCertificado.Text = dr("SerieCertificado")

                dr = Nothing
            Else

                chkAssinar.Checked = False
                chkEnviar.Checked = False
                chkVerificar.Checked = False
                chkImportar.Checked = False
                chkEmail.Checked = False
                chkArquivar.Checked = False

            End If

            'Destroi as variáveis utilizadas
            conBd = Nothing
            Sql = Nothing
            dt = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SalvarDados()
        Try

            Dim conBd As New ConexaoBd
            Dim Sql As String = "Select * from tb_ConfigAutomatico"
            Dim dt As DataTable = conBd.Consultar(Sql, "tb_ConfigAutomatico")

            If dt.Rows.Count > 0 Then
                Sql = "Update tb_ConfigAutomatico set Assinar = '" & chkAssinar.Tag & "', Enviar = '" & chkEnviar.Tag & "', Verificar = '" & chkVerificar.Tag & "', Importar = '" & chkImportar.Tag & "', EmailAuto = '" & chkEmail.Tag & "', Arquivar = '" & chkArquivar.Tag & "',SerieCertificado = '" & txtSerieCertificado.Text & "'"
            Else
                Sql = "Insert into tb_ConfigAutomatico(Assinar,Enviar,Verificar,Importar,EmailAuto,Arquivar,SerieCertificado) values ('" & chkAssinar.Tag & "','" & chkEnviar.Tag & "','" & chkVerificar.Tag & "','" & chkImportar.Tag & "','" & chkEmail.Tag & "','" & chkArquivar.Tag & "','" & txtSerieCertificado.Text & "')"
            End If

            conBd.ExecutarSql(Sql)
            MsgBox("Dados atualizados com sucesso!", vbInformation, "Confirmação")
            'Destroi as variáveis utilizadas
            conBd = Nothing
            Sql = Nothing
            dt = Nothing
        Catch ex As Exception
            MsgBox("Ocorreu em erro durante a inserção/atualização dos dados" & Chr(13) & ex.Message, vbCritical, "Erro")
        End Try
    End Sub


    Private Sub btSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSalvar.Click
        If MsgBox("Tem certeza que deseja salvar as configurações?", vbQuestion + vbYesNo, "Confirmação") = vbYes Then
            SalvarDados()
            GroupDados.Enabled = False
            GroupBox1.Enabled = False
        End If
    End Sub

    Private Sub btEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEditar.Click
        GroupDados.Enabled = True
        GroupBox1.Enabled = True
    End Sub

    Private Sub btCertificado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCertificado.Click
        Try
            Dim certificado As New X509Certificate2
            Dim fcert As New CertificadoDigital
            certificado = fcert.SelecionarCertificado("")
            txtSerieCertificado.Text = certificado.SerialNumber
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Erro")
            Err.Clear()
        End Try


    End Sub
End Class