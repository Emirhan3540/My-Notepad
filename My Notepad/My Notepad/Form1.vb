Public Class Form1
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        TextBox1.Text = ""
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        End
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName = "" Then
            Exit Sub
        End If
        ' this part saves the file
        FileSystem.FileOpen(1, SaveFileDialog1.FileName, OpenMode.Output)
        FileSystem.Print(1, TextBox1.Text)
        FileSystem.FileClose(1)
    End Sub

    Private Sub OpenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem1.Click
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" Then
            Exit Sub
        End If
        ' this part loads the 
        Dim Tmp As String
        Tmp = ""
        FileSystem.FileOpen(1, OpenFileDialog1.FileName, OpenMode.Input)
        Do While Not FileSystem.EOF(1)
            Tmp = Tmp & FileSystem.LineInput(1)
            If Not FileSystem.EOF(1) Then
                Tmp = Tmp & Chr(13) & Chr(10)
            End If

        Loop
        FileSystem.FileClose(1)
        TextBox1.Text = Tmp
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        FontDialog1.ShowDialog()
        TextBox1.Font = FontDialog1.Font
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Clipboard.SetText(TextBox1.SelectedText)
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        Clipboard.SetText(TextBox1.SelectedText)
        TextBox1.SelectedText = ""
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        TextBox1.SelectedText = Clipboard.GetText
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("This application is a test of making a notepad application out of VB.NET", MsgBoxStyle.OkOnly, "About My Notepad")

    End Sub
End Class
