Imports System.Collections.ObjectModel

Public Class World
    Inherits ViewModelBase

    Private _worldZones As ObservableCollection(Of WorldZone)
    Private _currentDate As Date

    ''' <summary>
    ''' Generate a new FeneMon world.
    ''' </summary>
    Public Sub New()
        _worldZones = New ObservableCollection(Of WorldZone)
        CurrentDate = New Date(1999, 1, 1)

        'Generate World Zones for each affinity.
        For i = 0 To CType([Enum].GetValues(GetType(Enumerations.ElementEnum)), Integer()).Last
            _worldZones.Add(New WorldZone(Me, i))
        Next
    End Sub

    ''' <summary>
    ''' Generate a new FeneMon world.
    ''' </summary>
    ''' <param name="GymsPerZone">Sets that default amount of GymZones that will exist in a Gym</param>
    Public Sub New(ByVal GymsPerZone As Integer)
        _worldZones = New ObservableCollection(Of WorldZone)
        CurrentDate = New Date(1999, 1, 1)
        'Generate World Zones for each affinity.
        For i = 0 To CType([Enum].GetValues(GetType(Enumerations.ElementEnum)), Integer()).Last
            _worldZones.Add(New WorldZone(Me, i, GymsPerZone))

        Next
    End Sub


#Region "Public Properties"

    ''' <summary>
    ''' A property that returns the list of WorldZones in a FeneMon World.
    ''' </summary>
    ''' <returns>List(Of WorldZone)</returns>
    Public Property WorldZones As ObservableCollection(Of WorldZone)
        Get
            Return _worldZones
        End Get
        Set(value As ObservableCollection(Of WorldZone))
            _worldZones = value
        End Set
    End Property

    Public Property CurrentDate As Date
        Get
            Return _currentDate
        End Get
        Set(value As Date)
            _currentDate = value
        End Set
    End Property

#End Region

End Class
