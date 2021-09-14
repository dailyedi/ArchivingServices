using System.IO;

namespace ArchivingServices.Structure
{
    /// <summary>
    /// a simple class used to encapsulate the information for the
    /// stream that contains the file to be archived and the file
    /// path inside the archive to be created
    /// </summary>
    public class ZipStreamConfig
    {
        public string FilePathInArchive { get; }
        public Stream FileStream { get; }

        public ZipStreamConfig(Stream fileStream, string filePathInArchive)
        {
            FilePathInArchive = filePathInArchive;
            FileStream = fileStream;
        }
    }
}