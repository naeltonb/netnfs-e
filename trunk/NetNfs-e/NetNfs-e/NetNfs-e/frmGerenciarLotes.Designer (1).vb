<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGerenciarLotes
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGerenciarLotes))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
        Me.List = New System.Windows.Forms.ListView()
        Me.Col_Sel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_StatusAssinatura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_NumLote = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Arquivo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_DataGeracao = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_UltimoComando = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_DataProtocolo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Protocolo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Col_Mensagem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStripContainer = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btAssinarLote = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btEnviarLote = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btVerificarLote = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btImportarMensagens = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btImportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btArquivar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btExcluir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btAtualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripContainer.ContentPanel.SuspendLayout()
        Me.ToolStripContainer.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BottomToolStripPanel
        '
        Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
        Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'TopToolStripPanel
        '
        Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStripPanel.Name = "TopToolStripPanel"
        Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'RightToolStripPanel
        '
        Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightToolStripPanel.Name = "RightToolStripPanel"
        Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'LeftToolStripPanel
        '
        Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
        Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'ContentPanel
        '
        Me.ContentPanel.Size = New System.Drawing.Size(1056, 557)
        '
        'List
        '
        Me.List.CheckBoxes = True
        Me.List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Col_Sel, Me.Col_StatusAssinatura, Me.Col_Status, Me.Col_NumLote, Me.Col_Arquivo, Me.Col_DataGeracao, Me.Col_UltimoComando, Me.Col_DataProtocolo, Me.Col_Protocolo, Me.Col_Mensagem})
        Me.List.Dock = System.Windows.Forms.DockStyle.Fill
        Me.List.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List.FullRowSelect = True
        Me.List.GridLines = True
        Me.List.Location = New System.Drawing.Point(0, 0)
        Me.List.Name = "List"
        Me.List.Size = New System.Drawing.Size(1123, 443)
        Me.List.TabIndex = 1
        Me.List.UseCompatibleStateImageBehavior = False
        Me.List.View = System.Windows.Forms.View.Details
        '
        'Col_Sel
        '
        Me.Col_Sel.Text = "X"
        Me.Col_Sel.Width = 20
        '
        'Col_StatusAssinatura
        '
        Me.Col_StatusAssinatura.Text = "Certificado digital"
        Me.Col_StatusAssinatura.Width = 115
        '
        'Col_Status
        '
        Me.Col_Status.Text = "Status envio"
        Me.Col_Status.Width = 175
        '
        'Col_NumLote
        '
        Me.Col_NumLote.Text = "Nº Lote"
        '
        'Col_Arquivo
        '
        Me.Col_Arquivo.Text = "Arquivo xml"
        Me.Col_Arquivo.Width = 150
        '
        'Col_DataGeracao
        '
        Me.Col_DataGeracao.Text = "Data criação do lote"
        Me.Col_DataGeracao.Width = 150
        '
        'Col_UltimoComando
        '
        Me.Col_UltimoComando.Text = "Data último comando"
        Me.Col_UltimoComando.Width = 150
        '
        'Col_DataProtocolo
        '
        Me.Col_DataProtocolo.Text = "Data protocolo"
        Me.Col_DataProtocolo.Width = 150
        '
        'Col_Protocolo
        '
        Me.Col_Protocolo.Text = "Protocolo de entrega"
        Me.Col_Protocolo.Width = 150
        '
        'Col_Mensagem
        '
        Me.Col_Mensagem.Text = "Mensagem"
        Me.Col_Mensagem.Width = 325
        '
        'ToolStripContainer
        '
        '
        'ToolStripContainer.ContentPanel
        '
        Me.ToolStripContainer.ContentPanel.Controls.Add(Me.List)
        Me.ToolStripContainer.ContentPanel.Size = New System.Drawing.Size(1123, 443)
        Me.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer.Name = "ToolStripContainer"
        Me.ToolStripContainer.Size = New System.Drawing.Size(1123, 483)
        Me.ToolStripContainer.TabIndex = 7
        Me.ToolStripContainer.Text = "ToolStripContainer1"
        '
        'ToolStripContainer.TopToolStripPanel
        '
        Me.ToolStripContainer.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btAssinarLote, Me.ToolStripSeparator6, Me.btEnviarLote, Me.ToolStripSeparator1, Me.btVerificarLote, Me.ToolStripSeparator2, Me.btImportarMensagens, Me.ToolStripSeparator7, Me.btImportar, Me.ToolStripSeparator4, Me.btArquivar, Me.ToolStripSeparator3, Me.btExcluir, Me.ToolStripSeparator5, Me.btAtualizar})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.MinimumSize = New System.Drawing.Size(0, 40)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1049, 40)
        Me.ToolStrip1.TabIndex = 0
        '
        'btAssinarLote
        '
        Me.btAssinarLote.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAssinarLote.Image = Global.NetNfs_e.My.Resources.Resources.kcmdf
        Me.btAssinarLote.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btAssinarLote.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btAssinarLote.Name = "btAssinarLote"
        Me.btAssinarLote.Size = New System.Drawing.Size(112, 37)
        Me.btAssinarLote.Text = "A&ssinar lote"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 40)
        '
        'btEnviarLote
        '
        Me.btEnviarLote.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btEnviarLote.Image = Global.NetNfs_e.My.Resources.Resources.yast_restore
        Me.btEnviarLote.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btEnviarLote.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btEnviarLote.Name = "btEnviarLote"
        Me.btEnviarLote.Size = New System.Drawing.Size(103, 37)
        Me.btEnviarLote.Text = "&Enviar lote"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'btVerificarLote
        '
        Me.btVerificarLote.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btVerificarLote.Image = Global.NetNfs_e.My.Resources.Resources.kget
        Me.btVerificarLote.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btVerificarLote.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btVerificarLote.Name = "btVerificarLote"
        Me.btVerificarLote.Size = New System.Drawing.Size(135, 37)
        Me.btVerificarLote.Text = "&Verificar status"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'btImportarMensagens
        '
        Me.btImportarMensagens.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btImportarMensagens.Image = CType(resources.GetObject("btImportarMensagens.Image"), System.Drawing.Image)
        Me.btImportarMensagens.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btImportarMensagens.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btImportarMensagens.Name = "btImportarMensagens"
        Me.btImportarMensagens.Size = New System.Drawing.Size(169, 37)
        Me.btImportarMensagens.Text = "Importar &mensagens"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 40)
        '
        'btImportar
        '
        Me.btImportar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btImportar.Image = Global.NetNfs_e.My.Resources.Resources.importar
        Me.btImportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btImportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btImportar.Name = "btImportar"
        Me.btImportar.Size = New System.Drawing.Size(130, 37)
        Me.btImportar.Text = "&Importar Nfs-e"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 40)
        '
        'btArquivar
        '
        Me.btArquivar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btArquivar.Image = Global.NetNfs_e.My.Resources.Resources.yast_HD
        Me.btArquivar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btArquivar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btArquivar.Name = "btArquivar"
        Me.btArquivar.Size = New System.Drawing.Size(120, 37)
        Me.btArquivar.Text = "&Arquivar lote"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
        '
        'btExcluir
        '
        Me.btExcluir.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btExcluir.Image = Global.NetNfs_e.My.Resources.Resources._error
        Me.btExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btExcluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btExcluir.Name = "btExcluir"
        Me.btExcluir.Size = New System.Drawing.Size(104, 37)
        Me.btExcluir.Text = "E&xcluir lote"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'btAtualizar
        '
        Me.btAtualizar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAtualizar.Image = Global.NetNfs_e.My.Resources.Resources.atualizar
        Me.btAtualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btAtualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btAtualizar.Name = "btAtualizar"
        Me.btAtualizar.Size = New System.Drawing.Size(122, 37)
        Me.btAtualizar.Text = "A&tualizar tela"
        '
        'frmGerenciarLotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1123, 483)
        Me.Controls.Add(Me.ToolStripContainer)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGerenciarLotes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gerenciar lotes de Rps"
        Me.ToolStripContainer.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer.ResumeLayout(False)
        Me.ToolStripContainer.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents List As System.Windows.Forms.ListView
    Friend WithEvents Col_Sel As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_StatusAssinatura As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_Status As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_NumLote As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_Arquivo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_DataGeracao As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_UltimoComando As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripContainer As System.Windows.Forms.ToolStripContainer
    Friend WithEvents BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents TopToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents RightToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ContentPanel As System.Windows.Forms.ToolStripContentPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btEnviarLote As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btVerificarLote As System.Windows.Forms.ToolStripButton
    Friend WithEvents Col_Mensagem As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btExcluir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btArquivar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btAtualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btAssinarLote As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btImportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Col_Protocolo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Col_DataProtocolo As System.Windows.Forms.ColumnHeader
    Friend WithEvents btImportarMensagens As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator

End Class
