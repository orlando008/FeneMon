Imports FeneMonLib

<TestClass> Public Class MatchTests

    <TestMethod> Public Sub SimulatedMatch_ChooseMons_InventoryOrder()

        Dim fighterUnderTest As Fighter = (New World).WorldZones.First.Gym.GymZones.First.Fighter

        fighterUnderTest.MonsList.Clear()
        fighterUnderTest.MonsList.Add(New FeneMon("Firemon", 10, 10, 10, 10, 10, 10, {}, Enumerations.ElementEnum.Fire))
        fighterUnderTest.MonsList.Add(New FeneMon("Bugmon", 10, 10, 10, 10, 10, 10, {}, Enumerations.ElementEnum.Bug))
        fighterUnderTest.MonsList.Add(New FeneMon("Icemon", 10, 10, 10, 10, 10, 10, {}, Enumerations.ElementEnum.Ice))

        Dim match As New SimulatedMatchState
        match.Challenger = fighterUnderTest

        ' first mon in the list is the chosen one
        Assert.AreSame(fighterUnderTest.MonsList.First, match.PromptChallengerNextMon)

        fighterUnderTest.MonsList.First.CurrentHealth = 0

        ' next mon is second
        Assert.AreSame(fighterUnderTest.MonsList.Skip(1).First, match.PromptChallengerNextMon)

        fighterUnderTest.MonsList.Skip(1).First.CurrentHealth = 0

        ' last mon is third
        Assert.AreSame(fighterUnderTest.MonsList.Last, match.PromptChallengerNextMon)

        fighterUnderTest.MonsList.Last.CurrentHealth = 0

        ' no mons left
        Assert.IsNull(match.PromptChallengerNextMon)
    End Sub

    <TestMethod> Public Sub SimulatedMatch_FightersCycle_On0HP()

        Dim challenger As Fighter = (New World).WorldZones.First.Gym.GymZones.First.Fighter
        Dim defender As Fighter = (New World).WorldZones.First.Gym.GymZones.First.Fighter

        Dim challengerMon As New FeneMon("Firemon", 10, 20, 10, 10, 10, 10, {New FeneMonMove("Physical Fire", Enumerations.ElementEnum.Fire, 10, Enumerations.DamageTypeEnum.Physical, 1), New FeneMonMove("Special Ice", Enumerations.ElementEnum.Ice, 10, Enumerations.DamageTypeEnum.Special, 2)}, Enumerations.ElementEnum.Fire)
        Dim defenderMon As New FeneMon("Watermon", 10, 20, 10, 10, 10, 10, {New FeneMonMove("Physical Fire", Enumerations.ElementEnum.Fire, 10, Enumerations.DamageTypeEnum.Physical, 1), New FeneMonMove("Special Ice", Enumerations.ElementEnum.Ice, 10, Enumerations.DamageTypeEnum.Special, 2)}, Enumerations.ElementEnum.Ice)

        Dim logger As New TestLogger

        challenger.MonsList.Clear()
        challenger.MonsList.Add(challengerMon)

        defender.MonsList.Clear()
        defender.MonsList.Add(defenderMon)

        Dim match As MatchStateBase = New SimulatedMatchState
        match.StartMatch(challenger, defender, logger)

        Assert.AreEqual(0, defender.MonsList.First.CurrentHealth)
        Assert.AreNotEqual(0, challenger.MonsList.First.CurrentHealth)

        Dim desiredLogs As New List(Of String)
        desiredLogs.Add("Firemon did 30 damage to Watermon")
        desiredLogs.Add("Watermon fainted!")

        AssertHelpers.CollectionsAreEqual(desiredLogs, logger.Messages)
    End Sub

End Class
