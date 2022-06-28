Imports System.Data.SqlClient
Imports System.Net.Mail
Public Class Form4

    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\V'th sem project\studentmanegerv2\students007.mdf;Integrated Security=True")

    Function clear()
        TextBoxrfid.Clear()
        TextBoxregno.Clear()
        studentname.Clear()
        fathersname.Clear()
        mothersname.Clear()
        TextBoxaddr.Clear()
        pincode.Clear()
        aadhaar.Clear()
        addmissionno.Clear()
        studentphn.Clear()
        parentphn.Clear()
        TextBoxcourse.Clear()
        TextBoxgender.Clear()
        TextBoxsem.Clear()
        course.Text = ""
        sem.Text = ""
        gender.Text = ""
        dateofbirth.Clear()
        dateofjoining.Clear()
        email.Clear()
        Me.ActiveControl = TextBoxrfid
        guardian.Clear()
        PictureBox2.Image = Nothing
        PictureBox2.BackgroundImage = studentmanegerv2.My.Resources.Resources.twotone_add_photo_alternate_white_24dp
    End Function

    Function collection()

        Try
            con.Open()
            Dim cmd45 As New SqlCommand
            cmd45.Connection = con
            cmd45.CommandText = "Select RFID from students "
            cmd45.CommandType = CommandType.Text
            Dim sdr As SqlDataReader = cmd45.ExecuteReader()
            sdr.Read()
            Dim list As New AutoCompleteStringCollection
            While sdr.Read()
                list.Add(sdr("RFID").ToString())
            End While
            TextBoxrfid.AutoCompleteCustomSource = list
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try

    End Function
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

            bcacount.Text = "BCA: " & cnt.ToString
            Dim cmd1 As New SqlCommand
            cmd1.Connection = con
            cmd1.CommandText = "SELECT Count([RFID]) FROM [students] where Course like '%BBA%'"
            cmd1.ExecuteNonQuery()
            cnt1 = Convert.ToInt32(cmd1.ExecuteScalar())

            bbacount.Text = "BBA: " & cnt1.ToString
            Dim cmd2 As New SqlCommand
            cmd2.Connection = con
            cmd2.CommandText = "SELECT Count([RFID]) FROM [students] where Course like '%BCOM%'"
            cmd2.ExecuteNonQuery()
            cnt2 = Convert.ToInt32(cmd2.ExecuteScalar())
            bcomcount.Text = "BCOM: " & cnt2.ToString
            stdtotal.Text = "Total : " & (cnt + cnt1 + cnt2).ToString
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try



    End Function

    Function age()
        Dim a As Integer = DateTimePicker1.Value.Year
        Dim b As Integer = DateTimePicker2.Value.Year
        Dim c As Integer = b - a
        If c >= 17 And c < 35 Then
            Label19.Text = ""
            Return 0
        Else

            Return 1
        End If
    End Function

    Function blank()
        If TextBoxregno.Text.Trim <> "" And studentname.Text.Trim <> "" And TextBoxrfid.Text.Trim <> "" And TextBoxaddr.Text.Trim <> "" And pincode.Text.Trim <> "" And aadhaar.Text.Trim <> "" And studentphn.Text.Trim <> "" And parentphn.Text.Trim <> "" And TextBoxcourse.Text.Trim <> "" And TextBoxsem.Text.Trim <> "" And TextBoxgender.Text.Trim <> "" And dateofbirth.Text.Trim <> "" And dateofjoining.Text.Trim <> "" And email.Text.Trim <> "" And addmissionno.Text.Trim <> "" And nullimg() = 0 Then
            Label19.Text = ""
            Return 0
        Else

            Return 1
        End If
    End Function

    Function num()
        If parentphn.Text <> studentphn.Text Then
            Label19.Text = ""
            Return 0
        Else

            Return 1
        End If
    End Function

    Function prt()
        If fathersname.Text.Trim <> "" Or mothersname.Text.Trim <> "" Or guardian.Text.Trim <> "" Then
            Label19.Text = ""
            Return 0
        Else

            Return 1
        End If
    End Function

    Function mailtest()
        If email.Text.Trim <> "" Then
            Try
                Dim testAddress = New MailAddress(email.Text)
            Catch ex As FormatException
                Return 1

            End Try
        End If

    End Function
    Function phn()
        If parentphn.TextLength < 10 Then
            Return 1
        Else
            Return 0

        End If

    End Function
    Function phn1()
        If studentphn.TextLength < 10 Then
            Return 1
        Else
            Return 0

        End If

    End Function
    Function phn2()
        If aadhaar.TextLength < 12 Then
            Return 1
        ElseIf aadhaar.Text.StartsWith("0") Or aadhaar.Text.StartsWith("1") Then
            Return 1
        Else
            Return 0

        End If

    End Function
    Function phn3()
        If pincode.TextLength < 6 Then
            Return 1
        Else
            Return 0

        End If

    End Function
    Function nullimg()
        If PictureBox2.Image Is Nothing Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
        Me.ActiveControl = TextBoxrfid
        collection()
        DateTimePicker1.MaxDate = Date.Now
        DateTimePicker2.MaxDate = Date.Now
        Label19.Text = ""
        Button3.Visible = False
        count()
    End Sub

    Private Sub Buttonadd_Click(sender As Object, e As EventArgs) Handles Buttonadd.Click
        If datacheck() = 0 Then
            If blank() = 0 Then
                If age() = 0 Then
                    If num() = 0 Then
                        If mailtest() = 0 Then
                            If prt() = 0 Then
                                If phn() = 0 Then
                                    If phn1() = 0 Then
                                        If phn2() = 0 Then
                                            If phn3() = 0 Then
                                                If nullimg() = 0 Then
                                                    Try
                                                        Cursor = Cursors.WaitCursor
                                                        Application.DoEvents()
                                                        Dim picture As Image = PictureBox2.Image
                                                        con.Open()
                                                        Dim cmd01 As New SqlCommand
                                                        cmd01.Connection = con
                                                        cmd01.CommandText = "insert into students(RFID,REGNO,STUDENTNAME,FATHERSNAME,MOTHERSNAME,ADDRESS,PINCODE,AADHAARNO,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,DATEOFBIRTH,DATEOFJOINING,EMAIL,ADDNO,GUARDIAN,PHOTO) values('" + TextBoxrfid.Text + "','" + TextBoxregno.Text + "','" + studentname.Text + "','" + fathersname.Text + "','" + mothersname.Text + "','" + TextBoxaddr.Text + "','" + pincode.Text + "','" + aadhaar.Text + "','" + studentphn.Text + "','" + parentphn.Text + "','" + TextBoxcourse.Text + "','" + TextBoxsem.Text + "','" + TextBoxgender.Text + "','" + dateofbirth.Text + "','" + dateofjoining.Text + "','" + email.Text + "','" + addmissionno.Text + "','" + guardian.Text + "',@MyImage)"
                                                        Using stream As New IO.MemoryStream
                                                            picture.Save(stream, Imaging.ImageFormat.Jpeg)
                                                            cmd01.Parameters.Add("@MyImage", SqlDbType.Image).Value = stream.GetBuffer
                                                            Debug.WriteLine(cmd01.ExecuteNonQuery())
                                                            con.Close()
                                                        End Using
                                                        MsgBox("Values added Successfully", MsgBoxStyle.Information, "Success")
                                                        clear()
                                                        count()
                                                        collection()
                                                        Cursor = Cursors.Default
                                                    Catch ex As Exception
                                                        MsgBox(ex.Message)
                                                        con.Close()
                                                    End Try
                                                Else
                                                    Label19.Text = "Please upload image"
                                                    Label19.ForeColor = Color.Red
                                                End If
                                            Else
                                                Label19.Text = "Invalid PINCODE number"
                                                Label19.ForeColor = Color.Red
                                            End If
                                        Else
                                            Label19.Text = "Invalid AADHAAR number"
                                            Label19.ForeColor = Color.Red
                                        End If
                                    Else
                                        Label19.Text = "Invalid student phone number"
                                        Label19.ForeColor = Color.Red
                                    End If

                                Else
                                    Label19.Text = "Invalid parent phone number"
                                    Label19.ForeColor = Color.Red
                                End If

                            Else
                                Label19.Text = "Please Enter Mother, Father or GUardians name "
                                Label19.ForeColor = Color.Red
                            End If
                        Else
                            Label19.Text = "Invalid email"
                            Label19.ForeColor = Color.Red
                        End If
                    Else
                        Label19.Text = "Parent phone number should not be same as student phone number"
                        Label19.ForeColor = Color.Red
                    End If
                Else
                    Label19.Text = "Student age dose not meet joining criteria"
                    Label19.ForeColor = Color.Red
                End If
            Else
                Label19.Text = "Please Enter All the values"
                Label19.ForeColor = Color.Red
            End If
        Else
            Label19.Text = "RFID is alredy assigned for someone other than student"
            Label19.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Buttoncancel_Click(sender As Object, e As EventArgs) Handles Buttoncancel.Click
        clear()
        Form3.Show()
        Me.Close()
    End Sub

    Private Sub Buttondlt_Click(sender As Object, e As EventArgs) Handles Buttondlt.Click
        If TextBoxrfid.Text <> "" Then
            Dim ans As Integer
            ans = MsgBox("Are you sure you want to delete?", vbOKCancel, "?")
            If ans = vbOK Then
                Try
                    Cursor = Cursors.WaitCursor
                    Application.DoEvents()
                    con.Open()
                    Dim cmd02 As New SqlCommand
                    cmd02.Connection = con
                    cmd02.CommandText = "delete from students where ('" + TextBoxrfid.Text + "')=RFID"
                    cmd02.ExecuteNonQuery()
                    Label19.Text = "Values Deleted from database successfully"
                    Label19.ForeColor = Color.Green
                    con.Close()
                    clear()
                    collection()
                    count()
                    Cursor = Cursors.Default
                Catch ex As Exception
                    MsgBox(ex.Message)
                    con.Close()
                End Try

            ElseIf ans = vbCancel Then
                Label19.Text = "Cancelled"
                Label19.ForeColor = Color.Green
            End If
        Else
            Label19.Text = "Select the RFID that is to be deleted"
            Label19.ForeColor = Color.Red
        End If

    End Sub




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub DateTimePicker1_TextChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.TextChanged
        dateofbirth.Text = DateTimePicker1.Value.Date
    End Sub

    Private Sub DateTimePicker2_TextChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.TextChanged
        dateofjoining.Text = DateTimePicker2.Value.Date
    End Sub

    Private Sub clearbtn_Click(sender As Object, e As EventArgs) Handles clearbtn.Click
        clear()
        Label19.Text = ""
    End Sub

    Private Sub TextBoxrfid_TextChanged(sender As Object, e As EventArgs) Handles TextBoxrfid.TextChanged
        TextBoxregno.Clear()
        studentname.Clear()
        fathersname.Clear()
        mothersname.Clear()
        TextBoxaddr.Clear()
        pincode.Clear()
        aadhaar.Clear()
        addmissionno.Clear()
        studentphn.Clear()
        parentphn.Clear()
        course.Text = ""
        sem.Text = ""
        gender.Text = ""
        TextBoxcourse.Clear()
        TextBoxgender.Clear()
        TextBoxsem.Clear()
        dateofbirth.Clear()
        dateofjoining.Clear()
        email.Clear()
        guardian.Clear()
        DateTimePicker1.MaxDate = Date.Now
        DateTimePicker2.MaxDate = Date.Now
        Buttonadd.Enabled = True
        Label19.Text = ""
        PictureBox2.BackgroundImage = studentmanegerv2.My.Resources.Resources.twotone_add_photo_alternate_white_24dp
        PictureBox2.Image = Nothing
        Button3.Visible = False
    End Sub

    Private Sub gender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gender.SelectedIndexChanged
        TextBoxgender.Text = gender.Text
    End Sub

    Private Sub course_SelectedIndexChanged(sender As Object, e As EventArgs) Handles course.SelectedIndexChanged
        TextBoxcourse.Text = course.Text
    End Sub

    Private Sub sem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sem.SelectedIndexChanged
        TextBoxsem.Text = sem.Text
    End Sub

    Private Sub pincode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles pincode.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then

            Else

                e.Handled = True
            End If
        End If
    End Sub

    Private Sub parentphn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles parentphn.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then

            Else

                e.Handled = True
            End If
        End If
    End Sub

    Private Sub studentphn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles studentphn.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then

            Else

                e.Handled = True
            End If
        End If
    End Sub

    Private Sub aadhaar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles aadhaar.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then

            Else

                e.Handled = True
            End If
        End If
    End Sub



    Private Sub fathersname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles fathersname.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "
            If Not allowedChars.Contains(e.KeyChar.ToString) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub studentname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles studentname.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "
            If Not allowedChars.Contains(e.KeyChar.ToString) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub mothersname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mothersname.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "
            If Not allowedChars.Contains(e.KeyChar.ToString) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

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
            Me.ActiveControl = TextBoxregno
            TextBoxregno.SelectionLength = 0
        End If
    End Sub

    Private Sub addmissionno_KeyDown(sender As Object, e As KeyEventArgs) Handles addmissionno.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = studentname

        End If
    End Sub

    Private Sub TextBoxregno_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxregno.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = addmissionno

        End If
    End Sub

    Private Sub studentname_KeyDown(sender As Object, e As KeyEventArgs) Handles studentname.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = fathersname
        End If
    End Sub

    Private Sub fathersname_KeyDown(sender As Object, e As KeyEventArgs) Handles fathersname.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = mothersname
        End If
    End Sub

    Private Sub TextBoxaddr_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxaddr.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = pincode
        End If
    End Sub

    Private Sub mothersname_KeyDown(sender As Object, e As KeyEventArgs) Handles mothersname.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = guardian
        End If
    End Sub

    Private Sub pincode_KeyDown(sender As Object, e As KeyEventArgs) Handles pincode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = aadhaar
        End If
    End Sub

    Private Sub aadhaar_KeyDown(sender As Object, e As KeyEventArgs) Handles aadhaar.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = studentphn
        End If
    End Sub

    Private Sub studentphn_KeyDown(sender As Object, e As KeyEventArgs) Handles studentphn.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = parentphn
        End If
    End Sub

    Private Sub parentphn_KeyDown(sender As Object, e As KeyEventArgs) Handles parentphn.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = email
        End If
    End Sub

    Private Sub TextBoxrfid_LostFocus(sender As Object, e As EventArgs) Handles TextBoxrfid.LostFocus
        lf()
        pic()
    End Sub
    Function lf()
        Try
            Dim r As String
            con.Open()
            Dim cmd3 As New SqlCommand
            cmd3.Connection = con
            cmd3.CommandText = "select * from students where RFID=('" + TextBoxrfid.Text + "')"
            cmd3.CommandType = CommandType.Text
            Dim sdr As SqlDataReader = cmd3.ExecuteReader
            sdr.Read()
            r = sdr("RFID").ToString
            TextBoxregno.Text = sdr("REGNO").ToString.Trim
            studentname.Text = sdr("STUDENTNAME").ToString.Trim
            fathersname.Text = sdr("FATHERSNAME").ToString.Trim
            mothersname.Text = sdr("MOTHERSNAME").ToString.Trim
            guardian.Text = sdr("GUARDIAN").ToString.Trim
            TextBoxaddr.Text = sdr("ADDRESS").ToString.Trim
            pincode.Text = sdr("PINCODE").ToString.Trim
            aadhaar.Text = sdr("AADHAARNO").ToString.Trim
            addmissionno.Text = sdr("ADDNO").ToString.Trim
            studentphn.Text = sdr("STDPHONE").ToString.Trim
            parentphn.Text = sdr("PARENTPHN").ToString.Trim
            TextBoxcourse.Text = sdr("COURSE").ToString.Trim
            TextBoxsem.Text = sdr("SEM").ToString.Trim
            TextBoxgender.Text = sdr("GENDER").ToString.Trim
            dateofbirth.Text = sdr("DATEOFBIRTH").ToString.Trim
            DateTimePicker1.Value = dateofbirth.Text
            dateofjoining.Text = sdr("DATEOFJOINING").ToString.Trim
            DateTimePicker2.Value = dateofjoining.Text
            email.Text = sdr("EMAIL").ToString.Trim
            con.Close()
            Buttonadd.Enabled = False
            Button3.Visible = True
        Catch ex As Exception
            con.Close()
            Buttonadd.Enabled = True
        End Try

    End Function
    Function pic()
        Try
            Dim picture1 As Image = Nothing
            con.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            Dim path As String = OpenFileDialog1.FileName
            cmd.CommandText = "select PHOTO from students where RFID=('" + TextBoxrfid.Text + "')"
            Dim pictureData As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
            con.Close()
            Using stream As New IO.MemoryStream(pictureData)
                picture1 = Image.FromStream(stream)
            End Using
            PictureBox2.Image = picture1
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
            Return picture1
        Catch ex As Exception
            con.Close()
        End Try
    End Function






    Private Sub guardian_KeyPress(sender As Object, e As KeyPressEventArgs) Handles guardian.KeyPress

        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "
            If Not allowedChars.Contains(e.KeyChar.ToString) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub



    Private Sub email_TextChanged(sender As Object, e As EventArgs) Handles email.TextChanged
        If mailtest() = 1 Then
            Label19.Text = "Invalid email"
            Label19.ForeColor = Color.Red
        Else
            Label19.Text = ""
        End If
    End Sub

    Private Sub parentphn_TextChanged(sender As Object, e As EventArgs) Handles parentphn.TextChanged
        If phn() = 1 Then
            Label19.Text = "Invalid parent phone number"
            Label19.ForeColor = Color.Red

        Else
            Label19.Text = ""
        End If
    End Sub

    Private Sub studentphn_TabIndexChanged(sender As Object, e As EventArgs) Handles studentphn.TabIndexChanged

    End Sub

    Private Sub aadhaar_TextChanged(sender As Object, e As EventArgs) Handles aadhaar.TextChanged
        If phn2() = 1 Then
            Label19.Text = "Invalid AADHAAR number"
            Label19.ForeColor = Color.Red

        Else
            Label19.Text = ""
        End If
    End Sub

    Private Sub aadhaar_MouseDown(sender As Object, e As MouseEventArgs) Handles aadhaar.MouseDown
        If e.Button = MouseButtons.Right Then
            aadhaar.ContextMenu = New ContextMenu()
            Label19.Text = "copy paste not allowed"
            Label19.ForeColor = Color.Red
        End If
    End Sub

    Private Sub parentphn_MouseDown(sender As Object, e As MouseEventArgs) Handles parentphn.MouseDown
        If e.Button = MouseButtons.Right Then
            parentphn.ContextMenu = New ContextMenu()
            Label19.Text = "copy paste not allowed"
            Label19.ForeColor = Color.Red
        End If
    End Sub

    Private Sub studentphn_MouseDown(sender As Object, e As MouseEventArgs) Handles studentphn.MouseDown
        If e.Button = MouseButtons.Right Then
            studentphn.ContextMenu = New ContextMenu()
            Label19.Text = "copy paste not allowed"
            Label19.ForeColor = Color.Red
        End If
    End Sub

    Private Sub TextBoxrfid_MouseDown(sender As Object, e As MouseEventArgs) Handles TextBoxrfid.MouseDown
        If e.Button = MouseButtons.Right Then
            TextBoxrfid.ContextMenu = New ContextMenu()
            Label19.Text = "copy paste not allowed"
            Label19.ForeColor = Color.Red
        End If
    End Sub

    Private Sub pincode_MouseDown(sender As Object, e As MouseEventArgs) Handles pincode.MouseDown
        If e.Button = MouseButtons.Right Then
            pincode.ContextMenu = New ContextMenu()
            Label19.Text = "copy paste not allowed"
            Label19.ForeColor = Color.Red
        End If
    End Sub


    Private Sub studentphn_TextChanged(sender As Object, e As EventArgs) Handles studentphn.TextChanged
        If phn1() = 1 Then
            Label19.Text = "Invalid student phone number"
            Label19.ForeColor = Color.Red

        Else
            Label19.Text = ""
        End If
    End Sub

    Private Sub guardian_KeyDown(sender As Object, e As KeyEventArgs) Handles guardian.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBoxaddr.Focus()
        End If
    End Sub

    Private Sub studentname_MouseDown(sender As Object, e As MouseEventArgs) Handles studentname.MouseDown
        If e.Button = MouseButtons.Right Then
            studentname.ContextMenu = New ContextMenu()
            Label19.Text = "copy paste not allowed"
            Label19.ForeColor = Color.Red
        End If
    End Sub

    Private Sub fathersname_MouseDown(sender As Object, e As MouseEventArgs) Handles fathersname.MouseDown
        If e.Button = MouseButtons.Right Then
            fathersname.ContextMenu = New ContextMenu()
            Label19.Text = "copy paste not allowed"
            Label19.ForeColor = Color.Red
        End If
    End Sub

    Private Sub mothersname_MouseDown(sender As Object, e As MouseEventArgs) Handles mothersname.MouseDown
        If e.Button = MouseButtons.Right Then
            mothersname.ContextMenu = New ContextMenu()
            Label19.Text = "copy paste not allowed"
            Label19.ForeColor = Color.Red
        End If
    End Sub

    Private Sub guardian_MouseDown(sender As Object, e As MouseEventArgs) Handles guardian.MouseDown
        If e.Button = MouseButtons.Right Then
            guardian.ContextMenu = New ContextMenu()
            Label19.Text = "copy paste not allowed"
            Label19.ForeColor = Color.Red
        End If
    End Sub

    Private Sub addimg_Click(sender As Object, e As EventArgs) Handles addimg.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Try
            PictureBox2.ImageLocation = OpenFileDialog1.FileName
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        Catch ex As Exception

        End Try


    End Sub
    Function datacheck()
        Try
            Dim r As String
            con.Open()
            Dim cmd3 As New SqlCommand
            cmd3.Connection = con
            cmd3.CommandText = "select * from staff where RFID=('" + TextBoxrfid.Text + "')"
            cmd3.CommandType = CommandType.Text
            Dim sdr As SqlDataReader = cmd3.ExecuteReader
            sdr.Read()
            r = sdr("RFID").ToString
            If r IsNot Nothing Then
                Return 1
            Else
                Return 0
            End If
        Catch ex As Exception
            con.Close()
        End Try
    End Function

    Private Sub Buttonmod_Click(sender As Object, e As EventArgs) Handles Buttonmod.Click
        If blank() = 0 Then
            If age() = 0 Then
                If num() = 0 Then
                    If mailtest() = 0 Then
                        If prt() = 0 Then
                            If phn() = 0 Then
                                If phn1() = 0 Then
                                    If phn2() = 0 Then
                                        If phn3() = 0 Then
                                            If nullimg() = 0 Then
                                                Try
                                                    Cursor = Cursors.WaitCursor
                                                    Application.DoEvents()
                                                    Dim picture As Image = PictureBox2.Image
                                                    con.Open()
                                                    Dim cmd01 As New SqlCommand
                                                    cmd01.Connection = con
                                                    cmd01.CommandText = "update students set REGNO=('" + TextBoxregno.Text + "'),STUDENTNAME=('" + studentname.Text + "'),FATHERSNAME=('" + fathersname.Text + "'),MOTHERSNAME=('" + mothersname.Text + "'),ADDRESS=('" + TextBoxaddr.Text + "'),PINCODE=('" + pincode.Text + "'),AADHAARNO=('" + aadhaar.Text + "'),STDPHONE=('" + studentphn.Text + "'),PARENTPHN=('" + parentphn.Text + "'),COURSE=('" + TextBoxcourse.Text + "'),SEM=('" + TextBoxsem.Text + "'),GENDER=('" + TextBoxgender.Text + "'),DATEOFBIRTH=('" + dateofbirth.Text + "'),DATEOFJOINING=('" + dateofjoining.Text + "'),EMAIL=('" + email.Text + "'),ADDNO=('" + addmissionno.Text + "'),GUARDIAN=('" + guardian.Text + "') where RFID=('" + TextBoxrfid.Text + "')"
                                                    cmd01.ExecuteNonQuery()
                                                    con.Close()
                                                    MsgBox("Values updated Successfully", MsgBoxStyle.Information, "Success")
                                                    clear()
                                                    Cursor = Cursors.Default
                                                Catch ex As Exception
                                                    MsgBox(ex.Message)
                                                    con.Close()
                                                End Try
                                            Else
                                                Label19.Text = "Please upload image"
                                                Label19.ForeColor = Color.Red
                                            End If
                                        Else
                                                Label19.Text = "Invalid PINCODE number"
                                            Label19.ForeColor = Color.Red
                                        End If
                                    Else
                                        Label19.Text = "Invalid AADHAAR number"
                                        Label19.ForeColor = Color.Red
                                    End If
                                Else
                                    Label19.Text = "Invalid student phone number"
                                    Label19.ForeColor = Color.Red
                                End If

                            Else
                                Label19.Text = "Invalid parent phone number"
                                Label19.ForeColor = Color.Red
                            End If

                        Else
                            Label19.Text = "Please Enter Mother, Father or GUardians name "
                            Label19.ForeColor = Color.Red
                        End If
                    Else
                        Label19.Text = "Invalid email"
                        Label19.ForeColor = Color.Red
                    End If
                Else
                    Label19.Text = "Parent phone number should not be same as student phone number"
                    Label19.ForeColor = Color.Red
                End If
            Else
                Label19.Text = "Student age dose not meet joining criteria"
                Label19.ForeColor = Color.Red
            End If
        Else
            Label19.Text = "Please Enter All the values"
            Label19.ForeColor = Color.Red
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If blank() = 0 Then
            If age() = 0 Then
                If num() = 0 Then
                    If mailtest() = 0 Then
                        If prt() = 0 Then
                            If phn() = 0 Then
                                If phn1() = 0 Then
                                    If phn2() = 0 Then
                                        If phn3() = 0 Then
                                            If nullimg() = 0 Then
                                                Try
                                                    Cursor = Cursors.WaitCursor
                                                    Application.DoEvents()
                                                    Dim picture As Image
                                                    picture = PictureBox2.Image
                                                    con.Open()
                                                    Dim cmd01 As New SqlCommand
                                                    cmd01.Connection = con
                                                    cmd01.CommandText = "update students set PHOTO=(@MyImage) where RFID=('" + TextBoxrfid.Text + "')"
                                                    Using stream As New IO.MemoryStream
                                                        picture.Save(stream, Imaging.ImageFormat.Jpeg)
                                                        cmd01.Parameters.Add("@MyImage", SqlDbType.Image).Value = stream.GetBuffer
                                                        Debug.WriteLine(cmd01.ExecuteNonQuery())
                                                        con.Close()
                                                    End Using
                                                    MsgBox("Values updated Successfully", MsgBoxStyle.Information, "Success")
                                                    Cursor = Cursors.Default
                                                Catch ex As Exception
                                                    Label19.Text = "Please select a different image"
                                                    Label19.ForeColor = Color.Red
                                                    con.Close()
                                                End Try
                                            Else
                                                Label19.Text = "Please upload image"
                                                Label19.ForeColor = Color.Red
                                            End If
                                        Else
                                            Label19.Text = "Invalid PINCODE number"
                                            Label19.ForeColor = Color.Red
                                        End If
                                    Else
                                        Label19.Text = "Invalid AADHAAR number"
                                        Label19.ForeColor = Color.Red
                                    End If
                                Else
                                    Label19.Text = "Invalid student phone number"
                                    Label19.ForeColor = Color.Red
                                End If

                            Else
                                Label19.Text = "Invalid parent phone number"
                                Label19.ForeColor = Color.Red
                            End If

                        Else
                            Label19.Text = "Please Enter Mother, Father or GUardians name "
                            Label19.ForeColor = Color.Red
                        End If
                    Else
                        Label19.Text = "Invalid email"
                        Label19.ForeColor = Color.Red
                    End If
                Else
                    Label19.Text = "Parent phone number should not be same as student phone number"
                    Label19.ForeColor = Color.Red
                End If
            Else
                Label19.Text = "Student age dose not meet joining criteria"
                Label19.ForeColor = Color.Red
            End If
        Else
            Label19.Text = "Please Enter All the values"
            Label19.ForeColor = Color.Red
        End If


    End Sub


End Class