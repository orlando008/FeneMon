Imports System.IO
Imports Newtonsoft.Json

Public Class JsonParsingMethods

    ''' <summary>
    ''' Get a Random Name for a Fighter
    ''' </summary>
    ''' <returns>A Tuple of Strings. Item1 will contain the first name of the Fighter and Item2 will contain the last name.</returns>
    Public Shared Function GetRandomFighterName() As Tuple(Of String, String)
        Dim firstNames As List(Of JSON_Names)
        Dim lastNames As List(Of JSON_Names)

        Using reader As StreamReader = New StreamReader("..\..\..\..\FeneMonLib\JsonData\FighterFirstNames.json")
            Dim jsonFirstNames As String = reader.ReadToEnd
            firstNames = JsonConvert.DeserializeObject(Of List(Of JSON_Names))(jsonFirstNames)
        End Using

        Using readerLastNames As StreamReader = New StreamReader("..\..\..\..\FeneMonLib\JsonData\FighterLastNames.json")
            Dim jsonLastNames As String = readerLastNames.ReadToEnd
            lastNames = JsonConvert.DeserializeObject(Of List(Of JSON_Names))(jsonLastNames)
        End Using

        Dim firstNameIndex, lastNameIndex As Integer
        Dim r As Random = New Random()
        firstNameIndex = r.Next(0, firstNames.Count - 1)
        lastNameIndex = r.Next(0, lastNames.Count - 1)

        Return New Tuple(Of String, String)(firstNames(firstNameIndex).Name, lastNames(lastNameIndex).Name)
    End Function

    Public Shared Function GetRandomMon() As FeneMon
        Dim monList As List(Of FeneMon)

        Using reader As StreamReader = New StreamReader("..\..\..\..\FeneMonLib\JsonData\FeneMon.json")
            Dim jsonMons As String = reader.ReadToEnd
            monList = JsonConvert.DeserializeObject(Of List(Of FeneMon))(jsonMons)
        End Using

        Dim r As Random = New Random()

        Return monList(r.Next(0, monList.Count - 1))
    End Function

    Public Shared Function GetAllMons() As List(Of FeneMon)
        Dim monList As List(Of FeneMon)

        Using reader As StreamReader = New StreamReader("..\..\..\..\FeneMonLib\JsonData\FeneMon.json")
            Dim jsonMons As String = reader.ReadToEnd
            monList = JsonConvert.DeserializeObject(Of List(Of FeneMon))(jsonMons)
        End Using

        Return monList
    End Function

End Class


Public Class JSON_Names
    <JsonProperty("Name")>
    Public Name As String
End Class
