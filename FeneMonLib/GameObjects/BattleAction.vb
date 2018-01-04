Imports FeneMonLib

Public Class BattleAction

    Private _user As FeneMon
    Private _target As FeneMon
    Private _move As FeneMonMove

    Public Sub New(user As FeneMon, target As FeneMon, move As FeneMonMove)
        Me.User = user
        Me.Target = target
        Me.Move = move
    End Sub

    Public Property User As FeneMon
        Get
            Return _user
        End Get
        Set(value As FeneMon)
            _user = value
        End Set
    End Property

    Public Property Target As FeneMon
        Get
            Return _target
        End Get
        Set(value As FeneMon)
            _target = value
        End Set
    End Property

    Public Property Move As FeneMonMove
        Get
            Return _move
        End Get
        Set(value As FeneMonMove)
            _move = value
        End Set
    End Property

End Class
