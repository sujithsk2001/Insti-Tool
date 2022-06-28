<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.Panelmenu = New System.Windows.Forms.Panel()
        Me.Buttonstd = New System.Windows.Forms.Button()
        Me.Buttondept = New System.Windows.Forms.Button()
        Me.Buttonparnt = New System.Windows.Forms.Button()
        Me.Buttonadmin = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Labeldash = New System.Windows.Forms.Label()
        Me.IconPictureBox1 = New FontAwesome.Sharp.IconPictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Lbldate = New System.Windows.Forms.Label()
        Me.lbltime = New System.Windows.Forms.Label()
        Me.Paneladmin = New System.Windows.Forms.Panel()
        Me.Department = New System.Windows.Forms.Panel()
        Me.IconPictureBox2 = New FontAwesome.Sharp.IconPictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.IconButton1 = New FontAwesome.Sharp.IconButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBoxrfid = New System.Windows.Forms.TextBox()
        Me.student = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.studentlogin = New FontAwesome.Sharp.IconButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxregno = New System.Windows.Forms.TextBox()
        Me.Labelcurbtn = New System.Windows.Forms.Label()
        Me.IconButtonlogin = New FontAwesome.Sharp.IconButton()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Labelpass = New System.Windows.Forms.Label()
        Me.TextBoxpass = New System.Windows.Forms.TextBox()
        Me.Labeluser = New System.Windows.Forms.Label()
        Me.TextBoxuser = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panelmenu.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.IconPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Paneladmin.SuspendLayout()
        Me.Department.SuspendLayout()
        CType(Me.IconPictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.student.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panelmenu
        '
        Me.Panelmenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Panelmenu.Controls.Add(Me.Buttonstd)
        Me.Panelmenu.Controls.Add(Me.Buttondept)
        Me.Panelmenu.Controls.Add(Me.Buttonparnt)
        Me.Panelmenu.Controls.Add(Me.Buttonadmin)
        Me.Panelmenu.Controls.Add(Me.PictureBox1)
        Me.Panelmenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panelmenu.Location = New System.Drawing.Point(0, 0)
        Me.Panelmenu.Name = "Panelmenu"
        Me.Panelmenu.Size = New System.Drawing.Size(200, 526)
        Me.Panelmenu.TabIndex = 0
        '
        'Buttonstd
        '
        Me.Buttonstd.FlatAppearance.BorderSize = 0
        Me.Buttonstd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buttonstd.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttonstd.ForeColor = System.Drawing.Color.Gainsboro
        Me.Buttonstd.Image = Global.studentmanegerv2.My.Resources.Resources.outline_school_white_24dp
        Me.Buttonstd.Location = New System.Drawing.Point(3, 368)
        Me.Buttonstd.Name = "Buttonstd"
        Me.Buttonstd.Size = New System.Drawing.Size(197, 46)
        Me.Buttonstd.TabIndex = 6
        Me.Buttonstd.Text = "Student"
        Me.Buttonstd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Buttonstd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Buttonstd.UseVisualStyleBackColor = True
        '
        'Buttondept
        '
        Me.Buttondept.FlatAppearance.BorderSize = 0
        Me.Buttondept.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buttondept.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttondept.ForeColor = System.Drawing.Color.Gainsboro
        Me.Buttondept.Image = Global.studentmanegerv2.My.Resources.Resources.twotone_apartment_white_24dp
        Me.Buttondept.Location = New System.Drawing.Point(2, 234)
        Me.Buttondept.Name = "Buttondept"
        Me.Buttondept.Size = New System.Drawing.Size(197, 46)
        Me.Buttondept.TabIndex = 5
        Me.Buttondept.Text = "Department"
        Me.Buttondept.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Buttondept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Buttondept.UseVisualStyleBackColor = True
        '
        'Buttonparnt
        '
        Me.Buttonparnt.FlatAppearance.BorderSize = 0
        Me.Buttonparnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buttonparnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttonparnt.ForeColor = System.Drawing.Color.Gainsboro
        Me.Buttonparnt.Image = Global.studentmanegerv2.My.Resources.Resources.twotone_family_restroom_white_24dp
        Me.Buttonparnt.Location = New System.Drawing.Point(2, 301)
        Me.Buttonparnt.Name = "Buttonparnt"
        Me.Buttonparnt.Size = New System.Drawing.Size(197, 46)
        Me.Buttonparnt.TabIndex = 2
        Me.Buttonparnt.Text = "Guardian"
        Me.Buttonparnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Buttonparnt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Buttonparnt.UseVisualStyleBackColor = True
        '
        'Buttonadmin
        '
        Me.Buttonadmin.FlatAppearance.BorderSize = 0
        Me.Buttonadmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buttonadmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttonadmin.ForeColor = System.Drawing.Color.Gainsboro
        Me.Buttonadmin.Image = Global.studentmanegerv2.My.Resources.Resources.twotone_admin_panel_settings_white_24dp
        Me.Buttonadmin.Location = New System.Drawing.Point(2, 167)
        Me.Buttonadmin.Name = "Buttonadmin"
        Me.Buttonadmin.Size = New System.Drawing.Size(197, 46)
        Me.Buttonadmin.TabIndex = 0
        Me.Buttonadmin.Text = "Admin"
        Me.Buttonadmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Buttonadmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Buttonadmin.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.studentmanegerv2.My.Resources.Resources.PikPng_com_open_book_png_558304
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(13, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(174, 92)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Labeldash)
        Me.Panel2.Controls.Add(Me.IconPictureBox1)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(200, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(761, 45)
        Me.Panel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label1.Location = New System.Drawing.Point(301, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 29)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "INSTI-TOOL"
        '
        'Labeldash
        '
        Me.Labeldash.AutoSize = True
        Me.Labeldash.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labeldash.ForeColor = System.Drawing.Color.Gainsboro
        Me.Labeldash.Location = New System.Drawing.Point(42, 13)
        Me.Labeldash.Name = "Labeldash"
        Me.Labeldash.Size = New System.Drawing.Size(0, 24)
        Me.Labeldash.TabIndex = 3
        '
        'IconPictureBox1
        '
        Me.IconPictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.IconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.IconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.None
        Me.IconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText
        Me.IconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconPictureBox1.Location = New System.Drawing.Point(10, 13)
        Me.IconPictureBox1.Name = "IconPictureBox1"
        Me.IconPictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.IconPictureBox1.TabIndex = 2
        Me.IconPictureBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackgroundImage = Global.studentmanegerv2.My.Resources.Resources.outline_minimize_white_24dp
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(691, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(26, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = Global.studentmanegerv2.My.Resources.Resources.outline_close_white_24dp1
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(723, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(26, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.Lbldate)
        Me.Panel3.Controls.Add(Me.lbltime)
        Me.Panel3.Controls.Add(Me.Paneladmin)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(200, 45)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(761, 481)
        Me.Panel3.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 444)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(761, 37)
        Me.Panel1.TabIndex = 8
        '
        'Label19
        '
        Me.Label19.AutoEllipsis = True
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label19.Location = New System.Drawing.Point(8, 8)
        Me.Label19.MaximumSize = New System.Drawing.Size(400, 70)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(0, 21)
        Me.Label19.TabIndex = 1
        '
        'Lbldate
        '
        Me.Lbldate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Lbldate.AutoSize = True
        Me.Lbldate.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbldate.ForeColor = System.Drawing.Color.Gainsboro
        Me.Lbldate.Location = New System.Drawing.Point(638, 27)
        Me.Lbldate.Name = "Lbldate"
        Me.Lbldate.Size = New System.Drawing.Size(50, 24)
        Me.Lbldate.TabIndex = 7
        Me.Lbldate.Text = "date"
        '
        'lbltime
        '
        Me.lbltime.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbltime.AutoSize = True
        Me.lbltime.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltime.ForeColor = System.Drawing.Color.Gainsboro
        Me.lbltime.Location = New System.Drawing.Point(638, 3)
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(49, 24)
        Me.lbltime.TabIndex = 6
        Me.lbltime.Text = "time"
        '
        'Paneladmin
        '
        Me.Paneladmin.BackColor = System.Drawing.Color.Transparent
        Me.Paneladmin.Controls.Add(Me.Department)
        Me.Paneladmin.Controls.Add(Me.student)
        Me.Paneladmin.Controls.Add(Me.Labelcurbtn)
        Me.Paneladmin.Controls.Add(Me.IconButtonlogin)
        Me.Paneladmin.Controls.Add(Me.PictureBox3)
        Me.Paneladmin.Controls.Add(Me.Labelpass)
        Me.Paneladmin.Controls.Add(Me.TextBoxpass)
        Me.Paneladmin.Controls.Add(Me.Labeluser)
        Me.Paneladmin.Controls.Add(Me.TextBoxuser)
        Me.Paneladmin.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Paneladmin.ForeColor = System.Drawing.Color.Gainsboro
        Me.Paneladmin.Location = New System.Drawing.Point(46, 62)
        Me.Paneladmin.Name = "Paneladmin"
        Me.Paneladmin.Size = New System.Drawing.Size(663, 376)
        Me.Paneladmin.TabIndex = 4
        '
        'Department
        '
        Me.Department.BackColor = System.Drawing.Color.Transparent
        Me.Department.Controls.Add(Me.IconPictureBox2)
        Me.Department.Controls.Add(Me.Label8)
        Me.Department.Controls.Add(Me.Label9)
        Me.Department.Controls.Add(Me.IconButton1)
        Me.Department.Controls.Add(Me.Label10)
        Me.Department.Controls.Add(Me.TextBoxrfid)
        Me.Department.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Department.ForeColor = System.Drawing.Color.Gainsboro
        Me.Department.Location = New System.Drawing.Point(61, 116)
        Me.Department.Name = "Department"
        Me.Department.Size = New System.Drawing.Size(545, 227)
        Me.Department.TabIndex = 9
        '
        'IconPictureBox2
        '
        Me.IconPictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.IconPictureBox2.BackgroundImage = Global.studentmanegerv2.My.Resources.Resources.twotone_settings_remote_white_24dp2
        Me.IconPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.IconPictureBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.IconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.None
        Me.IconPictureBox2.IconColor = System.Drawing.Color.Gainsboro
        Me.IconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconPictureBox2.IconSize = 26
        Me.IconPictureBox2.Location = New System.Drawing.Point(133, 35)
        Me.IconPictureBox2.Name = "IconPictureBox2"
        Me.IconPictureBox2.Size = New System.Drawing.Size(32, 26)
        Me.IconPictureBox2.TabIndex = 46
        Me.IconPictureBox2.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label8.Location = New System.Drawing.Point(180, 145)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(185, 25)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Scan your RFID card"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label9.Location = New System.Drawing.Point(277, -38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 25)
        Me.Label9.TabIndex = 6
        '
        'IconButton1
        '
        Me.IconButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.IconButton1.FlatAppearance.BorderSize = 0
        Me.IconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton1.IconChar = FontAwesome.Sharp.IconChar.UserCheck
        Me.IconButton1.IconColor = System.Drawing.Color.Gainsboro
        Me.IconButton1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton1.Location = New System.Drawing.Point(177, 73)
        Me.IconButton1.Name = "IconButton1"
        Me.IconButton1.Size = New System.Drawing.Size(190, 52)
        Me.IconButton1.TabIndex = 5
        Me.IconButton1.Text = "LOGIN"
        Me.IconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton1.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label10.Location = New System.Drawing.Point(167, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 20)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "RFID"
        '
        'TextBoxrfid
        '
        Me.TextBoxrfid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxrfid.Location = New System.Drawing.Point(171, 35)
        Me.TextBoxrfid.MaxLength = 10
        Me.TextBoxrfid.Name = "TextBoxrfid"
        Me.TextBoxrfid.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxrfid.Size = New System.Drawing.Size(207, 26)
        Me.TextBoxrfid.TabIndex = 2
        '
        'student
        '
        Me.student.BackColor = System.Drawing.Color.Transparent
        Me.student.Controls.Add(Me.Label5)
        Me.student.Controls.Add(Me.Label6)
        Me.student.Controls.Add(Me.studentlogin)
        Me.student.Controls.Add(Me.Label7)
        Me.student.Controls.Add(Me.TextBoxregno)
        Me.student.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.student.ForeColor = System.Drawing.Color.Gainsboro
        Me.student.Location = New System.Drawing.Point(61, 119)
        Me.student.Name = "student"
        Me.student.Size = New System.Drawing.Size(521, 203)
        Me.student.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label5.Location = New System.Drawing.Point(159, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(203, 25)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Enter Register number"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label6.Location = New System.Drawing.Point(277, -38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 25)
        Me.Label6.TabIndex = 6
        '
        'studentlogin
        '
        Me.studentlogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.studentlogin.FlatAppearance.BorderSize = 0
        Me.studentlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.studentlogin.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.studentlogin.IconChar = FontAwesome.Sharp.IconChar.UserCheck
        Me.studentlogin.IconColor = System.Drawing.Color.Gainsboro
        Me.studentlogin.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.studentlogin.Location = New System.Drawing.Point(165, 73)
        Me.studentlogin.Name = "studentlogin"
        Me.studentlogin.Size = New System.Drawing.Size(190, 52)
        Me.studentlogin.TabIndex = 5
        Me.studentlogin.Text = "LOGIN"
        Me.studentlogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.studentlogin.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label7.Location = New System.Drawing.Point(155, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 20)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Register number"
        '
        'TextBoxregno
        '
        Me.TextBoxregno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxregno.Location = New System.Drawing.Point(159, 35)
        Me.TextBoxregno.Name = "TextBoxregno"
        Me.TextBoxregno.Size = New System.Drawing.Size(207, 26)
        Me.TextBoxregno.TabIndex = 2
        '
        'Labelcurbtn
        '
        Me.Labelcurbtn.AutoSize = True
        Me.Labelcurbtn.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelcurbtn.ForeColor = System.Drawing.Color.Gainsboro
        Me.Labelcurbtn.Location = New System.Drawing.Point(277, -38)
        Me.Labelcurbtn.Name = "Labelcurbtn"
        Me.Labelcurbtn.Size = New System.Drawing.Size(0, 25)
        Me.Labelcurbtn.TabIndex = 6
        '
        'IconButtonlogin
        '
        Me.IconButtonlogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.IconButtonlogin.FlatAppearance.BorderSize = 0
        Me.IconButtonlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButtonlogin.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButtonlogin.IconChar = FontAwesome.Sharp.IconChar.UserCheck
        Me.IconButtonlogin.IconColor = System.Drawing.Color.Gainsboro
        Me.IconButtonlogin.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButtonlogin.Location = New System.Drawing.Point(236, 264)
        Me.IconButtonlogin.Name = "IconButtonlogin"
        Me.IconButtonlogin.Size = New System.Drawing.Size(190, 52)
        Me.IconButtonlogin.TabIndex = 5
        Me.IconButtonlogin.Text = "LOGIN"
        Me.IconButtonlogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButtonlogin.UseVisualStyleBackColor = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = Global.studentmanegerv2.My.Resources.Resources.PikPng_com_open_book_png_558304
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(244, 18)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(174, 92)
        Me.PictureBox3.TabIndex = 4
        Me.PictureBox3.TabStop = False
        '
        'Labelpass
        '
        Me.Labelpass.AutoSize = True
        Me.Labelpass.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelpass.ForeColor = System.Drawing.Color.Gainsboro
        Me.Labelpass.Location = New System.Drawing.Point(226, 186)
        Me.Labelpass.Name = "Labelpass"
        Me.Labelpass.Size = New System.Drawing.Size(73, 20)
        Me.Labelpass.TabIndex = 3
        Me.Labelpass.Text = "Password"
        '
        'TextBoxpass
        '
        Me.TextBoxpass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxpass.Location = New System.Drawing.Point(230, 207)
        Me.TextBoxpass.Name = "TextBoxpass"
        Me.TextBoxpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxpass.Size = New System.Drawing.Size(207, 26)
        Me.TextBoxpass.TabIndex = 2
        '
        'Labeluser
        '
        Me.Labeluser.AutoSize = True
        Me.Labeluser.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labeluser.ForeColor = System.Drawing.Color.Gainsboro
        Me.Labeluser.Location = New System.Drawing.Point(226, 119)
        Me.Labeluser.Name = "Labeluser"
        Me.Labeluser.Size = New System.Drawing.Size(78, 20)
        Me.Labeluser.TabIndex = 1
        Me.Labeluser.Text = "Username"
        '
        'TextBoxuser
        '
        Me.TextBoxuser.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxuser.Location = New System.Drawing.Point(230, 140)
        Me.TextBoxuser.Name = "TextBoxuser"
        Me.TextBoxuser.Size = New System.Drawing.Size(207, 26)
        Me.TextBoxuser.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.BackgroundImage = Global.studentmanegerv2.My.Resources.Resources.PikPng_com_open_book_png_558304
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Location = New System.Drawing.Point(99, 62)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(562, 357)
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 526)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panelmenu)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form2"
        Me.Panelmenu.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.IconPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Paneladmin.ResumeLayout(False)
        Me.Paneladmin.PerformLayout()
        Me.Department.ResumeLayout(False)
        Me.Department.PerformLayout()
        CType(Me.IconPictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.student.ResumeLayout(False)
        Me.student.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panelmenu As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Buttonadmin As Button
    Friend WithEvents Buttonparnt As Button
    Friend WithEvents Labeldash As Label
    Friend WithEvents IconPictureBox1 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Paneladmin As Panel
    Friend WithEvents Labelcurbtn As Label
    Friend WithEvents IconButtonlogin As FontAwesome.Sharp.IconButton
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Labelpass As Label
    Friend WithEvents TextBoxpass As TextBox
    Friend WithEvents Labeluser As Label
    Friend WithEvents TextBoxuser As TextBox
    Friend WithEvents Buttondept As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lbltime As Label
    Friend WithEvents Lbldate As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents student As Panel
    Friend WithEvents Department As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBoxrfid As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents studentlogin As FontAwesome.Sharp.IconButton
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBoxregno As TextBox
    Friend WithEvents IconPictureBox2 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label19 As Label
    Friend WithEvents Buttonstd As Button
End Class
