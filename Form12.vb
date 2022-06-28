Imports System.Data.SqlClient
Public Class Form12
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\V'th sem project\studentmanegerv2\students007.mdf;Integrated Security=True")
    Dim s As String = Form2.returnn()
    Dim buttonhp As Panel
    Dim currbtn As Button
    Dim dept As String = Nothing
    Dim mlttb As TextBox
    Dim lbl As Label
    Dim sm As String = Nothing
    Dim rg As String = Nothing
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles Me.Load
        Students.PerformClick()
        Students.PerformClick()
        Lbldate.Text = Date.Today
        Dim s As String = Form2.returnn()
        pic2()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbltime.Text = TimeOfDay
    End Sub

    Private Sub Students_Click(sender As Object, e As EventArgs) Handles Students.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        FlowLayoutPanel1.Controls.Clear()
        GC.Collect()

        Try
            con.Open()
            Dim cmd1 As New SqlCommand
            Dim dr2 As SqlDataReader
            cmd1.Connection = con
            cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6,libin,libout,outtime,date from attend where  RFID=('" + s + "') "
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
                    .Size = New Size(750, 100)
                    .Location = New Point(0, 6)
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .ForeColor = Color.Gainsboro
                    .Text = "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim + "  |  " + "HOUR2: " + dr2.Item("hour2").ToString.Trim + "  |  " + "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim + "  |  " + "HOUR5: " + dr2.Item("hour5").ToString.Trim + "  |  " + "HOUR6: " + dr2.Item("hour6").ToString.Trim & vbCrLf & "LIBRARY IN: " + dr2.Item("libin").ToString.Trim + "  |  " + "LIBRARY OUT: " + dr2.Item("libout").ToString.Trim & vbCrLf & "OUT TIME: " + dr2.Item("outtime").ToString.Trim
                    .BorderStyle = BorderStyle.None
                    .ScrollBars = ScrollBars.Both
                    .Font = New Font("Microsoft Sans Serif", 13)
                End With
                Dim lbl As Label
                lbl = New Label
                With lbl
                    .AutoSize = True
                    .Text = dr2.Item("date").ToString.Trim
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .ForeColor = Color.Gainsboro
                    .Location = New Point(756, 42)
                    .Size = New Size(100, 28)
                    .Font = New Font("Microsoft Sans Serif", 14.25, FontStyle.Bold)
                    .BringToFront()
                End With
                With atdpnl
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .Size = New Size(900, 120)
                    .Name = dr2.Item("regno") + pnlcount.ToString
                    .Controls.Add(tb)
                    .Controls.Add(lbl)
                End With
                FlowLayoutPanel1.Controls.Add(atdpnl)
                pnlname = atdpnl.Name
                pnlcount += 1

            End While
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        FlowLayoutPanel1.Controls.Clear()
        dooo()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        FlowLayoutPanel1.Controls.Clear()
        Try
            con.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select * from students where RFID=('" + s + "')"
            Dim dr2 As SqlDataReader
            cmd.CommandType = CommandType.Text
            dr2 = cmd.ExecuteReader
            While dr2.Read
                Dim pnlname As String = Nothing
                Dim pnlcount As Integer = 0
                Dim atdpnl As New Panel
                atdpnl = New Panel
                Dim tb As New TextBox
                tb = New TextBox
                With tb
                    .Multiline = True
                    .Size = New Size(750, 95)
                    .Location = New Point(0, 6)
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .ForeColor = Color.Gainsboro
                    .Text = "PAYMENT 1: " + dr2.Item("PAID1").ToString.Trim + " ON " + dr2.Item("PAYDATE1") & vbCrLf & "PAYMENT 2: " + dr2.Item("PAID2").ToString.Trim + " ON " + dr2.Item("PAYDATE2") & vbCrLf & "PAYMENT 3: " + dr2.Item("PAID3").ToString.Trim + " ON " + dr2.Item("PAYDATE3") & vbCrLf & "PAYMENT 4: " + dr2.Item("PAID4").ToString.Trim + " ON " + dr2.Item("PAYDATE4")
                    .BorderStyle = BorderStyle.None

                    .Font = New Font("Microsoft Sans Serif", 13)
                End With

                With atdpnl
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .Size = New Size(900, 100)
                    .Name = dr2.Item("rfid") + pnlcount.ToString
                    .Controls.Add(tb)
                    .Controls.Add(lbl)
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
    Function pic2()
        Try
            Dim picture1 As Image = Nothing
            con.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select PHOTO from students where RFID=('" + s + "')"
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
            cmd3.CommandText = "select * from students where RFID=('" + s + "')"
            cmd3.CommandType = CommandType.Text
            Dim sdr As SqlDataReader = cmd3.ExecuteReader
            sdr.Read()
            ' r = sdr("RFID").ToString
            regno.Text = "REGNO: " + sdr("REGNO").ToString.Trim
            dateofj.Text = "DOJ: " + sdr("dateofjoining").ToString.Trim
            namelbl.Text = "NAME: " + sdr("STUDENTNAME").ToString.Trim
            addno.Text = "ADDNO: " + sdr("addno").ToString.Trim
            cource.Text = "COURSE: " + sdr("COURSE").ToString.Trim
            sem.Text = "SEM: " + sdr("SEM").ToString.Trim
            dept = sdr("COURSE").ToString.Trim
            sm = sdr("SEM").ToString.Trim
            rg = sdr("REGNO").ToString.Trim
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
    End Function

    Private Sub dooo()
        pic2()

        Try
            con.Open()
            Dim cmd1 As New SqlCommand
            Dim dr2 As SqlDataReader
            cmd1.Connection = con
            cmd1.CommandText = "(select * from notif where [to]=('" + rg + "')) union(select * from notif where [to]='ALL') union(select * from notif where [to]='STUDENTS')union(select * from notif where [to]='PARENTS') order by date desc"
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
                    .Size = New Size(750, 100)
                    .Location = New Point(0, 6)
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .ForeColor = Color.Gainsboro
                    .Text = "To: " + dr2.Item("TO").ToString.Trim & vbCrLf & "from: " + dr2.Item("from").ToString.Trim & vbCrLf & dr2.Item("BODY").ToString.Trim
                    .BorderStyle = BorderStyle.None
                    .ScrollBars = ScrollBars.Both
                    .Font = New Font("Microsoft Sans Serif", 13)
                End With
                Dim lbl As Label
                lbl = New Label
                With lbl
                    .AutoSize = True
                    .Text = dr2.Item("date").ToString.Trim
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .ForeColor = Color.Gainsboro
                    .Location = New Point(756, 42)
                    .Size = New Size(100, 28)
                    .Font = New Font("Microsoft Sans Serif", 14.25, FontStyle.Bold)
                    .BringToFront()
                End With
                With atdpnl
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .Size = New Size(900, 120)
                    .Name = dr2.Item("time") + pnlcount.ToString
                    .Controls.Add(tb)
                    .Controls.Add(lbl)
                End With
                FlowLayoutPanel1.Controls.Add(atdpnl)
                pnlname = atdpnl.Name
                pnlcount += 1

            End While
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
        If dept = "BCA" Then

            Try
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "(select * from notifbca where [to]=('" + rg + "')) union(select * from notifbca where [to]='ALL')union(select * from notifbca where [to] like '%" + sm + "%') order by date desc"
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
                        .Size = New Size(750, 100)
                        .Location = New Point(0, 6)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Text = "To: " + dr2.Item("TO").ToString.Trim & vbCrLf & "from: " + dr2.Item("from").ToString.Trim & vbCrLf & dr2.Item("BODY").ToString.Trim
                        .BorderStyle = BorderStyle.None
                        .ScrollBars = ScrollBars.Both
                        .Font = New Font("Microsoft Sans Serif", 13)
                    End With
                    Dim lbl As Label
                    lbl = New Label
                    With lbl
                        .AutoSize = True
                        .Text = dr2.Item("date").ToString.Trim
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Location = New Point(756, 42)
                        .Size = New Size(100, 28)
                        .Font = New Font("Microsoft Sans Serif", 14.25, FontStyle.Bold)
                        .BringToFront()
                    End With
                    With atdpnl
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(900, 120)
                        .Name = dr2.Item("time") + pnlcount.ToString
                        .Controls.Add(tb)
                        .Controls.Add(lbl)
                    End With
                    FlowLayoutPanel1.Controls.Add(atdpnl)
                    pnlname = atdpnl.Name
                    pnlcount += 1

                End While
                con.Close()
            Catch ex As Exception
                con.Close()
            End Try
        ElseIf dept = "BBA" Then

            Try
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "(select * from notifbba where [to]=('" + rg + "')) union(select * from notifbba where [to]='ALL') union(select * from notifbba where to like '%" + sm + "%') order by date desc"
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
                        .Size = New Size(750, 100)
                        .Location = New Point(0, 6)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Text = "To: " + dr2.Item("TO").ToString.Trim & vbCrLf & "from: " + dr2.Item("from").ToString.Trim & vbCrLf & dr2.Item("BODY").ToString.Trim
                        .BorderStyle = BorderStyle.None
                        .ScrollBars = ScrollBars.Both
                        .Font = New Font("Microsoft Sans Serif", 13)
                    End With
                    Dim lbl As Label
                    lbl = New Label
                    With lbl
                        .AutoSize = True
                        .Text = dr2.Item("date").ToString.Trim
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Location = New Point(756, 42)
                        .Size = New Size(100, 28)
                        .Font = New Font("Microsoft Sans Serif", 14.25, FontStyle.Bold)
                        .BringToFront()
                    End With
                    With atdpnl
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(900, 120)
                        .Name = dr2.Item("time") + pnlcount.ToString
                        .Controls.Add(tb)
                        .Controls.Add(lbl)
                    End With
                    FlowLayoutPanel1.Controls.Add(atdpnl)
                    pnlname = atdpnl.Name
                    pnlcount += 1

                End While
                con.Close()
            Catch ex As Exception
                con.Close()
            End Try
        ElseIf dept = "BCOM" Then

            Try
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "(select * from notifbcom where [to]=('" + rg + "')) union(select * from notifbcom where [to]='ALL') union(select * from notifbcom where to like '%" + sm + "%') order by date desc"
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
                        .Size = New Size(750, 100)
                        .Location = New Point(0, 6)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Text = "To: " + dr2.Item("TO").ToString.Trim & vbCrLf & "from: " + dr2.Item("from").ToString.Trim & vbCrLf & dr2.Item("BODY").ToString.Trim
                        .BorderStyle = BorderStyle.None
                        .ScrollBars = ScrollBars.Both
                        .Font = New Font("Microsoft Sans Serif", 13)
                    End With
                    Dim lbl As Label
                    lbl = New Label
                    With lbl
                        .AutoSize = True
                        .Text = dr2.Item("date").ToString.Trim
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Location = New Point(756, 42)
                        .Size = New Size(100, 28)
                        .Font = New Font("Microsoft Sans Serif", 14.25, FontStyle.Bold)
                        .BringToFront()
                    End With
                    With atdpnl
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(900, 120)
                        .Name = dr2.Item("time") + pnlcount.ToString
                        .Controls.Add(tb)
                        .Controls.Add(lbl)
                    End With
                    FlowLayoutPanel1.Controls.Add(atdpnl)
                    pnlname = atdpnl.Name
                    pnlcount += 1

                End While
                con.Close()
            Catch ex As Exception
                con.Close()
            End Try
        End If


    End Sub
End Class