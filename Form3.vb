Public Class Form3
    Dim buttonhp As Panel
    Dim currbtn As Button
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

    Private Sub addteach_Click(sender As Object, e As EventArgs) Handles addteach.Click
        activatebutton(sender, customclour:=Color.Gainsboro)

        IconPictureBox1.Image = addteach.Image
        Labeldash.Text = addteach.Text
        PictureBox2.Hide()
        Form5.Show()
        Me.Hide()


    End Sub



    Private Sub addstudent_Click(sender As Object, e As EventArgs) Handles addstudent.Click
        activatebutton(sender, customclour:=Color.Gainsboro)
        IconPictureBox1.Image = addstudent.Image
        Labeldash.Text = addstudent.Text
        PictureBox2.Hide()
        Form4.Show()
        Me.Hide()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized


    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox2.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form6.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Buttonhist.Click
        activatebutton(sender, customclour:=Color.Gainsboro)

        IconPictureBox1.Image = Buttonhist.Image
        Labeldash.Text = Buttonhist.Text
        PictureBox2.Hide()
        Form13.Show()
        Me.Hide()
    End Sub
End Class