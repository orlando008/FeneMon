Public Class WorldMapControl
    Private Sub WorldMap_DataContextChanged(sender As Object, e As DependencyPropertyChangedEventArgs) Handles Me.DataContextChanged
        If worldZone1.DataContext Is Nothing Then
            Dim wmap As World = CType(Me.DataContext, WorldMapViewModel).WorldMap

            If wmap Is Nothing Then
                Exit Sub
            End If

            Dim zoneCount As Integer = 0
            If wmap.WorldZones IsNot Nothing Then
                zoneCount = wmap.WorldZones.Count
            End If


            For index = 1 To zoneCount
                Dim c As WorldMapZoneControl = Nothing
                Select Case index
                    Case 1
                        c = worldZone1
                    Case 2
                        c = worldZone2
                    Case 3
                        c = worldZone3
                    Case 4
                        c = worldZone4
                    Case 5
                        c = worldZone5
                    Case 6
                        c = worldZone6
                    Case 7
                        c = worldZone7
                    Case 8
                        c = worldZone8
                    Case 9
                        c = worldZone9
                    Case 10
                        c = worldZone10
                    Case 11
                        c = worldZone11
                    Case 12
                        c = worldZone12
                    Case 13
                        c = worldZone13
                    Case 14
                        c = worldZone14
                    Case 15
                        c = worldZone15
                End Select

                If c IsNot Nothing Then
                    c.DataContext = wmap.WorldZones(index - 1)
                    c.WorldMapVM = CType(Me.DataContext, WorldMapViewModel)
                End If
            Next

        End If
    End Sub
End Class
