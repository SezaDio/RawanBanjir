Imports WindowsApplication1.koneksi
Imports WindowsApplication1.database
Imports WindowsApplication1.simpanHasilLatih
Imports WindowsApplication1.prediksi
Imports System.Data.Odbc
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc.OdbcDataReader
Imports System.Windows.Forms.DataVisualization.Charting


Public Class home
    Public tmp(,) As Double

    Function ambil_id()
        Dim conn As OdbcConnection
        Dim BulanTahun As String = ""
        strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
        conn = New OdbcConnection(strcon)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim query_load_ambil_id As String = "Select id_variabel From variabel order by id_variabel desc limit 1"
        Dim cmd As OdbcCommand
        Using conn
            cmd = New Odbc.OdbcCommand(query_load_ambil_id, conn)
            dr = cmd.ExecuteReader()

            If dr.Read Then
                BulanTahun = dr("id_variabel")
            Else
                MsgBox("Database is empty")
            End If
        End Using
        Return BulanTahun
    End Function

    Sub grafik_home(ByVal chart1 As Chart)
        Dim conn As OdbcConnection
        Dim i As Integer
        strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
        conn = New OdbcConnection(strcon)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim query_load_data_grafik_home As String = "Select id_variabel, iri From variabel order by id_variabel desc limit 48"
        Dim cmd As OdbcCommand

        database.hitungData_pelatihan()
        database.hitungData_pengujian()

        ReDim tmp((database.jum_dataPengujian + database.jum_dataPelatihan) - 1, 1)
        Using conn
            cmd = New Odbc.OdbcCommand(query_load_data_grafik_home, conn)
            dr = cmd.ExecuteReader()
            i = 0

            While dr.Read()
                tmp(i, 0) = dr("id_variabel")
                tmp(i, 0) = Strings.Left(tmp(i, 0), 4)
                tmp(i, 1) = dr("iri")
                i = i + 1
            End While

            chart1.Series(0).Points.Clear()
            For j = i To 0 Step -1
                With chart1
                    .ChartAreas(0).AxisX.Interval = 12
                    .ChartAreas(0).AxisY.Interval = 1
                    .ChartAreas(0).AxisX.IsStartedFromZero = True

                    .Series(0).Name = tmp(j, 1).ToString

                    .Series(0).Points.AddXY(tmp(j, 0).ToString, tmp(j, 1))

                End With

            Next

        End Using
    End Sub

    Function ambil_data_iri_terakhir() As Double
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pelatihanPengujian.Tag = Me
        pelatihanPengujian.Show(Me)
        Me.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        database.Tag = Me
        database.Show(Me)
        Me.Visible = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Dim max As Double = 0.0
        Dim min As Double = 999.9

        Dim i As Integer
        Dim xk() As Double = {1, 2, 3, 4, 5, 6, 7}
        For i = 0 To xk.GetUpperBound(0)
            If xk(i) > max Then
                max = xk(i)
            End If
            If xk(i) < min Then
                min = xk(i)
            End If
        Next
        Stop
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        prediksi.Tag = Me
        prediksi.Show(Me)
        Me.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim _dataTerbaik As simpanHasilLatih
        Dim _dataTerbaru As String = ambil_id()
        Dim tahun As String = Strings.Left(_dataTerbaru, 4)
        Dim bulan As String = Strings.Right(_dataTerbaru, 2)
        Dim data_iri As Double = ambil_data_iri_terakhir()
        '_dataTerbaik = database.load_data_hasil_latih()

        grafik_home(Chart1)

        If bulan = "01" Then
            bulan = "Januari"
        ElseIf bulan = "02" Then
            bulan = "Februari"
        ElseIf bulan = "03" Then
            bulan = "Maret"
        ElseIf bulan = "04" Then
            bulan = "April"
        ElseIf bulan = "05" Then
            bulan = "Mei"
        ElseIf bulan = "06" Then
            bulan = "Juni"
        ElseIf bulan = "07" Then
            bulan = "Juli"
        ElseIf bulan = "08" Then
            bulan = "Agustus"
        ElseIf bulan = "09" Then
            bulan = "September"
        ElseIf bulan = "10" Then
            bulan = "Oktober"
        ElseIf bulan = "11" Then
            bulan = "November"
        ElseIf bulan = "12" Then
            bulan = "Desember"
        End If

        'home_learning.Text = (Math.Round(_dataTerbaik.learning, 3)).ToString
        'home_epoh.Text = _dataTerbaik.epoh.ToString
        'home_errorRate.Text = (Math.Round(_dataTerbaik.error_latih, 7)).ToString
        'home_hidden.Text = _dataTerbaik.hidden.ToString
        'home_mse.Text = (Math.Round(_dataTerbaik.mse_latih, 9)).ToString
        home_bulan.Text = bulan + "/" + tahun
        home_iri.Text = data_iri.ToString

    End Sub
End Class
