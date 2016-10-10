<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class prediksi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(prediksi))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.clear_prediksi = New System.Windows.Forms.Button()
        Me.predict = New System.Windows.Forms.Button()
        Me.input_mobil_pribadi = New System.Windows.Forms.TextBox()
        Me.input_hujan = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.input_suhu = New System.Windows.Forms.TextBox()
        Me.input_drainase = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.prediksiIri = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.keterangan_prediksi = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(143, 487)
        Me.Panel1.TabIndex = 10
        '
        'Button4
        '
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button4.Location = New System.Drawing.Point(6, 246)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(131, 52)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Kontrol Database"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button3.Location = New System.Drawing.Point(6, 168)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(131, 52)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Prediksi"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button2.Location = New System.Drawing.Point(6, 91)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(131, 52)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Pelatihan dan Pengujian Data"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.Button1.Location = New System.Drawing.Point(6, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(131, 52)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Home"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(-1, 487)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(844, 30)
        Me.Panel2.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.input_drainase)
        Me.GroupBox1.Controls.Add(Me.input_suhu)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.input_hujan)
        Me.GroupBox1.Controls.Add(Me.input_mobil_pribadi)
        Me.GroupBox1.Controls.Add(Me.predict)
        Me.GroupBox1.Controls.Add(Me.clear_prediksi)
        Me.GroupBox1.Location = New System.Drawing.Point(158, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(374, 252)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parameter Prediksi"
        '
        'clear_prediksi
        '
        Me.clear_prediksi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.clear_prediksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.clear_prediksi.Location = New System.Drawing.Point(197, 189)
        Me.clear_prediksi.Name = "clear_prediksi"
        Me.clear_prediksi.Size = New System.Drawing.Size(75, 23)
        Me.clear_prediksi.TabIndex = 10
        Me.clear_prediksi.Text = "Clear"
        Me.clear_prediksi.UseVisualStyleBackColor = True
        '
        'predict
        '
        Me.predict.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.predict.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.predict.Location = New System.Drawing.Point(100, 189)
        Me.predict.Name = "predict"
        Me.predict.Size = New System.Drawing.Size(75, 23)
        Me.predict.TabIndex = 9
        Me.predict.Text = "Prediksi"
        Me.predict.UseVisualStyleBackColor = True
        '
        'input_mobil_pribadi
        '
        Me.input_mobil_pribadi.Location = New System.Drawing.Point(206, 132)
        Me.input_mobil_pribadi.Name = "input_mobil_pribadi"
        Me.input_mobil_pribadi.Size = New System.Drawing.Size(124, 20)
        Me.input_mobil_pribadi.TabIndex = 8
        '
        'input_hujan
        '
        Me.input_hujan.Location = New System.Drawing.Point(206, 70)
        Me.input_hujan.Name = "input_hujan"
        Me.input_hujan.Size = New System.Drawing.Size(124, 20)
        Me.input_hujan.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(37, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Skor Topografi"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(37, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Skor Guna Lahan"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(37, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Skor Drainase"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Skor Curah Hujan"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 0
        '
        'input_suhu
        '
        Me.input_suhu.Location = New System.Drawing.Point(206, 39)
        Me.input_suhu.Name = "input_suhu"
        Me.input_suhu.Size = New System.Drawing.Size(124, 20)
        Me.input_suhu.TabIndex = 5
        '
        'input_drainase
        '
        Me.input_drainase.DisplayMember = "1"
        Me.input_drainase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.input_drainase.FormattingEnabled = True
        Me.input_drainase.Items.AddRange(New Object() {"Baik", "Sedang", "Buruk"})
        Me.input_drainase.Location = New System.Drawing.Point(206, 100)
        Me.input_drainase.Name = "input_drainase"
        Me.input_drainase.Size = New System.Drawing.Size(124, 21)
        Me.input_drainase.TabIndex = 29
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.keterangan_prediksi)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.prediksiIri)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Location = New System.Drawing.Point(98, 311)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(508, 135)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Hasil Prediksi"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(15, 31)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(217, 17)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "Skor Prediksi Tingkat Kerawanan"
        '
        'prediksiIri
        '
        Me.prediksiIri.Location = New System.Drawing.Point(73, 67)
        Me.prediksiIri.Multiline = True
        Me.prediksiIri.Name = "prediksiIri"
        Me.prediksiIri.ReadOnly = True
        Me.prediksiIri.Size = New System.Drawing.Size(102, 40)
        Me.prediksiIri.TabIndex = 31
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(302, 31)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(187, 17)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Kategori Tingkat Kerawanan"
        '
        'keterangan_prediksi
        '
        Me.keterangan_prediksi.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.keterangan_prediksi.Location = New System.Drawing.Point(303, 65)
        Me.keterangan_prediksi.Multiline = True
        Me.keterangan_prediksi.Name = "keterangan_prediksi"
        Me.keterangan_prediksi.ReadOnly = True
        Me.keterangan_prediksi.Size = New System.Drawing.Size(184, 40)
        Me.keterangan_prediksi.TabIndex = 33
        Me.keterangan_prediksi.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Location = New System.Drawing.Point(140, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(703, 487)
        Me.Panel3.TabIndex = 12
        '
        'prediksi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 517)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "prediksi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prediksi Rawan Banjir"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents input_drainase As System.Windows.Forms.ComboBox
    Friend WithEvents input_suhu As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents input_hujan As System.Windows.Forms.TextBox
    Friend WithEvents input_mobil_pribadi As System.Windows.Forms.TextBox
    Friend WithEvents predict As System.Windows.Forms.Button
    Friend WithEvents clear_prediksi As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents keterangan_prediksi As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents prediksiIri As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
End Class
