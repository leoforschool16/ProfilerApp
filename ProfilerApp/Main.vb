Imports System.Security.Cryptography.X509Certificates
Imports MySql.Data.MySqlClient

Public Class Main
    Public Sub searchrec(ByRef SQLSTATEMENT As String)
        SQLCONN.ConnectionString = con
        If SQLCONN.State = ConnectionState.Closed Then

            SQLCONN.Open()

            Dim dt As New DataTable
            Dim MyCommand As New MySqlCommand(SQLSTATEMENT, SQLCONN)
            Dim myDataAdapter As New MySqlDataAdapter(SQLSTATEMENT, SQLCONN)
            myDataAdapter.Fill(dt)
            Dim sqlrdr As MySqlDataReader
            sqlrdr = MyCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            While sqlrdr.Read()
                Label7.Text = sqlrdr("id")
                Label8.Text = sqlrdr("Fullname")
                TextBox2.Text = sqlrdr("Fullname")
                TextBox3.Text = sqlrdr("Email")
                TextBox4.Text = sqlrdr("Username")
                TextBox5.Text = sqlrdr("Password")
            End While
        End If
        SQLCONN.Close()
        SQLCONN.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SQLSTATEMENT As String = $"UPDATE user SET `Fullname` ='" & TextBox2.Text & "',`Email` ='" & TextBox3.Text & "', `Username`='" & TextBox4.Text & "',`Password`='" & TextBox5.Text & "' WHERE id = '" & Label7.Text & "'"
        save(SQLSTATEMENT)
        MsgBox("Data updated successfully", vbInformation)
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form1.Show()
        Me.Close()
    End Sub
End Class