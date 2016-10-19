<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pelatihanPengujian
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pelatihanPengujian))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.grafikLatih = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.msePengujian = New System.Windows.Forms.TextBox()
        Me.jumlahDataPengujian = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.total_epoch = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lama_waktu_pelatihan = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.msePelatihan = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.jumlahDataLatih = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.simpan = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pengujian = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.training = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.input_hidden = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.input_error_rate = New System.Windows.Forms.TextBox()
        Me.input_learning_rate = New System.Windows.Forms.TextBox()
        Me.input_epoch = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.bw_pengujian = New System.ComponentModel.BackgroundWorker()
        Me.Panel3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.grafikLatih, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.GroupBox4)
        Me.Panel3.Controls.Add(Me.GroupBox3)
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Location = New System.Drawing.Point(140, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(702, 487)
        Me.Panel3.TabIndex = 9
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.grafikLatih)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 250)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(689, 231)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(226, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(222, 17)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "GRAFIK PROSES PELATIHAN"
        '
        'grafikLatih
        '
        ChartArea1.AxisX.Title = "Epoch"
        ChartArea1.AxisY.Title = "Nilai MSE"
        ChartArea1.Name = "ChartArea1"
        Me.grafikLatih.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Legend1.Title = "Nilai MSE Akhir"
        Me.grafikLatih.Legends.Add(Legend1)
        Me.grafikLatih.Location = New System.Drawing.Point(7, 19)
        Me.grafikLatih.Name = "grafikLatih"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.grafikLatih.Series.Add(Series1)
        Me.grafikLatih.Size = New System.Drawing.Size(674, 206)
        Me.grafikLatih.TabIndex = 0
        Me.grafikLatih.Text = "Chart1"
        Me.grafikLatih.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.msePengujian)
        Me.GroupBox3.Controls.Add(Me.jumlahDataPengujian)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(393, 149)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(305, 90)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Hasil Pengujian"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 57)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(157, 17)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Akurasi Hasil Pengujian"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(154, 17)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Jumlah Data Pengujian"
        '
        'msePengujian
        '
        Me.msePengujian.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msePengujian.Location = New System.Drawing.Point(196, 57)
        Me.msePengujian.Name = "msePengujian"
        Me.msePengujian.ReadOnly = True
        Me.msePengujian.Size = New System.Drawing.Size(100, 20)
        Me.msePengujian.TabIndex = 5
        '
        'jumlahDataPengujian
        '
        Me.jumlahDataPengujian.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.jumlahDataPengujian.Location = New System.Drawing.Point(196, 24)
        Me.jumlahDataPengujian.Name = "jumlahDataPengujian"
        Me.jumlahDataPengujian.ReadOnly = True
        Me.jumlahDataPengujian.Size = New System.Drawing.Size(100, 20)
        Me.jumlahDataPengujian.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.total_epoch)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lama_waktu_pelatihan)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.msePelatihan)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.jumlahDataLatih)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(394, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(304, 135)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Hasil Pelatihan"
        '
        'total_epoch
        '
        Me.total_epoch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.total_epoch.Location = New System.Drawing.Point(194, 73)
        Me.total_epoch.Name = "total_epoch"
        Me.total_epoch.ReadOnly = True
        Me.total_epoch.Size = New System.Drawing.Size(100, 20)
        Me.total_epoch.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 17)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Total Epoch"
        '
        'lama_waktu_pelatihan
        '
        Me.lama_waktu_pelatihan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lama_waktu_pelatihan.Location = New System.Drawing.Point(194, 103)
        Me.lama_waktu_pelatihan.Name = "lama_waktu_pelatihan"
        Me.lama_waktu_pelatihan.ReadOnly = True
        Me.lama_waktu_pelatihan.Size = New System.Drawing.Size(100, 20)
        Me.lama_waktu_pelatihan.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(150, 17)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Lama Waktu Pelatihan"
        '
        'msePelatihan
        '
        Me.msePelatihan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msePelatihan.Location = New System.Drawing.Point(195, 44)
        Me.msePelatihan.Name = "msePelatihan"
        Me.msePelatihan.ReadOnly = True
        Me.msePelatihan.Size = New System.Drawing.Size(100, 20)
        Me.msePelatihan.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Jumlah Data Latih"
        '
        'jumlahDataLatih
        '
        Me.jumlahDataLatih.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.jumlahDataLatih.Location = New System.Drawing.Point(195, 15)
        Me.jumlahDataLatih.Name = "jumlahDataLatih"
        Me.jumlahDataLatih.ReadOnly = True
        Me.jumlahDataLatih.Size = New System.Drawing.Size(100, 20)
        Me.jumlahDataLatih.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(135, 17)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "MSE Hasil Pelatihan"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.simpan)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.pengujian)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.training)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.input_hidden)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.input_error_rate)
        Me.GroupBox1.Controls.Add(Me.input_learning_rate)
        Me.GroupBox1.Controls.Add(Me.input_epoch)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(378, 232)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parameter Pelatihan"
        '
        'simpan
        '
        Me.simpan.Enabled = False
        Me.simpan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.simpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.simpan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.simpan.Location = New System.Drawing.Point(195, 190)
        Me.simpan.Name = "simpan"
        Me.simpan.Size = New System.Drawing.Size(75, 23)
        Me.simpan.TabIndex = 12
        Me.simpan.Text = "Simpan"
        Me.simpan.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Learning Rate"
        '
        'pengujian
        '
        Me.pengujian.Enabled = False
        Me.pengujian.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.pengujian.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pengujian.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pengujian.Location = New System.Drawing.Point(109, 190)
        Me.pengujian.Name = "pengujian"
        Me.pengujian.Size = New System.Drawing.Size(75, 23)
        Me.pengujian.TabIndex = 11
        Me.pengujian.Text = "Pengujian"
        Me.pengujian.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 0
        '
        'Button7
        '
        Me.Button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(280, 190)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 10
        Me.Button7.Text = "Clear"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Looping/Epoch"
        '
        'training
        '
        Me.training.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.training.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.training.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.training.Location = New System.Drawing.Point(21, 190)
        Me.training.Name = "training"
        Me.training.Size = New System.Drawing.Size(75, 23)
        Me.training.TabIndex = 9
        Me.training.Text = "Training"
        Me.training.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(28, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Error Rate"
        '
        'input_hidden
        '
        Me.input_hidden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.input_hidden.Location = New System.Drawing.Point(197, 140)
        Me.input_hidden.Name = "input_hidden"
        Me.input_hidden.Size = New System.Drawing.Size(124, 20)
        Me.input_hidden.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(28, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Total Hidden Layer"
        '
        'input_error_rate
        '
        Me.input_error_rate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.input_error_rate.Location = New System.Drawing.Point(197, 106)
        Me.input_error_rate.Name = "input_error_rate"
        Me.input_error_rate.Size = New System.Drawing.Size(124, 20)
        Me.input_error_rate.TabIndex = 7
        '
        'input_learning_rate
        '
        Me.input_learning_rate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.input_learning_rate.Location = New System.Drawing.Point(197, 38)
        Me.input_learning_rate.Name = "input_learning_rate"
        Me.input_learning_rate.Size = New System.Drawing.Size(124, 20)
        Me.input_learning_rate.TabIndex = 5
        '
        'input_epoch
        '
        Me.input_epoch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.input_epoch.Location = New System.Drawing.Point(197, 72)
        Me.input_epoch.Name = "input_epoch"
        Me.input_epoch.Size = New System.Drawing.Size(124, 20)
        Me.input_epoch.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(-1, 487)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(843, 30)
        Me.Panel2.TabIndex = 8
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
        Me.Panel1.TabIndex = 2
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
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'bw_pengujian
        '
        '
        'pelatihanPengujian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 517)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "pelatihanPengujian"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pelatihan dan Pengujian Data "
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.grafikLatih, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents training As System.Windows.Forms.Button
    Friend WithEvents input_hidden As System.Windows.Forms.TextBox
    Friend WithEvents input_error_rate As System.Windows.Forms.TextBox
    Friend WithEvents input_epoch As System.Windows.Forms.TextBox
    Friend WithEvents input_learning_rate As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents pengujian As System.Windows.Forms.Button
    Friend WithEvents msePelatihan As System.Windows.Forms.TextBox
    Friend WithEvents jumlahDataLatih As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents bw_pengujian As System.ComponentModel.BackgroundWorker
    Friend WithEvents simpan As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents grafikLatih As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents msePengujian As System.Windows.Forms.TextBox
    Friend WithEvents jumlahDataPengujian As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lama_waktu_pelatihan As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents total_epoch As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
