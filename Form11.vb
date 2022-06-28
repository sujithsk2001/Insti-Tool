Imports System.Data.SqlClient
Imports System.Net.Mail
Public Class Form11
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\V'th sem project\studentmanegerv2\students007.mdf;Integrated Security=True")

    Dim buttonhp As Panel
    Dim currbtn As Button
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
    Private Sub Students_Click(sender As Object, e As EventArgs) Handles Students.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        Panel3.Hide()
        Me.ActiveControl = TextBox1
    End Sub
    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbltime.Text = TimeOfDay
    End Sub

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles Me.Load
        Lbldate.Text = Date.Today
        Panel3.Hide()
        Panel1.Enabled = False
        DateTimePicker2.MaxDate = Date.Today
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        Panel3.Show()
        Panel7.Show()
        Panel7.Enabled = False
        Me.ActiveControl = TextBoxrfid
        Try
            con.Open()
            Dim da As New SqlDataAdapter("select bookid from library", con)
            Dim ds As New DataSet
            da.Fill(ds, "1")
            For i As Integer = 0 To ds.Tables("1").Rows.Count - 1
                Me.ComboBox1.Items.Add(ds.Tables("1").Rows(i)(0))
                Me.ComboBox2.Items.Add(ds.Tables("1").Rows(i)(0))
            Next
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        TextBox4.Text = DateTimePicker1.Value.Date
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        Panel3.Show()
        Panel7.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If bookid.Text.Trim <> "" And title.Text.Trim <> "" And publishyear.Text.Trim <> "" And author.Text.Trim <> "" And publishdetails.Text.Trim <> "" And price.Text.Trim <> "" And publishdate.Text.Trim <> "" And purchasesource.Text.Trim <> "" And Ppagecnt.Text.Trim <> "" And Mpagecnt.Text.Trim <> "" And POSpagecnt.Text.Trim <> "" And extracontent.Text.Trim <> "" And category.Text.Trim <> "" And faultdescription.Text.Trim <> "" Then
            Try
                con.Open()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "insert into library(bookid,title,publishyear,author,publisherdetails,price,purchasedate,purchasesource,priliminarypagecount,mainpagecount,postpagecount,extracontent,bookcategory,faultdiscription) values('" + bookid.Text.Trim + "','" + title.Text.Trim + "','" + publishyear.Text.Trim + "','" + author.Text.Trim + "','" + publishdetails.Text.Trim + "','" + price.Text.Trim + "','" + publishdate.Text.Trim + "','" + purchasesource.Text.Trim + "','" + Ppagecnt.Text.Trim + "','" + Mpagecnt.Text.Trim + "','" + POSpagecnt.Text.Trim + "','" + extracontent.Text.Trim + "','" + category.SelectedItem + "','" + faultdescription.Text.Trim + "')"
                cmd.ExecuteNonQuery()
                MsgBox("book added to library", MsgBoxStyle.Information, "added")
                con.Close()
                Try
                    con.Open()
                    Dim da As New SqlDataAdapter("select bookid from library", con)
                    Dim ds As New DataSet
                    da.Fill(ds, "1")
                    For i As Integer = 0 To ds.Tables("1").Rows.Count - 1
                        Me.ComboBox1.Items.Add(ds.Tables("1").Rows(i)(0))
                        Me.ComboBox2.Items.Add(ds.Tables("1").Rows(i)(0))
                    Next
                    con.Close()
                Catch ex As Exception
                    con.Close()
                End Try
            Catch ex As Exception
                con.Close()
            End Try
        Else
            MsgBox("enter all the value", MsgBoxStyle.Exclamation, "warning")
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        publishdate.Text = DateTimePicker2.Value.Date
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If bookid.Text.Trim <> "" Then
            Try
                con.Open()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "delete from library where bookid=('" + bookid.Text.Trim + "') "
                cmd.ExecuteNonQuery()
                MsgBox("deleted successfully", MsgBoxStyle.Information, "deleted")
                con.Close()
                Try
                    con.Open()
                    Dim da As New SqlDataAdapter("select bookid from library", con)
                    Dim ds As New DataSet
                    da.Fill(ds, "1")
                    For i As Integer = 0 To ds.Tables("1").Rows.Count - 1
                        Me.ComboBox1.Items.Add(ds.Tables("1").Rows(i)(0))
                        Me.ComboBox2.Items.Add(ds.Tables("1").Rows(i)(0))
                    Next
                    con.Close()
                Catch ex As Exception
                    con.Close()
                End Try
            Catch ex As Exception
                con.Close()
            End Try
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If bookid.Text.Trim <> "" And title.Text.Trim <> "" And publishyear.Text.Trim <> "" And author.Text.Trim <> "" And publishdetails.Text.Trim <> "" And price.Text.Trim <> "" And publishdate.Text.Trim <> "" And purchasesource.Text.Trim <> "" And Ppagecnt.Text.Trim <> "" And Mpagecnt.Text.Trim <> "" And POSpagecnt.Text.Trim <> "" And extracontent.Text.Trim <> "" And category.Text.Trim <> "" And faultdescription.Text.Trim <> "" Then
            Try
                con.Open()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "update library set title=('" + title.Text.Trim + "'),publishyear=('" + publishyear.Text.Trim + "'),author=('" + author.Text.Trim + "'),publisherdetails=('" + publishdetails.Text.Trim + "'),price=('" + price.Text.Trim + "'),purchasedate=('" + publishdate.Text.Trim + "'),purchasesource=('" + purchasesource.Text.Trim + "'),priliminarypagecount=('" + Ppagecnt.Text.Trim + "'),mainpagecount=('" + Mpagecnt.Text.Trim + "'),postpagecount=('" + POSpagecnt.Text.Trim + "'),extracontent=('" + extracontent.Text.Trim + "'),bookcategory=('" + category.SelectedItem + "'),faultdiscription=('" + faultdescription.Text.Trim + "') where bookid=('" + bookid.Text.Trim + "')"
                cmd.ExecuteNonQuery()
                MsgBox("book details modified", MsgBoxStyle.Information, "modified")
                con.Close()
                Try
                    con.Open()
                    Dim da As New SqlDataAdapter("select bookid from library", con)
                    Dim ds As New DataSet
                    da.Fill(ds, "1")
                    For i As Integer = 0 To ds.Tables("1").Rows.Count - 1
                        Me.ComboBox1.Items.Add(ds.Tables("1").Rows(i)(0))
                        Me.ComboBox2.Items.Add(ds.Tables("1").Rows(i)(0))
                    Next
                    con.Close()
                Catch ex As Exception
                    con.Close()
                End Try
            Catch ex As Exception
                con.Close()
            End Try
        Else
            MsgBox("enter all the value", MsgBoxStyle.Exclamation, "warning")
        End If
    End Sub

    Private Sub bookid_LostFocus(sender As Object, e As EventArgs) Handles bookid.LostFocus
        lf()
    End Sub

    Function lf()
        Try
            con.Open()
            Dim cmd3 As New SqlCommand
            cmd3.Connection = con
            cmd3.CommandText = "select * from library where bookid=('" + bookid.Text.Trim + "')"
            cmd3.CommandType = CommandType.Text
            Dim sdr As SqlDataReader = cmd3.ExecuteReader
            sdr.Read()
            title.Text = sdr("title").ToString.Trim
            publishyear.Text = sdr("publishyear").ToString.Trim
            author.Text = sdr("author").ToString.Trim
            publishdetails.Text = sdr("publisherdetails").ToString.Trim
            price.Text = sdr("price").ToString.Trim
            publishdate.Text = sdr("purchasedate").ToString.Trim
            purchasesource.Text = sdr("purchasesource").ToString.Trim
            Ppagecnt.Text = sdr("priliminarypagecount").ToString.Trim
            Mpagecnt.Text = sdr("mainpagecount").ToString.Trim
            POSpagecnt.Text = sdr("postpagecount").ToString.Trim
            extracontent.Text = sdr("extracontent").ToString.Trim
            category.Text = sdr("bookcategory").ToString.Trim
            faultdescription.Text = sdr("faultdiscription").ToString.Trim
            DateTimePicker2.Value = publishdate.Text
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox1.Text <> "" And TextBox4.Text <> "" Then
            Try
                con.Open()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "update library set givento=('" + TextBox1.Text.Trim + "'),duedate=('" + TextBox4.Text.Trim + "'),givendate=('" + Lbldate.Text + "')"
                cmd.ExecuteNonQuery()

                MsgBox("book lending process has compleated recever can take the book", MsgBoxStyle.Information, "success")
                con.Close()
                Try
                    con.Open()
                    Dim da As New SqlDataAdapter("select bookid from library", con)
                    Dim ds As New DataSet
                    da.Fill(ds, "1")
                    For i As Integer = 0 To ds.Tables("1").Rows.Count - 1
                        Me.ComboBox1.Items.Add(ds.Tables("1").Rows(i)(0))
                        Me.ComboBox2.Items.Add(ds.Tables("1").Rows(i)(0))
                    Next
                    con.Close()
                Catch ex As Exception
                    con.Close()
                End Try
            Catch ex As Exception
                con.Close()
            End Try
        Else
            MsgBox("select book id", MsgBoxStyle.Exclamation, "warning")
        End If
        FlowLayoutPanel1.Controls.Clear()
        Try
            con.Open()
            Dim cmd1 As New SqlCommand
            Dim dr2 As SqlDataReader
            cmd1.Connection = con
            cmd1.CommandText = "select * from library where givento=('" + TextBox1.Text + "')"
            cmd1.CommandType = CommandType.Text
            dr2 = cmd1.ExecuteReader
            While dr2.Read
                Dim pnlname As String = Nothing
                Dim pnlcount As Integer = 0
                Dim atdpnl As New Panel
                atdpnl = New Panel
                Dim tb As New TextBox
                tb = New TextBox
                With tb
                    .Multiline = True
                    .Size = New Size(350, 110)
                    .Location = New Point(0, 0)
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .ForeColor = Color.Gainsboro
                    .Text = "BOOK ID: " + dr2.Item("bookid").ToString.Trim & vbCrLf & "TITLE: " + dr2.Item("title").ToString.Trim & vbCrLf & "AUTHOR: " + dr2.Item("author").ToString.Trim & vbCrLf & "GIVEN DATE: " + dr2.Item("givendate").ToString.Trim & vbCrLf & "DUEDATE: " + dr2.Item("duedate").ToString.Trim
                    .BorderStyle = BorderStyle.None
                    .ScrollBars = ScrollBars.Both
                    .Font = New Font("Microsoft Sans Serif", 13)
                End With
                With atdpnl
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .Size = New Size(350, 110)
                    .Name = dr2.Item("bookid")
                    .Controls.Add(tb)

                End With
                FlowLayoutPanel1.Controls.Add(atdpnl)
                pnlname = atdpnl.Name
                pnlcount += 1
            End While
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If ComboBox2.Text <> "" Then
            Try
                con.Open()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "update library set givento=null,duedate=null,givendate=null"
                cmd.ExecuteNonQuery()

                MsgBox("recived and ready to be given for others", MsgBoxStyle.Information, "recived")
                con.Close()
            Catch ex As Exception
                con.Close()
            End Try
        Else
            MsgBox("select book id", MsgBoxStyle.Exclamation, "warning")
        End If
        FlowLayoutPanel1.Controls.Clear()
        Try
            con.Open()
            Dim cmd1 As New SqlCommand
            Dim dr2 As SqlDataReader
            cmd1.Connection = con
            cmd1.CommandText = "select * from library where givento=('" + TextBox1.Text + "')"
            cmd1.CommandType = CommandType.Text
            dr2 = cmd1.ExecuteReader
            While dr2.Read
                Dim pnlname As String = Nothing
                Dim pnlcount As Integer = 0
                Dim atdpnl As New Panel
                atdpnl = New Panel
                Dim tb As New TextBox
                tb = New TextBox
                With tb
                    .Multiline = True
                    .Size = New Size(350, 110)
                    .Location = New Point(0, 0)
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .ForeColor = Color.Gainsboro
                    .Text = "BOOK ID: " + dr2.Item("bookid").ToString.Trim & vbCrLf & "TITLE: " + dr2.Item("title").ToString.Trim & vbCrLf & "AUTHOR: " + dr2.Item("author").ToString.Trim & vbCrLf & "GIVEN DATE: " + dr2.Item("givendate").ToString.Trim & vbCrLf & "DUEDATE: " + dr2.Item("duedate").ToString.Trim
                    .BorderStyle = BorderStyle.None
                    .ScrollBars = ScrollBars.Both
                    .Font = New Font("Microsoft Sans Serif", 13)
                End With
                With atdpnl
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .Size = New Size(350, 110)
                    .Name = dr2.Item("bookid")
                    .Controls.Add(tb)

                End With
                FlowLayoutPanel1.Controls.Add(atdpnl)
                pnlname = atdpnl.Name
                pnlcount += 1
            End While
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            con.Open()
            Dim cmd3 As New SqlCommand
            cmd3.Connection = con
            cmd3.CommandText = "select * from library where bookid=('" + ComboBox1.SelectedItem + "')"
            cmd3.CommandType = CommandType.Text
            Dim sdr As SqlDataReader = cmd3.ExecuteReader
            sdr.Read()
            TextBox2.Text = sdr("title").ToString.Trim
            TextBox3.Text = sdr("author").ToString.Trim
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            con.Open()
            Dim cmd3 As New SqlCommand
            cmd3.Connection = con
            cmd3.CommandText = "select * from library where bookid=('" + ComboBox2.SelectedItem + "')"
            cmd3.CommandType = CommandType.Text
            Dim sdr As SqlDataReader = cmd3.ExecuteReader
            sdr.Read()
            TextBox7.Text = sdr("title").ToString.Trim
            TextBox6.Text = sdr("author").ToString.Trim
            TextBox5.Text = sdr("duedate").ToString.Trim
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
        PictureBox2.Image = Nothing
        Labelname.Text = "NAME: "
        Labelregno.Text = "REG NO: "
        Labelpn.Text = "Phone no: "
        Labelsem.Text = "Sem: "
        Labelcour.Text = "course: "
        Try
            Dim picture1 As Image = Nothing
            con.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select PHOTO from students where RFID=('" + TextBox1.Text + "')"
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
        Try
            'Dim r As String
            con.Open()
            Dim cmd3 As New SqlCommand
            cmd3.Connection = con
            cmd3.CommandText = "select * from students where RFID=('" + TextBox1.Text + "')"
            cmd3.CommandType = CommandType.Text
            Dim sdr As SqlDataReader = cmd3.ExecuteReader
            sdr.Read()
            ' r = sdr("RFID").ToString
            Labelregno.Text = Labelregno.Text + " " + sdr("REGNO").ToString.Trim
            Labelname.Text = Labelname.Text + " " + sdr("STUDENTNAME").ToString.Trim
            Labelpn.Text = Labelpn.Text + " " + sdr("STDPHONE").ToString.Trim
            Labelcour.Text = Labelcour.Text + " " + sdr("COURSE").ToString.Trim
            Labelsem.Text = Labelsem.Text + " " + sdr("SEM").ToString.Trim
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
        FlowLayoutPanel1.Controls.Clear()
        Try
            con.Open()
            Dim cmd1 As New SqlCommand
            Dim dr2 As SqlDataReader
            cmd1.Connection = con
            cmd1.CommandText = "select * from library where givento=('" + TextBox1.Text + "')"
            cmd1.CommandType = CommandType.Text
            dr2 = cmd1.ExecuteReader
            While dr2.Read
                Dim pnlname As String = Nothing
                Dim pnlcount As Integer = 0
                Dim atdpnl As New Panel
                atdpnl = New Panel
                Dim tb As New TextBox
                tb = New TextBox
                With tb
                    .Multiline = True
                    .Size = New Size(350, 110)
                    .Location = New Point(0, 0)
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .ForeColor = Color.Gainsboro
                    .Text = "BOOK ID: " + dr2.Item("bookid").ToString.Trim & vbCrLf & "TITLE: " + dr2.Item("title").ToString.Trim & vbCrLf & "AUTHOR: " + dr2.Item("author").ToString.Trim & vbCrLf & "GIVEN DATE: " + dr2.Item("givendate").ToString.Trim & vbCrLf & "DUEDATE: " + dr2.Item("duedate").ToString.Trim
                    .BorderStyle = BorderStyle.None
                    .ScrollBars = ScrollBars.Both
                    .Font = New Font("Microsoft Sans Serif", 13)
                End With
                With atdpnl
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .Size = New Size(350, 110)
                    .Name = dr2.Item("bookid")
                    .Controls.Add(tb)

                End With
                FlowLayoutPanel1.Controls.Add(atdpnl)
                pnlname = atdpnl.Name
                pnlcount += 1
            End While
            con.Close()
            TextBox1.Clear()

        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        TextBox8.Clear()
        Me.ActiveControl = TextBox8
        Me.ActiveControl = TextBox8
        Panel3.Show()
        Panel7.Show()
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            PictureBox2.Focus()

        End If
    End Sub

    Private Sub TextBox8_LostFocus(sender As Object, e As EventArgs) Handles TextBox8.LostFocus
        Try
            con.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select libin from attend where rfid=('" + TextBox8.Text + "') and date like '%" + Lbldate.Text.Trim + "%' "
            cmd.CommandType = CommandType.Text
            Dim sdr27 As SqlDataReader = cmd.ExecuteReader()
            sdr27.Read()
            Dim post1 As String = Nothing
            post1 = sdr27("libin").ToString.Trim
            con.Close()

            If post1 = "" Then
                Try
                    Dim picture1 As Image = Nothing
                    con.Open()
                    Dim cmd1 As New SqlCommand
                    cmd1.Connection = con
                    cmd1.CommandText = "select PHOTO from students where RFID=('" + TextBox8.Text + "')"
                    Dim pictureData As Byte() = DirectCast(cmd1.ExecuteScalar(), Byte())
                    con.Close()
                    Using stream As New IO.MemoryStream(pictureData)
                        picture1 = Image.FromStream(stream)
                    End Using
                    PictureBox3.Image = picture1
                    PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
                    Me.ActiveControl = TextBox8
                    Panel7.BackColor = Color.Green
                    Dim cmd3 As New SqlCommand
                    con.Open()
                    cmd3.Connection = con
                    cmd3.CommandText = "update attend set libin=('" + lbltime.Text.Trim + "') where date like '%" + Lbldate.Text.Trim + "%' and rfid=('" + TextBox8.Text.Trim + "')"
                    cmd3.ExecuteNonQuery()
                    con.Close()
                    Threading.Thread.Sleep(10)
                    Timer2.Enabled = True
                Catch ex As Exception
                    con.Close()
                    Timer2.Enabled = True
                End Try
            Else
                Try
                    Dim picture12 As Image = Nothing
                    con.Open()
                    Dim cmd12 As New SqlCommand
                    cmd12.Connection = con
                    cmd12.CommandText = "select PHOTO from students where RFID=('" + TextBox8.Text + "')"
                    Dim pictureData2 As Byte() = DirectCast(cmd12.ExecuteScalar(), Byte())
                    con.Close()
                    Using stream As New IO.MemoryStream(pictureData2)
                        picture12 = Image.FromStream(stream)
                    End Using
                    PictureBox3.Image = picture12
                    PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
                    Me.ActiveControl = TextBox8
                    Panel7.BackColor = Color.Green
                    Dim cmd3 As New SqlCommand

                    con.Open()
                    Dim cmd4 As New SqlCommand
                    cmd4.Connection = con
                    cmd4.CommandText = "update attend set libout=('" + lbltime.Text.Trim + "') where date like '%" + Lbldate.Text.Trim + "%' and rfid=('" + TextBox8.Text.Trim + "')"
                    cmd4.ExecuteNonQuery()
                    con.Close()
                    Threading.Thread.Sleep(10)
                    Timer2.Enabled = True
                Catch ex As Exception
                    con.Close()
                    Timer2.Enabled = True
                End Try
            End If

            con.Close()

        Catch ex As Exception
            con.Close()

        End Try

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        GC.Collect()
        GC.WaitForPendingFinalizers()
        GC.Collect()
        Me.ActiveControl = TextBox8
        Panel7.BackColor = Color.FromArgb(34, 33, 74)
        PictureBox3.Image = Nothing
        Timer2.Enabled = False
        TextBox8.Clear()
    End Sub

    Private Sub TextBoxrfid_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxrfid.KeyDown
        If e.KeyCode = Keys.Enter Then
            PictureBox1.Focus()
        End If
    End Sub

    Private Sub TextBox8_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox8.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox9.Focus()
        End If
    End Sub

    Private Sub TextBoxrfid_LostFocus(sender As Object, e As EventArgs) Handles TextBoxrfid.LostFocus
        Try
            con.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select post from staff where rfid=('" + TextBoxrfid.Text.Trim + "') "
            cmd.CommandType = CommandType.Text
            Dim sdr27 As SqlDataReader = cmd.ExecuteReader()
            sdr27.Read()
            Dim post = sdr27("post").ToString.Trim

            If post = "Librarian" Then
                Panel1.Enabled = True
                Students.PerformClick()
                Students.PerformClick()
                Students.PerformClick()
                Panel7.Enabled = True
            End If

            con.Close()

        Catch ex As Exception
            con.Close()

        End Try
    End Sub

    Private Sub TextBoxrfid_TextChanged(sender As Object, e As EventArgs) Handles TextBoxrfid.TextChanged
        Panel3.Show()
        Panel7.Show()
        Panel7.Enabled = False
        Panel1.Enabled = False
        buttonhp.Visible = False
        desablebtn()
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub
End Class