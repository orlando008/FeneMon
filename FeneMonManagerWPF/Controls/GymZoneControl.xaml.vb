Public Class GymZoneControl
    Public Property WorldMapVM As WorldMapViewModel

    Private Sub btnMonDetails_Click(sender As Object, e As RoutedEventArgs)
        For Each gz As GymZone In WorldMapVM.Gym.GymZones
            If gz.Fighter IsNot Nothing Then
                For Each m As FeneMon In gz.Fighter.MonsList
                    m.ViewingDetails = False
                Next
            End If
        Next

        CType(sender.DataContext, FeneMon).ViewingDetails = True
    End Sub
End Class
