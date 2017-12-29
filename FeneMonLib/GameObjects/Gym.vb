Public Class Gym

    Private _gymZones As List(Of GymZone)
    Private _name As String

    ''' <summary>
    ''' Generate a new Gym with a number of GymZones.
    ''' </summary>
    ''' <param name="numGymZones">The Number of GymZones in a Gym. Must be greater than or equal to one.</param>
    Public Sub New(ByVal numGymZones As Integer)
        If numGymZones <= 0 Then
            Throw New Exception("The number of Gym Zones in a Gym must be greater than or equal to one.")
        End If
        _gymZones = New List(Of GymZone)

        For i = 0 To numGymZones
            If i = 0 Then
                'Add the Boss fighter
                _gymZones.Add(New GymZone(True, True))
            Else
                'All other fighters/GymZones in a gym will not be Bosses
                'Initially all other GymZones will be locked. This could change in the future.
                _gymZones.Add(New GymZone(False, False))
            End If
        Next

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
