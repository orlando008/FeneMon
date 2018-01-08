Public Class BattleMethods

    Public Shared Sub ResolveAttack(attack As FeneMonMove, attacker As FeneMon, defender As FeneMon, logger As ILogger)

        ' calculate damage
        Dim damage As Integer = CalculateDamage(attack, attacker, defender)

        ' apply it to the defender
        defender.CurrentHealth -= damage

        ' log the damage
        logger.LogMessage($"{attacker.Name} did {damage} damage to {defender.Name}")

    End Sub

    Private Shared Function CalculateDamage(attack As FeneMonMove, attacker As FeneMon, defender As FeneMon) As Integer

        Dim attackValue As Integer = GetEffectiveAttackAttributeValue(attack.MoveKind, attacker)
        Dim defenseValue As Integer = GetEffectiveDefenseAttributeValue(attack.MoveKind, defender)
        Dim STAB As Double = GetSameTypeAttackBonus(attack.Element, attacker.Element)

        ' can probably factor in more modifiers and constants
        ' for now, just power types the attack/defense ratio
        Return (attack.Power * STAB) * attackValue / defenseValue

    End Function

    Private Shared Function GetEffectiveAttackAttributeValue(attackType As Enumerations.MoveKindEnum, attacker As FeneMon) As Integer
        Select Case attackType
            Case Enumerations.MoveKindEnum.Physical
                Return attacker.CurrentAttack
            Case Enumerations.MoveKindEnum.Special
                Return attacker.CurrentSpecialAttack
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Private Shared Function GetEffectiveDefenseAttributeValue(attackType As Enumerations.MoveKindEnum, defender As FeneMon) As Integer
        Select Case attackType
            Case Enumerations.MoveKindEnum.Physical
                Return defender.CurrentDefense
            Case Enumerations.MoveKindEnum.Special
                Return defender.CurrentSpecialDefense
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    ''' <summary>
    ''' Gets the STAB factor
    ''' </summary>
    ''' <param name="attackType"></param>
    ''' <param name="attackerType"></param>
    ''' <returns></returns>
    Private Shared Function GetSameTypeAttackBonus(attackType As Enumerations.ElementEnum, attackerType As Enumerations.ElementEnum) As Double
        If attackType = attackerType Then
            Return 1.5
        End If

        Return 1
    End Function

    ' returns IList to reduce dependancy on System.Linq
    Public Shared Function ResolveActionOrder(actions As IEnumerable(Of BattleAction)) As IList(Of BattleAction)
        Return actions.OrderBy(Function(a) a.Move.Priority).ThenByDescending(Function(a) a.User.CurrentSpeed).ToList
    End Function

End Class
