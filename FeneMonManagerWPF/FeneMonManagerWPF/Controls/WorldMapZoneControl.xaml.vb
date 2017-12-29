Public Class WorldMapZoneControl
    Public Property WorldMapVM As WorldMapViewModel

    Private Sub btnViewGym_Click(sender As Object, e As RoutedEventArgs) Handles btnViewGym.Click
        WorldMapVM.Gym = CType(sender.DataContext, WorldZone).Gym
        WorldMapVM.RaiseNavigation(Enumerations.PageEnum.Gym)
    End Sub
End Class
