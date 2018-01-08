Imports FeneMonLib

Module TestMonsAndMoves

#Region " Test Mons "

    Function Default_Firemon() As FeneMon
        Return New FeneMon("Firemon", 1, 10, 10, 10, 10, 10, {Default_PhysicalFire(), Default_SpecialIce()}, Enumerations.ElementEnum.Fire)
    End Function

    Function Default_Watermon() As FeneMon
        Return New FeneMon("Watermon", 1, 10, 10, 10, 10, 10, {Default_PhysicalFire(), Default_SpecialIce()}, Enumerations.ElementEnum.Ice)
    End Function

#End Region

#Region " Test Moves "

    Function Default_PhysicalFire() As FeneMonMove
        Return New FeneMonMove("Physical Fire", Enumerations.ElementEnum.Fire, 10, Enumerations.MoveKindEnum.Physical, 1, 2, 0)
    End Function

    Function Default_SpecialIce() As FeneMonMove
        Return New FeneMonMove("Special Ice", Enumerations.ElementEnum.Ice, 10, Enumerations.MoveKindEnum.Special, 1, 2, 0)
    End Function

#End Region

End Module
