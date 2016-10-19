Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports WindowsApplication1.Back_Pro
Imports WindowsApplication1.koneksi
Imports WindowsApplication1.database
Imports WindowsApplication1.pelatihanPengujian


Public Class feedForwardPengujian
    Public input_uji As Integer = pelatihanPengujian.tmp.GetUpperBound(0)

    Public Function pengujian() As Double
        Dim i As Integer
        Dim kenal As Integer
        Dim dataKenal As Integer = 0
        Dim j As Integer
        Dim hasil_error As Double = 0
        Dim hidden As Integer = Convert.ToInt32(pelatihanPengujian.input_hidden.Text)
        Dim z_netj_uji() As Double
        Dim masukan(,) As Double = pelatihanPengujian.xi_uji
        Dim z_j() As Double
        Dim y_netk() As Double
        Dim w_jk(,) As Double = pelatihanPengujian.bobot_wjk_hasil_latih
        Dim v_ij(,) As Double = pelatihanPengujian.bobot_hasil_latih
        Dim y_k() As Double
        Dim jumlah_dikenali As Integer = 0
        Dim t() As Double = pelatihanPengujian.ListTarget_uji
        ReDim z_netj_uji(hidden - 1)

        'ReDim masukan(database.tmp.GetUpperBound(0), 3)
        ReDim y_netk(pelatihanPengujian.tmp.GetUpperBound(0))
        ReDim y_k(pelatihanPengujian.tmp.GetUpperBound(0))
        ReDim z_j(hidden - 1)

        For pola = 0 To input_uji

            'Hitung Keluaran Unit tersembunyi
            For j = 0 To hidden - 1
                z_netj_uji(j) = v_ij(j, 0)
                For i = 0 To 3
                    z_netj_uji(j) = z_netj_uji(j) + (masukan(pola, i) * (v_ij(j, i + 1)))
                Next
                z_j(j) = Back_Pro.activasi(z_netj_uji(j))
            Next

            'Hitung Unit keluaran jaringan (Yk)
            y_netk(pola) = w_jk(0, 0)
            For j = 0 To hidden - 1
                y_netk(pola) = y_netk(pola) + (z_j(j) * w_jk(j + 1, 0))
            Next
            y_k(pola) = Back_Pro.activasi(y_netk(pola))

            ' Ubah ke bentuk kelas
            If y_k(pola) >= 0.1 And y_k(pola) <= 0.3 Then
                y_k(pola) = 0.1
            ElseIf y_k(pola) > 0.3 And y_k(pola) <= 0.5 Then
                y_k(pola) = 0.3667
            ElseIf y_k(pola) > 0.5 And y_k(pola) <= 0.7 Then
                y_k(pola) = 0.6333
            ElseIf y_k(pola) > 0.7 And y_k(pola) <= 0.9 Then
                y_k(pola) = 0.9
            End If

            'Pembandingan Yk dengan Target
            If y_k(pola) = t(pola) Then
                kenal = 1
            Else
                kenal = 0
            End If

            'Counter data dikenali
            dataKenal = dataKenal + kenal

            'er = Math.Pow((t(pola) - y_k(pola)), 2)
            'hasil_error = hasil_error + er

            My.Application.Log.WriteEntry(CStr(pola) + " == " + CStr(y_k(pola)) + " " + CStr(t(pola)))
        Next
       
        Return dataKenal
    End Function
End Class
