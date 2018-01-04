Public Class GymViewModel
    Inherits MenuViewModelBase

    Public Property ParentWorldMapVM As WorldMapViewModel


    Public Sub New(ByRef parentWorldMapVM As WorldMapViewModel)
        Me.ParentWorldMapVM = parentWorldMapVM
    End Sub
End Class
