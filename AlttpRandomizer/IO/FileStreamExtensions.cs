using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
