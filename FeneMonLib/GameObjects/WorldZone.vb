Imports FeneMonLib

Public Class WorldZone
    Inherits ViewModelBase


    Private _gym As Gym
    Private _affinity As Enumerations.ElementEnum
    Private ReadOnly _parentWorld As World

    ''' <summary>
    ''' Generate a new World Zone. The Default number of GymZones in a Gym is 15.
    ''' </summary>
    ''' <param name="parentWorld">The parent world of the World Zone.</param>
    ''' <param name="affinity">Affinity of the world zone.</param>
    Public Sub New(ByVal parentWorld As World, ByVal affinity As Enumerations.ElementEnum)
        _parentWorld = parentWorld
        _affinity = affinity
        _gym = New Gym(Me, 15)

    End Sub

    ''' <summary>
    ''' Generate a new World Zone.
    ''' </summary>
    ''' <param name="parentWorld">The parent world of the World Zone.</param>
    ''' <param name="affinity">Affinity of the world zone.</param>
    ''' <param name="numGymZones">Number of Gym Zones in a Gym</param>
    Public Sub New(ByVal parentWorld As World, ByVal affinity As Enumerations.ElementEnum, ByVal numGymZones As Integer)
        _parentWorld = parentWorld
        _affinity = affinity
        _gym = New Gym(Me, numGymZones)

    End Sub


#Region "Public Properties"

    Public Property Gym As Gym
        Get
            Return _gym
        End Get
        Set(value As Gym)
            _gym = value
        End Set
    End Property

    Public Property Affinity As Enumerations.ElementEnum
        Get
            Return _affinity
        End Get
        Set(value As Enumerations.ElementEnum)
            _affinity = value
        End Set
    End Property

    Public ReadOnly Property ParentWorld As World
        Get
            Return _parentWorld
        End Get
    End Property

#End Region

End Class
