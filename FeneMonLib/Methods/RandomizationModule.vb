Public Module RandomizationModule
    Private _rng As Random

    Public Function RNG() As Random
        If _rng Is Nothing Then
            _rng = New Random(Guid.NewGuid().GetHashCode())
        End If

        Return _rng
    End Function

    Public Function GetRandomMon(ByVal initialLevel As Integer) As FeneMon
        Dim pointsToSpend As Integer = 10 + (initialLevel * 2) 'Level one mons have 12 points.  They get 2 points per level.
        Dim health As Integer = 5
        Dim speed As Integer = 1
        Dim attack As Integer = 1
        Dim defense As Integer = 1
        Dim specialAttack As Integer = 1
        Dim specialDefense As Integer = 1

        pointsToSpend -= 10

        While pointsToSpend > 0
            Dim stat As Enumerations.MainStatTypeEnum = RNG.Next([Enum].GetValues(GetType(Enumerations.MainStatTypeEnum)).Length)

            Select Case stat
                Case Enumerations.MainStatTypeEnum.HP
                    health += 1
                Case Enumerations.MainStatTypeEnum.Speed
                    speed += 1
                Case Enumerations.MainStatTypeEnum.Attack
                    attack += 1
                Case Enumerations.MainStatTypeEnum.Defense
                    defense += 1
                Case Enumerations.MainStatTypeEnum.SpecialAttack
                    specialAttack += 1
                Case Enumerations.MainStatTypeEnum.SpecialDefense
                    specialDefense += 1
                Case Else
                    Continue While
            End Select

            pointsToSpend -= 1
        End While

        Dim elementType As Enumerations.ElementEnum = RNG.Next([Enum].GetValues(GetType(Enumerations.ElementEnum)).Length)
        Dim elementName As String = [Enum].GetName(GetType(Enumerations.ElementEnum), elementType)
        elementName &= "Mon"
        'Todo: Moves.

        Return New FeneMon(elementName, health, attack, defense, speed, speed, specialAttack, Nothing, elementType)
    End Function
End Module
