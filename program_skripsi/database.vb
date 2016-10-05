Imports WindowsApplication1.koneksi
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.Odbc
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Data.Odbc.OdbcDataReader
Imports WindowsApplication1.Back_Pro
Imports WindowsApplication1.simpanHasilLatih
Imports WindowsApplication1.SimpanDataBaru
Imports WindowsApplication1.home

Public Class database
    Dim query As String
    Dim _hasillatih As simpanHasilLatih
    Public lth(10) As String
    Public id_latih As Integer
    Public tmp(,) As Double
    Public jum_dataPengujian As Integer
    Public jum_dataPelatihan As Integer
    Public jum_dataHasilPelatihan As Integer
    Public i As Integer

    Private Sub database_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        database_grid()
        hitungData_pengujian()
        hitungData_pelatihan()
        jum_data_pelatihan.Text = jum_dataPelatihan.ToString
        jum_data_pengujian.Text = jum_dataPengujian.ToString
        database_grid_tampilHasilLatih()
        hitungData_Hasilpelatihan()
        jumlah_data_hasil_pelatihan.Text = jum_dataHasilPelatihan.ToString
    End Sub

    Sub database_grid()
        konek()
        Dim query_load_isi_datagrid As String = "Select id_variabel, suhu, curah_hujan, drainase, tot_lalin_smp, iri, status_data From Variabel"
        Dim cmd As OdbcCommand

        hitungData_pelatihan()
        hitungData_pengujian()
        ReDim tmp((jum_dataPengujian + jum_dataPelatihan) - 1, 6)

        Using conn
            cmd = New Odbc.OdbcCommand(query_load_isi_datagrid, conn)
            dr = cmd.ExecuteReader()
            i = 0

            While dr.Read()
                tmp(i, 0) = dr("id_variabel")
                tmp(i, 1) = dr("suhu")
                tmp(i, 2) = dr("curah_hujan")
                tmp(i, 3) = dr("drainase")
                tmp(i, 4) = dr("tot_lalin_smp")
                tmp(i, 5) = dr("iri")
                tmp(i, 6) = dr("status_data")
                i = i + 1
            End While
        End Using

        data.Rows.Clear()

        For j = 0 To i - 1
            Dim newRow() As String = { _
                tmp(j, 0).ToString, tmp(j, 1).ToString, _
                                tmp(j, 2).ToString, "", tmp(j, 4).ToString, tmp(j, 5).ToString, "", "Edit", "Hapus"}

            If tmp(j, 3) = 1 Then
                newRow(3) = "Buruk"
            ElseIf tmp(j, 3) = 0.5 Then
                newRow(3) = "Sedang"
            Else
                newRow(3) = "Baik"
            End If

            If tmp(j, 6) = 0 Then
                newRow(6) = "Pelatihan"
            Else
                newRow(6) = "Pengujian"
            End If

            data.Rows.Add(newRow)
        Next


        'da = New Odbc.OdbcDataAdapter("Select * from variabel", conn)
        'ds = New DataSet
        'ds.Clear()
        'da.Fill(ds, "variabel")
        'DataGridView1.DataSource = (ds.Tables("variabel"))
        'DataGridView1.Refresh()
    End Sub

    Sub database_grid_tampilHasilLatih()
        konek()
        Dim query_load_tampil_dataHasilLatih As String = "Select id_latih, learning, epoh, error, hidden, data_latih, data_uji, total_epoch_digunakan, mse_latih, mse_uji, timestamp From hasillatih order by mse_uji"
        Dim cmd As OdbcCommand
        'Dim tolError As Double
        Using conn
            cmd = New Odbc.OdbcCommand(query_load_tampil_dataHasilLatih, conn)
            dr = cmd.ExecuteReader()

            While dr.Read()
                lth(0) = dr("id_latih")
                lth(1) = dr("timestamp")
                lth(2) = dr("data_latih")
                lth(3) = dr("data_uji")
                lth(4) = dr("learning")
                lth(5) = dr("epoh")
                lth(6) = dr("error")
                lth(7) = dr("hidden")
                lth(8) = dr("total_epoch_digunakan")
                lth(9) = dr("mse_latih")
                lth(10) = dr("mse_uji")

                Dim newRow() As String = { _
                    lth(0).ToString, lth(1).ToString, _
                                    lth(2).ToString, lth(3).ToString, lth(4), lth(5).ToString, lth(6), lth(7).ToString, lth(8).ToString, lth(9), lth(10), "Hapus"}

                dataHasilLatih.Rows.Add(newRow)

            End While
        End Using

        'dataHasilLatih.Rows.Clear()
    End Sub

    'Sub isigrid()
    '    Dim conn As OdbcConnection
    '    strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
    '    conn = New OdbcConnection(strcon)
    '    If conn.State = ConnectionState.Closed Then
    '        conn.Open()
    '    End If
    '    Dim query_load_data_pelatihan As String = "Select suhu, curah_hujan, drainase, tot_lalin_smp, iri From variabel Where status_data=0"
    '    Dim cmd As OdbcCommand

    '    hitungData_pelatihan()
    '    ReDim tmp(jum_dataPelatihan - 1, 4)
    '    Using conn
    '        cmd = New Odbc.OdbcCommand(query_load_data_pelatihan, conn)
    '        dr = cmd.ExecuteReader()
    '        i = 0

    '        While dr.Read()
    '            tmp(i, 0) = dr("suhu")
    '            tmp(i, 1) = dr("curah_hujan")
    '            tmp(i, 2) = dr("drainase")
    '            tmp(i, 3) = dr("tot_lalin_smp")
    '            tmp(i, 4) = dr("iri")

    '            i = i + 1
    '        End While
    '    End Using
    'End Sub

    'Sub isiData_Pengujian()
    '    Dim conn As OdbcConnection
    '    strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
    '    conn = New OdbcConnection(strcon)
    '    If conn.State = ConnectionState.Closed Then
    '        conn.Open()
    '    End If
    '    Dim query_load_data_pengujian As String = "Select suhu, curah_hujan, drainase, tot_lalin_smp, iri From variabel Where status_data=1"
    '    Dim cmd As OdbcCommand

    '    hitungData_pengujian()
    '    ReDim tmp(jum_dataPengujian - 1, 4)
    '    Using conn
    '        cmd = New Odbc.OdbcCommand(query_load_data_pengujian, conn)
    '        dr = cmd.ExecuteReader()
    '        i = 0

    '        While dr.Read()
    '            tmp(i, 0) = dr("suhu")
    '            tmp(i, 1) = dr("curah_hujan")
    '            tmp(i, 2) = dr("drainase")
    '            tmp(i, 3) = dr("tot_lalin_smp")
    '            tmp(i, 4) = dr("iri")

    '            i = i + 1
    '        End While
    '    End Using
    'End Sub

    Sub hitungData_pengujian()
        Dim conn As OdbcConnection
        strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=rawan_banjir;server = localhost; uid=root"
        conn = New OdbcConnection(strcon)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmd As OdbcCommand
        Dim query_hitung_data_pengujian As String = "Select Count(*) From data_banjir Where status=1"

        Using conn
            cmd = New Odbc.OdbcCommand(query_hitung_data_pengujian, conn)
            jum_dataPengujian = cmd.ExecuteScalar()
        End Using
    End Sub

    Sub hitungData_pelatihan()
        Dim conn As OdbcConnection
        strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=rawan_banjir;server = localhost; uid=root"
        conn = New OdbcConnection(strcon)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim query_hitung_data_pelatihan As String = "Select Count(*) From data_banjir Where status=0"
        Dim cmd As OdbcCommand
        Using conn
            cmd = New Odbc.OdbcCommand(query_hitung_data_pelatihan, conn)
            jum_dataPelatihan = cmd.ExecuteScalar()
        End Using
    End Sub

    Sub hitungData_Hasilpelatihan()
        Dim conn As OdbcConnection
        strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=rawan_banjir;server = localhost; uid=root"
        conn = New OdbcConnection(strcon)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim query_hitung_data_hasil_pelatihan As String = "Select Count(*) From hasillatih"
        Dim cmd As OdbcCommand
        Using conn
            cmd = New Odbc.OdbcCommand(query_hitung_data_hasil_pelatihan, conn)
            jum_dataHasilPelatihan = cmd.ExecuteScalar()
        End Using
    End Sub

    'Sub isiData_Prediksi()
    '    Dim conn As OdbcConnection
    '    strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
    '    conn = New OdbcConnection(strcon)
    '    If conn.State = ConnectionState.Closed Then
    '        conn.Open()
    '    End If
    '    Dim query_load_data_prediksi As String = "Select suhu, curah_hujan, drainase, tot_lalin_smp, iri From variabel"
    '    Dim cmd As OdbcCommand

    '    hitungData_pengujian()
    '    hitungData_pelatihan()
    '    ReDim tmp((jum_dataPengujian + jum_dataPelatihan) - 1, 4)
    '    Using conn
    '        cmd = New Odbc.OdbcCommand(query_load_data_prediksi, conn)
    '        dr = cmd.ExecuteReader()
    '        i = 0

    '        While dr.Read()
    '            tmp(i, 0) = dr("suhu")
    '            tmp(i, 1) = dr("curah_hujan")
    '            tmp(i, 2) = dr("drainase")
    '            tmp(i, 3) = dr("tot_lalin_smp")
    '            tmp(i, 4) = dr("iri")
    '            i = i + 1
    '        End While
    '    End Using
    'End Sub

    'Sub simpan_hasillatih(ByVal values As simpanHasilLatih)
    '    Dim conn As OdbcConnection
    '    Dim i As Integer
    '    Dim str_vij As String = ""
    '    Dim str_wjk As String = ""

    '    hitungData_pengujian()
    '    hitungData_pelatihan()

    '    For j = 0 To values.hidden - 1
    '        For i = 0 To 3
    '            str_vij = str_vij + values.vij_latih(j, i).ToString + ";"
    '        Next
    '        str_vij = str_vij + "|"
    '    Next

    '    For j = 0 To values.hidden
    '        str_wjk = str_wjk + values.wjk_latih(j, 0).ToString + ";"
    '    Next

    '    strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
    '    conn = New OdbcConnection(strcon)
    '    If conn.State = ConnectionState.Closed Then
    '        conn.Open()
    '    End If
    '    Dim query_simpan_latih As String = "INSERT INTO hasillatih(learning, epoh, error, hidden, data_latih, data_uji, bobot_vij, bobot_wjk, total_epoch_digunakan, mse_latih, mse_uji) VALUES('" & values.learning.ToString & "','" & values.epoh.ToString & "','" & values.error_latih.ToString & "','" & values.hidden.ToString & "','" & jum_dataPelatihan & "','" & jum_dataPengujian & "','" & str_vij & "','" & str_wjk & "','" & values.total_epoch_digunakan.ToString & "','" & values.mse_latih & "','" & values.mse_uji.ToString & "')"
    '    Dim cmd As OdbcCommand
    '    Using conn
    '        cmd = New Odbc.OdbcCommand(query_simpan_latih, conn)
    '        cmd.ExecuteNonQuery()
    '    End Using
    '    MsgBox("Data hasil pelatihan berhasil disimpan")
    'End Sub

    'Function load_data_hasil_latih()
    '    Dim conn As OdbcConnection
    '    Dim temp_vij As String
    '    Dim tempvij() As String
    '    Dim temp_kol_vij() As String
    '    Dim temp_wjk As String
    '    Dim tempwjk() As String
    '    Dim i As Integer
    '    Dim j As Integer

    '    _hasillatih = New simpanHasilLatih

    '    strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
    '    conn = New OdbcConnection(strcon)
    '    If conn.State = ConnectionState.Closed Then
    '        conn.Open()
    '    End If
    '    Dim cmd As OdbcCommand
    '    Dim query_load_data_hasil_latih As String = "Select * From hasillatih order by mse_uji asc limit 1"

    '    Using conn
    '        cmd = New Odbc.OdbcCommand(query_load_data_hasil_latih, conn)
    '        dr = cmd.ExecuteReader()

    '        If dr.Read Then
    '            _hasillatih.learning = dr("learning")
    '            _hasillatih.epoh = dr("epoh")
    '            _hasillatih.hidden = dr("hidden")
    '            _hasillatih.mse_latih = dr("mse_latih")
    '            _hasillatih.error_latih = dr("error")
    '            '_hasillatih.mse_uji = dr("mse_uji")
    '            temp_vij = dr("bobot_vij")
    '            tempvij = temp_vij.Split("|")
    '            temp_wjk = dr("bobot_wjk")
    '            tempwjk = temp_wjk.Split(";")

    '            ReDim _hasillatih.vij_latih(_hasillatih.hidden - 1, 3)
    '            ReDim _hasillatih.wjk_latih(_hasillatih.hidden, 0)

    '            For j = 0 To _hasillatih.hidden - 1
    '                temp_kol_vij = tempvij(j).Split(";")
    '                For i = 0 To 3
    '                    _hasillatih.vij_latih(j, i) = Double.Parse(temp_kol_vij(i))
    '                Next
    '            Next

    '            For j = 0 To _hasillatih.hidden
    '                _hasillatih.wjk_latih(j, 0) = Double.Parse(tempwjk(j))
    '            Next
    '        Else
    '            MsgBox("Database is empty")
    '        End If
    '    End Using
    '    Return _hasillatih
    'End Function

    'Function simpan_data_baru(ByVal values As SimpanDataBaru) As Boolean
    '    Dim conn As OdbcConnection
    '    Dim str_detil_lalin As String = ""
    '    Dim nomor_id As String = ""

    '    nomor_id = Trim(values.addTahun & values.addBulan)

    '    For j = 0 To 9
    '        str_detil_lalin = str_detil_lalin + values.addMeta_Data_Lalin(j).ToString + ";"
    '    Next

    '    Try
    '        strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
    '        conn = New OdbcConnection(strcon)
    '        If conn.State = ConnectionState.Closed Then
    '            conn.Open()
    '        End If
    '        Dim query_simpan_databaru As String = "INSERT INTO variabel(id_variabel, suhu, curah_hujan, drainase, tot_lalin_smp, iri, status_data, meta_data_lalulintas) VALUES('" & _
    '                                              nomor_id & "','" & values.addSuhu.ToString & "','" & values.addCurah.ToString & "','" & _
    '                                              values.addDrainase.ToString & "','" & values.addTotal_lalin.ToString & "','" & _
    '                                              values.addIri.ToString & "','" & values.addStatus.ToString & "','" & str_detil_lalin & "')"
    '        Dim cmd As OdbcCommand
    '        Using conn
    '            cmd = New Odbc.OdbcCommand(query_simpan_databaru, conn)
    '            cmd.ExecuteNonQuery()
    '        End Using
    '        MsgBox("Data baru berhasil disimpan", MsgBoxStyle.Information, "Success")
    '        Return True
    '    Catch ex As Exception
    '        MsgBox("Data gagal disimpan", MsgBoxStyle.Exclamation, "Warning")
    '        Return False
    '    End Try

    'End Function

    'Sub update_data_edit(ByVal values As SimpanDataBaru, ByVal nomorId As String)
    '    Dim conn As OdbcConnection
    '    Dim update_str_detil_lalin As String = ""

    '    For j = 0 To 9
    '        update_str_detil_lalin = update_str_detil_lalin + values.addMeta_Data_Lalin(j).ToString + ";"
    '    Next

    '    strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
    '    conn = New OdbcConnection(strcon)
    '    If conn.State = ConnectionState.Closed Then
    '        conn.Open()
    '    End If

    '    Dim query_update_data As String = "UPDATE variabel SET suhu = '" & values.addSuhu.ToString & "', curah_hujan = '" & _
    '                                      values.addCurah.ToString & "', drainase = '" & values.addDrainase.ToString & "', tot_lalin_smp = '" & _
    '                                      values.addTotal_lalin.ToString & "', iri = '" & values.addIri.ToString & "', status_data = '" & _
    '                                      values.addStatus.ToString & "', meta_data_lalulintas = '" & update_str_detil_lalin.ToString & "' WHERE id_variabel = '" + nomorId + "'"
    '    Dim cmd As OdbcCommand
    '    Using conn
    '        cmd = New Odbc.OdbcCommand(query_update_data, conn)
    '        cmd.ExecuteNonQuery()
    '    End Using
    '    MsgBox("Data berhasil diperbaharui", MsgBoxStyle.Information, "Success")

    'End Sub

    'Function load_data_edit_variabel(ByVal nomorId As String)
    '    Dim conn As OdbcConnection
    '    Dim temp_detil_lalin As String
    '    Dim detil_lalin() As String
    '    Dim _dataEditVariabel As SimpanDataBaru
    '    _dataEditVariabel = New SimpanDataBaru

    '    strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
    '    conn = New OdbcConnection(strcon)
    '    If conn.State = ConnectionState.Closed Then
    '        conn.Open()
    '    End If
    '    Dim cmd As OdbcCommand
    '    Dim query_load_data_edit_variabel As String = "Select id_variabel, suhu, curah_hujan, drainase, iri, " + _
    '                                                  "status_data, meta_data_lalulintas From variabel Where id_variabel ='" + nomorId + "'"

    '    Using conn
    '        cmd = New Odbc.OdbcCommand(query_load_data_edit_variabel, conn)
    '        dr = cmd.ExecuteReader()

    '        If dr.Read Then
    '            _dataEditVariabel.nomorIdData = dr("id_variabel")
    '            _dataEditVariabel.addSuhu = dr("suhu")
    '            _dataEditVariabel.addCurah = dr("curah_hujan")
    '            _dataEditVariabel.addDrainase = dr("drainase")
    '            _dataEditVariabel.addIri = dr("iri")
    '            _dataEditVariabel.addStatus = dr("status_data")

    '            temp_detil_lalin = dr("meta_data_lalulintas")
    '            detil_lalin = temp_detil_lalin.Split(";")

    '            ReDim _dataEditVariabel.addMeta_Data_Lalin(9)

    '            For j = 0 To 9
    '                _dataEditVariabel.addMeta_Data_Lalin(j) = Convert.ToInt32(detil_lalin(j))
    '            Next
    '        Else
    '            MsgBox("Database is empty")
    '        End If
    '    End Using

    '    Return _dataEditVariabel
    'End Function

    Sub hapus_data(ByVal nomor As String)
        Dim conn As OdbcConnection
        Dim konfirmasi As DialogResult = MsgBox("Anda yakini ingin menghapus item ini?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question)

        If konfirmasi = Windows.Forms.DialogResult.OK Then
            strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
            conn = New OdbcConnection(strcon)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim cmd As OdbcCommand
            Dim query_hapus_data As String = "Delete From variabel Where id_variabel ='" + nomor + "'"
            Using conn
                cmd = New Odbc.OdbcCommand(query_hapus_data, conn)
                cmd.ExecuteNonQuery()
            End Using
            MsgBox("Data berhasil dihapus")
        End If
    End Sub

    Sub hapus_data_latih(ByVal nomorId As String)
        Dim conn As OdbcConnection
        Dim konfirmasi As DialogResult = MsgBox("Anda yakini ingin menghapus item ini?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question)

        If konfirmasi = Windows.Forms.DialogResult.OK Then
            strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
            conn = New OdbcConnection(strcon)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim cmd As OdbcCommand
            Dim query_hapus_data_latih As String = "Delete From hasillatih Where id_latih ='" + nomorId + "'"
            Using conn
                cmd = New Odbc.OdbcCommand(query_hapus_data_latih, conn)
                cmd.ExecuteNonQuery()
            End Using

            MsgBox("Data berhasil dihapus")
            dataHasilLatih.Rows.Clear()
        End If

    End Sub

    'Sub grafik_home(ByVal chart1 As Chart)
    '    Dim conn As OdbcConnection
    '    strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
    '    conn = New OdbcConnection(strcon)
    '    If conn.State = ConnectionState.Closed Then
    '        conn.Open()
    '    End If
    '    Dim query_load_data_grafik_home As String = "Select id_variabel, iri From variabel order by id_variabel desc limit 48"
    '    Dim cmd As OdbcCommand

    '    hitungData_pelatihan()
    '    hitungData_pengujian()

    '    ReDim tmp((jum_dataPengujian + jum_dataPelatihan) - 1, 1)
    '    Using conn
    '        cmd = New Odbc.OdbcCommand(query_load_data_grafik_home, conn)
    '        dr = cmd.ExecuteReader()
    '        i = 0

    '        While dr.Read()
    '            tmp(i, 0) = dr("id_variabel")
    '            tmp(i, 0) = Strings.Left(tmp(i, 0), 4)
    '            tmp(i, 1) = dr("iri")
    '            i = i + 1
    '        End While

    '        chart1.Series(0).Points.Clear()
    '        For j = i To 0 Step -1
    '            With home.Chart1
    '                .ChartAreas(0).AxisX.Interval = 12
    '                .ChartAreas(0).AxisY.Interval = 1
    '                .ChartAreas(0).AxisX.IsStartedFromZero = True

    '                .Series(0).Name = tmp(j, 1).ToString

    '                .Series(0).Points.AddXY(tmp(j, 0).ToString, tmp(j, 1))

    '            End With

    '        Next

    '    End Using
    'End Sub

    'Function ambil_id()
    '    Dim conn As OdbcConnection
    '    Dim BulanTahun As String = ""
    '    strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
    '    conn = New OdbcConnection(strcon)
    '    If conn.State = ConnectionState.Closed Then
    '        conn.Open()
    '    End If
    '    Dim query_load_ambil_id As String = "Select id_variabel From variabel order by id_variabel desc limit 1"
    '    Dim cmd As OdbcCommand
    '    Using conn
    '        cmd = New Odbc.OdbcCommand(query_load_ambil_id, conn)
    '        dr = cmd.ExecuteReader()

    '        If dr.Read Then
    '            BulanTahun = dr("id_variabel")
    '        Else
    '            MsgBox("Database is empty")
    '        End If
    '    End Using
    '    Return BulanTahun
    'End Function

    Private Sub database_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        home.Show()
        Me.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pelatihanPengujian.Show()
        Me.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        prediksi.Show()
        Me.Visible = False
    End Sub

    Private Sub tambah_Click(sender As Object, e As EventArgs)
        tambahData.setEditStatus(Nothing)
        tambahData.ShowDialog()
        database_grid()
    End Sub

    Private Sub data_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub data_CellClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellClick
        Dim kolom_id As String

        If e.ColumnIndex = 7 Then
            kolom_id = data.Rows(e.RowIndex).Cells(0).Value.ToString()
            tambahData.setEditStatus(kolom_id)
            tambahData.ShowDialog()
            database_grid()
            hitungData_pengujian()
            hitungData_pelatihan()
            jum_data_pelatihan.Text = jum_dataPelatihan.ToString
            jum_data_pengujian.Text = jum_dataPengujian.ToString
        ElseIf e.ColumnIndex = 8 Then
            kolom_id = data.Rows(e.RowIndex).Cells(0).Value.ToString()
            hapus_data(kolom_id)
            database_grid()
            hitungData_pengujian()
            hitungData_pelatihan()
            jum_data_pelatihan.Text = jum_dataPelatihan.ToString
            jum_data_pengujian.Text = jum_dataPengujian.ToString
        End If
    End Sub

    Private Sub tambah_Click_1(sender As Object, e As EventArgs) Handles tambah.Click
        tambahData.setEditStatus(Nothing)
        tambahData.ShowDialog()
        database_grid()
    End Sub

    Private Sub dataHasilLatih_CellClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dataHasilLatih.CellClick
        Dim kolom_id_latih As String

        If e.ColumnIndex = 11 Then
            kolom_id_latih = dataHasilLatih.Rows(e.RowIndex).Cells(0).Value.ToString
            hapus_data_latih(kolom_id_latih)
            hitungData_Hasilpelatihan()
            jumlah_data_hasil_pelatihan.Text = jum_dataHasilPelatihan.ToString
            database_grid_tampilHasilLatih()
        End If
    End Sub
End Class