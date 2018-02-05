Imports FeneMonLib

Public Class MainMenuViewModel
    Inherits MenuViewModelBase
    Private _mainVM As MainViewModel

    Public Sub New(ByRef mainVM As MainViewModel)
        MyBase.New()
        _mainVM = mainVM
    End Sub

#Region "New Game Command"

    Private _NewGameCommand As RelayCommand

    Public ReadOnly Property NewGameCommand() As ICommand
        Get
            If _NewGameCommand Is Nothing Then
                _NewGameCommand = New RelayCommand(New Action(Of Object)(AddressOf NewGame), New Predicate(Of Object)(AddressOf CanNewGame))
            End If
            Return _NewGameCommand
        End Get
    End Property

    Private Function CanNewGame() As Boolean
        Return True
    End Function

    Private Sub NewGame()
        RaiseNavigation(Enumerations.PageEnum.NewGame)
    End Sub
#End Region


#Region "Load Game Command"

    Private _LoadGameCommand As RelayCommand

    Public ReadOnly Property LoadGameCommand() As ICommand
        Get
            If _LoadGameCommand Is Nothing Then
                _LoadGameCommand = New RelayCommand(New Action(Of Object)(AddressOf LoadGame), New Predicate(Of Object)(AddressOf CanLoadGame))
            End If
            Return _LoadGameCommand
        End Get
    End Property

    Private Function CanLoadGame() As Boolean
        Return True
    End Function

    Private Sub LoadGame()
        RaiseNavigation(Enumerations.PageEnum.LoadGame)
    End Sub
#End Region


#Region "World Map Command"

    Private _WorldMapCommand As RelayCommand

    Public ReadOnly Property WorldMapCommand() As ICommand
        Get
            If _WorldMapCommand Is Nothing Then
                _WorldMapCommand = New RelayCommand(New Action(Of Object)(AddressOf WorldMap), New Predicate(Of Object)(AddressOf CanWorldMap))
            End If
            Return _WorldMapCommand
        End Get
    End Property

    Private Function CanWorldMap() As Boolean
        Return True
    End Function

    Private Sub WorldMap()
        RaiseNavigation(Enumerations.PageEnum.WorldMap)
    End Sub
#End Region


#Region "Home Gym Command"

    Private _HomeGymCommand As RelayCommand

    Public ReadOnly Property HomeGymCommand() As ICommand
        Get
            If _HomeGymCommand Is Nothing Then
                _HomeGymCommand = New RelayCommand(New Action(Of Object)(AddressOf HomeGym), New Predicate(Of Object)(AddressOf CanHomeGym))
            End If
            Return _HomeGymCommand
        End Get
    End Property

    Private Function CanHomeGym() As Boolean
        Return True
    End Function

    Private Sub HomeGym()
        _mainVM.CurrentWorldViewModel.Gym = _mainVM.CurrentWorld.WorldZones.FirstOrDefault(Function(f) f.IsPlayerHome).Gym
        RaiseNavigation(Enumerations.PageEnum.Gym)
    End Sub
#End Region

#Region "Advance DayCommand"

    Private _AdvanceDayCommand As RelayCommand

    Public ReadOnly Property AdvanceDayCommand() As ICommand
        Get
            If _AdvanceDayCommand Is Nothing Then
                _AdvanceDayCommand = New RelayCommand(New Action(Of Object)(AddressOf AdvanceDay), New Predicate(Of Object)(AddressOf CanAdvanceDay))
            End If
            Return _AdvanceDayCommand
        End Get
    End Property

    Private Function CanAdvanceDay() As Boolean
        Return True
    End Function

    Private Sub AdvanceDay()
        _mainVM.CurrentWorldViewModel.WorldMap.AdvanceDay()
    End Sub
#End Region
End Class
