using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;

namespace ArchivingServices
{
    /// <summary>
    /// 
    /// </summary>
    public static class ArchivingServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inFilesList"></param>
        /// <param name="archivePath"></param>
        /// <returns></returns>
        public static bool ArchiveFilesInRootFolder(List<string> inFilesList, string archivePath) =>
            ArchiveFiles(inFilesList.ToDictionary(f => f, Path.GetFileName), archivePath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipConfigurationList"></param>
        /// <param name="archivePath"></param>
        /// <returns></returns>
        public static bool ArchiveFiles(List<ZipFileConfig> zipConfigurationList, string archivePath) =>
            ArchiveFiles(zipConfigurationList.ToDictionary(z => z.FilePathOnDisk,
                z => z.FilePathInArchive), archivePath);

        /// <summary>
        /// a simple function that wraps the functionality for zipping file list into an archive
        /// </summary>
        /// <param name="inFilesDictionary">a dictionary where the key is the file path on disk and the value is the file path in the archive</param>
        /// <param name="archivePath">the path to save the archived file to</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static bool ArchiveFiles(Dictionary<string, string> inFilesDictionary, string archivePath)
        {
            try
            {
                using (var zip = ZipFile.Open(archivePath, ZipArchiveMode.Create))
                    foreach (var kvp in inFilesDictionary)
                    {
                        zip.CreateEntryFromFile(kvp.Key, kvp.Value);
                    }
                
                return File.Exists(archivePath);
            }
            catch
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 
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

    /// <summary>
    /// 
    /// </summary>
    public class ZipStreamConfig
    {
        private readonly string _filePathInArchive;
        public Stream FileStream { get; }
        public string FileName { get; }

        public ZipStreamConfig(Stream fileStream, string fileName, string filePathInArchive)
        {
            _filePathInArchive = filePathInArchive;
            FileStream = fileStream;
            FileName = fileName;
        }
    }
}
