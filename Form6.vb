Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class Form6
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\V'th sem project\studentmanegerv2\students007.mdf;Integrated Security=True")
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ActiveControl = TextBoxrfid
        Lbldate.Text = Date.Today
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GC.Collect()
        GC.WaitForPendingFinalizers()
        GC.Collect()
        Me.ActiveControl = TextBoxrfid
        Panel3.BackColor = Color.FromArgb(34, 33, 74)
        PictureBox2.Image = Nothing
        Timer1.Enabled = False
    End Sub
    Private Sub Buttoncancel_Click(sender As Object, e As EventArgs) Handles Buttoncancel.Click


        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub TextBoxrfid_Validating(sender As Object, e As CancelEventArgs) Handles TextBoxrfid.Validating


    End Sub
    Function pic()


        Try
            Dim picture1 As Image = Nothing
            con.Open()
            Dim cmd2 As New SqlCommand
            cmd2.Connection = con
            cmd2.CommandText = "select PHOTO from students where RFID=('" + TextBoxrfid.Text + "')"
            Dim pictureData As Byte() = DirectCast(cmd2.ExecuteScalar(), Byte())
            con.Close()
            Using stream As New IO.MemoryStream(pictureData)
                picture1 = Image.FromStream(stream)
            End Using
            PictureBox2.Image = picture1
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
            Me.ActiveControl = TextBoxrfid
            Panel3.BackColor = Color.Green
            con.Open()
            Dim cmd21 As New SqlCommand
            cmd21.Connection = con
            cmd21.CommandText = "select rfid,studentname,course,sem,regno from students where rfid=('" + TextBoxrfid.Text + "')"
            cmd21.CommandType = CommandType.Text
            Dim sdr As SqlDataReader = cmd21.ExecuteReader
            sdr.Read()
            Dim rf As String = sdr("rfid").ToString.Trim
            Dim name As String = sdr("studentname").ToString.Trim
            Dim course As String = sdr("course").ToString.Trim
            Dim sem As String = sdr("sem").ToString.Trim
            Dim regno As String = sdr("regno").ToString.Trim
            Dim cmd3 As New SqlCommand
            con.Close()
            Try
                Dim cnt As Integer = -1
                con.Open()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "SELECT Count([RFID]) FROM [attend] where date=('" + Lbldate.Text.Trim + "') and rfid=('" + TextBoxrfid.Text + "')"
                cmd.ExecuteNonQuery()
                cnt = Convert.ToInt32(cmd.ExecuteScalar())
                con.Close()
                If cnt = 0 Then
                    con.Open()
                    cmd3.Connection = con
                    cmd3.CommandText = "insert into attend(rfid,name,course,sem,regno,intime,date) values('" + rf + "','" + name + "','" + course + "','" + sem + "','" + regno + "','" + lbltime.Text + "','" + Lbldate.Text + "')"
                    cmd3.ExecuteNonQuery()
                    con.Close()
                    Threading.Thread.Sleep(10)
                    Timer1.Enabled = True
                Else
                    con.Open()
                    Dim cmd4 As New SqlCommand
                    cmd4.Connection = con
                    cmd4.CommandText = "update attend set outtime=('" + lbltime.Text.Trim + "') where date like '%" + Lbldate.Text.Trim + "%' and rfid=('" + TextBoxrfid.Text.Trim + "')"
                    cmd4.ExecuteNonQuery()
                    con.Close()
                    Threading.Thread.Sleep(10)
                    Timer1.Enabled = True
                End If

            Catch ex As Exception
                con.Close()
                Timer1.Enabled = True
            End Try
        Catch ex As Exception
            con.Close()
            Timer1.Enabled = True
        End Try







    End Function
    Private Sub TextBoxrfid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxrfid.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub TextBoxrfid_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxrfid.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox1.Focus()

        End If
    End Sub

    Private Sub TextBoxrfid_LostFocus(sender As Object, e As EventArgs) Handles TextBoxrfid.LostFocus
        pic()
        TextBoxrfid.Clear()

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        lbltime.Text = TimeOfDay
    End Sub

    Private Sub TextBoxrfid_TextChanged(sender As Object, e As EventArgs) Handles TextBoxrfid.TextChanged

    End Sub
End Class