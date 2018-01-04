Imports FeneMonLib

Public Class SimulatedMatchState
    Inherits MatchStateBase

    Public Overrides Function GetBattleState() As BattleStateBase
        Return New SimulatedBattleState
    End Function

    Public Overrides Function PromptChallengerNextMon() As FeneMon
        Return SelectNextUnfaintedFeneMon(Challenger.MonsList)
    End Function

    Public Overrides Function PromptDefenderNextMon() As FeneMon
        Return SelectNextUnfaintedFeneMon(Defender.MonsList)
    End Function

    Private Function SelectNextUnfaintedFeneMon(mons As IList(Of FeneMon)) As FeneMon
        ' assume the next mon in line is good enough
        Return mons.FirstOrDefault(Function(m) m.CurrentHealth > 0)
    End Function
End Class
