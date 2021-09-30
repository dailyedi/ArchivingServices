using System;
using System.Collections.Generic;
using System.Text;

namespace ArchivingServices.Structure
{
    public class FileMetadata
    {
        public long CompressedLength { get; set; }
        public string FullName { get; set; }
        public long Length { get; set; }
        public DateTime LastWriteTime { get; set; }
    }
}
