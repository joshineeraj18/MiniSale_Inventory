Public Class Login
    Public loginUser As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If (IsFormValid()) Then
            qr = "Select * FROM UserLogin where UserName='" & TextBox1.Text & "' and Password='" & TextBox2.Text & "' and UserType='" & ComboBox1.Text & "'"
            ds = SearchData(qr)
            If (ds.Tables(0).Rows.Count > 0) Then
                loginUser = TextBox1.Text
                Dashboard.Show()
                Me.Close()
            Else
                MsgBox("Username and Password is not Correct", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Function IsFormValid() As Boolean
        If (String.IsNullOrWhiteSpace(TextBox1.Text)) Then
            'MsgBox("Username is Required", MsgBoxStyle.Critical)
            MessageBox.Show("Username is Required!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Clear()
            TextBox2.Clear()
            Return False
        End If
        If (TextBox2.Text.Trim() = String.Empty) Then
            MsgBox("Password is Required", MsgBoxStyle.Critical)
            TextBox1.Clear()
            TextBox2.Clear()
            Return False
        End If

        If (ComboBox1.SelectedIndex = -1) Then
            MsgBox("User Type Required", MsgBoxStyle.Critical)
            TextBox1.Clear()
            TextBox2.Clear()
            Return False
        End If

        Return True
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        btnLogin.Enabled = True
    End Sub
End Class
