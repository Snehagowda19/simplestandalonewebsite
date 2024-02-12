Imports System.Data.SqlClient
Imports ClosedXML.Excel
Public Class Form3

    Dim sqlConnectionString As String = "Data Source=DESKTOP-MOKS0OD\SQLEXPRESS;Initial Catalog=standalonecrud;Integrated Security=True"
    Dim connection As New SqlConnection(sqlConnectionString)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Excel Files|*.xlsx;*.xls"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                Dim excelFilePath As String = openFileDialog.FileName

                ' Read data from Excel file
                Using workbook As New XLWorkbook(excelFilePath)
                    Dim worksheet = workbook.Worksheets.First()

                    ' Assuming your SQL table has columns: ID, Name, Age, Phone
                    Dim query As String = "INSERT INTO excel (ID, Name, Age, Phone) VALUES (@ID, @Name, @Age, @Phone)"

                    ' Open SQL connection
                    connection.Open()

                    ' Iterate through rows in Excel and insert into SQL
                    For row As Integer = 2 To worksheet.LastRowUsed().RowNumber()
                        Using command As New SqlCommand(query, connection)
                            command.Parameters.AddWithValue("@ID", worksheet.Cell(row, 1).Value.ToString())
                            command.Parameters.AddWithValue("@Name", worksheet.Cell(row, 2).Value.ToString())
                            command.Parameters.AddWithValue("@Age", worksheet.Cell(row, 3).Value.ToString())
                            command.Parameters.AddWithValue("@Phone", worksheet.Cell(row, 4).Value.ToString())

                            ' Execute SQL command
                            command.ExecuteNonQuery()
                        End Using
                    Next
                End Using

                MessageBox.Show("Data imported successfully.")
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                ' Close SQL connection
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Navigate to Form4
        Dim form4 As New Form4()
        form4.Show()
        Me.Hide()
    End Sub
End Class