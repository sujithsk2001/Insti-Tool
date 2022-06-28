<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.Panelmenu = New System.Windows.Forms.Panel()
        Me.stdtotal = New System.Windows.Forms.Label()
        Me.bbacount = New System.Windows.Forms.Label()
        Me.bcomcount = New System.Windows.Forms.Label()
        Me.bcacount = New System.Windows.Forms.Label()
        Me.clearbtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Buttonadd = New System.Windows.Forms.Button()
        Me.Buttonmod = New System.Windows.Forms.Button()
        Me.Buttondlt = New System.Windows.Forms.Button()
        Me.Buttoncancel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.addimg = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.IconPictureBox1 = New FontAwesome.Sharp.IconPictureBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.guardian = New System.Windows.Forms.TextBox()
        Me.TextBoxsem = New System.Windows.Forms.TextBox()
        Me.TextBoxcourse = New System.Windows.Forms.TextBox()
        Me.TextBoxgender = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.addmissionno = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.email = New System.Windows.Forms.TextBox()
        Me.gender = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.mothersname = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.fathersname = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.parentphn = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.dateofjoining = New System.Windows.Forms.TextBox()
        Me.dateofbirth = New System.Windows.Forms.TextBox()
        Me.course = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBoxrfid = New System.Windows.Forms.TextBox()
        Me.sem = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.studentphn = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.aadhaar = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pincode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxaddr = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.studentname = New System.Windows.Forms.TextBox()
        Me.Labeluser = New System.Windows.Forms.Label()
        Me.TextBoxregno = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panelmenu.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IconPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panelmenu
        '
        Me.Panelmenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Panelmenu.Controls.Add(Me.stdtotal)
        Me.Panelmenu.Controls.Add(Me.bbacount)
        Me.Panelmenu.Controls.Add(Me.bcomcount)
        Me.Panelmenu.Controls.Add(Me.bcacount)
        Me.Panelmenu.Controls.Add(Me.clearbtn)
        Me.Panelmenu.Controls.Add(Me.Label1)
        Me.Panelmenu.Controls.Add(Me.PictureBox1)
        Me.Panelmenu.Controls.Add(Me.Buttonadd)
        Me.Panelmenu.Controls.Add(Me.Buttonmod)
        Me.Panelmenu.Controls.Add(Me.Buttondlt)
        Me.Panelmenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panelmenu.Location = New System.Drawing.Point(0, 0)
        Me.Panelmenu.Name = "Panelmenu"
        Me.Panelmenu.Size = New System.Drawing.Size(200, 757)
        Me.Panelmenu.TabIndex = 1
        '
        'stdtotal
        '
        Me.stdtotal.AutoSize = True
        Me.stdtotal.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stdtotal.ForeColor = System.Drawing.Color.Gainsboro
        Me.stdtotal.Location = New System.Drawing.Point(12, 692)
        Me.stdtotal.Name = "stdtotal"
        Me.stdtotal.Size = New System.Drawing.Size(0, 20)
        Me.stdtotal.TabIndex = 48
        '
        'bbacount
        '
        Me.bbacount.AutoSize = True
        Me.bbacount.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bbacount.ForeColor = System.Drawing.Color.Gainsboro
        Me.bbacount.Location = New System.Drawing.Point(12, 664)
        Me.bbacount.Name = "bbacount"
        Me.bbacount.Size = New System.Drawing.Size(0, 20)
        Me.bbacount.TabIndex = 20
        '
        'bcomcount
        '
        Me.bcomcount.AutoSize = True
        Me.bcomcount.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bcomcount.ForeColor = System.Drawing.Color.Gainsboro
        Me.bcomcount.Location = New System.Drawing.Point(12, 640)
        Me.bcomcount.Name = "bcomcount"
        Me.bcomcount.Size = New System.Drawing.Size(0, 20)
        Me.bcomcount.TabIndex = 19
        '
        'bcacount
        '
        Me.bcacount.AutoSize = True
        Me.bcacount.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bcacount.ForeColor = System.Drawing.Color.Gainsboro
        Me.bcacount.Location = New System.Drawing.Point(12, 616)
        Me.bcacount.Name = "bcacount"
        Me.bcacount.Size = New System.Drawing.Size(0, 20)
        Me.bcacount.TabIndex = 18
        '
        'clearbtn
        '
        Me.clearbtn.FlatAppearance.BorderSize = 0
        Me.clearbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.clearbtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clearbtn.ForeColor = System.Drawing.Color.Gainsboro
        Me.clearbtn.Image = Global.studentmanegerv2.My.Resources.Resources.twotone_clear_all_white_24dp1
        Me.clearbtn.Location = New System.Drawing.Point(3, 510)
        Me.clearbtn.Name = "clearbtn"
        Me.clearbtn.Size = New System.Drawing.Size(197, 46)
        Me.clearbtn.TabIndex = 7
        Me.clearbtn.Text = "Clear"
        Me.clearbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.clearbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.clearbtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label1.Location = New System.Drawing.Point(34, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 30)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Update data"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.studentmanegerv2.My.Resources.Resources.PikPng_com_open_book_png_558304
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(13, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(174, 92)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'Buttonadd
        '
        Me.Buttonadd.FlatAppearance.BorderSize = 0
        Me.Buttonadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buttonadd.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttonadd.ForeColor = System.Drawing.Color.Gainsboro
        Me.Buttonadd.Image = Global.studentmanegerv2.My.Resources.Resources.twotone_person_add_alt_white_24dp
        Me.Buttonadd.Location = New System.Drawing.Point(3, 255)
        Me.Buttonadd.Name = "Buttonadd"
        Me.Buttonadd.Size = New System.Drawing.Size(197, 46)
        Me.Buttonadd.TabIndex = 0
        Me.Buttonadd.Text = "Add"
        Me.Buttonadd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Buttonadd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Buttonadd.UseVisualStyleBackColor = True
        '
        'Buttonmod
        '
        Me.Buttonmod.FlatAppearance.BorderSize = 0
        Me.Buttonmod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buttonmod.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttonmod.ForeColor = System.Drawing.Color.Gainsboro
        Me.Buttonmod.Image = Global.studentmanegerv2.My.Resources.Resources.twotone_published_with_changes_white_24dp
        Me.Buttonmod.Location = New System.Drawing.Point(0, 425)
        Me.Buttonmod.Name = "Buttonmod"
        Me.Buttonmod.Size = New System.Drawing.Size(197, 46)
        Me.Buttonmod.TabIndex = 2
        Me.Buttonmod.Text = "Modify"
        Me.Buttonmod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Buttonmod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Buttonmod.UseVisualStyleBackColor = True
        '
        'Buttondlt
        '
        Me.Buttondlt.FlatAppearance.BorderSize = 0
        Me.Buttondlt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buttondlt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttondlt.ForeColor = System.Drawing.Color.Gainsboro
        Me.Buttondlt.Image = Global.studentmanegerv2.My.Resources.Resources.twotone_delete_white_24dp
        Me.Buttondlt.Location = New System.Drawing.Point(0, 340)
        Me.Buttondlt.Name = "Buttondlt"
        Me.Buttondlt.Size = New System.Drawing.Size(197, 46)
        Me.Buttondlt.TabIndex = 3
        Me.Buttondlt.Text = "Delete"
        Me.Buttondlt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Buttondlt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Buttondlt.UseVisualStyleBackColor = True
        '
        'Buttoncancel
        '
        Me.Buttoncancel.FlatAppearance.BorderSize = 0
        Me.Buttoncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buttoncancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttoncancel.ForeColor = System.Drawing.Color.Gainsboro
        Me.Buttoncancel.Image = Global.studentmanegerv2.My.Resources.Resources.twotone_cancel_white_24dp
        Me.Buttoncancel.Location = New System.Drawing.Point(597, 13)
        Me.Buttoncancel.Name = "Buttoncancel"
        Me.Buttoncancel.Size = New System.Drawing.Size(197, 46)
        Me.Buttoncancel.TabIndex = 4
        Me.Buttoncancel.Text = "Cancel"
        Me.Buttoncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Buttoncancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Buttoncancel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Buttoncancel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(200, 684)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(794, 73)
        Me.Panel1.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.AutoEllipsis = True
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(7, 7)
        Me.Label19.MaximumSize = New System.Drawing.Size(700, 70)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(0, 21)
        Me.Label19.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(200, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(794, 45)
        Me.Panel2.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label3.Location = New System.Drawing.Point(330, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 30)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Add student"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackgroundImage = Global.studentmanegerv2.My.Resources.Resources.outline_minimize_white_24dp
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(724, 9)
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
        Me.Button1.Location = New System.Drawing.Point(756, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(26, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Controls.Add(Me.addimg)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Controls.Add(Me.IconPictureBox1)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Controls.Add(Me.guardian)
        Me.Panel3.Controls.Add(Me.TextBoxsem)
        Me.Panel3.Controls.Add(Me.TextBoxcourse)
        Me.Panel3.Controls.Add(Me.TextBoxgender)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.addmissionno)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.email)
        Me.Panel3.Controls.Add(Me.gender)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.mothersname)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.fathersname)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.parentphn)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.DateTimePicker2)
        Me.Panel3.Controls.Add(Me.dateofjoining)
        Me.Panel3.Controls.Add(Me.dateofbirth)
        Me.Panel3.Controls.Add(Me.course)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.DateTimePicker1)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.TextBoxrfid)
        Me.Panel3.Controls.Add(Me.sem)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.studentphn)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.aadhaar)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.pincode)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.TextBoxaddr)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.studentname)
        Me.Panel3.Controls.Add(Me.Labeluser)
        Me.Panel3.Controls.Add(Me.TextBoxregno)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(200, 45)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(794, 639)
        Me.Panel3.TabIndex = 4
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Gainsboro
        Me.Button3.Image = Global.studentmanegerv2.My.Resources.Resources.twotone_published_with_changes_white_24dp1
        Me.Button3.Location = New System.Drawing.Point(534, 413)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(232, 46)
        Me.Button3.TabIndex = 47
        Me.Button3.Text = "Update image"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = False
        '
        'addimg
        '
        Me.addimg.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.addimg.FlatAppearance.BorderSize = 0
        Me.addimg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addimg.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addimg.ForeColor = System.Drawing.Color.Gainsboro
        Me.addimg.Image = Global.studentmanegerv2.My.Resources.Resources.twotone_perm_media_white_24dp
        Me.addimg.Location = New System.Drawing.Point(534, 354)
        Me.addimg.Name = "addimg"
        Me.addimg.Size = New System.Drawing.Size(232, 46)
        Me.addimg.TabIndex = 8
        Me.addimg.Text = "Search image"
        Me.addimg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.addimg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.addimg.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.studentmanegerv2.My.Resources.Resources.twotone_add_photo_alternate_white_24dp
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Enabled = False
        Me.PictureBox2.Location = New System.Drawing.Point(534, 27)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(232, 302)
        Me.PictureBox2.TabIndex = 46
        Me.PictureBox2.TabStop = False
        '
        'IconPictureBox1
        '
        Me.IconPictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.IconPictureBox1.BackgroundImage = Global.studentmanegerv2.My.Resources.Resources.twotone_settings_remote_white_24dp2
        Me.IconPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.IconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.IconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.None
        Me.IconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText
        Me.IconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconPictureBox1.IconSize = 26
        Me.IconPictureBox1.Location = New System.Drawing.Point(137, 27)
        Me.IconPictureBox1.Name = "IconPictureBox1"
        Me.IconPictureBox1.Size = New System.Drawing.Size(32, 26)
        Me.IconPictureBox1.TabIndex = 45
        Me.IconPictureBox1.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label20.Location = New System.Drawing.Point(38, 211)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(86, 20)
        Me.Label20.TabIndex = 44
        Me.Label20.Text = "GUARDIAN"
        '
        'guardian
        '
        Me.guardian.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.guardian.Location = New System.Drawing.Point(222, 208)
        Me.guardian.Name = "guardian"
        Me.guardian.Size = New System.Drawing.Size(265, 26)
        Me.guardian.TabIndex = 43
        '
        'TextBoxsem
        '
        Me.TextBoxsem.Location = New System.Drawing.Point(222, 485)
        Me.TextBoxsem.Name = "TextBoxsem"
        Me.TextBoxsem.ReadOnly = True
        Me.TextBoxsem.Size = New System.Drawing.Size(187, 20)
        Me.TextBoxsem.TabIndex = 42
        '
        'TextBoxcourse
        '
        Me.TextBoxcourse.Location = New System.Drawing.Point(222, 458)
        Me.TextBoxcourse.Name = "TextBoxcourse"
        Me.TextBoxcourse.ReadOnly = True
        Me.TextBoxcourse.Size = New System.Drawing.Size(187, 20)
        Me.TextBoxcourse.TabIndex = 41
        '
        'TextBoxgender
        '
        Me.TextBoxgender.Location = New System.Drawing.Point(222, 432)
        Me.TextBoxgender.Name = "TextBoxgender"
        Me.TextBoxgender.ReadOnly = True
        Me.TextBoxgender.Size = New System.Drawing.Size(187, 20)
        Me.TextBoxgender.TabIndex = 40
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label18.Location = New System.Drawing.Point(38, 88)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(129, 20)
        Me.Label18.TabIndex = 39
        Me.Label18.Text = "ADDMISSION NO"
        '
        'addmissionno
        '
        Me.addmissionno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addmissionno.Location = New System.Drawing.Point(222, 85)
        Me.addmissionno.MaxLength = 10
        Me.addmissionno.Name = "addmissionno"
        Me.addmissionno.Size = New System.Drawing.Size(265, 26)
        Me.addmissionno.TabIndex = 38
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label17.Location = New System.Drawing.Point(38, 402)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 20)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "EMAIL"
        '
        'email
        '
        Me.email.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.email.Location = New System.Drawing.Point(222, 399)
        Me.email.MaxLength = 200
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(265, 26)
        Me.email.TabIndex = 36
        '
        'gender
        '
        Me.gender.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "4", "5", "6"})
        Me.gender.BackColor = System.Drawing.Color.White
        Me.gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.gender.ForeColor = System.Drawing.Color.Black
        Me.gender.FormattingEnabled = True
        Me.gender.Items.AddRange(New Object() {"MALE", "FEMALE", "OTHERs"})
        Me.gender.Location = New System.Drawing.Point(415, 431)
        Me.gender.Name = "gender"
        Me.gender.Size = New System.Drawing.Size(72, 21)
        Me.gender.TabIndex = 35
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label16.Location = New System.Drawing.Point(38, 429)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 20)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "GENDER"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label15.Location = New System.Drawing.Point(38, 179)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(129, 20)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "MOTHER'S NAME"
        '
        'mothersname
        '
        Me.mothersname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mothersname.Location = New System.Drawing.Point(222, 176)
        Me.mothersname.Name = "mothersname"
        Me.mothersname.Size = New System.Drawing.Size(265, 26)
        Me.mothersname.TabIndex = 32
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label14.Location = New System.Drawing.Point(38, 148)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(121, 20)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "FATHER'S NAME"
        '
        'fathersname
        '
        Me.fathersname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fathersname.Location = New System.Drawing.Point(222, 145)
        Me.fathersname.Name = "fathersname"
        Me.fathersname.Size = New System.Drawing.Size(265, 26)
        Me.fathersname.TabIndex = 30
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label13.Location = New System.Drawing.Point(38, 370)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(168, 20)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "GUARDIAN PHONE NO"
        '
        'parentphn
        '
        Me.parentphn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.parentphn.Location = New System.Drawing.Point(222, 367)
        Me.parentphn.MaxLength = 10
        Me.parentphn.Name = "parentphn"
        Me.parentphn.Size = New System.Drawing.Size(265, 26)
        Me.parentphn.TabIndex = 28
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label12.Location = New System.Drawing.Point(38, 571)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(131, 20)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "DATE OF JOINING"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CalendarFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.CalendarTrailingForeColor = System.Drawing.Color.White
        Me.DateTimePicker2.Location = New System.Drawing.Point(222, 592)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(207, 20)
        Me.DateTimePicker2.TabIndex = 26
        '
        'dateofjoining
        '
        Me.dateofjoining.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateofjoining.Location = New System.Drawing.Point(222, 568)
        Me.dateofjoining.MaxLength = 10
        Me.dateofjoining.Name = "dateofjoining"
        Me.dateofjoining.ReadOnly = True
        Me.dateofjoining.Size = New System.Drawing.Size(265, 26)
        Me.dateofjoining.TabIndex = 25
        '
        'dateofbirth
        '
        Me.dateofbirth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateofbirth.Location = New System.Drawing.Point(222, 515)
        Me.dateofbirth.MaxLength = 10
        Me.dateofbirth.Name = "dateofbirth"
        Me.dateofbirth.ReadOnly = True
        Me.dateofbirth.Size = New System.Drawing.Size(265, 26)
        Me.dateofbirth.TabIndex = 24
        '
        'course
        '
        Me.course.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "4", "5", "6"})
        Me.course.BackColor = System.Drawing.Color.White
        Me.course.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.course.ForeColor = System.Drawing.Color.Black
        Me.course.FormattingEnabled = True
        Me.course.Items.AddRange(New Object() {"BCA", "BBA", "BCOM"})
        Me.course.Location = New System.Drawing.Point(415, 458)
        Me.course.Name = "course"
        Me.course.Size = New System.Drawing.Size(72, 21)
        Me.course.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label2.Location = New System.Drawing.Point(38, 456)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 20)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "COURSE"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.White
        Me.DateTimePicker1.Location = New System.Drawing.Point(222, 539)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(207, 20)
        Me.DateTimePicker1.TabIndex = 21
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label11.Location = New System.Drawing.Point(38, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 20)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "RFID NO"
        '
        'TextBoxrfid
        '
        Me.TextBoxrfid.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextBoxrfid.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBoxrfid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxrfid.Location = New System.Drawing.Point(222, 27)
        Me.TextBoxrfid.MaxLength = 10
        Me.TextBoxrfid.Name = "TextBoxrfid"
        Me.TextBoxrfid.Size = New System.Drawing.Size(265, 26)
        Me.TextBoxrfid.TabIndex = 19
        '
        'sem
        '
        Me.sem.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "4", "5", "6"})
        Me.sem.BackColor = System.Drawing.Color.White
        Me.sem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sem.ForeColor = System.Drawing.Color.Black
        Me.sem.FormattingEnabled = True
        Me.sem.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6"})
        Me.sem.Location = New System.Drawing.Point(415, 485)
        Me.sem.Name = "sem"
        Me.sem.Size = New System.Drawing.Size(72, 21)
        Me.sem.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label10.Location = New System.Drawing.Point(38, 518)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 20)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "DATE OF BIRTH"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label9.Location = New System.Drawing.Point(38, 483)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 20)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "SEMESTER"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label8.Location = New System.Drawing.Point(38, 341)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(161, 20)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "STUDENT PHONE  NO"
        '
        'studentphn
        '
        Me.studentphn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.studentphn.Location = New System.Drawing.Point(222, 335)
        Me.studentphn.MaxLength = 10
        Me.studentphn.Name = "studentphn"
        Me.studentphn.Size = New System.Drawing.Size(265, 26)
        Me.studentphn.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label7.Location = New System.Drawing.Point(38, 274)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 20)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "PINCODE"
        '
        'aadhaar
        '
        Me.aadhaar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aadhaar.Location = New System.Drawing.Point(222, 303)
        Me.aadhaar.MaxLength = 12
        Me.aadhaar.Name = "aadhaar"
        Me.aadhaar.Size = New System.Drawing.Size(265, 26)
        Me.aadhaar.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label6.Location = New System.Drawing.Point(38, 306)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 20)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "AADHAAR NO"
        '
        'pincode
        '
        Me.pincode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pincode.Location = New System.Drawing.Point(222, 271)
        Me.pincode.MaxLength = 6
        Me.pincode.Name = "pincode"
        Me.pincode.Size = New System.Drawing.Size(265, 26)
        Me.pincode.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label5.Location = New System.Drawing.Point(38, 243)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "ADDRESS"
        '
        'TextBoxaddr
        '
        Me.TextBoxaddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxaddr.Location = New System.Drawing.Point(222, 240)
        Me.TextBoxaddr.Name = "TextBoxaddr"
        Me.TextBoxaddr.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.TextBoxaddr.Size = New System.Drawing.Size(265, 26)
        Me.TextBoxaddr.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label4.Location = New System.Drawing.Point(38, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "STUDENT NAME"
        '
        'studentname
        '
        Me.studentname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.studentname.Location = New System.Drawing.Point(222, 115)
        Me.studentname.Name = "studentname"
        Me.studentname.Size = New System.Drawing.Size(265, 26)
        Me.studentname.TabIndex = 4
        '
        'Labeluser
        '
        Me.Labeluser.AutoSize = True
        Me.Labeluser.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labeluser.ForeColor = System.Drawing.Color.Gainsboro
        Me.Labeluser.Location = New System.Drawing.Point(38, 59)
        Me.Labeluser.Name = "Labeluser"
        Me.Labeluser.Size = New System.Drawing.Size(63, 20)
        Me.Labeluser.TabIndex = 3
        Me.Labeluser.Text = "REG NO"
        '
        'TextBoxregno
        '
        Me.TextBoxregno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxregno.Location = New System.Drawing.Point(222, 56)
        Me.TextBoxregno.MaxLength = 15
        Me.TextBoxregno.Name = "TextBoxregno"
        Me.TextBoxregno.Size = New System.Drawing.Size(265, 26)
        Me.TextBoxregno.TabIndex = 2
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 757)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panelmenu)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form4"
        Me.Panelmenu.ResumeLayout(False)
        Me.Panelmenu.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IconPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panelmenu As Panel
    Friend WithEvents Buttoncancel As Button
    Friend WithEvents Buttonadd As Button
    Friend WithEvents Buttonmod As Button
    Friend WithEvents Buttondlt As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents sem As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents studentphn As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents aadhaar As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents pincode As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxaddr As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents studentname As TextBox
    Friend WithEvents Labeluser As Label
    Friend WithEvents TextBoxregno As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBoxrfid As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents course As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents mothersname As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents fathersname As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents parentphn As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents dateofjoining As TextBox
    Friend WithEvents dateofbirth As TextBox
    Friend WithEvents gender As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents email As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents addmissionno As TextBox
    Friend WithEvents clearbtn As Button
    Friend WithEvents TextBoxsem As TextBox
    Friend WithEvents TextBoxcourse As TextBox
    Friend WithEvents TextBoxgender As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents guardian As TextBox
    Friend WithEvents IconPictureBox1 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents addimg As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Button3 As Button
    Friend WithEvents bbacount As Label
    Friend WithEvents bcomcount As Label
    Friend WithEvents bcacount As Label
    Friend WithEvents stdtotal As Label
End Class
