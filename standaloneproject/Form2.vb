Imports System.Data.SqlClient
Public Class form2

    ' DataTable to hold your data
    Dim dataTable As New DataTable()

    ' SQL Server connection string
    Dim connectionString As String = "Data Source=DESKTOP-MOKS0OD\SQLEXPRESS;Initial Catalog=standalonecrud;Integrated Security=True"
    Dim connection As New SqlConnection(connectionString)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonID.Click
        Try
            ' Check if the required fields are not empty
            If Not String.IsNullOrWhiteSpace(TextBox1.Text) AndAlso Not String.IsNullOrWhiteSpace(TextBox2.Text) AndAlso
               Not String.IsNullOrWhiteSpace(TextBox3.Text) AndAlso Not String.IsNullOrWhiteSpace(TextBox4.Text) Then

                ' Open the database connection
                connection.Open()

                ' SQL command for insertion
                Dim insertCommand As New SqlCommand("INSERT INTO CRUD (ID, NAME, AGE, PHONE) VALUES (@ID, @NAME, @AGE, @PHONE)", connection)
                insertCommand.Parameters.AddWithValue("@ID", Convert.ToInt32(TextBox1.Text))
                insertCommand.Parameters.AddWithValue("@NAME", TextBox2.Text)
                insertCommand.Parameters.AddWithValue("@AGE", Convert.ToInt32(TextBox3.Text))
                insertCommand.Parameters.AddWithValue("@PHONE", TextBox4.Text)

                ' Execute the SQL command
                insertCommand.ExecuteNonQuery()

                ' Display success message
                MessageBox.Show("Record added successfully.")

                ' Clear the input fields
                ClearFields()

            Else
                MessageBox.Show("Please fill in all the required fields.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)

        Finally
            ' Close the database connection
            connection.Close()
        End Try

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'update
        Try
            ' Check if the ID field is not empty
            If Not String.IsNullOrWhiteSpace(TextBox1.Text) Then
                ' Open the database connection
                connection.Open()

                ' SQL command for update
                Dim updateCommand As New SqlCommand("UPDATE CRUD SET NAME = @NAME, AGE = @AGE, PHONE = @PHONE WHERE ID = @ID", connection)
                updateCommand.Parameters.AddWithValue("@ID", Convert.ToInt32(TextBox1.Text))
                updateCommand.Parameters.AddWithValue("@NAME", TextBox2.Text)
                updateCommand.Parameters.AddWithValue("@AGE", Convert.ToInt32(TextBox3.Text))
                updateCommand.Parameters.AddWithValue("@PHONE", TextBox4.Text)

                ' Execute the SQL command
                updateCommand.ExecuteNonQuery()

                ' Display success message
                MessageBox.Show("Record updated successfully.")

                ' Clear the input fields
                ClearFields()

            Else
                MessageBox.Show("Please enter an ID to update.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)

        Finally
            ' Close the database connection
            connection.Close()
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'delete
        Try
            ' Check if the ID field is not empty
            If Not String.IsNullOrWhiteSpace(TextBox1.Text) Then
                ' Open the database connection
                connection.Open()

                ' SQL command for deletion
                Dim deleteCommand As New SqlCommand("DELETE FROM CRUD WHERE ID = @ID", connection)
                deleteCommand.Parameters.AddWithValue("@ID", Convert.ToInt32(TextBox1.Text))

                ' Execute the SQL command
                deleteCommand.ExecuteNonQuery()

                ' Display success message
                MessageBox.Show("Record deleted successfully.")

                ' Clear the input fields
                ClearFields()

            Else
                MessageBox.Show("Please enter an ID to delete.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)

        Finally
            ' Close the database connection
            connection.Close()
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ClearFields()


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Navigate to Form3
        Dim form3 As New Form3()
        form3.Show()
        Me.Hide()
    End Sub

    Private Sub ClearFields()
        ' Clear the input fields
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class