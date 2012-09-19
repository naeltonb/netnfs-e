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
        Me.btLocalizar = New System.Windows.Forms.Button()
        Me.btCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.txtNumLoteRps = New System.Windows.Forms.TextBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.txtNumRps = New System.Windows.Forms.TextBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.txtNumNfse = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.SuspendLayout()
        '
        'btLocalizar
        '
        Me.btLocalizar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btLocalizar.Image = CType(resources.GetObject("btLocalizar.Image"), System.Drawing.Image)
        Me.btLocalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btLocalizar.Location = New System.Drawing.Point(109, 164)
        Me.btLocalizar.Name = "btLocalizar"
        Me.btLocalizar.Size = New System.Drawing.Size(133, 38)
        Me.btLocalizar.TabIndex = 0
        Me.btLocalizar.Text = "&Localizar"
        Me.btLocalizar.UseVisualStyleBackColor = True
        '
        'btCancelar
        '
        Me.btCancelar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCancelar.Image = CType(resources.GetObject("btCancelar.Image"), System.Drawing.Image)
        Me.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btCancelar.Location = New System.Drawing.Point(257, 164)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(133, 38)
        Me.btCancelar.TabIndex = 1
        Me.btCancelar.Text = "&Cancelar"
        Me.btCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox13)
        Me.GroupBox1.Controls.Add(Me.GroupBox11)
        Me.GroupBox1.Controls.Add(Me.GroupBox12)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(525, 142)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opções para localizar"
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.txtNumLoteRps)
        Me.GroupBox13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox13.Location = New System.Drawing.Point(12, 22)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(218, 51)
        Me.GroupBox13.TabIndex = 3
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Nº do Rps"
        '
        'txtNumLoteRps
        '
        Me.txtNumLoteRps.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumLoteRps.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumLoteRps.Location = New System.Drawing.Point(8, 22)
        Me.txtNumLoteRps.Name = "txtNumLoteRps"
        Me.txtNumLoteRps.Size = New System.Drawing.Size(202, 23)
        Me.txtNumLoteRps.TabIndex = 0
        Me.txtNumLoteRps.Tag = "SIM"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.txtNumRps)
        Me.GroupBox11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox11.Location = New System.Drawing.Point(38, 79)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(225, 51)
        Me.GroupBox11.TabIndex = 4
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Nº do Lote"
        '
        'txtNumRps
        '
        Me.txtNumRps.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumRps.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumRps.Location = New System.Drawing.Point(6, 22)
        Me.txtNumRps.Name = "txtNumRps"
        Me.txtNumRps.Size = New System.Drawing.Size(210, 23)
        Me.txtNumRps.TabIndex = 1
        Me.txtNumRps.Tag = "SIM"
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.txtNumNfse)
        Me.GroupBox12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox12.Location = New System.Drawing.Point(245, 22)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(249, 51)
        Me.GroupBox12.TabIndex = 5
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Nº da Nota"
        '
        'txtNumNfse
        '
        Me.txtNumNfse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumNfse.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumNfse.Location = New System.Drawing.Point(12, 22)
        Me.txtNumNfse.Name = "txtNumNfse"
        Me.txtNumNfse.Size = New System.Drawing.Size(231, 23)
        Me.txtNumNfse.TabIndex = 2
        Me.txtNumNfse.Tag = "SIM"
        '
        'frmLocalizarNfse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 214)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.btLocalizar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLocalizarNfse"
        Me.Text = "frmLocalizarNfse"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btLocalizar As System.Windows.Forms.Button
    Friend WithEvents btCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumLoteRps As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumRps As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumNfse As System.Windows.Forms.TextBox
End Class
