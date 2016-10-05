Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions


Public Class Back_Pro
    Public Jumlah_Hidden As Integer
    Public Jumlah_Variabel As Integer = 4
    Public Learning_Rate As Double
    Public Error_Max As Double
    Dim epoch As Integer
    Public Training_Finish As Boolean = False
    Dim Nilai_Error As Double = 0
    Public Tot_Epoch As Integer

    Public total_Input As Integer

    Public nilai_besar As Double = 0.0
    Public nilai_kecil As Double = 999.9
    Public max() As Double
    Public min() As Double
    Public temp_vij(,) As Double
    Public temp_wjk(,) As Double
    Public pvij(,) As Double
    Public pwjk(,) As Double


    Dim Akar As Double
    Dim FaktorSkala As Double
    Public Vnguyen() As Double
    Public vij(,) As Double
    Dim Update_Vij(,) As Double
    Public wjk(,) As Double
    Dim Update_Wjk(,) As Double
    Public xi(,) As Double
    Public List_Target() As Double
    Dim Znet_j() As Double
    Dim Zj() As Double
    Dim Ynet_k() As Double
    Public Yk() As Double
    Dim deltaNet_j() As Double
    Dim delta_j() As Double
    Public delta_k() As Double
    Dim bobot_random() As Double
    Public yOutput() As Double
    Public mse As Double = 1.0

    Function TotalEpoch() As Integer
        Return Tot_Epoch
    End Function

    Function yKeluar() As Double()
        Return yOutput
    End Function

    Function NilaiError() As Double
        Return Nilai_Error
    End Function

    Function ListTarget() As Double()
        Return List_Target
    End Function

    Function ListInput() As Double(,)
        Return xi
    End Function

    Function vijHidden() As Double(,)
        Return vij
    End Function

    Function wjkHidden() As Double(,)
        Return wjk
    End Function

    Function TotalHidden() As Integer
        Return Jumlah_Hidden
    End Function

    Function LearningRate() As Double
        Return Learning_Rate
    End Function

    Function ErrorMax() As Double
        Return Error_Max
    End Function

    Function MaxLoop() As Integer
        Return epoch
    End Function

    'Melakukan Randomize bobot awal untuk setiap jaringan pada input
    Function RandomWeight(ByVal bawah As Double, ByVal atas As Double) As Double
        'bilangan random tanpa angka 0,0
        Dim tmp As Double = 0.0
        Randomize()
        While (tmp = 0)
            'tmp = CDbl(Math.Floor((1 - (-0.99) + 1) * Rnd())) + (-0.99)
            'tmp = CDbl(((1 * Rnd()) * 2) - 1) 'random antara -1 sampai 1
            tmp = CDbl(((atas * Rnd()) * 2) + bawah) 'random antara -0.5 sampai 0.5
        End While
        Return tmp
    End Function

    'Fungsi aktivasi sigmoid biner
    Shared Function activasi(ByVal nilai As Double) As Double
        Dim nilai_Baru As Double = 0

        'If (nilai >= 1) Then
        'nilai_Baru = 0.9999999
        'ElseIf (nilai <= 0) Then
        'nilai_Baru = 0.0
        'ElseIf (nilai > 0 And nilai < 1) Then
        nilai_Baru = (1 / (1 + Math.Exp(-nilai)))
        'End If

        Return nilai_Baru
    End Function

    Sub InitialData()
        vij = New Double(Jumlah_Hidden - 1, Jumlah_Variabel) {}
        wjk = New Double(Jumlah_Hidden, 0) {}
        Vnguyen = New Double(Jumlah_Hidden - 1) {}
        Update_Vij = New Double(Jumlah_Hidden - 1, Jumlah_Variabel) {}
        Update_Wjk = New Double(Jumlah_Hidden, 0) {}
        Znet_j = New Double(Jumlah_Hidden - 1) {}
        Zj = New Double(Jumlah_Hidden - 1) {}
        Ynet_k = New Double() {}
        Yk = New Double() {}
        delta_k = New Double(0 + 1) {}
        deltaNet_j = New Double(Jumlah_Hidden - 1) {}
        delta_j = New Double(Jumlah_Hidden - 1) {}
        yOutput = New Double() {}


        pvij = New Double(Jumlah_Hidden - 1, Jumlah_Variabel) {}
        temp_vij = New Double(Jumlah_Hidden - 1, Jumlah_Variabel) {}

        pwjk = New Double(Jumlah_Hidden, 0) {}
        temp_wjk = New Double(Jumlah_Hidden, 0) {}

        mse = 1

        'Mencari max dan min
        Dim j As Integer
        Dim i As Integer
        Dim jumlah_data1 As Integer = xi.GetUpperBound(0)
        Dim jumlah_data2 As Integer = xi.GetUpperBound(1)
        ReDim max(jumlah_data2)
        ReDim min(jumlah_data2)
        ReDim delta_k(jumlah_data1)
        ReDim yOutput(1)
        ReDim Yk(jumlah_data1)
        ReDim Ynet_k(jumlah_data1)

        'Inisialisasi bobot jaringan awal vij
        For i = 0 To Jumlah_Hidden - 1
            For j = 0 To Jumlah_Variabel
                vij(i, j) = Math.Round(RandomWeight(-0.5, 0.5), 5)
            Next
        Next

        'Inisialisasi bobot jaringan awal wjk
        For j = 0 To Jumlah_Hidden
            wjk(j, 0) = Math.Round(RandomWeight(-1, 1), 5)
        Next

        'Proses nguyen widrow
        Akar = 1 / Jumlah_Variabel
        FaktorSkala = 0.7 * (Math.Pow(Jumlah_Hidden, Akar))
        For j = 0 To Jumlah_Hidden - 1

            Vnguyen(j) = 0
            For i = 0 To Jumlah_Variabel - 1
                Vnguyen(j) = Vnguyen(j) + (Math.Pow(vij(j, i + 1), 2))
            Next
            Vnguyen(j) = Math.Sqrt(Vnguyen(j))
        Next

        For j = 0 To Jumlah_Hidden - 1
            For i = 0 To Jumlah_Variabel - 1
                vij(j, i + 1) = FaktorSkala * vij(j, i + 1) / Vnguyen(j)
            Next
        Next

        For j = 0 To Jumlah_Hidden - 1
            vij(j, 0) = RandomWeight(-FaktorSkala, FaktorSkala)
        Next


        'Mencari max dan min nilai untuk inputan (x1, x2, x3, x4)
        For j = 0 To 3
            min(j) = xi(0, j)
            For i = 0 To jumlah_data1
                If xi(i, j) > max(j) Then
                    max(j) = xi(i, j)
                End If
                If xi(i, j) < min(j) Then
                    min(j) = xi(i, j)
                End If
            Next
        Next

        'Normalisasi data inputan (x1, x2, x3, x4) agar nilainya antara 0 hingga 1
        For i = 0 To jumlah_data1
            For j = 0 To 3
                If (xi(i, j) = 0 Or xi(i, j) = 1 Or xi(i, j) = 0.5) Then
                    xi(i, j) = xi(i, j)
                Else
                    xi(i, j) = ((0.8 * (xi(i, j) - min(j))) / (max(j) - min(j)) + 0.1)
                    'xi(i, j) = (xi(i, j) - min(j)) / (max(j) - min(j))
                End If
            Next
        Next

        'Mencari max dan min nilai untuk target
        For i = 0 To List_Target.GetUpperBound(0)
            If List_Target(i) > nilai_besar Then
                nilai_besar = List_Target(i)
            End If
            If List_Target(i) < nilai_kecil Then
                nilai_kecil = List_Target(i)
            End If
        Next

        'Normalisasi nilai pada tiap target di dalam list
        For i = 0 To List_Target.GetUpperBound(0)
            If (List_Target(i) = 0 Or List_Target(i) = 1 Or List_Target(i) = 0.5) Then
                List_Target(i) = Math.Round(List_Target(i), 4)
            Else
                List_Target(i) = Math.Round(((0.8 * (List_Target(i) - nilai_kecil)) / (nilai_besar - nilai_kecil) + 0.1), 4)
                'List_Target(i) = Math.Round((List_Target(i) - nilai_kecil) / (nilai_besar - nilai_kecil), 4)
            End If
        Next

        Training_Finish = False
    End Sub

    Function run(ByVal iloop As Integer) As Boolean
        Dim j As Integer
        Dim i As Integer
        Dim pola As Integer

        Nilai_Error = 0
        For pola = 0 To total_Input - 1

            'Hitung Keluaran Unit tersembunyi
            For j = 0 To Jumlah_Hidden - 1
                Znet_j(j) = vij(j, 0)
                For i = 0 To Jumlah_Variabel - 1
                    Znet_j(j) = Znet_j(j) + (xi(pola, i) * vij(j, i + 1))
                Next
                Zj(j) = activasi(Znet_j(j))
            Next

            'Hitung Unit keluaran jaringan (Yk)
            Ynet_k(pola) = wjk(0, 0)
            For j = 0 To Jumlah_Hidden - 1
                Ynet_k(pola) = Ynet_k(pola) + (Zj(j) * wjk(j + 1, 0))
            Next
            Yk(pola) = activasi(Ynet_k(pola))

            'Hitung faktor kesalahan (δ) di unit keluaran (Yk)
            delta_k(pola) = (List_Target(pola) - Yk(pola)) * Yk(pola) * (1 - Yk(pola))

            'Hitung suku perubahan bobot wjk
            For j = 1 To Jumlah_Hidden
                Update_Wjk(j, 0) = Learning_Rate * delta_k(pola) * Zj(j - 1)
            Next
            Update_Wjk(0, 0) = Learning_Rate * delta_k(pola)

            'Hitung faktor kesalahan (δ) dari unit tersembunyi
            For i = 0 To Jumlah_Hidden - 1
                deltaNet_j(i) = (delta_k(pola) * wjk(i + 1, 0))
                delta_j(i) = deltaNet_j(i) * Zj(i) * (1 - Zj(i))
            Next

            'Hitung suku perubahan bobot di unit tersembunyi
            For j = 0 To Jumlah_Hidden - 1
                For i = 1 To Jumlah_Variabel
                    Update_Vij(j, i) = Learning_Rate * delta_j(j) * xi(pola, i - 1)
                Next
                Update_Vij(j, 0) = Learning_Rate * delta_j(j)
            Next

            'Perubahan bobot unit keluaran jaringan
            For j = 0 To Jumlah_Hidden
                temp_wjk(j, 0) = wjkHidden(j, 0)
                wjk(j, 0) = wjk(j, 0) + Update_Wjk(j, 0) '+ (0.2 * (wjk(j, 0) - pwjk(j, 0)))
                pwjk(j, 0) = temp_wjk(j, 0)
            Next

            'Perubahan bobot unit tersembunyi
            For j = 0 To Jumlah_Hidden - 1
                For i = 0 To Jumlah_Variabel - 1
                    temp_vij(j, i) = vij(j, i)
                    vij(j, i) = vij(j, i) + Update_Vij(j, i) '+ (0.2 * (vij(j, i) - pvij(j, i)))
                    pvij(j, i) = temp_vij(j, i)
                Next
            Next

            'Hitung MSE
            mse = Math.Pow((List_Target(pola) - Yk(pola)), 2)
            Nilai_Error = mse + Nilai_Error

        Next
        mse = Math.Round((Nilai_Error / total_Input), 5)
        Return Training_Finish
    End Function
End Class
