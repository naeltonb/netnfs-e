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
        Me.web = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'web
        '
        Me.web.Dock = System.Windows.Forms.DockStyle.Fill
        Me.web.Location = New System.Drawing.Point(0, 0)
        Me.web.MinimumSize = New System.Drawing.Size(20, 20)
        Me.web.Name = "web"
        Me.web.Size = New System.Drawing.Size(809, 454)
        Me.web.TabIndex = 0
        '
        'frmVisualizarXml
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 454)
        Me.Controls.Add(Me.web)
        Me.Name = "frmVisualizarXml"
        Me.Text = "frmVisualizarXml"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents web As System.Windows.Forms.WebBrowser
End Class
