Imports FeneMonLib

Public Class MainMenuViewModel
    Inherits MenuViewModelBase

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
End Class
