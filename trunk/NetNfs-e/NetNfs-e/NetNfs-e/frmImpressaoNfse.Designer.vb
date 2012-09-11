<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImpressaoNfse
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
        Me.Relatorio = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'Relatorio
        '
        Me.Relatorio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Relatorio.LocalReport.ReportEmbeddedResource = "NetNfs_e.repNfse.rdlc"
        Me.Relatorio.Location = New System.Drawing.Point(0, 0)
        Me.Relatorio.Name = "Relatorio"
        Me.Relatorio.Size = New System.Drawing.Size(729, 456)
        Me.Relatorio.TabIndex = 0
        '
        'frmImpressaoNfse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 456)
        Me.Controls.Add(Me.Relatorio)
        Me.Name = "frmImpressaoNfse"
        Me.Text = "NFS-e - Impressão DANFE"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Relatorio As Microsoft.Reporting.WinForms.ReportViewer
End Class
