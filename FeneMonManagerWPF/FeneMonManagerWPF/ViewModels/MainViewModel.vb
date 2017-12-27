Imports FeneMonManagerWPF

Public Class MainViewModel
    Inherits ViewModelBase



    Private _pageViewModels As Dictionary(Of Enumerations.PageEnum, MenuViewModelBase)
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
        _pageViewModels = New Dictionary(Of Enumerations.PageEnum, MenuViewModelBase)()
        _pageViewModels.Add(Enumerations.PageEnum.MainMenu, New MainMenuViewModel())
        _pageViewModels.Add(Enumerations.PageEnum.LoadGame, New LoadGameMenuViewModel())

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
        CurrentPageViewModel = _pageViewModels(Enumerations.PageEnum.LoadGame)
    End Sub
#End Region
End Class
