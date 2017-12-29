Imports FeneMonManagerWPF

Public Class MainViewModel
    Inherits ViewModelBase



    Private _pageViewModels As Dictionary(Of Enumerations.PageEnum, MenuViewModelBase)
    Private _currentPageViewModel As MenuViewModelBase

    Public Property MainMenuVM As MainMenuViewModel
    Public Property CurrentWorld As World

    Public Property CurrentPageViewModel As MenuViewModelBase
        Get
            Return _currentPageViewModel
        End Get
        Set(value As MenuViewModelBase)
            _currentPageViewModel = value
            OnPropertyChanged(NameOf(CurrentPageViewModel))
        End Set
    End Property

    Public Sub New()
        _pageViewModels = New Dictionary(Of Enumerations.PageEnum, MenuViewModelBase)()
        _pageViewModels.Add(Enumerations.PageEnum.MainMenu, New MainMenuViewModel())
        MainMenuVM = _pageViewModels(Enumerations.PageEnum.MainMenu)
        CurrentWorld = New World(15)

        _pageViewModels.Add(Enumerations.PageEnum.LoadGame, New LoadGameMenuViewModel())
        _pageViewModels.Add(Enumerations.PageEnum.NewGame, New NewGameMenuViewModel())
        _pageViewModels.Add(Enumerations.PageEnum.WorldMap, New WorldMapViewModel(CurrentWorld))
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
        CurrentPageViewModel = _pageViewModels(page)
    End Sub
End Class
