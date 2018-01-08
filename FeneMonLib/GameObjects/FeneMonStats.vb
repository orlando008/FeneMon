Public Class FeneMonStats

    Private _vitality As Integer
    Private _attack As Integer
    Private _defense As Integer
    Private _speed As Integer
    Private _specialAttack As Integer
    Private _specialDefense As Integer

    Public Sub New(vitality As Integer, attack As Integer, defense As Integer, speed As Integer, specialAttack As Integer, specialDefense As Integer)
        Me.Vitality = vitality
        Me.Attack = attack
        Me.Defense = defense
        Me.Speed = speed
        Me.SpecialAttack = specialAttack
        Me.SpecialDefense = specialDefense
    End Sub

    Public Property Vitality As Integer
        Get
            Return _vitality
        End Get
        Set(value As Integer)
            _vitality = value
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
            Return Vitality + Attack + SpecialAttack + Speed + Defense + SpecialDefense
        End Get
    End Property
End Class
