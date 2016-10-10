Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data.Odbc
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc.OdbcDataReader
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports WindowsApplication1.koneksi
Imports WindowsApplication1.database
Imports WindowsApplication1.Back_Pro
Imports WindowsApplication1.pelatihanPengujian
Imports WindowsApplication1.simpanHasilLatih
Imports WindowsApplication1.feedForwardPrediksi


Public Class prediksi
    Private _forwardPrediksi As feedForwardPrediksi
    Private _dataHasilLatih As simpanHasilLatih
    Private _hasilPrediksi As feedForwardPrediksi

    Dim busBesar As Double
    Dim busKecil As Integer
    Dim hujan As Double
    Dim mikroBus As Integer
    Dim mobilPribadi As Integer
    Dim pickup As Integer
    Dim sepedaMotor As Double
    Dim suhu As Double
    Dim truckBerat As Double
    Dim truckRingan As Double
    Dim truckSedang As Double
    Dim truckTrailer As Double
    Dim drainase As Double
    Dim hasil_prediksi As Double
    Dim totalKendaraan As Integer
    Dim _hasillatih As simpanHasilLatih
    Dim tmp(,) As Double

    public last_data As Double
    Public layer_hidden As Integer
    Public x_denormalisasi As Double
    Public tmp_vij(,) As Double
    Public tmp_wjk(,) As Double
    Public xi_prediksi(3) As Double
    Public xi_input_prediksi(3) As Double
    Public xi_data_prediksi(,) As Double
    Public min_input_prediksi() As Double
    Public max_input_prediksi() As Double
    Public min_target As Double
    Public max_target As Double
    Public listTarget_prediksi() As Double

    Function load_data_hasil_latih()
        Dim conn As OdbcConnection
        Dim temp_vij As String
        Dim tempvij() As String
        Dim temp_kol_vij() As String
        Dim temp_wjk As String
        Dim tempwjk() As String
        Dim i As Integer
        Dim j As Integer

        _hasillatih = New simpanHasilLatih

        strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=rawan_banjir;server = localhost; uid=root"
        conn = New OdbcConnection(strcon)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmd As OdbcCommand
        Dim query_load_data_hasil_latih As String = "Select * From hasillatih order by mse_uji asc limit 1"

        Using conn
            cmd = New Odbc.OdbcCommand(query_load_data_hasil_latih, conn)
            dr = cmd.ExecuteReader()

            If dr.Read Then
                _hasillatih.learning = dr("learning")
                _hasillatih.epoh = dr("epoh")
                _hasillatih.hidden = dr("hidden")
                _hasillatih.mse_latih = dr("mse_latih")
                _hasillatih.error_latih = dr("error")
                '_hasillatih.mse_uji = dr("mse_uji")
                temp_vij = dr("bobot_vij")
                tempvij = temp_vij.Split("|")
                temp_wjk = dr("bobot_wjk")
                tempwjk = temp_wjk.Split(";")

                ReDim _hasillatih.vij_latih(_hasillatih.hidden - 1, 3)
                ReDim _hasillatih.wjk_latih(_hasillatih.hidden, 0)

                For j = 0 To _hasillatih.hidden - 1
                    temp_kol_vij = tempvij(j).Split(";")
                    For i = 0 To 3
                        _hasillatih.vij_latih(j, i) = Double.Parse(temp_kol_vij(i))
                    Next
                Next

                For j = 0 To _hasillatih.hidden
                    _hasillatih.wjk_latih(j, 0) = Double.Parse(tempwjk(j))
                Next
            Else
                MsgBox("Database is empty")
            End If
        End Using
        Return _hasillatih
    End Function

    Sub isiData_Prediksi()
        Dim conn As OdbcConnection

        Dim i As Integer
        strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=rawan_banjir;server = localhost; uid=root"
        conn = New OdbcConnection(strcon)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim query_load_data_prediksi As String = "Select skor_curahhujan, skor_drainase, skor_gunalahan, skor_topografi, tingkat_kerawanan From data_banjir"
        Dim cmd As OdbcCommand

        database.hitungData_pengujian()
        database.hitungData_pelatihan()
        ReDim tmp((database.jum_dataPengujian + database.jum_dataPelatihan) - 1, 4)
        Using conn
            cmd = New Odbc.OdbcCommand(query_load_data_prediksi, conn)
            dr = cmd.ExecuteReader()
            i = 0

            While dr.Read()
                tmp(i, 0) = dr("skor_curahhujan")
                tmp(i, 1) = dr("skor_drainase")
                tmp(i, 2) = dr("skor_gunalahan")
                tmp(i, 3) = dr("skor_topografi")
                tmp(i, 4) = dr("tingkat_kerawanan")
                i = i + 1
            End While
        End Using
    End Sub

    Function ambil_data_terakhir() As Double
        Dim conn As OdbcConnection
        Dim data_terakhir As Double
        strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
        conn = New OdbcConnection(strcon)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim query_ambil_data_terakhir As String = "Select iri From variabel Order By id_variabel desc Limit 1"
        Dim cmd As OdbcCommand
        Using conn
            cmd = New Odbc.OdbcCommand(query_ambil_data_terakhir, conn)
            dr = cmd.ExecuteReader()

            If dr.Read Then
                data_terakhir = dr("iri")
            Else
                MsgBox("Database is empty")
            End If
        End Using
        Return data_terakhir
    End Function

    Private Sub training_Click(sender As Object, e As EventArgs) Handles predict.Click
        Dim hasil_cek_input As Boolean
        Dim kategori_jalan As String = ""

        last_data = ambil_data_terakhir()
        _hasilPrediksi = New feedForwardPrediksi

        hasil_cek_input = CheckInput_Prediksi()
        If hasil_cek_input = True Then
            Prepare_Data_Prediksi()
            hasil_prediksi = _hasilPrediksi.feedForward_prediksi()

            'Denormalisasi hasil prediksi
            hasil_prediksi = hasil_prediksi * (max_target - min_target)
            hasil_prediksi = hasil_prediksi - 0.1
            hasil_prediksi = hasil_prediksi + (0.8 * min_target)
            hasil_prediksi = Math.Round((hasil_prediksi / 0.8), 4)

            MsgBox("Proses prediksi selesai")

            If hasil_prediksi >= 0.0 And hasil_prediksi <= 4.0 Then
                kategori_jalan = "Very Good"
            ElseIf hasil_prediksi > 4.0 And hasil_prediksi <= 8.0 Then
                kategori_jalan = "Good"
            ElseIf hasil_prediksi > 8.0 And hasil_prediksi <= 12.0 Then
                kategori_jalan = "Fair"
            ElseIf hasil_prediksi > 12.0 And hasil_prediksi <= 16.0 Then
                kategori_jalan = "Poor"
            ElseIf hasil_prediksi > 16.0 And hasil_prediksi <= 20 Then
                kategori_jalan = "Bad"
            ElseIf hasil_prediksi > 20 Then
                kategori_jalan = "Very Bad"
            End If

            prediksiIri.Text = hasil_prediksi.ToString

            If hasil_prediksi < last_data Then
                keterangan_prediksi.Text = "Berdasarkan prediksi yang dilakukan, didapatkan nilai IRI sebesar " & hasil_prediksi.ToString & " dengan kategori kondisi jalan " & kategori_jalan & ". Penurunan nilai IRI ini menunjukkan bahwa terdapat proses perbaikan jalan yang dilakukan."
            Else
                keterangan_prediksi.Text = "Berdasarkan prediksi yang dilakukan, didapatkan nilai IRI sebesar " & hasil_prediksi.ToString & " dengan kategori kondisi jalan " & kategori_jalan & "."
            End If
        End If

    End Sub

    Private Sub prediksi_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub clear_prediksi_Click(sender As Object, e As EventArgs) Handles clear_prediksi.Click
        Me.input_hujan.Text = Nothing
        Me.input_mobil_pribadi.Text = Nothing
        Me.input_suhu.Text = Nothing
        Me.input_drainase.Text = Nothing
        Me.prediksiIri.Text = Nothing
        Me.keterangan_prediksi.Text = Nothing
    End Sub

    Private Function CheckInput_Prediksi() As Boolean
        Dim sukses As Boolean = True

        If (String.IsNullOrEmpty(input_suhu.Text.Trim())) Then
            MsgBox("Input suhu harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(input_hujan.Text.Trim())) Then
            MsgBox("Input curah hujan harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(input_drainase.Text.Trim())) Then
            MsgBox("Input keadaan drainase harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(input_mobil_pribadi.Text.Trim())) Then
            MsgBox("Input jumlah mobil pribadi harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        End If

        Return sukses
    End Function

    Private Sub Prepare_Data_Prediksi()
        isiData_Prediksi()
        _dataHasilLatih = load_data_hasil_latih()

        Dim i As Integer
        ReDim min_input_prediksi(3)
        ReDim max_input_prediksi(3)
        ReDim xi_data_prediksi(tmp.GetUpperBound(0), 3)
        ReDim tmp_vij(_dataHasilLatih.hidden - 1, 4)
        ReDim tmp_wjk(_dataHasilLatih.hidden, 0)
        ReDim listTarget_prediksi(tmp.GetUpperBound(0))

        'Pembacaan Inputan variabel yang diinputkaan oleh user
        suhu = Double.Parse(Me.input_suhu.Text)
        hujan = Double.Parse(Me.input_hujan.Text)
        If input_drainase.SelectedIndex = 0 Then
            drainase = 0
        ElseIf input_drainase.SelectedIndex = 1 Then
            drainase = 0.5
        Else
            drainase = 1
        End If
        mobilPribadi = Convert.ToInt32(Me.input_mobil_pribadi.Text)

        'Memasukkan data dari tmp ke variabel xi_prediksi(i,j)
        For j = 0 To 3
            For i = 0 To tmp.GetUpperBound(0)
                xi_data_prediksi(i, j) = tmp(i, j)
            Next
        Next

        'Memasukkan data target ke dalam variabel xi
        For i = 0 To tmp.GetUpperBound(0)
            listTarget_prediksi(i) = tmp(i, 4)
        Next

        'Mencari max dan min nilai untuk inputan (x1, x2, x3, x4)
        For j = 0 To 3
            min_input_prediksi(j) = xi_data_prediksi(0, j)
            For i = 0 To xi_data_prediksi.GetUpperBound(0)
                If xi_data_prediksi(i, j) > max_input_prediksi(j) Then
                    max_input_prediksi(j) = xi_data_prediksi(i, j)
                End If
                If xi_data_prediksi(i, j) < min_input_prediksi(j) Then
                    min_input_prediksi(j) = xi_data_prediksi(i, j)
                End If
            Next
        Next

        'Mencari max min untuk nilai target
        For i = 0 To listTarget_prediksi.GetUpperBound(0)
            If listTarget_prediksi(i) > max_target Then
                max_target = listTarget_prediksi(i)
            End If
            If listTarget_prediksi(i) < min_target Then
                min_target = listTarget_prediksi(i)
            End If
        Next

        'Konversi jumlah kendaraan ke satuan SMP
        busBesar = busBesar * 1.2
        truckRingan = truckRingan * 1.2
        truckSedang = truckSedang * 1.2
        truckBerat = truckBerat * 1.2
        truckTrailer = truckTrailer * 1.2
        sepedaMotor = sepedaMotor * 0.25

        'Jumlah total kendaraan berdasarkan satuan SMP
        totalKendaraan = busBesar + busKecil + mikroBus + mobilPribadi + pickup + sepedaMotor + truckBerat + truckRingan + truckSedang + truckTrailer

        'Memasukkan data iputan ke dalam array
        xi_prediksi(0) = suhu
        xi_prediksi(1) = hujan
        xi_prediksi(2) = drainase
        xi_prediksi(3) = totalKendaraan

        'Normalisasi data inputan (x1, x2, x3, x4) agar nilainya antara 0 hingga 1
        For i = 0 To 3
            If (xi_prediksi(i) = 0 Or xi_prediksi(i) = 1 Or xi_prediksi(i) = 0.5) Then
                xi_prediksi(i) = xi_prediksi(i)
            Else
                xi_prediksi(i) = ((0.8 * (xi_prediksi(i) - min_input_prediksi(i))) / (max_input_prediksi(i) - min_input_prediksi(i)) + 0.1)
            End If
        Next

        For i = 0 To 3
            xi_input_prediksi(i) = xi_prediksi(i)
        Next

        layer_hidden = _dataHasilLatih.hidden

        For j = 0 To _dataHasilLatih.hidden - 1
            For i = 0 To 3
                tmp_vij(j, i) = _dataHasilLatih.vij_latih(j, i)
            Next
        Next

        For j = 0 To _dataHasilLatih.hidden
            tmp_wjk(j, 0) = _dataHasilLatih.wjk_latih(j, 0)
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub prediksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        home.Show()
        Me.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pelatihanPengujian.Show()
        Me.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        database.Show()
        Me.Visible = False
    End Sub

    Private Sub input_suhu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles input_suhu.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) And (e.KeyChar <> ".") Then
            MsgBox("Inputan suhu harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub input_hujan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles input_hujan.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) And (e.KeyChar <> ".") Then
            MsgBox("Inputan curah hujan harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub input_mobil_pribadi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles input_mobil_pribadi.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah mobil pribadi harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub input_mikro_bus_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah mikro bus harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub input_bus_kecil_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah bus kecil harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub input_bus_besar_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah bus besar harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub input_pickup_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah mobil pickup harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub input_truck_ringan_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah truck ringan harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub input_truck_sedang_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah truck sedang harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub input_truck_berat_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah truck berat harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub input_truck_trailer_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah truck trailer harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub input_sepeda_motor_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan jumlah sepeda motor harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub
End Class