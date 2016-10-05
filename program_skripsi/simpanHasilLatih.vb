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

Public Class simpanHasilLatih
    Public learning As Double
    Public epoh As Integer
    Public total_epoch_digunakan As Integer
    Public error_latih As Double
    Public hidden As Integer
    Public mse_latih As Double
    Public mse_uji As Double
    Public vij_latih(,) As Double
    Public wjk_latih(,) As Double
End Class
