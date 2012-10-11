<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.BGW = New System.ComponentModel.BackgroundWorker()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSair = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuParametrosSistema = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.btSair = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btInterromper = New System.Windows.Forms.ToolStripButton()
        Me.btContinuar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BarraStatusUsuario = New System.Windows.Forms.ToolStripLabel()
        Me.BarraStatus = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblMensagemStatus = New System.Windows.Forms.ToolStripLabel()
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuAbrir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuSair = New System.Windows.Forms.ToolStripMenuItem()
        Me.BGW1 = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'BGW
        '
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.WindowsMenu, Me.HelpMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1264, 24)
        Me.MenuStrip.TabIndex = 13
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSair})
        Me.FileMenu.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(63, 20)
        Me.FileMenu.Text = "&Arquivo"
        '
        'MnuSair
        '
        Me.MnuSair.Image = CType(resources.GetObject("MnuSair.Image"), System.Drawing.Image)
        Me.MnuSair.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuSair.Name = "MnuSair"
        Me.MnuSair.Size = New System.Drawing.Size(236, 28)
        Me.MnuSair.Text = "&Sair do módulo automático"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuParametrosSistema, Me.ToolStripSeparator14})
        Me.WindowsMenu.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(101, 20)
        Me.WindowsMenu.Text = "Con&figurações"
        '
        'MnuParametrosSistema
        '
        Me.MnuParametrosSistema.Image = CType(resources.GetObject("MnuParametrosSistema.Image"), System.Drawing.Image)
        Me.MnuParametrosSistema.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuParametrosSistema.Name = "MnuParametrosSistema"
        Me.MnuParametrosSistema.Size = New System.Drawing.Size(223, 30)
        Me.MnuParametrosSistema.Text = "&Parâmentros do sistema"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(220, 6)
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IndexToolStripMenuItem, Me.ToolStripSeparator8, Me.AboutToolStripMenuItem})
        Me.HelpMenu.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(53, 20)
        Me.HelpMenu.Text = "&Ajuda"
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.Image = CType(resources.GetObject("IndexToolStripMenuItem.Image"), System.Drawing.Image)
        Me.IndexToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.IndexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(193, 30)
        Me.IndexToolStripMenuItem.Text = "&Manual"
        Me.IndexToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(190, 6)
        Me.ToolStripSeparator8.Visible = False
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = CType(resources.GetObject("AboutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AboutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(193, 30)
        Me.AboutToolStripMenuItem.Text = "&Sobre o sistema ..."
        '
        'ToolStrip
        '
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.btSair, Me.ToolStripSeparator2, Me.btInterromper, Me.btContinuar})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip.MinimumSize = New System.Drawing.Size(0, 40)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1264, 40)
        Me.ToolStrip.TabIndex = 14
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(307, 37)
        Me.ToolStripLabel1.Text = "<<<<< Módulo automático do Nfs-e >>>>>"
        '
        'btSair
        '
        Me.btSair.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btSair.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSair.Image = CType(resources.GetObject("btSair.Image"), System.Drawing.Image)
        Me.btSair.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btSair.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btSair.Name = "btSair"
        Me.btSair.Size = New System.Drawing.Size(137, 37)
        Me.btSair.Text = "&Ocultar sistema"
        Me.btSair.ToolTipText = "Ocultar sistema"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'btInterromper
        '
        Me.btInterromper.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btInterromper.Image = Global.AutoNetNfs_e.My.Resources.Resources._Stop
        Me.btInterromper.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btInterromper.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btInterromper.Name = "btInterromper"
        Me.btInterromper.Size = New System.Drawing.Size(242, 37)
        Me.btInterromper.Text = "&Interromper processo automático"
        '
        'btContinuar
        '
        Me.btContinuar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btContinuar.Image = Global.AutoNetNfs_e.My.Resources.Resources.Play
        Me.btContinuar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btContinuar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btContinuar.Name = "btContinuar"
        Me.btContinuar.Size = New System.Drawing.Size(228, 37)
        Me.btContinuar.Text = "&Continuar processo automático"
        Me.btContinuar.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarraStatusUsuario, Me.BarraStatus, Me.lblMensagemStatus})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 577)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1264, 25)
        Me.ToolStrip1.TabIndex = 16
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BarraStatusUsuario
        '
        Me.BarraStatusUsuario.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarraStatusUsuario.Image = CType(resources.GetObject("BarraStatusUsuario.Image"), System.Drawing.Image)
        Me.BarraStatusUsuario.Name = "BarraStatusUsuario"
        Me.BarraStatusUsuario.Size = New System.Drawing.Size(99, 22)
        Me.BarraStatusUsuario.Text = "Automático"
        '
        'BarraStatus
        '
        Me.BarraStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BarraStatus.MarqueeAnimationSpeed = 12
        Me.BarraStatus.Name = "BarraStatus"
        Me.BarraStatus.Size = New System.Drawing.Size(500, 22)
        Me.BarraStatus.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        '
        'lblMensagemStatus
        '
        Me.lblMensagemStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblMensagemStatus.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensagemStatus.ForeColor = System.Drawing.Color.Blue
        Me.lblMensagemStatus.Name = "lblMensagemStatus"
        Me.lblMensagemStatus.Size = New System.Drawing.Size(0, 22)
        '
        'NotifyIcon
        '
        Me.NotifyIcon.ContextMenuStrip = Me.Menu
        Me.NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
        Me.NotifyIcon.Text = "Nfs-e automático"
        Me.NotifyIcon.Visible = True
        '
        'Menu
        '
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAbrir, Me.ToolStripSeparator1, Me.MenuSair})
        Me.Menu.Name = "MenuSair"
        Me.Menu.Size = New System.Drawing.Size(101, 54)
        Me.Menu.Text = "&Sair"
        '
        'MenuAbrir
        '
        Me.MenuAbrir.Image = CType(resources.GetObject("MenuAbrir.Image"), System.Drawing.Image)
        Me.MenuAbrir.Name = "MenuAbrir"
        Me.MenuAbrir.Size = New System.Drawing.Size(100, 22)
        Me.MenuAbrir.Text = "Abrir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(97, 6)
        '
        'MenuSair
        '
        Me.MenuSair.Image = CType(resources.GetObject("MenuSair.Image"), System.Drawing.Image)
        Me.MenuSair.Name = "MenuSair"
        Me.MenuSair.Size = New System.Drawing.Size(100, 22)
        Me.MenuSair.Text = "Sair"
        '
        'BGW1
        '
        Me.BGW1.WorkerSupportsCancellation = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10000
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 602)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmPrincipal"
        Me.Text = "Modulo automático do Nfs-e"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Menu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSair As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuParametrosSistema As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents btSair As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BarraStatusUsuario As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BarraStatus As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblMensagemStatus As System.Windows.Forms.ToolStripLabel
    Friend WithEvents NotifyIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents Menu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuAbrir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuSair As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btInterromper As System.Windows.Forms.ToolStripButton
    Friend WithEvents btContinuar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BGW As System.ComponentModel.BackgroundWorker
    Friend WithEvents BGW1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
