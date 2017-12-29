Public Class WorldMapViewModel
    Inherits MenuViewModelBase

    Private _worldMap As World
    Private _gym As Gym

    Public Sub New(world As World)
        _worldMap = world
    End Sub

    Public Property WorldMap As World
        Get
            Return _worldMap
        End Get
        Set(value As World)
            _worldMap = value
            OnPropertyChanged(NameOf(WorldMap))
        End Set
    End Property

    Public Property Gym As Gym
        Get
            Return _gym
        End Get
        Set(value As Gym)
            _gym = value
            OnPropertyChanged(NameOf(Gym))
        End Set
    End Property

    Public Sub NavigateToGym(ByVal worldZone As WorldZone)
        Me.Gym = worldZone.Gym
        RaiseNavigation(Enumerations.PageEnum.Gym)
    End Sub
End Class
