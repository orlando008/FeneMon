Public Class WorldMapZoneViewModel
    Private _worldMapZone As WorldZone

    Public Sub New()

    End Sub

    Public Property WorldMapZone As WorldZone
        Get
            Return _worldMapZone
        End Get
        Set(value As WorldZone)
            _worldMapZone = value
        End Set
    End Property
End Class
