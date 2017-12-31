Imports System.IO
Imports Newtonsoft.Json

Public Class JsonParsingMethods

    ''' <summary>
    ''' Get a Random Name for a Fighter
    ''' </summary>
    ''' <returns>A Tuple of Strings. Item1 will contain the first name of the Fighter and Item2 will contain the last name.</returns>
    Public Shared Function GetRamdomFighterName() As Tuple(Of String, String)
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

End Class

Public Class JSON_Names
    <JsonProperty("Name")>
    Public Name As String
End Class
