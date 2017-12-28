Imports FeneMonLib

Public Class SimulatedBattleState
    Inherits BattleStateBase

    Private _challengerCycle As Integer
    Private _defenderCycle As Integer

    Public Overrides Function PromptChallengerAction() As BattleAction
        _challengerCycle += 1
        If _challengerCycle >= Challenger.Moves.Count Then
            _challengerCycle = 0
        End If

        Return SelectRandomAction(Challenger, Defender, _challengerCycle)
    End Function

    Public Overrides Function PromptDefenderAction() As BattleAction
        _defenderCycle += 1
        If _defenderCycle >= Defender.Moves.Count Then
            _defenderCycle = 0
        End If

        Return SelectRandomAction(Defender, Challenger, _defenderCycle)
    End Function

    Private Function SelectRandomAction(user As FeneMon, target As FeneMon, cycle As Integer) As BattleAction
        Return New BattleAction(user, target, user.Moves(cycle))
    End Function
End Class
