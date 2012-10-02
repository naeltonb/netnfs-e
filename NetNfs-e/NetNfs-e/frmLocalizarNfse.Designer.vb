<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLocalizarNfse
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLocalizarNfse))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtStatusNfse = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtStatusEmail = New System.Windows.Forms.ComboBox()
        Me.btCancelar = New System.Windows.Forms.Button()
        Me.btLocalizar = New System.Windows.Forms.Button()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.txtTomador = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDataCompetencia2 = New System.Windows.Forms.MaskedTextBox()
        Me.txtDataCompetencia1 = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDataEmissao2 = New System.Windows.Forms.MaskedTextBox()
        Me.txtDataEmissao1 = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.txtNumRps = New System.Windows.Forms.TextBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.txtNumLote = New System.Windows.Forms.TextBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.txtNumNfse = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.btCancelar)
        Me.GroupBox1.Controls.Add(Me.btLocalizar)
        Me.GroupBox1.Controls.Add(Me.GroupBox15)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.GroupBox13)
        Me.GroupBox1.Controls.Add(Me.GroupBox11)
        Me.GroupBox1.Controls.Add(Me.GroupBox12)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(8, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(644, 239)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opções para localizar"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtStatusNfse)
        Me.GroupBox5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(12, 136)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(140, 51)
        Me.GroupBox5.TabIndex = 6
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Status Nfs-e"
        '
        'txtStatusNfse
        '
        Me.txtStatusNfse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtStatusNfse.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatusNfse.FormattingEnabled = True
        Me.txtStatusNfse.Items.AddRange(New Object() {"", "NORMAL", "CANCELADA", "SUBSTITUIDA"})
        Me.txtStatusNfse.Location = New System.Drawing.Point(10, 20)
        Me.txtStatusNfse.Name = "txtStatusNfse"
        Me.txtStatusNfse.Size = New System.Drawing.Size(123, 24)
        Me.txtStatusNfse.TabIndex = 13
        Me.txtStatusNfse.Tag = "SIM"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtStatusEmail)
        Me.GroupBox4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(495, 79)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(140, 51)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Status e-mail"
        '
        'txtStatusEmail
        '
        Me.txtStatusEmail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtStatusEmail.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatusEmail.FormattingEnabled = True
        Me.txtStatusEmail.Items.AddRange(New Object() {"", "ENVIADO", "NÃO ENVIADO"})
        Me.txtStatusEmail.Location = New System.Drawing.Point(10, 20)
        Me.txtStatusEmail.Name = "txtStatusEmail"
        Me.txtStatusEmail.Size = New System.Drawing.Size(123, 24)
        Me.txtStatusEmail.TabIndex = 13
        Me.txtStatusEmail.Tag = "SIM"
        '
        'btCancelar
        '
        Me.btCancelar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCancelar.ForeColor = System.Drawing.Color.Black
        Me.btCancelar.Image = CType(resources.GetObject("btCancelar.Image"), System.Drawing.Image)
        Me.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btCancelar.Location = New System.Drawing.Point(317, 193)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(245, 38)
        Me.btCancelar.TabIndex = 9
        Me.btCancelar.Text = "&Cancelar localização"
        Me.btCancelar.UseVisualStyleBackColor = True
        '
        'btLocalizar
        '
        Me.btLocalizar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btLocalizar.ForeColor = System.Drawing.Color.Black
        Me.btLocalizar.Image = CType(resources.GetObject("btLocalizar.Image"), System.Drawing.Image)
        Me.btLocalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btLocalizar.Location = New System.Drawing.Point(77, 193)
        Me.btLocalizar.Name = "btLocalizar"
        Me.btLocalizar.Size = New System.Drawing.Size(217, 38)
        Me.btLocalizar.TabIndex = 8
        Me.btLocalizar.Text = "&Localizar dados"
        Me.btLocalizar.UseVisualStyleBackColor = True
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.txtTomador)
        Me.GroupBox15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox15.Location = New System.Drawing.Point(161, 136)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(477, 51)
        Me.GroupBox15.TabIndex = 7
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Tomador do serviço (cliente)"
        '
        'txtTomador
        '
        Me.txtTomador.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTomador.FormattingEnabled = True
        Me.txtTomador.Location = New System.Drawing.Point(10, 20)
        Me.txtTomador.Name = "txtTomador"
        Me.txtTomador.Size = New System.Drawing.Size(460, 24)
        Me.txtTomador.TabIndex = 13
        Me.txtTomador.Tag = "SIM"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtDataCompetencia2)
        Me.GroupBox3.Controls.Add(Me.txtDataCompetencia1)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(253, 79)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(236, 51)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Período de competência"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(110, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "a"
        '
        'txtDataCompetencia2
        '
        Me.txtDataCompetencia2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataCompetencia2.Location = New System.Drawing.Point(128, 22)
        Me.txtDataCompetencia2.Mask = "00/00/0000"
        Me.txtDataCompetencia2.Name = "txtDataCompetencia2"
        Me.txtDataCompetencia2.Size = New System.Drawing.Size(101, 23)
        Me.txtDataCompetencia2.TabIndex = 5
        Me.txtDataCompetencia2.ValidatingType = GetType(Date)
        '
        'txtDataCompetencia1
        '
        Me.txtDataCompetencia1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataCompetencia1.Location = New System.Drawing.Point(8, 22)
        Me.txtDataCompetencia1.Mask = "00/00/0000"
        Me.txtDataCompetencia1.Name = "txtDataCompetencia1"
        Me.txtDataCompetencia1.Size = New System.Drawing.Size(100, 23)
        Me.txtDataCompetencia1.TabIndex = 4
        Me.txtDataCompetencia1.ValidatingType = GetType(Date)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtDataEmissao2)
        Me.GroupBox2.Controls.Add(Me.txtDataEmissao1)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 79)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(235, 51)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Período de emissão"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(110, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "a"
        '
        'txtDataEmissao2
        '
        Me.txtDataEmissao2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataEmissao2.Location = New System.Drawing.Point(128, 22)
        Me.txtDataEmissao2.Mask = "00/00/0000"
        Me.txtDataEmissao2.Name = "txtDataEmissao2"
        Me.txtDataEmissao2.Size = New System.Drawing.Size(101, 23)
        Me.txtDataEmissao2.TabIndex = 4
        Me.txtDataEmissao2.ValidatingType = GetType(Date)
        '
        'txtDataEmissao1
        '
        Me.txtDataEmissao1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataEmissao1.Location = New System.Drawing.Point(8, 22)
        Me.txtDataEmissao1.Mask = "00/00/0000"
        Me.txtDataEmissao1.Name = "txtDataEmissao1"
        Me.txtDataEmissao1.Size = New System.Drawing.Size(100, 23)
        Me.txtDataEmissao1.TabIndex = 3
        Me.txtDataEmissao1.ValidatingType = GetType(Date)
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.txtNumRps)
        Me.GroupBox13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox13.Location = New System.Drawing.Point(12, 22)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(185, 51)
        Me.GroupBox13.TabIndex = 0
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Nº do Rps"
        '
        'txtNumRps
        '
        Me.txtNumRps.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumRps.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumRps.Location = New System.Drawing.Point(8, 22)
        Me.txtNumRps.Name = "txtNumRps"
        Me.txtNumRps.Size = New System.Drawing.Size(171, 23)
        Me.txtNumRps.TabIndex = 0
        Me.txtNumRps.Tag = "SIM"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.txtNumLote)
        Me.GroupBox11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox11.Location = New System.Drawing.Point(203, 22)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(210, 51)
        Me.GroupBox11.TabIndex = 1
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Nº do Lote"
        '
        'txtNumLote
        '
        Me.txtNumLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumLote.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumLote.Location = New System.Drawing.Point(6, 22)
        Me.txtNumLote.Name = "txtNumLote"
        Me.txtNumLote.Size = New System.Drawing.Size(198, 23)
        Me.txtNumLote.TabIndex = 1
        Me.txtNumLote.Tag = "SIM"
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.txtNumNfse)
        Me.GroupBox12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox12.Location = New System.Drawing.Point(419, 22)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(216, 51)
        Me.GroupBox12.TabIndex = 2
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Nº da Nota"
        '
        'txtNumNfse
        '
        Me.txtNumNfse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumNfse.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumNfse.Location = New System.Drawing.Point(12, 22)
        Me.txtNumNfse.Name = "txtNumNfse"
        Me.txtNumNfse.Size = New System.Drawing.Size(197, 23)
        Me.txtNumNfse.TabIndex = 2
        Me.txtNumNfse.Tag = "SIM"
        '
        'frmLocalizarNfse
        '
        Me.AcceptButton = Me.btLocalizar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 251)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmLocalizarNfse"
        Me.Text = "Localizar Nfs-e"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumRps As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumLote As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumNfse As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDataCompetencia2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDataCompetencia1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDataEmissao2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDataEmissao1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btCancelar As System.Windows.Forms.Button
    Friend WithEvents btLocalizar As System.Windows.Forms.Button
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTomador As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtStatusEmail As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtStatusNfse As System.Windows.Forms.ComboBox
End Class
