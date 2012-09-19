<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdicionarRps
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtRegEspTributacao = New System.Windows.Forms.ComboBox()
        Me.txtOptSimplesNacional = New System.Windows.Forms.ComboBox()
        Me.txtIncCultural = New System.Windows.Forms.ComboBox()
        Me.txtTipoRps = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(79, 318)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 42)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtRegEspTributacao
        '
        Me.txtRegEspTributacao.FormattingEnabled = True
        Me.txtRegEspTributacao.Location = New System.Drawing.Point(29, 74)
        Me.txtRegEspTributacao.Name = "txtRegEspTributacao"
        Me.txtRegEspTributacao.Size = New System.Drawing.Size(101, 21)
        Me.txtRegEspTributacao.TabIndex = 1
        '
        'txtOptSimplesNacional
        '
        Me.txtOptSimplesNacional.FormattingEnabled = True
        Me.txtOptSimplesNacional.Location = New System.Drawing.Point(29, 120)
        Me.txtOptSimplesNacional.Name = "txtOptSimplesNacional"
        Me.txtOptSimplesNacional.Size = New System.Drawing.Size(100, 21)
        Me.txtOptSimplesNacional.TabIndex = 2
        '
        'txtIncCultural
        '
        Me.txtIncCultural.FormattingEnabled = True
        Me.txtIncCultural.Location = New System.Drawing.Point(34, 162)
        Me.txtIncCultural.Name = "txtIncCultural"
        Me.txtIncCultural.Size = New System.Drawing.Size(95, 21)
        Me.txtIncCultural.TabIndex = 3
        '
        'txtTipoRps
        '
        Me.txtTipoRps.FormattingEnabled = True
        Me.txtTipoRps.Location = New System.Drawing.Point(34, 204)
        Me.txtTipoRps.Name = "txtTipoRps"
        Me.txtTipoRps.Size = New System.Drawing.Size(94, 21)
        Me.txtTipoRps.TabIndex = 4
        '
        'frmAdicionarRps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 391)
        Me.Controls.Add(Me.txtTipoRps)
        Me.Controls.Add(Me.txtIncCultural)
        Me.Controls.Add(Me.txtOptSimplesNacional)
        Me.Controls.Add(Me.txtRegEspTributacao)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmAdicionarRps"
        Me.Text = "frmAdicionarRps"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtRegEspTributacao As System.Windows.Forms.ComboBox
    Friend WithEvents txtOptSimplesNacional As System.Windows.Forms.ComboBox
    Friend WithEvents txtIncCultural As System.Windows.Forms.ComboBox
    Friend WithEvents txtTipoRps As System.Windows.Forms.ComboBox
End Class
