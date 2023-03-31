Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class AddStock


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If (IsFormValid()) Then
            qr = "Insert into tblProductInfo values('" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & My.Forms.Dashboard.LoggedUser.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "')"
            Dim logincorrect As Boolean = Convert.ToBoolean(Insertdata(qr))
            If (logincorrect) Then
                BindGD()
                MsgBox("Stock Added Successfully", MsgBoxStyle.Information)
                clr()
            Else
                MsgBox("Record Not Saved", MsgBoxStyle.Critical)
            End If
        End If
    End Sub


    Private Function IsFormValid() As Boolean
        If (TextBox2.Text.Trim() = String.Empty) Then
            MessageBox.Show("Name is Required!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            Return False
        End If
        If (TextBox3.Text.Trim() = String.Empty) Then
            MsgBox("Description is Required", MsgBoxStyle.Critical)
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            Return False
        End If

        If (TextBox4.Text.Trim = String.Empty) Then
            MsgBox("Price Required", MsgBoxStyle.Critical)
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            Return False
        End If

        If (TextBox5.Text.Trim = String.Empty) Then
            MsgBox("Stock Required", MsgBoxStyle.Critical)
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            Return False
        End If

        Return True
    End Function


    Public Sub BindGD()
        qr = "Select * from tblProductInfo"
        ds = SearchData(qr)
        If (ds.Tables(0).Rows.Count > 0) Then
            DataGridView1.DataSource = ds.Tables(0)
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub AddStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BindGD()
        btnAdd.Enabled = False
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Public Sub clr()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        i = DataGridView1.CurrentRow.Index
        If (i >= 0) Then
            Me.TextBox1.Text = DataGridView1.Item(0, i).Value
            Me.TextBox2.Text = DataGridView1.Item(1, i).Value
            Me.TextBox3.Text = DataGridView1.Item(2, i).Value
            Me.TextBox4.Text = DataGridView1.Item(3, i).Value
            Me.TextBox5.Text = DataGridView1.Item(4, i).Value

            btnAdd.Enabled = False
            btnUpdate.Enabled = True
            btnDelete.Enabled = True

        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If (IsFormValid()) Then
            qr = "Update tblProductInfo set ProductName='" & TextBox2.Text & "'  ,ProductDesc='" & TextBox3.Text & "' ,ProductPrice='" & TextBox4.Text & "' ,ProStock='" & TextBox5.Text & "' where ProId='" & Convert.ToInt32(TextBox1.Text) & "' "
            Dim isUpdatetrue As Boolean = Convert.ToBoolean(Insertdata(qr))
            If (isUpdatetrue) Then
                BindGD()
                MsgBox("Stock Updated Successfully", MsgBoxStyle.Information)
                clr()
            Else
                MsgBox("Record Not Updated", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim result As Integer = MsgBox("Do You Really Want to Delete the Record...?", MsgBoxStyle.YesNo)
        If (result = DialogResult.No) Then
        ElseIf (result = DialogResult.Yes) Then
            If (IsFormValid2()) Then
                qr = "Delete from tblProductInfo  where ProId='" & Convert.ToInt32(TextBox1.Text) & "' "
                Dim wantToDelete As Boolean = Convert.ToBoolean(Insertdata(qr))
                If (wantToDelete) Then
                    BindGD()
                    MsgBox("Stock Deleted Successfully", MsgBoxStyle.Information)
                    clr()
                Else
                    MsgBox("Record Not Deleted", MsgBoxStyle.Critical)
                End If
            End If
        End If

    End Sub

    Private Function IsFormValid2() As Boolean
        If (TextBox1.Text.Trim() = String.Empty) Then
            MessageBox.Show("Product ID is Required!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clr()
        TextBox2.Focus()
        btnAdd.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        qr = "Select * from tblProductInfo where ProId='" & Convert.ToInt32(TextBox6.Text) & "'"
        ds = SearchData(qr)
        If (ds.Tables(0).Rows.Count > 0) Then
            DataGridView1.DataSource = ds.Tables(0)
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Critical)
        End If
    End Sub
End Class