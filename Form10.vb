Imports System.Data.SqlClient
Imports System.Net.Mail
Public Class Form10
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\V'th sem project\studentmanegerv2\students007.mdf;Integrated Security=True")
    Dim post As String = Nothing
    Dim buttonhp As Panel
    Dim currbtn As Button
    Private curpnlname As String = Nothing
    Private curpnlcnt As Integer = 0
    Dim pic2 As PictureBox
    Dim p1 As Double
    Dim p2 As Double
    Dim p3 As Double
    Dim p4 As Double
    Dim total As Double
    Private WithEvents contactpanel2 As Panel
    Dim bal As Double
    Dim mlttb As TextBox
    Dim lbl As Label
    Dim dr As SqlDataReader
    Dim mailid As String = Nothing
    Dim regno As String = Nothing
    Dim total2 As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Close()
    End Sub
    Public Sub New()
        InitializeComponent()
        buttonhp = New Panel
        buttonhp.Size = New Size(155, 4)
        Panel1.Controls.Add(buttonhp)
    End Sub
    Private Sub activatebutton(senderbtn As Object, customclour As Color)
        If senderbtn IsNot Nothing Then
            desablebtn()
            currbtn = CType(senderbtn, Button)
            currbtn.BackColor = Color.FromArgb(37, 36, 81)
            currbtn.ForeColor = customclour
            buttonhp.BackColor = customclour
            currbtn.TextAlign = ContentAlignment.MiddleCenter
            currbtn.TextImageRelation = TextImageRelation.ImageBeforeText
            buttonhp.Location = New Point(currbtn.Location.X, currbtn.Location.Y)
            buttonhp.Visible = True
            buttonhp.BringToFront()
        End If
    End Sub
    Private Sub desablebtn()
        If currbtn IsNot Nothing Then
            currbtn.BackColor = Color.FromArgb(26, 25, 62)
            currbtn.ForeColor = Color.Gainsboro
            currbtn.TextAlign = ContentAlignment.MiddleCenter
            currbtn.TextImageRelation = TextImageRelation.ImageBeforeText
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Lbldate.Text = Date.Today
        Panel9.Hide()
        Panel3.Hide()
        Panel1.Enabled = False
        Me.ActiveControl = TextBoxrfid
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        lbltime.Text = TimeOfDay
    End Sub

    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
        lf()
        pic()

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            PictureBox1.Focus()
            TextBoxregno.SelectionLength = 0
        End If
    End Sub

    Function lf()
        Labelregno.Text = "Regno:"
        Labelname.Text = "Name:"
        Labelpay1.Text = "1st inst.:"
        Labelpay2.Text = "2nd inst.:"
        Labelpay3.Text = "3rd inst.:"
        Labelpay4.Text = "4th inst.:"
        Labelpn.Text = "Phone no:"
        Labelppn.Text = "parent phone:"
        Labelcour.Text = "course:"
        Labelsem.Text = "Sem:"
        Labelbal.Text = "Balance:"
        Try
            'Dim r As String
            con.Open()
            Dim cmd3 As New SqlCommand
            cmd3.Connection = con
            cmd3.CommandText = "select * from students where RFID=('" + TextBox1.Text + "') or REGNO=('" + TextBoxregno.Text.Trim + "')"
            cmd3.CommandType = CommandType.Text
            Dim sdr As SqlDataReader = cmd3.ExecuteReader
            sdr.Read()
            ' r = sdr("RFID").ToString
            Labelregno.Text = Labelregno.Text + " " + sdr("REGNO").ToString.Trim
            Labelname.Text = Labelname.Text + " " + sdr("STUDENTNAME").ToString.Trim
            Labelpay1.Text = Labelpay1.Text + " " + sdr("PAID1").ToString.Trim + " " + sdr("PAYDATE1").ToString.Trim
            Labelpay2.Text = Labelpay2.Text + " " + sdr("PAID2").ToString.Trim + " " + sdr("PAYDATE2").ToString.Trim
            Labelpay3.Text = Labelpay3.Text + " " + sdr("PAID3").ToString.Trim + " " + sdr("PAYDATE3").ToString.Trim
            Labelpay4.Text = Labelpay4.Text + " " + sdr("PAID4").ToString.Trim + " " + sdr("PAYDATE4").ToString.Trim
            Labelpn.Text = Labelpn.Text + " " + sdr("STDPHONE").ToString.Trim
            Labelppn.Text = Labelppn.Text + " " + sdr("PARENTPHN").ToString.Trim
            Labelcour.Text = Labelcour.Text + " " + sdr("COURSE").ToString.Trim
            Labelsem.Text = Labelsem.Text + " " + sdr("SEM").ToString.Trim
            mailid = sdr("EMAIL").ToString.Trim
            regno = sdr("REGNO").ToString.Trim
            p1 = Nothing
            p2 = Nothing
            p3 = Nothing
            p4 = Nothing
            total = Nothing
            bal = Nothing
            p1 = CDbl(Val(sdr("PAID1").ToString.Trim))
            p2 = CDbl(Val(sdr("PAID2").ToString.Trim))
            p3 = CDbl(Val(sdr("PAID3").ToString.Trim))
            p4 = CDbl(Val(sdr("PAID4").ToString.Trim))
            total = p1 + p2 + p3 + p4
            bal = 50000 - total
            Labelbal.Text = Labelbal.Text + " " + bal.ToString
            con.Close()
        Catch ex As Exception
            con.Close()
            Panel8.Show()
        End Try

    End Function
    Function pic()
        Try
            Dim picture1 As Image = Nothing
            con.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select PHOTO from students where RFID=('" + TextBox1.Text + "') or REGNO=('" + TextBoxregno.Text.Trim + "')"
            Dim pictureData As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
            con.Close()
            Using stream As New IO.MemoryStream(pictureData)
                picture1 = Image.FromStream(stream)
            End Using
            PictureBox2.Image = picture1
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage

        Catch ex As Exception
            con.Close()
        End Try
    End Function

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbltime.Text = TimeOfDay
    End Sub

    Private Sub TextBoxrfid_LostFocus(sender As Object, e As EventArgs) Handles TextBoxrfid.LostFocus
        Try
            con.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select post from staff where rfid=('" + TextBoxrfid.Text + "') "
            cmd.CommandType = CommandType.Text
            Dim sdr27 As SqlDataReader = cmd.ExecuteReader()
            sdr27.Read()
            post = sdr27("post").ToString.Trim

            If post = "Accountant" Then
                Panel1.Enabled = True
                Students.PerformClick()
                Students.PerformClick()
            End If

            con.Close()

        Catch ex As Exception
            con.Close()

        End Try
    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        lf()
        pic()

    End Sub



    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        While Panel5.Height > 20
            Threading.Thread.Sleep(0.5)
            Panel5.Height -= 1

            Button5.Visible = False
        End While
        TextBox3.Text = TextBox2.Text
    End Sub

    Private Sub cancelpay_Click(sender As Object, e As EventArgs) Handles cancelpay.Click
        While Panel5.Height <= 525
            Threading.Thread.Sleep(0.5)
            Panel5.Height += 1

            Button5.Visible = True
        End While
    End Sub

    Private Sub confirmpay_Click(sender As Object, e As EventArgs) Handles confirmpay.Click
        If bal > 0 Then
            If p1 = 0 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "update students set paid1=('" + TextBox3.Text.Trim + "'),paydate1=('" + Lbldate.Text + "') where rfid=('" + TextBox1.Text + "') or regno=('" + TextBoxregno.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    While Panel5.Height <= 525
                        Threading.Thread.Sleep(0.5)
                        Panel5.Height += 1

                        Button5.Visible = True
                    End While
                    TextBox2.Clear()
                    lf()
                    pic()
                    Cursor = Cursors.WaitCursor
                    Application.DoEvents()
                    Try

                        Cursor = Cursors.WaitCursor
                        Application.DoEvents()
                        Dim mail As New MailMessage
                        Dim smtpserver As New SmtpClient("smtp.gmail.com")
                        mail.From = New MailAddress("institoolbca5@gmail.com")
                        mail.To.Add(mailid)
                        mail.Subject = "Fees paid successfully"
                        mail.Body = "*************************THANK YOU*************************" & vbCrLf & Labelname.Text & vbCrLf & Labelcour.Text & vbCrLf & Labelsem.Text & vbCrLf & "Amount recived till date: " + total.ToString + " rupees " + Lbldate.Text & vbCrLf & Labelbal.Text
                        smtpserver.Port = 587
                        smtpserver.Credentials = New Net.NetworkCredential("institoolbca5@gmail.com", "Institoolbca5@")
                        smtpserver.EnableSsl = True
                        smtpserver.Send(mail)
                        MsgBox("Mail has been sent successfully!", MsgBoxStyle.Information, "Sent")

                        Cursor = Cursors.Default

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Information, "Please enter valid e-mail address")
                        con.Close()
                        Cursor = Cursors.Default
                    End Try
                    Try
                        con.Open()
                        Dim cmd2 As New SqlCommand
                        Dim s As String = "*************************THANK YOU*************************" & vbCrLf & Labelname.Text & vbCrLf & Labelcour.Text & vbCrLf & Labelsem.Text & vbCrLf & "Amount recived till date: " + total.ToString + " rupees " + Lbldate.Text & vbCrLf & Labelbal.Text
                        cmd2.Connection = con
                        cmd2.CommandText = "insert into notifacc([from],[to],[body],[date],[time]) values('Accountant','" + regno + "','" + s + "','" + Lbldate.Text + "','" + lbltime.Text + "')"
                        cmd2.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                    End Try

                Catch ex As Exception
                    con.Close()
                    lf()
                    pic()
                End Try

            ElseIf p2 = 0 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "update students set paid2=('" + TextBox3.Text.Trim + "'),paydate2=('" + Lbldate.Text + "') where rfid=('" + TextBox1.Text + "') or regno=('" + TextBoxregno.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    While Panel5.Height <= 525
                        Threading.Thread.Sleep(0.5)
                        Panel5.Height += 1

                        Button5.Visible = True
                    End While
                    TextBox2.Clear()
                    lf()
                    pic()
                    Cursor = Cursors.WaitCursor
                    Application.DoEvents()
                    Try

                        Cursor = Cursors.WaitCursor
                        Application.DoEvents()
                        Dim mail As New MailMessage
                        Dim smtpserver As New SmtpClient("smtp.gmail.com")
                        mail.From = New MailAddress("institoolbca5@gmail.com")
                        mail.To.Add(mailid)
                        mail.Subject = "Fees paid successfully"
                        mail.Body = "*************************THANK YOU*************************" & vbCrLf & Labelname.Text & vbCrLf & Labelcour.Text & vbCrLf & Labelsem.Text & vbCrLf & "Amount recived till date: " + total.ToString + " rupees " + Lbldate.Text & vbCrLf & Labelbal.Text
                        smtpserver.Port = 587
                        smtpserver.Credentials = New Net.NetworkCredential("institoolbca5@gmail.com", "Institoolbca5@")
                        smtpserver.EnableSsl = True
                        smtpserver.Send(mail)
                        MsgBox("Mail has been sent successfully!", MsgBoxStyle.Information, "Sent")

                        Cursor = Cursors.Default

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Information, "Please enter valid e-mail address")
                        con.Close()
                        Cursor = Cursors.Default
                    End Try
                    Try
                        con.Open()
                        Dim cmd2 As New SqlCommand
                        Dim s As String = "*************************THANK YOU*************************" & vbCrLf & Labelname.Text & vbCrLf & Labelcour.Text & vbCrLf & Labelsem.Text & vbCrLf & "Amount recived till date: " + total.ToString + " rupees " + Lbldate.Text & vbCrLf & Labelbal.Text
                        cmd2.Connection = con
                        cmd2.CommandText = "insert into notifacc([from],[to],[body],[date],[time]) values('Accountant','" + regno + "','" + s + "','" + Lbldate.Text + "','" + lbltime.Text + "')"
                        cmd2.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                    End Try

                Catch ex As Exception
                    con.Close()
                    lf()
                    pic()
                End Try

            ElseIf p3 = 0 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "update students set paid3=('" + TextBox3.Text.Trim + "'),paydate3=('" + Lbldate.Text + "') where rfid=('" + TextBox1.Text + "') or regno=('" + TextBoxregno.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    While Panel5.Height <= 525
                        Threading.Thread.Sleep(0.5)
                        Panel5.Height += 1

                        Button5.Visible = True
                    End While
                    TextBox2.Clear()
                    lf()
                    pic()
                    Cursor = Cursors.WaitCursor
                    Application.DoEvents()
                    Cursor = Cursors.Default
                    Try

                        Cursor = Cursors.WaitCursor
                        Application.DoEvents()
                        Dim mail As New MailMessage
                        Dim smtpserver As New SmtpClient("smtp.gmail.com")
                        mail.From = New MailAddress("institoolbca5@gmail.com")
                        mail.To.Add(mailid)
                        mail.Subject = "Fees paid successfully"
                        mail.Body = "*************************THANK YOU*************************" & vbCrLf & Labelname.Text & vbCrLf & Labelcour.Text & vbCrLf & Labelsem.Text & vbCrLf & "Amount recived till date: " + total.ToString + " rupees " + Lbldate.Text & vbCrLf & Labelbal.Text
                        smtpserver.Port = 587
                        smtpserver.Credentials = New Net.NetworkCredential("institoolbca5@gmail.com", "Institoolbca5@")
                        smtpserver.EnableSsl = True
                        smtpserver.Send(mail)
                        MsgBox("Mail has been sent successfully!", MsgBoxStyle.Information, "Sent")

                        Cursor = Cursors.Default

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Information, "Please enter valid e-mail address")
                        con.Close()
                        Cursor = Cursors.Default
                    End Try
                    Try
                        con.Open()
                        Dim cmd2 As New SqlCommand
                        Dim s As String = "*************************THANK YOU*************************" & vbCrLf & Labelname.Text & vbCrLf & Labelcour.Text & vbCrLf & Labelsem.Text & vbCrLf & "Amount recived till date: " + total.ToString + " rupees " + Lbldate.Text & vbCrLf & Labelbal.Text
                        cmd2.Connection = con
                        cmd2.CommandText = "insert into notifacc([from],[to],[body],[date],[time]) values('Accountant','" + regno + "','" + s + "','" + Lbldate.Text + "','" + lbltime.Text + "')"
                        cmd2.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                    End Try

                Catch ex As Exception
                    con.Close()
                    lf()
                    pic()
                End Try

            ElseIf p4 = 0 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "update students set paid4=('" + TextBox3.Text.Trim + "'),paydate4=('" + Lbldate.Text + "') where rfid=('" + TextBox1.Text + "') or regno=('" + TextBoxregno.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    While Panel5.Height <= 525
                        Threading.Thread.Sleep(0.5)
                        Panel5.Height += 1

                        Button5.Visible = True
                    End While
                    TextBox2.Clear()
                    lf()
                    pic()
                    Cursor = Cursors.WaitCursor
                    Application.DoEvents()
                    Try

                        Cursor = Cursors.WaitCursor
                        Application.DoEvents()
                        Dim mail As New MailMessage
                        Dim smtpserver As New SmtpClient("smtp.gmail.com")
                        mail.From = New MailAddress("institoolbca5@gmail.com")
                        mail.To.Add(mailid)
                        mail.Subject = "Fees paid successfully"
                        mail.Body = "*************************THANK YOU*************************" & vbCrLf & Labelname.Text & vbCrLf & Labelcour.Text & vbCrLf & Labelsem.Text & vbCrLf & "Amount recived till date: " + total.ToString + " rupees " + Lbldate.Text & vbCrLf & Labelbal.Text
                        smtpserver.Port = 587
                        smtpserver.Credentials = New Net.NetworkCredential("institoolbca5@gmail.com", "Institoolbca5@")
                        smtpserver.EnableSsl = True
                        smtpserver.Send(mail)
                        MsgBox("Mail has been sent successfully!", MsgBoxStyle.Information, "Sent")

                        Cursor = Cursors.Default

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Information, "Please enter valid e-mail address")
                        con.Close()
                        Cursor = Cursors.Default
                    End Try
                    Try
                        con.Open()
                        Dim cmd2 As New SqlCommand
                        Dim s As String = "*************************THANK YOU*************************" & vbCrLf & Labelname.Text & vbCrLf & Labelcour.Text & vbCrLf & Labelsem.Text & vbCrLf & "Amount recived till date: " + total.ToString + " rupees " + Lbldate.Text & vbCrLf & Labelbal.Text
                        cmd2.Connection = con
                        cmd2.CommandText = "insert into notifacc([from],[to],[body],[date],[time]) values('Accountant','" + regno + "','" + s + "','" + Lbldate.Text + "','" + lbltime.Text + "')"
                        cmd2.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                    End Try

                Catch ex As Exception
                    con.Close()
                    lf()
                    pic()
                End Try

            Else
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "update students set paid4=('" + TextBox3.Text.Trim + "'),paydate4=('" + Lbldate.Text + "') where rfid=('" + TextBox1.Text + "') or regno=('" + TextBoxregno.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    While Panel5.Height <= 525
                        Threading.Thread.Sleep(0.5)
                        Panel5.Height += 1

                        Button5.Visible = True
                    End While
                    TextBox2.Clear()
                    lf()
                    pic()
                    Cursor = Cursors.WaitCursor
                    Application.DoEvents()
                    Try

                        Cursor = Cursors.WaitCursor
                        Application.DoEvents()
                        Dim mail As New MailMessage
                        Dim smtpserver As New SmtpClient("smtp.gmail.com")
                        mail.From = New MailAddress("institoolbca5@gmail.com")
                        mail.To.Add(mailid)
                        mail.Subject = "Fees paid successfully"
                        mail.Body = "*************************THANK YOU*************************" & vbCrLf & Labelname.Text & vbCrLf & Labelcour.Text & vbCrLf & Labelsem.Text & vbCrLf & "Amount recived till date: " + total.ToString + " rupees " + Lbldate.Text & vbCrLf & Labelbal.Text
                        smtpserver.Port = 587
                        smtpserver.Credentials = New Net.NetworkCredential("institoolbca5@gmail.com", "Institoolbca5@")
                        smtpserver.EnableSsl = True
                        smtpserver.Send(mail)
                        MsgBox("Mail has been sent successfully!", MsgBoxStyle.Information, "Sent")

                        Cursor = Cursors.Default

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Information, "Please enter valid e-mail address")
                        con.Close()
                        Cursor = Cursors.Default
                    End Try
                    Try
                        con.Open()
                        Dim cmd2 As New SqlCommand
                        Dim s As String = "*************************THANK YOU*************************" & vbCrLf & Labelname.Text & vbCrLf & Labelcour.Text & vbCrLf & Labelsem.Text & vbCrLf & "Amount recived till date: " + total.ToString + " rupees " + Lbldate.Text & vbCrLf & Labelbal.Text
                        cmd2.Connection = con
                        cmd2.CommandText = "insert into notifacc([from],[to],[body],[date],[time]) values('Accountant','" + regno + "','" + s + "','" + Lbldate.Text + "','" + lbltime.Text + "')"
                        cmd2.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                    End Try

                Catch ex As Exception
                    con.Close()
                    lf()
                    pic()
                End Try

            End If
        Else
            MsgBox("Payment not accepted if the balance is '0'", MsgBoxStyle.Exclamation, "no due")
            While Panel5.Height <= 525
                Threading.Thread.Sleep(0.5)
                Panel5.Height += 1

                Button5.Visible = True
            End While
            TextBox2.Clear()
            lf()
            pic()
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBoxregno_TextChanged(sender As Object, e As EventArgs) Handles TextBoxregno.TextChanged

    End Sub

    Private Sub Students_Click(sender As Object, e As EventArgs) Handles Students.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        Panel3.Show()
        Panel9.Hide()
        FlowLayoutPanel1.Controls.Clear()
        GC.Collect()
    End Sub

    Private Sub TextBox2_GotFocus(sender As Object, e As EventArgs) Handles TextBox2.GotFocus
        Panel8.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        createpanelfs()
        Panel3.Show()
        Panel9.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        activatebutton(sender, customclour:=Color.Gainsboro)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        activatebutton(sender, customclour:=Color.Gainsboro)
    End Sub

    Private Sub Buttoncancel_Click(sender As Object, e As EventArgs) Handles Buttoncancel.Click
        Labelregno.Text = "Regno:"
        Labelname.Text = "Name:"
        Labelpay1.Text = "1st inst.:"
        Labelpay2.Text = "2nd inst.:"
        Labelpay3.Text = "3rd inst.:"
        Labelpay4.Text = "4th inst.:"
        Labelpn.Text = "Phone no:"
        Labelppn.Text = "parent phone:"
        Labelcour.Text = "course:"
        Labelsem.Text = "Sem:"
        Labelbal.Text = "Balance:"
        Panel8.Show()
        While Panel5.Height <= 525
            Threading.Thread.Sleep(0.5)
            Panel5.Height += 1

            Button5.Visible = True
        End While
        TextBox1.Clear()
        TextBoxregno.Clear()
        TextBox2.Clear()
        PictureBox2.Image = Nothing
    End Sub



    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub createpanelfs()
        FlowLayoutPanel1.Controls.Clear()
        GC.Collect()
        ComboBox1.SelectedItem = Nothing
        ComboBox4.SelectedItem = Nothing
        Try

            con.Open()
            Dim cmd1 As New SqlCommand
            Dim dr2 As SqlDataReader
            cmd1.Connection = con
            cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students order by sem desc"
            cmd1.CommandType = CommandType.Text
            dr2 = cmd1.ExecuteReader
            While dr2.Read

                Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                Dim array(CInt(len)) As Byte
                dr2.GetBytes(0, 0, array, 0, CInt(len))
                Dim ms As New IO.MemoryStream(array)
                Dim bitmap As New Bitmap(ms)
                pic2 = New PictureBox
                pic2.Size = New Size(130, 150)
                pic2.Image = bitmap
                pic2.BorderStyle = BorderStyle.FixedSingle
                pic2.SizeMode = PictureBoxSizeMode.StretchImage

                mlttb = New TextBox
                With mlttb
                    .Multiline = True
                    .BorderStyle = BorderStyle.None
                    .ReadOnly = True
                    .ScrollBars = ScrollBars.Both
                    .Size = New Size(665, 145)
                    .Location = New Point(135, 2)
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .ForeColor = Color.Gainsboro
                    .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                    p1 = Nothing
                    p2 = Nothing
                    p3 = Nothing
                    p4 = Nothing
                    total = Nothing
                    bal = Nothing
                    p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                    p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                    p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                    p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                    total = p1 + p2 + p3 + p4
                    bal = 50000 - total
                    .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                End With

                contactpanel2 = New Panel
                With contactpanel2
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .Size = New Size(800, 150)
                    .Name = "contactpanel" + (curpnlcnt + 1).ToString
                    .Controls.Add(pic2)
                    .Controls.Add(mlttb)
                End With
                curpnlname = contactpanel2.Name
                curpnlcnt += 1
                FlowLayoutPanel1.Controls.Add(contactpanel2)
            End While
            con.Close()
        Catch ex As Exception
            con.Close()
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox4.SelectedItem <> "" Then
            FlowLayoutPanel1.Controls.Clear()
            GC.Collect()

            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where course=('" + ComboBox1.SelectedItem + "') and sem=('" + ComboBox4.SelectedItem + "')"
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        Else
            FlowLayoutPanel1.Controls.Clear()
            GC.Collect()

            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where course=('" + ComboBox1.SelectedItem + "') order by sem desc"
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        End If

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        If ComboBox1.SelectedItem <> "" Then
            FlowLayoutPanel1.Controls.Clear()
            GC.Collect()

            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where sem=('" + ComboBox4.SelectedItem + "') and course=('" + ComboBox1.SelectedItem + "')"
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        Else
            FlowLayoutPanel1.Controls.Clear()
            GC.Collect()

            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where sem=('" + ComboBox4.SelectedItem + "')"
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        End If

    End Sub

    Private Sub TextBoxrfid_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxrfid.KeyDown
        If e.KeyCode = Keys.Enter Then
            PictureBox1.Focus()
            TextBoxregno.SelectionLength = 0
        End If
    End Sub



    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        FlowLayoutPanel1.Controls.Clear()
        GC.Collect()
        If ComboBox1.SelectedItem <> "" Then
            FlowLayoutPanel1.Controls.Clear()
            GC.Collect()

            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where course=('" + ComboBox1.SelectedItem + "') and paid1 is null "
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        ElseIf ComboBox4.SelectedItem <> "" Then
            FlowLayoutPanel1.Controls.Clear()
            GC.Collect()

            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where paid1 is null and sem=('" + ComboBox4.SelectedItem + "') "
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        ElseIf ComboBox1.SelectedItem <> "" And ComboBox4.SelectedItem <> "" Then
            FlowLayoutPanel1.Controls.Clear()
            GC.Collect()

            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where paid1 is null and course=('" + ComboBox1.SelectedItem + "') and sem=('" + ComboBox4.SelectedItem + "') "
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        Else
            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where paid1 is null "
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        FlowLayoutPanel1.Controls.Clear()
        GC.Collect()
        If ComboBox1.SelectedItem <> "" Then
            FlowLayoutPanel1.Controls.Clear()
            GC.Collect()

            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where course=('" + ComboBox1.SelectedItem + "') and paid2 is null "
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        ElseIf ComboBox4.SelectedItem <> "" Then
            FlowLayoutPanel1.Controls.Clear()
            GC.Collect()

            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where paid2 is null and sem=('" + ComboBox4.SelectedItem + "') "
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        ElseIf ComboBox1.SelectedItem <> "" And ComboBox4.SelectedItem <> "" Then
            FlowLayoutPanel1.Controls.Clear()
            GC.Collect()

            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where paid2 is null and course=('" + ComboBox1.SelectedItem + "') and sem=('" + ComboBox4.SelectedItem + "') "
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        Else
            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where paid2 is null "
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        FlowLayoutPanel1.Controls.Clear()
        GC.Collect()
        If ComboBox1.SelectedItem <> "" Then
            FlowLayoutPanel1.Controls.Clear()
            GC.Collect()

            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where course=('" + ComboBox1.SelectedItem + "') and paid3 is null "
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        ElseIf ComboBox4.SelectedItem <> "" Then
            FlowLayoutPanel1.Controls.Clear()
            GC.Collect()

            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where paid3 is null and sem=('" + ComboBox4.SelectedItem + "') "
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        ElseIf ComboBox1.SelectedItem <> "" And ComboBox4.SelectedItem <> "" Then
            FlowLayoutPanel1.Controls.Clear()
            GC.Collect()

            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where paid3 is null and course=('" + ComboBox1.SelectedItem + "') and sem=('" + ComboBox4.SelectedItem + "') "
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        Else
            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where paid3 is null "
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        FlowLayoutPanel1.Controls.Clear()
        GC.Collect()
        If ComboBox1.SelectedItem <> "" Then
            FlowLayoutPanel1.Controls.Clear()
            GC.Collect()

            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where course=('" + ComboBox1.SelectedItem + "') and paid4 is null "
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        ElseIf ComboBox4.SelectedItem <> "" Then
            FlowLayoutPanel1.Controls.Clear()
            GC.Collect()

            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where paid4 is null and sem=('" + ComboBox4.SelectedItem + "') "
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        ElseIf ComboBox1.SelectedItem <> "" And ComboBox4.SelectedItem <> "" Then
            FlowLayoutPanel1.Controls.Clear()
            GC.Collect()

            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where paid4 is null and course=('" + ComboBox1.SelectedItem + "') and sem=('" + ComboBox4.SelectedItem + "') "
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        Else
            Try

                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno,paid1,paid2,paid3,paid4 from students where paid4 is null "
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic2 = New PictureBox
                    pic2.Size = New Size(130, 150)
                    pic2.Image = bitmap
                    pic2.BorderStyle = BorderStyle.FixedSingle
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage

                    mlttb = New TextBox
                    With mlttb
                        .Multiline = True
                        .BorderStyle = BorderStyle.None
                        .ReadOnly = True
                        .ScrollBars = ScrollBars.Both
                        .Size = New Size(665, 145)
                        .Location = New Point(135, 2)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                        p1 = Nothing
                        p2 = Nothing
                        p3 = Nothing
                        p4 = Nothing
                        total = Nothing
                        bal = Nothing
                        p1 = CDbl(Val(dr2.Item("PAID1").ToString.Trim))
                        p2 = CDbl(Val(dr2.Item("PAID2").ToString.Trim))
                        p3 = CDbl(Val(dr2.Item("PAID3").ToString.Trim))
                        p4 = CDbl(Val(dr2.Item("PAID4").ToString.Trim))
                        total = p1 + p2 + p3 + p4
                        bal = 50000 - total
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "BALANCE: " + bal.ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic2)
                        .Controls.Add(mlttb)
                    End With
                    curpnlname = contactpanel2.Name
                    curpnlcnt += 1
                    FlowLayoutPanel1.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        count()
        ProgressBar1.Maximum = total2
        Try
            Cursor = Cursors.WaitCursor
            con.Open()
            Dim cmd1 As New SqlCommand
            Dim dr2 As SqlDataReader
            cmd1.Connection = con
            cmd1.CommandText = "select EMAIL from students"
            cmd1.CommandType = CommandType.Text
            dr2 = cmd1.ExecuteReader
            While dr2.Read
                ProgressBar1.Value += 1
                Dim s As String = Nothing
                s = dr2.Item("email").ToString.Trim
                Try
                    Dim mail As New MailMessage
                    Dim smtpserver As New SmtpClient("smtp.gmail.com")
                    mail.From = New MailAddress("institoolbca5@gmail.com")
                    mail.To.Add(s)
                    mail.Subject = "Fees remainder"
                    mail.Body = "This is to infrom that those who have not paid the balance fees amount kindly do the needfull" & vbCrLf & "those who have alredy paid please ignore this mail" & vbCrLf & "******************** THANK YOU ********************"
                    smtpserver.Port = 587
                    smtpserver.Credentials = New Net.NetworkCredential("institoolbca5@gmail.com", "Institoolbca5@")
                    smtpserver.EnableSsl = True
                    smtpserver.Send(mail)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Information, "Please enter valid e-mail address")
                    con.Close()
                    Cursor = Cursors.Default
                End Try
            End While
            Cursor = Cursors.Default
            con.Close()
            MsgBox("Email remainder has been sent to all", MsgBoxStyle.Information, "sent!")
        Catch ex As Exception
            con.Close()
        End Try
    End Sub
    Function count()

        Try
            Dim cnt As Integer = -1
            Dim cnt1 As Integer = -1
            Dim cnt2 As Integer = -1
            con.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "SELECT Count([RFID]) FROM [students] where Course like '%BCA%'"
            cmd.ExecuteNonQuery()
            cnt = Convert.ToInt32(cmd.ExecuteScalar())


            Dim cmd1 As New SqlCommand
            cmd1.Connection = con
            cmd1.CommandText = "SELECT Count([RFID]) FROM [students] where Course like '%BBA%'"
            cmd1.ExecuteNonQuery()
            cnt1 = Convert.ToInt32(cmd1.ExecuteScalar())


            Dim cmd2 As New SqlCommand
            cmd2.Connection = con
            cmd2.CommandText = "SELECT Count([RFID]) FROM [students] where Course like '%BCOM%'"
            cmd2.ExecuteNonQuery()
            cnt2 = Convert.ToInt32(cmd2.ExecuteScalar())

            total2 = cnt + cnt1 + cnt2
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try



    End Function

    Private Sub TextBoxrfid_TextChanged(sender As Object, e As EventArgs) Handles TextBoxrfid.TextChanged
        Labelregno.Text = "Regno:"
        Labelname.Text = "Name:"
        Labelpay1.Text = "1st inst.:"
        Labelpay2.Text = "2nd inst.:"
        Labelpay3.Text = "3rd inst.:"
        Labelpay4.Text = "4th inst.:"
        Labelpn.Text = "Phone no:"
        Labelppn.Text = "parent phone:"
        Labelcour.Text = "course:"
        Labelsem.Text = "Sem:"
        Labelbal.Text = "Balance:"
        Panel8.Show()
        While Panel5.Height <= 525
            Threading.Thread.Sleep(0.5)
            Panel5.Height += 1

            Button5.Visible = True
        End While
        TextBox1.Clear()
        TextBoxregno.Clear()
        TextBox2.Clear()
        PictureBox2.Image = Nothing
        Lbldate.Text = Date.Today
        Panel9.Hide()
        Panel3.Hide()
        Panel1.Enabled = False
        buttonhp.Visible = False
        desablebtn()
    End Sub
End Class