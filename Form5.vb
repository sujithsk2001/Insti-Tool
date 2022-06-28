Imports System.Data.SqlClient
Imports System.Net.Mail
Public Class Form5
    Dim buttonhp As Panel
    Dim currbtn As Button
    Dim currtb As TextBox
    Dim currtb2 As TextBox
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\V'th sem project\studentmanegerv2\students007.mdf;Integrated Security=True")
    Public Sub New()
        InitializeComponent()
        buttonhp = New Panel
        buttonhp.Size = New Size(114, 4)
        Panelmenu1.Controls.Add(buttonhp)
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
            currbtn.BackColor = Color.FromArgb(31, 30, 68)
            currbtn.ForeColor = Color.Gainsboro
            currbtn.TextAlign = ContentAlignment.MiddleCenter
            currbtn.TextImageRelation = TextImageRelation.ImageBeforeText
            Panelmenu.Enabled = False
        End If
    End Sub
    Function clearalp()
        alrfid.Clear()
        alname.Clear()
        aladdr.Clear()
        alpin.Clear()
        alaadhaar.Clear()
        alphn.Clear()
        alaltphn.Clear()
        alemail.Clear()
        algender.Clear()
        aldateofj.Clear()
        alpic.Image = Nothing
        GC.Collect()
        ComboBox5.Text = ""
        Label19.Text = ""
        alpicupdate.Visible = False
    End Function
    Function clearpd()
        pdrfid.Clear()
        pdname.Clear()
        pdaddr.Clear()
        pdpincode.Clear()
        pdaadhar.Clear()
        pdphone.Clear()
        pdaltphone.Clear()
        pdemail.Clear()
        pdgender.Clear()
        pdsub1.Clear()
        pdsub2.Clear()
        pddateofj.Clear()
        pdpic.Image = Nothing
        GC.Collect()
        ComboBox1.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        Label19.Text = ""
        pdpicupdate.Visible = False
    End Function
    Function clearhl()
        hlrfid.Clear()
        hlname.Clear()
        hladdr.Clear()
        hlpin.Clear()
        hlaadhaar.Clear()
        hlphoneno.Clear()
        hlaltphone.Clear()
        hlemail.Clear()
        hlgender.Clear()
        hlsub1.Clear()
        hlsub2.Clear()
        hldateofjoining.Clear()
        hldepart.Clear()
        hlpic.Image = Nothing
        GC.Collect()
        gender.Text = ""
        sem.Text = ""
        course.Text = ""
        sub2.Text = ""
        Label19.Text = ""
        hlupdateimage.Visible = False
    End Function
    Function numchk(e As KeyPressEventArgs)
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If
    End Function
    Function charchk(e As KeyPressEventArgs)
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "
            If Not allowedChars.Contains(e.KeyChar.ToString) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Function
    Function nocpy(o As Object, e As MouseEventArgs)
        If o IsNot Nothing Then
            currtb = CType(o, TextBox)
            currtb.ContextMenu = New ContextMenu
        End If
    End Function
    Private Sub DirectorPrincipal_Click(sender As Object, e As EventArgs) Handles Director.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        principalchair.Show()
        hodlec.Show()
        accountantlibr.Hide()
        Panelmenu.Enabled = True
        clearhl()
        clearalp()
        'clearpd()
        Me.ActiveControl = pdrfid
    End Sub

    Private Sub HOD_Click(sender As Object, e As EventArgs) Handles HOD.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        principalchair.Hide()
        hodlec.Show()
        accountantlibr.Hide()
        Panelmenu.Enabled = True
        clearpd()
        clearalp()
        'clearhl()
        Me.ActiveControl = hlrfid
    End Sub

    Private Sub Lecturer_Click(sender As Object, e As EventArgs) Handles Lecturer.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        principalchair.Hide()
        hodlec.Show()
        accountantlibr.Hide()
        Panelmenu.Enabled = True
        clearpd()
        clearalp()
        'clearhl()
        Me.ActiveControl = hlrfid
    End Sub

    Private Sub Librarian_Click(sender As Object, e As EventArgs) Handles Librarian.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        accountantlibr.Show()
        principalchair.Show()
        hodlec.Show()
        Panelmenu.Enabled = True
        clearpd()
        clearhl()
        'clearalp()
        Me.ActiveControl = alrfid
    End Sub

    Private Sub Accountant_Click(sender As Object, e As EventArgs) Handles Accountant.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        accountantlibr.Show()
        principalchair.Show()
        hodlec.Show()
        Panelmenu.Enabled = True
        clearpd()
        clearhl()
        'clearalp()
        Me.ActiveControl = alrfid
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles Me.Load
        principalchair.Hide()
        hodlec.Hide()
        accountantlibr.Hide()
        Panelmenu.Enabled = False
        DateTimePicker1.MaxDate = Date.Now
        DateTimePicker2.MaxDate = Date.Now
        DateTimePicker3.MaxDate = Date.Now
        clearalp()
        clearpd()
        clearhl()
        Label19.Text = ""
        pdcollection()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub



    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.ValueChanged
        aldateofj.Text = DateTimePicker3.Value.Date
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        algender.Text = ComboBox5.Text
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        OpenFileDialog3.ShowDialog()
    End Sub

    Private Sub gender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gender.SelectedIndexChanged
        hlgender.Text = gender.Text
    End Sub

    Private Sub sem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sem.SelectedIndexChanged
        hldepart.Text = sem.Text
    End Sub

    Private Sub course_SelectedIndexChanged(sender As Object, e As EventArgs) Handles course.SelectedIndexChanged
        hlsub1.Text = course.Text
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sub2.SelectedIndexChanged
        hlsub2.Text = sub2.Text
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        hldateofjoining.Text = DateTimePicker2.Value.Date
    End Sub

    Private Sub addimg_Click(sender As Object, e As EventArgs) Handles addimg.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub updateimage_Click(sender As Object, e As EventArgs) Handles hlupdateimage.Click
        updhlpic()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        OpenFileDialog2.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles pdpicupdate.Click
        If buttonhp.Location = Director.Location Or buttonhp.Location = Principal.Location Then
            updatepdpic()

        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        pdgender.Text = ComboBox4.Text
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        pdsub2.Text = ComboBox1.Text
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        pdsub1.Text = ComboBox3.Text
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        pddateofj.Text = DateTimePicker1.Value.Date
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        hlpic.ImageLocation = OpenFileDialog1.FileName
        hlpic.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub OpenFileDialog2_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog2.FileOk
        pdpic.ImageLocation = OpenFileDialog2.FileName
        pdpic.SizeMode = PictureBoxSizeMode.StretchImage

    End Sub

    Private Sub OpenFileDialog3_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog3.FileOk
        alpic.ImageLocation = OpenFileDialog3.FileName
        alpic.SizeMode = PictureBoxSizeMode.StretchImage

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles alpicupdate.Click
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        updalpic()
        Cursor = Cursors.Default
    End Sub

    Private Sub clearbtn_Click(sender As Object, e As EventArgs) Handles clearbtn.Click
        If buttonhp.Location = Director.Location Or buttonhp.Location = Principal.Location Then
            clearpd()
        ElseIf buttonhp.Location = HOD.Location Or buttonhp.Location = Lecturer.Location Then
            clearhl()
        ElseIf buttonhp.Location = Accountant.Location Or buttonhp.Location = Librarian.Location Then
            clearalp()
        End If
    End Sub

    Private Sub alrfid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles alrfid.KeyPress
        numchk(e)
    End Sub

    Private Sub alpin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles alpin.KeyPress
        numchk(e)
    End Sub

    Private Sub alphn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles alphn.KeyPress
        numchk(e)
    End Sub

    Private Sub alaltphn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles alaltphn.KeyPress
        numchk(e)
    End Sub

    Private Sub alaadhar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles alaadhaar.KeyPress
        numchk(e)
    End Sub

    Private Sub hlrfid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles hlrfid.KeyPress
        numchk(e)
    End Sub

    Private Sub hlpin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles hlpin.KeyPress
        numchk(e)
    End Sub

    Private Sub hlphoneno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles hlphoneno.KeyPress
        numchk(e)
    End Sub

    Private Sub hlaltphone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles hlaltphone.KeyPress
        numchk(e)
    End Sub

    Private Sub hlaadhaar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles hlaadhaar.KeyPress
        numchk(e)
    End Sub

    Private Sub pdrfid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles pdrfid.KeyPress
        numchk(e)
    End Sub

    Private Sub pdpincode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles pdpincode.KeyPress
        numchk(e)
    End Sub

    Private Sub pdphone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles pdphone.KeyPress
        numchk(e)
    End Sub

    Private Sub pdaltphone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles pdaltphone.KeyPress
        numchk(e)
    End Sub

    Private Sub pdaadhar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles pdaadhar.KeyPress
        numchk(e)
    End Sub

    Private Sub alname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles alname.KeyPress
        charchk(e)
    End Sub

    Private Sub hlname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles hlname.KeyPress
        charchk(e)
    End Sub

    Private Sub pdname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles pdname.KeyPress
        charchk(e)
    End Sub

    Private Sub alrfid_MouseDown(sender As Object, e As MouseEventArgs) Handles alrfid.MouseDown
        nocpy(sender, e)
    End Sub

    Private Sub alpin_MouseDown(sender As Object, e As MouseEventArgs) Handles alpin.MouseDown
        nocpy(sender, e)
    End Sub

    Private Sub alphn_MouseDown(sender As Object, e As MouseEventArgs) Handles alphn.MouseDown
        nocpy(sender, e)
    End Sub

    Private Sub alname_MouseDown(sender As Object, e As MouseEventArgs) Handles alname.MouseDown
        nocpy(sender, e)
    End Sub

    Private Sub alaltphn_MouseDown(sender As Object, e As MouseEventArgs) Handles alaltphn.MouseDown
        nocpy(sender, e)
    End Sub

    Private Sub alaadhar_MouseDown(sender As Object, e As MouseEventArgs) Handles alaadhaar.MouseDown
        nocpy(sender, e)
    End Sub

    Private Sub hlrfid_MouseDown(sender As Object, e As MouseEventArgs) Handles hlrfid.MouseDown
        nocpy(sender, e)
    End Sub

    Private Sub hlpin_MouseDown(sender As Object, e As MouseEventArgs) Handles hlpin.MouseDown
        nocpy(sender, e)
    End Sub

    Private Sub hlphoneno_MouseDown(sender As Object, e As MouseEventArgs) Handles hlphoneno.MouseDown
        nocpy(sender, e)
    End Sub

    Private Sub hlname_MouseDown(sender As Object, e As MouseEventArgs) Handles hlname.MouseDown
        nocpy(sender, e)
    End Sub

    Private Sub hlaltphone_MouseDown(sender As Object, e As MouseEventArgs) Handles hlaltphone.MouseDown
        nocpy(sender, e)
    End Sub

    Private Sub hlaadhaar_MouseDown(sender As Object, e As MouseEventArgs) Handles hlaadhaar.MouseDown
        nocpy(sender, e)
    End Sub

    Private Sub pdrfid_MouseDown(sender As Object, e As MouseEventArgs) Handles pdrfid.MouseDown
        nocpy(sender, e)
    End Sub

    Private Sub pdpincode_MouseDown(sender As Object, e As MouseEventArgs) Handles pdpincode.MouseDown
        nocpy(sender, e)
    End Sub

    Private Sub pdphone_MouseDown(sender As Object, e As MouseEventArgs) Handles pdphone.MouseDown
        nocpy(sender, e)
    End Sub

    Private Sub pdname_MouseDown(sender As Object, e As MouseEventArgs) Handles pdname.MouseDown
        nocpy(sender, e)
    End Sub

    Private Sub pdaltphone_MouseDown(sender As Object, e As MouseEventArgs) Handles pdaltphone.MouseDown
        nocpy(sender, e)
    End Sub

    Private Sub pdaadhar_MouseDown(sender As Object, e As MouseEventArgs) Handles pdaadhar.MouseDown
        nocpy(sender, e)
    End Sub
    Function pdmailt()
        Try
            Dim testAddress = New MailAddress(pdemail.Text)
        Catch ex As FormatException
            Return 1
        End Try
    End Function
    Function pdcollection()
        Try
            con.Open()
            Dim cmd45 As New SqlCommand
            cmd45.Connection = con
            cmd45.CommandText = "Select RFID from Staff "
            cmd45.CommandType = CommandType.Text
            Dim sdr As SqlDataReader = cmd45.ExecuteReader()
            sdr.Read()
            Dim list As New AutoCompleteStringCollection
            While sdr.Read()
                list.Add(sdr("RFID").ToString())
            End While
            pdrfid.AutoCompleteCustomSource = list
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
    End Function
    Function adddp()
        If buttonhp.Location = Director.Location Or buttonhp.Location = Principal.Location Then
            If pdrfid.Text.Trim <> "" And pdname.Text.Trim <> "" And pdaddr.Text.Trim <> "" And pdpincode.Text.Trim <> "" And pdaadhar.Text.Trim <> "" And pdphone.Text.Trim <> "" And pdaltphone.Text.Trim <> "" And pdemail.Text.Trim <> "" And pdgender.Text.Trim <> "" And pddateofj.Text.Trim <> "" And pdpic.Image IsNot Nothing Then
                If pdpincode.TextLength = 6 Then
                    If pdaadhar.TextLength = 12 And (pdaadhar.Text.StartsWith("2") Or pdaadhar.Text.StartsWith("3") Or pdaadhar.Text.StartsWith("4") Or pdaadhar.Text.StartsWith("5") Or pdaadhar.Text.StartsWith("6") Or pdaadhar.Text.StartsWith("7") Or pdaadhar.Text.StartsWith("8") Or pdaadhar.Text.StartsWith("9")) Then
                        If pdphone.TextLength = 10 And pdaltphone.TextLength = 10 Then
                            If pdphone.Text <> pdaltphone.Text Then
                                If pdmailt() <> 1 Then
                                    Try
                                        Dim picture As Image = pdpic.Image
                                        con.Open()
                                        Dim cmd01 As New SqlCommand
                                        cmd01.Connection = con
                                        cmd01.CommandText = "insert into staff(RFID,NAME,ADDRESS,pincode,AADHAAR,PHONENO,ALTPHONE,EMAIL,GENDER,SUB1,SUB2,DATEOFJOINING,PHOTO,POST) values('" + pdrfid.Text + "','" + pdname.Text + "','" + pdaddr.Text + "','" + pdpincode.Text + "','" + pdaadhar.Text + "','" + pdphone.Text + "','" + pdaltphone.Text + "','" + pdemail.Text + "','" + pdgender.Text + "','" + pdsub1.Text + "','" + pdsub2.Text + "','" + pddateofj.Text + "',@MyImage,'" + currbtn.Text.Trim + "')"
                                        Using stream As New IO.MemoryStream
                                            picture.Save(stream, Imaging.ImageFormat.Jpeg)
                                            cmd01.Parameters.Add("@MyImage", SqlDbType.Image).Value = stream.GetBuffer
                                            Debug.WriteLine(cmd01.ExecuteNonQuery())
                                            con.Close()
                                        End Using
                                        MsgBox("Values added Successfully", MsgBoxStyle.Information, "Success")
                                        clearpd()
                                        pdcollection()
                                    Catch ex As Exception
                                        MsgBox(ex.Message)
                                        con.Close()
                                    End Try
                                Else
                                    Label19.Text = "Please enter valid email address"
                                    Label19.ForeColor = Color.Red
                                End If
                            Else
                                Label19.Text = "phone number and alternate phone number shall not be same"
                                Label19.ForeColor = Color.Red
                            End If
                        Else
                            Label19.Text = "Please enter valid phone number"
                            Label19.ForeColor = Color.Red
                        End If
                    Else
                        Label19.Text = "Please enter a valid AADHAAR number"
                        Label19.ForeColor = Color.Red
                    End If
                Else
                    Label19.Text = "Please enter a valid pincode number"
                    Label19.ForeColor = Color.Red
                End If
            Else
                Label19.Text = "Please enter all the information"
                Label19.ForeColor = Color.Red
            End If
        End If
    End Function
    Function updatedptxt()
        If buttonhp.Location = Director.Location Or buttonhp.Location = Principal.Location Then
            If pdrfid.Text.Trim <> "" And pdname.Text.Trim <> "" And pdaddr.Text.Trim <> "" And pdpincode.Text.Trim <> "" And pdaadhar.Text.Trim <> "" And pdphone.Text.Trim <> "" And pdaltphone.Text.Trim <> "" And pdemail.Text.Trim <> "" And pdgender.Text.Trim <> "" And pddateofj.Text.Trim <> "" And pdpic.Image IsNot Nothing Then
                If pdpincode.TextLength = 6 Then
                    If pdaadhar.TextLength = 12 And (pdaadhar.Text.StartsWith("2") Or pdaadhar.Text.StartsWith("3") Or pdaadhar.Text.StartsWith("4") Or pdaadhar.Text.StartsWith("5") Or pdaadhar.Text.StartsWith("6") Or pdaadhar.Text.StartsWith("7") Or pdaadhar.Text.StartsWith("8") Or pdaadhar.Text.StartsWith("9")) Then
                        If pdphone.TextLength = 10 And pdaltphone.TextLength = 10 Then
                            If pdphone.Text <> pdaltphone.Text Then
                                If pdmailt() <> 1 Then
                                    Try
                                        con.Open()
                                        Dim cmd01 As New SqlCommand
                                        cmd01.Connection = con
                                        cmd01.CommandText = "update staff set NAME=('" + pdname.Text + "'),ADDRESS=('" + pdaddr.Text + "'),pincode=('" + pdpincode.Text + "'),AADHAAR=('" + pdaadhar.Text + "'),PHONENO=('" + pdphone.Text + "'),ALTPHONE=('" + pdaltphone.Text + "'),EMAIL=('" + pdemail.Text + "'),GENDER=('" + pdgender.Text + "'),SUB1=('" + pdsub1.Text + "'),SUB2=('" + pdsub2.Text + "'),DATEOFJOINING=('" + pddateofj.Text + "') where RFID=('" + pdrfid.Text + "')"
                                        cmd01.ExecuteNonQuery()
                                        con.Close()
                                        MsgBox("Values modified Successfully", MsgBoxStyle.Information, "Success")
                                        clearpd()
                                        pdcollection()
                                    Catch ex As Exception
                                        MsgBox(ex.Message)
                                        con.Close()
                                    End Try
                                Else
                                    Label19.Text = "Please enter valid email address"
                                    Label19.ForeColor = Color.Red
                                End If
                            Else
                                Label19.Text = "phone number and alternate phone number shall not be same"
                                Label19.ForeColor = Color.Red
                            End If
                        Else
                            Label19.Text = "Please enter valid phone number"
                            Label19.ForeColor = Color.Red
                        End If
                    Else
                        Label19.Text = "Please enter a valid AADHAAR number"
                        Label19.ForeColor = Color.Red
                    End If
                Else
                    Label19.Text = "Please enter a valid pincode number"
                    Label19.ForeColor = Color.Red
                End If
            Else
                Label19.Text = "Please enter all the information"
                Label19.ForeColor = Color.Red
            End If
        End If
    End Function
    Function dltpd()
        If buttonhp.Location = Director.Location Or buttonhp.Location = Principal.Location Then
            If pdrfid.Text <> "" Then
                Dim ans As Integer
                ans = MsgBox("Are you sure you want to delete?", vbOKCancel, "?")
                If ans = vbOK Then
                    Try
                        con.Open()
                        Dim cmd02 As New SqlCommand
                        cmd02.Connection = con
                        cmd02.CommandText = "delete from staff where ('" + pdrfid.Text + "')=RFID"
                        cmd02.ExecuteNonQuery()
                        Label19.Text = "Values Deleted from database successfully"
                        Label19.ForeColor = Color.Green
                        con.Close()
                        clearpd()
                        pdcollection()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        con.Close()
                        pdcollection()
                    End Try

                ElseIf ans = vbCancel Then
                    Label19.Text = "Cancelled"
                    Label19.ForeColor = Color.Green
                End If
            Else
                Label19.Text = "Select the RFID that is to be deleted"
                Label19.ForeColor = Color.Red
            End If
        End If
    End Function
    Function updatepdpic()
        If buttonhp.Location = Director.Location Or buttonhp.Location = Principal.Location Then
            If pdrfid.Text.Trim <> "" And pdname.Text.Trim <> "" And pdaddr.Text.Trim <> "" And pdpincode.Text.Trim <> "" And pdaadhar.Text.Trim <> "" And pdphone.Text.Trim <> "" And pdaltphone.Text.Trim <> "" And pdemail.Text.Trim <> "" And pdgender.Text.Trim <> "" And pddateofj.Text.Trim <> "" And pdpic.Image IsNot Nothing Then
                If pdpincode.TextLength = 6 Then
                    If pdaadhar.TextLength = 12 And (pdaadhar.Text.StartsWith("2") Or pdaadhar.Text.StartsWith("3") Or pdaadhar.Text.StartsWith("4") Or pdaadhar.Text.StartsWith("5") Or pdaadhar.Text.StartsWith("6") Or pdaadhar.Text.StartsWith("7") Or pdaadhar.Text.StartsWith("8") Or pdaadhar.Text.StartsWith("9")) Then
                        If pdphone.TextLength = 10 And pdaltphone.TextLength = 10 Then
                            If pdphone.Text <> pdaltphone.Text Then
                                If pdmailt() <> 1 Then
                                    Try
                                        Dim picture As Image
                                        picture = pdpic.Image
                                        con.Open()
                                        Dim cmd01 As New SqlCommand
                                        cmd01.Connection = con
                                        cmd01.CommandText = "update staff set PHOTO=(@MyImage) where RFID=('" + pdrfid.Text + "')"
                                        Using stream As New IO.MemoryStream
                                            picture.Save(stream, Imaging.ImageFormat.Jpeg)
                                            cmd01.Parameters.Add("@MyImage", SqlDbType.Image).Value = stream.GetBuffer
                                            Debug.WriteLine(cmd01.ExecuteNonQuery())
                                            con.Close()
                                        End Using
                                        MsgBox("Photo updated Successfully", MsgBoxStyle.Information, "Success")
                                        pdcollection()
                                    Catch ex As Exception
                                        Label19.Text = "Please select a different image"
                                        Label19.ForeColor = Color.Red
                                        con.Close()
                                        pdcollection()
                                    End Try
                                Else
                                    Label19.Text = "Please enter valid email address"
                                    Label19.ForeColor = Color.Red
                                End If
                            Else
                                Label19.Text = "phone number and alternate phone number shall not be same"
                                Label19.ForeColor = Color.Red
                            End If
                        Else
                            Label19.Text = "Please enter valid phone number"
                            Label19.ForeColor = Color.Red
                        End If
                    Else
                        Label19.Text = "Please enter a valid AADHAAR number"
                        Label19.ForeColor = Color.Red
                    End If
                Else
                    Label19.Text = "Please enter a valid pincode number"
                    Label19.ForeColor = Color.Red
                End If
            Else
                Label19.Text = "Please enter all the information"
                Label19.ForeColor = Color.Red
            End If
        End If
    End Function
    Function pdrlf()



    End Function
    Function picpd()
        Try
            Dim picture1 As Image = Nothing
            con.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            Dim path As String = OpenFileDialog1.FileName
            cmd.CommandText = "select PHOTO from Staff where RFID=('" + pdrfid.Text + "')"
            Dim pictureData As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
            con.Close()
            Using stream As New IO.MemoryStream(pictureData)
                picture1 = Image.FromStream(stream)
            End Using
            pdpic.Image = picture1
            pdpic.SizeMode = PictureBoxSizeMode.StretchImage
            Return picture1
        Catch ex As Exception
            con.Close()
        End Try
    End Function
    Function datacheck2()
        If buttonhp.Location = Director.Location Or buttonhp.Location = Principal.Location Then
            Try
                Dim r As String
                con.Open()
                Dim cmd3 As New SqlCommand
                cmd3.Connection = con
                cmd3.CommandText = "select * from students where RFID=('" + pdrfid.Text + "')"
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
        ElseIf buttonhp.Location = HOD.Location Or buttonhp.Location = Lecturer.Location Then
            Try
                Dim r As String
                con.Open()
                Dim cmd3 As New SqlCommand
                cmd3.Connection = con
                cmd3.CommandText = "select * from students where RFID=('" + hlrfid.Text + "')"
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
        ElseIf buttonhp.Location = Accountant.Location Or buttonhp.Location = Librarian.Location Then
            Try
                Dim r As String
                con.Open()
                Dim cmd3 As New SqlCommand
                cmd3.Connection = con
                cmd3.CommandText = "select * from students where RFID=('" + alrfid.Text + "')"
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
        End If

    End Function

    Private Sub Buttonadd_Click_1(sender As Object, e As EventArgs) Handles Buttonadd.Click
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        If buttonhp.Location = Director.Location Or buttonhp.Location = Principal.Location Then
            If datacheck2() = 0 Then
                adddp()
            Else
                Label19.Text = "RFID is alredy assigned for a student"
                Label19.ForeColor = Color.Red
            End If

        ElseIf buttonhp.Location = HOD.Location Or buttonhp.Location = Lecturer.Location Then
            If datacheck2() = 0 Then
                addhl()
            Else
                Label19.Text = "RFID is alredy assigned for a student"
                Label19.ForeColor = Color.Red
            End If

        ElseIf buttonhp.Location = Accountant.Location Or buttonhp.Location = Librarian.Location Then
            If datacheck2() = 0 Then
                addal()
            Else
                Label19.Text = "RFID is alredy assigned for a student"
                Label19.ForeColor = Color.Red
            End If
        Else
            Label19.Text = ""
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub pdrfid_TextChanged(sender As Object, e As EventArgs) Handles pdrfid.TextChanged
        Buttonadd.Enabled = True
        pdname.Clear()
        pdaddr.Clear()
        pdpincode.Clear()
        pdaadhar.Clear()
        pdphone.Clear()
        pdaltphone.Clear()
        pdemail.Clear()
        pdgender.Clear()
        pdsub1.Clear()
        pdsub2.Clear()
        pddateofj.Clear()
        pdpic.Image = Nothing
        GC.Collect()
        ComboBox1.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        Label19.Text = ""
        pdpicupdate.Visible = False
        Buttonadd.Enabled = True
    End Sub

    Private Sub Principal_Click(sender As Object, e As EventArgs) Handles Principal.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        principalchair.Show()
        hodlec.Show()
        accountantlibr.Hide()
        Panelmenu.Enabled = True
        clearhl()
        clearalp()
        ' clearpd()
        Me.ActiveControl = pdrfid
    End Sub

    Private Sub pdrfid_LostFocus(sender As Object, e As EventArgs) Handles pdrfid.LostFocus

    End Sub

    Private Sub Buttondlt_Click(sender As Object, e As EventArgs) Handles Buttondlt.Click
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        If buttonhp.Location = Director.Location Or buttonhp.Location = Principal.Location Then
            dltpd()
        ElseIf buttonhp.Location = HOD.Location Or buttonhp.Location = Lecturer.Location Then
            dlthl()
        ElseIf buttonhp.Location = Accountant.Location Or buttonhp.Location = Librarian.Location Then
            dltal()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Buttonmod_Click(sender As Object, e As EventArgs) Handles Buttonmod.Click
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        If buttonhp.Location = Director.Location Or buttonhp.Location = Principal.Location Then
            updatedptxt()
        ElseIf buttonhp.Location = HOD.Location Or buttonhp.Location = Lecturer.Location Then
            uphltxt()
        ElseIf buttonhp.Location = Accountant.Location Or buttonhp.Location = Librarian.Location Then
            updaltxt()
        End If
        Cursor = Cursors.Default
    End Sub
    Function hlmailt()
        Try
            Dim testAddress = New MailAddress(hlemail.Text)
        Catch ex As FormatException
            Return 1
        End Try
    End Function
    Function iflec()
        If buttonhp.Location = Lecturer.Location Then
            If (hlsub1.Text <> "" Or hlsub2.Text <> "") Then
                Return 0
            Else
                Return 1
            End If
        End If
    End Function
    Function hlcollection()
        Try
            con.Open()
            Dim cmd45 As New SqlCommand
            cmd45.Connection = con
            cmd45.CommandText = "Select RFID from Staff"
            cmd45.CommandType = CommandType.Text
            Dim sdr As SqlDataReader = cmd45.ExecuteReader()
            sdr.Read()
            Dim list As New AutoCompleteStringCollection
            While sdr.Read()
                list.Add(sdr("RFID").ToString())
            End While
            hlrfid.AutoCompleteCustomSource = list
            alrfid.AutoCompleteCustomSource = list
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
    End Function
    Function addhl()
        If buttonhp.Location = HOD.Location Or buttonhp.Location = Lecturer.Location Then
            If hlrfid.Text.Trim <> "" And hlname.Text.Trim <> "" And hladdr.Text.Trim <> "" And hlpin.Text.Trim <> "" And hlaadhaar.Text.Trim <> "" And hlphoneno.Text.Trim <> "" And hlaltphone.Text.Trim <> "" And hlemail.Text.Trim <> "" And hlgender.Text.Trim <> "" And hldateofjoining.Text.Trim <> "" And hldepart.Text.Trim <> "" And hlpic.Image IsNot Nothing Then
                If hlpin.TextLength = 6 Then
                    If hlaadhaar.TextLength = 12 And (hlaadhaar.Text.StartsWith("2") Or hlaadhaar.Text.StartsWith("3") Or hlaadhaar.Text.StartsWith("4") Or hlaadhaar.Text.StartsWith("5") Or hlaadhaar.Text.StartsWith("6") Or hlaadhaar.Text.StartsWith("7") Or hlaadhaar.Text.StartsWith("8") Or hlaadhaar.Text.StartsWith("9")) Then
                        If hlphoneno.TextLength = 10 And hlaltphone.TextLength = 10 Then
                            If hlphoneno.Text <> hlaltphone.Text Then
                                If hlmailt() <> 1 Then
                                    If iflec() <> 1 Then
                                        Try
                                            Dim picture As Image = hlpic.Image
                                            con.Open()
                                            Dim cmd01 As New SqlCommand
                                            cmd01.Connection = con
                                            cmd01.CommandText = "insert into staff(RFID,NAME,ADDRESS,pincode,AADHAAR,PHONENO,ALTPHONE,EMAIL,GENDER,SUB1,SUB2,DATEOFJOINING,PHOTO,POST,DEPARTMENT) values('" + hlrfid.Text + "','" + hlname.Text + "','" + hladdr.Text + "','" + hlpin.Text + "','" + hlaadhaar.Text + "','" + hlphoneno.Text + "','" + hlaltphone.Text + "','" + hlemail.Text + "','" + hlgender.Text + "','" + hlsub1.Text + "','" + hlsub2.Text + "','" + hldateofjoining.Text + "',@MyImage,'" + currbtn.Text.Trim + "','" + hldepart.Text.Trim + "')"
                                            Using stream As New IO.MemoryStream
                                                picture.Save(stream, Imaging.ImageFormat.Jpeg)
                                                cmd01.Parameters.Add("@MyImage", SqlDbType.Image).Value = stream.GetBuffer
                                                Debug.WriteLine(cmd01.ExecuteNonQuery())
                                                con.Close()
                                            End Using
                                            MsgBox("Values added Successfully", MsgBoxStyle.Information, "Success")
                                            clearhl()
                                            hlcollection()
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                            con.Close()
                                        End Try
                                    Else
                                        Label19.Text = "lecturer should teach atleast one subject"
                                        Label19.ForeColor = Color.Red
                                    End If
                                Else
                                    Label19.Text = "Please enter valid email address"
                                    Label19.ForeColor = Color.Red
                                End If
                            Else
                                Label19.Text = "phone number and alternate phone number shall not be same"
                                Label19.ForeColor = Color.Red
                            End If
                        Else
                            Label19.Text = "Please enter valid phone number"
                            Label19.ForeColor = Color.Red
                        End If
                    Else
                        Label19.Text = "Please enter a valid AADHAAR number"
                        Label19.ForeColor = Color.Red
                    End If
                Else
                    Label19.Text = "Please enter a valid pincode number"
                    Label19.ForeColor = Color.Red
                End If
            Else
                Label19.Text = "Please enter all the information"
                Label19.ForeColor = Color.Red
            End If
        End If
    End Function
    Function uphltxt()
        If buttonhp.Location = HOD.Location Or buttonhp.Location = Lecturer.Location Then
            If hlrfid.Text.Trim <> "" And hlname.Text.Trim <> "" And hladdr.Text.Trim <> "" And hlpin.Text.Trim <> "" And hlaadhaar.Text.Trim <> "" And hlphoneno.Text.Trim <> "" And hlaltphone.Text.Trim <> "" And hlemail.Text.Trim <> "" And hlgender.Text.Trim <> "" And hldateofjoining.Text.Trim <> "" And hldepart.Text.Trim <> "" And hlpic.Image IsNot Nothing Then
                If hlpin.TextLength = 6 Then
                    If hlaadhaar.TextLength = 12 And (hlaadhaar.Text.StartsWith("2") Or hlaadhaar.Text.StartsWith("3") Or hlaadhaar.Text.StartsWith("4") Or hlaadhaar.Text.StartsWith("5") Or hlaadhaar.Text.StartsWith("6") Or hlaadhaar.Text.StartsWith("7") Or hlaadhaar.Text.StartsWith("8") Or hlaadhaar.Text.StartsWith("9")) Then
                        If hlphoneno.TextLength = 10 And hlaltphone.TextLength = 10 Then
                            If hlphoneno.Text <> hlaltphone.Text Then
                                If hlmailt() <> 1 Then
                                    If iflec() <> 1 Then
                                        Try
                                            con.Open()
                                            Dim cmd01 As New SqlCommand
                                            cmd01.Connection = con
                                            cmd01.CommandText = "update staff set NAME=('" + hlname.Text + "'),ADDRESS=('" + hladdr.Text + "'),pincode=('" + hlpin.Text + "'),AADHAAR=('" + hlaadhaar.Text + "'),PHONENO=('" + hlphoneno.Text + "'),ALTPHONE=('" + hlaltphone.Text + "'),EMAIL=('" + hlemail.Text + "'),GENDER=('" + hlgender.Text + "'),SUB1=('" + hlsub1.Text + "'),SUB2=('" + hlsub2.Text + "'),DATEOFJOINING=('" + hldateofjoining.Text + "'),DEPARTMENT=('" + hldepart.Text + "') where RFID=('" + hlrfid.Text + "')"
                                            cmd01.ExecuteNonQuery()
                                            con.Close()
                                            MsgBox("Values modified Successfully", MsgBoxStyle.Information, "Success")
                                            clearhl()
                                            hlcollection()
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                            con.Close()
                                        End Try
                                    Else
                                        Label19.Text = "lecturer should teach atleast one subject"
                                        Label19.ForeColor = Color.Red
                                    End If
                                Else
                                    Label19.Text = "Please enter valid email address"
                                    Label19.ForeColor = Color.Red
                                End If
                            Else
                                Label19.Text = "phone number and alternate phone number shall not be same"
                                Label19.ForeColor = Color.Red
                            End If
                        Else
                            Label19.Text = "Please enter valid phone number"
                            Label19.ForeColor = Color.Red
                        End If
                    Else
                        Label19.Text = "Please enter a valid AADHAAR number"
                        Label19.ForeColor = Color.Red
                    End If
                Else
                    Label19.Text = "Please enter a valid pincode number"
                    Label19.ForeColor = Color.Red
                End If
            Else
                Label19.Text = "Please enter all the information"
                Label19.ForeColor = Color.Red
            End If
        End If
    End Function
    Function updhlpic()
        If buttonhp.Location = HOD.Location Or buttonhp.Location = Lecturer.Location Then
            If hlrfid.Text.Trim <> "" And hlname.Text.Trim <> "" And hladdr.Text.Trim <> "" And hlpin.Text.Trim <> "" And hlaadhaar.Text.Trim <> "" And hlphoneno.Text.Trim <> "" And hlaltphone.Text.Trim <> "" And hlemail.Text.Trim <> "" And hlgender.Text.Trim <> "" And hldateofjoining.Text.Trim <> "" And hldepart.Text.Trim <> "" And hlpic.Image IsNot Nothing Then
                If hlpin.TextLength = 6 Then
                    If hlaadhaar.TextLength = 12 And (hlaadhaar.Text.StartsWith("2") Or hlaadhaar.Text.StartsWith("3") Or hlaadhaar.Text.StartsWith("4") Or hlaadhaar.Text.StartsWith("5") Or hlaadhaar.Text.StartsWith("6") Or hlaadhaar.Text.StartsWith("7") Or hlaadhaar.Text.StartsWith("8") Or hlaadhaar.Text.StartsWith("9")) Then
                        If hlphoneno.TextLength = 10 And hlaltphone.TextLength = 10 Then
                            If hlphoneno.Text <> hlaltphone.Text Then
                                If hlmailt() <> 1 Then
                                    If iflec() <> 1 Then
                                        Try
                                            Dim picture As Image
                                            picture = hlpic.Image
                                            con.Open()
                                            Dim cmd01 As New SqlCommand
                                            cmd01.Connection = con
                                            cmd01.CommandText = "update staff set PHOTO=(@MyImage) where RFID=('" + hlrfid.Text + "')"
                                            Using stream As New IO.MemoryStream
                                                picture.Save(stream, Imaging.ImageFormat.Jpeg)
                                                cmd01.Parameters.Add("@MyImage", SqlDbType.Image).Value = stream.GetBuffer
                                                Debug.WriteLine(cmd01.ExecuteNonQuery())
                                                con.Close()
                                            End Using
                                            MsgBox("Photo updated Successfully", MsgBoxStyle.Information, "Success")
                                            hlcollection()
                                        Catch ex As Exception
                                            Label19.Text = "Please select a different image"
                                            Label19.ForeColor = Color.Red
                                            con.Close()
                                            pdcollection()
                                        End Try
                                    Else
                                        Label19.Text = "lecturer should teach atleast one subject"
                                        Label19.ForeColor = Color.Red
                                    End If
                                Else
                                    Label19.Text = "Please enter valid email address"
                                    Label19.ForeColor = Color.Red
                                End If
                            Else
                                Label19.Text = "phone number and alternate phone number shall not be same"
                                Label19.ForeColor = Color.Red
                            End If
                        Else
                            Label19.Text = "Please enter valid phone number"
                            Label19.ForeColor = Color.Red
                        End If
                    Else
                        Label19.Text = "Please enter a valid AADHAAR number"
                        Label19.ForeColor = Color.Red
                    End If
                Else
                    Label19.Text = "Please enter a valid pincode number"
                    Label19.ForeColor = Color.Red
                End If
            Else
                Label19.Text = "Please enter all the information "
                Label19.ForeColor = Color.Red
            End If
        End If
    End Function
    Function dlthl()
        If buttonhp.Location = HOD.Location Or buttonhp.Location = Lecturer.Location Then
            If hlrfid.Text <> "" Then
                Dim ans As Integer
                ans = MsgBox("Are you sure you want to delete?", vbOKCancel, "?")
                If ans = vbOK Then
                    Try
                        con.Open()
                        Dim cmd02 As New SqlCommand
                        cmd02.Connection = con
                        cmd02.CommandText = "delete from staff where ('" + hlrfid.Text + "')=RFID"
                        cmd02.ExecuteNonQuery()
                        Label19.Text = "Values Deleted from database successfully"
                        Label19.ForeColor = Color.Green
                        con.Close()
                        clearhl()
                        hlcollection()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        con.Close()
                        hlcollection()
                    End Try

                ElseIf ans = vbCancel Then
                    Label19.Text = "Cancelled"
                    Label19.ForeColor = Color.Green
                End If
            Else
                Label19.Text = "Select the RFID that is to be deleted"
                Label19.ForeColor = Color.Red
            End If
        End If
    End Function

    Private Sub hlrfid_TextChanged(sender As Object, e As EventArgs) Handles hlrfid.TextChanged
        hlname.Clear()
        hladdr.Clear()
        hlpin.Clear()
        hlaadhaar.Clear()
        hlphoneno.Clear()
        hlaltphone.Clear()
        hlemail.Clear()
        hlgender.Clear()
        hlsub1.Clear()
        hlsub2.Clear()
        hldateofjoining.Clear()
        hldepart.Clear()
        hlpic.Image = Nothing
        GC.Collect()
        gender.Text = ""
        sem.Text = ""
        course.Text = ""
        sub2.Text = ""
        Label19.Text = ""
        hlupdateimage.Visible = False
        Buttonadd.Enabled = True
    End Sub
    Function hlrlf()


    End Function
    Function pichl()
        Try
            Dim picture1 As Image = Nothing
            con.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            Dim path As String = OpenFileDialog1.FileName
            cmd.CommandText = "select PHOTO from Staff where RFID=('" + hlrfid.Text + "')"
            Dim pictureData As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
            con.Close()
            Using stream As New IO.MemoryStream(pictureData)
                picture1 = Image.FromStream(stream)
            End Using
            hlpic.Image = picture1
            hlpic.SizeMode = PictureBoxSizeMode.StretchImage
            Return picture1
        Catch ex As Exception
            con.Close()
        End Try
    End Function

    Private Sub hlrfid_LostFocus(sender As Object, e As EventArgs) Handles hlrfid.LostFocus

    End Sub
    Function almailt()
        Try
            Dim testAddress = New MailAddress(alemail.Text)
        Catch ex As FormatException
            Return 1
        End Try
    End Function
    Function addal()
        If buttonhp.Location = Accountant.Location Or buttonhp.Location = Librarian.Location Then
            If alrfid.Text.Trim <> "" And alname.Text.Trim <> "" And aladdr.Text.Trim <> "" And alpin.Text.Trim <> "" And alaadhaar.Text.Trim <> "" And alphn.Text.Trim <> "" And alaltphn.Text.Trim <> "" And alemail.Text.Trim <> "" And algender.Text.Trim <> "" And aldateofj.Text.Trim <> "" And alpic.Image IsNot Nothing Then
                If alpin.TextLength = 6 Then
                    If alaadhaar.TextLength = 12 And (alaadhaar.Text.StartsWith("2") Or alaadhaar.Text.StartsWith("3") Or alaadhaar.Text.StartsWith("4") Or alaadhaar.Text.StartsWith("5") Or alaadhaar.Text.StartsWith("6") Or alaadhaar.Text.StartsWith("7") Or alaadhaar.Text.StartsWith("8") Or alaadhaar.Text.StartsWith("9")) Then
                        If alphn.TextLength = 10 And alaltphn.TextLength = 10 Then
                            If alphn.Text <> alaltphn.Text Then
                                If almailt() <> 1 Then
                                    Try
                                        Dim picture As Image = alpic.Image
                                        con.Open()
                                        Dim cmd01 As New SqlCommand
                                        cmd01.Connection = con
                                        cmd01.CommandText = "insert into staff(RFID,NAME,ADDRESS,pincode,AADHAAR,PHONENO,ALTPHONE,EMAIL,GENDER,DATEOFJOINING,PHOTO,POST) values('" + alrfid.Text + "','" + alname.Text + "','" + aladdr.Text + "','" + alpin.Text + "','" + alaadhaar.Text + "','" + alphn.Text + "','" + alaltphn.Text + "','" + alemail.Text + "','" + algender.Text + "','" + aldateofj.Text + "',@MyImage,'" + currbtn.Text.Trim + "')"
                                        Using stream As New IO.MemoryStream
                                            picture.Save(stream, Imaging.ImageFormat.Jpeg)
                                            cmd01.Parameters.Add("@MyImage", SqlDbType.Image).Value = stream.GetBuffer
                                            Debug.WriteLine(cmd01.ExecuteNonQuery())
                                            con.Close()
                                        End Using
                                        MsgBox("Values added Successfully", MsgBoxStyle.Information, "Success")
                                        clearalp()
                                        hlcollection()
                                    Catch ex As Exception
                                        MsgBox(ex.Message)
                                        con.Close()
                                    End Try
                                Else
                                    Label19.Text = "Please enter valid email address"
                                    Label19.ForeColor = Color.Red
                                End If
                            Else
                                Label19.Text = "phone number and alternate phone number shall not be same"
                                Label19.ForeColor = Color.Red
                            End If
                        Else
                            Label19.Text = "Please enter valid phone number"
                            Label19.ForeColor = Color.Red
                        End If
                    Else
                        Label19.Text = "Please enter a valid AADHAAR number"
                        Label19.ForeColor = Color.Red
                    End If
                Else
                    Label19.Text = "Please enter a valid pincode number"
                    Label19.ForeColor = Color.Red
                End If
            Else
                Label19.Text = "Please enter all the information"
                Label19.ForeColor = Color.Red
            End If
        End If
    End Function
    Function updaltxt()
        If buttonhp.Location = Accountant.Location Or buttonhp.Location = Librarian.Location Then
            If alrfid.Text.Trim <> "" And alname.Text.Trim <> "" And aladdr.Text.Trim <> "" And alpin.Text.Trim <> "" And alaadhaar.Text.Trim <> "" And alphn.Text.Trim <> "" And alaltphn.Text.Trim <> "" And alemail.Text.Trim <> "" And algender.Text.Trim <> "" And aldateofj.Text.Trim <> "" And alpic.Image IsNot Nothing Then
                If alpin.TextLength = 6 Then
                    If alaadhaar.TextLength = 12 And (alaadhaar.Text.StartsWith("2") Or alaadhaar.Text.StartsWith("3") Or alaadhaar.Text.StartsWith("4") Or alaadhaar.Text.StartsWith("5") Or alaadhaar.Text.StartsWith("6") Or alaadhaar.Text.StartsWith("7") Or alaadhaar.Text.StartsWith("8") Or alaadhaar.Text.StartsWith("9")) Then
                        If alphn.TextLength = 10 And alaltphn.TextLength = 10 Then
                            If alphn.Text <> alaltphn.Text Then
                                If almailt() <> 1 Then
                                    Try
                                        Dim picture As Image = alpic.Image
                                        con.Open()
                                        Dim cmd01 As New SqlCommand
                                        cmd01.Connection = con
                                        cmd01.CommandText = "update staff set NAME=('" + alname.Text + "'),ADDRESS=('" + aladdr.Text + "'),pincode=('" + alpin.Text + "'),AADHAAR=('" + alaadhaar.Text + "'),PHONENO=('" + alphn.Text + "'),ALTPHONE=('" + alaltphn.Text + "'),EMAIL=('" + alemail.Text + "'),GENDER=('" + algender.Text + "'),DATEOFJOINING=('" + aldateofj.Text + "') where RFID=('" + alrfid.Text + "')"
                                        cmd01.ExecuteNonQuery()
                                        MsgBox("Values updated Successfully", MsgBoxStyle.Information, "Success")
                                        clearalp()
                                        hlcollection()
                                    Catch ex As Exception
                                        MsgBox(ex.Message)
                                        con.Close()
                                    End Try
                                Else
                                    Label19.Text = "Please enter valid email address"
                                    Label19.ForeColor = Color.Red
                                End If
                            Else
                                Label19.Text = "phone number and alternate phone number shall not be same"
                                Label19.ForeColor = Color.Red
                            End If
                        Else
                            Label19.Text = "Please enter valid phone number"
                            Label19.ForeColor = Color.Red
                        End If
                    Else
                        Label19.Text = "Please enter a valid AADHAAR number"
                        Label19.ForeColor = Color.Red
                    End If
                Else
                    Label19.Text = "Please enter a valid pincode number"
                    Label19.ForeColor = Color.Red
                End If
            Else
                Label19.Text = "Please enter all the information"
                Label19.ForeColor = Color.Red
            End If
        End If
    End Function
    Function updalpic()
        If buttonhp.Location = Accountant.Location Or buttonhp.Location = Librarian.Location Then
            If alrfid.Text.Trim <> "" And alname.Text.Trim <> "" And aladdr.Text.Trim <> "" And alpin.Text.Trim <> "" And alaadhaar.Text.Trim <> "" And alphn.Text.Trim <> "" And alaltphn.Text.Trim <> "" And alemail.Text.Trim <> "" And algender.Text.Trim <> "" And aldateofj.Text.Trim <> "" And alpic.Image IsNot Nothing Then
                If alpin.TextLength = 6 Then
                    If alaadhaar.TextLength = 12 And (alaadhaar.Text.StartsWith("2") Or alaadhaar.Text.StartsWith("3") Or alaadhaar.Text.StartsWith("4") Or alaadhaar.Text.StartsWith("5") Or alaadhaar.Text.StartsWith("6") Or alaadhaar.Text.StartsWith("7") Or alaadhaar.Text.StartsWith("8") Or alaadhaar.Text.StartsWith("9")) Then
                        If alphn.TextLength = 10 And alaltphn.TextLength = 10 Then
                            If alphn.Text <> alaltphn.Text Then
                                If almailt() <> 1 Then
                                    Try
                                        Dim picture As Image
                                        picture = alpic.Image
                                        con.Open()
                                        Dim cmd01 As New SqlCommand
                                        cmd01.Connection = con
                                        cmd01.CommandText = "update staff set PHOTO=(@MyImage) where RFID=('" + alrfid.Text + "')"
                                        Using stream As New IO.MemoryStream
                                            picture.Save(stream, Imaging.ImageFormat.Jpeg)
                                            cmd01.Parameters.Add("@MyImage", SqlDbType.Image).Value = stream.GetBuffer
                                            Debug.WriteLine(cmd01.ExecuteNonQuery())
                                            con.Close()
                                        End Using
                                        MsgBox("Photo updated Successfully", MsgBoxStyle.Information, "Success")
                                        hlcollection()
                                    Catch ex As Exception
                                        Label19.Text = "Please select a different image"
                                        Label19.ForeColor = Color.Red
                                        con.Close()
                                        pdcollection()
                                    End Try
                                Else
                                    Label19.Text = "Please enter valid email address"
                                    Label19.ForeColor = Color.Red
                                End If
                            Else
                                Label19.Text = "phone number and alternate phone number shall not be same"
                                Label19.ForeColor = Color.Red
                            End If
                        Else
                            Label19.Text = "Please enter valid phone number"
                            Label19.ForeColor = Color.Red
                        End If
                    Else
                        Label19.Text = "Please enter a valid AADHAAR number"
                        Label19.ForeColor = Color.Red
                    End If
                Else
                    Label19.Text = "Please enter a valid pincode number"
                    Label19.ForeColor = Color.Red
                End If
            Else
                Label19.Text = "Please enter all the information"
                Label19.ForeColor = Color.Red
            End If
        End If
    End Function
    Function dltal()
        If buttonhp.Location = Accountant.Location Or buttonhp.Location = Librarian.Location Then
            If alrfid.Text <> "" Then
                Dim ans As Integer
                ans = MsgBox("Are you sure you want to delete?", vbOKCancel, "?")
                If ans = vbOK Then
                    Try
                        con.Open()
                        Dim cmd02 As New SqlCommand
                        cmd02.Connection = con
                        cmd02.CommandText = "delete from staff where ('" + alrfid.Text + "')=RFID"
                        cmd02.ExecuteNonQuery()
                        Label19.Text = "Values Deleted from database successfully"
                        Label19.ForeColor = Color.Green
                        con.Close()
                        clearalp()
                        hlcollection()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        con.Close()
                        hlcollection()
                    End Try

                ElseIf ans = vbCancel Then
                    Label19.Text = "Cancelled"
                    Label19.ForeColor = Color.Green
                End If
            Else
                Label19.Text = "Select the RFID that is to be deleted"
                Label19.ForeColor = Color.Red
            End If
        End If
    End Function

    Private Sub alrfid_TextChanged(sender As Object, e As EventArgs) Handles alrfid.TextChanged
        alname.Clear()
        aladdr.Clear()
        alpin.Clear()
        alaadhaar.Clear()
        alphn.Clear()
        alaltphn.Clear()
        alemail.Clear()
        algender.Clear()
        aldateofj.Clear()
        alpic.Image = Nothing
        GC.Collect()
        ComboBox5.Text = ""
        Label19.Text = ""
        alpicupdate.Visible = False
        Buttonadd.Enabled = True
    End Sub
    Function performclk()
        If buttonhp.Location = Director.Location Or buttonhp.Location = Principal.Location Then
            Try
                Dim cb As String
                con.Open()
                Dim cmd3 As New SqlCommand
                cmd3.Connection = con
                cmd3.CommandText = "select POST from Staff where RFID=('" + pdrfid.Text + "')"
                cmd3.CommandType = CommandType.Text
                Dim sdr As SqlDataReader = cmd3.ExecuteReader
                sdr.Read()
                cb = sdr("POST").ToString.Trim
                con.Close()
                If cb = "Director" Then
                    Director.PerformClick()
                    pdrfid.SelectionLength = 0
                    Try
                        'Dim cb1 As String
                        con.Open()
                        Dim cmd31 As New SqlCommand
                        cmd31.Connection = con
                        cmd31.CommandText = "select * from Staff where RFID=('" + pdrfid.Text + "')"
                        cmd31.CommandType = CommandType.Text
                        Dim sdr1 As SqlDataReader = cmd31.ExecuteReader
                        sdr1.Read()
                        pdname.Text = sdr1("NAME").ToString.Trim
                        pdaddr.Text = sdr1("ADDRESS").ToString.Trim
                        pdpincode.Text = sdr1("PINCODE").ToString.Trim
                        pdaadhar.Text = sdr1("AADHAAR").ToString.Trim
                        pdphone.Text = sdr1("PHONENO").ToString.Trim
                        pdaltphone.Text = sdr1("ALTPHONE").ToString.Trim
                        pdsub1.Text = sdr1("SUB1").ToString.Trim
                        pdsub2.Text = sdr1("SUB2").ToString.Trim
                        pdgender.Text = sdr1("GENDER").ToString.Trim
                        pddateofj.Text = sdr1("DATEOFJOINING").ToString.Trim
                        DateTimePicker1.Value = pddateofj.Text
                        pdemail.Text = sdr1("EMAIL").ToString.Trim
                        con.Close()
                        picpd()
                        pdpicupdate.Visible = True
                    Catch ex As Exception
                        con.Close()
                    End Try
                ElseIf cb = "Principal" Then
                    Principal.PerformClick()
                    Try
                        'Dim cb2 As String
                        con.Open()
                        Dim cmd32 As New SqlCommand
                        cmd32.Connection = con
                        cmd32.CommandText = "select * from Staff where RFID=('" + pdrfid.Text + "')"
                        cmd32.CommandType = CommandType.Text
                        Dim sdr2 As SqlDataReader = cmd32.ExecuteReader
                        sdr2.Read()
                        pdname.Text = sdr2("NAME").ToString.Trim
                        pdaddr.Text = sdr2("ADDRESS").ToString.Trim
                        pdpincode.Text = sdr2("PINCODE").ToString.Trim
                        pdaadhar.Text = sdr2("AADHAAR").ToString.Trim
                        pdphone.Text = sdr2("PHONENO").ToString.Trim
                        pdaltphone.Text = sdr2("ALTPHONE").ToString.Trim
                        pdsub1.Text = sdr2("SUB1").ToString.Trim
                        pdsub2.Text = sdr2("SUB2").ToString.Trim
                        pdgender.Text = sdr2("GENDER").ToString.Trim
                        pddateofj.Text = sdr2("DATEOFJOINING").ToString.Trim
                        DateTimePicker1.Value = pddateofj.Text
                        pdemail.Text = sdr2("EMAIL").ToString.Trim
                        con.Close()
                        picpd()
                        pdpicupdate.Visible = True
                    Catch ex As Exception
                        con.Close()
                    End Try
                ElseIf cb = "HOD" Then
                    HOD.PerformClick()
                    Try
                        'Dim cb3 As String
                        con.Open()
                        Dim cmd33 As New SqlCommand
                        cmd33.Connection = con
                        cmd33.CommandText = "select * from Staff where RFID=('" + hlrfid.Text + "')"
                        cmd33.CommandType = CommandType.Text
                        Dim sdr33 As SqlDataReader = cmd33.ExecuteReader
                        sdr33.Read()
                        hlname.Text = sdr33("NAME").ToString.Trim
                        hladdr.Text = sdr33("ADDRESS").ToString.Trim
                        hlpin.Text = sdr33("PINCODE").ToString.Trim
                        hlaadhaar.Text = sdr33("AADHAAR").ToString.Trim
                        hlphoneno.Text = sdr33("PHONENO").ToString.Trim
                        hlaltphone.Text = sdr33("ALTPHONE").ToString.Trim
                        hlsub1.Text = sdr33("SUB1").ToString.Trim
                        hlsub2.Text = sdr33("SUB2").ToString.Trim
                        hldepart.Text = sdr33("DEPARTMENT").ToString.Trim
                        hlgender.Text = sdr33("GENDER").ToString.Trim
                        hldateofjoining.Text = sdr33("DATEOFJOINING").ToString.Trim
                        DateTimePicker2.Value = hldateofjoining.Text
                        hlemail.Text = sdr33("EMAIL").ToString.Trim
                        con.Close()
                        pichl()
                        hlupdateimage.Visible = True
                    Catch ex As Exception
                        con.Close()
                    End Try

                ElseIf cb = "Lecturer" Then
                    Lecturer.PerformClick()
                    Try
                        'Dim cb4 As String
                        con.Open()
                        Dim cmd34 As New SqlCommand
                        cmd34.Connection = con
                        cmd34.CommandText = "select * from Staff where RFID=('" + hlrfid.Text + "')"
                        cmd34.CommandType = CommandType.Text
                        Dim sdr4 As SqlDataReader = cmd34.ExecuteReader
                        sdr4.Read()
                        hlname.Text = sdr4("NAME").ToString.Trim
                        hladdr.Text = sdr4("ADDRESS").ToString.Trim
                        hlpin.Text = sdr4("PINCODE").ToString.Trim
                        hlaadhaar.Text = sdr4("AADHAAR").ToString.Trim
                        hlphoneno.Text = sdr4("PHONENO").ToString.Trim
                        hlaltphone.Text = sdr4("ALTPHONE").ToString.Trim
                        hlsub1.Text = sdr4("SUB1").ToString.Trim
                        hlsub2.Text = sdr4("SUB2").ToString.Trim
                        hldepart.Text = sdr4("DEPARTMENT").ToString.Trim
                        hlgender.Text = sdr4("GENDER").ToString.Trim
                        hldateofjoining.Text = sdr4("DATEOFJOINING").ToString.Trim
                        DateTimePicker2.Value = hldateofjoining.Text
                        hlemail.Text = sdr4("EMAIL").ToString.Trim
                        con.Close()
                        pichl()
                        hlupdateimage.Visible = True
                    Catch ex As Exception
                        con.Close()
                    End Try

                ElseIf cb = "Librarian" Then
                    Librarian.PerformClick()
                    Try
                        'Dim cb5 As String
                        con.Open()
                        Dim cmd35 As New SqlCommand
                        cmd35.Connection = con
                        cmd35.CommandText = "select * from Staff where RFID=('" + alrfid.Text + "')"
                        cmd35.CommandType = CommandType.Text
                        Dim sdr5 As SqlDataReader = cmd35.ExecuteReader
                        sdr5.Read()
                        alname.Text = sdr5("NAME").ToString.Trim
                        aladdr.Text = sdr5("ADDRESS").ToString.Trim
                        alpin.Text = sdr5("PINCODE").ToString.Trim
                        alaadhaar.Text = sdr5("AADHAAR").ToString.Trim
                        alphn.Text = sdr5("PHONENO").ToString.Trim
                        alaltphn.Text = sdr5("ALTPHONE").ToString.Trim
                        algender.Text = sdr5("GENDER").ToString.Trim
                        aldateofj.Text = sdr5("DATEOFJOINING").ToString.Trim
                        DateTimePicker3.Value = aldateofj.Text
                        alemail.Text = sdr5("EMAIL").ToString.Trim
                        con.Close()
                        pical()
                        alpicupdate.Visible = True
                    Catch ex As Exception
                        con.Close()

                    End Try
                ElseIf cb = "Accountant" Then
                    Accountant.PerformClick()
                    Try
                        'Dim cb6 As String
                        con.Open()
                        Dim cmd36 As New SqlCommand
                        cmd36.Connection = con
                        cmd36.CommandText = "select * from Staff where RFID=('" + alrfid.Text + "')"
                        cmd36.CommandType = CommandType.Text
                        Dim sdr6 As SqlDataReader = cmd36.ExecuteReader
                        sdr6.Read()
                        alname.Text = sdr6("NAME").ToString.Trim
                        aladdr.Text = sdr6("ADDRESS").ToString.Trim
                        alpin.Text = sdr6("PINCODE").ToString.Trim
                        alaadhaar.Text = sdr6("AADHAAR").ToString.Trim
                        alphn.Text = sdr6("PHONENO").ToString.Trim
                        alaltphn.Text = sdr6("ALTPHONE").ToString.Trim
                        algender.Text = sdr6("GENDER").ToString.Trim
                        aldateofj.Text = sdr6("DATEOFJOINING").ToString.Trim
                        DateTimePicker3.Value = aldateofj.Text
                        alemail.Text = sdr6("EMAIL").ToString.Trim
                        con.Close()
                        pical()
                        alpicupdate.Visible = True
                    Catch ex As Exception
                        con.Close()

                    End Try
                End If

                alpicupdate.Visible = True
            Catch ex As Exception
                con.Close()

            End Try
        ElseIf buttonhp.Location = HOD.Location Or buttonhp.Location = Lecturer.Location Then
            Try
                Dim cb As String
                con.Open()
                Dim cmd3 As New SqlCommand
                cmd3.Connection = con
                cmd3.CommandText = "select POST from Staff where RFID=('" + hlrfid.Text + "')"
                cmd3.CommandType = CommandType.Text
                Dim sdr As SqlDataReader = cmd3.ExecuteReader
                sdr.Read()
                cb = sdr("POST").ToString.Trim
                con.Close()
                If cb = "Director" Then
                    Director.PerformClick()
                    Try
                        Dim cb12 As String
                        con.Open()
                        Dim cmd312 As New SqlCommand
                        cmd312.Connection = con
                        cmd312.CommandText = "select * from Staff where RFID=('" + pdrfid.Text + "')"
                        cmd312.CommandType = CommandType.Text
                        Dim sdr12 As SqlDataReader = cmd312.ExecuteReader
                        sdr12.Read()
                        pdname.Text = sdr12("NAME").ToString.Trim
                        pdaddr.Text = sdr12("ADDRESS").ToString.Trim
                        pdpincode.Text = sdr12("PINCODE").ToString.Trim
                        pdaadhar.Text = sdr12("AADHAAR").ToString.Trim
                        pdphone.Text = sdr12("PHONENO").ToString.Trim
                        pdaltphone.Text = sdr12("ALTPHONE").ToString.Trim
                        pdsub1.Text = sdr12("SUB1").ToString.Trim
                        pdsub2.Text = sdr12("SUB2").ToString.Trim
                        pdgender.Text = sdr12("GENDER").ToString.Trim
                        pddateofj.Text = sdr12("DATEOFJOINING").ToString.Trim
                        DateTimePicker1.Value = pddateofj.Text
                        pdemail.Text = sdr12("EMAIL").ToString.Trim
                        con.Close()
                        picpd()
                        pdpicupdate.Visible = True
                    Catch ex As Exception
                        con.Close()
                    End Try
                ElseIf cb = "Principal" Then
                    Principal.PerformClick()
                    Try
                        'Dim cb21 As String
                        con.Open()
                        Dim cmd321 As New SqlCommand
                        cmd321.Connection = con
                        cmd321.CommandText = "select * from Staff where RFID=('" + pdrfid.Text + "')"
                        cmd321.CommandType = CommandType.Text
                        Dim sdr21 As SqlDataReader = cmd321.ExecuteReader
                        sdr21.Read()
                        pdname.Text = sdr21("NAME").ToString.Trim
                        pdaddr.Text = sdr21("ADDRESS").ToString.Trim
                        pdpincode.Text = sdr21("PINCODE").ToString.Trim
                        pdaadhar.Text = sdr21("AADHAAR").ToString.Trim
                        pdphone.Text = sdr21("PHONENO").ToString.Trim
                        pdaltphone.Text = sdr21("ALTPHONE").ToString.Trim
                        pdsub1.Text = sdr21("SUB1").ToString.Trim
                        pdsub2.Text = sdr21("SUB2").ToString.Trim
                        pdgender.Text = sdr21("GENDER").ToString.Trim
                        pddateofj.Text = sdr21("DATEOFJOINING").ToString.Trim
                        DateTimePicker1.Value = pddateofj.Text
                        pdemail.Text = sdr21("EMAIL").ToString.Trim
                        con.Close()
                        picpd()
                        pdpicupdate.Visible = True
                    Catch ex As Exception
                        con.Close()
                    End Try
                ElseIf cb = "HOD" Then
                    HOD.PerformClick()
                    Try
                        ' Dim cb11 As String
                        con.Open()
                        Dim cmd311 As New SqlCommand
                        cmd311.Connection = con
                        cmd311.CommandText = "select * from Staff where RFID=('" + hlrfid.Text + "')"
                        cmd311.CommandType = CommandType.Text
                        Dim sdr311 As SqlDataReader = cmd311.ExecuteReader
                        sdr311.Read()
                        hlname.Text = sdr311("NAME").ToString.Trim
                        hladdr.Text = sdr311("ADDRESS").ToString.Trim
                        hlpin.Text = sdr311("PINCODE").ToString.Trim
                        hlaadhaar.Text = sdr311("AADHAAR").ToString.Trim
                        hlphoneno.Text = sdr311("PHONENO").ToString.Trim
                        hlaltphone.Text = sdr311("ALTPHONE").ToString.Trim
                        hlsub1.Text = sdr311("SUB1").ToString.Trim
                        hlsub2.Text = sdr311("SUB2").ToString.Trim
                        hldepart.Text = sdr311("DEPARTMENT").ToString.Trim
                        hlgender.Text = sdr311("GENDER").ToString.Trim
                        hldateofjoining.Text = sdr311("DATEOFJOINING").ToString.Trim
                        DateTimePicker2.Value = hldateofjoining.Text
                        hlemail.Text = sdr311("EMAIL").ToString.Trim
                        con.Close()
                        pichl()
                        hlupdateimage.Visible = True
                    Catch ex As Exception
                        con.Close()
                    End Try

                ElseIf cb = "Lecturer" Then
                    Lecturer.PerformClick()
                    Try
                        'Dim cb22 As String
                        con.Open()
                        Dim cmd322 As New SqlCommand
                        cmd322.Connection = con
                        cmd322.CommandText = "select * from Staff where RFID=('" + hlrfid.Text + "')"
                        cmd322.CommandType = CommandType.Text
                        Dim sdr22 As SqlDataReader = cmd322.ExecuteReader
                        sdr22.Read()
                        hlname.Text = sdr22("NAME").ToString.Trim
                        hladdr.Text = sdr22("ADDRESS").ToString.Trim
                        hlpin.Text = sdr22("PINCODE").ToString.Trim
                        hlaadhaar.Text = sdr22("AADHAAR").ToString.Trim
                        hlphoneno.Text = sdr22("PHONENO").ToString.Trim
                        hlaltphone.Text = sdr22("ALTPHONE").ToString.Trim
                        hlsub1.Text = sdr22("SUB1").ToString.Trim
                        hlsub2.Text = sdr22("SUB2").ToString.Trim
                        hldepart.Text = sdr22("DEPARTMENT").ToString.Trim
                        hlgender.Text = sdr22("GENDER").ToString.Trim
                        hldateofjoining.Text = sdr22("DATEOFJOINING").ToString.Trim
                        DateTimePicker2.Value = hldateofjoining.Text
                        hlemail.Text = sdr22("EMAIL").ToString.Trim
                        con.Close()
                        pichl()
                        hlupdateimage.Visible = True
                    Catch ex As Exception
                        con.Close()
                    End Try

                ElseIf cb = "Librarian" Then
                    Librarian.PerformClick()
                    Try
                        'Dim cb44 As String
                        con.Open()
                        Dim cmd344 As New SqlCommand
                        cmd344.Connection = con
                        cmd344.CommandText = "select * from Staff where RFID=('" + alrfid.Text + "')"
                        cmd344.CommandType = CommandType.Text
                        Dim sdr44 As SqlDataReader = cmd344.ExecuteReader
                        sdr44.Read()
                        alname.Text = sdr44("NAME").ToString.Trim
                        aladdr.Text = sdr44("ADDRESS").ToString.Trim
                        alpin.Text = sdr44("PINCODE").ToString.Trim
                        alaadhaar.Text = sdr44("AADHAAR").ToString.Trim
                        alphn.Text = sdr44("PHONENO").ToString.Trim
                        alaltphn.Text = sdr44("ALTPHONE").ToString.Trim
                        algender.Text = sdr44("GENDER").ToString.Trim
                        aldateofj.Text = sdr44("DATEOFJOINING").ToString.Trim
                        DateTimePicker3.Value = aldateofj.Text
                        alemail.Text = sdr44("EMAIL").ToString.Trim
                        con.Close()
                        pical()
                        alpicupdate.Visible = True
                    Catch ex As Exception
                        con.Close()

                    End Try
                ElseIf cb = "Accountant" Then
                    Accountant.PerformClick()
                    Try
                        ' Dim cb55 As String
                        con.Open()
                        Dim cmd355 As New SqlCommand
                        cmd355.Connection = con
                        cmd355.CommandText = "select * from Staff where RFID=('" + alrfid.Text + "')"
                        cmd355.CommandType = CommandType.Text
                        Dim sdr55 As SqlDataReader = cmd355.ExecuteReader
                        sdr55.Read()
                        alname.Text = sdr55("NAME").ToString.Trim
                        aladdr.Text = sdr55("ADDRESS").ToString.Trim
                        alpin.Text = sdr55("PINCODE").ToString.Trim
                        alaadhaar.Text = sdr55("AADHAAR").ToString.Trim
                        alphn.Text = sdr55("PHONENO").ToString.Trim
                        alaltphn.Text = sdr55("ALTPHONE").ToString.Trim
                        algender.Text = sdr55("GENDER").ToString.Trim
                        aldateofj.Text = sdr55("DATEOFJOINING").ToString.Trim
                        DateTimePicker3.Value = aldateofj.Text
                        alemail.Text = sdr55("EMAIL").ToString.Trim
                        con.Close()
                        pical()
                        alpicupdate.Visible = True
                    Catch ex As Exception
                        con.Close()

                    End Try
                End If

                alpicupdate.Visible = True
            Catch ex As Exception
                con.Close()

            End Try
        ElseIf buttonhp.Location = Accountant.Location Or buttonhp.Location = Librarian.Location Then
            Try
                Dim cb As String
                con.Open()
                Dim cmd3 As New SqlCommand
                cmd3.Connection = con
                cmd3.CommandText = "select POST from Staff where RFID=('" + alrfid.Text + "')"
                cmd3.CommandType = CommandType.Text
                Dim sdr As SqlDataReader = cmd3.ExecuteReader
                sdr.Read()
                cb = sdr("POST").ToString.Trim
                con.Close()
                If cb = "Director" Then
                    Director.PerformClick()
                    Try
                        'Dim cb66 As String
                        con.Open()
                        Dim cmd366 As New SqlCommand
                        cmd366.Connection = con
                        cmd366.CommandText = "select * from Staff where RFID=('" + pdrfid.Text + "')"
                        cmd366.CommandType = CommandType.Text
                        Dim sdr66 As SqlDataReader = cmd366.ExecuteReader
                        sdr66.Read()
                        pdname.Text = sdr66("NAME").ToString.Trim
                        pdaddr.Text = sdr66("ADDRESS").ToString.Trim
                        pdpincode.Text = sdr66("PINCODE").ToString.Trim
                        pdaadhar.Text = sdr66("AADHAAR").ToString.Trim
                        pdphone.Text = sdr66("PHONENO").ToString.Trim
                        pdaltphone.Text = sdr66("ALTPHONE").ToString.Trim
                        pdsub1.Text = sdr66("SUB1").ToString.Trim
                        pdsub2.Text = sdr66("SUB2").ToString.Trim
                        pdgender.Text = sdr66("GENDER").ToString.Trim
                        pddateofj.Text = sdr66("DATEOFJOINING").ToString.Trim
                        DateTimePicker1.Value = pddateofj.Text
                        pdemail.Text = sdr66("EMAIL").ToString.Trim
                        con.Close()
                        picpd()
                        pdpicupdate.Visible = True
                    Catch ex As Exception
                        con.Close()
                    End Try
                ElseIf cb = "Principal" Then
                    Principal.PerformClick()
                    Try
                        'Dim cb77 As String
                        con.Open()
                        Dim cmd377 As New SqlCommand
                        cmd377.Connection = con
                        cmd377.CommandText = "select * from Staff where RFID=('" + pdrfid.Text + "')"
                        cmd377.CommandType = CommandType.Text
                        Dim sdr77 As SqlDataReader = cmd377.ExecuteReader
                        sdr77.Read()
                        pdname.Text = sdr77("NAME").ToString.Trim
                        pdaddr.Text = sdr77("ADDRESS").ToString.Trim
                        pdpincode.Text = sdr77("PINCODE").ToString.Trim
                        pdaadhar.Text = sdr77("AADHAAR").ToString.Trim
                        pdphone.Text = sdr77("PHONENO").ToString.Trim
                        pdaltphone.Text = sdr77("ALTPHONE").ToString.Trim
                        pdsub1.Text = sdr77("SUB1").ToString.Trim
                        pdsub2.Text = sdr77("SUB2").ToString.Trim
                        pdgender.Text = sdr77("GENDER").ToString.Trim
                        pddateofj.Text = sdr77("DATEOFJOINING").ToString.Trim
                        DateTimePicker1.Value = pddateofj.Text
                        pdemail.Text = sdr77("EMAIL").ToString.Trim
                        con.Close()
                        picpd()
                        pdpicupdate.Visible = True
                    Catch ex As Exception
                        con.Close()
                    End Try
                ElseIf cb = "HOD" Then
                    HOD.PerformClick()
                    Try
                        'Dim cb88 As String
                        con.Open()
                        Dim cmd388 As New SqlCommand
                        cmd388.Connection = con
                        cmd388.CommandText = "select * from Staff where RFID=('" + hlrfid.Text + "')"
                        cmd388.CommandType = CommandType.Text
                        Dim sdr888 As SqlDataReader = cmd388.ExecuteReader
                        sdr888.Read()
                        hlname.Text = sdr888("NAME").ToString.Trim
                        hladdr.Text = sdr888("ADDRESS").ToString.Trim
                        hlpin.Text = sdr888("PINCODE").ToString.Trim
                        hlaadhaar.Text = sdr888("AADHAAR").ToString.Trim
                        hlphoneno.Text = sdr888("PHONENO").ToString.Trim
                        hlaltphone.Text = sdr888("ALTPHONE").ToString.Trim
                        hlsub1.Text = sdr888("SUB1").ToString.Trim
                        hlsub2.Text = sdr888("SUB2").ToString.Trim
                        hldepart.Text = sdr888("DEPARTMENT").ToString.Trim
                        hlgender.Text = sdr888("GENDER").ToString.Trim
                        hldateofjoining.Text = sdr888("DATEOFJOINING").ToString.Trim
                        DateTimePicker2.Value = hldateofjoining.Text
                        hlemail.Text = sdr888("EMAIL").ToString.Trim
                        con.Close()
                        pichl()
                        hlupdateimage.Visible = True
                    Catch ex As Exception
                        con.Close()
                    End Try

                ElseIf cb = "Lecturer" Then
                    Lecturer.PerformClick()
                    Try
                        'Dim cb99 As String
                        con.Open()
                        Dim cmd399 As New SqlCommand
                        cmd399.Connection = con
                        cmd399.CommandText = "select * from Staff where RFID=('" + hlrfid.Text + "')"
                        cmd399.CommandType = CommandType.Text
                        Dim sdr99 As SqlDataReader = cmd399.ExecuteReader
                        sdr99.Read()
                        hlname.Text = sdr99("NAME").ToString.Trim
                        hladdr.Text = sdr99("ADDRESS").ToString.Trim
                        hlpin.Text = sdr99("PINCODE").ToString.Trim
                        hlaadhaar.Text = sdr99("AADHAAR").ToString.Trim
                        hlphoneno.Text = sdr99("PHONENO").ToString.Trim
                        hlaltphone.Text = sdr99("ALTPHONE").ToString.Trim
                        hlsub1.Text = sdr99("SUB1").ToString.Trim
                        hlsub2.Text = sdr99("SUB2").ToString.Trim
                        hldepart.Text = sdr99("DEPARTMENT").ToString.Trim
                        hlgender.Text = sdr99("GENDER").ToString.Trim
                        hldateofjoining.Text = sdr99("DATEOFJOINING").ToString.Trim
                        DateTimePicker2.Value = hldateofjoining.Text
                        hlemail.Text = sdr99("EMAIL").ToString.Trim
                        con.Close()
                        pichl()
                        hlupdateimage.Visible = True
                    Catch ex As Exception
                        con.Close()
                    End Try

                ElseIf cb = "Librarian" Then
                    Librarian.PerformClick()
                    Try
                        'Dim cb333 As String
                        con.Open()
                        Dim cmd333 As New SqlCommand
                        cmd333.Connection = con
                        cmd333.CommandText = "select * from Staff where RFID=('" + alrfid.Text + "')"
                        cmd333.CommandType = CommandType.Text
                        Dim sdr333 As SqlDataReader = cmd333.ExecuteReader
                        sdr333.Read()
                        alname.Text = sdr333("NAME").ToString.Trim
                        aladdr.Text = sdr333("ADDRESS").ToString.Trim
                        alpin.Text = sdr333("PINCODE").ToString.Trim
                        alaadhaar.Text = sdr333("AADHAAR").ToString.Trim
                        alphn.Text = sdr333("PHONENO").ToString.Trim
                        alaltphn.Text = sdr333("ALTPHONE").ToString.Trim
                        algender.Text = sdr333("GENDER").ToString.Trim
                        aldateofj.Text = sdr333("DATEOFJOINING").ToString.Trim
                        DateTimePicker3.Value = aldateofj.Text
                        alemail.Text = sdr333("EMAIL").ToString.Trim
                        con.Close()
                        pical()
                        alpicupdate.Visible = True
                    Catch ex As Exception
                        con.Close()

                    End Try
                ElseIf cb = "Accountant" Then
                    Accountant.PerformClick()
                    Try
                        ' Dim cb99 As String
                        con.Open()
                        Dim cmd399 As New SqlCommand
                        cmd399.Connection = con
                        cmd399.CommandText = "select * from Staff where RFID=('" + alrfid.Text + "')"
                        cmd399.CommandType = CommandType.Text
                        Dim sdr99 As SqlDataReader = cmd399.ExecuteReader
                        sdr99.Read()
                        alname.Text = sdr99("NAME").ToString.Trim
                        aladdr.Text = sdr99("ADDRESS").ToString.Trim
                        alpin.Text = sdr99("PINCODE").ToString.Trim
                        alaadhaar.Text = sdr99("AADHAAR").ToString.Trim
                        alphn.Text = sdr99("PHONENO").ToString.Trim
                        alaltphn.Text = sdr99("ALTPHONE").ToString.Trim
                        algender.Text = sdr99("GENDER").ToString.Trim
                        aldateofj.Text = sdr99("DATEOFJOINING").ToString.Trim
                        DateTimePicker3.Value = aldateofj.Text
                        alemail.Text = sdr99("EMAIL").ToString.Trim
                        con.Close()
                        pical()
                        alpicupdate.Visible = True
                    Catch ex As Exception
                        con.Close()

                    End Try
                End If

                alpicupdate.Visible = True
            Catch ex As Exception
                con.Close()

            End Try
        End If

    End Function
    Function alrlf()



    End Function
    Function pical()
        Try
            Dim picture1 As Image = Nothing
            con.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select PHOTO from Staff where RFID=('" + alrfid.Text + "')"
            Dim pictureData As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
            con.Close()
            Using stream As New IO.MemoryStream(pictureData)
                picture1 = Image.FromStream(stream)
            End Using
            alpic.Image = picture1
            alpic.SizeMode = PictureBoxSizeMode.StretchImage
            Return picture1
        Catch ex As Exception
            con.Close()
        End Try
    End Function

    Private Sub alrfid_LostFocus(sender As Object, e As EventArgs) Handles alrfid.LostFocus

    End Sub

    Private Sub alrfid_KeyDown(sender As Object, e As KeyEventArgs) Handles alrfid.KeyDown
        If e.KeyCode = Keys.Enter Then
            performclk()
            alname.Focus()
            alname.SelectionLength = 0
        End If
    End Sub

    Private Sub alname_KeyDown(sender As Object, e As KeyEventArgs) Handles alname.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = aladdr
            aladdr.SelectionLength = 0
        End If
    End Sub

    Private Sub aladdr_KeyDown(sender As Object, e As KeyEventArgs) Handles aladdr.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = alpin
            alpin.SelectionLength = 0
        End If
    End Sub

    Private Sub alpin_KeyDown(sender As Object, e As KeyEventArgs) Handles alpin.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = alaadhaar
            alaadhaar.SelectionLength = 0
        End If
    End Sub

    Private Sub alaadhaar_KeyDown(sender As Object, e As KeyEventArgs) Handles alaadhaar.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = alphn
            alphn.SelectionLength = 0
        End If
    End Sub

    Private Sub alphn_KeyDown(sender As Object, e As KeyEventArgs) Handles alphn.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = alaltphn
            alaltphn.SelectionLength = 0
        End If
    End Sub

    Private Sub alaltphn_KeyDown(sender As Object, e As KeyEventArgs) Handles alaltphn.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = alemail
            alemail.SelectionLength = 0
        End If
    End Sub

    Private Sub hlrfid_KeyDown(sender As Object, e As KeyEventArgs) Handles hlrfid.KeyDown
        If e.KeyCode = Keys.Enter Then
            performclk()
            hlname.Focus()
            hlname.SelectionLength = 0
        End If
    End Sub

    Private Sub hlname_KeyDown(sender As Object, e As KeyEventArgs) Handles hlname.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = hladdr
            hladdr.SelectionLength = 0
        End If
    End Sub

    Private Sub hladdr_KeyDown(sender As Object, e As KeyEventArgs) Handles hladdr.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = hlpin
            hlpin.SelectionLength = 0
        End If
    End Sub

    Private Sub hlpin_KeyDown(sender As Object, e As KeyEventArgs) Handles hlpin.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = hlaadhaar
            hlaadhaar.SelectionLength = 0
        End If
    End Sub

    Private Sub hlaadhaar_KeyDown(sender As Object, e As KeyEventArgs) Handles hlaadhaar.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = hlphoneno
            hlphoneno.SelectionLength = 0
        End If
    End Sub

    Private Sub hlphoneno_KeyDown(sender As Object, e As KeyEventArgs) Handles hlphoneno.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = hlaltphone
            hlaltphone.SelectionLength = 0
        End If
    End Sub

    Private Sub hlaltphone_KeyDown(sender As Object, e As KeyEventArgs) Handles hlaltphone.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = hlemail
            hlemail.SelectionLength = 0
        End If
    End Sub

    Private Sub pdrfid_KeyDown(sender As Object, e As KeyEventArgs) Handles pdrfid.KeyDown
        If e.KeyCode = Keys.Enter Then
            performclk()
            pdname.Focus()
            pdname.SelectionLength = 0
        End If
    End Sub

    Private Sub pdname_KeyDown(sender As Object, e As KeyEventArgs) Handles pdname.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = pdaddr
            pdaddr.SelectionLength = 0
        End If
    End Sub

    Private Sub pdaddr_KeyDown(sender As Object, e As KeyEventArgs) Handles pdaddr.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = pdpincode
            pdpincode.SelectionLength = 0
        End If
    End Sub

    Private Sub pdpincode_KeyDown(sender As Object, e As KeyEventArgs) Handles pdpincode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = pdaadhar
            pdaadhar.SelectionLength = 0
        End If
    End Sub

    Private Sub pdaadhar_KeyDown(sender As Object, e As KeyEventArgs) Handles pdaadhar.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = pdphone
            pdphone.SelectionLength = 0
        End If
    End Sub

    Private Sub pdphone_KeyDown(sender As Object, e As KeyEventArgs) Handles pdphone.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = pdaltphone
            pdaltphone.SelectionLength = 0
        End If
    End Sub

    Private Sub pdaltphone_KeyDown(sender As Object, e As KeyEventArgs) Handles pdaltphone.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = pdemail
            pdemail.SelectionLength = 0
        End If
    End Sub
    Private Sub Buttoncancel_Click(sender As Object, e As EventArgs) Handles Buttoncancel.Click
        Form3.Show()
        Me.Close()
    End Sub

    Private Sub Panelmenu1_Paint(sender As Object, e As PaintEventArgs) Handles Panelmenu1.Paint

    End Sub
End Class