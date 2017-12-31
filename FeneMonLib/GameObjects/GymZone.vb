Imports FeneMonLib

Public Class GymZone
    Inherits ViewModelBase

    Private _fighter As Fighter
    Private _isBossZone As Boolean
    Private _isUnlocked As Boolean
    Private ReadOnly _parentGym As Gym

    ''' <summary>
    ''' Generate a new GymZone.
    ''' </summary>
    ''' <param name="parentGym">The parent Gym to the GymZone.</param>
    ''' <param name="isBossZone">Indicates whether or not the GymZone is a boss Zone.</param>
    ''' <param name="isUnlocked">Indicates whether or not the GymZone is locked/unlocked to the player.</param>
    Public Sub New(ByVal parentGym As Gym, ByVal isBossZone As Boolean, ByVal isUnlocked As Boolean)
        _parentGym = parentGym
        _isBossZone = isBossZone
        _isUnlocked = isUnlocked

        'TODO JK: Make the Fighters Name Random
        _fighter = New Fighter(Me, "lastName", "firstName")
    End Sub

    Public Sub New(ByVal parentGym As Gym, fighter As Fighter)
        _parentGym = parentGym
        _fighter = fighter
    End Sub

#Region "Public Properties"

    Public Property Fighter As Fighter
        Get
            Return _fighter
        End Get
        Set(value As Fighter)
            _fighter = value
        End Set
    End Property

    Public Property IsBossZone As Boolean
        Get
            Return _isBossZone
        End Get
        Set(value As Boolean)
            _isBossZone = value
        End Set
    End Property

    Public Property IsUnlocked As Boolean
        Get
            Return _isUnlocked
        End Get
        Set(value As Boolean)
            _isUnlocked = value
        End Set
    End Property

    Public ReadOnly Property ParentGym As Gym
        Get
            Return _parentGym
        End Get
    End Property

#End Region

End Class
