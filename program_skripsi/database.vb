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
        Dim query_load_isi_datagrid As String = "Select id_rawanbanjir, skor_curahhujan, skor_drainase, skor_gunalahan, skor_topografi, tingkat_kerawanan, status From data_banjir"
        Dim cmd As OdbcCommand

        hitungData_pelatihan()
        hitungData_pengujian()
        ReDim tmp((jum_dataPengujian + jum_dataPelatihan) - 1, 6)

        Using conn
            cmd = New Odbc.OdbcCommand(query_load_isi_datagrid, conn)
            dr = cmd.ExecuteReader()
            i = 0

            While dr.Read()
                tmp(i, 0) = dr("id_rawanbanjir")
                tmp(i, 1) = dr("skor_curahhujan")
                tmp(i, 2) = dr("skor_drainase")
                tmp(i, 3) = dr("skor_gunalahan")
                tmp(i, 4) = dr("skor_topografi")
                tmp(i, 5) = dr("tingkat_kerawanan")
                tmp(i, 6) = dr("status")
                i = i + 1
            End While
        End Using

        data.Rows.Clear()

        For j = 0 To i - 1
            Dim newRow() As String = { _
                tmp(j, 0).ToString, tmp(j, 1).ToString, _
                                tmp(j, 2).ToString, tmp(j, 3).ToString, tmp(j, 4).ToString, tmp(j, 5).ToString, "", "Edit", "Hapus"}

            'If tmp(j, 3) = 1 Then
            '    newRow(3) = "Buruk"
            'ElseIf tmp(j, 3) = 0.5 Then
            '    newRow(3) = "Sedang"
            'Else
            '    newRow(3) = "Baik"
            'End If

            If tmp(j, 6) = 0 Then
                newRow(6) = "Pelatihan"
            Else
                newRow(6) = "Pengujian"
            End If

            data.Rows.Add(newRow)
        Next

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

    Sub hapus_data(ByVal nomor As String)
        Dim conn As OdbcConnection
        Dim konfirmasi As DialogResult = MsgBox("Anda yakini ingin menghapus item ini?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question)

        If konfirmasi = Windows.Forms.DialogResult.OK Then
            strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=rawan_banjir;server = localhost; uid=root"
            conn = New OdbcConnection(strcon)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim cmd As OdbcCommand
            Dim query_hapus_data As String = "Delete From data_banjir Where id_rawanbanjir ='" + nomor + "'"
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
            strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=rawan_banjir;server = localhost; uid=root"
            conn = New OdbcConnection(strcon)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim cmd As OdbcCommand
            Dim query_hapus_data_latih As String = "Delete From hasillatih Where id_rawanbanjir ='" + nomorId + "'"
            Using conn
                cmd = New Odbc.OdbcCommand(query_hapus_data_latih, conn)
                cmd.ExecuteNonQuery()
            End Using

            MsgBox("Data berhasil dihapus")
            dataHasilLatih.Rows.Clear()
        End If

    End Sub

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