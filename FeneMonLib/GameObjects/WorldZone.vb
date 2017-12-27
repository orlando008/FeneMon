Public Class WorldZone
    Private _gyms As List(Of Gym)
    Private _affinity As Enumerations.ElementEnum

    Public Sub New()
        'Generate random list of gyms 
    End Sub

    Public Sub New(gyms As List(Of Gym), affinity As Enumerations.ElementEnum)
        _gyms = gyms
        _affinity = affinity
    End Sub

#Region "Public Properties"

    Public Property Gyms As List(Of Gym)
        Get
            Return _gyms
        End Get
        Set(value As List(Of Gym))
            _gyms = value
        End Set
    End Property

    Public Property Affinity As Enumerations.ElementEnum
        Get
            Return _affinity
        End Get
        Set(value As Enumerations.ElementEnum)
            _affinity = value
        End Set
    End Property

#End Region

End Class
