<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form12
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form12))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panelmenu1 = New System.Windows.Forms.Panel()
        Me.Lbldate = New System.Windows.Forms.Label()
        Me.lbltime = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Students = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cource = New System.Windows.Forms.Label()
        Me.sem = New System.Windows.Forms.Label()
        Me.dateofj = New System.Windows.Forms.Label()
        Me.addno = New System.Windows.Forms.Label()
        Me.regno = New System.Windows.Forms.Label()
        Me.namelbl = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2.SuspendLayout()
        Me.Panelmenu1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1315, 45)
        Me.Panel2.TabIndex = 12
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackgroundImage = Global.studentmanegerv2.My.Resources.Resources.outline_minimize_white_24dp
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(1245, 9)
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
        Me.Button1.Location = New System.Drawing.Point(1277, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(26, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panelmenu1
        '
        Me.Panelmenu1.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Panelmenu1.Controls.Add(Me.Lbldate)
        Me.Panelmenu1.Controls.Add(Me.lbltime)
        Me.Panelmenu1.Controls.Add(Me.PictureBox1)
        Me.Panelmenu1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panelmenu1.Location = New System.Drawing.Point(0, 45)
        Me.Panelmenu1.Name = "Panelmenu1"
        Me.Panelmenu1.Size = New System.Drawing.Size(1315, 100)
        Me.Panelmenu1.TabIndex = 17
        '
        'Lbldate
        '
        Me.Lbldate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Lbldate.AutoSize = True
        Me.Lbldate.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbldate.ForeColor = System.Drawing.Color.Gainsboro
        Me.Lbldate.Location = New System.Drawing.Point(1159, 26)
        Me.Lbldate.Name = "Lbldate"
        Me.Lbldate.Size = New System.Drawing.Size(50, 24)
        Me.Lbldate.TabIndex = 64
        Me.Lbldate.Text = "date"
        '
        'lbltime
        '
        Me.lbltime.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbltime.AutoSize = True
        Me.lbltime.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltime.ForeColor = System.Drawing.Color.Gainsboro
        Me.lbltime.Location = New System.Drawing.Point(1159, 50)
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(49, 24)
        Me.lbltime.TabIndex = 63
        Me.lbltime.Text = "time"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.studentmanegerv2.My.Resources.Resources.PikPng_com_open_book_png_558304
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(174, 92)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'Students
        '
        Me.Students.FlatAppearance.BorderSize = 0
        Me.Students.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Students.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.Students.ForeColor = System.Drawing.Color.Gainsboro
        Me.Students.Location = New System.Drawing.Point(14, 0)
        Me.Students.Name = "Students"
        Me.Students.Size = New System.Drawing.Size(155, 37)
        Me.Students.TabIndex = 17
        Me.Students.Text = "Attendance"
        Me.Students.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Students.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.Button6.ForeColor = System.Drawing.Color.Gainsboro
        Me.Button6.Location = New System.Drawing.Point(179, 0)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(155, 37)
        Me.Button6.TabIndex = 21
        Me.Button6.Text = "Notifications"
        Me.Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Students)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 145)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1315, 37)
        Me.Panel1.TabIndex = 18
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.Button3.ForeColor = System.Drawing.Color.Gainsboro
        Me.Button3.Location = New System.Drawing.Point(344, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(155, 37)
        Me.Button3.TabIndex = 22
        Me.Button3.Text = "Fees"
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Panel3.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel3.Controls.Add(Me.cource)
        Me.Panel3.Controls.Add(Me.sem)
        Me.Panel3.Controls.Add(Me.dateofj)
        Me.Panel3.Controls.Add(Me.addno)
        Me.Panel3.Controls.Add(Me.regno)
        Me.Panel3.Controls.Add(Me.namelbl)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 182)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1315, 587)
        Me.Panel3.TabIndex = 19
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.FlowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.FlowLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 15)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(10, 5, 0, 0)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(948, 560)
        Me.FlowLayoutPanel1.TabIndex = 82
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'cource
        '
        Me.cource.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cource.AutoSize = True
        Me.cource.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cource.ForeColor = System.Drawing.Color.Gainsboro
        Me.cource.Location = New System.Drawing.Point(1005, 473)
        Me.cource.Name = "cource"
        Me.cource.Size = New System.Drawing.Size(75, 24)
        Me.cource.TabIndex = 70
        Me.cource.Text = "cource"
        '
        'sem
        '
        Me.sem.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.sem.AutoSize = True
        Me.sem.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sem.ForeColor = System.Drawing.Color.Gainsboro
        Me.sem.Location = New System.Drawing.Point(1005, 449)
        Me.sem.Name = "sem"
        Me.sem.Size = New System.Drawing.Size(49, 24)
        Me.sem.TabIndex = 69
        Me.sem.Text = "sem"
        '
        'dateofj
        '
        Me.dateofj.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.dateofj.AutoSize = True
        Me.dateofj.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateofj.ForeColor = System.Drawing.Color.Gainsboro
        Me.dateofj.Location = New System.Drawing.Point(1005, 425)
        Me.dateofj.Name = "dateofj"
        Me.dateofj.Size = New System.Drawing.Size(72, 24)
        Me.dateofj.TabIndex = 68
        Me.dateofj.Text = "dateofj"
        '
        'addno
        '
        Me.addno.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.addno.AutoSize = True
        Me.addno.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addno.ForeColor = System.Drawing.Color.Gainsboro
        Me.addno.Location = New System.Drawing.Point(1005, 401)
        Me.addno.Name = "addno"
        Me.addno.Size = New System.Drawing.Size(140, 24)
        Me.addno.TabIndex = 67
        Me.addno.Text = "addmissionno"
        '
        'regno
        '
        Me.regno.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.regno.AutoSize = True
        Me.regno.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regno.ForeColor = System.Drawing.Color.Gainsboro
        Me.regno.Location = New System.Drawing.Point(1005, 377)
        Me.regno.Name = "regno"
        Me.regno.Size = New System.Drawing.Size(65, 24)
        Me.regno.TabIndex = 66
        Me.regno.Text = "regno"
        '
        'namelbl
        '
        Me.namelbl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.namelbl.AutoSize = True
        Me.namelbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.namelbl.ForeColor = System.Drawing.Color.Gainsboro
        Me.namelbl.Location = New System.Drawing.Point(1005, 353)
        Me.namelbl.Name = "namelbl"
        Me.namelbl.Size = New System.Drawing.Size(62, 24)
        Me.namelbl.TabIndex = 65
        Me.namelbl.Text = "name"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(1009, 15)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(262, 324)
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Form12
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1315, 769)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panelmenu1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form12"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form12"
        Me.Panel2.ResumeLayout(False)
        Me.Panelmenu1.ResumeLayout(False)
        Me.Panelmenu1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Panelmenu1 As Panel
    Friend WithEvents Lbldate As Label
    Friend WithEvents lbltime As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Students As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents cource As Label
    Friend WithEvents sem As Label
    Friend WithEvents dateofj As Label
    Friend WithEvents addno As Label
    Friend WithEvents regno As Label
    Friend WithEvents namelbl As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
End Class
