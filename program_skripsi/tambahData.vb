Imports WindowsApplication1.koneksi
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data.Odbc
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc.OdbcDataReader
Imports WindowsApplication1.SimpanDataBaru


Public Class tambahData
    Dim add_truckBerat As Double
    Dim add_truckRingan As Double
    Dim add_truckSedang As Double
    Dim add_truckTrailer As Double
    Dim add_busBesar As Double
    Dim add_sepedaMotor As Double
    Private _status As String

    Function simpan_data_baru(ByVal values As SimpanDataBaru) As Boolean
        Dim conn As OdbcConnection
        Dim str_detil_lalin As String = ""
        Dim nomor_id As String = ""

        nomor_id = Trim(values.addTahun & values.addBulan)

        For j = 0 To 9
            str_detil_lalin = str_detil_lalin + values.addMeta_Data_Lalin(j).ToString + ";"
        Next

        Try
            strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
            conn = New OdbcConnection(strcon)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim query_simpan_databaru As String = "INSERT INTO variabel(id_variabel, suhu, curah_hujan, drainase, tot_lalin_smp, iri, status_data, meta_data_lalulintas) VALUES('" & _
                                                  nomor_id & "','" & values.addSuhu.ToString & "','" & values.addCurah.ToString & "','" & _
                                                  values.addDrainase.ToString & "','" & values.addTotal_lalin.ToString & "','" & _
                                                  values.addIri.ToString & "','" & values.addStatus.ToString & "','" & str_detil_lalin & "')"
            Dim cmd As OdbcCommand
            Using conn
                cmd = New Odbc.OdbcCommand(query_simpan_databaru, conn)
                cmd.ExecuteNonQuery()
            End Using
            MsgBox("Data baru berhasil disimpan", MsgBoxStyle.Information, "Success")
            Return True
        Catch ex As Exception
            MsgBox("Data gagal disimpan", MsgBoxStyle.Exclamation, "Warning")
            Return False
        End Try

    End Function

    Function load_data_edit_variabel(ByVal nomorId As String)
        Dim conn As OdbcConnection
        Dim temp_detil_lalin As String
        Dim detil_lalin() As String
        Dim _dataEditVariabel As SimpanDataBaru
        _dataEditVariabel = New SimpanDataBaru

        strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
        conn = New OdbcConnection(strcon)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmd As OdbcCommand
        Dim query_load_data_edit_variabel As String = "Select id_variabel, suhu, curah_hujan, drainase, iri, " + _
                                                      "status_data, meta_data_lalulintas From variabel Where id_variabel ='" + nomorId + "'"

        Using conn
            cmd = New Odbc.OdbcCommand(query_load_data_edit_variabel, conn)
            dr = cmd.ExecuteReader()

            If dr.Read Then
                _dataEditVariabel.nomorIdData = dr("id_variabel")
                _dataEditVariabel.addSuhu = dr("suhu")
                _dataEditVariabel.addCurah = dr("curah_hujan")
                _dataEditVariabel.addDrainase = dr("drainase")
                _dataEditVariabel.addIri = dr("iri")
                _dataEditVariabel.addStatus = dr("status_data")

                temp_detil_lalin = dr("meta_data_lalulintas")
                detil_lalin = temp_detil_lalin.Split(";")

                ReDim _dataEditVariabel.addMeta_Data_Lalin(9)

                For j = 0 To 9
                    _dataEditVariabel.addMeta_Data_Lalin(j) = Convert.ToInt32(detil_lalin(j))
                Next
            Else
                MsgBox("Database is empty")
            End If
        End Using

        Return _dataEditVariabel
    End Function

    Sub update_data_edit(ByVal values As SimpanDataBaru, ByVal nomorId As String)
        Dim conn As OdbcConnection
        Dim update_str_detil_lalin As String = ""

        For j = 0 To 9
            update_str_detil_lalin = update_str_detil_lalin + values.addMeta_Data_Lalin(j).ToString + ";"
        Next

        strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
        conn = New OdbcConnection(strcon)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Dim query_update_data As String = "UPDATE variabel SET suhu = '" & values.addSuhu.ToString & "', curah_hujan = '" & _
                                          values.addCurah.ToString & "', drainase = '" & values.addDrainase.ToString & "', tot_lalin_smp = '" & _
                                          values.addTotal_lalin.ToString & "', iri = '" & values.addIri.ToString & "', status_data = '" & _
                                          values.addStatus.ToString & "', meta_data_lalulintas = '" & update_str_detil_lalin.ToString & "' WHERE id_variabel = '" + nomorId + "'"
        Dim cmd As OdbcCommand
        Using conn
            cmd = New Odbc.OdbcCommand(query_update_data, conn)
            cmd.ExecuteNonQuery()
        End Using
        MsgBox("Data berhasil diperbaharui", MsgBoxStyle.Information, "Success")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles tombol_cancel_tambahData.Click
        Me.Close()
    End Sub

    Private Sub tombol_clear_tambahData_Click(sender As Object, e As EventArgs) Handles tombol_clear_tambahData.Click
        clear_data()
    End Sub

    Private Function CheckInput_TambahDataBaru(ByVal id As String) As Boolean
        Dim sukses As Boolean = True

        If (String.IsNullOrEmpty(tambah_input_bulan.Text.Trim()) And id Is Nothing) Then
            MsgBox("Input bulan harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(tambah_input_tahun.Text.Trim()) And id Is Nothing) Then
            MsgBox("Input tahun harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(tambah_input_suhu.Text.Trim())) Then
            MsgBox("Input suhu harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(tambah_input_hujan.Text.Trim())) Then
            MsgBox("Input curah hujan harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(tambah_input_drainase.Text.Trim())) Then
            MsgBox("Input keadaan drainase harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(tambah_input_mobil_pribadi.Text.Trim())) Then
            MsgBox("Input jumlah mobil pribadi harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(tambah_input_mikro_bus.Text.Trim())) Then
            MsgBox("Input jumlah mikro bus harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(tambah_input_bus_kecil.Text.Trim())) Then
            MsgBox("Input jumlah bus kecil harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(tambah_input_bus_besar.Text.Trim())) Then
            MsgBox("Input jumlah bus besar harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(tambah_input_pickup.Text.Trim())) Then
            MsgBox("Input jumlah mobil pickup harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(tambah_input_truck_ringan.Text.Trim())) Then
            MsgBox("Input jumlah truck ringan harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(tambah_input_truck_sedang.Text.Trim())) Then
            MsgBox("Input jumlah truck sedang harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(tambah_input_truck_berat.Text.Trim())) Then
            MsgBox("Input jumlah truck berat harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(tambah_input_truck_trailer.Text.Trim())) Then
            MsgBox("Input jumlah truck trailer harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(tambah_input_sepeda_motor.Text.Trim())) Then
            MsgBox("Input jumlah sepeda motor harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(tambah_input_iri.Text.Trim())) Then
            MsgBox("Input nilai IRI harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(tambah_input_status.Text.Trim())) Then
            MsgBox("Input status data harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        End If

        Return sukses
    End Function

    Sub clear_data()
        Me.tambah_input_bus_besar.Text = Nothing
        Me.tambah_input_bus_kecil.Text = Nothing
        Me.tambah_input_hujan.Text = Nothing
        Me.tambah_input_mikro_bus.Text = Nothing
        Me.tambah_input_mobil_pribadi.Text = Nothing
        Me.tambah_input_pickup.Text = Nothing
        Me.tambah_input_sepeda_motor.Text = Nothing
        Me.tambah_input_suhu.Text = Nothing
        Me.tambah_input_truck_berat.Text = Nothing
        Me.tambah_input_truck_ringan.Text = Nothing
        Me.tambah_input_truck_sedang.Text = Nothing
        Me.tambah_input_truck_trailer.Text = Nothing
        Me.tambah_input_drainase.Text = Nothing
        Me.tambah_input_tahun.Text = Nothing
        Me.tambah_input_status.Text = Nothing
        Me.tambah_input_bulan.Text = Nothing
        Me.tambah_input_iri.Text = Nothing
    End Sub

    Private Sub tombol_save_tambahData_Click(sender As Object, e As EventArgs) Handles tombol_save_tambahData.Click
        Dim _simpanDataBaru As SimpanDataBaru
        Dim nomer As String
        Dim hasil_cek_input_tambah_data As Boolean
        Dim hasil_cek_fungsi_simpan_data_baru As Boolean

        _simpanDataBaru = New SimpanDataBaru
        hasil_cek_input_tambah_data = CheckInput_TambahDataBaru(_status)

        If _status Is Nothing Then
            If hasil_cek_input_tambah_data = True Then
                _simpanDataBaru.addSuhu = Double.Parse(Me.tambah_input_suhu.Text)
                _simpanDataBaru.addCurah = Double.Parse(Me.tambah_input_hujan.Text)

                If Me.tambah_input_drainase.SelectedIndex = 0 Then
                    _simpanDataBaru.addDrainase = 0
                ElseIf Me.tambah_input_drainase.SelectedIndex = 1 Then
                    _simpanDataBaru.addDrainase = 0.5
                Else
                    _simpanDataBaru.addDrainase = 1
                End If

                _simpanDataBaru.addMeta_Data_Lalin(0) = Convert.ToInt32(Me.tambah_input_mobil_pribadi.Text)
                _simpanDataBaru.addMeta_Data_Lalin(1) = Convert.ToInt32(Me.tambah_input_mikro_bus.Text)
                _simpanDataBaru.addMeta_Data_Lalin(2) = Convert.ToInt32(Me.tambah_input_bus_kecil.Text)
                _simpanDataBaru.addMeta_Data_Lalin(3) = Convert.ToInt32(Me.tambah_input_bus_besar.Text)
                _simpanDataBaru.addMeta_Data_Lalin(4) = Convert.ToInt32(Me.tambah_input_pickup.Text)
                _simpanDataBaru.addMeta_Data_Lalin(5) = Convert.ToInt32(Me.tambah_input_truck_ringan.Text)
                _simpanDataBaru.addMeta_Data_Lalin(6) = Convert.ToInt32(Me.tambah_input_truck_sedang.Text)
                _simpanDataBaru.addMeta_Data_Lalin(7) = Convert.ToInt32(Me.tambah_input_truck_berat.Text)
                _simpanDataBaru.addMeta_Data_Lalin(8) = Convert.ToInt32(Me.tambah_input_truck_trailer.Text)
                _simpanDataBaru.addMeta_Data_Lalin(9) = Convert.ToInt32(Me.tambah_input_sepeda_motor.Text)

                If Me.tambah_input_status.SelectedIndex = 0 Then
                    _simpanDataBaru.addStatus = 0
                Else
                    _simpanDataBaru.addStatus = 1
                End If

                If Me.tambah_input_bulan.SelectedIndex = 0 Then
                    _simpanDataBaru.addBulan = "01"
                ElseIf Me.tambah_input_bulan.SelectedIndex = 1 Then
                    _simpanDataBaru.addBulan = "02"
                ElseIf Me.tambah_input_bulan.SelectedIndex = 2 Then
                    _simpanDataBaru.addBulan = "03"
                ElseIf Me.tambah_input_bulan.SelectedIndex = 3 Then
                    _simpanDataBaru.addBulan = "04"
                ElseIf Me.tambah_input_bulan.SelectedIndex = 4 Then
                    _simpanDataBaru.addBulan = "05"
                ElseIf Me.tambah_input_bulan.SelectedIndex = 5 Then
                    _simpanDataBaru.addBulan = "06"
                ElseIf Me.tambah_input_bulan.SelectedIndex = 6 Then
                    _simpanDataBaru.addBulan = "07"
                ElseIf Me.tambah_input_bulan.SelectedIndex = 7 Then
                    _simpanDataBaru.addBulan = "08"
                ElseIf Me.tambah_input_bulan.SelectedIndex = 8 Then
                    _simpanDataBaru.addBulan = "09"
                ElseIf Me.tambah_input_bulan.SelectedIndex = 9 Then
                    _simpanDataBaru.addBulan = "10"
                ElseIf Me.tambah_input_bulan.SelectedIndex = 10 Then
                    _simpanDataBaru.addBulan = "11"
                ElseIf Me.tambah_input_bulan.SelectedIndex = 11 Then
                    _simpanDataBaru.addBulan = "12"
                End If

                _simpanDataBaru.addTahun = Me.tambah_input_tahun.Text
                _simpanDataBaru.addIri = Double.Parse(Me.tambah_input_iri.Text)

                'Konversi jumlah kendaraan ke satuan SMP
                add_busBesar = _simpanDataBaru.addMeta_Data_Lalin(3) * 1.2
                add_truckRingan = _simpanDataBaru.addMeta_Data_Lalin(5) * 1.2
                add_truckSedang = _simpanDataBaru.addMeta_Data_Lalin(6) * 1.2
                add_truckBerat = _simpanDataBaru.addMeta_Data_Lalin(7) * 1.2
                add_truckTrailer = _simpanDataBaru.addMeta_Data_Lalin(8) * 1.2
                add_sepedaMotor = _simpanDataBaru.addMeta_Data_Lalin(9) * 0.25

                'Jumlah total kendaraan berdasarkan satuan SMP
                _simpanDataBaru.addTotal_lalin = add_busBesar + _simpanDataBaru.addMeta_Data_Lalin(2) + _simpanDataBaru.addMeta_Data_Lalin(1) + _
                    _simpanDataBaru.addMeta_Data_Lalin(0) + _simpanDataBaru.addMeta_Data_Lalin(4) + add_sepedaMotor + add_truckBerat + _
                    add_truckRingan + add_truckSedang + add_truckTrailer

                hasil_cek_fungsi_simpan_data_baru = simpan_data_baru(_simpanDataBaru)
                If hasil_cek_fungsi_simpan_data_baru = True Then
                    Me.Close()
                End If

            End If
        Else
            nomer = Me.nomorId.Text
            _simpanDataBaru.addSuhu = Double.Parse(Me.tambah_input_suhu.Text)
            _simpanDataBaru.addCurah = Double.Parse(Me.tambah_input_hujan.Text)

            If Me.tambah_input_drainase.SelectedIndex = 0 Then
                _simpanDataBaru.addDrainase = 0
            ElseIf Me.tambah_input_drainase.SelectedIndex = 1 Then
                _simpanDataBaru.addDrainase = 0.5
            Else
                _simpanDataBaru.addDrainase = 1
            End If

            _simpanDataBaru.addMeta_Data_Lalin(0) = Convert.ToInt32(Me.tambah_input_mobil_pribadi.Text)
            _simpanDataBaru.addMeta_Data_Lalin(1) = Convert.ToInt32(Me.tambah_input_mikro_bus.Text)
            _simpanDataBaru.addMeta_Data_Lalin(2) = Convert.ToInt32(Me.tambah_input_bus_kecil.Text)
            _simpanDataBaru.addMeta_Data_Lalin(3) = Convert.ToInt32(Me.tambah_input_bus_besar.Text)
            _simpanDataBaru.addMeta_Data_Lalin(4) = Convert.ToInt32(Me.tambah_input_pickup.Text)
            _simpanDataBaru.addMeta_Data_Lalin(5) = Convert.ToInt32(Me.tambah_input_truck_ringan.Text)
            _simpanDataBaru.addMeta_Data_Lalin(6) = Convert.ToInt32(Me.tambah_input_truck_sedang.Text)
            _simpanDataBaru.addMeta_Data_Lalin(7) = Convert.ToInt32(Me.tambah_input_truck_berat.Text)
            _simpanDataBaru.addMeta_Data_Lalin(8) = Convert.ToInt32(Me.tambah_input_truck_trailer.Text)
            _simpanDataBaru.addMeta_Data_Lalin(9) = Convert.ToInt32(Me.tambah_input_sepeda_motor.Text)

            If Me.tambah_input_status.SelectedIndex = 0 Then
                _simpanDataBaru.addStatus = 0
            Else
                _simpanDataBaru.addStatus = 1
            End If

            _simpanDataBaru.addIri = Double.Parse(Me.tambah_input_iri.Text)

            'Konversi jumlah kendaraan ke satuan SMP
            add_busBesar = _simpanDataBaru.addMeta_Data_Lalin(3) * 1.2
            add_truckRingan = _simpanDataBaru.addMeta_Data_Lalin(5) * 1.2
            add_truckSedang = _simpanDataBaru.addMeta_Data_Lalin(6) * 1.2
            add_truckBerat = _simpanDataBaru.addMeta_Data_Lalin(7) * 1.2
            add_truckTrailer = _simpanDataBaru.addMeta_Data_Lalin(8) * 1.2
            add_sepedaMotor = _simpanDataBaru.addMeta_Data_Lalin(9) * 0.25

            'Jumlah total kendaraan berdasarkan satuan SMP
            _simpanDataBaru.addTotal_lalin = add_busBesar + _simpanDataBaru.addMeta_Data_Lalin(2) + _simpanDataBaru.addMeta_Data_Lalin(1) + _
                _simpanDataBaru.addMeta_Data_Lalin(0) + _simpanDataBaru.addMeta_Data_Lalin(4) + add_sepedaMotor + add_truckBerat + _
                add_truckRingan + add_truckSedang + add_truckTrailer

            update_data_edit(_simpanDataBaru, nomer)
            Me.Close()
        End If
    End Sub

    Private Sub tambahData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim thn As Integer
        Dim data_variabel As SimpanDataBaru

        If _status Is Nothing Then
            data_variabel = New SimpanDataBaru
            clear_data()
            Me.Text = "Tambah Data"
            Me.tombol_save_tambahData.Text = "Save"
            Me.panel_id_variabel.Visible = False
        Else
            Me.Text = "Edit Data"
            Me.tombol_save_tambahData.Text = "Update"
            Me.panel_id_variabel.Visible = True
            data_variabel = load_data_edit_variabel(_status)

            tambah_input_bulan.Text = data_variabel.addBulan
            tambah_input_tahun.Text = data_variabel.addTahun
            nomorId.Text = data_variabel.nomorIdData
            tambah_input_suhu.Text = data_variabel.addSuhu
            tambah_input_hujan.Text = data_variabel.addCurah

            If data_variabel.addDrainase = 0 Then
                tambah_input_drainase.SelectedIndex = 0
            ElseIf data_variabel.addDrainase = 0.5 Then
                tambah_input_drainase.SelectedIndex = 1
            ElseIf data_variabel.addDrainase = 1 Then
                tambah_input_drainase.SelectedIndex = 2
            End If

            tambah_input_mobil_pribadi.Text = data_variabel.addMeta_Data_Lalin(0)
            tambah_input_mikro_bus.Text = data_variabel.addMeta_Data_Lalin(1)
            tambah_input_bus_kecil.Text = data_variabel.addMeta_Data_Lalin(2)
            tambah_input_bus_besar.Text = data_variabel.addMeta_Data_Lalin(3)
            tambah_input_pickup.Text = data_variabel.addMeta_Data_Lalin(4)
            tambah_input_truck_ringan.Text = data_variabel.addMeta_Data_Lalin(5)
            tambah_input_truck_sedang.Text = data_variabel.addMeta_Data_Lalin(6)
            tambah_input_truck_berat.Text = data_variabel.addMeta_Data_Lalin(7)
            tambah_input_truck_trailer.Text = data_variabel.addMeta_Data_Lalin(8)
            tambah_input_sepeda_motor.Text = data_variabel.addMeta_Data_Lalin(9)

            tambah_input_iri.Text = data_variabel.addIri

            If data_variabel.addStatus = 0 Then
                tambah_input_status.SelectedIndex = 0
            Else
                tambah_input_status.SelectedIndex = 1
            End If

        End If

        For thn = 2011 To (Today.Year + 5)
            tambah_input_tahun.Items.Add(Str(thn))
        Next
    End Sub

    Public Sub setEditStatus(ByVal statusForm As String)
        _status = statusForm
    End Sub

    Private Sub tambah_input_suhu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tambah_input_suhu.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) And (e.KeyChar <> ".") Then
            MsgBox("Inputan suhu harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub tambah_input_hujan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tambah_input_hujan.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) And (e.KeyChar <> ".") Then
            MsgBox("Inputan curah hujan harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub tambah_input_mobil_pribadi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tambah_input_mobil_pribadi.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah mobil pribadi harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub tambah_input_mikro_bus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tambah_input_mikro_bus.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah mikro bus harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub tambah_input_bus_kecil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tambah_input_bus_kecil.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah bus kecil harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub tambah_input_bus_besar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tambah_input_bus_besar.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah bus besar harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub tambah_input_pickup_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tambah_input_pickup.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah mobil pickup harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub tambah_input_truck_ringan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tambah_input_truck_ringan.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah truck ringan harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub tambah_input_truck_sedang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tambah_input_truck_sedang.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah truck sedang harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub tambah_input_truck_berat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tambah_input_truck_berat.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah truck berat harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub tambah_input_truck_trailer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tambah_input_truck_trailer.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah truck trailer harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub tambah_input_sepeda_motor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tambah_input_sepeda_motor.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah sepeda motor harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub tambah_input_iri_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tambah_input_iri.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) And (e.KeyChar <> ".") Then
            MsgBox("Inputan nilai IRI harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub
End Class