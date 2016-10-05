Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions

Module BackPro
    Dim Jumlah_Hidden As Integer
    Dim Jumlah_Variabel As Integer = 4
    Dim Learning_Rate As Double
    Dim Error_Max As Double
    Dim epoch As Integer
    Dim Training_Finish As Boolean
    Dim Nilai_Error As Double
    Dim Tot_Epoch As Integer
    Dim nilai_Baru As Double = 0
    Dim total_Input As Integer = 60

    Dim vij(,) As Double
    Dim Update_Vij(,) As Double
    Dim wjk(,) As Double
    Dim Update_Wjk(,) As Double
    Dim xi(,) As Double
    Dim List_Target() As Double
    Dim Znet_j() As Double
    Dim Zj() As Double
    Dim Ynet_k() As Double
    Dim Yk() As Double
    Dim deltaNet_j() As Double
    Dim delta_j() As Double
    Dim delta_k() As Double
    Dim bobot_random() As Double
    Dim yOutput() As Double


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
    Function RandomWeight() As Double
        'bilangan random tanpa angka 0,0
        Dim tmp As Double = 0.0
        Randomize()
        While (tmp = 0)
            tmp = CDbl((1 * Rnd()) + 1)
        End While
        Return tmp
    End Function

    'Fungsi aktivasi sigmoid biner
    Function activasi(ByVal nilai As Double) As Double
        If (nilai >= 1) Then
            nilai_Baru = 0.9999999
        ElseIf (nilai <= 0) Then
            nilai_Baru = 0.0
        ElseIf (nilai > 0 And nilai < 1) Then
            nilai_Baru = (1 / (1 + Math.Exp(-nilai)))
        End If

        Return nilai_Baru
    End Function

    Sub InitialData()
        vij = New Double(total_Input + 1, Jumlah_Hidden + 1) {}
        wjk = New Double(Jumlah_Hidden + 1, 0 + 1) {}
        Update_Vij = New Double(total_Input + 1, Jumlah_Hidden + 1) {}
        Update_Wjk = New Double(Jumlah_Hidden + 1, 0 + 1) {}
        Znet_j = New Double(Jumlah_Hidden + 1) {}
        Zj = New Double(Jumlah_Hidden + 1) {}
        Ynet_k = New Double(0 + 1) {}
        Yk = New Double(0 + 1) {}
        delta_k = New Double(0 + 1) {}
        deltaNet_j = New Double(Jumlah_Hidden + 1) {}
        delta_j = New Double(Jumlah_Hidden + 1) {}
        yOutput = New Double() {}

        'Mencari max dan min
        Dim max() As Double
        Dim min() As Double
        Dim j As Integer
        Dim i As Integer
        Dim jumlah_data1 As Integer = xi.GetUpperBound(0)
        Dim jumlah_data2 As Integer = xi.GetUpperBound(1)
        ReDim max(jumlah_data2)
        ReDim min(jumlah_data2)

        'Mencari max dan min nilai untuk inputan (x1, x2, x3, x4)
        For j = 0 To xi.GetUpperBound(1)
            min(j) = xi(0, j)
            For i = 0 To xi.GetUpperBound(0)
                If xi(i, j) > max(j) Then
                    max(j) = xi(i, j)
                End If
                If xi(i, j) < min(j) Then
                    min(j) = xi(i, j)
                End If
            Next
        Next
        'Normalisasi data inputan (x1, x2, x3, x4) agar nilainya 
        For i = 0 To xi.GetUpperBound(0)
            For j = 0 To xi.GetUpperBound(1)
                If (xi(i, j) = 0 Or xi(i, j) = 1 Or xi(i, j) = 0.5) Then
                    xi(i, j) = xi(i, j)
                Else
                    xi(i, j) = ((0.8 * (xi(i, j) - min(j))) / (max(j) - min(j)) + 0.1)
                End If
            Next
        Next

        'Mencari max dan min nilai untuk target
        Dim nilai_besar As Double = 0.0
        Dim nilai_kecil As Double = 999.9
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
                List_Target(i) = List_Target(i)
            Else
                List_Target(i) = ((0.8 * (List_Target(i) - nilai_kecil)) / (nilai_besar - nilai_kecil) + 0.1)
            End If
        Next

        Training_Finish = False
    End Sub

    Function run() As Boolean
        Dim iloop As Integer
        Dim j As Integer
        Dim i As Integer
        Dim k As Integer
        Dim pola As Integer
        Dim mse As Double
        Dim yOut() As Double

        If (Not Training_Finish And iloop > Tot_Epoch) Then
            Training_Finish = True
        End If

        If (Not Training_Finish) Then
            System.Diagnostics.Debug.WriteLine("Epoch ke " + (iloop))
            epoch = iloop

            For pola = 0 To total_Input
                'Hitung Keluaran Unit tersembunyi
                For i = 1 To i <= Jumlah_Hidden
                    Znet_j(i) = vij(i, 0)
                    For j = 1 To j <= Jumlah_Variabel
                        Znet_j(i) = Znet_j(i) + (xi(pola, j) * (vij(i, j)))
                    Next
                    Zj(i) = activasi(Znet_j(i))
                Next

                'Hitung Unit keluaran jaringan (Yk)
                Ynet_k(pola) = wjk(1, 0)
                For k = 1 To Jumlah_Hidden
                    Ynet_k(pola) = Ynet_k(pola) + (Zj(k) * wjk(1, k))
                Next
                Yk(pola) = activasi(Ynet_k(pola))

                'Hitung MSE
                mse = 0
                mse = Math.Pow((List_Target(pola) - Yk(pola)), 2)
                mse = mse / 4

                If (mse > Error_Max) Then
                    'Hitung faktor kesalahan (δ) di unit keluaran (Yk)
                    delta_k(pola) = Nilai_Error + ((List_Target(pola) - Yk(pola)) * Yk(pola) * (1 - Yk(pola)))

                    'Hitung suku perubahan bobot wjk
                    For j = 1 To Jumlah_Hidden
                        Update_Wjk(j, 1) = Learning_Rate * delta_k(pola) * Zj(j)
                    Next
                    Update_Wjk(0, 1) = Learning_Rate * delta_k(pola)

                    'Hitung faktor kesalahan (δ) dari unit tersembunyi
                    For i = 1 To Jumlah_Hidden
                        deltaNet_j(i) = (delta_k(pola) * wjk(1, i))
                        delta_j(i) = deltaNet_j(i) * Zj(i) * (1 - Zj(i))
                    Next

                    'Hitung suku perubahan bobot di unit tersembunyi
                    For j = 1 To Jumlah_Hidden
                        For i = 1 To Jumlah_Variabel
                            Update_Vij(i, j) = Learning_Rate * delta_j(j) * xi(pola, i)
                        Next
                        Update_Vij(0, j) = Learning_Rate * delta_j(j)
                    Next

                    'Perubahan bobot unit keluaran jaringan
                    For j = 0 To Jumlah_Hidden
                        wjk(j, 1) = wjk(j, 1) + Update_Wjk(j, 1)
                    Next

                    'Perubahan bobot unit tersembunyi
                    For i = 0 To total_Input
                        For j = 1 To Jumlah_Hidden
                            vij(i, j) = vij(i, j) + Update_Vij(i, j)
                        Next
                    Next
                Else
                    Training_Finish = True
                End If
                Nilai_Error = mse

                yOut = New Double(1) {}
                yOut(0) = mse
                yOut(1) = Yk(1)
                yOutput(0) = yOut(0)
                yOutput(1) = yOut(1)
            Next
        End If
        Return Training_Finish
    End Function
End Module
