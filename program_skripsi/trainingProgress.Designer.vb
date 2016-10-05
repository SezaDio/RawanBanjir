Imports WindowsApplication1.pelatihanPengujian

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class progress
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
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.cancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(34, 58)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(423, 23)
        Me.ProgressBar1.TabIndex = 0
        '
        'cancel
        '
        Me.cancel.Location = New System.Drawing.Point(382, 87)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(75, 23)
        Me.cancel.TabIndex = 1
        Me.cancel.Text = "Cancel"
        Me.cancel.UseVisualStyleBackColor = True
        '
        'progress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 131)
        Me.Controls.Add(Me.cancel)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Name = "progress"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Training Progress"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents cancel As System.Windows.Forms.Button

    Public Sub setProgress(ByVal progress As Integer)
        ProgressBar1.Value = progress
    End Sub

    Private Sub cancel_Click(sender As Object, e As EventArgs) Handles cancel.Click
        pelatihanPengujian.cancelTraining()
        Me.Close()
    End Sub

    Private Sub progress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'pelatihan.start_train()
    End Sub

    Private Sub progress_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        pelatihanPengujian.start_train()
    End Sub
End Class
