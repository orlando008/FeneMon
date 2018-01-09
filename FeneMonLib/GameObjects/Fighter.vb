Imports System.Collections.ObjectModel
Imports FeneMonLib

Public Class Fighter
    Inherits ViewModelBase

    Private _lastName As String
    Private _firstName As String
    Private _gender As Enumerations.Gender
    Private _personality As Enumerations.Personality
    Private _monsList As ObservableCollection(Of FeneMon)
    Private ReadOnly _parentGymZone As GymZone

    ''' <summary>
    ''' Generate a new Fighter
    ''' </summary>
    ''' <param name="parentGymZone">The parent Gym Zone to the Fighter</param>
    ''' <param name="lastName">Last Name of the Fighter</param>
    ''' <param name="firstName">First Name of the Fighter</param>
    ''' <param name="gender">Gender of the Fighter</param>
    ''' <param name="personality">Gender of the Fighter</param>
    Public Sub New(ByVal parentGymZone As GymZone, ByVal firstName As String, ByVal lastName As String, ByVal gender As Enumerations.Gender, ByVal personality As Enumerations.Personality)
        _monsList = New ObservableCollection(Of FeneMon)()
        _parentGymZone = parentGymZone
        _lastName = lastName
        _firstName = firstName
        _personality = personality

        'Add a random mon to the Fighters list of Mons to start with
        _monsList.Add(GetRandomMon(1))
        _monsList.Add(GetRandomMon(1))
    End Sub

    ''' <summary>
    ''' Generate a new Fighter
    ''' </summary>
    ''' <param name="parentGymZone">The parent Gym Zone to the Fighter</param>
    ''' <param name="lastName">Last Name of the Fighter</param>
    ''' <param name="firstName">First Name of the Fighter</param>
    ''' <param name="gender">Gender of the Fighter</param>
    ''' <param name="personality">Gender of the Fighter</param>
    ''' <param name="monsList">A list of Mons that belong to the fighter</param>
    Public Sub New(ByVal parentGymZone As GymZone, ByVal firstName As String, ByVal lastName As String, ByVal gender As Enumerations.Gender, ByVal personality As Enumerations.Personality, ByVal monsList As ObservableCollection(Of FeneMon))
        _lastName = lastName
        _firstName = _firstName
        _gender = gender
        _parentGymZone = parentGymZone
        _personality = personality
        _monsList = monsList
    End Sub

#Region "Public Properties"

    Public Property LastName As String
        Get
            Return _lastName
        End Get
        Set(value As String)
            _lastName = value
        End Set
    End Property

    Public Property MonsList As ObservableCollection(Of FeneMon)
        Get
            Return _monsList
        End Get
        Set(value As ObservableCollection(Of FeneMon))
            _monsList = value
        End Set
    End Property

    Public Property FirstName As String
        Get
            Return _firstName
        End Get
        Set(value As String)
            _firstName = value
        End Set
    End Property

    Public ReadOnly Property ParentGymZone As GymZone
        Get
            Return _parentGymZone
        End Get
    End Property

    Public Property Gender As Enumerations.Gender
        Get
            Return _gender
        End Get
        Set(value As Enumerations.Gender)
            _gender = value
        End Set
    End Property

    Public ReadOnly Property FormattedName As String
        Get
            Return FirstName & " " & LastName
        End Get
    End Property

    Public ReadOnly Property PowerLevel As Integer
        Get
            If _monsList Is Nothing OrElse _monsList.Count = 0 Then
                Return 0
            Else
                Return _monsList.Sum(Function(f) f.BaseStats.PowerLevel)
            End If
        End Get
    End Property
#End Region

#Region " Public Methods "

    Public Function PromptNextMon(opponentMon As FeneMon) As FeneMon
        ' todo: ai logic / strategies

        ' assume the next mon in line is good enough
        Return MonsList.FirstOrDefault(Function(m) m.CurrentHealth > 0)
    End Function

#End Region

#Region "Private Methods"

    Private Function ChoseFeneMove(ByVal enemyMon As FeneMon) As FeneMonMove
        'Will there be an Active Mon in the mons list like in PokeMon?
        'Just going to start with the first mon being the active one for now.
        Dim chosenMon As FeneMon = _monsList(0)

        'most powerful move
        Dim chosenMove As FeneMonMove = chosenMon.Moves.ToList.OrderBy(Function(x) x.Power)

        Return chosenMove
    End Function

#End Region

End Class
