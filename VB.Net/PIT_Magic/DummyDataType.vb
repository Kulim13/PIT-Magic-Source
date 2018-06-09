Imports System
Imports System.Text

Namespace PIT_Magic
    Public Class DummyDataType
        ' Methods
        Public Shared Function GetDummyDataFromHexStr(ByVal hexStr As String) As Byte()
            Do While (hexStr.Length < 8)
                hexStr = (hexStr & "0")
            Loop
            If ((hexStr.Length Mod 2) <> 0) Then
                Return Nothing
            End If
            Dim buffer2 As Byte() = New Byte((((hexStr.Length / 2) - 1) + 1)  - 1) {}
            Dim num2 As Integer = (hexStr.Length - 1)
            Dim i As Integer = 0
            Do While (i <= num2)
                buffer2((i / 2)) = Convert.ToByte(hexStr.Substring(i, 2), &H10)
                i = (i + 2)
            Loop
            Return buffer2
        End Function

        Public Shared Function GetDummyDataFromStr(ByVal str As String) As Byte()
            Dim encoding As New UTF8Encoding
            Do While (str.Length < 4)
                str = (str & ChrW(0))
            Loop
            Return encoding.GetBytes(str)
        End Function

        Public Shared Function GetHexStrFromDummyData(ByVal bytes As Byte()) As String
            Dim builder As New StringBuilder((bytes.Length * 2))
            Dim num As Byte
            For Each num In bytes
                builder.AppendFormat("{0:X2}", num)
            Next
            Do While (builder.Length < 8)
                builder.Append("0")
            Loop
            Return builder.ToString
        End Function

        Public Shared Function GetStrFromDummyData(ByVal bytes As Byte()) As String
            Return Encoding.UTF8.GetString(bytes)
        End Function

    End Class
End Namespace

