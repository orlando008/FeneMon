Imports FeneMonLib
''' <summary>
''' Collects log messages in a list
''' Useful for comparing step by step during a test
''' </summary>
Public Class TestLogger
    Implements ILogger

    Private _messages As IList(Of String)

    Public Sub New()
        _messages = New List(Of String)
    End Sub

    Public Sub LogMessage(message As String) Implements ILogger.LogMessage
        _messages.Add(message)
    End Sub

    Public ReadOnly Property Messages As IReadOnlyList(Of String)
        Get
            Return _messages
        End Get
    End Property
End Class
