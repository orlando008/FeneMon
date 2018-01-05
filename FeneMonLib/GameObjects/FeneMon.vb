Imports FeneMonLib
Imports Newtonsoft.Json

<DebuggerDisplay("{Me.Name}")>
Public Class FeneMon

    Private _name As String

    Private _baseStats As FeneMonStats
    Private _effectiveStats As FeneMonStats

    Private _moves As IList(Of FeneMonMove)

    Private _element As Enumerations.ElementEnum

    Public Sub New(name As String, maxHealth As Integer, attack As Integer, defense As Integer, speed As Integer, specialAttack As Integer, specialDefense As Integer, moves As IEnumerable(Of FeneMonMove), element As Enumerations.ElementEnum)
        Me.Name = name
        _baseStats = New FeneMonStats(maxHealth, attack, defense, speed, specialAttack, specialDefense)
        _effectiveStats = New FeneMonStats(maxHealth, attack, defense, speed, specialAttack, specialDefense)
        _moves = moves
        Me.Element = element
        ResetEffectiveStats()
        RestoreToFullHealth()
    End Sub

    <JsonProperty("Name")>
    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    <JsonProperty("MaxHealth")>
    Public ReadOnly Property MaxHealth As Integer
        Get
            Return _baseStats.Health
        End Get
    End Property

    <JsonProperty("Attach")>
    Public ReadOnly Property Attack As Integer
        Get
            Return _baseStats.Attack
        End Get
    End Property

    <JsonProperty("Defense")>
    Public ReadOnly Property Defense As Integer
        Get
            Return _baseStats.Defense
        End Get
    End Property

    <JsonProperty("Speed")>
    Public ReadOnly Property Speed As Integer
        Get
            Return _baseStats.Speed
        End Get
    End Property

    <JsonProperty("SpecialAttack")>
    Public ReadOnly Property SpecialAttack As Integer
        Get
            Return _baseStats.SpecialAttack
        End Get
    End Property

    <JsonProperty("SpecialDefense")>
    Public ReadOnly Property SpecialDefense As Integer
        Get
            Return _baseStats.SpecialDefense
        End Get
    End Property

    <JsonProperty("CurrentHealth")>
    Public Property CurrentHealth As Integer
        Get
            Return _effectiveStats.Health
        End Get
        Set(value As Integer)
            ' health should never go below 0
            If value < 0 Then value = 0

            _effectiveStats.Health = value
        End Set
    End Property

    <JsonProperty("CurrentAttack")>
    Public Property CurrentAttack As Integer
        Get
            Return _effectiveStats.Attack
        End Get
        Set(value As Integer)
            _effectiveStats.Attack = value
        End Set
    End Property

    <JsonProperty("CurrentDefense")>
    Public Property CurrentDefense As Integer
        Get
            Return _effectiveStats.Defense
        End Get
        Set(value As Integer)
            _effectiveStats.Defense = value
        End Set
    End Property

    <JsonProperty("CurrentSpeed")>
    Public Property CurrentSpeed As Integer
        Get
            Return _effectiveStats.Speed
        End Get
        Set(value As Integer)
            _effectiveStats.Speed = value
        End Set
    End Property

    <JsonProperty("CurrentSpecialAttack")>
    Public Property CurrentSpecialAttack As Integer
        Get
            Return _effectiveStats.SpecialAttack
        End Get
        Set(value As Integer)
            _effectiveStats.SpecialAttack = value
        End Set
    End Property

    <JsonProperty("CurrentSpecialDefense")>
    Public Property CurrentSpecialDefense As Integer
        Get
            Return _effectiveStats.SpecialDefense
        End Get
        Set(value As Integer)
            _effectiveStats.SpecialDefense = value
        End Set
    End Property

    <JsonProperty("Moves")>
    Public ReadOnly Property Moves As IReadOnlyList(Of FeneMonMove)
        Get
            Return _moves
        End Get
    End Property

    <JsonProperty("Element")>
    Public Property Element As Enumerations.ElementEnum
        Get
            Return _element
        End Get
        Set(value As Enumerations.ElementEnum)
            _element = value
        End Set
    End Property

    Public ReadOnly Property BaseStats As FeneMonStats
        Get
            Return _baseStats
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
