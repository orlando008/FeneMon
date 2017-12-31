Imports System.Collections.ObjectModel
Imports FeneMonLib

Public Class Gym
    Inherits ViewModelBase

    Private _gymZones As ObservableCollection(Of GymZone)
    Private _name As String
    Private ReadOnly _parentWorldZone As WorldZone

    ''' <summary>
    ''' Generate a new Gym with a number of GymZones.
    ''' </summary>
    ''' <param name="parentWorldZone">The parent World Zone of the Gym.</param>
    ''' <param name="numGymZones">The Number of GymZones in a Gym. Must be greater than or equal to one.</param>
    Public Sub New(ByVal parentWorldZone As WorldZone, ByVal numGymZones As Integer)
        _parentWorldZone = parentWorldZone
        If numGymZones <= 0 Then
            Throw New Exception("The number of Gym Zones in a Gym must be greater than or equal to one.")
        End If
        _gymZones = New ObservableCollection(Of GymZone)

        For i = 0 To numGymZones - 1
            If i = 0 Then
                'Add the Boss fighter
                _gymZones.Add(New GymZone(Me, True, True))
            Else
                'All other fighters/GymZones in a gym will not be Bosses
                'Initially all other GymZones will be locked. This could change in the future.
                _gymZones.Add(New GymZone(Me, False, False))
            End If
        Next

    End Sub

    Public Sub New(ByVal parentWorldZone As WorldZone, gymZones As ObservableCollection(Of GymZone), name As String)
        _parentWorldZone = parentWorldZone
        _gymZones = gymZones
        _name = name
    End Sub

#Region "Public Properties"

    Public Property GymZones As ObservableCollection(Of GymZone)
        Get
            Return _gymZones
        End Get
        Set(value As ObservableCollection(Of GymZone))
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

    Public ReadOnly Property ParentWorldZone As WorldZone
        Get
            Return _parentWorldZone
        End Get
    End Property

#End Region

End Class
