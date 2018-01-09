Public Class FeneMonViewerControl
    Private Sub btnClose_Click(sender As Object, e As RoutedEventArgs)
        CType(sender.DataContext, FeneMon).ViewingDetails = False
    End Sub
End Class
