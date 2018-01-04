Imports FeneMonLib

Public Class SimulatedBattleState
    Inherits BattleStateBase

    Private _challengerCycle As Integer
    Private _defenderCycle As Integer

    Public Overrides Function PromptChallengerAction() As BattleAction
        If _challengerCycle >= Challenger.Moves.Count Then
            _challengerCycle = 0
        End If

        Dim action As BattleAction = SelectRandomAction(Challenger, Defender, _challengerCycle)

        _challengerCycle += 1

        Return action
    End Function

    Public Overrides Function PromptDefenderAction() As BattleAction
        If _defenderCycle >= Defender.Moves.Count Then
            _defenderCycle = 0
        End If

        Dim action As BattleAction = SelectRandomAction(Defender, Challenger, _defenderCycle)

        _defenderCycle += 1

        Return action
    End Function

    Private Function SelectRandomAction(user As FeneMon, target As FeneMon, cycle As Integer) As BattleAction
        Return New BattleAction(user, target, user.Moves(cycle))
    End Function
End Class
