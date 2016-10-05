Imports System.Data.Odbc
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc.OdbcDataReader

Module koneksi
    Public conn As OdbcConnection
    Public da As OdbcDataAdapter
    Public dr As OdbcDataReader
    Public ds As DataSet

    Public strcon As String

    Public Sub konek()
        strcon = "Driver={MySQL ODBC 5.3 ANSI Driver};database=skripsi;server = localhost; uid=root"
        conn = New OdbcConnection(strcon)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
End Module
