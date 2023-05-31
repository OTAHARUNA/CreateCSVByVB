Imports System.IO

Public Class Logger
    Private Shared logFilePath As String = "C:\Users\chopp\source\repos\CreateCSV\CreateCSV\log\log_" & DateTime.Now.ToString("yyyyMMdd") & ".log"

    Public Shared Sub Log(message As String)
        Dim logEntry As String = $"{DateTime.Now} - {message}"

        Using writer As New StreamWriter(logFilePath, True)
            writer.WriteLine(logEntry)
        End Using
    End Sub
End Class
