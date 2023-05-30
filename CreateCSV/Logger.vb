Imports log4net

Public Class Logger
        Private Shared ReadOnly log As ILog = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

        Public Shared Sub LogInfo(message As String)
            log.Info(message)
        End Sub

        Public Shared Sub LogError(message As String, ex As Exception)
            log.Error(message, ex)
        End Sub
    End Class
