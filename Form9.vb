Imports System.Data.SqlClient
Imports System.Threading
Imports System.Net.Mail
Imports System.Windows.Forms.DataVisualization.Charting
Public Class Form9
    Dim dept As String = Nothing
    Dim class1 As String = Nothing
    Dim class2 As String = Nothing
    Dim post As String = Nothing
    Private curpnlname As String = Nothing
    Private curpnlcnt As Integer = 0
    Dim pic As PictureBox
    Private WithEvents contactpanel As Panel
    Private WithEvents contactpanel2 As Panel
    Private WithEvents contactpanel3 As Panel
    Private WithEvents contactpanel4 As Panel
    Dim mlttb As TextBox
    Dim lbl As Label
    Dim name1 As String = Nothing
    Dim buttonhp As Panel
    Dim currbtn As Button
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub TextBoxrfid_LostFocus(sender As Object, e As EventArgs) Handles TextBoxrfid.LostFocus
        Try
            con.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select department,class1,class2,post,name from staff where rfid=('" + TextBoxrfid.Text + "') "
            cmd.CommandType = CommandType.Text
            Dim sdr27 As SqlDataReader = cmd.ExecuteReader()
            sdr27.Read()
            post = sdr27("post").ToString.Trim
            class1 = sdr27("class1").ToString.Trim
            class2 = sdr27("class2").ToString.Trim
            If post = "Lecturer" Then
                If class1 <> "" Or class2 <> "" Then
                    Panel1.Enabled = True
                    Threading.Thread.Sleep(10)
                    Students.PerformClick()
                    Students.PerformClick()
                    ComboBox4.Items.Add(class1)
                    ComboBox4.Items.Add(class2)
                    ComboBox1.Items.Add(class1)
                    ComboBox1.Items.Add(class2)
                    dept = sdr27("department").ToString.Trim
                    name1 = sdr27("name").ToString.Trim
                End If
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
    End Sub
    Private Sub TextBoxrfid_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxrfid.KeyDown
        If e.KeyCode = Keys.Enter Then
            PictureBox1.Focus()
        End If
    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles Me.Load
        Panel1.Enabled = False
        Me.ActiveControl = TextBoxrfid
        Panel4.Hide()
        Lbldate.Text = Date.Today
    End Sub

    Private Sub Students_Click(sender As Object, e As EventArgs) Handles Students.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        Panel4.Show()
        HODP.Show()
        Panel3.Hide()
        Panel5.Hide()
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        FlowLayoutPanel5.Controls.Clear()
        GC.Collect()
        Cursor = Cursors.Default
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        FlowLayoutPanel5.Controls.Clear()
        GC.Collect()
        Panel3.Show()
        Panel4.Show()
        HODP.Show()
        Panel5.Hide()

        FlowLayoutPanel3.Controls.Clear()
        GC.Collect()

        If dept = "BCA" Then
            Try
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr23 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select [to],[from],[body],[date],[time] from notifbca  order by date desc"
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
        ElseIf dept = "BBA" Then

            Try
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr23 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select [to],[from],[body],[date],[time] from notifbba  order by date desc"
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
        ElseIf dept = "BCOM" Then
            Try
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr23 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select [to],[from],[body],[date],[time] from notifbcom  order by date desc"
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
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        activatebutton(sender, customclour:=Color.Gainsboro)

        Panel3.Show()
        Panel4.Show()
        HODP.Show()
        Panel5.Show()
        FlowLayoutPanel7.Controls.Clear()
        GC.Collect()
        FlowLayoutPanel5.Controls.Clear()
        GC.Collect()
        FlowLayoutPanel3.Controls.Clear()
        GC.Collect()
        If dept = "BCA" Then
            Try
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr23 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select [to],[subject],[body],[date],[time] from mailbca order by date desc"
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
                    FlowLayoutPanel7.Controls.Add(contactpanel3)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        ElseIf dept = "BBA" Then
            Try
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr23 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select [to],[subject],[body],[date],[time] from mailbba order by date desc"
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
                    FlowLayoutPanel7.Controls.Add(contactpanel3)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        ElseIf dept = "BCOM" Then
            Try
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr23 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select [to],[subject],[body],[date],[time] from mailbcom order by date desc"
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
                    FlowLayoutPanel7.Controls.Add(contactpanel3)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        Panel4.Show()
        HODP.Hide()
        loadchart()
        Panel5.Hide()
        Chart1.Size = New Size(300, 528)
        Chart1.Location = New Point(1039, 46)
        Button5.Visible = True
        Label13.Visible = True
        Labeluser.Visible = True
        TextBoxregno.Visible = True
        Button9.Visible = True
    End Sub
    Private Sub Chart1_MouseEnter(sender As Object, e As EventArgs) Handles Chart1.MouseEnter
        Chart1.Size = New Size(652, 528)
        Chart1.Location = New Point(628, 37)
        Button5.Visible = False
        Label13.Visible = False
        Labeluser.Visible = False
        TextBoxregno.Visible = False
        Button9.Visible = False

    End Sub

    Private Sub Chart1_MouseLeave(sender As Object, e As EventArgs) Handles Chart1.MouseLeave
        Chart1.Size = New Size(300, 528)
        Chart1.Location = New Point(1039, 46)
        Button5.Visible = True
        Label13.Visible = True
        Labeluser.Visible = True
        TextBoxregno.Visible = True
        Button9.Visible = True
    End Sub
    Private Sub loadchart()
        If class1 = "1st sem" Or class2 = "1st sem" Then
            Try
                Dim cnt As Integer = -1
                Dim cnt1 As Integer = -1
                con.Open()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "SELECT Count([RFID]) FROM [students] where Course like '%" + dept + "%' and sem='1' "
                cmd.ExecuteNonQuery()
                cnt = Convert.ToInt32(cmd.ExecuteScalar())
                Dim cmd1 As New SqlCommand
                cmd1.Connection = con
                cmd1.CommandText = "SELECT Count([rfid]) FROM [attend] where Course like '%" + dept + "%' and date like '" + Date.Today + "' and sem=1  "
                cmd1.ExecuteNonQuery()
                cnt1 = Convert.ToInt32(cmd1.ExecuteScalar())
                con.Close()
                Chart1.Series.Clear()
                Chart1.Series.Add("atnd")
                Dim atnd As Series = Chart1.Series("atnd")
                atnd.ChartType = SeriesChartType.Pie
                atnd.Name = "attendance"
                atnd.Points.AddXY("Total " + cnt.ToString, cnt)
                atnd.Points.AddXY("attended " + cnt1.ToString, cnt1)
            Catch ex As Exception
                con.Close()
            End Try
        ElseIf class1 = "2nd sem" Or class2 = "2nd sem" Then
            Try
                Dim cnt As Integer = -1
                Dim cnt1 As Integer = -1
                con.Open()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "SELECT Count([RFID]) FROM [students] where Course like '%" + dept + "%' and sem='2' "
                cmd.ExecuteNonQuery()
                cnt = Convert.ToInt32(cmd.ExecuteScalar())
                Dim cmd1 As New SqlCommand
                cmd1.Connection = con
                cmd1.CommandText = "SELECT Count([rfid]) FROM [attend] where Course like '%" + dept + "%' and date like '" + Date.Today + "' and sem='2'  "
                cmd1.ExecuteNonQuery()
                cnt1 = Convert.ToInt32(cmd1.ExecuteScalar())
                con.Close()
                Chart1.Series.Clear()
                Chart1.Series.Add("atnd")
                Dim atnd As Series = Chart1.Series("atnd")
                atnd.ChartType = SeriesChartType.Pie
                atnd.Name = "attendance"
                atnd.Points.AddXY("Total " + cnt.ToString, cnt)
                atnd.Points.AddXY("attended " + cnt1.ToString, cnt1)
            Catch ex As Exception
                con.Close()
            End Try
        ElseIf class1 = "3rd sem" Or class2 = "3rd sem" Then
            Try
                Dim cnt As Integer = -1
                Dim cnt1 As Integer = -1
                con.Open()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "SELECT Count([RFID]) FROM [students] where Course like '%" + dept + "%' and sem='3' "
                cmd.ExecuteNonQuery()
                cnt = Convert.ToInt32(cmd.ExecuteScalar())
                Dim cmd1 As New SqlCommand
                cmd1.Connection = con
                cmd1.CommandText = "SELECT Count([rfid]) FROM [attend] where Course like '%" + dept + "%' and date like '" + Date.Today + "' and sem='3'  "
                cmd1.ExecuteNonQuery()
                cnt1 = Convert.ToInt32(cmd1.ExecuteScalar())
                con.Close()
                Chart1.Series.Clear()
                Chart1.Series.Add("atnd")
                Dim atnd As Series = Chart1.Series("atnd")
                atnd.ChartType = SeriesChartType.Pie
                atnd.Name = "attendance"
                atnd.Points.AddXY("Total " + cnt.ToString, cnt)
                atnd.Points.AddXY("attended " + cnt1.ToString, cnt1)
            Catch ex As Exception
                con.Close()
            End Try
        ElseIf class1 = "4th sem" Or class2 = "4th sem" Then
            Try
                Dim cnt As Integer = -1
                Dim cnt1 As Integer = -1
                con.Open()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "SELECT Count([RFID]) FROM [students] where Course like '%" + dept + "%' and sem='4' "
                cmd.ExecuteNonQuery()
                cnt = Convert.ToInt32(cmd.ExecuteScalar())
                Dim cmd1 As New SqlCommand
                cmd1.Connection = con
                cmd1.CommandText = "SELECT Count([rfid]) FROM [attend] where Course like '%" + dept + "%' and date like '" + Date.Today + "' and sem='4'  "
                cmd1.ExecuteNonQuery()
                cnt1 = Convert.ToInt32(cmd1.ExecuteScalar())
                con.Close()
                Chart1.Series.Clear()
                Chart1.Series.Add("atnd")
                Dim atnd As Series = Chart1.Series("atnd")
                atnd.ChartType = SeriesChartType.Pie
                atnd.Name = "attendance"
                atnd.Points.AddXY("Total " + cnt.ToString, cnt)
                atnd.Points.AddXY("attended " + cnt1.ToString, cnt1)
            Catch ex As Exception
                con.Close()
            End Try
        ElseIf class1 = "5th sem" Or class2 = "5th sem" Then
            Try
                Dim cnt As Integer = -1
                Dim cnt1 As Integer = -1
                con.Open()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "SELECT Count([RFID]) FROM [students] where Course like '%" + dept + "%' and sem='5' "
                cmd.ExecuteNonQuery()
                cnt = Convert.ToInt32(cmd.ExecuteScalar())
                Dim cmd1 As New SqlCommand
                cmd1.Connection = con
                cmd1.CommandText = "SELECT Count([rfid]) FROM [attend] where Course like '%" + dept + "%' and date like '" + Date.Today + "' and sem='5'  "
                cmd1.ExecuteNonQuery()
                cnt1 = Convert.ToInt32(cmd1.ExecuteScalar())
                con.Close()
                Chart1.Series.Clear()
                Chart1.Series.Add("atnd")
                Dim atnd As Series = Chart1.Series("atnd")
                atnd.ChartType = SeriesChartType.Pie
                atnd.Name = "attendance"
                atnd.Points.AddXY("Total " + cnt.ToString, cnt)
                atnd.Points.AddXY("attended " + cnt1.ToString, cnt1)
            Catch ex As Exception
                con.Close()
            End Try
        ElseIf class1 = "6th sem" Or class2 = "6th sem" Then
            Try
                Dim cnt As Integer = -1
                Dim cnt1 As Integer = -1
                con.Open()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "SELECT Count([RFID]) FROM [students] where Course like '%" + dept + "%' and sem='6' "
                cmd.ExecuteNonQuery()
                cnt = Convert.ToInt32(cmd.ExecuteScalar())
                Dim cmd1 As New SqlCommand
                cmd1.Connection = con
                cmd1.CommandText = "SELECT Count([rfid]) FROM [attend] where Course like '%" + dept + "%' and date like '" + Date.Today + "' and sem='6'  "
                cmd1.ExecuteNonQuery()
                cnt1 = Convert.ToInt32(cmd1.ExecuteScalar())
                con.Close()
                Chart1.Series.Clear()
                Chart1.Series.Add("atnd")
                Dim atnd As Series = Chart1.Series("atnd")
                atnd.ChartType = SeriesChartType.Pie
                atnd.Name = "attendance"
                atnd.Points.AddXY("Total " + cnt.ToString, cnt)
                atnd.Points.AddXY("attended " + cnt1.ToString, cnt1)
            Catch ex As Exception
                con.Close()
            End Try
        End If


    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        If ComboBox4.SelectedItem = "1st sem" Then
            Try
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem='1' and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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

        ElseIf ComboBox4.SelectedItem = "2nd sem" Then
            Try
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem='2' and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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

        ElseIf ComboBox4.SelectedItem = "3rd sem" Then
            Try
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem='3' and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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

        ElseIf ComboBox4.SelectedItem = "4th sem" Then
            Try
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem='4' and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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

        ElseIf ComboBox4.SelectedItem = "5th sem" Then
            Try
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem='5' and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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

        ElseIf ComboBox4.SelectedItem = "6th sem" Then
            Try
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem='6' and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        If ComboBox4.SelectedItem = "1st sem" Then
            If ComboBox4.SelectedItem IsNot Nothing And ComboBox5.SelectedItem IsNot Nothing Then
                If ComboBox5.SelectedIndex = 0 Then
                    Try
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "update attend set hour1=('" + name1 + "') where sem like '%1%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('1') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour2=('" + name1 + "') where sem like '%1%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('1') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour3=('" + name1 + "') where sem like '%1%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('1') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour4=('" + name1 + "') where sem like '%1%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('1') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour5=('" + name1 + "') where sem like '%1%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('1') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour6=('" + name1 + "') where sem like '%1%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('1') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
        ElseIf ComboBox4.SelectedItem = "2nd sem" Then
            If ComboBox4.SelectedItem IsNot Nothing And ComboBox5.SelectedItem IsNot Nothing Then
                If ComboBox5.SelectedIndex = 0 Then
                    Try
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "update attend set hour1=('" + name1 + "') where sem like '%2%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('2') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour2=('" + name1 + "') where sem like '%2%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('2') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour3=('" + name1 + "') where sem like '%2%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('2') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour4=('" + name1 + "') where sem like '%2%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('2') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour5=('" + name1 + "') where sem like '%2%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('2') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour6=('" + name1 + "') where sem like '%2%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('2') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
        ElseIf ComboBox4.SelectedItem = "3rd sem" Then
            If ComboBox4.SelectedItem IsNot Nothing And ComboBox5.SelectedItem IsNot Nothing Then
                If ComboBox5.SelectedIndex = 0 Then
                    Try
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "update attend set hour1=('" + name1 + "') where sem like '%3%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('3') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour2=('" + name1 + "') where sem like '%3%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('3') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour3=('" + name1 + "') where sem like '%3%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('3') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour4=('" + name1 + "') where sem like '%3%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('3') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour5=('" + name1 + "') where sem like '%3%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('3') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour6=('" + name1 + "') where sem like '%3%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('3') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
        ElseIf ComboBox4.SelectedItem = "4th sem" Then
            If ComboBox4.SelectedItem IsNot Nothing And ComboBox5.SelectedItem IsNot Nothing Then
                If ComboBox5.SelectedIndex = 0 Then
                    Try
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "update attend set hour1=('" + name1 + "') where sem like '%4%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('4') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour2=('" + name1 + "') where sem like '%4%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('4') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour3=('" + name1 + "') where sem like '%4%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('4') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour4=('" + name1 + "') where sem like '%4%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('4') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour5=('" + name1 + "') where sem like '%4%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('4') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour6=('" + name1 + "') where sem like '%4%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('4') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
        ElseIf ComboBox4.SelectedItem = "5th sem" Then
            If ComboBox4.SelectedItem IsNot Nothing And ComboBox5.SelectedItem IsNot Nothing Then
                If ComboBox5.SelectedIndex = 0 Then
                    Try
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "update attend set hour1=('" + name1 + "') where sem like '%5%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('5') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour2=('" + name1 + "') where sem like '%5%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('5') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour3=('" + name1 + "') where sem like '%5%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('5') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour4=('" + name1 + "') where sem like '%5%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('5') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour5=('" + name1 + "') where sem like '%5%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('5') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour6=('" + name1 + "') where sem like '%5%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('5') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
        ElseIf ComboBox4.SelectedItem = "6th sem" Then
            If ComboBox4.SelectedItem IsNot Nothing And ComboBox5.SelectedItem IsNot Nothing Then
                If ComboBox5.SelectedIndex = 0 Then
                    Try
                        con.Open()
                        Dim cmd As New SqlCommand
                        cmd.Connection = con
                        cmd.CommandText = "update attend set hour1=('" + name1 + "') where sem like '%6%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('6') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour2=('" + name1 + "') where sem like '%6%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('6') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour3=('" + name1 + "') where sem like '%6%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('6') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour4=('" + name1 + "') where sem like '%6%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('6') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour5=('" + name1 + "') where sem like '%6%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('6') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd.CommandText = "update attend set hour6=('" + name1 + "') where sem like '%6%' and date like '" + Date.Today + "' "
                        cmd.ExecuteNonQuery()
                        con.Close()
                        MsgBox("Mrked all as present for" + ComboBox5.SelectedItem.ToString, MsgBoxStyle.Information, "marked")

                        FlowLayoutPanel4.Controls.Clear()
                        con.Open()
                        Dim cmd1 As New SqlCommand
                        Dim dr2 As SqlDataReader
                        cmd1.Connection = con
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('6') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If ComboBox4.SelectedItem = "1st sem" Then
            If ComboBox4.SelectedItem IsNot Nothing And ComboBox5.SelectedItem IsNot Nothing Then
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('1') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('1') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('1') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('1') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('1') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('1') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
        ElseIf ComboBox4.SelectedItem = "2nd sem" Then
            If ComboBox4.SelectedItem IsNot Nothing And ComboBox5.SelectedItem IsNot Nothing Then
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('2') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('2') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('2') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('2') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('2') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('2') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
        ElseIf ComboBox4.SelectedItem = "3rd sem" Then
            If ComboBox4.SelectedItem IsNot Nothing And ComboBox5.SelectedItem IsNot Nothing Then
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('3') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('3') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('3') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('3') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('3') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('3') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
        ElseIf ComboBox4.SelectedItem = "4th sem" Then

            If ComboBox4.SelectedItem IsNot Nothing And ComboBox5.SelectedItem IsNot Nothing Then
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('4') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('4') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('4') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('4') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('4') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('4') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
        ElseIf ComboBox4.SelectedItem = "5th sem" Then
            If ComboBox4.SelectedItem IsNot Nothing And ComboBox5.SelectedItem IsNot Nothing Then
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('5') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('5') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('5') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('5') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('5') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('5') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
        ElseIf ComboBox4.SelectedItem = "6th sem" Then
            If ComboBox4.SelectedItem IsNot Nothing And ComboBox5.SelectedItem IsNot Nothing Then
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('6') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('6') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('6') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('6') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('6') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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
                        cmd1.CommandText = "select NAME,regno,sem,intime,hour1,hour2,hour3,hour4,hour5,hour6 from attend where sem=('6') and course like '%" + dept + "%' and date like '" + Date.Today + "'"
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

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        FlowLayoutPanel5.Controls.Clear()
        GC.Collect()
        If ComboBox1.SelectedItem = "1st sem" Then
            Try
                GC.Collect()
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno from students where course like '%" + dept + "%' and sem like '%1%' "
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
                    FlowLayoutPanel5.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        ElseIf ComboBox1.SelectedItem = "2nd sem" Then
            Try
                GC.Collect()
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno from students where course like '%" + dept + "%' and sem like '%2%' "
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
                    FlowLayoutPanel5.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        ElseIf ComboBox1.SelectedItem = "3rd sem" Then
            Try
                GC.Collect()
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno from students where course like '%" + dept + "%' and sem like '%3%' "
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
                    FlowLayoutPanel5.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        ElseIf ComboBox1.SelectedItem = "4th sem" Then
            Try
                GC.Collect()
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno from students where course like '%" + dept + "%' and sem like '%4%' "
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
                    FlowLayoutPanel5.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        ElseIf ComboBox1.SelectedItem = "5th sem" Then
            Try
                GC.Collect()
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno from students where course like '%" + dept + "%' and sem like '%5%' "
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
                    FlowLayoutPanel5.Controls.Add(contactpanel2)
                End While
                con.Close()
            Catch ex As Exception
                con.Close()
                Cursor = Cursors.Default
            End Try
        ElseIf ComboBox1.SelectedItem = "6th sem" Then
            Try
                GC.Collect()
                con.Open()
                Dim cmd1 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd1.Connection = con
                cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno from students where course like '%" + dept + "%' and sem like '%6%' "
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
                    FlowLayoutPanel5.Controls.Add(contactpanel2)
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
        FlowLayoutPanel5.Controls.Clear()
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
            cmd1.CommandText = "select PHOTO,STUDENTNAME,STDPHONE,PARENTPHN,COURSE,SEM,GENDER,EMAIL,ADDNO,regno from students where regno like'%" + rrr + "%' and course like '%" + dept + "%'"
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
                TextBox7.Text = "NAME: " + dr2.Item("STUDENTNAME").ToString.Trim & vbCrLf & "COURSE: " + dr2.Item("course").ToString.Trim & vbCrLf & "SEM: " + dr2.Item("sem").ToString.Trim & vbCrLf & "GENDER: " + dr2.Item("gender").ToString.Trim & vbCrLf & "EMAIL: " + dr2.Item("email").ToString.Trim & vbCrLf & "PHONE NO: " + dr2.Item("STDPHONE").ToString.Trim & vbCrLf & "GUARDIAN NO: " + dr2.Item("PARENTPHN").ToString.Trim & vbCrLf & "ADDMISSION NO: " + dr2.Item("addno").ToString.Trim & vbCrLf & "REGISTER NO: " + dr2.Item("REGNO").ToString.Trim

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
                FlowLayoutPanel5.Controls.Add(contactpanel2)
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
        TextBox7.Clear()
    End Sub

    Private Sub sendnotif_Click(sender As Object, e As EventArgs) Handles sendnotif.Click
        If dept = "BCA" Then
            Try
                con.Open()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "insert into notifbca([from],[to],[body],[time],[date]) values('" + name1 + "','" + TextBox5.Text.Trim + "','" + TextBox6.Text + "','" + lbltime.Text + "','" + Lbldate.Text + "')"
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("notification sent successfully!", MsgBoxStyle.Information, "sent")
                Button4.PerformClick()
            Catch ex As Exception
                con.Close()
            End Try

        ElseIf dept = "BBA" Then
            Try
                con.Open()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "insert into notifbba([from],[to],[body],[time],[date]) values('" + name1 + "','" + TextBox5.Text.Trim + "','" + TextBox6.Text + "','" + lbltime.Text + "','" + Lbldate.Text + "')"
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("notification sent successfully!", MsgBoxStyle.Information, "sent")
                Button4.PerformClick()
            Catch ex As Exception
                con.Close()
            End Try
        ElseIf dept = "BCOM" Then
            Try
                con.Open()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "insert into notifbcom([from],[to],[body],[time],[date]) values('" + name1 + "','" + TextBox5.Text.Trim + "','" + TextBox6.Text + "','" + lbltime.Text + "','" + Lbldate.Text + "')"
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("notification sent successfully!", MsgBoxStyle.Information, "sent")
                Button4.PerformClick()
            Catch ex As Exception
                con.Close()
            End Try
        End If

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbltime.Text = TimeOfDay
    End Sub

    Private Sub btnsnd_Click(sender As Object, e As EventArgs) Handles btnsnd.Click
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        If dept = "BCA" Then
            If txtto.Text.Trim = "" Then
                Label21.ForeColor = Color.Red
            ElseIf txtsub.Text.Trim = "" Then
                Label20.ForeColor = Color.Red
            ElseIf txtbody.Text.Trim = "" Then
                Label19.ForeColor = Color.Red
            Else
                Label21.ForeColor = Color.Gainsboro
                Label20.ForeColor = Color.Gainsboro
                Label19.ForeColor = Color.Gainsboro
                Try
                    Label18.Visible = True
                    Cursor = Cursors.WaitCursor
                    Application.DoEvents()
                    Dim mail As New MailMessage
                    Dim smtpserver As New SmtpClient("smtp.gmail.com")
                    mail.From = New MailAddress("institoolbca5@gmail.com")
                    mail.To.Add(txtto.Text.Trim)
                    mail.Subject = txtsub.Text.Trim
                    mail.Body = txtbody.Text & vbCrLf & "" & vbCrLf & "sd\-" & vbCrLf & "Lecturer, BCA"
                    smtpserver.Port = 587
                    smtpserver.Credentials = New Net.NetworkCredential("institoolbca5@gmail.com", "Institoolbca5@")
                    smtpserver.EnableSsl = True
                    smtpserver.Send(mail)
                    Label18.Text = "Sent!"
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "insert into mailbca([TO],[SUBJECT],[BODY],[DATE],[TIME]) values('" + txtto.Text + "','" + txtsub.Text + "','" + txtbody.Text + "','" + Lbldate.Text + "','" + lbltime.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Mail has been sent successfully!", MsgBoxStyle.Information, "Sent")
                    Button3.PerformClick()
                    Cursor = Cursors.Default
                    Label18.Visible = False
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Information, "Please enter valid e-mail address")
                    con.Close()
                    Cursor = Cursors.Default
                    Label18.Visible = False
                End Try

            End If
        ElseIf dept = "BBA" Then
            If txtto.Text.Trim = "" Then
                Label21.ForeColor = Color.Red
            ElseIf txtsub.Text.Trim = "" Then
                Label20.ForeColor = Color.Red
            ElseIf txtbody.Text.Trim = "" Then
                Label19.ForeColor = Color.Red
            Else
                Label21.ForeColor = Color.Gainsboro
                Label20.ForeColor = Color.Gainsboro
                Label19.ForeColor = Color.Gainsboro
                Try
                    Label18.Visible = True
                    Cursor = Cursors.WaitCursor
                    Application.DoEvents()
                    Dim mail As New MailMessage
                    Dim smtpserver As New SmtpClient("smtp.gmail.com")
                    mail.From = New MailAddress("institoolbca5@gmail.com")
                    mail.To.Add(txtto.Text.Trim)
                    mail.Subject = txtsub.Text.Trim
                    mail.Body = txtbody.Text & vbCrLf & "" & vbCrLf & "sd\-" & vbCrLf & "Lecturer, BBA"
                    smtpserver.Port = 587
                    smtpserver.Credentials = New Net.NetworkCredential("institoolbca5@gmail.com", "Institoolbca5@")
                    smtpserver.EnableSsl = True
                    smtpserver.Send(mail)
                    Label18.Text = "Sent!"
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "insert into mailbba([TO],[SUBJECT],[BODY],[DATE],[TIME]) values('" + txtto.Text + "','" + txtsub.Text + "','" + txtbody.Text + "','" + Lbldate.Text + "','" + lbltime.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Mail has been sent successfully!", MsgBoxStyle.Information, "Sent")
                    Button3.PerformClick()
                    Cursor = Cursors.Default
                    Label18.Visible = False
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Information, "Please enter valid e-mail address")
                    con.Close()
                    Cursor = Cursors.Default
                    Label18.Visible = False
                End Try

            End If
        ElseIf dept = "BCOM" Then
            If txtto.Text.Trim = "" Then
                Label21.ForeColor = Color.Red
            ElseIf txtsub.Text.Trim = "" Then
                Label20.ForeColor = Color.Red
            ElseIf txtbody.Text.Trim = "" Then
                Label19.ForeColor = Color.Red
            Else
                Label21.ForeColor = Color.Gainsboro
                Label20.ForeColor = Color.Gainsboro
                Label19.ForeColor = Color.Gainsboro
                Try
                    Label18.Visible = True
                    Cursor = Cursors.WaitCursor
                    Application.DoEvents()
                    Dim mail As New MailMessage
                    Dim smtpserver As New SmtpClient("smtp.gmail.com")
                    mail.From = New MailAddress("institoolbca5@gmail.com")
                    mail.To.Add(txtto.Text.Trim)
                    mail.Subject = txtsub.Text.Trim
                    mail.Body = txtbody.Text & vbCrLf & "" & vbCrLf & "sd\-" & vbCrLf & "Lecturer, BCOM"
                    smtpserver.Port = 587
                    smtpserver.Credentials = New Net.NetworkCredential("institoolbca5@gmail.com", "Institoolbca5@")
                    smtpserver.EnableSsl = True
                    smtpserver.Send(mail)
                    Label18.Text = "Sent!"
                    con.Open()
                    Dim cmd As New SqlCommand
                    cmd.Connection = con
                    cmd.CommandText = "insert into mailbcom([TO],[SUBJECT],[BODY],[DATE],[TIME]) values('" + txtto.Text + "','" + txtsub.Text + "','" + txtbody.Text + "','" + Lbldate.Text + "','" + lbltime.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Mail has been sent successfully!", MsgBoxStyle.Information, "Sent")
                    Button3.PerformClick()
                    Cursor = Cursors.Default
                    Label18.Visible = False
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Information, "Please enter valid e-mail address")
                    con.Close()
                    Cursor = Cursors.Default
                    Label18.Visible = False
                End Try

            End If
        End If
        Cursor = Cursors.Default
        Button3.PerformClick()
    End Sub

    Private Sub txtto_TextChanged(sender As Object, e As EventArgs) Handles txtto.TextChanged
        Label21.ForeColor = Color.Gainsboro
    End Sub

    Private Sub txtsub_TextChanged(sender As Object, e As EventArgs) Handles txtsub.TextChanged
        Label20.ForeColor = Color.Gainsboro
    End Sub

    Private Sub txtbody_TextChanged(sender As Object, e As EventArgs) Handles txtbody.TextChanged
        Label19.ForeColor = Color.Gainsboro
    End Sub
End Class