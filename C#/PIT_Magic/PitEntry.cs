namespace PIT_Magic
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    [Serializable]
    public class PitEntry
    {
        private EntryAttribute _attribute = EntryAttribute.Write;
        private EntryBinaryType _binaryType = EntryBinaryType.AppProcessor;
        private int _blockCount = 0;
        private int _blockSize = 0;
        private EntryDeviceType _deviceType = EntryDeviceType.OneNand;
        private string _entryMemAddr = string.Empty;
        private int _fileOffset = 0;
        private int _fileSize = 0;
        private string _flashFilename = string.Empty;
        private string _fotaFilename = string.Empty;
        private int _identifier = 0;
        private int _index = 0;
        private string _partitionName = string.Empty;
        private EntryUpdateAttribute _updateAttribute = EntryUpdateAttribute.Fota;

        public static PitEntry Clone(PitEntry pEntry)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, pEntry);
                stream.Position = 0L;
                return (PitEntry) formatter.Deserialize(stream);
            }
        }

        public object Matches(PitEntry otherPitEntry) => 
            ((((((((((((this._binaryType == otherPitEntry._binaryType) & (this._deviceType == otherPitEntry._deviceType)) & (this._identifier == otherPitEntry._identifier)) & (this._attribute == otherPitEntry._attribute)) & (this._updateAttribute == otherPitEntry._updateAttribute)) & (this._blockSize == otherPitEntry._blockSize)) & (this._blockCount == otherPitEntry._blockCount)) & (this._fileOffset == otherPitEntry._fileOffset)) & (this._fileSize == otherPitEntry._fileSize)) & string.Equals(this._partitionName, otherPitEntry._partitionName)) & string.Equals(this._flashFilename, otherPitEntry._flashFilename)) & string.Equals(this._fotaFilename, otherPitEntry._fotaFilename));

        public void SetEntryMemAddr(string value)
        {
            this._entryMemAddr = value;
        }

        public EntryAttribute Attribute
        {
            get => 
                this._attribute;
            set
            {
                this._attribute = value;
            }
        }

        public EntryBinaryType BinaryType
        {
            get => 
                this._binaryType;
            set
            {
                this._binaryType = value;
            }
        }

        public int BlockCount
        {
            get => 
                this._blockCount;
            set
            {
                this._blockCount = value;
            }
        }

        public int BlockSize
        {
            get => 
                this._blockSize;
            set
            {
                this._blockSize = value;
            }
        }

        public EntryDeviceType DeviceType
        {
            get => 
                this._deviceType;
            set
            {
                this._deviceType = value;
            }
        }

        public string EntryMemAddr =>
            this._entryMemAddr;

        public int FileOffset
        {
            get => 
                this._fileOffset;
            set
            {
                this._fileOffset = value;
            }
        }

        public int FileSize
        {
            get => 
                this._fileSize;
            set
            {
                this._fileSize = value;
            }
        }

        public string FlashFileName
        {
            get => 
                this._flashFilename;
            set
            {
                if (value.Length < 0x20)
                {
                    this._flashFilename = value;
                }
                else
                {
                    this._flashFilename = value.Substring(0, 0x20);
                }
            }
        }

        public string FotaFileName
        {
            get => 
                this._fotaFilename;
            set
            {
                if (value.Length < 0x20)
                {
                    this._fotaFilename = value;
                }
                else
                {
                    this._fotaFilename = value.Substring(0, 0x20);
                }
            }
        }

        public int Identifier
        {
            get => 
                this._identifier;
            set
            {
                this._identifier = value;
            }
        }

        public int Index
        {
            get => 
                this._index;
            set
            {
                this._index = value;
            }
        }

        public string PartitionName
        {
            get => 
                this._partitionName;
            set
            {
                if (value.Length < 0x20)
                {
                    this._partitionName = value;
                }
                else
                {
                    this._partitionName = value.Substring(0, 0x20);
                }
            }
        }

        public EntryUpdateAttribute UpdateAttribute
        {
            get => 
                this._updateAttribute;
            set
            {
                this._updateAttribute = value;
            }
        }

        public enum EntryAttribute
        {
            STL = 2,
            Write = 1
        }

        public enum EntryBinaryType
        {
            AppProcessor,
            ComProcessor
        }

        public enum EntryData
        {
            DataSize = 0x84,
            FlashFileNameMaxLength = 0x20,
            FotaFileNameMaxLength = 0x20,
            PartitionNameMaxLength = 0x20
        }

        public enum EntryDeviceType
        {
            OneNand,
            FileOrFat,
            MMC,
            All
        }

        public enum EntryUpdateAttribute
        {
            Fota = 1,
            Secure = 2
        }
    }
}

