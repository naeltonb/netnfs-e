<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExecutar
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
        Me.Barra = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BGW = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtCab = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Barra
        '
        Me.Barra.Location = New System.Drawing.Point(92, 67)
        Me.Barra.MarqueeAnimationSpeed = 25
        Me.Barra.Maximum = 1000
        Me.Barra.Name = "Barra"
        Me.Barra.Size = New System.Drawing.Size(427, 27)
        Me.Barra.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.Barra.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(92, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(427, 23)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Executando... Aguarde um minuto por favor"
        '
        'BGW
        '
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'txtCab
        '
        Me.txtCab.Location = New System.Drawing.Point(12, 12)
        Me.txtCab.Name = "txtCab"
        Me.txtCab.Size = New System.Drawing.Size(631, 20)
        Me.txtCab.TabIndex = 9
        Me.txtCab.Text = "<?xml version=""1.0"" encoding=""UTF-8""?><cabecalho xmlns=""http://www.abrasf.org.br/" & _
            "nfse.xsd"" versao=""1.00""><versaoDados>1.00</versaoDados></cabecalho>"
        Me.txtCab.Visible = False
        '
        'frmExecutar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 135)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtCab)
        Me.Controls.Add(Me.Barra)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmExecutar"
        Me.Opacity = 0.7R
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Barra As System.Windows.Forms.ProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BGW As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtCab As System.Windows.Forms.TextBox
End Class
