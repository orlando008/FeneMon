Imports FeneMonLib
Imports Newtonsoft.Json

<DebuggerDisplay("{Me.Name}")>
Public Class FeneMonMove

    Private _name As String
    Private _element As Enumerations.ElementEnum
    Private _power As Integer
    Private _moveKind As Enumerations.MoveKindEnum
    Private _accuracy As Decimal
    Private _priority As Integer
    Private _enduranceRequirement As Integer

    Public Sub New(name As String, element As Enumerations.ElementEnum, power As Integer, moveKind As Enumerations.MoveKindEnum, accuracy As Decimal, priority As Integer, enduranceRequirement As Integer)
        Me.Name = name
        Me.Element = element
        Me.Power = power
        Me.MoveKind = moveKind
        Me.Accuracy = accuracy
        Me.Priority = priority
        Me.EnduranceRequirement = enduranceRequirement
    End Sub

    <JsonProperty("Name")>
    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    <JsonProperty("Element")>
    Public Property Element As Enumerations.ElementEnum
        Get
            Return _element
        End Get
        Set(value As Enumerations.ElementEnum)
            _element = value
        End Set
    End Property

    <JsonProperty("Power")>
    Public Property Power As Integer
        Get
            Return _power
        End Get
        Set(value As Integer)
            _power = value
        End Set
    End Property

    <JsonProperty("DamageType")>
    Public Property MoveKind As Enumerations.MoveKindEnum
        Get
            Return _moveKind
        End Get
        Set(value As Enumerations.MoveKindEnum)
            _moveKind = value
        End Set
    End Property

    Public Property Accuracy As Decimal
        Get
            Return _accuracy
        End Get
        Set(value As Decimal)
            _accuracy = value
        End Set
    End Property

    Public Property Priority As Integer
        Get
            Return _priority
        End Get
        Set(value As Integer)
            _priority = value
        End Set
    End Property

    Public Property EnduranceRequirement As Integer
        Get
            Return _enduranceRequirement
        End Get
        Set(value As Integer)
            _enduranceRequirement = value
        End Set
    End Property
End Class
