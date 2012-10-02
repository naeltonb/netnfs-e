<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisualizarXml
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVisualizarXml))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.Web = New System.Windows.Forms.WebBrowser()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btExportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btSair = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Web)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(784, 383)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(784, 423)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        Me.ToolStripContainer1.TopToolStripPanel.MinimumSize = New System.Drawing.Size(0, 40)
        '
        'Web
        '
        Me.Web.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Web.Location = New System.Drawing.Point(0, 0)
        Me.Web.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Web.Name = "Web"
        Me.Web.Size = New System.Drawing.Size(784, 383)
        Me.Web.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btExportar, Me.ToolStripSeparator1, Me.btSair, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.MinimumSize = New System.Drawing.Size(0, 40)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(781, 40)
        Me.ToolStrip1.TabIndex = 0
        '
        'btExportar
        '
        Me.btExportar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btExportar.Image = CType(resources.GetObject("btExportar.Image"), System.Drawing.Image)
        Me.btExportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btExportar.Name = "btExportar"
        Me.btExportar.Size = New System.Drawing.Size(117, 37)
        Me.btExportar.Text = "&Exportar Xml"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'btSair
        '
        Me.btSair.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSair.Image = CType(resources.GetObject("btSair.Image"), System.Drawing.Image)
        Me.btSair.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btSair.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btSair.Name = "btSair"
        Me.btSair.Size = New System.Drawing.Size(59, 37)
        Me.btSair.Text = "&Sair"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(1600, 37)
        Me.ToolStripLabel1.Text = "Menu de funções"
        '
        'frmVisualizarXml
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 423)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "frmVisualizarXml"
        Me.ShowInTaskbar = False
        Me.Text = "Visualizar Xml"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents Web As System.Windows.Forms.WebBrowser
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btExportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btSair As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
End Class
