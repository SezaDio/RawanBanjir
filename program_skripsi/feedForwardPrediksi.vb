Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions
Imports WindowsApplication1.Back_Pro
Imports WindowsApplication1.pelatihanPengujian
Imports WindowsApplication1.prediksi
Imports WindowsApplication1.simpanHasilLatih


Public Class feedForwardPrediksi
    Public Function feedForward_prediksi() As Double
        Dim i As Integer
        Dim j As Integer

        Dim hidden_prediksi As Integer = prediksi.layer_hidden
        Dim wjk_prediksi(,) As Double = prediksi.tmp_wjk
        Dim vij_prediksi(,) As Double = prediksi.tmp_vij

        Dim masukan_prediksi() As Double = prediksi.xi_input_prediksi

        Dim z_netj_prediksi() As Double
        Dim zj_prediksi() As Double
        Dim y_netk_prediksi As Double
        Dim yk_prediksi As Double

        ReDim z_netj_prediksi(hidden_prediksi - 1)
        ReDim zj_prediksi(hidden_prediksi - 1)

        'Hitung keluaran unit tersembunyi 
        For j = 0 To hidden_prediksi - 1
            z_netj_prediksi(j) = vij_prediksi(j, 0)
            For i = 0 To 3
                z_netj_prediksi(j) = z_netj_prediksi(j) + (masukan_prediksi(i) * (vij_prediksi(j, i + 1)))
            Next
            zj_prediksi(j) = Back_Pro.activasi(z_netj_prediksi(j))
        Next

        'Hitung unit keluaran jaringan Yk
        y_netk_prediksi = wjk_prediksi(0, 0)
        For j = 0 To hidden_prediksi - 1
            y_netk_prediksi = y_netk_prediksi + (zj_prediksi(j) * wjk_prediksi(j + 1, 0))
        Next
        yk_prediksi = Back_Pro.activasi(y_netk_prediksi)

        Return yk_prediksi
    End Function




End Class
