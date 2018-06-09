Imports System
Imports System.IO
Imports System.Text

Namespace PIT_Magic
    Public Class PitOutputStream
        ' Methods
        Public Sub New(ByVal byteStream As Stream)
            Me.outputStream = New BinaryWriter(byteStream, Encoding.UTF8)
        End Sub

        Public Sub Write(ByVal buffer As Byte(), ByVal offset As Integer, ByVal length As Integer)
            Me.outputStream.Write(buffer, offset, length)
        End Sub

        Public Sub WriteBytes(ByVal buffer As Byte())
            Me.outputStream.Write(buffer)
        End Sub

        Public Sub WriteInt(ByVal value As Integer)
            Dim buffer As Byte() = New Byte() { CByte((value And &HFF)), CByte(((value And &HFF00) >> 8)), CByte(((value And &HFF0000) >> &H10)), CByte(((value And &HFF000000) >> &H18)) }
            Me.outputStream.Write(buffer)
        End Sub

        Public Sub WriteRemainingBytes(ByVal hexString As String)
            Dim length As Integer = hexString.Length
            Dim buffer As Byte() = New Byte((((length / 2) - 1) + 1)  - 1) {}
            Dim num3 As Integer = (length - 1)
            Dim i As Integer = 0
            Do While (i <= num3)
                buffer((i / 2)) = Convert.ToByte(hexString.Substring(i, 2), &H10)
                i = (i + 2)
            Loop
            Me.outputStream.Write(buffer)
        End Sub

        Public Sub WriteShort(ByVal value As Short)
            Dim buffer As Byte() = New Byte() { CByte((value And &HFF)), CByte(((value And &HFF00) >> 8)) }
            Me.outputStream.Write(buffer)
        End Sub

        Public Sub WriteString(ByVal str As String, ByVal strMaxLength As Integer)
            Dim chArray As Char() = str.ToCharArray
            Dim buffer As Byte() = New Byte(((strMaxLength - 1) + 1)  - 1) {}
            Dim i As Integer
            For i = 0 To strMaxLength - 1
                If (i < chArray.Length) Then
                    buffer(i) = Convert.ToByte(chArray(i))
                Else
                    buffer(i) = Convert.ToByte(0)
                End If
            Next i
            Me.outputStream.Write(buffer, 0, buffer.Length)
        End Sub


        ' Fields
        Private outputStream As BinaryWriter
    End Class
End Namespace

