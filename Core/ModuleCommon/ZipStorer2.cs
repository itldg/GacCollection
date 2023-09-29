using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Gac
{
    public class ZipStorer2 : IDisposable
    {
        public enum Compression : ushort
        {
            Store,
            Deflate = 8
        }

        public struct ZipFileEntry
        {
            public ZipStorer2.Compression Method;

            public string FilenameInZip;

            public uint FileSize;

            public uint CompressedSize;

            public uint HeaderOffset;

            public uint FileOffset;

            public uint HeaderSize;

            public uint Crc32;

            public DateTime ModifyTime;

            public string Comment;

            public override string ToString()
            {
                return this.FilenameInZip;
            }
        }

        private static Encoding FilenameEncoder;

        private static uint[] CrcTable;

        private List<ZipStorer2.ZipFileEntry> list_0 = new List<ZipStorer2.ZipFileEntry>();

        private string string_0;

        private FileStream fileStream_0;

        private string string_1 = "";

        private byte[] byte_0;

        private ushort ushort_0;

        private FileAccess fileAccess_0;

        static ZipStorer2()
        {
            ZipStorer2.old_acctor_mc();
        }

        private static void old_acctor_mc()
        {
            ZipStorer2.FilenameEncoder = Encoding.Default;
            ZipStorer2.CrcTable = null;
            ZipStorer2.CrcTable = new uint[256];
            for (int i = 0; i < ZipStorer2.CrcTable.Length; i++)
            {
                uint num = (uint)i;
                for (int j = 0; j < 8; j++)
                {
                    if ((num & 1u) != 0u)
                    {
                        num = (3988292384u ^ num >> 1);
                    }
                    else
                    {
                        num >>= 1;
                    }
                }
                ZipStorer2.CrcTable[i] = num;
            }
        }

        public static ZipStorer2 Create(string string_2, string string_3)
        {
            return new ZipStorer2
            {
                string_0 = string_2,
                string_1 = string_3,
                fileStream_0 = new FileStream(string_2, FileMode.Create, FileAccess.ReadWrite),
                fileAccess_0 = FileAccess.Write
            };
        }

        public static ZipStorer2 Open(string string_2, FileAccess fileAccess_1)
        {
            ZipStorer2 ZipStorer2 = new ZipStorer2();
            ZipStorer2.string_0 = string_2;
            ZipStorer2.fileStream_0 = new FileStream(string_2, FileMode.Open, (fileAccess_1 == FileAccess.Read) ? FileAccess.Read : FileAccess.ReadWrite);
            ZipStorer2.fileAccess_0 = fileAccess_1;
            if (!ZipStorer2.method_8())
            {
                throw new InvalidDataException();
            }
            return ZipStorer2;
        }

        public void AddFile(ZipStorer2.Compression compression_0, string string_2, string string_3, string string_4)
        {
            if (this.fileAccess_0 == FileAccess.Read)
            {
                throw new InvalidOperationException("Writing is not alowed");
            }
            FileStream fileStream = new FileStream(string_2, FileMode.Open, FileAccess.Read);
            this.AddStream(compression_0, string_3, fileStream, File.GetLastWriteTime(string_2), string_4);
            fileStream.Close();
        }

        public void AddStream(ZipStorer2.Compression compression_0, string string_2, Stream stream_0, DateTime dateTime_0, string string_3)
        {
            if (this.fileAccess_0 == FileAccess.Read)
            {
                throw new InvalidOperationException("Writing is not alowed");
            }
            if (this.list_0.Count != 0)
            {
                ZipStorer2.ZipFileEntry arg_39_0 = this.list_0[this.list_0.Count - 1];
            }
            ZipStorer2.ZipFileEntry item = default(ZipStorer2.ZipFileEntry);
            item.Method = compression_0;
            item.FilenameInZip = this.method_7(string_2);
            item.Comment = ((string_3 == null) ? "" : string_3);
            item.Crc32 = 0u;
            item.HeaderOffset = (uint)this.fileStream_0.Position;
            item.ModifyTime = dateTime_0;
            this.method_1(ref item);
            item.FileOffset = (uint)this.fileStream_0.Position;
            this.method_4(ref item, stream_0);
            stream_0.Close();
            this.method_6(ref item);
            this.list_0.Add(item);
        }

        public void Close()
        {
            if (this.fileAccess_0 != FileAccess.Read)
            {
                uint uint_ = (uint)this.fileStream_0.Position;
                uint num = 0u;
                if (this.byte_0 != null)
                {
                    this.fileStream_0.Write(this.byte_0, 0, this.byte_0.Length);
                }
                for (int i = 0; i < this.list_0.Count; i++)
                {
                    long position = this.fileStream_0.Position;
                    this.method_2(this.list_0[i]);
                    num += (uint)(this.fileStream_0.Position - position);
                }
                if (this.byte_0 != null)
                {
                    this.method_3(num + (uint)this.byte_0.Length, uint_);
                }
                else
                {
                    this.method_3(num, uint_);
                }
            }
            if (this.fileStream_0 != null)
            {
                this.fileStream_0.Flush();
                this.fileStream_0.Dispose();
                this.fileStream_0 = null;
            }
        }

        public List<ZipStorer2.ZipFileEntry> ReadCentralDir()
        {
            if (this.byte_0 == null)
            {
                throw new InvalidOperationException("Central directory currently does not exist");
            }
            List<ZipStorer2.ZipFileEntry> list = new List<ZipStorer2.ZipFileEntry>();
            ushort num2;
            ushort num3;
            ushort num4;
            for (int i = 0; i < this.byte_0.Length; i += (int)(46 + num2 + num3 + num4))
            {
                uint num = BitConverter.ToUInt32(this.byte_0, i);
                if (num != 33639248u)
                {
                    break;
                }
                ushort method = BitConverter.ToUInt16(this.byte_0, i + 10);
                uint compressedSize = BitConverter.ToUInt32(this.byte_0, i + 20);
                uint fileSize = BitConverter.ToUInt32(this.byte_0, i + 24);
                num2 = BitConverter.ToUInt16(this.byte_0, i + 28);
                num3 = BitConverter.ToUInt16(this.byte_0, i + 30);
                num4 = BitConverter.ToUInt16(this.byte_0, i + 32);
                uint num5 = BitConverter.ToUInt32(this.byte_0, i + 42);
                uint headerSize = (uint)(46 + num2 + num3 + num4);
                ZipStorer2.ZipFileEntry item = default(ZipStorer2.ZipFileEntry);
                item.Method = (ZipStorer2.Compression)method;
                item.FilenameInZip = ZipStorer2.FilenameEncoder.GetString(this.byte_0, i + 46, (int)num2);
                item.FileOffset = this.method_0(num5);
                item.FileSize = fileSize;
                item.CompressedSize = compressedSize;
                item.HeaderOffset = num5;
                item.HeaderSize = headerSize;
                if (num4 > 0)
                {
                    item.Comment = ZipStorer2.FilenameEncoder.GetString(this.byte_0, i + 46 + (int)num2 + (int)num3, (int)num4);
                }
                list.Add(item);
            }
            return list;
        }

        public bool ExtractStoredFile(ZipStorer2.ZipFileEntry zipFileEntry_0, string string_2)
        {
            byte[] array = new byte[4];
            this.fileStream_0.Seek((long)((ulong)zipFileEntry_0.HeaderOffset), SeekOrigin.Begin);
            this.fileStream_0.Read(array, 0, 4);
            if (BitConverter.ToUInt32(array, 0) != 67324752u)
            {
                return false;
            }
            Stream stream;
            if (zipFileEntry_0.Method == ZipStorer2.Compression.Store)
            {
                stream = this.fileStream_0;
            }
            else
            {
                if (zipFileEntry_0.Method != ZipStorer2.Compression.Deflate)
                {
                    return false;
                }
                stream = new DeflateStream(this.fileStream_0, CompressionMode.Decompress, true);
            }
            string directoryName = Path.GetDirectoryName(string_2);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            if (Directory.Exists(string_2))
            {
                return true;
            }
            FileStream fileStream = new FileStream(string_2, FileMode.Create, FileAccess.Write);
            byte[] array2 = new byte[16384];
            this.fileStream_0.Seek((long)((ulong)zipFileEntry_0.FileOffset), SeekOrigin.Begin);
            int num2;
            for (uint num = zipFileEntry_0.FileSize; num > 0u; num -= (uint)num2)
            {
                num2 = stream.Read(array2, 0, (int)Math.Min((long)((ulong)num), (long)array2.Length));
                fileStream.Write(array2, 0, num2);
            }
            fileStream.Close();
            if (zipFileEntry_0.Method == ZipStorer2.Compression.Deflate)
            {
                stream.Dispose();
            }
            return true;
        }

        public static bool RemoveEntries(ref ZipStorer2 ZipStorer2_0, List<ZipStorer2.ZipFileEntry> list_1)
        {
            List<ZipStorer2.ZipFileEntry> list = ZipStorer2_0.ReadCentralDir();
            string tempFileName = Path.GetTempFileName();
            string tempFileName2 = Path.GetTempFileName();
            try
            {
                ZipStorer2 ZipStorer2 = ZipStorer2.Create(tempFileName, string.Empty);
                foreach (ZipStorer2.ZipFileEntry current in list)
                {
                    if (!list_1.Contains(current) && ZipStorer2_0.ExtractStoredFile(current, tempFileName2))
                    {
                        ZipStorer2.AddFile(current.Method, tempFileName2, current.FilenameInZip, current.Comment);
                    }
                }
                ZipStorer2_0.Close();
                ZipStorer2.Close();
                File.Delete(ZipStorer2_0.string_0);
                File.Move(tempFileName, ZipStorer2_0.string_0);
                ZipStorer2_0 = ZipStorer2.Open(ZipStorer2_0.string_0, ZipStorer2_0.fileAccess_0);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (File.Exists(tempFileName))
                {
                    File.Delete(tempFileName);
                }
                if (File.Exists(tempFileName2))
                {
                    File.Delete(tempFileName2);
                }
            }
            return true;
        }

        private uint method_0(uint uint_0)
        {
            byte[] array = new byte[2];
            this.fileStream_0.Seek((long)((ulong)(uint_0 + 26u)), SeekOrigin.Begin);
            this.fileStream_0.Read(array, 0, 2);
            ushort num = BitConverter.ToUInt16(array, 0);
            this.fileStream_0.Read(array, 0, 2);
            ushort num2 = BitConverter.ToUInt16(array, 0);
            return (uint)((long)(30 + num + num2) + (long)((ulong)uint_0));
        }

        private void method_1(ref ZipStorer2.ZipFileEntry zipFileEntry_0)
        {
            long position = this.fileStream_0.Position;
            byte[] bytes = ZipStorer2.FilenameEncoder.GetBytes(zipFileEntry_0.FilenameInZip);
            this.fileStream_0.Write(new byte[]
            {
                80,
                75,
                3,
                4,
                20,
                0,
                0,
                0
            }, 0, 8);
            this.fileStream_0.Write(BitConverter.GetBytes((ushort)zipFileEntry_0.Method), 0, 2);
            this.fileStream_0.Write(BitConverter.GetBytes(this.method_5(zipFileEntry_0.ModifyTime)), 0, 4);
            Stream arg_83_0 = this.fileStream_0;
            byte[] buffer = new byte[12];
            arg_83_0.Write(buffer, 0, 12);
            this.fileStream_0.Write(BitConverter.GetBytes((ushort)bytes.Length), 0, 2);
            this.fileStream_0.Write(BitConverter.GetBytes(0), 0, 2);
            this.fileStream_0.Write(bytes, 0, bytes.Length);
            zipFileEntry_0.HeaderSize = (uint)(this.fileStream_0.Position - position);
        }

        private void method_2(ZipStorer2.ZipFileEntry zipFileEntry_0)
        {
            byte[] bytes = ZipStorer2.FilenameEncoder.GetBytes(zipFileEntry_0.FilenameInZip);
            byte[] bytes2 = ZipStorer2.FilenameEncoder.GetBytes(zipFileEntry_0.Comment);
            this.fileStream_0.Write(new byte[]
            {
                80,
                75,
                1,
                2,
                23,
                11,
                20,
                0,
                0,
                0
            }, 0, 10);
            this.fileStream_0.Write(BitConverter.GetBytes((ushort)zipFileEntry_0.Method), 0, 2);
            this.fileStream_0.Write(BitConverter.GetBytes(this.method_5(zipFileEntry_0.ModifyTime)), 0, 4);
            this.fileStream_0.Write(BitConverter.GetBytes(zipFileEntry_0.Crc32), 0, 4);
            this.fileStream_0.Write(BitConverter.GetBytes(zipFileEntry_0.CompressedSize), 0, 4);
            this.fileStream_0.Write(BitConverter.GetBytes(zipFileEntry_0.FileSize), 0, 4);
            this.fileStream_0.Write(BitConverter.GetBytes((ushort)bytes.Length), 0, 2);
            this.fileStream_0.Write(BitConverter.GetBytes(0), 0, 2);
            this.fileStream_0.Write(BitConverter.GetBytes((ushort)bytes2.Length), 0, 2);
            this.fileStream_0.Write(BitConverter.GetBytes(0), 0, 2);
            this.fileStream_0.Write(BitConverter.GetBytes(0), 0, 2);
            this.fileStream_0.Write(BitConverter.GetBytes(0), 0, 2);
            this.fileStream_0.Write(BitConverter.GetBytes(33024), 0, 2);
            this.fileStream_0.Write(BitConverter.GetBytes(zipFileEntry_0.HeaderOffset), 0, 4);
            this.fileStream_0.Write(bytes, 0, bytes.Length);
            this.fileStream_0.Write(bytes2, 0, bytes2.Length);
        }

        private void method_3(uint uint_0, uint uint_1)
        {
            byte[] bytes = ZipStorer2.FilenameEncoder.GetBytes(this.string_1);
            this.fileStream_0.Write(new byte[]
            {
                80,
                75,
                5,
                6,
                0,
                0,
                0,
                0
            }, 0, 8);
            this.fileStream_0.Write(BitConverter.GetBytes((int)((ushort)this.list_0.Count + this.ushort_0)), 0, 2);
            this.fileStream_0.Write(BitConverter.GetBytes((int)((ushort)this.list_0.Count + this.ushort_0)), 0, 2);
            this.fileStream_0.Write(BitConverter.GetBytes(uint_0), 0, 4);
            this.fileStream_0.Write(BitConverter.GetBytes(uint_1), 0, 4);
            this.fileStream_0.Write(BitConverter.GetBytes((ushort)bytes.Length), 0, 2);
            this.fileStream_0.Write(bytes, 0, bytes.Length);
        }

        private void method_4(ref ZipStorer2.ZipFileEntry zipFileEntry_0, Stream stream_0)
        {
            byte[] array = new byte[16384];
            uint num = 0u;
            long position = this.fileStream_0.Position;
            Stream stream;
            if (zipFileEntry_0.Method == ZipStorer2.Compression.Store)
            {
                stream = this.fileStream_0;
            }
            else
            {
                stream = new DeflateStream(this.fileStream_0, CompressionMode.Compress, true);
            }
            zipFileEntry_0.Crc32 = 4294967295u;
            int num2;
            do
            {
                num2 = stream_0.Read(array, 0, array.Length);
                num += (uint)num2;
                if (num2 > 0)
                {
                    stream.Write(array, 0, num2);
                    uint num3 = 0u;
                    while ((ulong)num3 < (ulong)((long)num2))
                    {
                        zipFileEntry_0.Crc32 = (ZipStorer2.CrcTable[(int)((UIntPtr)((zipFileEntry_0.Crc32 ^ (uint)array[(int)((UIntPtr)num3)]) & 255u))] ^ zipFileEntry_0.Crc32 >> 8);
                        num3 += 1u;
                    }
                }
            }
            while (num2 == array.Length);
            stream.Flush();
            if (zipFileEntry_0.Method == ZipStorer2.Compression.Deflate)
            {
                stream.Dispose();
            }
            zipFileEntry_0.Crc32 ^= 4294967295u;
            zipFileEntry_0.FileSize = num;
            zipFileEntry_0.CompressedSize = (uint)(this.fileStream_0.Position - position);
        }

        private uint method_5(DateTime dateTime_0)
        {
            return (uint)(dateTime_0.Second / 2 | dateTime_0.Minute << 5 | dateTime_0.Hour << 11 | dateTime_0.Day << 16 | dateTime_0.Month << 21 | dateTime_0.Year - 1980 << 25);
        }

        private void method_6(ref ZipStorer2.ZipFileEntry zipFileEntry_0)
        {
            long position = this.fileStream_0.Position;
            this.fileStream_0.Position = (long)((ulong)(zipFileEntry_0.HeaderOffset + 14u));
            this.fileStream_0.Write(BitConverter.GetBytes(zipFileEntry_0.Crc32), 0, 4);
            this.fileStream_0.Write(BitConverter.GetBytes(zipFileEntry_0.CompressedSize), 0, 4);
            this.fileStream_0.Write(BitConverter.GetBytes(zipFileEntry_0.FileSize), 0, 4);
            this.fileStream_0.Position = position;
        }

        private string method_7(string string_2)
        {
            string text = string_2.Replace('\\', '/');
            int num = text.IndexOf(':');
            if (num >= 0)
            {
                text = text.Remove(0, num + 1);
            }
            return text.Trim(new char[]
            {
                '/'
            });
        }

        private bool method_8()
        {
            if (this.fileStream_0.Length < 22L)
            {
                return false;
            }
            try
            {
                this.fileStream_0.Seek(-17L, SeekOrigin.End);
                BinaryReader binaryReader = new BinaryReader(this.fileStream_0);
                while (true)
                {
                    this.fileStream_0.Seek(-5L, SeekOrigin.Current);
                    uint num = binaryReader.ReadUInt32();
                    if (num == 101010256u)
                    {
                        break;
                    }
                    if (this.fileStream_0.Position <= 0L)
                    {
                        goto IL_11B;
                    }
                }
                this.fileStream_0.Seek(6L, SeekOrigin.Current);
                ushort num2 = binaryReader.ReadUInt16();
                int num3 = binaryReader.ReadInt32();
                uint num4 = binaryReader.ReadUInt32();
                ushort num5 = binaryReader.ReadUInt16();
                bool result;
                if (this.fileStream_0.Position + (long)((ulong)num5) != this.fileStream_0.Length)
                {
                    result = false;
                    return result;
                }
                this.ushort_0 = num2;
                this.byte_0 = new byte[num3];
                this.fileStream_0.Seek((long)((ulong)num4), SeekOrigin.Begin);
                this.fileStream_0.Read(this.byte_0, 0, num3);
                this.fileStream_0.Seek((long)((ulong)num4), SeekOrigin.Begin);
                result = true;
                return result;
                IL_11B:;
            }
            catch
            {
            }
            return false;
        }

        public void Dispose()
        {
            this.Close();
        }
    }
}
