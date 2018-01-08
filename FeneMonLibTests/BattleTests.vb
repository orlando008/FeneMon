Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports FeneMonLib

<TestClass()> Public Class BattleTests

    <TestMethod()> Public Sub SimulatedBattleState_ChoosesFirstMove()
        Dim challenger As FeneMon = Default_Firemon()
        Dim battle As BattleStateBase = New SimulatedBattleState()
        battle.Challenger = challenger
        Dim action As BattleAction = battle.PromptChallengerAction()
        Assert.AreEqual(challenger.Moves.First, action.Move)
    End Sub

    <TestMethod()> Public Sub SimulatedBattleState_IdenticalMonsChallengerWins()
        Dim challenger As FeneMon = Default_Firemon()
        Dim defender As FeneMon = Default_Watermon()

        Dim logger As New TestLogger

        Dim battle As BattleStateBase = New SimulatedBattleState
        battle.StartBattle(challenger, defender, logger)

        Assert.AreEqual(0, defender.CurrentHealth)
        Assert.AreNotEqual(0, challenger.CurrentHealth)

        Dim desiredLogs As New List(Of String)
        desiredLogs.Add("Firemon did 15 damage to Watermon")
        desiredLogs.Add("Watermon fainted!")

        AssertHelpers.CollectionsAreEqual(desiredLogs, logger.Messages)
    End Sub

    <TestMethod()> Public Sub SimulatedBattleState_SameMonSpeed_DifferentMovePriority_FasterMoveFirst()
        Dim challenger As FeneMon = Default_Firemon()
        Dim defender As FeneMon = Default_Watermon()

        defender.Moves(0).Priority = 1

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

    <TestMethod()> Public Sub SimulatedBattleState_DifferentMonSpeed_SameMovePriority_FasterMoveFirst()
        Dim challenger As FeneMon = Default_Firemon()
        Dim defender As FeneMon = Default_Watermon()

        defender.CurrentSpeed = 20

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

    <TestMethod()> Public Sub AttackHigherThanDefense_MoreDamage()
        Dim challenger As FeneMon = Default_Firemon()
        Dim defender As FeneMon = Default_Watermon()

        challenger.CurrentAttack = 20
        defender.CurrentAttack = 20

        Dim logger As New TestLogger

        Dim battle As BattleStateBase = New SimulatedBattleState
        battle.StartBattle(challenger, defender, logger)

        Assert.AreEqual(0, defender.CurrentHealth)
        Assert.AreNotEqual(0, challenger.CurrentHealth)

        Dim desiredLogs As New List(Of String)
        desiredLogs.Add("Firemon did 30 damage to Watermon")
        desiredLogs.Add("Watermon fainted!")

        AssertHelpers.CollectionsAreEqual(desiredLogs, logger.Messages)
    End Sub

    <TestMethod()> Public Sub DefenseHigherThanAttack_LessDamage()
        Dim challenger As FeneMon = Default_Firemon()
        Dim defender As FeneMon = Default_Watermon()

        challenger.CurrentDefense = 20
        defender.CurrentDefense = 20

        Dim logger As New TestLogger

        Dim battle As BattleStateBase = New SimulatedBattleState
        battle.StartBattle(challenger, defender, logger)

        Assert.AreEqual(0, defender.CurrentHealth)
        Assert.AreNotEqual(0, challenger.CurrentHealth)

        Dim desiredLogs As New List(Of String)
        desiredLogs.Add("Firemon did 8 damage to Watermon")
        desiredLogs.Add("Watermon did 5 damage to Firemon")
        desiredLogs.Add("Firemon did 10 damage to Watermon")
        desiredLogs.Add("Watermon fainted!")

        AssertHelpers.CollectionsAreEqual(desiredLogs, logger.Messages)
    End Sub

    <TestMethod()> Public Sub SpecialMove_SpecialStatsDamage()
        Dim challenger As FeneMon = Default_Firemon()
        Dim defender As FeneMon = Default_Watermon()

        challenger.Moves(0).Power = 0
        challenger.CurrentSpecialDefense = 20
        defender.Moves(0).Power = 0
        defender.CurrentSpecialDefense = 20

        Dim logger As New TestLogger

        Dim battle As BattleStateBase = New SimulatedBattleState
        battle.StartBattle(challenger, defender, logger)

        Assert.AreEqual(0, defender.CurrentHealth)
        Assert.AreNotEqual(0, challenger.CurrentHealth)

        Dim desiredLogs As New List(Of String)
        desiredLogs.Add("Firemon did 0 damage to Watermon")
        desiredLogs.Add("Watermon did 0 damage to Firemon")
        desiredLogs.Add("Firemon did 5 damage to Watermon")
        desiredLogs.Add("Watermon did 8 damage to Firemon")
        desiredLogs.Add("Firemon did 0 damage to Watermon")
        desiredLogs.Add("Watermon did 0 damage to Firemon")
        desiredLogs.Add("Firemon did 5 damage to Watermon")
        desiredLogs.Add("Watermon fainted!")

        AssertHelpers.CollectionsAreEqual(desiredLogs, logger.Messages)
    End Sub

End Class