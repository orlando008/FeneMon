Public Class WorldMapViewModel
    Inherits MenuViewModelBase

    Private _worldMap As World

    Public Sub New(world As World)
        _worldMap = world
    End Sub

    Public Property WorldMap As World
        Get
            Return _worldMap
        End Get
        Set(value As World)
            _worldMap = value
        End Set
    End Property
End Class
