Imports System.Runtime.CompilerServices

Class AssertHelpers

    Public Shared Sub CollectionsAreEqual(expected As ICollection, actual As ICollection)
        Assert.AreEqual(expected.Count, actual.Count)
        For i As Integer = 0 To expected.Count
            Assert.AreEqual(expected(i), actual(i))
        Next
    End Sub

End Class
