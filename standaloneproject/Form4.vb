Imports System.Data.SqlClient

Public Class Form4
    Dim sqlConnectionString As String = "Data Source=DESKTOP-MOKS0OD\SQLEXPRESS;Initial Catalog=standalonecrud;Integrated Security=True"
    Dim connection As New SqlConnection(sqlConnectionString)
    Dim dataTable As New DataTable()
    Dim form2Instance As form2 ' Declare a variable to hold the instance of Form2
    ' Constructor to receive Form2 instance

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load options into ComboBox
        ComboBox1.Items.Add("Data from Form2")
        ComboBox1.Items.Add("Data from SQL (Imported from Excel)")
        ComboBox1.SelectedIndex = 0 ' Default selection
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Handle the selection change in ComboBox
        If ComboBox1.SelectedIndex = 0 Then
            ' Display data from Form2
            DisplayDataFromForm2()
        ElseIf ComboBox1.SelectedIndex = 1 Then
            ' Display data from Excel import
            DisplayDataFromSQL()
        End If
    End Sub

    Private Sub DisplayDataFromForm2()
        Try
            Using command As New SqlCommand("SELECT * FROM crud", connection)
                Dim dataAdapter As New SqlDataAdapter(command)
                dataTable.Clear()
                dataAdapter.Fill(dataTable)
                DataGridView1.DataSource = dataTable
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub DisplayDataFromSQL()
        Try
            ' Fetch and display data from the SQL table where Excel data was imported
            Using command As New SqlCommand("SELECT * FROM excel", connection)
                Dim dataAdapter As New SqlDataAdapter(command)
                dataTable.Clear()
                dataAdapter.Fill(dataTable)
                DataGridView1.DataSource = dataTable
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub okButton2_Click(sender As Object, e As EventArgs) Handles okButton2.Click
        ' Clear existing data in DataGridView
        DataGridView1.DataSource = Nothing

        ' Perform action based on selected option in ComboBox...
        If ComboBox1.SelectedIndex = 0 Then
            ' Display data from Form2
            DisplayDataFromForm2()
        ElseIf ComboBox1.SelectedIndex = 1 Then
            ' Display data from SQL (Imported from Excel)
            DisplayDataFromSQL()
        End If
    End Sub


    Private Sub exitButton1_Click(sender As Object, e As EventArgs) Handles exitButton1.Click
        ' Close the form
        Me.Close()
    End Sub
End Class
