Imports System.Data.SqlClient
Public Class Form2
    Dim buttonhp As Panel
    Dim cb2 As String = Nothing
    Dim currbtn As Button
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\V'th sem project\studentmanegerv2\students007.mdf;Integrated Security=True")

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.Hide()
        IconPictureBox1.Hide()
        Labeldash.Hide()
        Paneladmin.Hide()
        PictureBox2.BringToFront()
        lbltime.Text = TimeOfDay
        Lbldate.Text = Date.Today
        student.Visible = False
        Department.Visible = False

        Paneladmin.Visible = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Form2_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Maximized Then
            Me.MaximizedBounds = Screen.PrimaryScreen.WorkingArea
        End If
    End Sub
    Public Sub New()


        InitializeComponent()
        buttonhp = New Panel

        buttonhp.Size = New Size(6, 46)
        Panelmenu.Controls.Add(buttonhp)


    End Sub
    Private Sub activatebutton(senderbtn As Object, customclour As Color)
        If senderbtn IsNot Nothing Then
            desablebtn()
            currbtn = CType(senderbtn, Button)
            currbtn.BackColor = Color.FromArgb(37, 36, 81)
            currbtn.ForeColor = customclour
            buttonhp.BackColor = customclour
            currbtn.TextAlign = ContentAlignment.MiddleCenter
            currbtn.ImageAlign = ContentAlignment.MiddleRight
            currbtn.TextImageRelation = TextImageRelation.ImageBeforeText
            buttonhp.Location = New Point(0, currbtn.Location.Y)
            buttonhp.Visible = True
            buttonhp.BringToFront()

        End If
    End Sub
    Private Sub desablebtn()
        If currbtn IsNot Nothing Then

            currbtn.BackColor = Color.FromArgb(31, 30, 68)
            currbtn.ForeColor = Color.Gainsboro

            currbtn.TextAlign = ContentAlignment.MiddleCenter
            currbtn.ImageAlign = ContentAlignment.MiddleRight
            currbtn.TextImageRelation = TextImageRelation.ImageBeforeText
        End If
    End Sub

    Private Sub Buttonadmin_Click(sender As Object, e As EventArgs) Handles Buttonadmin.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        student.Visible = False
        Department.Visible = False

        Paneladmin.Visible = True

        IconPictureBox1.Show()
        Labeldash.Show()



        Labelcurbtn.Text = "Aministrator Login"
        IconPictureBox1.Image = Buttonadmin.Image
        Labeldash.Text = Buttonadmin.Text
        PictureBox2.Hide()




    End Sub

    Private Sub Buttonparnt_Click(sender As Object, e As EventArgs) Handles Buttonparnt.Click

        student.Visible = True
        Department.Visible = False
        PictureBox2.Hide()
        Paneladmin.Visible = True

        Labelcurbtn.BringToFront()
        Labelcurbtn.Text = "Parents Login"
        activatebutton(sender, customclour:=Color.Gainsboro)
        IconPictureBox1.Show()
        Labeldash.Show()
        IconPictureBox1.Image = Buttonparnt.Image
        Labeldash.Text = Buttonparnt.Text
    End Sub



    Private Sub IconButtonlogin_Click(sender As Object, e As EventArgs) Handles IconButtonlogin.Click
        If TextBoxuser.Text.ToLower = "admin2001" And TextBoxpass.Text = "shs1234" Then
            Form3.Show()
            Me.Hide()
        ElseIf TextBoxuser.Text.ToLower = "" And TextBoxpass.Text = "" Then
            Label19.Text = "please enter username and password"
            Label19.ForeColor = Color.Red
        Else
            Label19.Text = "username or password is incorrect "
            Label19.ForeColor = Color.Red
        End If
    End Sub

    Private Sub IconButtonprl_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Buttondept.Click
        activatebutton(sender, customclour:=Color.Gainsboro)

        Paneladmin.Visible = True
        Department.Visible = True

        student.Visible = False

        IconPictureBox1.Show()
        Labeldash.Show()
        Labelcurbtn.Text = "Department Login"
        IconPictureBox1.Image = Buttondept.Image
        Labeldash.Text = Buttondept.Text
        PictureBox2.Hide()
        Me.ActiveControl = TextBoxrfid

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbltime.Text = TimeOfDay
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Buttonstd.Click
        Paneladmin.Visible = True
        student.Visible = True
        Department.Visible = False

        PictureBox2.Hide()

        Labelcurbtn.BringToFront()
        Labelcurbtn.Text = "Student Login"
        activatebutton(sender, customclour:=Color.Gainsboro)
        IconPictureBox1.Show()
        Labeldash.Show()
        IconPictureBox1.Image = Buttonstd.Image
        Labeldash.Text = Buttonstd.Text
    End Sub
    Public Function autorouter()
        Try
            If TextBoxrfid.Text.Trim <> "" Then
                Dim cb As String
                con.Open()
                Dim cmd3 As New SqlCommand
                cmd3.Connection = con
                cmd3.CommandText = "select POST from Staff where RFID=('" + TextBoxrfid.Text + "')"
                cmd3.CommandType = CommandType.Text
                Dim sdr As SqlDataReader = cmd3.ExecuteReader
                sdr.Read()
                cb = sdr("POST").ToString.Trim
                con.Close()
                If cb = "Director" Then
                    Form7.Show()
                    Me.Hide()
                ElseIf cb = "Principal" Then
                    Form7.Show()
                    Me.Hide()
                ElseIf cb = "HOD" Then
                    Form8.Show()
                    Me.Hide()
                ElseIf cb = "Lecturer" Then
                    Form9.Show()
                    Me.Hide()
                ElseIf cb = "Librarian" Then
                    Form11.Show()
                    Me.Hide()
                ElseIf cb = "Accountant" Then
                    Form10.Show()
                    Me.Hide()
                Else
                    Label19.Text = "Unregistered RFID"
                    Label19.ForeColor = Color.Red
                End If
            End If
        Catch ex As Exception
            con.Close()
        End Try
    End Function

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        autorouter()
    End Sub

    Private Sub TextBoxrfid_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxrfid.KeyDown
        If e.KeyCode = Keys.Enter Then
            IconButton1.PerformClick()
        End If
    End Sub

    Private Sub studentlogin_Click(sender As Object, e As EventArgs) Handles studentlogin.Click
        Try
            If TextBoxregno.Text.Trim <> "" Then

                con.Open()
                Dim cmd3 As New SqlCommand
                cmd3.Connection = con
                cmd3.CommandText = "select rfid from students where Regno=('" + TextBoxregno.Text.Trim + "')"
                cmd3.CommandType = CommandType.Text
                Dim sdr As SqlDataReader = cmd3.ExecuteReader
                sdr.Read()
                cb2 = sdr("rfid").ToString.Trim
                con.Close()
                If cb2 IsNot Nothing Then
                    Form12.Show()
                    returnn()
                End If
            End If
        Catch ex As Exception
            con.Close()
            Label19.Text = "Unregistered RFID"
            Label19.ForeColor = Color.Red
        End Try
    End Sub
    Function returnn()
        If cb2 IsNot Nothing Then
            Return cb2
        End If
    End Function

    Private Sub TextBoxuser_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxuser.KeyPress

    End Sub

    Private Sub TextBoxuser_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxuser.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = TextBoxpass
            TextBoxpass.SelectionLength = 0
        End If
    End Sub

    Private Sub TextBoxpass_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxpass.KeyDown
        If e.KeyCode = Keys.Enter Then
            IconButtonlogin.PerformClick()
        End If
    End Sub
End Class