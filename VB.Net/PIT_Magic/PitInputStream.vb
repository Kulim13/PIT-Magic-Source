Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.IO
Imports System.Text

Namespace PIT_Magic
    Public Class PitInputStream
        ' Methods
        Public Sub New(ByVal byteStream As Stream)
            Me.inputStream = New BinaryReader(byteStream, Encoding.UTF8)
        End Sub

        Public Function GetMemoryAddress() As String
            Return $"0x{Me.inputStream.BaseStream.Position.ToString("X")}"
        End Function

        Public Function Read(ByVal buffer As Byte(), ByVal offset As Integer, ByVal length As Integer) As Integer
            Return Me.inputStream.Read(buffer, offset, length)
        End Function

        Public Function ReadBytes(ByVal byteCount As Integer) As Byte()
            Return Me.inputStream.ReadBytes(byteCount)
        End Function

        Public Function ReadInt() As Integer
            Return Me.inputStream.ReadInt32
        End Function

        Public Function ReadRemainingBytes() As String
            Dim count As Integer = CInt((Me.inputStream.BaseStream.Length - Me.inputStream.BaseStream.Position))
            Dim buffer As Byte() = New Byte(0  - 1) {}
            buffer = Me.inputStream.ReadBytes(count)
            Dim builder As New StringBuilder((buffer.Length * 2))
            Dim num2 As Byte
            For Each num2 In buffer
                builder.AppendFormat("{0:X2}", num2)
            Next
            Return builder.ToString
        End Function

        Public Function ReadShort() As Short
            Return Me.inputStream.ReadInt16
        End Function

        Public Function ReadString(ByVal buffer As Byte(), ByVal strMaxLength As Integer) As String
            Dim chArray As Char() = New Char((strMaxLength + 1)  - 1) {}
            If (Me.inputStream.Read(buffer, 0, strMaxLength) <> strMaxLength) Then
                Return Conversions.ToString(-1)
            End If
            Dim index As Integer = 0
            Dim i As Integer
            For i = 0 To strMaxLength - 1
                If (buffer(i) = 0) Then
                    index = i
                    Exit For
                End If
                chArray(i) = Convert.ToChar(buffer(i))
            Next i
            chArray(index) = Convert.ToChar(0)
            Return New String(chArray, 0, index)
        End Function


        ' Fields
        Private inputStream As BinaryReader
    End Class
End Namespace

