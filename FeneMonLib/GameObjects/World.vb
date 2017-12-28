Public Class World

    Private _worldZones As List(Of WorldZone)

    ''' <summary>
    ''' Generate a new FeneMon world.
    ''' </summary>
    Public Sub New()
        'Generate World Zones for each affinity.
        For i = 0 To Enumerations.NUM_OF_AFFINITIES
            _worldZones.Add(New WorldZone(i))
        Next
    End Sub

    ''' <summary>
    ''' Generate a new FeneMon world.
    ''' </summary>
    ''' <param name="GymsPerZone">Sets that default amount of GymZones that will exist in a Gym</param>
    Public Sub New(ByVal GymsPerZone As Integer)
        'Generate World Zones for each affinity.
        For i = 0 To Enumerations.NUM_OF_AFFINITIES
            _worldZones.Add(New WorldZone(GymsPerZone, i))
        Next
    End Sub


#Region "Public Properties"

    ''' <summary>
    ''' A property that returns the list of WorldZones in a FeneMon World.
    ''' </summary>
    ''' <returns>List(Of WorldZone)</returns>
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
