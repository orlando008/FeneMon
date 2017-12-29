Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports FeneMonLib

<TestClass()> Public Class BattleTests

    <TestMethod()> Public Sub SimulatedBattleState_ChoosesFirstMove()
        Dim challenger As New FeneMon(10, 10, 10, 10, 10, 10, {New FeneMonMove("Attack", Enumerations.ElementEnum.Fire, 10, Enumerations.DamageTypeEnum.Physical, 1), New FeneMonMove("Attack2", Enumerations.ElementEnum.Fire, 10, Enumerations.DamageTypeEnum.Physical, 1)})
        Dim battle As BattleStateBase = New SimulatedBattleState()
        battle.Challenger = challenger
        Dim action As BattleAction = battle.PromptChallengerAction()
        Assert.AreEqual(challenger.Moves.First, action.Move)
    End Sub

    <TestMethod()> Public Sub SimulatedBattleState_IdenticalMonsChallengerWins()
        Dim challenger As New FeneMon(10, 10, 10, 10, 10, 10, {New FeneMonMove("Physical Fire", Enumerations.ElementEnum.Fire, 10, Enumerations.DamageTypeEnum.Physical, 1), New FeneMonMove("Special Ice", Enumerations.ElementEnum.Ice, 10, Enumerations.DamageTypeEnum.Special, 2)})
        Dim defender As New FeneMon(10, 10, 10, 10, 10, 10, {New FeneMonMove("Physical Fire", Enumerations.ElementEnum.Fire, 10, Enumerations.DamageTypeEnum.Physical, 1), New FeneMonMove("Special Ice", Enumerations.ElementEnum.Ice, 10, Enumerations.DamageTypeEnum.Special, 2)})

        Dim battle As BattleStateBase = New SimulatedBattleState
        battle.StartBattle(challenger, defender)

        Assert.AreEqual(0, defender.CurrentHealth)
        Assert.AreNotEqual(0, challenger.CurrentHealth)
    End Sub

End Class