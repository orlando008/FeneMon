Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports FeneMonLib

<TestClass()> Public Class BattleTests

    <TestMethod()> Public Sub SimulatedBattleState_ChoosesFirstMove()
        Dim challenger As New FeneMon(10, 10, 10, 10, 10, 10, {New FeneMonMove("Attack", Enumerations.ElementEnum.Fire, 10, Enumerations.DamageTypeEnum.Physical, 1)})
        Dim battle As BattleStateBase = New SimulatedBattleState()
        battle.Challenger = challenger
        Dim action As BattleAction = battle.PromptChallengerAction()
        Assert.AreEqual(challenger.Moves.First, action.Move)
    End Sub

End Class