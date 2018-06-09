Imports System
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Namespace PIT_Magic
    <Serializable> _
    Public Class PitEntry
        ' Methods
        Public Shared Function Clone(ByVal pEntry As PitEntry) As PitEntry
            Using stream As MemoryStream = New MemoryStream
                Dim formatter As New BinaryFormatter
                formatter.Serialize(stream, pEntry)
                stream.Position = 0
                Return DirectCast(formatter.Deserialize(stream), PitEntry)
            End Using
        End Function

        Public Function Matches(ByVal otherPitEntry As PitEntry) As Object
            Return ((((((((((((Me._binaryType = otherPitEntry._binaryType) And (Me._deviceType = otherPitEntry._deviceType)) And (Me._identifier = otherPitEntry._identifier)) And (Me._attribute = otherPitEntry._attribute)) And (Me._updateAttribute = otherPitEntry._updateAttribute)) And (Me._blockSize = otherPitEntry._blockSize)) And (Me._blockCount = otherPitEntry._blockCount)) And (Me._fileOffset = otherPitEntry._fileOffset)) And (Me._fileSize = otherPitEntry._fileSize)) And String.Equals(Me._partitionName, otherPitEntry._partitionName)) And String.Equals(Me._flashFilename, otherPitEntry._flashFilename)) And String.Equals(Me._fotaFilename, otherPitEntry._fotaFilename))
        End Function

        Public Sub SetEntryMemAddr(ByVal value As String)
            Me._entryMemAddr = value
        End Sub


        ' Properties
        Public Property Attribute As EntryAttribute
            Get
                Return Me._attribute
            End Get
            Set(ByVal newValue As EntryAttribute)
                Me._attribute = newValue
            End Set
        End Property

        Public Property BinaryType As EntryBinaryType
            Get
                Return Me._binaryType
            End Get
            Set(ByVal newValue As EntryBinaryType)
                Me._binaryType = newValue
            End Set
        End Property

        Public Property BlockCount As Integer
            Get
                Return Me._blockCount
            End Get
            Set(ByVal newValue As Integer)
                Me._blockCount = newValue
            End Set
        End Property

        Public Property BlockSize As Integer
            Get
                Return Me._blockSize
            End Get
            Set(ByVal newValue As Integer)
                Me._blockSize = newValue
            End Set
        End Property

        Public Property DeviceType As EntryDeviceType
            Get
                Return Me._deviceType
            End Get
            Set(ByVal newValue As EntryDeviceType)
                Me._deviceType = newValue
            End Set
        End Property

        Public ReadOnly Property EntryMemAddr As String
            Get
                Return Me._entryMemAddr
            End Get
        End Property

        Public Property FileOffset As Integer
            Get
                Return Me._fileOffset
            End Get
            Set(ByVal newValue As Integer)
                Me._fileOffset = newValue
            End Set
        End Property

        Public Property FileSize As Integer
            Get
                Return Me._fileSize
            End Get
            Set(ByVal newValue As Integer)
                Me._fileSize = newValue
            End Set
        End Property

        Public Property FlashFileName As String
            Get
                Return Me._flashFilename
            End Get
            Set(ByVal newFlashFileName As String)
                If (newFlashFileName.Length < &H20) Then
                    Me._flashFilename = newFlashFileName
                Else
                    Me._flashFilename = newFlashFileName.Substring(0, &H20)
                End If
            End Set
        End Property

        Public Property FotaFileName As String
            Get
                Return Me._fotaFilename
            End Get
            Set(ByVal newFotaFileName As String)
                If (newFotaFileName.Length < &H20) Then
                    Me._fotaFilename = newFotaFileName
                Else
                    Me._fotaFilename = newFotaFileName.Substring(0, &H20)
                End If
            End Set
        End Property

        Public Property Identifier As Integer
            Get
                Return Me._identifier
            End Get
            Set(ByVal newValue As Integer)
                Me._identifier = newValue
            End Set
        End Property

        Public Property Index As Integer
            Get
                Return Me._index
            End Get
            Set(ByVal newValue As Integer)
                Me._index = newValue
            End Set
        End Property

        Public Property PartitionName As String
            Get
                Return Me._partitionName
            End Get
            Set(ByVal newPartitionName As String)
                If (newPartitionName.Length < &H20) Then
                    Me._partitionName = newPartitionName
                Else
                    Me._partitionName = newPartitionName.Substring(0, &H20)
                End If
            End Set
        End Property

        Public Property UpdateAttribute As EntryUpdateAttribute
            Get
                Return Me._updateAttribute
            End Get
            Set(ByVal newValue As EntryUpdateAttribute)
                Me._updateAttribute = newValue
            End Set
        End Property


        ' Fields
        Private _attribute As EntryAttribute = EntryAttribute.Write
        Private _binaryType As EntryBinaryType = EntryBinaryType.AppProcessor
        Private _blockCount As Integer = 0
        Private _blockSize As Integer = 0
        Private _deviceType As EntryDeviceType = EntryDeviceType.OneNand
        Private _entryMemAddr As String = String.Empty
        Private _fileOffset As Integer = 0
        Private _fileSize As Integer = 0
        Private _flashFilename As String = String.Empty
        Private _fotaFilename As String = String.Empty
        Private _identifier As Integer = 0
        Private _index As Integer = 0
        Private _partitionName As String = String.Empty
        Private _updateAttribute As EntryUpdateAttribute = EntryUpdateAttribute.Fota

        ' Nested Types
        Public Enum EntryAttribute
            ' Fields
            STL = 2
            Write = 1
        End Enum

        Public Enum EntryBinaryType
            ' Fields
            AppProcessor = 0
            ComProcessor = 1
        End Enum

        Public Enum EntryData
            ' Fields
            DataSize = &H84
            FlashFileNameMaxLength = &H20
            FotaFileNameMaxLength = &H20
            PartitionNameMaxLength = &H20
        End Enum

        Public Enum EntryDeviceType
            ' Fields
            All = 3
            FileOrFat = 1
            MMC = 2
            OneNand = 0
        End Enum

        Public Enum EntryUpdateAttribute
            ' Fields
            Fota = 1
            Secure = 2
        End Enum
    End Class
End Namespace

