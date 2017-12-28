Public Class BattleMethods

    Public Shared Sub ResolveAttack(attack As FeneMonMove, attacker As FeneMon, defender As FeneMon)

        ' calculate damage
        Dim damage As Integer = CalculateDamage(attack, attacker, defender)

        ' apply it to the defender
        defender.CurrentHealth -= damage

    End Sub

    Private Shared Function CalculateDamage(attack As FeneMonMove, attacker As FeneMon, defender As FeneMon) As Integer

        Dim attackValue As Integer = GetEffectiveAttackAttributeValue(attack.DamageType, attacker)
        Dim defenseValue As Integer = GetEffectiveAttackAttributeValue(attack.DamageType, defender)

        ' can probably factor in more modifiers and constants
        ' for now, just power types the attack/defense ratio
        Return attack.Power * attackValue / defenseValue

    End Function

    Private Shared Function GetEffectiveAttackAttributeValue(attackType As Enumerations.DamageTypeEnum, attacker As FeneMon) As Integer
        Select Case attackType
            Case Enumerations.DamageTypeEnum.Physical
                Return attacker.CurrentAttack
            Case Enumerations.DamageTypeEnum.Special
                Return attacker.CurrentSpecialAttack
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Private Shared Function GetEffectiveDefenseAttributeValue(attackType As Enumerations.DamageTypeEnum, defender As FeneMon) As Integer
        Select Case attackType
            Case Enumerations.DamageTypeEnum.Physical
                Return defender.CurrentDefense
            Case Enumerations.DamageTypeEnum.Special
                Return defender.CurrentSpecialDefense
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    ' returns IList to reduce dependancy on System.Linq
    Public Shared Function ResolveActionOrder(actions As IEnumerable(Of BattleAction)) As IList(Of BattleAction)
        Return actions.OrderBy(Function(a) CalculateActionSpeed(a)).ToList
    End Function

    Private Shared Function CalculateActionSpeed(action As BattleAction) As Integer
        Return action.User.CurrentSpeed * action.Move.SpeedFactor
    End Function

End Class
