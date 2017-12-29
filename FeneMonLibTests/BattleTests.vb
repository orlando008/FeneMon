Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports FeneMonLib

<TestClass()> Public Class BattleTests

    <TestMethod()> Public Sub SimulatedBattleState_ChoosesFirstMove()
        Dim challenger As New FeneMon("Glassmon", 10, 10, 10, 10, 10, 10, {New FeneMonMove("Attack", Enumerations.ElementEnum.Fire, 10, Enumerations.DamageTypeEnum.Physical, 1), New FeneMonMove("Attack2", Enumerations.ElementEnum.Fire, 10, Enumerations.DamageTypeEnum.Physical, 1)})
        Dim battle As BattleStateBase = New SimulatedBattleState()
        battle.Challenger = challenger
        Dim action As BattleAction = battle.PromptChallengerAction()
        Assert.AreEqual(challenger.Moves.First, action.Move)
    End Sub

    <TestMethod()> Public Sub SimulatedBattleState_IdenticalMonsChallengerWins()
        Dim challenger As New FeneMon("Firemon", 10, 10, 10, 10, 10, 10, {New FeneMonMove("Physical Fire", Enumerations.ElementEnum.Fire, 10, Enumerations.DamageTypeEnum.Physical, 1), New FeneMonMove("Special Ice", Enumerations.ElementEnum.Ice, 10, Enumerations.DamageTypeEnum.Special, 2)})
        Dim defender As New FeneMon("Watermon", 10, 10, 10, 10, 10, 10, {New FeneMonMove("Physical Fire", Enumerations.ElementEnum.Fire, 10, Enumerations.DamageTypeEnum.Physical, 1), New FeneMonMove("Special Ice", Enumerations.ElementEnum.Ice, 10, Enumerations.DamageTypeEnum.Special, 2)})

        Dim logger As New TestLogger

        Dim battle As BattleStateBase = New SimulatedBattleState
        battle.StartBattle(challenger, defender, logger)

        Assert.AreEqual(0, defender.CurrentHealth)
        Assert.AreNotEqual(0, challenger.CurrentHealth)

        Dim desiredLogs As New List(Of String)
        desiredLogs.Add("Firemon did 10 damage to Watermon")
        desiredLogs.Add("Watermon fainted!")

        AssertHelpers.CollectionsAreEqual(desiredLogs, logger.Messages)
    End Sub

    <TestMethod()> Public Sub SimulatedBattleState_SameMonSpeed_DifferentMoveSpeed_FasterMoveFirst()
        Dim challenger As New FeneMon("Firemon", 10, 10, 10, 10, 10, 10, {New FeneMonMove("Physical Fire", Enumerations.ElementEnum.Fire, 10, Enumerations.DamageTypeEnum.Physical, 1), New FeneMonMove("Special Ice", Enumerations.ElementEnum.Ice, 10, Enumerations.DamageTypeEnum.Special, 2)})
        Dim defender As New FeneMon("Watermon", 10, 10, 10, 10, 10, 10, {New FeneMonMove("Physical Fire", Enumerations.ElementEnum.Fire, 10, Enumerations.DamageTypeEnum.Physical, 2), New FeneMonMove("Special Ice", Enumerations.ElementEnum.Ice, 10, Enumerations.DamageTypeEnum.Special, 2)})

        Dim logger As New TestLogger

        Dim battle As BattleStateBase = New SimulatedBattleState
        battle.StartBattle(challenger, defender, logger)

        Assert.AreEqual(0, challenger.CurrentHealth)
        Assert.AreNotEqual(0, defender.CurrentHealth)

        Dim desiredLogs As New List(Of String)
        desiredLogs.Add("Watermon did 10 damage to Firemon")
        desiredLogs.Add("Firemon fainted!")

        AssertHelpers.CollectionsAreEqual(desiredLogs, logger.Messages)
    End Sub

    <TestMethod()> Public Sub SimulatedBattleState_DifferentMonSpeed_SameMoveSpeed_FasterMoveFirst()
        Dim challenger As New FeneMon("Firemon", 10, 10, 10, 10, 10, 10, {New FeneMonMove("Physical Fire", Enumerations.ElementEnum.Fire, 10, Enumerations.DamageTypeEnum.Physical, 1), New FeneMonMove("Special Ice", Enumerations.ElementEnum.Ice, 10, Enumerations.DamageTypeEnum.Special, 2)})
        Dim defender As New FeneMon("Watermon", 10, 10, 10, 11, 10, 10, {New FeneMonMove("Physical Fire", Enumerations.ElementEnum.Fire, 10, Enumerations.DamageTypeEnum.Physical, 1), New FeneMonMove("Special Ice", Enumerations.ElementEnum.Ice, 10, Enumerations.DamageTypeEnum.Special, 2)})

        Dim logger As New TestLogger

        Dim battle As BattleStateBase = New SimulatedBattleState
        battle.StartBattle(challenger, defender, logger)

        Assert.AreEqual(0, challenger.CurrentHealth)
        Assert.AreNotEqual(0, defender.CurrentHealth)

        Dim desiredLogs As New List(Of String)
        desiredLogs.Add("Watermon did 10 damage to Firemon")
        desiredLogs.Add("Firemon fainted!")

        AssertHelpers.CollectionsAreEqual(desiredLogs, logger.Messages)
    End Sub

End Class