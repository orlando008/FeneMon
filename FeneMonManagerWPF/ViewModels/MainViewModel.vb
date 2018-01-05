Imports FeneMonManagerWPF

Public Class MainViewModel
    Inherits ViewModelBase



    Private _pageViewModels As Dictionary(Of Enumerations.PageEnum, MenuViewModelBase)
    Private _currentPageViewModel As MenuViewModelBase
    Private _currentWorld As World

    Public Property MainMenuVM As MainMenuViewModel
    Public Property CurrentWorld As World
        Get
            Return _currentWorld
        End Get
        Set(value As World)
            _currentWorld = value
            OnPropertyChanged(NameOf(CurrentWorld))
        End Set
    End Property

    Public ReadOnly Property CurrentWorldViewModel As WorldMapViewModel
        Get
            Return _pageViewModels(Enumerations.PageEnum.WorldMap)
        End Get
    End Property

    Public Property CurrentPageViewModel As MenuViewModelBase
        Get
            Return _currentPageViewModel
        End Get
        Set(value As MenuViewModelBase)
            _currentPageViewModel = value
            OnPropertyChanged(NameOf(CurrentPageViewModel))
        End Set
    End Property

    <DependsUpon(NameOf(CurrentWorld))>
    Public ReadOnly Property HUDVisibility As Visibility
        Get
            If CurrentWorld Is Nothing Then
                Return Visibility.Collapsed
            Else
                Return Visibility.Visible
            End If
        End Get
    End Property


    Public Sub New()
        _pageViewModels = New Dictionary(Of Enumerations.PageEnum, MenuViewModelBase)()
        _pageViewModels.Add(Enumerations.PageEnum.MainMenu, New MainMenuViewModel(Me))
        MainMenuVM = _pageViewModels(Enumerations.PageEnum.MainMenu)

        _pageViewModels.Add(Enumerations.PageEnum.LoadGame, New LoadGameMenuViewModel())
        _pageViewModels.Add(Enumerations.PageEnum.NewGame, New NewGameMenuViewModel(Me))
        _pageViewModels.Add(Enumerations.PageEnum.WorldMap, New WorldMapViewModel(Nothing))
        _pageViewModels.Add(Enumerations.PageEnum.Gym, New GymViewModel(_pageViewModels(Enumerations.PageEnum.WorldMap)))

        WireUpPageViewModelEvents()

        PageViewModelNavigate(Enumerations.PageEnum.MainMenu)
    End Sub

    Private Sub WireUpPageViewModelEvents()
        For Each pvm As MenuViewModelBase In _pageViewModels.Values
            AddHandler pvm.Navigate, AddressOf PageViewModelNavigate
        Next
    End Sub

    Private Sub UnwirePageViewModelEvents()
        For Each pvm As MenuViewModelBase In _pageViewModels.Values
            RemoveHandler pvm.Navigate, AddressOf PageViewModelNavigate
        Next
    End Sub

    Private Sub PageViewModelNavigate(page As Enumerations.PageEnum)
        If CType(_pageViewModels(Enumerations.PageEnum.WorldMap), WorldMapViewModel).WorldMap Is Nothing Then
            CType(_pageViewModels(Enumerations.PageEnum.WorldMap), WorldMapViewModel).WorldMap = CurrentWorld
        End If

        CurrentPageViewModel = _pageViewModels(page)
    End Sub

#Region "Back To Main Menu Command"

    Private _BackToMainMenuCommand As RelayCommand

    Public ReadOnly Property BackToMainMenuCommand() As ICommand
        Get
            If _BackToMainMenuCommand Is Nothing Then
                _BackToMainMenuCommand = New RelayCommand(New Action(Of Object)(AddressOf BackToMainMenu), New Predicate(Of Object)(AddressOf CanBackToMainMenu))
            End If
            Return _BackToMainMenuCommand
        End Get
    End Property

    Private Function CanBackToMainMenu() As Boolean
        Return True
    End Function

    Private Sub BackToMainMenu()
        CurrentWorld = Nothing
        PageViewModelNavigate(Enumerations.PageEnum.MainMenu)
    End Sub
#End Region

End Class
