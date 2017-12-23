
Imports System.ComponentModel
Imports System.Reflection
''' <summary>
''' Base class for all ViewModel classes in the application.
''' It provides support for property change notifications 
''' and has a DisplayName property.  This class is abstract.
''' </summary>
Public MustInherit Class ViewModelBase
    Implements INotifyPropertyChanged

#Region "Constructor"

    Protected Sub New()
    End Sub

#End Region

#Region "DisplayName"

    ''' <summary>
    ''' Returns the user-friendly name of this object.
    ''' Child classes can set this property to a new value,
    ''' or override it to determine the value on-demand.
    ''' </summary>
    Private privateDisplayName As String
    Public Overridable Property DisplayName() As String
        Get
            Return privateDisplayName
        End Get
        Protected Set(ByVal value As String)
            privateDisplayName = value
        End Set
    End Property

#End Region

#Region "Debugging Aides"

    ''' <summary>
    ''' Warns the developer if this object does not have
    ''' a public property with the specified name. This 
    ''' method does not exist in a Release build.
    ''' </summary>
    <Conditional("DEBUG"), DebuggerStepThrough()>
    Public Sub VerifyPropertyName(ByVal propertyName As String)
        ' Verify that the property name matches a real,  
        ' public, instance property on this object.
        If TypeDescriptor.GetProperties(Me)(propertyName) Is Nothing Then
            Dim msg As String = "Invalid property name: " & propertyName

            If Me.ThrowOnInvalidPropertyName Then
                Throw New Exception(msg)
            Else
                Debug.Fail(msg)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Returns whether an exception is thrown, or if a Debug.Fail() is used
    ''' when an invalid property name is passed to the VerifyPropertyName method.
    ''' The default value is false, but subclasses used by unit tests might 
    ''' override this property's getter to return true.
    ''' </summary>
    Private privateThrowOnInvalidPropertyName As Boolean
    Protected Overridable Property ThrowOnInvalidPropertyName() As Boolean
        Get
            Return privateThrowOnInvalidPropertyName
        End Get
        Set(ByVal value As Boolean)
            privateThrowOnInvalidPropertyName = value
        End Set
    End Property

#End Region

#Region "INotifyPropertyChanged Members"

    ''' <summary>
    ''' Raised when a property on this object has a new value.
    ''' </summary>
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    ''' <summary>
    ''' Raises this object's PropertyChanged event.
    ''' </summary>
    ''' <param name="propertyName">The property that has a new value.</param>
    Protected Overridable Sub OnPropertyChanged(ByVal propertyName As String)
        'Me.VerifyPropertyName(propertyName)

        Dim handler As PropertyChangedEventHandler = Me.PropertyChangedEvent
        If handler IsNot Nothing Then
            If String.IsNullOrWhiteSpace(propertyName) Then
                handler(Me, New PropertyChangedEventArgs(Nothing))
            Else
                If Me.MultiThreadedPropertyChangeNotification Then
                    'multithreaded for higher performance
                    System.Threading.Tasks.Parallel.ForEach(AllNotifiedProperties(propertyName), Sub(p)
                                                                                                     handler(Me, New PropertyChangedEventArgs(p))
                                                                                                 End Sub)
                Else
                    For Each p As String In AllNotifiedProperties(propertyName)
                        handler(Me, New PropertyChangedEventArgs(p))
                    Next
                End If
            End If
        End If

    End Sub

    ''' <summary>
    ''' If true, DependsUpon attributes will be executed on multiple threads for performance.  
    ''' If false, they will execute sequentially on one thread.  
    ''' Set to False if a screen freezes up on multi-threads, or you get cross-thread operation errors.
    ''' </summary>
    Public Overridable Property MultiThreadedPropertyChangeNotification As Boolean = True

#End Region

#Region "Depends Upon Attribute"

    <AttributeUsage(AttributeTargets.[Property], AllowMultiple:=True)>
    Protected Class DependsUponAttribute
        Inherits Attribute

        Private _dependencyName As String

        Public Sub New(ByVal propertyName As String)
            Me.DependencyName = propertyName
        End Sub

        Public Property DependencyName() As String
            Get
                Return _dependencyName
            End Get
            Private Set(ByVal value As String)
                _dependencyName = value
            End Set
        End Property

    End Class

    Private _dependentProperties As New System.Collections.Concurrent.ConcurrentDictionary(Of String, IEnumerable(Of String))

    Private Function DependentProperties(ByVal inputName As String) As IEnumerable(Of String)

        Dim value As IEnumerable(Of String) = Nothing

        If Not _dependentProperties.TryGetValue(inputName, value) Then 'Use TryGetValue instead of ContainsKey to save another lookup call behind the scenes.

            Dim nameList As New List(Of String)
            Dim defaultValue As IEnumerable(Of String) = nameList.AsEnumerable

            For Each pi As PropertyInfo In Me.GetType.GetProperties()
                For Each dua As DependsUponAttribute In pi.GetCustomAttributes(GetType(DependsUponAttribute), True)
                    If dua.DependencyName = inputName Then
                        nameList.Add(pi.Name)
                        Exit For
                    End If
                Next
            Next

            value = nameList.AsEnumerable

            _dependentProperties.AddOrUpdate(inputName, value, Function(key, oldValue) defaultValue)
        End If

        Return value

    End Function

    Private Function NotifiedProperties(ByVal inputs As IEnumerable(Of String)) As IEnumerable(Of String)

        Dim dependencies As IEnumerable(Of String) =
            From input In inputs
            From dependency In DependentProperties(input)
            Select dependency

        Return inputs.Union(dependencies).Distinct()

    End Function

    Private Function AllNotifiedProperties(ByVal inputName As String) As IEnumerable(Of String)

        Dim list As New List(Of String)
        list.Add(inputName)

        Dim results As IEnumerable(Of String) = list.AsEnumerable

        While NotifiedProperties(results).Count() > results.Count()
            results = NotifiedProperties(results)
        End While

        Return results

    End Function

#End Region

End Class
