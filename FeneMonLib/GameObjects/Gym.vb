Public Class Gym

    Private _gymZones As List(Of GymZone)
    Private _name As String

    Public Sub New()
        'Generate a random list of Gym Zones
    End Sub

    Public Sub New(gymZones As List(Of GymZone), name As String)
        _gymZones = gymZones
        _name = name
    End Sub

#Region "Public Properties"

    Public Property GymZones As List(Of GymZone)
        Get
            Return _gymZones
        End Get
        Set(value As List(Of GymZone))
            _gymZones = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

#End Region

End Class
