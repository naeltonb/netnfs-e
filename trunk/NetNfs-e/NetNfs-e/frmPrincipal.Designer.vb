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
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.ConsultarNfse = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuLogOff = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuSair = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuCadUsuarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuParametrosSistema = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.btNovoLote = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.btAbrirLote = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.btArquivoLote = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btConsultarNfse = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btLogOff = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.btSair = New System.Windows.Forms.ToolStripButton()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.BGW = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BarraStatusUsuario = New System.Windows.Forms.ToolStripLabel()
        Me.BarraStatus = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblMensagemStatus = New System.Windows.Forms.ToolStripLabel()
        Me.MenuStrip.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.ToolsMenu, Me.WindowsMenu, Me.HelpMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1025, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.ToolStripSeparator11, Me.OpenToolStripMenuItem, Me.ToolStripSeparator12, Me.ConsultarNfse, Me.ToolStripSeparator4, Me.ToolStripMenuItem6, Me.ToolStripSeparator17, Me.MnuLogOff, Me.ToolStripSeparator15, Me.MnuSair})
        Me.FileMenu.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(63, 20)
        Me.FileMenu.Text = "&Arquivo"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = CType(resources.GetObject("NewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(240, 30)
        Me.NewToolStripMenuItem.Text = "&Novo lote"
        Me.NewToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(237, 6)
        Me.ToolStripSeparator11.Visible = False
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = CType(resources.GetObject("OpenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(240, 30)
        Me.OpenToolStripMenuItem.Text = "&Gerenciar lotes Rps"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(237, 6)
        '
        'ConsultarNfse
        '
        Me.ConsultarNfse.Image = CType(resources.GetObject("ConsultarNfse.Image"), System.Drawing.Image)
        Me.ConsultarNfse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ConsultarNfse.Name = "ConsultarNfse"
        Me.ConsultarNfse.Size = New System.Drawing.Size(240, 30)
        Me.ConsultarNfse.Text = "&Consultar NFS-e"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(237, 6)
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Image = CType(resources.GetObject("ToolStripMenuItem6.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(240, 30)
        Me.ToolStripMenuItem6.Text = "Arquivo de lotes Rps"
        Me.ToolStripMenuItem6.Visible = False
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(237, 6)
        Me.ToolStripSeparator17.Visible = False
        '
        'MnuLogOff
        '
        Me.MnuLogOff.Image = CType(resources.GetObject("MnuLogOff.Image"), System.Drawing.Image)
        Me.MnuLogOff.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuLogOff.Name = "MnuLogOff"
        Me.MnuLogOff.Size = New System.Drawing.Size(240, 30)
        Me.MnuLogOff.Text = "Fazer logoff"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(237, 6)
        '
        'MnuSair
        '
        Me.MnuSair.Image = CType(resources.GetObject("MnuSair.Image"), System.Drawing.Image)
        Me.MnuSair.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuSair.Name = "MnuSair"
        Me.MnuSair.Size = New System.Drawing.Size(240, 30)
        Me.MnuSair.Text = "&Sair"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.ToolStripSeparator3, Me.ToolStripMenuItem2, Me.ToolStripSeparator6, Me.MnuCadUsuarios})
        Me.ToolsMenu.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(77, 20)
        Me.ToolsMenu.Text = "&Cadastros"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Image = CType(resources.GetObject("OptionsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OptionsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(199, 30)
        Me.OptionsToolStripMenuItem.Text = "&Empresa"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(196, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(199, 30)
        Me.ToolStripMenuItem2.Text = "&Serviços"
        Me.ToolStripMenuItem2.Visible = False
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(196, 6)
        Me.ToolStripSeparator6.Visible = False
        '
        'MnuCadUsuarios
        '
        Me.MnuCadUsuarios.Image = CType(resources.GetObject("MnuCadUsuarios.Image"), System.Drawing.Image)
        Me.MnuCadUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MnuCadUsuarios.Name = "MnuCadUsuarios"
        Me.MnuCadUsuarios.Size = New System.Drawing.Size(199, 30)
        Me.MnuCadUsuarios.Text = "&Usuários do sistema"
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
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNovoLote, Me.ToolStripSeparator9, Me.btAbrirLote, Me.ToolStripSeparator10, Me.btArquivoLote, Me.ToolStripSeparator1, Me.btConsultarNfse, Me.ToolStripSeparator2, Me.btLogOff, Me.ToolStripSeparator13, Me.btSair})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip.MinimumSize = New System.Drawing.Size(0, 40)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1025, 40)
        Me.ToolStrip.TabIndex = 6
        Me.ToolStrip.Text = "ToolStrip"
        '
        'btNovoLote
        '
        Me.btNovoLote.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btNovoLote.Image = CType(resources.GetObject("btNovoLote.Image"), System.Drawing.Image)
        Me.btNovoLote.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btNovoLote.ImageTransparentColor = System.Drawing.Color.Black
        Me.btNovoLote.Name = "btNovoLote"
        Me.btNovoLote.Size = New System.Drawing.Size(126, 37)
        Me.btNovoLote.Text = "Cr&iar lote Rps"
        Me.btNovoLote.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.btNovoLote.Visible = False
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 40)
        Me.ToolStripSeparator9.Visible = False
        '
        'btAbrirLote
        '
        Me.btAbrirLote.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAbrirLote.Image = CType(resources.GetObject("btAbrirLote.Image"), System.Drawing.Image)
        Me.btAbrirLote.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btAbrirLote.ImageTransparentColor = System.Drawing.Color.Black
        Me.btAbrirLote.Name = "btAbrirLote"
        Me.btAbrirLote.Size = New System.Drawing.Size(160, 37)
        Me.btAbrirLote.Text = "&Gerenciar lotes Rps"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 40)
        Me.ToolStripSeparator10.Visible = False
        '
        'btArquivoLote
        '
        Me.btArquivoLote.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btArquivoLote.Image = CType(resources.GetObject("btArquivoLote.Image"), System.Drawing.Image)
        Me.btArquivoLote.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btArquivoLote.ImageTransparentColor = System.Drawing.Color.Black
        Me.btArquivoLote.Name = "btArquivoLote"
        Me.btArquivoLote.Size = New System.Drawing.Size(171, 37)
        Me.btArquivoLote.Text = "&Arquivo de lotes Rps"
        Me.btArquivoLote.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'btConsultarNfse
        '
        Me.btConsultarNfse.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btConsultarNfse.Image = CType(resources.GetObject("btConsultarNfse.Image"), System.Drawing.Image)
        Me.btConsultarNfse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btConsultarNfse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btConsultarNfse.Name = "btConsultarNfse"
        Me.btConsultarNfse.Size = New System.Drawing.Size(137, 37)
        Me.btConsultarNfse.Text = "&Consultar Nfs-e"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'btLogOff
        '
        Me.btLogOff.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btLogOff.Image = CType(resources.GetObject("btLogOff.Image"), System.Drawing.Image)
        Me.btLogOff.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btLogOff.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btLogOff.Name = "btLogOff"
        Me.btLogOff.Size = New System.Drawing.Size(123, 37)
        Me.btLogOff.Text = "Fazer &logoff  "
        Me.btLogOff.ToolTipText = "Fazer logoff  "
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 40)
        '
        'btSair
        '
        Me.btSair.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSair.Image = CType(resources.GetObject("btSair.Image"), System.Drawing.Image)
        Me.btSair.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btSair.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btSair.Name = "btSair"
        Me.btSair.Size = New System.Drawing.Size(136, 37)
        Me.btSair.Text = "Sai&r do sistema"
        '
        'BGW
        '
        '
        'Timer1
        '
        Me.Timer1.Interval = 300
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BarraStatusUsuario, Me.BarraStatus, Me.lblMensagemStatus})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 483)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1025, 25)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BarraStatusUsuario
        '
        Me.BarraStatusUsuario.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BarraStatusUsuario.Image = CType(resources.GetObject("BarraStatusUsuario.Image"), System.Drawing.Image)
        Me.BarraStatusUsuario.Name = "BarraStatusUsuario"
        Me.BarraStatusUsuario.Size = New System.Drawing.Size(123, 22)
        Me.BarraStatusUsuario.Text = "ToolStripLabel2"
        '
        'BarraStatus
        '
        Me.BarraStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BarraStatus.MarqueeAnimationSpeed = 12
        Me.BarraStatus.Name = "BarraStatus"
        Me.BarraStatus.Size = New System.Drawing.Size(500, 22)
        Me.BarraStatus.Visible = False
        '
        'lblMensagemStatus
        '
        Me.lblMensagemStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblMensagemStatus.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensagemStatus.ForeColor = System.Drawing.Color.Blue
        Me.lblMensagemStatus.Name = "lblMensagemStatus"
        Me.lblMensagemStatus.Size = New System.Drawing.Size(0, 22)
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1025, 508)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmPrincipal"
        Me.Text = "NetNfs-e - Gerenciador de Nota Fiscal de Serviço Eletrônica"
        Me.TransparencyKey = System.Drawing.Color.White
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuParametrosSistema As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents btNovoLote As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents btAbrirLote As System.Windows.Forms.ToolStripButton
    Friend WithEvents btArquivoLote As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuSair As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarNfse As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btConsultarNfse As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btSair As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuCadUsuarios As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btLogOff As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MnuLogOff As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BGW As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BarraStatusUsuario As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BarraStatus As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblMensagemStatus As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
