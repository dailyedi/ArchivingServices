using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ArchivingServices.Structure;
using System.Text.RegularExpressions;

namespace ArchivingServices
{
    /// <summary>
    /// a simple library used to encapsulate and wrap System.IO.Compression.ZipFile
    /// functions in a more real world common scenario 
    /// </summary>
    public static class ArchivingServicess
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
        /// archive files in the list of paths inFilesList to the destination archivePath
        /// with using the file names in the archive from Path.GetFileName and add
        /// all of them in the root directory of the archive
        /// </summary>
        /// <param name="inFilesList">the files path list to archive</param>
        /// <returns>Memory Stream</returns>
        public static MemoryStream ArchiveFilesInRootFolder(List<string> inFilesList) =>
             ArchiveFiles(inFilesList.ToDictionary(f => f, Path.GetFileName));
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
        /// archive a single file to the destination archivePath
        /// with using the file name in the archive from Path.GetFileName and add
        /// all of them in the root directory of the archive
        /// </summary>
        /// <param name="inFile">the file path to archive</param>
        /// <returns>Memory Stream</returns>
        public static MemoryStream ArchiveSingleFileInRootFolder(string inFile) =>
            ArchiveFiles(new Dictionary<string, string> { { inFile, Path.GetFileName(inFile) } });
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
        /// archive files in the list of objects ZipFileConfig which you
        /// can specify the file path on disk and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipConfigurationList">the list of objects ZipFileConfig to archive</param>
        /// <param name="archivePath">the zip file path to create</param>
        /// <returns>Memory Stream</returns>
        public static MemoryStream ArchiveFiles(List<ZipFileConfig> zipConfigurationList) =>
            ArchiveFiles(zipConfigurationList.ToDictionary(z => z.FilePathOnDisk, z => z.FilePathInArchive));
        /// <summary>
        /// archive file in the ZipFileConfig which you
        /// can specify the file path on disk and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipFileConfiguration">the object ZipFileConfig to archive</param>
        /// <param name="archivePath">the zip file path to create</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static bool ArchiveSingleFile(ZipFileConfig zipFileConfiguration, string archivePath) =>
            ArchiveFiles(new Dictionary<string, string>{
                { zipFileConfiguration.FilePathOnDisk, zipFileConfiguration.FilePathInArchive } }
            , archivePath);
        /// <summary>
        /// archive file in the ZipFileConfig which you
        /// can specify the file path on disk and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipFileConfiguration">the object ZipFileConfig to archive</param>
        /// <returns>Memory Stream</returns>
        public static MemoryStream ArchiveSingleFile(ZipFileConfig zipFileConfiguration) =>
            ArchiveFiles(new Dictionary<string, string> { { zipFileConfiguration.FilePathOnDisk, zipFileConfiguration.FilePathInArchive } });
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
                File.WriteAllBytes(archivePath, ArchiveFiles(inFilesDictionary).ToArray());
                return File.Exists(archivePath);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// a simple async function that wraps the functionality for
        /// zipping file dictionary into an archive with the key
        /// referring to the file path on disk
        /// and the value referring to the file path in
        /// the archive to be created
        /// </summary>
        /// <param name="inFilesDictionary">a dictionary where the key is the file path on disk and the value is the file path in the archive</param>
        /// <param name="archivePath">the path to save the archived file to</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static async Task<bool> ArchiveFilesAsync(Dictionary<string, string> inFilesDictionary, string archivePath)
        {
            try
            {
                var result = await ArchiveFilesAsync(inFilesDictionary);
                File.WriteAllBytes(archivePath, result.ToArray());
                return File.Exists(archivePath);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// a simple function that wraps the functionality for
        /// zipping file dictionary into MemoryStream
        /// </summary>
        /// <param name="inFilesDictionary">a dictionary where the key is the file path on disk and the value is the file path in the archive</param>
        /// <returns>memoryStream or null</returns>
        public static  MemoryStream ArchiveFiles(Dictionary<string, string> inFilesDictionary)
        {
            var memoryStream = new MemoryStream();
                using (memoryStream)
                {
                    using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        foreach (var kvp in inFilesDictionary)
                        {
                            if (kvp.Value != null)
                                archive.CreateEntryFromFile(kvp.Key, kvp.Value);
                            else
                                archive.CreateEntry(kvp.Key + "\\");
                        }
                    }
                }
            
            return memoryStream;
        }
        /// <summary>
        /// a simple async function that wraps the functionality for
        /// zipping file dictionary into MemoryStream
        /// </summary>
        /// <param name="inFilesDictionary">a dictionary where the key is the file path on disk and the value is the file path in the archive</param>
        /// <returns>memoryStream or null</returns>
        public static async Task<MemoryStream> ArchiveFilesAsync(Dictionary<string, string> inFilesDictionary)
        {
            var memoryStream = new MemoryStream();
            await Task.Run(() => {
                using (memoryStream)
                {
                    using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        foreach (var kvp in inFilesDictionary)
                        {
                            if (kvp.Value != null)
                                archive.CreateEntryFromFile(kvp.Key, kvp.Value);
                            else
                                archive.CreateEntry(kvp.Key + "\\");
                        }
                    }
                }
            });

            return memoryStream;
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
                File.WriteAllBytes(archivePath, ArchiveFile(filePathOnDisk, filePathInArchive).ToArray());
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
        /// <returns>MemoryStream</returns>
        /// 
        public static MemoryStream ArchiveFile(string filePathOnDisk, string filePathInArchive)
        {
            var dic = new Dictionary<string, string>()
            {
                {filePathOnDisk,  filePathInArchive}
            };
            return ArchiveFiles(dic);
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
            ArchiveFilesStream(zipConfigurationList.ToDictionary(z => z.FilePathInArchive, z => z.FileStream), archivePath);
        /// <summary>
        /// archive files in the list of ZipStreamConfig which you
        /// can specify the file stream and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipConfigurationList">the list of objects ZipFileConfig to archive</param>
        /// <returns>Memory Stream</returns>
        public static MemoryStream ArchiveFiles(List<ZipStreamConfig> zipConfigurationList) =>
             ArchiveFilesStreamAsync(zipConfigurationList.ToDictionary(z => z.FilePathInArchive, z => z.FileStream));
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
        /// archive files in the list of ZipStreamConfig which you
        /// can specify the file path on disk and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipConfiguration">the list of objects called ZipFileConfig to archive</param>
        /// <returns>Memory Stream</returns>
        public static MemoryStream ArchiveFile(ZipStreamConfig zipConfiguration) =>
             ArchiveFilesStreamAsync(new Dictionary<string, Stream> {{ zipConfiguration.FilePathInArchive, zipConfiguration.FileStream }});
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
        /// archive file from filePathInArchive which you can
        /// can specify the file stream and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="filePathInArchive">the file path in the archive to be created</param>
        /// <param name="fileStream">the file stream to archive</param>
        /// <returns>Memory Stream</returns>
        public static MemoryStream ArchiveFile(string filePathInArchive, Stream fileStream) =>
             ArchiveFilesStreamAsync(new Dictionary<string, Stream> { { filePathInArchive, fileStream } });
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
        /// archive files in the list of ZipStreamConfig which you
        /// can specify the file stream and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipConfigurationList">the list of objects called ZipFileConfig to archive</param>
        /// <returns>Memory Stream</returns>
        public static async Task<MemoryStream> ArchiveFilesAsync(List<ZipStreamConfig> zipConfigurationList) =>
            ArchiveFilesStreamAsync(zipConfigurationList.ToDictionary(z => z.FilePathInArchive,
                z => z.FileStream));
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
        /// archive file Async using the stream object ZipStreamConfig which you
        /// can specify the file stream and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipConfiguration">the list of objects called ZipFileConfig to archive</param>
        /// <returns>Memory Stream</returns>
        public static async Task<MemoryStream> ArchiveFileAsync(ZipStreamConfig zipConfiguration) =>
             ArchiveFilesStreamAsync(new Dictionary<string, Stream>
            {{ zipConfiguration.FilePathInArchive, zipConfiguration.FileStream }});
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
        public static async Task<MemoryStream> ArchiveFileAsync(string filePathInArchive, Stream fileStream) =>
            ArchiveFilesStreamAsync(new Dictionary<string, Stream> {{ filePathInArchive, fileStream } });
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
                File.WriteAllBytes(archivePath, ArchiveFilesStreamAsync(inFilesDictionary).ToArray());
                return File.Exists(archivePath);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// a simple function that wraps the functionality for zipping file list into an Stream archive
        /// </summary>
        /// <param name="inFilesDictionary">a dictionary where the key is the file path on disk and the value is the file path in the archive</param>
        /// <returns>Memory Stream</returns>
        public static MemoryStream ArchiveFilesStream(Dictionary<string, Stream> inFilesDictionary) =>
            ArchiveFilesStreamAsync(inFilesDictionary);
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
                File.WriteAllBytes(archivePath, ArchiveFilesStreamAsync(inFilesDictionary).ToArray());
                return File.Exists(archivePath);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// a simple function that wraps the functionality for zipping files list into an Stream archive
        /// </summary>
        /// <param name="inFilesDictionary">a dictionary where the key is the file path on disk and the value is the file path in the archive</param>
        /// <returns>MemoryStream</returns>
        public static MemoryStream ArchiveFilesStreamAsync(Dictionary<string, Stream> inFilesDictionary)
        {

            var dic = new Dictionary<string, string>() { };
            foreach (var item in inFilesDictionary)
            {
                StreamReader reader = new StreamReader(item.Value);
                string text = reader.ReadToEnd();
                dic.Add(item.Key, text);
            }
            return ArchiveFiles(dic);
        }

        //TODO: archive directory (same location, same name, only parameter is directory path)

        /// <summary>
        /// a simple function that wraps the functionality for archiving a Directory 
        /// </summary>
        /// <param name="directoryPathOnDisk">a phisycal path for a Directory which you Want to Archive</param>
        /// <param name="allowEmptyNode">a flag determines that do you want empty Directories or not, Default is True </param>
        /// <returns>returns boolean for indicating that archived directory saved or not</returns>
        public static bool ArchiveDirectory(string directoryPathOnDisk, bool allowEmptyNode = true)
        {
            var archivedPath = directoryPathOnDisk + ".zip";
            var pathsResult = GetDirctoryPaths(directoryPathOnDisk, allowEmptyNode);
            return ArchiveFiles(pathsResult,archivedPath);
           
        }
        /// <summary>
        /// a simple  async function that wraps the functionality for archiving a Directory 
        /// </summary>
        /// <param name="directoryPathOnDisk">a phisycal path for a Directory which you Want to Archive</param>
        /// <param name="allowEmptyNode">a flag determines that do you want empty Directories or not, Default is True </param>
        /// <returns>returns boolean for indicating that archived directory saved or not</returns>
        public static async Task<bool> ArchiveDirectoryAsync(string directoryPathOnDisk, bool allowEmptyNode = true)
        {
            var archivedPath = directoryPathOnDisk + ".zip";
            var pathsResult = GetDirctoryPaths(directoryPathOnDisk, allowEmptyNode);
            return await ArchiveFilesAsync(pathsResult,archivedPath);
        }
        /// <summary>
        /// a simple function that wraps the functionality for archiving a Directory 
        /// </summary>
        /// <param name="directoryPathOnDisk">a phisycal path for a Directory which you Want to Archive</param>
        /// <param name="allowEmptyNode">a flag determines that do you want empty Directories or not, Default is True </param>
        /// <returns>return archived directory as a MemoryStream Formate</returns>
        public static MemoryStream ArchiveDirectoryStream(string directoryPathOnDisk, bool allowEmptyNode = true)
        {
            var pathsResult = GetDirctoryPaths(directoryPathOnDisk, allowEmptyNode);
            return ArchiveFiles(pathsResult);
        }
        /// <summary>
        /// a simple async function that wraps the functionality for archiving a Directory 
        /// </summary>
        /// <param name="directoryPathOnDisk">a phisycal path for a Directory which you Want to Archive</param>
        /// <param name="allowEmptyNode">a flag determines that do you want empty Directories or not, Default is True </param>
        /// <returns>return archived directory as a MemoryStream Formate</returns>
        public static async Task <MemoryStream> ArchiveDirectoryStreamAsync(string directoryPathOnDisk, bool allowEmptyNode = true)
        {
            var pathsResult = GetDirctoryPaths(directoryPathOnDisk, allowEmptyNode);
            return await ArchiveFilesAsync(pathsResult);
        }
        /// <summary>
        /// a simple function that wraps the functionality for Getting Paths For All Files And Directories
        /// </summary>
        /// <param name="directoryPathOnDisk">a phisycal path for a Directory which you Want to Archive</param>
        /// <param name="allowEmptyNode">a flag determines that do you want Empty Directories or not </param>
        /// <returns> return a Dictionary that Contains Key:phisycal path of files,Value:relative path for Archived Directory </returns>
        private static Dictionary<string, string> GetDirctoryPaths(string directoryPathOnDisk, bool allowEmptyNode)
        {
            Dictionary<string, string> Paths = new Dictionary<string, string>();
            var files = Directory.GetFiles(directoryPathOnDisk, "*.*", SearchOption.AllDirectories);
            var dirctories = Directory.GetDirectories(directoryPathOnDisk, "*.*", SearchOption.AllDirectories);
            files?.ToList().ForEach(rf => Paths.Add(rf, rf.Substring(directoryPathOnDisk.Length + 1)));
            if (allowEmptyNode)
            {
                // Getting Paths Of Empty Directories
                dirctories?.Where(d => !files.Any(f => f.Contains(d)))
                          ?.ToList()
                          ?.ForEach(r => Paths.Add(r.Substring(directoryPathOnDisk.Length + 1), null));
            }
            return Paths;
        }


        /// <summary>
        /// a simple function that wraps the functionality for archiving a Directory Ignoring Sub Directpries
        /// </summary>
        /// <param name="directoryPathOnDisk">a phisycal path for a Directory which you Want to Archive</param>
        /// <returns>returns boolean for indicating that archived directory saved or not which Contains All files in Same Directory Ignoring Sub Directpries </returns>
        public static bool ArchiveDirectoryFlates(string directoryPathOnDisk)
        {
            var archivedPath = directoryPathOnDisk + ".zip";
            var pathsResult = GetDirctoryPathsFlates(directoryPathOnDisk);
            return ArchiveFiles(pathsResult,archivedPath);
           
        }
        /// <summary>
        /// a simple async function that wraps the functionality for archiving a Directory Ignoring Sub Directpries
        /// </summary>
        /// <param name="directoryPathOnDisk">a phisycal path for a Directory which you Want to Archive</param>
        /// <returns>returns boolean for indicating that archived directory saved or not which Contains All files in Same Directory Ignoring Sub Directpries </returns>
        public static async Task<bool> ArchiveDirectoryFlatesAsync(string directoryPathOnDisk)
        {
            var archivedPath = directoryPathOnDisk + ".zip";
            var pathsResult = GetDirctoryPathsFlates(directoryPathOnDisk);
            return await ArchiveFilesAsync(pathsResult,archivedPath);
        }
        /// <summary>
        /// a simple function that wraps the functionality for archiving a Directory Ignoring Sub Directpries
        /// </summary>
        /// <param name="directoryPathOnDisk">a phisycal path for a Directory which you Want to Archive</param>
        /// <returns> return archived directory As a MemoryStream which Contains All files in Same Directory Ignoring Sub Directpries </returns>
        public static MemoryStream ArchiveDirectoryFlatesStream(string directoryPathOnDisk)
        {
            var pathsResult = GetDirctoryPathsFlates(directoryPathOnDisk);
            return ArchiveFiles(pathsResult);
        }
        /// <summary>
        /// a simple async function that wraps the functionality for archiving a Directory Ignoring Sub Directpries
        /// </summary>
        /// <param name="directoryPathOnDisk">a phisycal path for a Directory which you Want to Archive</param>
        /// <returns> return archived directory As a MemoryStream which Contains All files in Same Directory Ignoring Sub Directpries </returns>
        public static async Task<MemoryStream> ArchiveDirectoryFlatesStreamAsync(string directoryPathOnDisk)
        {
            var pathsResult = GetDirctoryPathsFlates(directoryPathOnDisk);
            return await ArchiveFilesAsync(pathsResult);
        }
        /// <summary>
        /// a simple function that wraps the functionality for Getting Paths For All Files  
        /// </summary>
        /// <param name="directoryPathOnDisk">a phisycal path for a Directory which you Want to Archive</param>
        /// <returns> return a Dictionary that Contains Key:phisycal path of files,Value:relative path for Archived Directory </returns>
        private static Dictionary<string, string> GetDirctoryPathsFlates(string directoryPathOnDisk)
        {
            Dictionary<string, string> Paths = new Dictionary<string, string>();
            var files = Directory.GetFiles(directoryPathOnDisk, "*.*", SearchOption.AllDirectories);
            files?.ToList().ForEach(f => Paths.Add(f, Path.GetFileName(f)));
            return Paths;
        }

        //TODO: archive directory with more options (include/exclude files patterns, archive all in root directory, archive to, etc..)

        /// <summary>
        /// a simple function that wraps the functionality for archiving files in a Directory for Specific Pattern  
        /// </summary>
        /// <param name="directoryPathOnDisk">a phisycal path for a Directory which you Want to Archive</param>
        /// <param name="searchWay">an Enum For Searshing Options Either RegEx or WildCard </param>
        /// <param name="pattern"> contains the pattern you want to filter With it</param>
        /// <param name="allowedFlates">a flag determines what do you want Either subfolders or Flats directory </param>
        /// <returns>returns boolean for indicating that archived directory saved or not</returns>
        public static bool ArchiveDirectoryWithPattern(string directoryPathOnDisk, SearchPattern searchWay, string pattern,  bool allowedFlates = default)
        {
            var archivePath = directoryPathOnDisk + ".zip";
            var pathsResult = GetPathsFilesInDirectorywithPattern(directoryPathOnDisk, searchWay, pattern,  allowedFlates);
            return ArchiveFiles(pathsResult,archivePath);
        }
        /// <summary>
        /// a simple async function that wraps the functionality for archiving files in a Directory for Specific Pattern  
        /// </summary>
        /// <param name="directoryPathOnDisk">a phisycal path for a Directory which you Want to Archive</param>
        /// <param name="searchWay">an Enum For Searshing Options Either RegEx or WildCard </param>
        /// <param name="pattern"> contains the pattern you want to filter With it</param>
        /// <param name="allowedFlates">a flag determines what do you want Either subfolders or Flats directory </param>
        /// <returns>returns boolean for indicating that archived directory saved or not</returns>
        public static async Task<bool> ArchiveDirectoryWithPatternAsync(string directoryPathOnDisk, SearchPattern searchWay, string pattern, bool allowedFlates = default)
        {
            var archivePath = directoryPathOnDisk + ".zip";
            var pathsResult = GetPathsFilesInDirectorywithPattern(directoryPathOnDisk, searchWay, pattern, allowedFlates);
            return await ArchiveFilesAsync(pathsResult,archivePath);
            
        }
        /// <summary>
        /// a simple function that wraps the functionality for archiving files in a Directory for Specific Pattern  
        /// </summary>
        /// <param name="directoryPathOnDisk">a phisycal path for a Directory which you Want to Archive</param>
        /// <param name="searchWay">an Enum For Searshing Options Either RegEx or WildCard </param>
        /// <param name="pattern"> contains the pattern you want to filter With it</param>
        /// <param name="allowedFlates">a flag determines what do you want Either subfolders or Flats directory </param>
        /// <returns>return archived directory as a MemoryStream</returns>
        public static MemoryStream ArchiveDirectoryWithPatternStream(string directoryPathOnDisk, SearchPattern searchWay, string pattern, bool allowedFlates = default)
        {
            var pathsResult = GetPathsFilesInDirectorywithPattern(directoryPathOnDisk, searchWay, pattern, allowedFlates);
            return ArchiveFiles(pathsResult);
        }
        /// <summary>
        /// a simple async function that wraps the functionality for archiving files in a Directory for Specific Pattern  
        /// </summary>
        /// <param name="directoryPathOnDisk">a phisycal path for a Directory which you Want to Archive</param>
        /// <param name="searchWay">an Enum For Searshing Options Either RegEx or WildCard </param>
        /// <param name="pattern"> contains the pattern you want to filter With it</param>
        /// <param name="allowedFlates">a flag determines what do you want Either subfolders or Flats directory </param>
        /// <returns>return archived directory as a MemoryStream</returns>
        public static async Task<MemoryStream> ArchiveDirectoryWithPatternStreamAsync(string directoryPathOnDisk, SearchPattern searchWay, string pattern, bool allowedFlates = default)
        {
            var pathsResult = GetPathsFilesInDirectorywithPattern(directoryPathOnDisk, searchWay, pattern, allowedFlates);
            return await ArchiveFilesAsync(pathsResult);
        }
        /// <summary>
        /// a simple function that wraps the functionality for Getting Paths of Files in a Directory for Specific Pattern  
        /// </summary>
        /// <param name="directoryPathOnDisk">a phisycal path for a Directory which you Want to Archive</param>
        /// <param name="searchWay">an Enum For Searshing Options Either RegEx or WildCard </param>
        /// <param name="pattern"> contains the pattern you want to filter With it</param>
        /// <param name="allowedFlates">a flag determines what do you want Either subfolders or Flats directory </param>
        /// <returns>return a Dictionary that Contains Key:phisycal path of files,Value:relative path for Archived Directory</returns>
        private static Dictionary<string, string> GetPathsFilesInDirectorywithPattern(string directoryPathOnDisk, SearchPattern searchWay, string pattern,  bool allowedFlates)
        {
            Dictionary<string, string> Paths = new Dictionary<string, string>();
            if (searchWay == SearchPattern.RegEx)
            {
                Regex rgx = new Regex(pattern);
                var files = Directory.GetFiles(directoryPathOnDisk, "*.*", SearchOption.AllDirectories);
                if (allowedFlates)
                    files?.Where(f => rgx.IsMatch(Path.GetFileName(f))).ToList().ForEach(rf => Paths.Add(rf, Path.GetFileName(rf)));
                else
                    files?.Where(f => rgx.IsMatch(Path.GetFileName(f))).ToList().ForEach(rf => Paths.Add(rf, rf.Substring(directoryPathOnDisk.Length + 1)));
            }
            else if (searchWay == SearchPattern.WildCard)
            {
                var files = Directory.GetFiles(directoryPathOnDisk, pattern, SearchOption.AllDirectories);
                if (allowedFlates)
                    files?.ToList().ForEach(rf => Paths.Add(rf, Path.GetFileName(rf)));
                else
                    files?.ToList().ForEach(rf => Paths.Add(rf, rf.Substring(directoryPathOnDisk.Length + 1)));
            }

            return Paths;
        }

        //TODO: add files to existing archive
        //TODO: get files metadata from archive
        //TODO: extract particular file from archive
        //TODO: get a file stream from archive
        //TODO: get all files metadata and streams from archive
        //TODO: extract archive as flat directory
        //TODO: extract archive to directory
        //TODO: overloads to specify the compressing algorithm with more support than the LZ77/78, DEFLATE like rar and others
    }
}
