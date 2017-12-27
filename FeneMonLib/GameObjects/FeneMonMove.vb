﻿Imports FeneMonLib

Public Class FeneMonMove

    Private _name As String
    Private _element As Enumerations.ElementEnum
    Private _power As Integer
    Private _damageType As Enumerations.DamageTypeEnum

    Public Sub New(name As String, element As Enumerations.ElementEnum, power As Integer, damageType As Enumerations.DamageTypeEnum)
        Me.Name = name
        Me.Element = element
        Me.Power = power
        Me.DamageType = damageType
    End Sub

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property Element As Enumerations.ElementEnum
        Get
            Return _element
        End Get
        Set(value As Enumerations.ElementEnum)
            _element = value
        End Set
    End Property

    Public Property Power As Integer
        Get
            Return _power
        End Get
        Set(value As Integer)
            _power = value
        End Set
    End Property

    Public Property DamageType As Enumerations.DamageTypeEnum
        Get
            Return _damageType
        End Get
        Set(value As Enumerations.DamageTypeEnum)
            _damageType = value
        End Set
    End Property
End Class
