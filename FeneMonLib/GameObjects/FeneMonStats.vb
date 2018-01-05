Public Class FeneMonStats

    Private _health As Integer
    Private _attack As Integer
    Private _defense As Integer
    Private _speed As Integer
    Private _specialAttack As Integer
    Private _specialDefense As Integer

    Public Sub New(health As Integer, attack As Integer, defense As Integer, speed As Integer, specialAttack As Integer, specialDefense As Integer)
        Me.Health = health
        Me.Attack = attack
        Me.Defense = defense
        Me.Speed = speed
        Me.SpecialAttack = specialAttack
        Me.SpecialDefense = specialDefense
    End Sub

    Public Property Health As Integer
        Get
            Return _health
        End Get
        Set(value As Integer)
            _health = value
        End Set
    End Property

    Public Property Attack As Integer
        Get
            Return _attack
        End Get
        Set(value As Integer)
            _attack = value
        End Set
    End Property

    Public Property Defense As Integer
        Get
            Return _defense
        End Get
        Set(value As Integer)
            _defense = value
        End Set
    End Property

    Public Property Speed As Integer
        Get
            Return _speed
        End Get
        Set(value As Integer)
            _speed = value
        End Set
    End Property

    Public Property SpecialAttack As Integer
        Get
            Return _specialAttack
        End Get
        Set(value As Integer)
            _specialAttack = value
        End Set
    End Property

    Public Property SpecialDefense As Integer
        Get
            Return _specialDefense
        End Get
        Set(value As Integer)
            _specialDefense = value
        End Set
    End Property

    Public ReadOnly Property PowerLevel As Integer
        Get
            Return Health + Attack + SpecialAttack + Speed + Defense + SpecialDefense
        End Get
    End Property
End Class
