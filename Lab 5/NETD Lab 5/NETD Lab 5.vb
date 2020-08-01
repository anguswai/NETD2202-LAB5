' Name: Angus Wai (100719558)
' Date: 2020-07-31
' Description: Text editor for Lab 5

Option Strict On
Imports System.IO

Public Class frmTextEditor
    Private Sub frmTextEditorLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        frmAbout.Hide()
    End Sub

    ' Create new file
    Private Sub NewClick(sender As Object, e As EventArgs) Handles mnuFileNew.Click
        ' Empty txtArea and deselect any selected file
        txtArea.Text = String.Empty
        openDialog.FileName = String.Empty
    End Sub

    ' Open an existing file
    Private Sub OpenClick(sender As Object, e As EventArgs) Handles mnuFileOpen.Click
        Dim fileRead As FileStream
        Dim inputStream As StreamReader

        ' If user clicked "Open" button in openDialog
        If openDialog.ShowDialog() = DialogResult.OK Then
            ' Reads the selected file then prints its content in txtArea
            fileRead = New FileStream(openDialog.FileName, FileMode.Open, FileAccess.Read)
            inputStream = New StreamReader(fileRead)
            txtArea.Text = inputStream.ReadToEnd()
            inputStream.Close()
        End If
    End Sub

    ' Save an existing file
    Private Sub SaveClick(sender As Object, e As EventArgs) Handles mnuFileSave.Click
        ' If no file is selected
        If openDialog.FileName = String.Empty Then
            ' Save as a new file
            SaveAsClick(mnuFileSaveAs, EventArgs.Empty)
        Else ' If a file is selected
            ' Call save method
            Save(openDialog.FileName)
        End If
    End Sub

    ' Save as a new file
    Private Sub SaveAsClick(sender As Object, e As EventArgs) Handles mnuFileSaveAs.Click
        ' If user clicked "Save" in openDialog
        If saveDialog.ShowDialog() = DialogResult.OK Then
            ' Call save method
            Save(saveDialog.FileName)
        End If
    End Sub

    ' Close the current file
    Private Sub CloseClick(sender As Object, e As EventArgs) Handles mnuFileClose.Click
        ' Emptiy txtArea and deselect any selected file
        txtArea.Text = String.Empty
        openDialog.FileName = String.Empty
    End Sub

    ' Exit application
    Private Sub ExitClick(sender As Object, e As EventArgs) Handles mnuFileExit.Click
        Application.Exit()
    End Sub

    ' About window popup
    Private Sub AboutClick(sender As Object, e As EventArgs) Handles mnuHelpAbout.Click
        frmAbout.Show()
    End Sub

    ' Copy operation
    Private Sub CopyClick(sender As Object, e As EventArgs) Handles mnuEditCopy.Click
        If txtArea.SelectionLength > 0 Then
            My.Computer.Clipboard.SetText(txtArea.SelectedText)
        End If
    End Sub

    'Cut operation
    Private Sub CutClick(sender As Object, e As EventArgs) Handles mnuEditCut.Click
        If txtArea.SelectionLength > 0 Then
            My.Computer.Clipboard.SetText(txtArea.SelectedText)
            txtArea.SelectedText = String.Empty
        End If
    End Sub

    ' Paste operation
    Private Sub PasteClick(sender As Object, e As EventArgs) Handles mnuEditPaste.Click
        Dim insertPos As Integer = txtArea.SelectionStart
        Dim insertText As String = My.Computer.Clipboard.GetText()

        txtArea.Text = txtArea.Text.Insert(insertPos, insertText)
        txtArea.SelectionStart = insertPos + insertText.Length
    End Sub

    ' Save method
    Private Sub Save(fullPath As String)
        Dim fileWrite As FileStream
        Dim outputStream As StreamWriter

        ' Save content in txtArea and save it to the selected location
        fileWrite = New FileStream(fullPath, FileMode.Create, FileAccess.Write)
        outputStream = New StreamWriter(fileWrite)
        outputStream.Write(txtArea.Text)
        outputStream.Close()
    End Sub
End Class