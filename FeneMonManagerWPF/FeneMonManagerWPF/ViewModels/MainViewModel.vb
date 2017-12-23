Imports FeneMonManagerWPF

Public Class MainViewModel
    Inherits ViewModelBase

    Public Enum PageEnum
        MainMenu
        LoadGame
    End Enum

    Private _pageViewModels As Dictionary(Of PageEnum, MenuViewModelBase)
    Private _currentPageViewModel As MenuViewModelBase

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
        _pageViewModels = New Dictionary(Of PageEnum, MenuViewModelBase)()
        _pageViewModels.Add(PageEnum.MainMenu, New MainMenuViewModel())
        _pageViewModels.Add(PageEnum.LoadGame, New LoadGameMenuViewModel())

        PageViewModelNavigate(PageEnum.MainMenu)
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

    Private Sub PageViewModelNavigate(page As PageEnum)
        CurrentPageViewModel = _pageViewModels(page)
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

    Private Function NewGame()
        Return True
    End Function
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

    Private Function LoadGame()
        Return True
    End Function
#End Region
End Class
