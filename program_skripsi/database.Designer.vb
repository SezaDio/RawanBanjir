<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class database
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(database))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.jum_data_pengujian = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.jum_data_pelatihan = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tambah = New System.Windows.Forms.Button()
        Me.data = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.suhu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hujan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.drainase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.total_lalin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.iri = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.edit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.hapus = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.jumlah_data_hasil_pelatihan = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dataHasilLatih = New System.Windows.Forms.DataGridView()
        Me.id_hasil_latih = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_variabel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.data_latih = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.data_uji = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.learning = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.epoh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toleransi_error = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hidden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.total_epoch_digunakan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mse_latih = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mse_uji = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aksi = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dataHasilLatih, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(143, 526)
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
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(-1, 487)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1098, 68)
        Me.Panel2.TabIndex = 11
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.TabControl1)
        Me.Panel3.Location = New System.Drawing.Point(140, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(955, 525)
        Me.Panel3.TabIndex = 12
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(15, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(928, 506)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.jum_data_pengujian)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.jum_data_pelatihan)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.tambah)
        Me.TabPage1.Controls.Add(Me.data)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(920, 480)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Data Instansi"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'jum_data_pengujian
        '
        Me.jum_data_pengujian.Location = New System.Drawing.Point(845, 8)
        Me.jum_data_pengujian.Name = "jum_data_pengujian"
        Me.jum_data_pengujian.ReadOnly = True
        Me.jum_data_pengujian.Size = New System.Drawing.Size(44, 20)
        Me.jum_data_pengujian.TabIndex = 7
        Me.jum_data_pengujian.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(762, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Data Pengujian"
        '
        'jum_data_pelatihan
        '
        Me.jum_data_pelatihan.Location = New System.Drawing.Point(683, 8)
        Me.jum_data_pelatihan.Name = "jum_data_pelatihan"
        Me.jum_data_pelatihan.ReadOnly = True
        Me.jum_data_pelatihan.Size = New System.Drawing.Size(44, 20)
        Me.jum_data_pelatihan.TabIndex = 5
        Me.jum_data_pelatihan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(600, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Data Pelatihan"
        '
        'tambah
        '
        Me.tambah.Location = New System.Drawing.Point(0, 3)
        Me.tambah.Name = "tambah"
        Me.tambah.Size = New System.Drawing.Size(87, 28)
        Me.tambah.TabIndex = 3
        Me.tambah.Text = "Add New Data"
        Me.tambah.UseVisualStyleBackColor = True
        '
        'data
        '
        Me.data.AllowUserToAddRows = False
        Me.data.AllowUserToResizeColumns = False
        Me.data.AllowUserToResizeRows = False
        Me.data.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.data.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.data.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.data.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.data.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.suhu, Me.hujan, Me.drainase, Me.total_lalin, Me.iri, Me.status, Me.edit, Me.hapus})
        Me.data.Location = New System.Drawing.Point(1, 35)
        Me.data.Name = "data"
        Me.data.RowHeadersVisible = False
        Me.data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.data.Size = New System.Drawing.Size(919, 457)
        Me.data.TabIndex = 2
        '
        'id
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.id.DefaultCellStyle = DataGridViewCellStyle1
        Me.id.HeaderText = "ID Variabel"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        '
        'suhu
        '
        Me.suhu.HeaderText = "Suhu"
        Me.suhu.Name = "suhu"
        Me.suhu.ReadOnly = True
        '
        'hujan
        '
        Me.hujan.HeaderText = "Curah Hujan"
        Me.hujan.Name = "hujan"
        Me.hujan.ReadOnly = True
        '
        'drainase
        '
        Me.drainase.HeaderText = "Kondisi Drainase"
        Me.drainase.Name = "drainase"
        Me.drainase.ReadOnly = True
        '
        'total_lalin
        '
        Me.total_lalin.HeaderText = "Jumlah Lalu Lintas Kendaraan"
        Me.total_lalin.Name = "total_lalin"
        Me.total_lalin.ReadOnly = True
        '
        'iri
        '
        Me.iri.HeaderText = "IRI"
        Me.iri.Name = "iri"
        Me.iri.ReadOnly = True
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        '
        'edit
        '
        Me.edit.HeaderText = "Edit"
        Me.edit.Name = "edit"
        Me.edit.ReadOnly = True
        Me.edit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'hapus
        '
        Me.hapus.HeaderText = "Hapus"
        Me.hapus.Name = "hapus"
        Me.hapus.ReadOnly = True
        Me.hapus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.hapus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.jumlah_data_hasil_pelatihan)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.dataHasilLatih)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(920, 480)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Data Hasil Pelatihan"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'jumlah_data_hasil_pelatihan
        '
        Me.jumlah_data_hasil_pelatihan.Location = New System.Drawing.Point(141, 10)
        Me.jumlah_data_hasil_pelatihan.Name = "jumlah_data_hasil_pelatihan"
        Me.jumlah_data_hasil_pelatihan.ReadOnly = True
        Me.jumlah_data_hasil_pelatihan.Size = New System.Drawing.Size(44, 20)
        Me.jumlah_data_hasil_pelatihan.TabIndex = 2
        Me.jumlah_data_hasil_pelatihan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Jumlah data hasil pelatihan"
        '
        'dataHasilLatih
        '
        Me.dataHasilLatih.AllowUserToAddRows = False
        Me.dataHasilLatih.AllowUserToResizeColumns = False
        Me.dataHasilLatih.AllowUserToResizeRows = False
        Me.dataHasilLatih.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataHasilLatih.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataHasilLatih.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_hasil_latih, Me.id_variabel, Me.data_latih, Me.data_uji, Me.learning, Me.epoh, Me.toleransi_error, Me.hidden, Me.total_epoch_digunakan, Me.mse_latih, Me.mse_uji, Me.aksi})
        Me.dataHasilLatih.Location = New System.Drawing.Point(6, 39)
        Me.dataHasilLatih.Name = "dataHasilLatih"
        Me.dataHasilLatih.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dataHasilLatih.RowHeadersVisible = False
        Me.dataHasilLatih.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataHasilLatih.Size = New System.Drawing.Size(908, 435)
        Me.dataHasilLatih.TabIndex = 0
        '
        'id_hasil_latih
        '
        Me.id_hasil_latih.HeaderText = "Column1"
        Me.id_hasil_latih.Name = "id_hasil_latih"
        Me.id_hasil_latih.Visible = False
        Me.id_hasil_latih.Width = 125
        '
        'id_variabel
        '
        Me.id_variabel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.id_variabel.FillWeight = 159.8985!
        Me.id_variabel.HeaderText = "Tanggal"
        Me.id_variabel.Name = "id_variabel"
        Me.id_variabel.ReadOnly = True
        Me.id_variabel.Width = 148
        '
        'data_latih
        '
        Me.data_latih.HeaderText = "Jumlah Data Latih"
        Me.data_latih.Name = "data_latih"
        Me.data_latih.ReadOnly = True
        '
        'data_uji
        '
        Me.data_uji.HeaderText = "Jumlah Data Uji"
        Me.data_uji.Name = "data_uji"
        Me.data_uji.ReadOnly = True
        '
        'learning
        '
        Me.learning.FillWeight = 90.01694!
        Me.learning.HeaderText = "Learning Rate"
        Me.learning.Name = "learning"
        Me.learning.ReadOnly = True
        '
        'epoh
        '
        Me.epoh.FillWeight = 90.01694!
        Me.epoh.HeaderText = "Maksimum Epoch"
        Me.epoh.Name = "epoh"
        Me.epoh.ReadOnly = True
        Me.epoh.Width = 116
        '
        'toleransi_error
        '
        DataGridViewCellStyle2.Format = "N6"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.toleransi_error.DefaultCellStyle = DataGridViewCellStyle2
        Me.toleransi_error.FillWeight = 90.01694!
        Me.toleransi_error.HeaderText = "Toleransi Error"
        Me.toleransi_error.Name = "toleransi_error"
        Me.toleransi_error.ReadOnly = True
        Me.toleransi_error.Width = 117
        '
        'hidden
        '
        DataGridViewCellStyle3.Format = "N4"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.hidden.DefaultCellStyle = DataGridViewCellStyle3
        Me.hidden.FillWeight = 90.01694!
        Me.hidden.HeaderText = "Jumlah Neuron Hidden"
        Me.hidden.Name = "hidden"
        Me.hidden.ReadOnly = True
        Me.hidden.Width = 150
        '
        'total_epoch_digunakan
        '
        Me.total_epoch_digunakan.HeaderText = "Stop Epoch"
        Me.total_epoch_digunakan.Name = "total_epoch_digunakan"
        Me.total_epoch_digunakan.ReadOnly = True
        '
        'mse_latih
        '
        Me.mse_latih.FillWeight = 90.01694!
        Me.mse_latih.HeaderText = "MSE Hasil Pelatihan"
        Me.mse_latih.Name = "mse_latih"
        Me.mse_latih.ReadOnly = True
        Me.mse_latih.Width = 130
        '
        'mse_uji
        '
        Me.mse_uji.HeaderText = "MSE Pengujian"
        Me.mse_uji.Name = "mse_uji"
        Me.mse_uji.ReadOnly = True
        '
        'aksi
        '
        Me.aksi.FillWeight = 90.01694!
        Me.aksi.HeaderText = "Aksi"
        Me.aksi.Name = "aksi"
        Me.aksi.ReadOnly = True
        Me.aksi.Width = 110
        '
        'database
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1095, 555)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "database"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "database"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dataHasilLatih, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents tambah As System.Windows.Forms.Button
    Friend WithEvents data As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents suhu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hujan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents drainase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents total_lalin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents iri As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents edit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents hapus As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents dataHasilLatih As System.Windows.Forms.DataGridView
    Friend WithEvents jumlah_data_hasil_pelatihan As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents jum_data_pengujian As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents jum_data_pelatihan As System.Windows.Forms.TextBox
    Friend WithEvents id_hasil_latih As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id_variabel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents data_latih As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents data_uji As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents learning As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents epoh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents toleransi_error As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hidden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents total_epoch_digunakan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mse_latih As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mse_uji As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aksi As System.Windows.Forms.DataGridViewButtonColumn
End Class
