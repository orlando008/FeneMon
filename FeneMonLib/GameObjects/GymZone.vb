Imports FeneMonLib

Public Class GymZone

    Private _fighter As Fighter
    Private _isBossZone As Boolean
    Private _isUnlocked As Boolean

    ''' <summary>
    ''' Generate a new GymZone.
    ''' </summary>
    ''' <param name="isBossZone">Indicates whether or not the GymZone is a boss Zone.</param>
    Public Sub New(ByVal isBossZone As Boolean, ByVal isUnlocked As Boolean)
        _isBossZone = isBossZone
        _isUnlocked = isUnlocked
        'TODO JK: Make the Fighters Name Random
        _fighter = New Fighter("Fighter's Name")
    End Sub

    Public Sub New(fighter As Fighter)
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

#End Region

End Class
