Public MustInherit Class BattleStateBase

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
        While True

            ' todo: prompts could probably simultaneous
            Dim challengerAction As BattleAction = PromptChallengerAction()
            Dim defenderAction As BattleAction = PromptDefenderAction()

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

        End While
    End Sub

    Public MustOverride Function PromptChallengerAction() As BattleAction

    Public MustOverride Function PromptDefenderAction() As BattleAction

End Class
