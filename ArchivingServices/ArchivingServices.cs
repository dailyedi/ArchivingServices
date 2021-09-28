using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using ArchivingServices.Structure;
using System;
using System.IO;
using System.Collections.Generic;

namespace ArchivingServices
{
    /// <summary>
    /// a simple library used to encapsulate and wrap System.IO.Compression.ZipFile
    /// functions in a more real world common scenario 
    /// </summary>
    public static class ArchivingServicess
    {
        /// <summary>
        /// rename duplicated file name
        /// </summary>
        /// <param name="inFilesDictionary">a dictionary where the key is the file path on disk and the value is the file name</param>
        /// <returns>dictionary withot duplicated file name</returns>
        public static Dictionary<string, string> CheckDuplicateName(Dictionary<string, string> inFilesDictionary)
        {
            var list = inFilesDictionary.GroupBy(f => f.Value).Where(a => a.Count() > 1).ToList();
            foreach (var group in list)
            {
                for (int i = 1; i < group.Count(); i++)
                {
                    string[] splitFileExtention = group.ElementAt(i).Value.Split('.');
                    var (fileName, fileExtention) = new Tuple<string, string>(splitFileExtention[0], splitFileExtention[1]);
                    inFilesDictionary[group.ElementAt(i).Key] = $"{fileName} - Copy ({i}).{fileExtention}";
                }
            }
            return inFilesDictionary;
        }
        /// <summary>
        /// archive files in the list of paths inFilesList to the destination archivePath
        /// with using the file names in the archive from Path.GetFileName and add
        /// all of them in the root directory of the archive
        /// </summary>
        /// <param name="inFilesList">the files path list to archive</param>
        /// <param name="archivePath">the zip file path to create</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static bool ArchiveFilesInRootFolder(List<string> inFilesList, string archivePath) =>
            ArchiveFiles(CheckDuplicateName(inFilesList.ToDictionary(f => f, Path.GetFileName)), archivePath);
        /// <summary>
        /// archive files in the list of paths inFilesList to the stream archive
        /// with using the file names in the archive from Path.GetFileName and add
        /// all of them in the root directory of the archive
        /// </summary>
        /// <param name="inFilesList">the files path list to archive</param>
        /// <returns>MemoryStream</returns>
        public static MemoryStream ArchiveFilesInRootFolder(List<string> inFilesList) =>
             ArchiveFiles(CheckDuplicateName(inFilesList.ToDictionary(f => f, Path.GetFileName)));
        /// <summary>
        /// archive a single file to the destination archivePath
        /// with using the file name in the archive from Path.GetFileName and add
        /// all of them in the root directory of the archive
        /// </summary>
        /// <param name="inFile">the file path to archive</param>
        /// <param name="archivePath">the zip file path to create</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static bool ArchiveSingleFileInRootFolder(string inFile, string archivePath) =>
            ArchiveFiles(CheckDuplicateName(new Dictionary<string, string>
            {
                {inFile, Path.GetFileName(inFile)}
            }), archivePath);
        /// <summary>
        /// archive a single file to the destination stream archive
        /// with using the file name in the archive from Path.GetFileName and add
        /// all of them in the root directory of the archive
        /// </summary>
        /// <param name="inFile">the file path to archive</param>
        /// <returns>MemoryStream</returns>
        public static MemoryStream ArchiveSingleFileInRootFolder(string inFile) =>
            ArchiveFiles(CheckDuplicateName(new Dictionary<string, string> { { inFile, Path.GetFileName(inFile) } }));
        /// <summary>
        /// archive files in the list of objects ZipFileConfig which you
        /// can specify the file path on disk and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipConfigurationList">the list of objects ZipFileConfig to archive</param>
        /// <param name="archivePath">the zip file path to create</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static bool ArchiveFiles(List<ZipFileConfig> zipConfigurationList, string archivePath) =>
            ArchiveFiles(CheckDuplicateName(zipConfigurationList.ToDictionary(z => z.FilePathOnDisk,
                z => z.FilePathInArchive)), archivePath);
        /// <summary>
        /// archive files in the list of objects ZipFileConfig which you
        /// can specify stream archive and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipConfigurationList">the list of objects ZipFileConfig to archive</param>
        /// <returns>MemoryStream</returns>
        public static MemoryStream ArchiveFiles(List<ZipFileConfig> zipConfigurationList) =>
            ArchiveFiles(CheckDuplicateName(zipConfigurationList.ToDictionary(z => z.FilePathOnDisk, z => z.FilePathInArchive)));
        /// <summary>
        /// archive file in the ZipFileConfig which you
        /// can specify the file path on disk and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipFileConfiguration">the object ZipFileConfig to archive</param>
        /// <param name="archivePath">the zip file path to create</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static bool ArchiveSingleFile(ZipFileConfig zipFileConfiguration, string archivePath) =>
            ArchiveFiles(CheckDuplicateName(new Dictionary<string, string>{
                { zipFileConfiguration.FilePathOnDisk, zipFileConfiguration.FilePathInArchive } })
            , archivePath);
        /// <summary>
        /// archive file in the ZipFileConfig which you
        /// can specify the stream archive and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipFileConfiguration">the object ZipFileConfig to archive</param>
        /// <returns>Memory Stream</returns>
        public static MemoryStream ArchiveSingleFile(ZipFileConfig zipFileConfiguration) =>
            ArchiveFiles(CheckDuplicateName(new Dictionary<string, string> { { zipFileConfiguration.FilePathOnDisk, zipFileConfiguration.FilePathInArchive } }));
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
        /// a simple function that wraps the functionality for
        /// zipping file dictionary into MemoryStream
        /// </summary>
        /// <param name="inFilesDictionary">a dictionary where the key is the file path on disk and the value is the file path in the archive</param>
        /// <returns>memoryStream</returns>
        public static MemoryStream ArchiveFiles(Dictionary<string, string> inFilesDictionary)
        {
            using (var memoryStream = new MemoryStream())
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
                    return memoryStream;
                }
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
        /// using the file path on stream archive and the file path in archive to be created
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
            return ArchiveFiles(CheckDuplicateName(dic));
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
              ArchiveFilesStream(zipConfigurationList.ToDictionary(z => z.FilePathInArchive, z => z.FileStream));
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
        /// can specify the file path on stream archive and the file path in the zip file
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipConfiguration">the list of objects called ZipFileConfig to archive</param>
        /// <returns>Memory Stream</returns>
        public static MemoryStream ArchiveFile(ZipStreamConfig zipConfiguration) =>
             ArchiveFilesStream(new Dictionary<string, Stream> { { zipConfiguration.FilePathInArchive, zipConfiguration.FileStream } });
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
        /// can specify the file stream and the file path in the stream archive
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="filePathInArchive">the file path in the archive to be created</param>
        /// <param name="fileStream">the file stream to archive</param>
        /// <returns>Memory Stream</returns>
        public static MemoryStream ArchiveFile(string filePathInArchive, Stream fileStream) =>
             ArchiveFilesStream(new Dictionary<string, Stream> { { filePathInArchive, fileStream } });
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
        /// can specify the file stream and the file path in the stream archive
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipConfigurationList">the list of objects called ZipFileConfig to archive</param>
        /// <returns>Memory Stream</returns>
        public static async Task<MemoryStream> ArchiveFilesAsync(List<ZipStreamConfig> zipConfigurationList) =>
            await ArchiveFilesStreamAsync(zipConfigurationList.ToDictionary(z => z.FilePathInArchive,
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
        /// can specify the file stream and the file path in the stream archive
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="zipConfiguration">the list of objects called ZipFileConfig to archive</param>
        /// <returns>Memory Stream</returns>
        public static async Task<MemoryStream> ArchiveFileAsync(ZipStreamConfig zipConfiguration) =>
             await ArchiveFilesStreamAsync(new Dictionary<string, Stream>
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
        /// <summary>
        /// archive file Async using the stream provided with the file path in archive
        /// which gives you more control over having everything in the root folder
        /// </summary>
        /// <param name="filePathInArchive">the file path in the archive to be created</param>
        /// <param name="fileStream">the file stream to archive</param>
        /// <returns>Memory Stream</returns>
        public static async Task<MemoryStream> ArchiveFileAsync(string filePathInArchive, Stream fileStream) =>
            await ArchiveFilesStreamAsync(new Dictionary<string, Stream> { { filePathInArchive, fileStream } });
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
                File.WriteAllBytes(archivePath, ArchiveFilesStream(inFilesDictionary).ToArray());
                return File.Exists(archivePath);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// a simple function that wraps the functionality for zipping file list into an stream archive
        /// </summary>
        /// <param name="inFilesDictionary">a dictionary where the key is the file path on disk and the value is the file path in the archive</param>
        /// <returns>Memory Stream</returns>
        public static MemoryStream ArchiveFilesStream(Dictionary<string, Stream> inFilesDictionary)
        {
            var dic = new Dictionary<string, string>() { };
            foreach (var item in inFilesDictionary)
            {
                StreamReader reader = new StreamReader(item.Value);
                dic.Add(item.Key, reader.ReadToEnd());
            }
            return ArchiveFiles(dic);
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
        /// <summary>
        /// a simple function that wraps the functionality for zipping files list into an stream archive
        /// </summary>
        /// <param name="inFilesDictionary">a dictionary where the key is the file path on disk and the value is the file path in the archive</param>
        /// <returns>memorystream</returns>
        public static async Task<MemoryStream> ArchiveFilesStreamAsync(Dictionary<string, Stream> inFilesDictionary)
        {

            var dic = new Dictionary<string, string>() { };
            foreach (var item in inFilesDictionary)
            {
                StreamReader reader = new StreamReader(item.Value);
                dic.Add(item.Key, await reader.ReadToEndAsync());
            }
            return ArchiveFiles(dic);
        }
        /// <summary>
        /// a simple function that extract archive
        /// </summary>
        /// <param name="zipPath">the archive path on disk </param>
        /// <param name="extractPath">the extract zip file path</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static bool ExtractArchive(string zipPath, string extractPath)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream(ExtractArchive(zipPath).ToArray());
                ZipArchive Archive = new ZipArchive(memoryStream);
                Archive.ExtractToDirectory(extractPath);
                return File.Exists($"{extractPath}/{Archive.Entries[0].FullName}");
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// a simple function that extract archive
        /// </summary>
        /// <param name="zipPath">the archive path on disk </param>
        /// <returns>memorystream</returns>
        public static MemoryStream ExtractArchive(string zipPath)
        {
            MemoryStream ms = new MemoryStream();
            using (FileStream file = new FileStream(zipPath, FileMode.Open, FileAccess.Read))
                file.CopyTo(ms);
            return ms;
        }
        /// <summary>
        /// a simple function that extract particular file from archive
        /// </summary>
        /// <param name="zipPath">the archive path on disk </param>
        /// <param name="extractPath">the extract zip file path</param>
        /// <param name="particularPath">particular path from archive</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static bool ExtractParticularFile(string zipPath, string extractPath, string particularPath)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream(ExtractArchive(zipPath).ToArray());
                ZipArchive Archive = new ZipArchive(memoryStream);

                foreach (ZipArchiveEntry entry in Archive.Entries)
                {
                    if (entry.FullName == particularPath)
                    {
                        entry.ExtractToFile(Path.Combine(extractPath, particularPath));
                    }
                }
                return File.Exists($"{extractPath}/{Archive.Entries[0].FullName}");
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// a simple function that extract particular file from archive
        /// </summary>
        /// <param name="zipPath">the archive path on disk </param>
        /// <param name="particularPath">particular path from archive</param>
        /// <returns>memorystream</returns>
        public static MemoryStream ExtractParticularFile(string zipPath, string particularPath)
        {
            MemoryStream extractData = new MemoryStream(ExtractArchive(zipPath).ToArray());
            ZipArchive unZipArchive = new ZipArchive(extractData);

            using (var memoryStream = new MemoryStream())
            {
                using (var Archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    foreach (var item in unZipArchive.Entries)
                    {
                        if (item.FullName == particularPath)
                        {
                            Archive.CreateEntry(particularPath);
                        }
                    }
                }
                return memoryStream;
            }
        }
        /// <summary>
        /// a simple function that extract archive to flat diractory
        /// </summary>
        /// <param name="zipPath">the archive path on disk </param>
        /// <param name="extractPath">the extract zip file path</param>
        /// <returns>the result as to where it was successful or not</returns>
        public static bool extractArchiveFlatDirectory(string zipPath, string extractPath) 
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream(ExtractArchive(zipPath).ToArray());
                ZipArchive Archive = new ZipArchive(memoryStream);

                foreach (ZipArchiveEntry entry in Archive.Entries)
                {
                    if (entry.Name != "")
                    {
                        entry.ExtractToFile(Path.Combine(extractPath, entry.Name));
                    }
                }
                return File.Exists(extractPath);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// a simple function that extract archive to flat diractory
        /// </summary>
        /// <param name="zipPath">the archive path on disk </param>
        /// <returns>memorystream</returns>
        public static MemoryStream extractArchiveFlatDirectory(string zipPath)
        {

            MemoryStream extractData = new MemoryStream(ExtractArchive(zipPath).ToArray());
            ZipArchive unZipArchive = new ZipArchive(extractData);

            using (var memoryStream = new MemoryStream())
            {
                using (var Archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    foreach (var item in unZipArchive.Entries)
                    {
                        if (item.FullName != "")
                        {
                            Archive.CreateEntry(item.Name);
                        }
                    }
                }
                return memoryStream;
            }
        }




        //TODO: extract archive to directory
        //TODO: extract particular file from archive
        //TODO: extract archive as flat directory

        //TODO: get a file stream from archive

        //TODO: archive directory (same location, same name, only parameter is directory path)
        //TODO: archive directory with more options (include/exclude files patterns, archive all in root directory, archive to, etc..)
        //TODO: add files to existing archive
        //TODO: get files metadata from archive
        //TODO: get all files metadata and streams from archive
        //TODO: overloads to specify the compressing algorithm with more support than the LZ77/78, DEFLATE like rar and others
    }
}
