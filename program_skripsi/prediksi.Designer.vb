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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.keterangan_prediksi = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.prediksiIri = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.input_drainase = New System.Windows.Forms.ComboBox()
        Me.input_suhu = New System.Windows.Forms.TextBox()
        Me.input_sepeda_motor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.input_truck_trailer = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.input_truck_berat = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.input_hujan = New System.Windows.Forms.TextBox()
        Me.input_truck_sedang = New System.Windows.Forms.TextBox()
        Me.input_mobil_pribadi = New System.Windows.Forms.TextBox()
        Me.input_truck_ringan = New System.Windows.Forms.TextBox()
        Me.predict = New System.Windows.Forms.Button()
        Me.input_pickup = New System.Windows.Forms.TextBox()
        Me.clear_prediksi = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.input_bus_besar = New System.Windows.Forms.TextBox()
        Me.input_mikro_bus = New System.Windows.Forms.TextBox()
        Me.input_bus_kecil = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(143, 489)
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.keterangan_prediksi)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.prediksiIri)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Location = New System.Drawing.Point(393, 245)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(303, 233)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Hasil Prediksi"
        '
        'keterangan_prediksi
        '
        Me.keterangan_prediksi.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.keterangan_prediksi.Location = New System.Drawing.Point(18, 118)
        Me.keterangan_prediksi.Multiline = True
        Me.keterangan_prediksi.Name = "keterangan_prediksi"
        Me.keterangan_prediksi.ReadOnly = True
        Me.keterangan_prediksi.Size = New System.Drawing.Size(278, 101)
        Me.keterangan_prediksi.TabIndex = 33
        Me.keterangan_prediksi.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(15, 93)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(170, 17)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Keterangan Kondisi Jalan"
        '
        'prediksiIri
        '
        Me.prediksiIri.Location = New System.Drawing.Point(18, 51)
        Me.prediksiIri.Name = "prediksiIri"
        Me.prediksiIri.ReadOnly = True
        Me.prediksiIri.Size = New System.Drawing.Size(102, 20)
        Me.prediksiIri.TabIndex = 31
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(15, 31)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 17)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "Nilai Prediksi IRI"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.input_drainase)
        Me.GroupBox1.Controls.Add(Me.input_suhu)
        Me.GroupBox1.Controls.Add(Me.input_sepeda_motor)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.input_truck_trailer)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.input_truck_berat)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.input_hujan)
        Me.GroupBox1.Controls.Add(Me.input_truck_sedang)
        Me.GroupBox1.Controls.Add(Me.input_mobil_pribadi)
        Me.GroupBox1.Controls.Add(Me.input_truck_ringan)
        Me.GroupBox1.Controls.Add(Me.predict)
        Me.GroupBox1.Controls.Add(Me.input_pickup)
        Me.GroupBox1.Controls.Add(Me.clear_prediksi)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.input_bus_besar)
        Me.GroupBox1.Controls.Add(Me.input_mikro_bus)
        Me.GroupBox1.Controls.Add(Me.input_bus_kecil)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(374, 469)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parameter Prediksi"
        '
        'input_drainase
        '
        Me.input_drainase.DisplayMember = "1"
        Me.input_drainase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.input_drainase.FormattingEnabled = True
        Me.input_drainase.Items.AddRange(New Object() {"Baik", "Sedang", "Buruk"})
        Me.input_drainase.Location = New System.Drawing.Point(206, 85)
        Me.input_drainase.Name = "input_drainase"
        Me.input_drainase.Size = New System.Drawing.Size(124, 21)
        Me.input_drainase.TabIndex = 29
        '
        'input_suhu
        '
        Me.input_suhu.Location = New System.Drawing.Point(206, 24)
        Me.input_suhu.Name = "input_suhu"
        Me.input_suhu.Size = New System.Drawing.Size(124, 20)
        Me.input_suhu.TabIndex = 5
        '
        'input_sepeda_motor
        '
        Me.input_sepeda_motor.Location = New System.Drawing.Point(206, 395)
        Me.input_sepeda_motor.Name = "input_sepeda_motor"
        Me.input_sepeda_motor.Size = New System.Drawing.Size(124, 20)
        Me.input_sepeda_motor.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 0
        '
        'input_truck_trailer
        '
        Me.input_truck_trailer.Location = New System.Drawing.Point(206, 364)
        Me.input_truck_trailer.Name = "input_truck_trailer"
        Me.input_truck_trailer.Size = New System.Drawing.Size(124, 20)
        Me.input_truck_trailer.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Suhu Udara"
        '
        'input_truck_berat
        '
        Me.input_truck_berat.Location = New System.Drawing.Point(206, 333)
        Me.input_truck_berat.Name = "input_truck_berat"
        Me.input_truck_berat.Size = New System.Drawing.Size(124, 20)
        Me.input_truck_berat.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(37, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Curah Hujan"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(37, 395)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(146, 17)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Jumlah Sepeda Motor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(37, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Drainase"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(37, 364)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(138, 17)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Jumlah Truck Trailer"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(37, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Jumlah Mobil Pribadi"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(37, 333)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(131, 17)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Jumlah Truck Berat"
        '
        'input_hujan
        '
        Me.input_hujan.Location = New System.Drawing.Point(206, 55)
        Me.input_hujan.Name = "input_hujan"
        Me.input_hujan.Size = New System.Drawing.Size(124, 20)
        Me.input_hujan.TabIndex = 6
        '
        'input_truck_sedang
        '
        Me.input_truck_sedang.Location = New System.Drawing.Point(206, 303)
        Me.input_truck_sedang.Name = "input_truck_sedang"
        Me.input_truck_sedang.Size = New System.Drawing.Size(124, 20)
        Me.input_truck_sedang.TabIndex = 22
        '
        'input_mobil_pribadi
        '
        Me.input_mobil_pribadi.Location = New System.Drawing.Point(206, 117)
        Me.input_mobil_pribadi.Name = "input_mobil_pribadi"
        Me.input_mobil_pribadi.Size = New System.Drawing.Size(124, 20)
        Me.input_mobil_pribadi.TabIndex = 8
        '
        'input_truck_ringan
        '
        Me.input_truck_ringan.Location = New System.Drawing.Point(206, 272)
        Me.input_truck_ringan.Name = "input_truck_ringan"
        Me.input_truck_ringan.Size = New System.Drawing.Size(124, 20)
        Me.input_truck_ringan.TabIndex = 21
        '
        'predict
        '
        Me.predict.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.predict.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.predict.Location = New System.Drawing.Point(105, 434)
        Me.predict.Name = "predict"
        Me.predict.Size = New System.Drawing.Size(75, 23)
        Me.predict.TabIndex = 9
        Me.predict.Text = "Prediksi"
        Me.predict.UseVisualStyleBackColor = True
        '
        'input_pickup
        '
        Me.input_pickup.Location = New System.Drawing.Point(206, 241)
        Me.input_pickup.Name = "input_pickup"
        Me.input_pickup.Size = New System.Drawing.Size(124, 20)
        Me.input_pickup.TabIndex = 20
        '
        'clear_prediksi
        '
        Me.clear_prediksi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.clear_prediksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.clear_prediksi.Location = New System.Drawing.Point(202, 434)
        Me.clear_prediksi.Name = "clear_prediksi"
        Me.clear_prediksi.Size = New System.Drawing.Size(75, 23)
        Me.clear_prediksi.TabIndex = 10
        Me.clear_prediksi.Text = "Clear"
        Me.clear_prediksi.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(37, 303)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(146, 17)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Jumlah Truck Sedang"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(37, 147)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 17)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Jumlah Mikro Bus"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(37, 272)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(142, 17)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Jumlah Truck Ringan"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(37, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 17)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Jumlah Bus Kecil"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(37, 241)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(136, 17)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Jumlah Mobil Pickup"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(37, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 17)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Jumlah Bus Besar"
        '
        'input_bus_besar
        '
        Me.input_bus_besar.Location = New System.Drawing.Point(206, 209)
        Me.input_bus_besar.Name = "input_bus_besar"
        Me.input_bus_besar.Size = New System.Drawing.Size(124, 20)
        Me.input_bus_besar.TabIndex = 16
        '
        'input_mikro_bus
        '
        Me.input_mikro_bus.Location = New System.Drawing.Point(206, 147)
        Me.input_mikro_bus.Name = "input_mikro_bus"
        Me.input_mikro_bus.Size = New System.Drawing.Size(124, 20)
        Me.input_mikro_bus.TabIndex = 14
        '
        'input_bus_kecil
        '
        Me.input_bus_kecil.Location = New System.Drawing.Point(206, 178)
        Me.input_bus_kecil.Name = "input_bus_kecil"
        Me.input_bus_kecil.Size = New System.Drawing.Size(124, 20)
        Me.input_bus_kecil.TabIndex = 15
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(-1, 487)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(844, 30)
        Me.Panel2.TabIndex = 11
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
        Me.Text = "prediksi"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents clear_prediksi As System.Windows.Forms.Button
    Friend WithEvents predict As System.Windows.Forms.Button
    Friend WithEvents input_mobil_pribadi As System.Windows.Forms.TextBox
    Friend WithEvents input_hujan As System.Windows.Forms.TextBox
    Friend WithEvents input_suhu As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents input_sepeda_motor As System.Windows.Forms.TextBox
    Friend WithEvents input_truck_trailer As System.Windows.Forms.TextBox
    Friend WithEvents input_truck_berat As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents input_truck_sedang As System.Windows.Forms.TextBox
    Friend WithEvents input_truck_ringan As System.Windows.Forms.TextBox
    Friend WithEvents input_pickup As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents input_bus_besar As System.Windows.Forms.TextBox
    Friend WithEvents input_bus_kecil As System.Windows.Forms.TextBox
    Friend WithEvents input_mikro_bus As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents input_drainase As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents keterangan_prediksi As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents prediksiIri As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
