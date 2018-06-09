namespace PIT_Magic
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    [Serializable]
    public class PitData
    {
        private byte[] _dummyData1 = new byte[] { 0, 0, 0, 0 };
        private byte[] _dummyData2 = new byte[] { 0, 0, 0, 0 };
        private byte[] _dummyData3 = new byte[] { 0, 0, 0, 0 };
        private byte[] _dummyData4 = new byte[] { 0, 0, 0, 0 };
        private byte[] _dummyData5 = new byte[] { 0, 0, 0, 0 };
        private List<PitEntry> _entries = new List<PitEntry>();
        private int _entryCount;
        public const int DummyDataBlockLength = 4;
        public const int HeaderMagic = 0x12349876;
        public const int HeaderSize = 0x1c;
        public const int StrMaxLength = 0x20;

        public void AddEntry(PitEntry entry)
        {
            entry.Index = this._entryCount;
            this._entries.Add(entry);
            this._entryCount++;
        }

        public void Clear()
        {
            this._entryCount = 0;
            this._dummyData1 = new byte[] { 0, 0, 0, 0 };
            this._dummyData2 = new byte[] { 0, 0, 0, 0 };
            this._dummyData3 = new byte[] { 0, 0, 0, 0 };
            this._dummyData4 = new byte[] { 0, 0, 0, 0 };
            this._dummyData5 = new byte[] { 0, 0, 0, 0 };
            this._entries.Clear();
        }

        public static PitData Clone(PitData pData)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, pData);
                stream.Position = 0L;
                return (PitData) formatter.Deserialize(stream);
            }
        }

        private bool CompareByteArray(byte[] byteArray1, byte[] byteArray2)
        {
            if (byteArray1 != byteArray2)
            {
                if ((byteArray1 == null) || (byteArray2 == null))
                {
                    return false;
                }
                if (byteArray1.Length != byteArray2.Length)
                {
                    return false;
                }
                int num2 = byteArray1.Length - 1;
                for (int i = 0; i <= num2; i++)
                {
                    if (byteArray1[i] != byteArray2[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public PitEntry FindEntry(string partitionName)
        {
            int num = 0;
            while (num < this._entries.Count)
            {
                PitEntry entry2 = this._entries[num];
                if (string.Equals(partitionName, entry2.PartitionName))
                {
                    return entry2;
                }
            }
            return null;
        }

        public PitEntry GetEntry(int index) => 
            this._entries[index];

        public bool Matches(PitData otherPitData)
        {
            if (!((((((this._entryCount == otherPitData._entryCount) & this.CompareByteArray(this._dummyData1, otherPitData._dummyData1)) & this.CompareByteArray(this._dummyData2, otherPitData._dummyData2)) & this.CompareByteArray(this._dummyData3, otherPitData._dummyData3)) & this.CompareByteArray(this._dummyData4, otherPitData._dummyData4)) & this.CompareByteArray(this._dummyData5, otherPitData._dummyData5)))
            {
                return false;
            }
            for (int i = 0; i < this._entryCount; i++)
            {
                PitEntry entry = this._entries[i];
                PitEntry otherPitEntry = otherPitData._entries[i];
                if (Conversions.ToBoolean(Operators.NotObject(entry.Matches(otherPitEntry))))
                {
                    return false;
                }
            }
            return true;
        }

        public bool ReadPITFile(PitInputStream inputStream)
        {
            byte[] buffer = new byte[4];
            byte[] buffer2 = new byte[0x20];
            if (inputStream.ReadInt() != 0x12349876)
            {
                return false;
            }
            this._entries.Clear();
            this._entryCount = inputStream.ReadInt();
            this._entries.Capacity = this._entryCount;
            this._dummyData1 = inputStream.ReadBytes(4);
            this._dummyData2 = inputStream.ReadBytes(4);
            this._dummyData3 = inputStream.ReadBytes(4);
            this._dummyData4 = inputStream.ReadBytes(4);
            this._dummyData5 = inputStream.ReadBytes(4);
            for (int i = 0; i < this._entryCount; i++)
            {
                PitEntry item = new PitEntry {
                    Index = i
                };
                item.SetEntryMemAddr(inputStream.GetMemoryAddress());
                int num2 = inputStream.ReadInt();
                item.BinaryType = (PitEntry.EntryBinaryType) num2;
                num2 = inputStream.ReadInt();
                item.DeviceType = (PitEntry.EntryDeviceType) num2;
                num2 = inputStream.ReadInt();
                item.Identifier = num2;
                num2 = inputStream.ReadInt();
                item.Attribute = (PitEntry.EntryAttribute) num2;
                num2 = inputStream.ReadInt();
                item.UpdateAttribute = (PitEntry.EntryUpdateAttribute) num2;
                num2 = inputStream.ReadInt();
                item.BlockSize = num2;
                num2 = inputStream.ReadInt();
                item.BlockCount = num2;
                num2 = inputStream.ReadInt();
                item.FileOffset = num2;
                num2 = inputStream.ReadInt();
                item.FileSize = num2;
                item.PartitionName = inputStream.ReadString(buffer2, 0x20);
                item.FlashFileName = inputStream.ReadString(buffer2, 0x20);
                item.FotaFileName = inputStream.ReadString(buffer2, 0x20);
                this._entries.Add(item);
            }
            return true;
        }

        public void RemoveEntry(int index)
        {
            List<PitEntry>.Enumerator enumerator;
            this._entries.RemoveAt(index);
            this._entryCount--;
            int num = 0;
            try
            {
                enumerator = this._entries.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    PitEntry current = enumerator.Current;
                    current.Index = num;
                    num++;
                }
            }
            finally
            {
                enumerator.Dispose();
            }
        }

        public void SetEntry(int index, PitEntry newPitEntry)
        {
            this._entries.RemoveAt(index);
            this._entries.Insert(index, newPitEntry);
        }

        public void WritePITFile(PitOutputStream outputStream)
        {
            outputStream.WriteInt(0x12349876);
            outputStream.WriteInt(this._entryCount);
            outputStream.WriteBytes(this._dummyData1);
            outputStream.WriteBytes(this._dummyData2);
            outputStream.WriteBytes(this._dummyData3);
            outputStream.WriteBytes(this._dummyData4);
            outputStream.WriteBytes(this._dummyData5);
            for (int i = 0; i < this._entryCount; i++)
            {
                PitEntry entry = this._entries[i];
                outputStream.WriteInt((int) entry.BinaryType);
                outputStream.WriteInt((int) entry.DeviceType);
                outputStream.WriteInt(entry.Identifier);
                outputStream.WriteInt((int) entry.Attribute);
                outputStream.WriteInt((int) entry.UpdateAttribute);
                outputStream.WriteInt(entry.BlockSize);
                outputStream.WriteInt(entry.BlockCount);
                outputStream.WriteInt(entry.FileOffset);
                outputStream.WriteInt(entry.FileSize);
                outputStream.WriteString(entry.PartitionName, 0x20);
                outputStream.WriteString(entry.FlashFileName, 0x20);
                outputStream.WriteString(entry.FotaFileName, 0x20);
            }
        }

        public byte[] DummyData1
        {
            get => 
                this._dummyData1;
            set
            {
                this._dummyData1 = value;
            }
        }

        public byte[] DummyData2
        {
            get => 
                this._dummyData2;
            set
            {
                this._dummyData2 = value;
            }
        }

        public byte[] DummyData3
        {
            get => 
                this._dummyData3;
            set
            {
                this._dummyData3 = value;
            }
        }

        public byte[] DummyData4
        {
            get => 
                this._dummyData4;
            set
            {
                this._dummyData4 = value;
            }
        }

        public byte[] DummyData5
        {
            get => 
                this._dummyData5;
            set
            {
                this._dummyData5 = value;
            }
        }

        public PitEntry[] Entries =>
            this._entries.ToArray();

        public int EntryCount =>
            this._entryCount;
    }
}

