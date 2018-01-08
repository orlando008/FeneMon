Imports FeneMonLib

Public MustInherit Class ExhibitionMatchStateBase

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
            currentChallengerMon = PromptChallengerNextMon()
            currentDefenderMon = PromptDefenderNextMon()

            ' one (or both) fighters have no more mons, the match is over
            If currentChallengerMon Is Nothing OrElse currentDefenderMon Is Nothing Then
                Exit While
            End If
        End While
    End Sub

    Public MustOverride Function GetBattleState() As BattleStateBase

    Public MustOverride Function PromptChallengerNextMon() As FeneMon
    Public MustOverride Function PromptDefenderNextMon() As FeneMon

End Class
