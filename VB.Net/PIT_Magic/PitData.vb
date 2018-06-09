Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Namespace PIT_Magic
    <Serializable> _
    Public Class PitData
        ' Methods
        Public Sub AddEntry(ByVal entry As PitEntry)
            entry.Index = Me._entryCount
            Me._entries.Add(entry)
            Me._entryCount += 1
        End Sub

        Public Sub Clear()
            Me._entryCount = 0
            Me._dummyData1 = New Byte() { 0, 0, 0, 0 }
            Me._dummyData2 = New Byte() { 0, 0, 0, 0 }
            Me._dummyData3 = New Byte() { 0, 0, 0, 0 }
            Me._dummyData4 = New Byte() { 0, 0, 0, 0 }
            Me._dummyData5 = New Byte() { 0, 0, 0, 0 }
            Me._entries.Clear
        End Sub

        Public Shared Function Clone(ByVal pData As PitData) As PitData
            Using stream As MemoryStream = New MemoryStream
                Dim formatter As New BinaryFormatter
                formatter.Serialize(stream, pData)
                stream.Position = 0
                Return DirectCast(formatter.Deserialize(stream), PitData)
            End Using
        End Function

        Private Function CompareByteArray(ByVal byteArray1 As Byte(), ByVal byteArray2 As Byte()) As Boolean
            If (Not byteArray1 Is byteArray2) Then
                If ((byteArray1 Is Nothing) OrElse (byteArray2 Is Nothing)) Then
                    Return False
                End If
                If (byteArray1.Length <> byteArray2.Length) Then
                    Return False
                End If
                Dim num2 As Integer = (byteArray1.Length - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (byteArray1(i) <> byteArray2(i)) Then
                        Return False
                    End If
                    i += 1
                Loop
            End If
            Return True
        End Function

        Public Function FindEntry(ByVal partitionName As String) As PitEntry
            Dim num As Integer = 0
            Do While (num < Me._entries.Count)
                Dim entry2 As PitEntry = Me._entries.Item(num)
                If String.Equals(partitionName, entry2.PartitionName) Then
                    Return entry2
                End If
            Loop
            Return Nothing
        End Function

        Public Function GetEntry(ByVal index As Integer) As PitEntry
            Return Me._entries.Item(index)
        End Function

        Public Function Matches(ByVal otherPitData As PitData) As Boolean
            If Not ((((((Me._entryCount = otherPitData._entryCount) And Me.CompareByteArray(Me._dummyData1, otherPitData._dummyData1)) And Me.CompareByteArray(Me._dummyData2, otherPitData._dummyData2)) And Me.CompareByteArray(Me._dummyData3, otherPitData._dummyData3)) And Me.CompareByteArray(Me._dummyData4, otherPitData._dummyData4)) And Me.CompareByteArray(Me._dummyData5, otherPitData._dummyData5)) Then
                Return False
            End If
            Dim i As Integer
            For i = 0 To Me._entryCount - 1
                Dim entry As PitEntry = Me._entries.Item(i)
                Dim otherPitEntry As PitEntry = otherPitData._entries.Item(i)
                If Conversions.ToBoolean(Operators.NotObject(entry.Matches(otherPitEntry))) Then
                    Return False
                End If
            Next i
            Return True
        End Function

        Public Function ReadPITFile(ByVal inputStream As PitInputStream) As Boolean
            Dim buffer As Byte() = New Byte(4  - 1) {}
            Dim buffer2 As Byte() = New Byte(&H20  - 1) {}
            If (inputStream.ReadInt <> &H12349876) Then
                Return False
            End If
            Me._entries.Clear
            Me._entryCount = inputStream.ReadInt
            Me._entries.Capacity = Me._entryCount
            Me._dummyData1 = inputStream.ReadBytes(4)
            Me._dummyData2 = inputStream.ReadBytes(4)
            Me._dummyData3 = inputStream.ReadBytes(4)
            Me._dummyData4 = inputStream.ReadBytes(4)
            Me._dummyData5 = inputStream.ReadBytes(4)
            Dim i As Integer
            For i = 0 To Me._entryCount - 1
                Dim item As New PitEntry With { _
                    .Index = i _
                }
                item.SetEntryMemAddr(inputStream.GetMemoryAddress)
                Dim num2 As Integer = inputStream.ReadInt
                item.BinaryType = DirectCast(num2, EntryBinaryType)
                num2 = inputStream.ReadInt
                item.DeviceType = DirectCast(num2, EntryDeviceType)
                num2 = inputStream.ReadInt
                item.Identifier = num2
                num2 = inputStream.ReadInt
                item.Attribute = DirectCast(num2, EntryAttribute)
                num2 = inputStream.ReadInt
                item.UpdateAttribute = DirectCast(num2, EntryUpdateAttribute)
                num2 = inputStream.ReadInt
                item.BlockSize = num2
                num2 = inputStream.ReadInt
                item.BlockCount = num2
                num2 = inputStream.ReadInt
                item.FileOffset = num2
                num2 = inputStream.ReadInt
                item.FileSize = num2
                item.PartitionName = inputStream.ReadString(buffer2, &H20)
                item.FlashFileName = inputStream.ReadString(buffer2, &H20)
                item.FotaFileName = inputStream.ReadString(buffer2, &H20)
                Me._entries.Add(item)
            Next i
            Return True
        End Function

        Public Sub RemoveEntry(ByVal index As Integer)
            Dim enumerator As Enumerator(Of PitEntry)
            Me._entries.RemoveAt(index)
            Me._entryCount -= 1
            Dim num As Integer = 0
            Try 
                enumerator = Me._entries.GetEnumerator
                Do While enumerator.MoveNext
                    Dim current As PitEntry = enumerator.Current
                    current.Index = num
                    num += 1
                Loop
            Finally
                enumerator.Dispose
            End Try
        End Sub

        Public Sub SetEntry(ByVal index As Integer, ByVal newPitEntry As PitEntry)
            Me._entries.RemoveAt(index)
            Me._entries.Insert(index, newPitEntry)
        End Sub

        Public Sub WritePITFile(ByVal outputStream As PitOutputStream)
            outputStream.WriteInt(&H12349876)
            outputStream.WriteInt(Me._entryCount)
            outputStream.WriteBytes(Me._dummyData1)
            outputStream.WriteBytes(Me._dummyData2)
            outputStream.WriteBytes(Me._dummyData3)
            outputStream.WriteBytes(Me._dummyData4)
            outputStream.WriteBytes(Me._dummyData5)
            Dim i As Integer
            For i = 0 To Me._entryCount - 1
                Dim entry As PitEntry = Me._entries.Item(i)
                outputStream.WriteInt(CInt(entry.BinaryType))
                outputStream.WriteInt(CInt(entry.DeviceType))
                outputStream.WriteInt(entry.Identifier)
                outputStream.WriteInt(CInt(entry.Attribute))
                outputStream.WriteInt(CInt(entry.UpdateAttribute))
                outputStream.WriteInt(entry.BlockSize)
                outputStream.WriteInt(entry.BlockCount)
                outputStream.WriteInt(entry.FileOffset)
                outputStream.WriteInt(entry.FileSize)
                outputStream.WriteString(entry.PartitionName, &H20)
                outputStream.WriteString(entry.FlashFileName, &H20)
                outputStream.WriteString(entry.FotaFileName, &H20)
            Next i
        End Sub


        ' Properties
        Public Property DummyData1 As Byte()
            Get
                Return Me._dummyData1
            End Get
            Set(ByVal newValue As Byte())
                Me._dummyData1 = newValue
            End Set
        End Property

        Public Property DummyData2 As Byte()
            Get
                Return Me._dummyData2
            End Get
            Set(ByVal newValue As Byte())
                Me._dummyData2 = newValue
            End Set
        End Property

        Public Property DummyData3 As Byte()
            Get
                Return Me._dummyData3
            End Get
            Set(ByVal newValue As Byte())
                Me._dummyData3 = newValue
            End Set
        End Property

        Public Property DummyData4 As Byte()
            Get
                Return Me._dummyData4
            End Get
            Set(ByVal newValue As Byte())
                Me._dummyData4 = newValue
            End Set
        End Property

        Public Property DummyData5 As Byte()
            Get
                Return Me._dummyData5
            End Get
            Set(ByVal newValue As Byte())
                Me._dummyData5 = newValue
            End Set
        End Property

        Public ReadOnly Property Entries As PitEntry()
            Get
                Return Me._entries.ToArray
            End Get
        End Property

        Public ReadOnly Property EntryCount As Integer
            Get
                Return Me._entryCount
            End Get
        End Property


        ' Fields
        Private _dummyData1 As Byte() = New Byte() { 0, 0, 0, 0 }
        Private _dummyData2 As Byte() = New Byte() { 0, 0, 0, 0 }
        Private _dummyData3 As Byte() = New Byte() { 0, 0, 0, 0 }
        Private _dummyData4 As Byte() = New Byte() { 0, 0, 0, 0 }
        Private _dummyData5 As Byte() = New Byte() { 0, 0, 0, 0 }
        Private _entries As List(Of PitEntry) = New List(Of PitEntry)
        Private _entryCount As Integer
        Public Const DummyDataBlockLength As Integer = 4
        Public Const HeaderMagic As Integer = &H12349876
        Public Const HeaderSize As Integer = &H1C
        Public Const StrMaxLength As Integer = &H20
    End Class
End Namespace

