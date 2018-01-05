Imports System.Collections.ObjectModel
Imports FeneMonLib

Public Class Fighter
    Inherits ViewModelBase

    Private _lastName As String
    Private _firstName As String
    Private _gender As Enumerations.Gender
    Private _monsList As ObservableCollection(Of FeneMon)
    Private ReadOnly _parentGymZone As GymZone

    ''' <summary>
    ''' Generate a new Fighter
    ''' </summary>
    ''' <param name="parentGymZone">The parent Gym Zone to the Fighter</param>
    ''' <param name="lastName">Last Name of the Fighter</param>
    ''' <param name="firstName">First Name of the Fighter</param>
    ''' <param name="gender">Gender of the Fighter</param>
    Public Sub New(ByVal parentGymZone As GymZone, ByVal lastName As String, ByVal firstName As String, ByVal gender As Enumerations.Gender)
        _monsList = New ObservableCollection(Of FeneMon)()
        _parentGymZone = parentGymZone
        _lastName = lastName
        _firstName = firstName

        'Add a random mon to the Fighters list of Mons to start with
        _monsList.Add(JsonParsingMethods.GetRandomMon())
    End Sub

    ''' <summary>
    ''' Generate a new Fighter
    ''' </summary>
    ''' <param name="parentGymZone">The parent Gym Zone to the Fighter</param>
    ''' <param name="lastName">Last Name of the Fighter</param>
    ''' <param name="firstName">First Name of the Fighter</param>
    ''' <param name="gender">Gender of the Fighter</param>
    ''' <param name="monsList">A list of Mons that belong to the fighter</param>
    Public Sub New(ByVal parentGymZone As GymZone, ByVal lastName As String, ByVal firstName As String, ByVal gender As Enumerations.Gender, ByVal monsList As ObservableCollection(Of FeneMon))
        _lastName = lastName
        _firstName = _firstName
        _parentGymZone = parentGymZone
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
#End Region

End Class
