using System.IO;

namespace AlttpRandomizer.IO
{
    public static class FileStreamExtensions
    {
        public static void WriteBytes(this FileStream rom, int offset, params byte[] write)
        {
            rom.Seek(offset, SeekOrigin.Begin);
            rom.Write(write, 0, write.Length);
        }
    }
}
