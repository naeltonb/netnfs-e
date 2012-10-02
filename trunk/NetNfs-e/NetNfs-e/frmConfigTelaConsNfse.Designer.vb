<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigTelaConsNfse
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfigTelaConsNfse))
        Me.bt1 = New System.Windows.Forms.Button()
        Me.bt2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.List = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btSair = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bt1
        '
        Me.bt1.Image = CType(resources.GetObject("bt1.Image"), System.Drawing.Image)
        Me.bt1.Location = New System.Drawing.Point(262, 9)
        Me.bt1.Name = "bt1"
        Me.bt1.Size = New System.Drawing.Size(47, 50)
        Me.bt1.TabIndex = 2
        Me.bt1.UseVisualStyleBackColor = True
        '
        'bt2
        '
        Me.bt2.Image = CType(resources.GetObject("bt2.Image"), System.Drawing.Image)
        Me.bt2.Location = New System.Drawing.Point(262, 65)
        Me.bt2.Name = "bt2"
        Me.bt2.Size = New System.Drawing.Size(47, 53)
        Me.bt2.TabIndex = 3
        Me.bt2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.List)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(2, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(254, 321)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "(X)"
        '
        'List
        '
        Me.List.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.List.CheckBoxes = True
        Me.List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.List.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List.Location = New System.Drawing.Point(10, 32)
        Me.List.MultiSelect = False
        Me.List.Name = "List"
        Me.List.Size = New System.Drawing.Size(238, 283)
        Me.List.TabIndex = 9
        Me.List.UseCompatibleStateImageBehavior = False
        Me.List.View = System.Windows.Forms.View.List
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Index"
        Me.ColumnHeader1.Width = 200
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Colunas"
        '
        'btSair
        '
        Me.btSair.Image = CType(resources.GetObject("btSair.Image"), System.Drawing.Image)
        Me.btSair.Location = New System.Drawing.Point(262, 124)
        Me.btSair.Name = "btSair"
        Me.btSair.Size = New System.Drawing.Size(47, 53)
        Me.btSair.TabIndex = 9
        Me.btSair.UseVisualStyleBackColor = True
        '
        'frmConfigTelaConsNfse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(316, 335)
        Me.Controls.Add(Me.btSair)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bt2)
        Me.Controls.Add(Me.bt1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmConfigTelaConsNfse"
        Me.ShowInTaskbar = False
        Me.Text = "Configurar tela"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bt1 As System.Windows.Forms.Button
    Friend WithEvents bt2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents List As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btSair As System.Windows.Forms.Button
End Class
