Public Class Fighter

    Private _name As String
    Private _monsList As List(Of FeneMon)

    Public Sub New(name As String, monsList As List(Of FeneMon))
        _name = name
        _monsList = monsList
    End Sub

#Region "Public Properties"

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property MonsList As List(Of FeneMon)
        Get
            Return _monsList
        End Get
        Set(value As List(Of FeneMon))
            _monsList = value
        End Set
    End Property

#End Region

End Class
