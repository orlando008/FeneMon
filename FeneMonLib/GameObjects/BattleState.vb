Public Class BattleState

    Private _challenger As FeneMon
    Private _defender As FeneMon
    Private _logger As ILogger

    Public Property Challenger As FeneMon
        Get
            Return _challenger
        End Get
        Set(value As FeneMon)
            _challenger = value
        End Set
    End Property

    Public Property Defender As FeneMon
        Get
            Return _defender
        End Get
        Set(value As FeneMon)
            _defender = value
        End Set
    End Property

    Public Sub StartBattle(challenger As FeneMon, defender As FeneMon, logger As ILogger)
        _logger = logger

        Me.Challenger = challenger
        Me.Defender = defender

        ' run the battle to completion
        BattleLoop()

        ' report victor results?
    End Sub

    Private Sub BattleLoop()
        ' keep looping until we have a winner or until someone resigns
        Dim roundNumber As Integer = 0

        While True

            ' todo: prompts could probably simultaneous
            Dim challengerAction As BattleAction = PromptChallengerAction(roundNumber)
            Dim defenderAction As BattleAction = PromptDefenderAction(roundNumber)

            ' figure out who goes first
            Dim orderedActions As IList(Of BattleAction) = BattleMethods.ResolveActionOrder({challengerAction, defenderAction})

            For Each action As BattleAction In orderedActions
                BattleMethods.ResolveAttack(action.Move, action.User, action.Target, _logger)

                ' target fainted, battle is over
                ' todo: switch Mons?
                If action.Target.CurrentHealth = 0 Then
                    _logger.LogMessage($"{action.Target.Name} fainted!")
                    Exit While
                End If
            Next

            roundNumber += 1

        End While
    End Sub

    Public Function PromptChallengerAction(roundNumber As Integer) As BattleAction
        Return Challenger.Owner.PromptBattleAction(Challenger, Defender, roundNumber)
    End Function

    Public Function PromptDefenderAction(roundNumber As Integer) As BattleAction
        Return Defender.Owner.PromptBattleAction(Defender, Challenger, roundNumber)
    End Function

End Class
