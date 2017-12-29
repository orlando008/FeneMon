Public Class FeneMon

    ' base stats
    Private _maxHealth As Integer
    Private _attack As Integer
    Private _defense As Integer
    Private _speed As Integer
    Private _specialAttack As Integer
    Private _specialDefense As Integer

    ' effective stats
    Private _currentHealth As Integer
    Private _currentAttack As Integer
    Private _currentDefense As Integer
    Private _currentSpeed As Integer
    Private _currentSpecialAttack As Integer
    Private _currentSpecialDefense As Integer

    Private _moves As IList(Of FeneMonMove)

    Public Sub New(maxHealth As Integer, attack As Integer, defense As Integer, speed As Integer, specialAttack As Integer, specialDefense As Integer, moves As IEnumerable(Of FeneMonMove))
        Me.MaxHealth = maxHealth
        Me.Attack = attack
        Me.Defense = defense
        Me.Speed = speed
        Me.SpecialAttack = specialAttack
        Me.SpecialDefense = specialDefense
        _moves = moves
        ResetEffectiveStats()
        RestoreToFullHealth()
    End Sub

    Public Property MaxHealth As Integer
        Get
            Return _maxHealth
        End Get
        Set(value As Integer)
            _maxHealth = value
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

    Public Property CurrentHealth As Integer
        Get
            Return _currentHealth
        End Get
        Set(value As Integer)
            ' health should never go below 0
            If value < 0 Then value = 0

            _currentHealth = value
        End Set
    End Property

    Public Property CurrentAttack As Integer
        Get
            Return _currentAttack
        End Get
        Set(value As Integer)
            _currentAttack = value
        End Set
    End Property

    Public Property CurrentDefense As Integer
        Get
            Return _currentDefense
        End Get
        Set(value As Integer)
            _currentDefense = value
        End Set
    End Property

    Public Property CurrentSpeed As Integer
        Get
            Return _currentSpeed
        End Get
        Set(value As Integer)
            _currentSpeed = value
        End Set
    End Property

    Public Property CurrentSpecialAttack As Integer
        Get
            Return _currentSpecialAttack
        End Get
        Set(value As Integer)
            _currentSpecialAttack = value
        End Set
    End Property

    Public Property CurrentSpecialDefense As Integer
        Get
            Return _currentSpecialDefense
        End Get
        Set(value As Integer)
            _currentSpecialDefense = value
        End Set
    End Property

    Public ReadOnly Property Moves As IReadOnlyList(Of FeneMonMove)
        Get
            Return _moves
        End Get
    End Property

    Public Sub ResetEffectiveStats()
        Me.CurrentAttack = Me.Attack
        Me.CurrentDefense = Me.Defense
        Me.CurrentSpecialAttack = Me.SpecialAttack
        Me.CurrentSpecialDefense = Me.SpecialDefense
        Me.CurrentSpeed = Me.Speed
    End Sub

    Public Sub RestoreToFullHealth()
        Me.CurrentHealth = Me.MaxHealth
    End Sub
End Class
