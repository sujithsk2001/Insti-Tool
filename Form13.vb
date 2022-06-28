Imports System.Data.SqlClient
Public Class Form13
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\V'th sem project\studentmanegerv2\students007.mdf;Integrated Security=True")

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            con.Open()
            Dim cmd As New SqlClient.SqlCommand("SELECT * FROM " & Me.ComboBox1.SelectedItem.ToString, con)
            Dim da As New SqlClient.SqlDataAdapter(cmd)
            Dim ds As New DataSet("bpl")
            da.Fill(ds, "bpl")
            DataGridView1.DataSource = ds.Tables(0)
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try

    End Sub



    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            con.Open()
            Dim da As New SqlDataAdapter("SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_TYPE ='Base Table'order by 'TABLE_NAME' asc", con)
            Dim ds As New DataSet("bpl")
            Dim i As Integer = 0

            da.Fill(ds, "bpl")
            Dim MyTableCount As Integer = ds.Tables.Count

            For Each row As DataRow In ds.Tables(0).Rows
                ComboBox1.Items.Add(row.Item("TABLE_NAME"))
            Next row
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Buttoncancel_Click(sender As Object, e As EventArgs) Handles Buttoncancel.Click
        Form3.Show()
        Me.Close()
    End Sub
End Class