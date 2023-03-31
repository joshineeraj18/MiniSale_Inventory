Public Class Splash

    Private incCTR = 0
    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer1.Start()
        Timer1.Interval = 10
    End Sub


    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        Label1.Text = Val(Label1.Text) + 1

        If (ProgressBar1.Value = 99) Then
            Timer1.Stop()
            Timer2.Enabled = True
            Timer2.Start()
            Timer2.Interval = 10
        End If
    End Sub

    Private Sub Timer2_Tick(sender2 As Object, e2 As EventArgs) Handles Timer2.Tick
        'Label1.Text = Val(Label1.Text) + 1
        incCTR = incCTR + 1
        'Label3.Text = incCTR
        If (incCTR = 50) Then
            ProgressBar1.Increment(1)
        End If

        If (incCTR = 100) Then
            incCTR = 0
            Timer2.Stop()
            Login.Show()
            Me.Hide()
        End If

    End Sub


End Class