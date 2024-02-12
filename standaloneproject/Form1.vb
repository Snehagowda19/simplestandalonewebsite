Public Class parentForm1
    Private Sub CRUDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CRUDToolStripMenuItem.Click
        Dim n As New form2
        Me.IsMdiContainer = True
        n.MdiParent = Me
        n.Show()
        Form3.Close()
        Form4.Close()

    End Sub

    Private Sub ExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExcelToolStripMenuItem.Click
        Dim n As New Form3
        Me.IsMdiContainer = True
        n.MdiParent = Me
        n.Show()
        form2.Close()
        Form4.Close()
    End Sub

    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        Dim n As New Form4
        Me.IsMdiContainer = True
        n.MdiParent = Me
        n.Show()
        form2.Close()
        Form3.Close()
    End Sub
End Class