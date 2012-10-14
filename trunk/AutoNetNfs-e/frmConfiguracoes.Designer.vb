<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguracoes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfiguracoes))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.GroupDados = New System.Windows.Forms.GroupBox()
        Me.chkArquivar = New System.Windows.Forms.CheckBox()
        Me.chkEmail = New System.Windows.Forms.CheckBox()
        Me.chkImportar = New System.Windows.Forms.CheckBox()
        Me.chkVerificar = New System.Windows.Forms.CheckBox()
        Me.chkEnviar = New System.Windows.Forms.CheckBox()
        Me.chkAssinar = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btSalvar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.GroupDados.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.GroupDados)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(590, 146)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(590, 186)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        Me.ToolStripContainer1.TopToolStripPanel.MinimumSize = New System.Drawing.Size(0, 40)
        '
        'GroupDados
        '
        Me.GroupDados.Controls.Add(Me.chkArquivar)
        Me.GroupDados.Controls.Add(Me.chkEmail)
        Me.GroupDados.Controls.Add(Me.chkImportar)
        Me.GroupDados.Controls.Add(Me.chkVerificar)
        Me.GroupDados.Controls.Add(Me.chkEnviar)
        Me.GroupDados.Controls.Add(Me.chkAssinar)
        Me.GroupDados.Enabled = False
        Me.GroupDados.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupDados.ForeColor = System.Drawing.Color.Maroon
        Me.GroupDados.Location = New System.Drawing.Point(7, 11)
        Me.GroupDados.Name = "GroupDados"
        Me.GroupDados.Size = New System.Drawing.Size(567, 127)
        Me.GroupDados.TabIndex = 0
        Me.GroupDados.TabStop = False
        Me.GroupDados.Text = "Funções automáticas"
        '
        'chkArquivar
        '
        Me.chkArquivar.AutoSize = True
        Me.chkArquivar.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkArquivar.ForeColor = System.Drawing.Color.Black
        Me.chkArquivar.Location = New System.Drawing.Point(305, 90)
        Me.chkArquivar.Name = "chkArquivar"
        Me.chkArquivar.Size = New System.Drawing.Size(201, 22)
        Me.chkArquivar.TabIndex = 5
        Me.chkArquivar.Text = "Arquivar lotes processados"
        Me.chkArquivar.UseVisualStyleBackColor = True
        '
        'chkEmail
        '
        Me.chkEmail.AutoSize = True
        Me.chkEmail.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEmail.ForeColor = System.Drawing.Color.Black
        Me.chkEmail.Location = New System.Drawing.Point(305, 62)
        Me.chkEmail.Name = "chkEmail"
        Me.chkEmail.Size = New System.Drawing.Size(215, 22)
        Me.chkEmail.TabIndex = 4
        Me.chkEmail.Text = "Enviar e-mail para os clientes"
        Me.chkEmail.UseVisualStyleBackColor = True
        '
        'chkImportar
        '
        Me.chkImportar.AutoSize = True
        Me.chkImportar.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkImportar.ForeColor = System.Drawing.Color.Black
        Me.chkImportar.Location = New System.Drawing.Point(305, 34)
        Me.chkImportar.Name = "chkImportar"
        Me.chkImportar.Size = New System.Drawing.Size(241, 22)
        Me.chkImportar.TabIndex = 3
        Me.chkImportar.Text = "Importar retorno via WebService"
        Me.chkImportar.UseVisualStyleBackColor = True
        '
        'chkVerificar
        '
        Me.chkVerificar.AutoSize = True
        Me.chkVerificar.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVerificar.ForeColor = System.Drawing.Color.Black
        Me.chkVerificar.Location = New System.Drawing.Point(19, 90)
        Me.chkVerificar.Name = "chkVerificar"
        Me.chkVerificar.Size = New System.Drawing.Size(227, 22)
        Me.chkVerificar.TabIndex = 2
        Me.chkVerificar.Text = "Verificar status do lote enviado"
        Me.chkVerificar.UseVisualStyleBackColor = True
        '
        'chkEnviar
        '
        Me.chkEnviar.AutoSize = True
        Me.chkEnviar.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEnviar.ForeColor = System.Drawing.Color.Black
        Me.chkEnviar.Location = New System.Drawing.Point(19, 62)
        Me.chkEnviar.Name = "chkEnviar"
        Me.chkEnviar.Size = New System.Drawing.Size(222, 22)
        Me.chkEnviar.TabIndex = 1
        Me.chkEnviar.Text = "Enviar arquivo via WebService"
        Me.chkEnviar.UseVisualStyleBackColor = True
        '
        'chkAssinar
        '
        Me.chkAssinar.AutoSize = True
        Me.chkAssinar.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAssinar.ForeColor = System.Drawing.Color.Black
        Me.chkAssinar.Location = New System.Drawing.Point(19, 34)
        Me.chkAssinar.Name = "chkAssinar"
        Me.chkAssinar.Size = New System.Drawing.Size(244, 22)
        Me.chkAssinar.TabIndex = 0
        Me.chkAssinar.Text = "Assinar lote com certificado digital"
        Me.chkAssinar.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btSalvar, Me.ToolStripSeparator1, Me.btEditar, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.MinimumSize = New System.Drawing.Size(0, 40)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(587, 40)
        Me.ToolStrip1.TabIndex = 0
        '
        'btSalvar
        '
        Me.btSalvar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSalvar.Image = CType(resources.GetObject("btSalvar.Image"), System.Drawing.Image)
        Me.btSalvar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btSalvar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btSalvar.Name = "btSalvar"
        Me.btSalvar.Size = New System.Drawing.Size(75, 37)
        Me.btSalvar.Text = "&Salvar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'btEditar
        '
        Me.btEditar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btEditar.Image = CType(resources.GetObject("btEditar.Image"), System.Drawing.Image)
        Me.btEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btEditar.Name = "btEditar"
        Me.btEditar.Size = New System.Drawing.Size(74, 37)
        Me.btEditar.Text = "&Editar"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(500, 37)
        Me.ToolStripLabel1.Text = "Menu de funções"
        '
        'frmConfiguracoes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 186)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmConfiguracoes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configurações do módulo automático"
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.GroupDados.ResumeLayout(False)
        Me.GroupDados.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btSalvar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupDados As System.Windows.Forms.GroupBox
    Friend WithEvents chkArquivar As System.Windows.Forms.CheckBox
    Friend WithEvents chkEmail As System.Windows.Forms.CheckBox
    Friend WithEvents chkImportar As System.Windows.Forms.CheckBox
    Friend WithEvents chkVerificar As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnviar As System.Windows.Forms.CheckBox
    Friend WithEvents chkAssinar As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
End Class
