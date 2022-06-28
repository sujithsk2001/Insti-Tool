Imports System.Data.SqlClient
Imports System.Threading
Imports System.Net.Mail
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form7
    Dim buttonhp As Panel
    Dim currbtn As Button
    Private curpnlname As String = Nothing
    Private curpnlcnt As Integer = 0
    Dim pic As PictureBox
    Private WithEvents contactpanel As Panel
    Private WithEvents contactpanel2 As Panel
    Private WithEvents contactpanel3 As Panel
    Private WithEvents contactpanel4 As Panel
    Dim mlttb As TextBox
    Dim lbl As Label
    Dim dr As SqlDataReader

    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\V'th sem project\studentmanegerv2\students007.mdf;Integrated Security=True")
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
    Sub Main(ByVal args As String())
        Dim th As Thread = New Thread(New ThreadStart(AddressOf createpanel))
        th.Start()
        Dim th2 As Thread = New Thread(New ThreadStart(AddressOf createpanelfs))
        th2.Start()
    End Sub
    Private Sub createpanel()
        Try
            Dim post As String
            post = currbtn.Text
            con.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select photo,name,gender,address,email,phoneno,department,sub1,sub2,post from staff where post like '%" + post + "%' "
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader
            While dr.Read

                Dim len As Long = dr.GetBytes(0, 0, Nothing, 0, 0)
                Dim array(CInt(len)) As Byte
                dr.GetBytes(0, 0, array, 0, CInt(len))
                Dim ms As New IO.MemoryStream(array)
                Dim bitmap As New Bitmap(ms)
                pic = New PictureBox
                pic.Size = New Size(130, 150)
                pic.Image = bitmap
                pic.BorderStyle = BorderStyle.FixedSingle
                pic.SizeMode = PictureBoxSizeMode.StretchImage

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
                    .Text = "NAME: " + dr.Item("NAME").ToString.Trim & vbCrLf & "POST: " + dr.Item("post").ToString.Trim & vbCrLf & "GENDER: " + dr.Item("gender").ToString.Trim & vbCrLf & "EMAIL: " + dr.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr.Item("phoneno").ToString.Trim & vbCrLf & "DEPARTMENT: " + dr.Item("department").ToString.Trim & vbCrLf & "SUB1: " + dr.Item("sub1").ToString.Trim & vbCrLf & "SUB2: " + dr.Item("sub2").ToString.Trim
                End With
                contactpanel = New Panel
                With contactpanel
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .Size = New Size(800, 150)
                    .Name = "contactpanel" + (curpnlcnt + 1).ToString
                    .Controls.Add(pic)
                    .Controls.Add(mlttb)
                End With

                curpnlname = contactpanel.Name
                curpnlcnt += 1
                FlowLayoutPanel1.Controls.Add(contactpanel)
            End While
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try

    End Sub

    Private Sub HOD_Click(sender As Object, e As EventArgs) Handles HOD.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        FlowLayoutPanel1.Controls.Clear()
        GC.Collect()
        createpanel()
        Panel4.Visible = False
        alrfid.Clear()
        Panel5.Hide()
    End Sub

    Private Sub Lecturer_Click(sender As Object, e As EventArgs) Handles Lecturer.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        FlowLayoutPanel1.Controls.Clear()
        GC.Collect()
        createpanel()
        Panel4.Visible = False
        alrfid.Clear()
        Panel5.Hide()
        Cursor = Cursors.Default
    End Sub
    Private Sub createpanelfs()
        Try

            con.Open()
            Dim cmd1 As New SqlCommand
            Dim dr2 As SqlDataReader
            cmd1.Connection = con
            cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno from students order by sem desc"
            cmd1.CommandType = CommandType.Text
            dr2 = cmd1.ExecuteReader
            While dr2.Read

                Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                Dim array(CInt(len)) As Byte
                dr2.GetBytes(0, 0, array, 0, CInt(len))
                Dim ms As New IO.MemoryStream(array)
                Dim bitmap As New Bitmap(ms)
                pic = New PictureBox
                pic.Size = New Size(130, 150)
                pic.Image = bitmap
                pic.BorderStyle = BorderStyle.FixedSingle
                pic.SizeMode = PictureBoxSizeMode.StretchImage

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
                    .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "GENDER: " + dr2.Item("gender").ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                End With
                contactpanel2 = New Panel
                With contactpanel2
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .Size = New Size(800, 150)
                    .Name = "contactpanel" + (curpnlcnt + 1).ToString
                    .Controls.Add(pic)
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



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        Panel4.Visible = False
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        alrfid.Clear()
        FlowLayoutPanel1.Controls.Clear()
        GC.Collect()
        FlowLayoutPanel2.Controls.Clear()
        GC.Collect()
        FlowLayoutPanel3.Controls.Clear()
        GC.Collect()
        Panel8.Hide()
        Panel6.Show()
        Panel5.Show()
        txtnotif.Clear()
        TextBox2.Clear()
        Try
            con.Open()
            Dim cmd1 As New SqlCommand
            Dim dr23 As SqlDataReader
            cmd1.Connection = con
            cmd1.CommandText = "select [to],[from],[body],[date],[time] from notif order by date desc"
            cmd1.CommandType = CommandType.Text
            dr23 = cmd1.ExecuteReader()
            While dr23.Read
                mlttb = New TextBox
                With mlttb
                    .Multiline = True
                    .ScrollBars = ScrollBars.Both
                    .BorderStyle = BorderStyle.None
                    .ReadOnly = True
                    .Size = New Size(449, 68)
                    .Location = New Point(0, 30)
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .ForeColor = Color.Gainsboro
                    .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                    .Text = "To: " + dr23.Item("TO").ToString.Trim & vbCrLf & "from: " + dr23.Item("from").ToString.Trim & vbCrLf & dr23.Item("BODY").ToString.Trim
                End With
                Dim lbl As Label
                lbl = New Label
                With lbl
                    .AutoSize = True
                    .Text = dr23.Item("TIME").ToString.Trim
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .ForeColor = Color.Gainsboro
                    .Location = New Point(0, 0)
                    .Size = New Size(100, 28)
                    .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                    .BringToFront()
                End With
                Dim lbl2 As Label
                lbl2 = New Label
                With lbl2
                    .AutoSize = True
                    .Text = dr23.Item("date").ToString.Trim
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .ForeColor = Color.Gainsboro
                    .Location = New Point(60, 0)
                    .Size = New Size(300, 28)
                    .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                    .BringToFront()
                End With
                contactpanel4 = New Panel
                With contactpanel4
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .Size = New Size(450, 100)
                    .Name = "contactpanel" + (curpnlcnt + 1).ToString
                    .Controls.Add(mlttb)
                    .Controls.Add(lbl)
                    .Controls.Add(lbl2)
                End With

                curpnlname = contactpanel4.Name
                curpnlcnt += 1
                FlowLayoutPanel3.Controls.Add(contactpanel4)
            End While
            con.Close()
        Catch ex As Exception
            con.Close()
            Cursor = Cursors.Default
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles Me.Load
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        HOD.PerformClick()
        Try
            Dim tlist As New AutoCompleteStringCollection


            con.Open()
            Dim cmd45 As New SqlCommand
            cmd45.Connection = con
            cmd45.CommandText = "Select Regno from students "
            cmd45.CommandType = CommandType.Text
            Dim sdr As SqlDataReader = cmd45.ExecuteReader()
            sdr.Read()
            While sdr.Read()
                tlist.Add(sdr("Regno").ToString().Trim)
            End While
            alrfid.AutoCompleteCustomSource = tlist

            TextBox2.AutoCompleteCustomSource = tlist

            con.Close()
        Catch ex As Exception
            con.Close()
            Cursor = Cursors.Default
        End Try
        Lbldate.Text = Date.Today
        Cursor = Cursors.Default
    End Sub

    Private Sub Students_Click(sender As Object, e As EventArgs) Handles Students.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        FlowLayoutPanel1.Controls.Clear()
        GC.Collect()
        createpanelfs()
        Panel4.Visible = True
        Panel5.Hide()
        Cursor = Cursors.Default
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll

        FlowLayoutPanel1.Controls.Clear()
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        If TrackBar1.Value = 1 Then
            Try
                GC.Collect()
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno from students where course like '%BCA%' order by sem desc "
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic = New PictureBox
                    pic.Size = New Size(130, 150)
                    pic.Image = bitmap
                    pic.BorderStyle = BorderStyle.FixedSingle
                    pic.SizeMode = PictureBoxSizeMode.StretchImage

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
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "GENDER: " + dr2.Item("gender").ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic)
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
        ElseIf TrackBar1.Value = 2 Then
            Try
                GC.Collect()
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno from students where course like '%BCOM%' order by sem desc"
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic = New PictureBox
                    pic.Size = New Size(130, 150)
                    pic.Image = bitmap
                    pic.BorderStyle = BorderStyle.FixedSingle
                    pic.SizeMode = PictureBoxSizeMode.StretchImage

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
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "GENDER: " + dr2.Item("gender").ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic)
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
        ElseIf TrackBar1.Value = 3 Then
            Try
                GC.Collect()
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno from students where course like '%BBA%' order by sem desc"
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic = New PictureBox
                    pic.Size = New Size(130, 150)
                    pic.Image = bitmap
                    pic.BorderStyle = BorderStyle.FixedSingle
                    pic.SizeMode = PictureBoxSizeMode.StretchImage

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
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "GENDER: " + dr2.Item("gender").ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic)
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
                GC.Collect()
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno from students order by sem desc"
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic = New PictureBox
                    pic.Size = New Size(130, 150)
                    pic.Image = bitmap
                    pic.BorderStyle = BorderStyle.FixedSingle
                    pic.SizeMode = PictureBoxSizeMode.StretchImage

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
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "GENDER: " + dr2.Item("gender").ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic)
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
        Cursor = Cursors.Default
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        TrackBar1.Value = 0
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        TrackBar1.Value = 1
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        TrackBar1.Value = 2
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        TrackBar1.Value=3
    End Sub

    Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar1.ValueChanged
        FlowLayoutPanel1.Controls.Clear()
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        If TrackBar1.Value = 1 Then
            Try
                GC.Collect()
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno from students where course like '%BCA%'order by sem desc "
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic = New PictureBox
                    pic.Size = New Size(130, 150)
                    pic.Image = bitmap
                    pic.BorderStyle = BorderStyle.FixedSingle
                    pic.SizeMode = PictureBoxSizeMode.StretchImage

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
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "GENDER: " + dr2.Item("gender").ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic)
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
        ElseIf TrackBar1.Value = 2 Then
            Try
                GC.Collect()
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno from students where course like '%BCOM%' order by sem desc"
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic = New PictureBox
                    pic.Size = New Size(130, 150)
                    pic.Image = bitmap
                    pic.BorderStyle = BorderStyle.FixedSingle
                    pic.SizeMode = PictureBoxSizeMode.StretchImage

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
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "GENDER: " + dr2.Item("gender").ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic)
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
        ElseIf TrackBar1.Value = 3 Then
            Try
                GC.Collect()
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno from students where course like '%BBA%' order by sem desc"
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic = New PictureBox
                    pic.Size = New Size(130, 150)
                    pic.Image = bitmap
                    pic.BorderStyle = BorderStyle.FixedSingle
                    pic.SizeMode = PictureBoxSizeMode.StretchImage

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
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "GENDER: " + dr2.Item("gender").ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic)
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
                GC.Collect()
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno from students order by sem desc"
                cmd1.CommandType = CommandType.Text
                dr2 = cmd1.ExecuteReader
                While dr2.Read

                    Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte
                    dr2.GetBytes(0, 0, array, 0, CInt(len))
                    Dim ms As New IO.MemoryStream(array)
                    Dim bitmap As New Bitmap(ms)
                    pic = New PictureBox
                    pic.Size = New Size(130, 150)
                    pic.Image = bitmap
                    pic.BorderStyle = BorderStyle.FixedSingle
                    pic.SizeMode = PictureBoxSizeMode.StretchImage

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
                        .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "GENDER: " + dr2.Item("gender").ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                    End With
                    contactpanel2 = New Panel
                    With contactpanel2
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(800, 150)
                        .Name = "contactpanel" + (curpnlcnt + 1).ToString
                        .Controls.Add(pic)
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
        Cursor = Cursors.Default
    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        desablebtn()
        buttonhp.Visible = False
        FlowLayoutPanel1.Controls.Clear()
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try
            Dim rrr As String
            rrr = alrfid.Text.Trim
            GC.Collect()
            con.Open()
            Dim cmd1 As New SqlCommand
            Dim dr2 As SqlDataReader
            cmd1.Connection = con
            cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno from students where regno like'%" + rrr + "%'"
            cmd1.CommandType = CommandType.Text
            dr2 = cmd1.ExecuteReader
            While dr2.Read

                Dim len As Long = dr2.GetBytes(0, 0, Nothing, 0, 0)
                Dim array(CInt(len)) As Byte
                dr2.GetBytes(0, 0, array, 0, CInt(len))
                Dim ms As New IO.MemoryStream(array)
                Dim bitmap As New Bitmap(ms)
                pic = New PictureBox
                pic.Size = New Size(130, 150)
                pic.Image = bitmap
                pic.BorderStyle = BorderStyle.FixedSingle
                pic.SizeMode = PictureBoxSizeMode.StretchImage
                alpic.Image = bitmap
                alpic.SizeMode = PictureBoxSizeMode.StretchImage
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
                    .Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "GENDER: " + dr2.Item("gender").ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim
                End With
                TextBox1.Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "GENDER: " + dr2.Item("gender").ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim

                contactpanel2 = New Panel
                With contactpanel2
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .Size = New Size(800, 150)
                    .Name = "contactpanel" + (curpnlcnt + 1).ToString
                    .Controls.Add(pic)
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
        Cursor = Cursors.Default
    End Sub

    Private Sub alrfid_TextChanged(sender As Object, e As EventArgs) Handles alrfid.TextChanged
        alpic.Image = Nothing
        TextBox1.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        Panel4.Visible = False
        Panel6.Hide()
        alrfid.Clear()
        FlowLayoutPanel1.Controls.Clear()
        GC.Collect()
        Panel5.Show()
        GC.Collect()
        FlowLayoutPanel2.Controls.Clear()
        GC.Collect()
        txtto.Clear()
        txtsub.Clear()
        txtbody.Clear()
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try
            con.Open()
            Dim cmd1 As New SqlCommand
            Dim dr23 As SqlDataReader
            cmd1.Connection = con
            cmd1.CommandText = "select [to],[subject],[body],[date],[time] from mail order by date desc"
            cmd1.CommandType = CommandType.Text
            dr23 = cmd1.ExecuteReader()
            While dr23.Read
                mlttb = New TextBox
                With mlttb
                    .Multiline = True
                    .ScrollBars = ScrollBars.Both
                    .BorderStyle = BorderStyle.None
                    .ReadOnly = True
                    .Size = New Size(400, 68)
                    .Location = New Point(0, 30)
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .ForeColor = Color.Gainsboro
                    .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                    .Text = "To: " + dr23.Item("TO").ToString.Trim & vbCrLf & "Subject: " + dr23.Item("SUBJECT").ToString.Trim & vbCrLf & dr23.Item("BODY").ToString.Trim
                End With
                Dim lbl As Label
                lbl = New Label
                With lbl
                    .AutoSize = True
                    .Text = dr23.Item("TIME").ToString.Trim
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .ForeColor = Color.Gainsboro
                    .Location = New Point(0, 0)
                    .Size = New Size(100, 28)
                    .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                    .BringToFront()
                End With
                Dim lbl2 As Label
                lbl2 = New Label
                With lbl2
                    .AutoSize = True
                    .Text = dr23.Item("date").ToString.Trim
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .ForeColor = Color.Gainsboro
                    .Location = New Point(60, 0)
                    .Size = New Size(300, 28)
                    .Font = New Font("Segoe UI Semibold", 11.25, FontStyle.Bold)
                    .BringToFront()
                End With

                contactpanel3 = New Panel
                With contactpanel3
                    .BackColor = Color.FromArgb(34, 33, 74)
                    .Size = New Size(420, 100)
                    .Name = "contactpanel" + (curpnlcnt + 1).ToString
                    .Controls.Add(mlttb)
                    .Controls.Add(lbl)
                    .Controls.Add(lbl2)

                End With

                curpnlname = contactpanel3.Name
                curpnlcnt += 1
                FlowLayoutPanel2.Controls.Add(contactpanel3)
            End While
            con.Close()
        Catch ex As Exception
            con.Close()
            Cursor = Cursors.Default
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub btnsnd_Click(sender As Object, e As EventArgs) Handles btnsnd.Click
        If txtto.Text.Trim = "" Then
            Label10.ForeColor = Color.Red
        ElseIf txtsub.Text.Trim = "" Then
            Label11.ForeColor = Color.Red
        ElseIf txtbody.Text.Trim = "" Then
            Label12.ForeColor = Color.Red
        Else
            Label10.ForeColor = Color.Gainsboro
            Label11.ForeColor = Color.Gainsboro
            Label12.ForeColor = Color.Gainsboro
            Try
                Label1.Visible = True
                Cursor = Cursors.WaitCursor
                Application.DoEvents()
                Dim mail As New MailMessage
                Dim smtpserver As New SmtpClient("smtp.gmail.com")
                mail.From = New MailAddress("institoolbca5@gmail.com")
                mail.To.Add(txtto.Text.Trim)
                mail.Subject = txtsub.Text.Trim
                mail.Body = txtbody.Text & vbCrLf & "" & vbCrLf & "sd\-" & vbCrLf & "Management"
                smtpserver.Port = 587
                smtpserver.Credentials = New Net.NetworkCredential("institoolbca5@gmail.com", "Institoolbca5@")
                smtpserver.EnableSsl = True
                smtpserver.Send(mail)
                Label1.Text = "Sent!"
                con.Open()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "insert into mail([TO],[SUBJECT],[BODY],[DATE],[TIME]) values('" + txtto.Text + "','" + txtsub.Text + "','" + txtbody.Text + "','" + Lbldate.Text + "','" + lbltime.Text + "')"
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Mail has been sent successfully!", MsgBoxStyle.Information, "Sent")
                Button3.PerformClick()
                Cursor = Cursors.Default
                Label1.Visible = False
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Please enter valid e-mail address")
                con.Close()
                Cursor = Cursors.Default
                Label1.Visible = False
            End Try

        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbltime.Text = TimeOfDay
    End Sub

    Private Sub txtto_TextChanged(sender As Object, e As EventArgs) Handles txtto.TextChanged
        Label10.ForeColor = Color.Gainsboro
    End Sub

    Private Sub txtsub_TextChanged(sender As Object, e As EventArgs) Handles txtsub.TextChanged
        Label11.ForeColor = Color.Gainsboro
    End Sub

    Private Sub txtbody_TextChanged(sender As Object, e As EventArgs) Handles txtbody.TextChanged
        Label12.ForeColor = Color.Gainsboro
    End Sub


    Private Sub sndnotif_Click(sender As Object, e As EventArgs) Handles sndnotif.Click
        If CheckBox8.CheckState = CheckState.Checked Then
            If CheckBox1.CheckState = CheckState.Checked And TextBox2.Text <> "" Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "insert into notif([from],[to],[body],[time],[date]) values('" + CheckBox8.Text + "','" + TextBox2.Text.Trim + "','" + txtnotif.Text + "','" + lbltime.Text + "','" + Lbldate.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("notification sent successfully!", MsgBoxStyle.Information, "sent")
                Catch ex As Exception
                    con.Close()
                End Try
            ElseIf TrackBar2.Value = 0 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "insert into notif([from],[to],[body],[time],[date]) values('" + CheckBox8.Text + "','BCA HOD','" + txtnotif.Text + "','" + lbltime.Text + "','" + Lbldate.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("notification sent successfully!", MsgBoxStyle.Information, "sent")
                Catch ex As Exception
                    con.Close()
                End Try
            ElseIf TrackBar2.Value = 1 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "insert into notif([from],[to],[body],[time],[date]) values('" + CheckBox8.Text + "','BBA HOD','" + txtnotif.Text + "','" + lbltime.Text + "','" + Lbldate.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("notification sent successfully!", MsgBoxStyle.Information, "sent")
                Catch ex As Exception
                    con.Close()
                End Try
            ElseIf TrackBar2.Value = 2 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "insert into notif([from],[to],[body],[time],[date]) values('" + CheckBox8.Text + "','BCOM HOD','" + txtnotif.Text + "','" + lbltime.Text + "','" + Lbldate.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("notification sent successfully!", MsgBoxStyle.Information, "sent")
                Catch ex As Exception
                    con.Close()
                End Try
            ElseIf TrackBar2.Value = 3 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "insert into notif([from],[to],[body],[time],[date]) values('" + CheckBox8.Text + "','STUDENTS','" + txtnotif.Text + "','" + lbltime.Text + "','" + Lbldate.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("notification sent successfully!", MsgBoxStyle.Information, "sent")
                Catch ex As Exception
                    con.Close()
                End Try
            ElseIf TrackBar2.Value = 4 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "insert into notif([from],[to],[body],[time],[date]) values('" + CheckBox8.Text + "','PARENTS','" + txtnotif.Text + "','" + lbltime.Text + "','" + Lbldate.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("notification sent successfully!", MsgBoxStyle.Information, "sent")
                Catch ex As Exception
                    con.Close()
                End Try
            ElseIf TrackBar2.Value = 5 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "insert into notif([from],[to],[body],[time],[date]) values('" + CheckBox8.Text + "','ALL','" + txtnotif.Text + "','" + lbltime.Text + "','" + Lbldate.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("notification sent successfully!", MsgBoxStyle.Information, "sent")
                Catch ex As Exception
                    con.Close()
                End Try
            End If
        End If
        If CheckBox7.CheckState = CheckState.Checked Then
            If CheckBox1.CheckState = CheckState.Checked And TextBox2.Text <> "" Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "insert into notif([from],[to],[body],[time],[date]) values('" + CheckBox7.Text + "','" + TextBox2.Text.Trim + "','" + txtnotif.Text + "','" + lbltime.Text + "','" + Lbldate.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("notification sent successfully!", MsgBoxStyle.Information, "sent")
                Catch ex As Exception
                    con.Close()
                End Try
            ElseIf TrackBar2.Value = 0 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "insert into notif([from],[to],[body],[time],[date]) values('" + CheckBox7.Text + "','BCA HOD','" + txtnotif.Text + "','" + lbltime.Text + "','" + Lbldate.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("notification sent successfully!", MsgBoxStyle.Information, "sent")
                Catch ex As Exception
                    con.Close()
                End Try
            ElseIf TrackBar2.Value = 1 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "insert into notif([from],[to],[body],[time],[date]) values('" + CheckBox7.Text + "','BBA HOD','" + txtnotif.Text + "','" + lbltime.Text + "','" + Lbldate.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("notification sent successfully!", MsgBoxStyle.Information, "sent")
                Catch ex As Exception
                    con.Close()
                End Try
            ElseIf TrackBar2.Value = 2 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "insert into notif([from],[to],[body],[time],[date]) values('" + CheckBox7.Text + "','BCOM HOD','" + txtnotif.Text + "','" + lbltime.Text + "','" + Lbldate.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("notification sent successfully!", MsgBoxStyle.Information, "sent")
                Catch ex As Exception
                    con.Close()
                End Try
            ElseIf TrackBar2.Value = 3 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "insert into notif([from],[to],[body],[time],[date]) values('" + CheckBox7.Text + "','STUDENTS','" + txtnotif.Text + "','" + lbltime.Text + "','" + Lbldate.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("notification sent successfully!", MsgBoxStyle.Information, "sent")
                Catch ex As Exception
                    con.Close()
                End Try
            ElseIf TrackBar2.Value = 4 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "insert into notif([from],[to],[body],[time],[date]) values('" + CheckBox7.Text + "','PARENTS','" + txtnotif.Text + "','" + lbltime.Text + "','" + Lbldate.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("notification sent successfully!", MsgBoxStyle.Information, "sent")
                Catch ex As Exception
                    con.Close()
                End Try
            ElseIf TrackBar2.Value = 5 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "insert into notif([from],[to],[body],[time],[date]) values('" + CheckBox7.Text + "','ALL','" + txtnotif.Text + "','" + lbltime.Text + "','" + Lbldate.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("notification sent successfully!", MsgBoxStyle.Information, "sent")
                Catch ex As Exception
                    con.Close()
                End Try
            End If
        End If
        Button4.PerformClick()
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged
        CheckBox7.Checked = False
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
        CheckBox8.Checked = False
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        TrackBar2.Value = 0
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        TrackBar2.Value = 1
    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        TrackBar2.Value = 2
    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        TrackBar2.Value = 3
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click
        TrackBar2.Value = 4
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        TrackBar2.Value = 5
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            TextBox2.Visible = True
            Panel7.Hide()
        Else
            TextBox2.Visible = False
            Panel7.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub sndnotif_MouseEnter(sender As Object, e As EventArgs) Handles sndnotif.MouseEnter
        If txtnotif.Text.Trim = "" Then
            sndnotif.Visible = False


        End If
    End Sub

    Private Sub sndnotif_MouseLeave(sender As Object, e As EventArgs) Handles sndnotif.MouseLeave
        sndnotif.Visible = True
    End Sub

    Private Sub sndnotif_MouseHover(sender As Object, e As EventArgs) Handles sndnotif.MouseHover
        If txtnotif.Text.Trim = "" Then
            sndnotif.Visible = False
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        Panel8.Show()
        Panel6.Show()
        Panel5.Show()
        loadchart()
        Chart1.Size = New Size(235, 526)
        Chart1.Location = New Point(1045, 60)
        Button5.Visible = True
        Label2.Visible = True
        Labeluser.Visible = True
        TextBoxregno.Visible = True
        Button9.Visible = True
        ComboBox1.SelectedItem = Nothing
        ComboBox4.SelectedItem = Nothing
        ComboBox5.SelectedItem = Nothing
        TextBoxregno.Clear()
    End Sub
    Private Sub loadchart()
        Try
            Dim cnt As Integer = -1
            Dim cnt1 As Integer = -1
            con.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "SELECT Count([RFID]) FROM [students] where Course like '%" + ComboBox1.SelectedItem + "%'  "
            cmd.ExecuteNonQuery()
            cnt = Convert.ToInt32(cmd.ExecuteScalar())
            Dim cmd1 As New SqlCommand
            cmd1.Connection = con
            cmd1.CommandText = "SELECT Count([rfid]) FROM [attend] where Course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "' "
            cmd1.ExecuteNonQuery()
            cnt1 = Convert.ToInt32(cmd1.ExecuteScalar())
            con.Close()
            Chart1.Series.Clear()
            Chart1.Series.Add("atnd")
            Dim atnd As Series = Chart1.Series("atnd")
            atnd.ChartType = SeriesChartType.Pie
            atnd.Name = "Attendance"

            atnd.Points.AddXY("Total " + cnt.ToString, cnt)
            atnd.Points.AddXY("attended " + cnt1.ToString, cnt1)
        Catch ex As Exception
            con.Close()
        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        loadchart()
    End Sub



    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        FlowLayoutPanel4.Controls.Clear()
        If ComboBox1.SelectedItem IsNot Nothing Then
            Try
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                        .Size = New Size(400, 200)
                        .Location = New Point(0, 0)
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .ForeColor = Color.Gainsboro
                        .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                        .BorderStyle = BorderStyle.None
                        .ScrollBars = ScrollBars.Both
                        .Font = New Font("Microsoft Sans Serif", 13)
                    End With
                    With atdpnl
                        .BackColor = Color.FromArgb(34, 33, 74)
                        .Size = New Size(400, 200)
                        .Name = dr2.Item("regno")
                        .Controls.Add(tb)

                    End With
                    FlowLayoutPanel4.Controls.Add(atdpnl)
                    pnlname = atdpnl.Name
                    pnlcount += 1
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
            End Try

        End If
    End Sub

    Private Sub Chart1_MouseEnter(sender As Object, e As EventArgs) Handles Chart1.MouseEnter
        Chart1.Size = New Size(542, 526)
        Chart1.Location = New Point(764, 60)
        Button5.Visible = False
        Label2.Visible = False
        Labeluser.Visible = False
        TextBoxregno.Visible = False
        Button9.Visible = False

    End Sub

    Private Sub Chart1_MouseLeave(sender As Object, e As EventArgs) Handles Chart1.MouseLeave
        Chart1.Size = New Size(235, 526)
        Chart1.Location = New Point(1045, 60)
        Button5.Visible = True
        Label2.Visible = True
        Labeluser.Visible = True
        TextBoxregno.Visible = True
        Button9.Visible = True
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        If CheckBox2.CheckState = CheckState.Checked Then
            If ComboBox4.SelectedItem IsNot Nothing And ComboBox5.SelectedItem IsNot Nothing And ComboBox1.SelectedItem IsNot Nothing Then
                If ComboBox5.SelectedIndex = 0 Then
                    Try
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "update attend set hour1=('" + CheckBox2.Text + "') where sem like '%" + ComboBox4.SelectedItem + "%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                                .Size = New Size(400, 200)
                                .Location = New Point(0, 0)
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .ForeColor = Color.Gainsboro
                                .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                                .BorderStyle = BorderStyle.None
                                .ScrollBars = ScrollBars.Both
                                .Font = New Font("Microsoft Sans Serif", 13)
                            End With
                            With atdpnl
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .Size = New Size(400, 200)
                                .Name = dr2.Item("regno")
                                .Controls.Add(tb)

                            End With
                            FlowLayoutPanel4.Controls.Add(atdpnl)
                            pnlname = atdpnl.Name
                            pnlcount += 1
                        End While
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                    End Try

                ElseIf ComboBox5.SelectedIndex = 1 Then
                    Try
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "update attend set hour2=('" + CheckBox2.Text + "') where sem like '%" + ComboBox4.SelectedItem + "%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                                .Size = New Size(400, 200)
                                .Location = New Point(0, 0)
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .ForeColor = Color.Gainsboro
                                .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                                .BorderStyle = BorderStyle.None
                                .ScrollBars = ScrollBars.Both
                                .Font = New Font("Microsoft Sans Serif", 13)
                            End With
                            With atdpnl
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .Size = New Size(400, 200)
                                .Name = dr2.Item("regno")
                                .Controls.Add(tb)

                            End With
                            FlowLayoutPanel4.Controls.Add(atdpnl)
                            pnlname = atdpnl.Name
                            pnlcount += 1
                        End While
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                    End Try

                ElseIf ComboBox5.SelectedIndex = 2 Then
                    Try
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "update attend set hour3=('" + CheckBox2.Text + "') where sem like '%" + ComboBox4.SelectedItem + "%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                                .Size = New Size(400, 200)
                                .Location = New Point(0, 0)
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .ForeColor = Color.Gainsboro
                                .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                                .BorderStyle = BorderStyle.None
                                .ScrollBars = ScrollBars.Both
                                .Font = New Font("Microsoft Sans Serif", 13)
                            End With
                            With atdpnl
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .Size = New Size(400, 200)
                                .Name = dr2.Item("regno")
                                .Controls.Add(tb)

                            End With
                            FlowLayoutPanel4.Controls.Add(atdpnl)
                            pnlname = atdpnl.Name
                            pnlcount += 1
                        End While
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                    End Try

                ElseIf ComboBox5.SelectedIndex = 3 Then
                    Try
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "update attend set hour4=('" + CheckBox2.Text + "') where sem like '%" + ComboBox4.SelectedItem + "%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                                .Size = New Size(400, 200)
                                .Location = New Point(0, 0)
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .ForeColor = Color.Gainsboro
                                .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                                .BorderStyle = BorderStyle.None
                                .ScrollBars = ScrollBars.Both
                                .Font = New Font("Microsoft Sans Serif", 13)
                            End With
                            With atdpnl
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .Size = New Size(400, 200)
                                .Name = dr2.Item("regno")
                                .Controls.Add(tb)

                            End With
                            FlowLayoutPanel4.Controls.Add(atdpnl)
                            pnlname = atdpnl.Name
                            pnlcount += 1
                        End While
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                    End Try

                ElseIf ComboBox5.SelectedIndex = 4 Then
                    Try
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "update attend set hour5=('" + CheckBox2.Text + "') where sem like '%" + ComboBox4.SelectedItem + "%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                                .Size = New Size(400, 200)
                                .Location = New Point(0, 0)
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .ForeColor = Color.Gainsboro
                                .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                                .BorderStyle = BorderStyle.None
                                .ScrollBars = ScrollBars.Both
                                .Font = New Font("Microsoft Sans Serif", 13)
                            End With
                            With atdpnl
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .Size = New Size(400, 200)
                                .Name = dr2.Item("regno")
                                .Controls.Add(tb)

                            End With
                            FlowLayoutPanel4.Controls.Add(atdpnl)
                            pnlname = atdpnl.Name
                            pnlcount += 1
                        End While
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                    End Try

                ElseIf ComboBox5.SelectedIndex = 5 Then
                    Try
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "update attend set hour6=('" + CheckBox2.Text + "') where sem like '%" + ComboBox4.SelectedItem + "%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                                .Size = New Size(400, 200)
                                .Location = New Point(0, 0)
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .ForeColor = Color.Gainsboro
                                .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                                .BorderStyle = BorderStyle.None
                                .ScrollBars = ScrollBars.Both
                                .Font = New Font("Microsoft Sans Serif", 13)
                            End With
                            With atdpnl
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .Size = New Size(400, 200)
                                .Name = dr2.Item("regno")
                                .Controls.Add(tb)

                            End With
                            FlowLayoutPanel4.Controls.Add(atdpnl)
                            pnlname = atdpnl.Name
                            pnlcount += 1
                        End While
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                    End Try

                End If
            End If
        ElseIf CheckBox3.CheckState = CheckState.Checked Then
            If ComboBox4.SelectedItem IsNot Nothing And ComboBox5.SelectedItem IsNot Nothing And ComboBox1.SelectedItem IsNot Nothing Then
                If ComboBox5.SelectedIndex = 0 Then
                    Try
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "update attend set hour1=('" + CheckBox3.Text + "') where sem like '%" + ComboBox4.SelectedItem + "%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                                .Size = New Size(400, 200)
                                .Location = New Point(0, 0)
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .ForeColor = Color.Gainsboro
                                .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                                .BorderStyle = BorderStyle.None
                                .ScrollBars = ScrollBars.Both
                                .Font = New Font("Microsoft Sans Serif", 13)
                            End With
                            With atdpnl
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .Size = New Size(400, 200)
                                .Name = dr2.Item("regno")
                                .Controls.Add(tb)

                            End With
                            FlowLayoutPanel4.Controls.Add(atdpnl)
                            pnlname = atdpnl.Name
                            pnlcount += 1
                        End While
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                    End Try


                ElseIf ComboBox5.SelectedIndex = 1 Then
                    Try
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "update attend set hour2=('" + CheckBox3.Text + "') where sem like '%" + ComboBox4.SelectedItem + "%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                                .Size = New Size(400, 200)
                                .Location = New Point(0, 0)
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .ForeColor = Color.Gainsboro
                                .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                                .BorderStyle = BorderStyle.None
                                .ScrollBars = ScrollBars.Both
                                .Font = New Font("Microsoft Sans Serif", 13)
                            End With
                            With atdpnl
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .Size = New Size(400, 200)
                                .Name = dr2.Item("regno")
                                .Controls.Add(tb)

                            End With
                            FlowLayoutPanel4.Controls.Add(atdpnl)
                            pnlname = atdpnl.Name
                            pnlcount += 1
                        End While
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                    End Try


                ElseIf ComboBox5.SelectedIndex = 2 Then
                    Try
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "update attend set hour3=('" + CheckBox3.Text + "') where sem like '%" + ComboBox4.SelectedItem + "%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                                .Size = New Size(400, 200)
                                .Location = New Point(0, 0)
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .ForeColor = Color.Gainsboro
                                .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                                .BorderStyle = BorderStyle.None
                                .ScrollBars = ScrollBars.Both
                                .Font = New Font("Microsoft Sans Serif", 13)
                            End With
                            With atdpnl
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .Size = New Size(400, 200)
                                .Name = dr2.Item("regno")
                                .Controls.Add(tb)

                            End With
                            FlowLayoutPanel4.Controls.Add(atdpnl)
                            pnlname = atdpnl.Name
                            pnlcount += 1
                        End While
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                    End Try


                ElseIf ComboBox5.SelectedIndex = 3 Then
                    Try
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "update attend set hour4=('" + CheckBox3.Text + "') where sem like '%" + ComboBox4.SelectedItem + "%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                                .Size = New Size(400, 200)
                                .Location = New Point(0, 0)
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .ForeColor = Color.Gainsboro
                                .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                                .BorderStyle = BorderStyle.None
                                .ScrollBars = ScrollBars.Both
                                .Font = New Font("Microsoft Sans Serif", 13)
                            End With
                            With atdpnl
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .Size = New Size(400, 200)
                                .Name = dr2.Item("regno")
                                .Controls.Add(tb)

                            End With
                            FlowLayoutPanel4.Controls.Add(atdpnl)
                            pnlname = atdpnl.Name
                            pnlcount += 1
                        End While
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                    End Try


                ElseIf ComboBox5.SelectedIndex = 4 Then
                    Try
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "update attend set hour5=('" + CheckBox3.Text + "') where sem like '%" + ComboBox4.SelectedItem + "%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                                .Size = New Size(400, 200)
                                .Location = New Point(0, 0)
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .ForeColor = Color.Gainsboro
                                .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                                .BorderStyle = BorderStyle.None
                                .ScrollBars = ScrollBars.Both
                                .Font = New Font("Microsoft Sans Serif", 13)
                            End With
                            With atdpnl
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .Size = New Size(400, 200)
                                .Name = dr2.Item("regno")
                                .Controls.Add(tb)

                            End With
                            FlowLayoutPanel4.Controls.Add(atdpnl)
                            pnlname = atdpnl.Name
                            pnlcount += 1
                        End While
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                    End Try


                ElseIf ComboBox5.SelectedIndex = 5 Then
                    Try
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "update attend set hour6=('" + CheckBox3.Text + "') where sem like '%" + ComboBox4.SelectedItem + "%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                                .Size = New Size(400, 200)
                                .Location = New Point(0, 0)
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .ForeColor = Color.Gainsboro
                                .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                                .BorderStyle = BorderStyle.None
                                .ScrollBars = ScrollBars.Both
                                .Font = New Font("Microsoft Sans Serif", 13)
                            End With
                            With atdpnl
                                .BackColor = Color.FromArgb(34, 33, 74)
                                .Size = New Size(400, 200)
                                .Name = dr2.Item("regno")
                                .Controls.Add(tb)

                            End With
                            FlowLayoutPanel4.Controls.Add(atdpnl)
                            pnlname = atdpnl.Name
                            pnlcount += 1
                        End While
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                    End Try

                End If
            End If
        End If

    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If ComboBox4.SelectedItem IsNot Nothing And ComboBox5.SelectedItem IsNot Nothing And ComboBox1.SelectedItem IsNot Nothing Then
            If ComboBox5.SelectedIndex = 0 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "update attend set hour1=NULL where  date like '" + Date.Today + "' and regno like'%" + TextBoxregno.Text.Trim + "%'"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Mrked as absent for" + TextBoxregno.Text, MsgBoxStyle.Information, "marked")

                    FlowLayoutPanel4.Controls.Clear()
                    con.Open()
                    Dim cmd1 As New SqlCommand
                    Dim dr2 As SqlDataReader
                    cmd1.Connection = con
                    cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                            .Size = New Size(400, 200)
                            .Location = New Point(0, 0)
                            .BackColor = Color.FromArgb(34, 33, 74)
                            .ForeColor = Color.Gainsboro
                            .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                            .BorderStyle = BorderStyle.None
                            .ScrollBars = ScrollBars.Both
                            .Font = New Font("Microsoft Sans Serif", 13)
                        End With
                        With atdpnl
                            .BackColor = Color.FromArgb(34, 33, 74)
                            .Size = New Size(400, 200)
                            .Name = dr2.Item("regno")
                            .Controls.Add(tb)

                        End With
                        FlowLayoutPanel4.Controls.Add(atdpnl)
                        pnlname = atdpnl.Name
                        pnlcount += 1
                    End While
                    con.Close()
                Catch ex As Exception
                    con.Close()
                End Try


            ElseIf ComboBox5.SelectedIndex = 1 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "update attend set hour2=NULL where  date like '" + Date.Today + "' and regno like'%" + TextBoxregno.Text.Trim + "%'"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Mrked as absent for" + TextBoxregno.Text, MsgBoxStyle.Information, "marked")

                    FlowLayoutPanel4.Controls.Clear()
                    con.Open()
                    Dim cmd1 As New SqlCommand
                    Dim dr2 As SqlDataReader
                    cmd1.Connection = con
                    cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                            .Size = New Size(400, 200)
                            .Location = New Point(0, 0)
                            .BackColor = Color.FromArgb(34, 33, 74)
                            .ForeColor = Color.Gainsboro
                            .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                            .BorderStyle = BorderStyle.None
                            .ScrollBars = ScrollBars.Both
                            .Font = New Font("Microsoft Sans Serif", 13)
                        End With
                        With atdpnl
                            .BackColor = Color.FromArgb(34, 33, 74)
                            .Size = New Size(400, 200)
                            .Name = dr2.Item("regno")
                            .Controls.Add(tb)

                        End With
                        FlowLayoutPanel4.Controls.Add(atdpnl)
                        pnlname = atdpnl.Name
                        pnlcount += 1
                    End While
                    con.Close()
                Catch ex As Exception
                    con.Close()
                End Try


            ElseIf ComboBox5.SelectedIndex = 2 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "update attend set hour3=NULL where  date like '" + Date.Today + "' and regno like'%" + TextBoxregno.Text.Trim + "%'"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Mrked as absent for" + TextBoxregno.Text, MsgBoxStyle.Information, "marked")

                    FlowLayoutPanel4.Controls.Clear()
                    con.Open()
                    Dim cmd1 As New SqlCommand
                    Dim dr2 As SqlDataReader
                    cmd1.Connection = con
                    cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                            .Size = New Size(400, 200)
                            .Location = New Point(0, 0)
                            .BackColor = Color.FromArgb(34, 33, 74)
                            .ForeColor = Color.Gainsboro
                            .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                            .BorderStyle = BorderStyle.None
                            .ScrollBars = ScrollBars.Both
                            .Font = New Font("Microsoft Sans Serif", 13)
                        End With
                        With atdpnl
                            .BackColor = Color.FromArgb(34, 33, 74)
                            .Size = New Size(400, 200)
                            .Name = dr2.Item("regno")
                            .Controls.Add(tb)

                        End With
                        FlowLayoutPanel4.Controls.Add(atdpnl)
                        pnlname = atdpnl.Name
                        pnlcount += 1
                    End While
                    con.Close()
                Catch ex As Exception
                    con.Close()
                End Try


            ElseIf ComboBox5.SelectedIndex = 3 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "update attend set hour4=NULL where  date like '" + Date.Today + "' and regno like'%" + TextBoxregno.Text.Trim + "%'"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Mrked as absent for" + TextBoxregno.Text, MsgBoxStyle.Information, "marked")

                    FlowLayoutPanel4.Controls.Clear()
                    con.Open()
                    Dim cmd1 As New SqlCommand
                    Dim dr2 As SqlDataReader
                    cmd1.Connection = con
                    cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                            .Size = New Size(400, 200)
                            .Location = New Point(0, 0)
                            .BackColor = Color.FromArgb(34, 33, 74)
                            .ForeColor = Color.Gainsboro
                            .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                            .BorderStyle = BorderStyle.None
                            .ScrollBars = ScrollBars.Both
                            .Font = New Font("Microsoft Sans Serif", 13)
                        End With
                        With atdpnl
                            .BackColor = Color.FromArgb(34, 33, 74)
                            .Size = New Size(400, 200)
                            .Name = dr2.Item("regno")
                            .Controls.Add(tb)

                        End With
                        FlowLayoutPanel4.Controls.Add(atdpnl)
                        pnlname = atdpnl.Name
                        pnlcount += 1
                    End While
                    con.Close()
                Catch ex As Exception
                    con.Close()
                End Try


            ElseIf ComboBox5.SelectedIndex = 4 Then
                Try

                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "update attend set hour5=NULL where  date like '" + Date.Today + "' and regno like'%" + TextBoxregno.Text.Trim + "%'"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Mrked as absent for" + TextBoxregno.Text, MsgBoxStyle.Information, "marked")

                    FlowLayoutPanel4.Controls.Clear()
                    con.Open()
                    Dim cmd1 As New SqlCommand
                    Dim dr2 As SqlDataReader
                    cmd1.Connection = con
                    cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                            .Size = New Size(400, 200)
                            .Location = New Point(0, 0)
                            .BackColor = Color.FromArgb(34, 33, 74)
                            .ForeColor = Color.Gainsboro
                            .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                            .BorderStyle = BorderStyle.None
                            .ScrollBars = ScrollBars.Both
                            .Font = New Font("Microsoft Sans Serif", 13)
                        End With
                        With atdpnl
                            .BackColor = Color.FromArgb(34, 33, 74)
                            .Size = New Size(400, 200)
                            .Name = dr2.Item("regno")
                            .Controls.Add(tb)

                        End With
                        FlowLayoutPanel4.Controls.Add(atdpnl)
                        pnlname = atdpnl.Name
                        pnlcount += 1
                    End While
                    con.Close()
                Catch ex As Exception
                    con.Close()
                End Try

            ElseIf ComboBox5.SelectedIndex = 5 Then
                Try
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "update attend set hour6=NULL where  date like '" + Date.Today + "' and regno like'%" + TextBoxregno.Text.Trim + "%'"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Mrked as absent for" + TextBoxregno.Text, MsgBoxStyle.Information, "marked")

                    FlowLayoutPanel4.Controls.Clear()
                    con.Open()
                    Dim cmd1 As New SqlCommand
                    Dim dr2 As SqlDataReader
                    cmd1.Connection = con
                    cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('" + ComboBox4.SelectedItem + "') and course like '%" + ComboBox1.SelectedItem + "%' and date like '" + Date.Today + "'"
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
                            .Size = New Size(400, 200)
                            .Location = New Point(0, 0)
                            .BackColor = Color.FromArgb(34, 33, 74)
                            .ForeColor = Color.Gainsboro
                            .Text = "NAME: " + dr2.Item("NAME").ToString.Trim & vbCrLf & "REGNO: " + dr2.Item("regno").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "IN TIME: " + dr2.Item("intime").ToString.Trim & vbCrLf & "HOUR1: " + dr2.Item("hour1").ToString.Trim & vbCrLf & "HOUR2: " + dr2.Item("hour2").ToString.Trim & vbCrLf & "HOUR3: " + dr2.Item("hour3").ToString.Trim & vbCrLf & "HOUR4: " + dr2.Item("hour4").ToString.Trim & vbCrLf & "HOUR5: " + dr2.Item("hour5").ToString.Trim & vbCrLf & "HOUR6: " + dr2.Item("hour6").ToString.Trim
                            .BorderStyle = BorderStyle.None
                            .ScrollBars = ScrollBars.Both
                            .Font = New Font("Microsoft Sans Serif", 13)
                        End With
                        With atdpnl
                            .BackColor = Color.FromArgb(34, 33, 74)
                            .Size = New Size(400, 200)
                            .Name = dr2.Item("regno")
                            .Controls.Add(tb)

                        End With
                        FlowLayoutPanel4.Controls.Add(atdpnl)
                        pnlname = atdpnl.Name
                        pnlcount += 1
                    End While
                    con.Close()
                Catch ex As Exception
                    con.Close()
                End Try

            End If
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.CheckState = CheckState.Checked Then
            CheckBox3.CheckState = CheckState.Unchecked

        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.CheckState = CheckState.Checked Then
            CheckBox2.CheckState = CheckState.Unchecked

        End If
    End Sub
End Class
