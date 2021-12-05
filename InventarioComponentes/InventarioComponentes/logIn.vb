Imports MySql.Data.MySqlClient
Public Class logIn
    Dim adCon As MySqlConnection
    Dim cmCon As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim dr As MySqlDataReader
    Private Sub Label1_MouseHover(sender As Object, e As EventArgs) Handles Label1.MouseHover
        Label1.ForeColor = Color.LightSeaGreen
    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = Color.Gray
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            MsgBox("Llena la información necesaria", MsgBoxStyle.OkOnly)
        Else

        End If

        Me.Hide()
        mainform.ShowDialog()
        Me.Show()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label5_MouseHover(sender As Object, e As EventArgs) Handles Label5.MouseHover
        Label5.ForeColor = Color.DeepSkyBlue
    End Sub

    Private Sub Label5_MouseLeave(sender As Object, e As EventArgs) Handles Label5.MouseLeave
        Label5.ForeColor = Color.LightBlue
    End Sub
End Class
