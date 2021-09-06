using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ArchivingServices.Structure;

namespace ArchivingServices
{
    /// <summary>
    /// a simple library used to encapsulate and wrap System.IO.Compression.ZipFile
    /// functions in a more real world common scenario 
    /// </summary>
    public static class ArchivingServices
    {
        /// <summary>
        /// archive files in the list of paths inFilesList to the destination archivePath
        /// with using the file names in the archive from Path.GetFileName and add
        /// all of them in the root directory of the archive
        /// </summary>
        /// <param name="inFilesList">the files path list to archive</param>
        /// <param name="archivePath">the zip file path to create</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static bool ArchiveFilesInRootFolder(List<string> inFilesList, string archivePath) =>
            ArchiveFiles(inFilesList.ToDictionary(f => f, Path.GetFileName), archivePath);

        /// <summary>
        /// archive a single file to the destination archivePath
        /// with using the file name in the archive from Path.GetFileName and add
        /// all of them in the root directory of the archive
        /// </summary>
        /// <param name="inFile">the file path to archive</param>
        /// <param name="archivePath">the zip file path to create</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static bool ArchiveSingleFileInRootFolder(string inFile, string archivePath) =>
            ArchiveFiles(new Dictionary<string, string>
            {
                {inFile, Path.GetFileName(inFile)}
            }, archivePath);

        /// <summary>
        /// archive files in the list of objects ZipFileConfig which you
        /// can specify the file path on disk and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipConfigurationList">the list of objects ZipFileConfig to archive</param>
        /// <param name="archivePath">the zip file path to create</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static bool ArchiveFiles(List<ZipFileConfig> zipConfigurationList, string archivePath) =>
            ArchiveFiles(zipConfigurationList.ToDictionary(z => z.FilePathOnDisk,
                z => z.FilePathInArchive), archivePath);

        /// <summary>
        /// archive file in the ZipFileConfig which you
        /// can specify the file path on disk and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipFileConfiguration">the object ZipFileConfig to archive</param>
        /// <param name="archivePath">the zip file path to create</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static bool ArchiveSingleFile(ZipFileConfig zipFileConfiguration, string archivePath) =>
            ArchiveFiles(new Dictionary<string, string>
            {
                    { zipFileConfiguration.FilePathOnDisk, zipFileConfiguration.FilePathInArchive }
                }, archivePath);

        /// <summary>
        /// a simple function that wraps the functionality for
        /// zipping file dictionary into an archive with the key
        /// referring to the file path on disk
        /// and the value referring to the file path in
        /// the archive to be created
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
                        zip.CreateEntryFromFile(kvp.Key, kvp.Value);

                return File.Exists(archivePath);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// a simple function that wraps the functionality for zipping file
        /// using the file path on disk and the file path in archive to be created
        /// </summary>
        /// <param name="filePathOnDisk">the file path on disk</param>
        /// <param name="filePathInArchive">the file path in the archive</param>
        /// <param name="archivePath">the path to save the archived file to</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static bool ArchiveFile(string filePathOnDisk, string filePathInArchive, string archivePath)
        {
            try
            {
                using (var zip = ZipFile.Open(archivePath, ZipArchiveMode.Create))
                    zip.CreateEntryFromFile(filePathOnDisk, filePathInArchive);

                return File.Exists(archivePath);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// archive files in the list of ZipStreamConfig which you
        /// can specify the file stream and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipConfigurationList">the list of objects ZipFileConfig to archive</param>
        /// <param name="archivePath">the zip file path to create</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static bool ArchiveFiles(List<ZipStreamConfig> zipConfigurationList, string archivePath) =>
            ArchiveFilesStream(zipConfigurationList.ToDictionary(z => z.FilePathInArchive,
                z => z.FileStream), archivePath);

        /// <summary>
        /// archive files in the list of ZipStreamConfig which you
        /// can specify the file path on disk and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipConfiguration">the list of objects called ZipFileConfig to archive</param>
        /// <param name="archivePath">the zip file path to create</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static bool ArchiveFile(ZipStreamConfig zipConfiguration, string archivePath) =>
            ArchiveFilesStream(new Dictionary<string, Stream>
            {
                { zipConfiguration.FilePathInArchive, zipConfiguration.FileStream }
            }, archivePath);

        /// <summary>
        /// archive file from filePathInArchive which you can
        /// can specify the file stream and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="filePathInArchive">the file path in the archive to be created</param>
        /// <param name="fileStream">the file stream to archive</param>
        /// <param name="archivePath">the zip file path to create</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static bool ArchiveFile(string filePathInArchive, Stream fileStream, string archivePath) =>
            ArchiveFilesStream(new Dictionary<string, Stream>
            {
                { filePathInArchive, fileStream }
            }, archivePath);

        /// <summary>
        /// archive files in the list of ZipStreamConfig which you
        /// can specify the file stream and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipConfigurationList">the list of objects called ZipFileConfig to archive</param>
        /// <param name="archivePath">the zip file path to create</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static async Task<bool> ArchiveFilesAsync(List<ZipStreamConfig> zipConfigurationList, string archivePath) =>
            await ArchiveFilesStreamAsync(zipConfigurationList.ToDictionary(z => z.FilePathInArchive,
                z => z.FileStream), archivePath);

        /// <summary>
        /// archive file Async using the stream object ZipStreamConfig which you
        /// can specify the file stream and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipConfiguration">the list of objects called ZipFileConfig to archive</param>
        /// <param name="archivePath">the zip file path to create</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static async Task<bool> ArchiveFileAsync(ZipStreamConfig zipConfiguration, string archivePath) =>
            await ArchiveFilesStreamAsync(new Dictionary<string, Stream>
            {
                { zipConfiguration.FilePathInArchive, zipConfiguration.FileStream }
            }, archivePath);

        /// <summary>
        /// archive file Async using the stream provided with the file path in archive
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="filePathInArchive">the file path in the archive to be created</param>
        /// <param name="fileStream">the file stream to archive</param>
        /// <param name="archivePath">the zip file path to create</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static async Task<bool> ArchiveFileAsync(string filePathInArchive, Stream fileStream, string archivePath) =>
            await ArchiveFilesStreamAsync(new Dictionary<string, Stream>
            {
                { filePathInArchive, fileStream }
            }, archivePath);

        /// <summary>
        /// a simple function that wraps the functionality for zipping file list into an archive
        /// </summary>
        /// <param name="inFilesDictionary">a dictionary where the key is the file path on disk and the value is the file path in the archive</param>
        /// <param name="archivePath">the path to save the archived file to</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static bool ArchiveFilesStream(Dictionary<string, Stream> inFilesDictionary, string archivePath)
        {
            try
            {
                using (var zip = ZipFile.Open(archivePath, ZipArchiveMode.Create))
                    foreach (var kvp in inFilesDictionary)
                        using (var entryStream = zip.CreateEntry(kvp.Key).Open())
                            kvp.Value.CopyTo(entryStream);

                return File.Exists(archivePath);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// a simple function that wraps the functionality for zipping files list async into an archive
        /// </summary>
        /// <param name="inFilesDictionary">a dictionary where the key is the file path on disk and the value is the file path in the archive</param>
        /// <param name="archivePath">the path to save the archived file to</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static async Task<bool> ArchiveFilesStreamAsync(Dictionary<string, Stream> inFilesDictionary, string archivePath)
        {
            try
            {
                using (var zip = ZipFile.Open(archivePath, ZipArchiveMode.Create))
                    foreach (var kvp in inFilesDictionary)
                        using (var entryStream = zip.CreateEntry(kvp.Key).Open())
                            await kvp.Value.CopyToAsync(entryStream);

                return File.Exists(archivePath);
            }
            catch
            {
                return false;
            }
        }
    }
}
