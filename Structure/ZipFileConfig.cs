namespace ArchivingServices.Structure
{
    /// <summary>
    /// a simple class used to encapsulate the information for the
    /// zip library to make use of the file path on disk and in the
    /// archive to be created
    /// </summary>
    public class ZipFileConfig
    {
        public string FilePathOnDisk { get; }
        public string FilePathInArchive { get; }

        public ZipFileConfig(string filePathOnDisk, string filePathInArchive)
        {
            this.FilePathInArchive = filePathInArchive;
            this.FilePathOnDisk = filePathOnDisk;
        }
    }
}