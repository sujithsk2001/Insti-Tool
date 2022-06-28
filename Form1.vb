Public Class Form1

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ProgressBar1.Value = ProgressBar1.Value + 1

        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = False


            Form2.Show()

        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class
