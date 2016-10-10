Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports WindowsApplication1.Back_Pro
Imports WindowsApplication1.koneksi
Imports WindowsApplication1.database
Imports WindowsApplication1.progress
Imports WindowsApplication1.feedForwardPengujian
Imports WindowsApplication1.simpanHasilLatih

Public Class pelatihanPengujian
    Private _total_Input As Integer
    Private _Jumlah_Hidden As Integer
    Private _activasi As Integer = 0
    Private _nLoop As Integer
    Private _backpro As Back_Pro
    Public i As Integer
    Public bobot_hasil_latih(,) As Double
    Public bobot_wjk_hasil_latih(,) As Double
    Public t() As Double
    Public ListTarget_uji() As Double
    Public xi_uji(,) As Double
    Public max() As Double
    Public min() As Double
    Public epoch_error() As Double
    Public Execution_Start As Stopwatch
    Dim akhir_epoch As Integer
    Public tmp(,) As Double
    Dim mse_hasil_uji As Double

    Sub isigrid()
        Dim conn As OdbcConnection

        strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=rawan_banjir;server = localhost; uid=root"
        conn = New OdbcConnection(strcon)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim query_load_data_pelatihan As String = "Select skor_curahhujan, skor_drainase, skor_gunalahan, skor_topografi, tingkat_kerawanan From data_banjir Where status=0"
        Dim cmd As OdbcCommand

        database.hitungData_pelatihan()
        ReDim tmp(database.jum_dataPelatihan - 1, 4)
        Using conn
            cmd = New Odbc.OdbcCommand(query_load_data_pelatihan, conn)
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

    Sub isiData_Pengujian()
        Dim conn As OdbcConnection
        strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=rawan_banjir;server = localhost; uid=root"
        conn = New OdbcConnection(strcon)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim query_load_data_pengujian As String = "Select skor_curahhujan, skor_drainase, skor_gunalahan, skor_topografi, tingkat_kerawanan From data_banjir Where status=1"
        Dim cmd As OdbcCommand

        database.hitungData_pengujian()
        ReDim tmp(database.jum_dataPengujian - 1, 4)
        Using conn
            cmd = New Odbc.OdbcCommand(query_load_data_pengujian, conn)
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

    Sub simpan_hasillatih(ByVal values As simpanHasilLatih)
        Dim conn As OdbcConnection
        Dim i As Integer
        Dim str_vij As String = ""
        Dim str_wjk As String = ""

        database.hitungData_pengujian()
        database.hitungData_pelatihan()

        For j = 0 To values.hidden - 1
            For i = 0 To 3
                str_vij = str_vij + values.vij_latih(j, i).ToString + ";"
            Next
            str_vij = str_vij + "|"
        Next

        For j = 0 To values.hidden
            str_wjk = str_wjk + values.wjk_latih(j, 0).ToString + ";"
        Next

        strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=rawan_banjir;server = localhost; uid=root"
        conn = New OdbcConnection(strcon)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim query_simpan_latih As String = "INSERT INTO hasillatih(learning, epoh, error, hidden, data_latih, data_uji, bobot_vij, bobot_wjk, total_epoch_digunakan, mse_latih, mse_uji) VALUES('" & values.learning.ToString & "','" & values.epoh.ToString & "','" & values.error_latih.ToString & "','" & values.hidden.ToString & "','" & database.jum_dataPelatihan & "','" & database.jum_dataPengujian & "','" & str_vij & "','" & str_wjk & "','" & values.total_epoch_digunakan.ToString & "','" & values.mse_latih & "','" & values.mse_uji.ToString & "')"
        Dim cmd As OdbcCommand
        Using conn
            cmd = New Odbc.OdbcCommand(query_simpan_latih, conn)
            cmd.ExecuteNonQuery()
        End Using
        MsgBox("Data hasil pelatihan berhasil disimpan")
    End Sub

    'Pengecekan inputan learning rate, epoch, hidden layer, dan error rate
    Private Function CheckInput() As Boolean
        Dim sukses As Boolean = True

        If (String.IsNullOrEmpty(input_learning_rate.Text.Trim())) Then
            MsgBox("Nilai learning rate harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (Double.Parse(Me.input_learning_rate.Text.Trim())) > 1 Or (Double.Parse(Me.input_learning_rate.Text.Trim)) < 0 Then
            MsgBox("Learning rate harus bernilai lebih kecil dari 1 dan lebih besar dari 0", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        End If

        If (String.IsNullOrEmpty(input_epoch.Text.Trim())) Then
            MsgBox("Jumlah epoch harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (Convert.ToInt32(Me.input_epoch.Text.Trim())) <= 0 Then
            MsgBox("Jumlah epoch tidak boleh kurang dari atau sama dengan 0", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        End If

        If (String.IsNullOrEmpty(input_error_rate.Text.Trim())) Then
            MsgBox("Nilai toleransi error harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (Double.Parse(Me.input_error_rate.Text.Trim())) <= 0 Or (Double.Parse(Me.input_error_rate.Text.Trim())) >= 1 Then
            MsgBox("Toleransi error harus bernilai lebih besar dari 0 dan lebih kecil dari 1", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        End If

        If (String.IsNullOrEmpty(input_hidden.Text.Trim())) Then
            MsgBox("Jumlah neuron hidden layer harus diisi", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        ElseIf (Convert.ToInt32(Me.input_hidden.Text.Trim())) <= 0 Then
            MsgBox("Jumlah neuron hidden layer harus lebih dari 0", MsgBoxStyle.Exclamation, "Warning")
            sukses = False
        End If

        Return sukses
    End Function

    'Melakukan persiapan untuk data yang akan dilatih
    Private Sub PrepareData()
        Dim i As Integer

        _backpro = New Back_Pro
        _backpro.Jumlah_Hidden = Convert.ToInt32(Me.input_hidden.Text)
        _backpro.Learning_Rate = Double.Parse(Me.input_learning_rate.Text)
        _backpro.Error_Max = Double.Parse(Me.input_error_rate.Text)
        _backpro.Tot_Epoch = Convert.ToInt32(Me.input_epoch.Text)
        _nLoop = Convert.ToInt32(Me.input_epoch.Text)
        Dim uper0 As Integer = tmp.GetUpperBound(0)
        Dim uper1 As Integer = tmp.GetUpperBound(1)
        _backpro.total_Input = uper0
        ReDim _backpro.xi(uper0, 3)
        ReDim _backpro.List_Target(uper0)

        'Memasukkan data dari tmp ke variabel xi(i,j)
        For i = 0 To uper0
            For j = 0 To 3
                _backpro.xi(i, j) = tmp(i, j)
            Next
        Next

        'Memasukkan data target ke dalam variabel xi
        For i = 0 To uper0
            _backpro.List_Target(i) = tmp(i, 4)
        Next
        Stop
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        home.Show()
        Me.Visible = False
    End Sub

    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub


    Private Sub training_Click(sender As Object, e As EventArgs) Handles training.Click
        If Not CheckInput() Then
            Return
        End If
        progress.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.input_learning_rate.Text = Nothing
        Me.input_epoch.Text = Nothing
        Me.input_error_rate.Text = Nothing
        Me.input_hidden.Text = Nothing
        Me.jumlahDataLatih.Text = Nothing
        Me.msePelatihan.Text = Nothing
        Me.total_epoch.Text = Nothing
        Me.jumlahDataPengujian.Text = Nothing
        Me.msePengujian.Text = Nothing
        Me.lama_waktu_pelatihan.Text = Nothing
    End Sub

    Private Sub pelatihan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isigrid()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim delta As Double = 100 / _nLoop
        Dim i As Integer = 0

        ReDim epoch_error(_backpro.Tot_Epoch)

        _backpro.InitialData()

        'timer lama waktu pelatihan
        Execution_Start = New Stopwatch
        Execution_Start.Start()

        While (i <= _nLoop - 1 And _backpro.Error_Max < _backpro.mse)
            If BackgroundWorker1.CancellationPending = True Then
                Exit While
            End If
            _backpro.mse = 0
            System.Diagnostics.Debug.WriteLine("Epoch ke " + (CStr(i)))
            BackgroundWorker1.ReportProgress((i + 1) * delta)
            _backpro.run(i)
            _backpro.Tot_Epoch = i + 1
            epoch_error(i) = _backpro.mse
            i = i + 1
        End While
        akhir_epoch = i
        BackgroundWorker1.ReportProgress(100)

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        progress.setProgress(e.ProgressPercentage)
        'System.Diagnostics.Debug.WriteLine("Epoch ke " + (CStr(e.ProgressPercentage)))
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Dim i As Integer
        Dim detik As Double
        Dim menit As Integer
        ReDim bobot_hasil_latih(_backpro.Jumlah_Hidden - 1, _backpro.Jumlah_Variabel)
        ReDim bobot_wjk_hasil_latih(_backpro.Jumlah_Hidden, 0)
        ReDim t(_backpro.xi.GetUpperBound(0))

        'penghentian stopwatch pelatihan
        Execution_Start.Stop()
        detik = Execution_Start.ElapsedMilliseconds / 1000
        If detik >= 60 Then
            menit = Math.Floor(detik / 60)
            detik = (menit * 60) - detik
            lama_waktu_pelatihan.Text = menit.ToString + " Menit" + Math.Floor(detik).ToString + " Detik"
        Else
            lama_waktu_pelatihan.Text = detik.ToString + " Detik"
        End If

        If e.Error IsNot Nothing Then
            MsgBox("Error: " & e.Error.Message)
        ElseIf e.Cancelled Then
            MsgBox("Proses pelatihan dibatalkan")
        Else
            MsgBox("Proses pelatihan selesai pada epoch ke - " + CStr(akhir_epoch))
            progress.Close()
            For j = 0 To _backpro.Jumlah_Hidden - 1
                For i = 0 To _backpro.Jumlah_Variabel
                    bobot_hasil_latih(j, i) = _backpro.vij(j, i)
                Next
            Next

            For j = 0 To _backpro.Jumlah_Hidden
                bobot_wjk_hasil_latih(j, 0) = _backpro.wjk(j, 0)
            Next

            'For i = 0 To _backpro.xi.GetUpperBound(0)
            't(i) = _backpro.List_Target(i)
            'Next

            database.hitungData_pelatihan()
            jumlahDataLatih.Text = database.jum_dataPelatihan
            msePelatihan.Text = _backpro.mse.ToString
            total_epoch.Text = akhir_epoch.ToString

            'panggil procedure grafik pelatihan
            grafikLatih.Visible = True
            grafik_pelatihan()

            pengujian.Enabled = True
            'simpan.Enabled = True
        End If
    End Sub

    Sub cancelTraining()
        If BackgroundWorker1.WorkerSupportsCancellation = True Then
            BackgroundWorker1.CancelAsync()
        End If
    End Sub

    Sub start_train()
        PrepareData()
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub pengujian_Click(sender As Object, e As EventArgs) Handles pengujian.Click
        isiData_Pengujian()

        Dim j As Integer
        Dim i As Integer
        Dim jumlah_data1 As Integer = _backpro.xi.GetUpperBound(0)
        Dim jumlah_data2 As Integer = _backpro.xi.GetUpperBound(1)
        ReDim max(jumlah_data2)
        ReDim min(jumlah_data2)
        ReDim _backpro.delta_k(jumlah_data1)
        ReDim _backpro.yOutput(1)
        ReDim _backpro.Yk(jumlah_data1)

        ReDim ListTarget_uji(tmp.GetUpperBound(0))
        ReDim xi_uji(tmp.GetUpperBound(0), tmp.GetUpperBound(1))

        'Memasukkan data dari tmp ke variabel xi(i,j)
        For j = 0 To tmp.GetUpperBound(1)
            For i = 0 To tmp.GetUpperBound(0)
                xi_uji(i, j) = tmp(i, j)
            Next
        Next

        'Memasukkan data target ke dalam variabel xi
        For i = 0 To tmp.GetUpperBound(0)
            ListTarget_uji(i) = tmp(i, 4)
        Next

        'Mencari max dan min nilai untuk inputan (x1, x2, x3, x4)
        For j = 0 To 3
            min(j) = xi_uji(0, j)
            For i = 0 To xi_uji.GetUpperBound(0)
                If xi_uji(i, j) > max(j) Then
                    max(j) = xi_uji(i, j)
                End If
                If xi_uji(i, j) < min(j) Then
                    min(j) = xi_uji(i, j)
                End If
            Next
        Next
        'Normalisasi data inputan (x1, x2, x3, x4) agar nilainya antara 0 hingga 1
        For i = 0 To xi_uji.GetUpperBound(0)
            For j = 0 To 3
                If (xi_uji(i, j) = 0 Or xi_uji(i, j) = 1 Or xi_uji(i, j) = 0.5) Then
                    xi_uji(i, j) = xi_uji(i, j)
                Else
                    xi_uji(i, j) = ((0.8 * (xi_uji(i, j) - min(j))) / (max(j) - min(j)) + 0.1)
                End If
            Next
        Next

        'Mencari max dan min nilai untuk target
        Dim nilai_besar As Double = 0.0
        Dim nilai_kecil As Double = 999.9
        For i = 0 To ListTarget_uji.GetUpperBound(0)
            If ListTarget_uji(i) > nilai_besar Then
                nilai_besar = ListTarget_uji(i)
            End If
            If ListTarget_uji(i) < nilai_kecil Then
                nilai_kecil = ListTarget_uji(i)
            End If
        Next
        'Normalisasi nilai pada tiap target di dalam list
        For i = 0 To ListTarget_uji.GetUpperBound(0)
            If (ListTarget_uji(i) = 0 Or ListTarget_uji(i) = 1 Or ListTarget_uji(i) = 0.5) Then
                ListTarget_uji(i) = Math.Round(ListTarget_uji(i), 4)
            Else
                ListTarget_uji(i) = Math.Round(((0.8 * (ListTarget_uji(i) - nilai_kecil)) / (nilai_besar - nilai_kecil) + 0.1), 4)
            End If
        Next

        Dim _FeedForward_Pengujian As New feedForwardPengujian
        'Dim data_dikenali As Integer
        'Dim persentase As Double

        MsgBox("Prose pengujian selesai.")
        simpan.Enabled = True
        database.hitungData_pengujian()
        jumlahDataPengujian.Text = database.jum_dataPengujian
        mse_hasil_uji = _FeedForward_Pengujian.pengujian()
        msePengujian.Text = mse_hasil_uji
        'persentase = Math.Round((data_dikenali / (xi_uji.GetUpperBound(0) + 1)) * 100, 2)

        'tidak_kenal.Text = (database.tmp.GetUpperBound(0) + 1 - data_dikenali).ToString
        'persen.Text = persentase.ToString + " %"

        'uji.Visible = True

    End Sub

    Private Sub bw_pengujian_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw_pengujian.DoWork

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        prediksi.Tag = Me
        prediksi.Show(Me)
        Me.Visible = False
    End Sub

    Private Sub simpan_Click(sender As Object, e As EventArgs) Handles simpan.Click
        Dim i As Integer
        Dim _simpanlatih As simpanHasilLatih
        _simpanlatih = New simpanHasilLatih

        ReDim _simpanlatih.vij_latih(_backpro.Jumlah_Hidden - 1, _backpro.Jumlah_Variabel)
        ReDim _simpanlatih.wjk_latih(_backpro.Jumlah_Hidden, 0)

        _simpanlatih.learning = _backpro.Learning_Rate
        _simpanlatih.epoh = Convert.ToInt32(Me.input_epoch.Text)
        _simpanlatih.error_latih = _backpro.Error_Max
        _simpanlatih.hidden = _backpro.Jumlah_Hidden
        _simpanlatih.mse_latih = _backpro.mse
        _simpanlatih.total_epoch_digunakan = akhir_epoch
        _simpanlatih.mse_uji = mse_hasil_uji

        For j = 0 To _backpro.Jumlah_Hidden - 1
            For i = 0 To _backpro.Jumlah_Variabel
                _simpanlatih.vij_latih(j, i) = _backpro.vij(j, i)
            Next
        Next

        For j = 0 To _backpro.Jumlah_Hidden
            _simpanlatih.wjk_latih(j, 0) = _backpro.wjk(j, 0)
        Next

        simpan_hasillatih(_simpanlatih)
    End Sub

    Sub grafik_pelatihan()
        i = _backpro.Tot_Epoch

        grafikLatih.Series(0).Points.Clear()
        For j = 0 To i - 1
            With grafikLatih
                .ChartAreas(0).AxisX.Interval = 1
                .ChartAreas(0).AxisY.Interval = 0.01
                .ChartAreas(0).AxisX.IsStartedFromZero = True

                .Series(0).Name = epoch_error(j).ToString

                .Series(0).Points.AddXY(j + 1, epoch_error(j))

            End With

        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        database.Show()
        Me.Visible = False
    End Sub

    Private Sub input_learning_rate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles input_learning_rate.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) And (e.KeyChar <> ".") Then
            MsgBox("Inputan harus berupa angka antara 0.1 sampai dengan 0.9", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub input_epoch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles input_epoch.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan harus berupa angka dan bernilai positif", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub input_error_rate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles input_error_rate.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) And (e.KeyChar <> ".") Then
            MsgBox("Inputan harus berupa angka dan bernilai positif", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub input_hidden_KeyPress(sender As Object, e As KeyPressEventArgs) Handles input_hidden.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MsgBox("Inputan harus berupa angka dengan nilai lebih dari 0", MsgBoxStyle.Exclamation, "Warning")
            e.Handled = True
        End If
    End Sub
End Class