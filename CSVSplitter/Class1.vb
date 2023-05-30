Public Class Class1
#Region "メッセージボックスエラー"
    ''' <summary>
    ''' メッセージボックス
    ''' </summary>
    Public Shared Sub ShowMessageBox(message As String, strStatus As String)
        Dim strTitle As String = Nothing
        Dim icon As MessageBoxIcon

        If strStatus = "Error" Then
            strTitle = "Error"
            icon = MessageBoxIcon.Error
        ElseIf strStatus = "Result" Then
            strTitle = "処理結果"
            icon = MessageBoxIcon.None
        ElseIf strStatus = "注意" Then
            strTitle = "Error"
            icon = MessageBoxIcon.Exclamation
        End If

        'メッセージボックス表示
        MessageBox.Show(message,
                        strTitle,
                        MessageBoxButtons.OK,
                        icon)
    End Sub
#End Region

#Region "メッセージボックス処理結果"
    ''' <summary>
    ''' メッセージボックス
    ''' </summary>
    Public Shared Sub ShowMessageBoxResult(message As String)
        MessageBox.Show(message,
                        "処理結果",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.None)
    End Sub
#End Region

#Region "メッセージボックス注意"
    ''' <summary>
    ''' メッセージボックス
    ''' </summary>
    Public Shared Sub ShowMessageBoxAttention(message As String)
        MessageBox.Show(message,
                        "注意",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation)
    End Sub
#End Region
End Class
