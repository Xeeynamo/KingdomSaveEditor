using System.IO;
using Xe.BinaryMapper;

namespace KHSave.LibFf7Remake.Chunks
{
    public class ChunkHeader
    {
        [Data] public byte Unknown00 { get; set; }
        [Data] public byte Unknown01 { get; set; }
        [Data] public byte Unknown02 { get; set; }
        [Data] public byte Unused03 { get; set; }
        [Data] public int NextChunkOffset { get; set; }
        [Data] public int Unused08 { get; set; }
        [Data] public int Unused0c { get; set; }
    }

    public class ChunkContent
    {
        [Data(Count = 0x10)] public string MagicCode { get; set; }
        [Data] public int Unknown10 { get; set; }
        [Data] public int ChunkLength { get; set; }
        public byte[] RawData { get; set; }
    }

    public class Chunk
    {
        public const int HeaderLength = 0x10;
        public const int ContentHeaderLength = 0x18;
        public const int TotalHeaderLength = HeaderLength + ContentHeaderLength;

        public ChunkHeader Header { get; }
        public ChunkContent Content { get; }

        public bool IsLastChunk => Header.NextChunkOffset == 0;
        public bool IsEmpty => Content.ChunkLength == 0;

        public Chunk(ChunkHeader header, ChunkContent content)
        {
            Header = header;
            Content = content;
        }

        public static Chunk Read(Stream stream)
        {
            var header = BinaryMapping.ReadObject<ChunkHeader>(stream);
            ChunkContent content;

            if (header.NextChunkOffset > 0)
            {
                content = BinaryMapping.ReadObject<ChunkContent>(stream);
                if (content.ChunkLength > ContentHeaderLength)
                    content.RawData = stream.ReadBytes(content.ChunkLength - ContentHeaderLength);
                else
                    content.RawData = new byte[0];
            }
            else
                content = null;

            if (header.NextChunkOffset > 0)
                stream.Position = header.NextChunkOffset;

            return new Chunk(header, content);
        }
        
        public void Write(Stream stream)
        {
            BinaryMapping.WriteObject(stream, Header);
            if (!IsLastChunk)
            {
                BinaryMapping.WriteObject(stream, Content);
                stream.Write(Content.RawData, 0, Content.RawData.Length);
                stream.Position = Header.NextChunkOffset;
            }
        }

        public override string ToString()
        {
            var h = $"H({Header.Unknown00:X02}, {Header.Unknown01:X02}, {Header.Unknown02:X02})";
            if (IsEmpty)
                return $"{h} EMPTY";
            if (!IsLastChunk)
                return $"{h} C({Content.MagicCode}, {Content.Unknown10:X}";
            else
                return $"{h} END";
        }
    }
}
