Public Class MenuViewModelBase
    Inherits ViewModelBase

    Public Event Navigate(ByVal page As Enumerations.PageEnum)

    Public Sub RaiseNavigation(ByVal page As Enumerations.PageEnum)
        RaiseEvent Navigate(page)
    End Sub

End Class
