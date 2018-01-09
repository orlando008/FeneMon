Imports FeneMonLib

<TestClass> Public Class MatchTests

    <TestMethod> Public Sub SimulatedMatch_ChooseMons_InventoryOrder()

        Dim fighterUnderTest As Fighter = Default_Fighter()

        fighterUnderTest.AddMon(New FeneMon("Firemon", 1, 10, 10, 10, 10, 10, {}, Enumerations.ElementEnum.Fire))
        fighterUnderTest.AddMon(New FeneMon("Bugmon", 1, 10, 10, 10, 10, 10, {}, Enumerations.ElementEnum.Bug))
        fighterUnderTest.AddMon(New FeneMon("Icemon", 1, 10, 10, 10, 10, 10, {}, Enumerations.ElementEnum.Ice))

        Dim match As New ExhibitionMatchState
        match.Challenger = fighterUnderTest

        ' first mon in the list is the chosen one
        Assert.AreSame(fighterUnderTest.MonsList.First, match.PromptChallengerNextMon(Default_Firemon))

        fighterUnderTest.MonsList.First.CurrentHealth = 0

        ' next mon is second
        Assert.AreSame(fighterUnderTest.MonsList.Skip(1).First, match.PromptChallengerNextMon(Default_Firemon))

        fighterUnderTest.MonsList.Skip(1).First.CurrentHealth = 0

        ' last mon is third
        Assert.AreSame(fighterUnderTest.MonsList.Last, match.PromptChallengerNextMon(Default_Firemon))

        fighterUnderTest.MonsList.Last.CurrentHealth = 0

        ' no mons left
        Assert.IsNull(match.PromptChallengerNextMon(Default_Firemon))
    End Sub

    <TestMethod> Public Sub SimulatedMatch_FightersDone_On0HP()

        Dim challenger As Fighter = Default_Fighter()
        Dim defender As Fighter = Default_Fighter()

        Dim challengerMon As FeneMon = Default_Firemon()
        Dim defenderMon As FeneMon = Default_Watermon()

        challengerMon.CurrentAttack = 20
        challengerMon.CurrentAttack = 20

        Dim logger As New TestLogger

        challenger.AddMon(challengerMon)
        defender.AddMon(defenderMon)

        Dim match As New ExhibitionMatchState
        match.StartMatch(challenger, defender, logger)

        Assert.AreEqual(0, defender.MonsList.First.CurrentHealth)
        Assert.AreNotEqual(0, challenger.MonsList.First.CurrentHealth)

        Dim desiredLogs As New List(Of String)
        desiredLogs.Add("Firemon did 30 damage to Watermon")
        desiredLogs.Add("Watermon fainted!")

        AssertHelpers.CollectionsAreEqual(desiredLogs, logger.Messages)
    End Sub

    <TestMethod> Public Sub SimulatedMatch_FightersCycle_On0HP()

        Dim challenger As Fighter = Default_Fighter()
        Dim defender As Fighter = Default_Fighter()

        Dim logger As New TestLogger

        challenger.AddMon(Default_Firemon)
        challenger.AddMon(Default_Firemon)
        challenger.MonsList.Last.Name = "Flamemon"
        challenger.MonsList(0).CurrentAttack = 20
        challenger.MonsList(1).CurrentAttack = 20

        defender.AddMon(Default_Watermon)
        defender.AddMon(Default_Watermon)
        defender.MonsList.Last.Name = "Liquidmon"
        defender.MonsList(0).CurrentAttack = 20
        defender.MonsList(1).CurrentAttack = 20

        Dim match As New ExhibitionMatchState
        match.StartMatch(challenger, defender, logger)

        Assert.AreEqual(0, defender.MonsList.First.CurrentHealth)
        Assert.AreNotEqual(0, challenger.MonsList.First.CurrentHealth)

        Dim desiredLogs As New List(Of String)
        desiredLogs.Add("Firemon did 30 damage to Watermon")
        desiredLogs.Add("Watermon fainted!")
        desiredLogs.Add("Firemon did 30 damage to Liquidmon")
        desiredLogs.Add("Liquidmon fainted!")

        AssertHelpers.CollectionsAreEqual(desiredLogs, logger.Messages)
    End Sub

    <TestMethod> Public Sub SimulatedMatch_FightersCycle_On0HP_Challenger()

        Dim challenger As Fighter = Default_Fighter()
        Dim defender As Fighter = Default_Fighter()

        Dim logger As New TestLogger

        challenger.AddMon(Default_Firemon)
        challenger.AddMon(Default_Firemon)
        challenger.MonsList.Last.Name = "Flamemon"
        challenger.MonsList(0).CurrentDefense = 20
        challenger.MonsList(1).CurrentDefense = 20

        defender.AddMon(Default_Watermon)
        defender.AddMon(Default_Watermon)
        defender.MonsList.Last.Name = "Liquidmon"
        defender.MonsList(0).CurrentDefense = 20
        defender.MonsList(1).CurrentDefense = 20

        Dim match As New ExhibitionMatchState
        match.StartMatch(challenger, defender, logger)

        Assert.AreEqual(0, defender.MonsList.First.CurrentHealth)
        Assert.AreEqual(0, defender.MonsList.Last.CurrentHealth)
        Assert.AreEqual(0, challenger.MonsList.First.CurrentHealth)
        Assert.AreNotEqual(0, challenger.MonsList.Last.CurrentHealth)

        Dim desiredLogs As New List(Of String)
        desiredLogs.Add("Firemon did 8 damage to Watermon")
        desiredLogs.Add("Watermon did 5 damage to Firemon")
        desiredLogs.Add("Firemon did 10 damage to Watermon")
        desiredLogs.Add("Watermon fainted!")
        desiredLogs.Add("Firemon did 8 damage to Liquidmon")
        desiredLogs.Add("Liquidmon did 5 damage to Firemon")
        desiredLogs.Add("Firemon fainted!")
        desiredLogs.Add("Flamemon did 8 damage to Liquidmon")
        desiredLogs.Add("Liquidmon fainted!")

        AssertHelpers.CollectionsAreEqual(desiredLogs, logger.Messages)
    End Sub

    '<TestMethod> Public Sub SimulatedMatch_WholeWorld_DoesNotBreak()

    '    Dim world As New World
    '    Dim logger As New TestLogger

    '    ' let each zone be the challenger
    '    For Each challengerWorldZone As WorldZone In world.WorldZones

    '        ' challenge every other zone
    '        For Each defenderWorldZone As WorldZone In world.WorldZones.Except({challengerWorldZone})

    '            ' let each fighter in the gymzones fight
    '            For Each challengerGymZone As GymZone In challengerWorldZone.Gym.GymZones

    '                ' challenge each defending fighter
    '                For Each defenderGymZone As GymZone In defenderWorldZone.Gym.GymZones

    '                    ' run the match
    '                    Dim simulatedMatch As MatchStateBase = New SimulatedMatchState
    '                    simulatedMatch.StartMatch(challengerGymZone.Fighter, defenderGymZone.Fighter, logger)

    '                    ' restore all the mons
    '                    For Each mon As FeneMon In challengerGymZone.Fighter.MonsList.Union(defenderGymZone.Fighter.MonsList)
    '                        mon.ResetEffectiveStats()
    '                        mon.RestoreToFullHealth()
    '                    Next
    '                Next
    '            Next
    '        Next
    '    Next

    '    Using writer As New System.IO.StreamWriter("WholeWorldBattleDump.txt")
    '        For Each log As String In logger.Messages
    '            writer.WriteLine(log)
    '        Next
    '    End Using

    'End Sub

End Class
