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

    Dim skor_topografi As Double
    Dim skor_gunalahan As Integer
    Dim skor_curahhujan As Integer
    Dim skor_drainase As Integer
    Dim hasil_prediksi As Double
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
        Dim query_load_data_hasil_latih As String = "Select * From hasillatih order by mse_uji desc limit 1"

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
                tmp(i, 3) = Math.Round((dr("skor_topografi")), 2)
                tmp(i, 4) = dr("tingkat_kerawanan")
                i = i + 1
            End While
        End Using
    End Sub

    Private Sub training_Click(sender As Object, e As EventArgs) Handles predict.Click
        Dim hasil_cek_input As Boolean
        Dim kelas As Integer

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

            If hasil_prediksi >= 1.0 And hasil_prediksi <= 1.75 Then
                kelas = 1
                keterangan_prediksi.Text = "Tidak Rawan Banjir"
            ElseIf hasil_prediksi > 1.75 And hasil_prediksi <= 2.5 Then
                kelas = 2
                keterangan_prediksi.Text = "Cukup Rawan Banjir"
            ElseIf hasil_prediksi > 2.5 And hasil_prediksi <= 3.25 Then
                kelas = 3
                keterangan_prediksi.Text = "Rawan Banjir"
            ElseIf hasil_prediksi > 3.25 And hasil_prediksi <= 4 Then
                kelas = 4
                keterangan_prediksi.Text = "Sangat Rawan Banjir"
            End If

            kategori_jalan.Text = kelas.ToString

        End If

    End Sub

    Private Sub prediksi_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub clear_prediksi_Click(sender As Object, e As EventArgs) Handles clear_prediksi.Click
        Me.input_skordrainase.Text = Nothing
        Me.input_skortopografi.Text = Nothing
        Me.input_skorcurahhujan.Text = Nothing
        Me.input_skorgunalahan.Text = Nothing
        Me.kategori_jalan.Text = Nothing
        Me.keterangan_prediksi.Text = Nothing
    End Sub

    Private Function CheckInput_Prediksi() As Boolean
        Dim sukses As Boolean = True

        If (String.IsNullOrEmpty(input_skorcurahhujan.Text.Trim())) Then
            MsgBox("Input skor curah hujan harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(input_skordrainase.Text.Trim())) Then
            MsgBox("Input skor drainase harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(input_skorgunalahan.Text.Trim())) Then
            MsgBox("Input skor guna lahan harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (String.IsNullOrEmpty(input_skortopografi.Text.Trim())) Then
            MsgBox("Input skor topografi harus diisi", MsgBoxStyle.Exclamation, "Warning")
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

        'Pembacaan Input skor curah hujan
        If Double.Parse(Me.input_skorcurahhujan.Text) >= 0 And Double.Parse(Me.input_skorcurahhujan.Text) <= 100 Then
            skor_curahhujan = 1
        ElseIf Double.Parse(Me.input_skorcurahhujan.Text) >= 101 And Double.Parse(Me.input_skorcurahhujan.Text) <= 300 Then
            skor_curahhujan = 2
        ElseIf Double.Parse(Me.input_skorcurahhujan.Text) >= 301 And Double.Parse(Me.input_skorcurahhujan.Text) <= 400 Then
            skor_curahhujan = 3
        ElseIf Double.Parse(Me.input_skorcurahhujan.Text) > 400 Then
            skor_curahhujan = 4
        End If

        'Pembacaan input skor drainase
        If input_skordrainase.SelectedIndex = 0 Then
            skor_drainase = 1
        Else
            skor_drainase = 2
        End If

        'Pembacaan input skor guna lahan
        If input_skorgunalahan.SelectedIndex = 0 Then
            skor_gunalahan = 5
        ElseIf input_skorgunalahan.SelectedIndex = 1 Then
            skor_gunalahan = 4
        ElseIf input_skorgunalahan.SelectedIndex = 2 Then
            skor_gunalahan = 3
        ElseIf input_skorgunalahan.SelectedIndex = 3 Then
            skor_gunalahan = 2
        ElseIf input_skorgunalahan.SelectedIndex = 4 Then
            skor_gunalahan = 1
        End If

        'Pembacaan input skor topografi
        skor_topografi = CDbl(Me.input_skortopografi.Text)

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
        max_target = 4.0
        min_target = 1.0
        'For i = 0 To listTarget_prediksi.GetUpperBound(0)
        '    If listTarget_prediksi(i) > max_target Then
        '        max_target = listTarget_prediksi(i)
        '    End If
        '    If listTarget_prediksi(i) < min_target Then
        '        min_target = listTarget_prediksi(i)
        '    End If
        'Next

        'Memasukkan data iputan ke dalam array
        xi_prediksi(0) = skor_curahhujan
        xi_prediksi(1) = skor_drainase
        xi_prediksi(2) = skor_gunalahan
        xi_prediksi(3) = skor_topografi

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

    Private Sub input_skorcurahhujan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles input_skorcurahhujan.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) And (e.KeyChar <> ".") Then
            MsgBox("Inputan skor curah hujan harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub input_skortopografi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles input_skortopografi.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) And (e.KeyChar <> ".") Then
            MsgBox("Inputan skor topografi harus berupa angka dan bernilai positif ", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

End Class