Imports FeneMonLib

Public Class ExhibitionMatchState

    Private _challenger As Fighter
    Private _defender As Fighter
    Private _logger As ILogger

    Public Property Challenger As Fighter
        Get
            Return _challenger
        End Get
        Set(value As Fighter)
            _challenger = value
        End Set
    End Property

    Public Property Defender As Fighter
        Get
            Return _defender
        End Get
        Set(value As Fighter)
            _defender = value
        End Set
    End Property

    Public Sub StartMatch(challenger As Fighter, defender As Fighter, logger As ILogger)
        _logger = logger

        Me.Challenger = challenger
        Me.Defender = defender

        ' run the match
        MatchLoop()

        ' report results?
    End Sub

    Private Sub MatchLoop()
        ' the first mon in the slot starts the match
        Dim currentChallengerMon As FeneMon = Me.Challenger.MonsList.First
        Dim currentDefenderMon As FeneMon = Me.Defender.MonsList.First

        ' keep looping until we have a winner or until someone resigns
        While True
            Dim battleState As BattleStateBase = GetBattleState()
            battleState.StartBattle(currentChallengerMon, currentDefenderMon, _logger)

            ' battle finished, prompt for new Mons
            ' prompt the fainted one first
            If currentChallengerMon.CurrentHealth = 0 Then
                ' challenger fainted, get a new challenger first
                currentChallengerMon = PromptChallengerNextMon(currentDefenderMon)
                currentDefenderMon = PromptDefenderNextMon(currentChallengerMon)
            Else
                ' defender fainted, get a new defender first
                currentDefenderMon = PromptDefenderNextMon(currentChallengerMon)
                currentChallengerMon = PromptChallengerNextMon(currentDefenderMon)
            End If

            ' one (or both) fighters have no more mons, the match is over
            If currentChallengerMon Is Nothing OrElse currentDefenderMon Is Nothing Then
                Exit While
            End If
        End While
    End Sub

    Public Function GetBattleState() As BattleStateBase
        Return New SimulatedBattleState
    End Function

    Public Function PromptChallengerNextMon(currentDefenderMon As FeneMon) As FeneMon
        Return Challenger.PromptNextMon(currentDefenderMon)
    End Function

    Public Function PromptDefenderNextMon(currentChallengerMon As FeneMon) As FeneMon
        Return Defender.PromptNextMon(currentChallengerMon)
    End Function

End Class
