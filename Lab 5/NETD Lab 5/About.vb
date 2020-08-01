' Name: Angus Wai (100719558)
' Date: 2020-07-31
' Description: About window of text editor for Lab 5

Option Strict On

Public Class frmAbout
    ' Hide the about window if "OK" is clicked
    Private Sub OKClick(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Hide()
    End Sub
End Class