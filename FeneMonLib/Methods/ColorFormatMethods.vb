Imports System.Windows.Media

Public Class ColorFormatMethods

    Private Shared _affinityBackgroundBrushDictionary As New Dictionary(Of Enumerations.ElementEnum, SolidColorBrush)
    Private Shared _affinityForegroundBrushDictionary As New Dictionary(Of Enumerations.ElementEnum, SolidColorBrush)
    Public Shared Function GetAffinityBackgroundColor(ByVal affinity As Enumerations.ElementEnum) As SolidColorBrush
        If _affinityBackgroundBrushDictionary.ContainsKey(affinity) = False Then
            Select Case affinity
                Case Enumerations.ElementEnum.Bug
                    _affinityBackgroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.LimeGreen))
                Case Enumerations.ElementEnum.Dragon
                    _affinityBackgroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.Black))
                Case Enumerations.ElementEnum.Electric
                    _affinityBackgroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.Yellow))
                Case Enumerations.ElementEnum.Fighting
                    _affinityBackgroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.RosyBrown))
                Case Enumerations.ElementEnum.Fire
                    _affinityBackgroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.Orange))
                Case Enumerations.ElementEnum.Flying
                    _affinityBackgroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.LightSkyBlue))
                Case Enumerations.ElementEnum.Ghost
                    _affinityBackgroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.Indigo))
                Case Enumerations.ElementEnum.Grass
                    _affinityBackgroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.LawnGreen))
                Case Enumerations.ElementEnum.Ground
                    _affinityBackgroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.Peru))
                Case Enumerations.ElementEnum.Ice
                    _affinityBackgroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.AliceBlue))
                Case Enumerations.ElementEnum.Normal
                    _affinityBackgroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.BlanchedAlmond))
                Case Enumerations.ElementEnum.Poison
                    _affinityBackgroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.DarkMagenta))
                Case Enumerations.ElementEnum.Psychic
                    _affinityBackgroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.MediumVioletRed))
                Case Enumerations.ElementEnum.Rock
                    _affinityBackgroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.SlateGray))
                Case Enumerations.ElementEnum.Water
                    _affinityBackgroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.RoyalBlue))
            End Select
        End If

        Return _affinityBackgroundBrushDictionary(affinity)
    End Function

    Public Shared Function GetAffinityForegroundColor(ByVal affinity As Enumerations.ElementEnum) As SolidColorBrush
        If _affinityForegroundBrushDictionary.ContainsKey(affinity) = False Then
            Select Case affinity
                Case Enumerations.ElementEnum.Bug
                    _affinityForegroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.Black))
                Case Enumerations.ElementEnum.Dragon
                    _affinityForegroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.White))
                Case Enumerations.ElementEnum.Electric
                    _affinityForegroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.Black))
                Case Enumerations.ElementEnum.Fighting
                    _affinityForegroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.Black))
                Case Enumerations.ElementEnum.Fire
                    _affinityForegroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.Black))
                Case Enumerations.ElementEnum.Flying
                    _affinityForegroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.Black))
                Case Enumerations.ElementEnum.Ghost
                    _affinityForegroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.White))
                Case Enumerations.ElementEnum.Grass
                    _affinityForegroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.Black))
                Case Enumerations.ElementEnum.Ground
                    _affinityForegroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.Black))
                Case Enumerations.ElementEnum.Ice
                    _affinityForegroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.Black))
                Case Enumerations.ElementEnum.Normal
                    _affinityForegroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.Black))
                Case Enumerations.ElementEnum.Poison
                    _affinityForegroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.White))
                Case Enumerations.ElementEnum.Psychic
                    _affinityForegroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.White))
                Case Enumerations.ElementEnum.Rock
                    _affinityForegroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.Black))
                Case Enumerations.ElementEnum.Water
                    _affinityForegroundBrushDictionary.Add(affinity, New SolidColorBrush(Colors.Black))
            End Select
        End If

        Return _affinityForegroundBrushDictionary(affinity)
    End Function
End Class
