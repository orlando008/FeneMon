Imports System.Collections.ObjectModel
Imports FeneMonManagerWPF

Public Class NewGameMenuViewModel
    Inherits MenuViewModelBase

    Private _typeList As New ObservableCollection(Of ComboBoxListItem)
    Private _statList As New ObservableCollection(Of ComboBoxListItem)
    Private _selectedType As Enumerations.ElementEnum
    Private _selectedStat As Enumerations.MainStatTypeEnum
    Private _mainViewModel As MainViewModel

    Public Sub New(ByRef mainVM As MainViewModel)
        For Each e As Enumerations.ElementEnum In [Enum].GetValues(GetType(Enumerations.ElementEnum))
            _typeList.Add(New ComboBoxListItem([Enum].GetName(GetType(Enumerations.ElementEnum), e), e))
        Next

        For Each e As Enumerations.MainStatTypeEnum In [Enum].GetValues(GetType(Enumerations.MainStatTypeEnum))
            _statList.Add(New ComboBoxListItem([Enum].GetName(GetType(Enumerations.MainStatTypeEnum), e), e))
        Next

        MainViewModel = mainVM
    End Sub

#Region "Start New Game Command"

    Private _StartNewGameCommand As RelayCommand

    Public ReadOnly Property StartNewGameCommand() As ICommand
        Get
            If _StartNewGameCommand Is Nothing Then
                _StartNewGameCommand = New RelayCommand(New Action(Of Object)(AddressOf StartNewGame), New Predicate(Of Object)(AddressOf CanStartNewGame))
            End If
            Return _StartNewGameCommand
        End Get
    End Property

    Private Function CanStartNewGame() As Boolean
        Return True
    End Function

    Private Sub StartNewGame()
        MainViewModel.CurrentWorld = New World()

        RaiseNavigation(Enumerations.PageEnum.WorldMap)
    End Sub
#End Region


    Public Property SelectedType As Enumerations.ElementEnum
        Get
            Return _selectedType
        End Get
        Set(value As Enumerations.ElementEnum)
            _selectedType = value
        End Set
    End Property

    Public Property SelectedStat As Enumerations.MainStatTypeEnum
        Get
            Return _selectedStat
        End Get
        Set(value As Enumerations.MainStatTypeEnum)
            _selectedStat = value
        End Set
    End Property

    Public Property TypeList As ObservableCollection(Of ComboBoxListItem)
        Get
            Return _typeList
        End Get
        Set(value As ObservableCollection(Of ComboBoxListItem))
            _typeList = value
        End Set
    End Property

    Public Property StatList As ObservableCollection(Of ComboBoxListItem)
        Get
            Return _statList
        End Get
        Set(value As ObservableCollection(Of ComboBoxListItem))
            _statList = value
        End Set
    End Property

    Public Property MainViewModel As MainViewModel
        Get
            Return _mainViewModel
        End Get
        Set(value As MainViewModel)
            _mainViewModel = value
        End Set
    End Property
End Class

Public Class ComboBoxListItem
    Public Property Text As String
    Public Property Value As Object

    Public Sub New(text As String, val As Object)
        Me.Text = text
        Me.Value = val
    End Sub

End Class
