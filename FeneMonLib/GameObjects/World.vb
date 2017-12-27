Public Class World

    Private _worldZones As List(Of WorldZone)

    Public Sub New()
        'Generate random list of world Zones
    End Sub

    Public Sub New(worldZones As List(Of WorldZone))
        _worldZones = worldZones
    End Sub


#Region "Public Properties"

    Public Property WorldZones As List(Of WorldZone)
        Get
            Return _worldZones
        End Get
        Set(value As List(Of WorldZone))
            _worldZones = value
        End Set
    End Property

#End Region

End Class
