using ArchivingServices;
using ArchivingServices.Structure;
using NUnit.Framework;
using SharpCompress.Archives.Rar;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace TestProject1
{
    public class Tests
    {
        #region Streaming

        #region ArchiveFilesInRootFolder
        [Test]
        public void Test_ArchiveFilesInRootFolder_Memorystream()
        {
            string fileName1 = "test1.txt", fileName2 = "test1 - Copy (1).txt";
            List<string> pathsSameName = new()
            {
                @"..\..\..\..\Testing\Input\test1.txt",
                @"..\..\..\..\Testing\test1.txt"
            };

            MemoryStream memoryStream = new(ArchivingServicess.ArchiveFilesInRootFolder(pathsSameName).ToArray());
            ZipArchive Archive = new(memoryStream);

            Assert.IsNotNull(memoryStream);
            Assert.AreEqual(2, Archive.Entries.Count);
            Assert.AreEqual(fileName1, Archive.Entries[0].Name);
            Assert.AreEqual(fileName2, Archive.Entries[1].Name);
        }
        #endregion

        #region ArchiveSingleFileInRootFolder
        [Test]
        public void Test_ArchiveSingleFileInRootFolder_MemoryStream()
        {
            string testFilePath = @"..\..\..\..\Testing\Input\test.txt", fileName = "test.txt";

            MemoryStream memoryStream = new(ArchivingServicess.ArchiveSingleFileInRootFolder(testFilePath).ToArray());
            ZipArchive Archive = new(memoryStream);

            Assert.IsNotNull(memoryStream);
            Assert.AreEqual(1, Archive.Entries.Count);
            Assert.AreEqual(fileName, Archive.Entries[0].Name);
        }
        #endregion

        #region ArchiveFiles_List<ZipFileConfig>
        [Test]
        public void Test_ArchiveFiles_MemoryStream()
        {
            string testFilePath = @"..\..\..\..\Testing\Input\test.txt", fileName = "test.txt";
            List<ZipFileConfig> zipFileConfig = new() { new ZipFileConfig(testFilePath, fileName) };

            MemoryStream memoryStream = new(ArchivingServicess.ArchiveFiles(zipFileConfig).ToArray());
            ZipArchive Archive = new(memoryStream);

            Assert.AreEqual(1, Archive.Entries.Count);
            Assert.IsNotNull(memoryStream);
            Assert.AreEqual(fileName, Archive.Entries[0].Name);
        }
        #endregion

        #region ArchiveSingleFile_ZipFileConfig
        [Test]
        public void Test_ArchiveSingleFile_MemoryStream()
        {
            string fileName = "new/test.txt", testFilePath = @"..\..\..\..\Testing\Input\test.txt";
            ZipFileConfig zipFileConfigs = new(testFilePath, fileName);

            MemoryStream memoryStream = new(ArchivingServicess.ArchiveSingleFile(zipFileConfigs).ToArray());
            ZipArchive Archive = new(memoryStream);

            Assert.IsNotNull(memoryStream);
            Assert.AreEqual(1, Archive.Entries.Count);
            Assert.AreEqual(fileName, Archive.Entries[0].FullName);
        }

        #endregion

        #region ArchiveFiles

        [Test]
        public void Test_ArchiveFile_MemoryStream()
        {
            string testFilePath = @"..\..\..\..\Testing\Input\test.txt", filName = "new/test.txt";

            MemoryStream memoryStream = new(ArchivingServicess.ArchiveFile(testFilePath, filName).ToArray());
            ZipArchive Archive = new(memoryStream);

            Assert.IsNotNull(memoryStream);
            Assert.AreEqual(1, Archive.Entries.Count);
            Assert.AreEqual(filName, Archive.Entries[0].FullName);
        }
        #endregion

        #region ArchiveStreamFiles
        [Test]
        public void Test_MemoryStream_Dic_MemoryStream()
        {
            string testFilePath = @"..\..\..\..\Testing\Input\test.txt", fileName = "test.txt";
            Dictionary<string, string> dic = new() { { testFilePath, fileName } };

            MemoryStream memoryStream = new(ArchivingServicess.ArchiveFiles(dic).ToArray());
            ZipArchive Archive = new(memoryStream);

            Assert.IsNotNull(memoryStream);
            Assert.AreEqual(1, Archive.Entries.Count);
            Assert.AreEqual(fileName, Archive.Entries[0].Name);
        }

        #endregion

        #region ArchiveFiles
        [Test]
        public void Test_ArchiveFiles_Dic_MemoryStream()
        {
            string testFilePath = @"..\..\..\..\Testing\Input\test.txt", fileName = "test.txt";
            Dictionary<string, string> dic = new() { { testFilePath, fileName } };

            MemoryStream memoryStream = new(ArchivingServicess.ArchiveFiles(dic).ToArray());
            ZipArchive Archive = new(memoryStream);

            Assert.IsNotNull(memoryStream);
            Assert.AreEqual(1, Archive.Entries.Count);
            Assert.AreEqual(fileName, Archive.Entries[0].Name);
        }
        #endregion

        #region ArchiveFiles_List<ZipStreamConfig>

        [Test]
        public void Test_ArchiveFiles_ListZipStreamConfig_MemoryStream()
        {
            string fileName = "test.txt";
            byte[] byteArray = Encoding.ASCII.GetBytes(fileName);
            MemoryStream stream = new(byteArray);
            List<ZipStreamConfig> zipFileConfigs = new() { new ZipStreamConfig(stream, fileName) };

            stream = new(ArchivingServicess.ArchiveFiles(zipFileConfigs).ToArray());
            ZipArchive Archive = new(stream);

            Assert.IsNotNull(stream);
            Assert.AreEqual(1, Archive.Entries.Count);
            Assert.AreEqual(fileName, Archive.Entries[0].Name);
        }
        #endregion

        #region ArchiveFile_ZipStreamConfig
        [Test]
        public void Test_ArchiveFile_ZipStreamConfig_MemoryStream()
        {
            string fileName = "test.txt";

            byte[] byteArray = Encoding.ASCII.GetBytes(fileName);
            MemoryStream stream = new(byteArray);
            ZipStreamConfig zipFileConfigs = new(stream, fileName);

            MemoryStream memoryStream = new(ArchivingServicess.ArchiveFile(zipFileConfigs).ToArray());
            ZipArchive Archive = new(memoryStream);

            Assert.IsNotNull(memoryStream);
            Assert.AreEqual(1, Archive.Entries.Count);
            Assert.AreEqual(fileName, Archive.Entries[0].FullName);

        }

        #endregion

        #region ArchiveFile_3String
        [Test]
        public void Test_ArchiveFile_3String_MemoryStream()
        {
            string fileName = "test.txt";
            byte[] byteArray = Encoding.ASCII.GetBytes(fileName);
            MemoryStream stream = new(byteArray);

            MemoryStream memoryStream = new(ArchivingServicess.ArchiveFile(fileName, stream).ToArray());
            ZipArchive Archive = new(memoryStream);

            Assert.IsNotNull(memoryStream);
            Assert.AreEqual(1, Archive.Entries.Count);
            Assert.AreEqual(fileName, Archive.Entries[0].Name);
        }
        #endregion

        #region ExtractArchive

        [Test]
        public void Test_Extract_Archive()
        {
            string fileName1 = "test1.txt", fileName2 = "test2.txt";
            string archivePath = @"..\..\..\..\Testing\Input\ArchiveFilesInRootFolder.zip";

            MemoryStream memoryStream = new(ArchivingServicess.ExtractArchive(archivePath).ToArray());
            ZipArchive Archive = new(memoryStream);

            Assert.IsNotNull(memoryStream);
            Assert.AreEqual(2, Archive.Entries.Count);
            Assert.AreEqual(fileName1, Archive.Entries[0].Name);
            Assert.AreEqual(fileName2, Archive.Entries[1].Name);
        }

        #endregion

        #region ExtractParticularFileFromArchive

        [Test]
        public void Test_Extract_Particular_File()
        {
            string fileName = "test.txt", archivePath = @"..\..\..\..\Testing\Input\ArchiveFilesInRootFolder.zip";

            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ExtractParticularFile(archivePath, fileName).ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);

            Assert.IsNotNull(memoryStream);
            Assert.AreEqual(1, Archive.Entries.Count);
            Assert.AreEqual(fileName, Archive.Entries[0].Name);
        }


        #endregion

        #region Test_Extract_Rar_Archive_Memorystream
        [Test]
        public void Test_Extract_Rar_Archive_Memorystream()
        {
            string rarPath = @"..\..\..\..\Testing\Input\testRAR.rar";
            var index = 0;
            var filesCollection = new List<string> { "test1.txt", "test2.txt" };

            MemoryStream memoryStream = new(ArchivingServicess.ExtractRarArchive(rarPath).ToArray());
            RarArchive archive = RarArchive.Open(memoryStream);

            Assert.IsNotNull(memoryStream);
            Assert.AreEqual(2, archive.Entries.Count);
            foreach (var item in archive.Entries)
            {
                Assert.AreEqual(filesCollection[index], archive.Entries.ElementAt(index).Key);
                index += 1;
            }
        }
        #endregion

        #region Extract_Archive_Flat_Directory
        [Test]
        public void Test_Extract_Archive_Flat_Directory()
        {
            string fileName1 = "test1.txt", fileName2 = "test2.txt";
            string archivePath = @"..\..\..\..\Testing\Input\ArchiveFilesInRootFolder.zip";

            MemoryStream memoryStream = new(ArchivingServicess.ExtractArchiveFlatDirectory(archivePath).ToArray());
            ZipArchive Archive = new(memoryStream);

            Assert.IsNotNull(memoryStream);
            Assert.AreEqual(2, Archive.Entries.Count);
            Assert.AreEqual(fileName2, Archive.Entries[1].Name);
            Assert.AreEqual(fileName1, Archive.Entries[0].Name);

        }
        #endregion

        #endregion Streaming

        #region Archiving
        #region TestingArchivingDirectory
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ArchiveDirectoryStream_whenCalled_ReturnStream(bool allowedEmptyNode)
        {
            string directoryName = "ArchiveDirectoryStream";
            string inputPath = @"..\..\..\..\Testing\Input\" + directoryName;
            DirectoryInfo inputDirectoryInfo = new DirectoryInfo(inputPath);
            IEnumerable<FileInfo> inputFilesList = inputDirectoryInfo.GetFiles("*.*", SearchOption.AllDirectories);
            var archivedFile = ArchivingServicess.ArchiveDirectoryStream(inputPath, allowedEmptyNode);
            MemoryStream archivedFileStream = new MemoryStream(archivedFile.ToArray());
            ZipArchive archivedFileZiped = new ZipArchive(archivedFileStream);

            foreach (var inputFileInfo in inputFilesList)
            {
                string fileFullName = inputFileInfo.FullName.Substring(inputFileInfo.FullName.LastIndexOf(directoryName));
                fileFullName = fileFullName.Remove(0, directoryName.Count() + 1);

                Assert.That(archivedFileZiped.Entries.Any(ae => ae.FullName == fileFullName));
            }
        }
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ArchiveDirectoryStreamAsync_whenCalled_ReturnStream(bool allowedEmptyNode)
        {
            string directoryName = "ArchiveDirectoryStream";
            string inputPath = @"..\..\..\..\Testing\Input\" + directoryName;
            var archivedFile = await ArchivingServicess.ArchiveDirectoryStreamAsync(inputPath, allowedEmptyNode);
            MemoryStream archivedFileStream = new MemoryStream(archivedFile.ToArray());
            ZipArchive archivedFileZiped = new ZipArchive(archivedFileStream);
            DirectoryInfo inputDirectoryInfo = new DirectoryInfo(inputPath);
            IEnumerable<FileInfo> inputFilesList = inputDirectoryInfo.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (var inputFileInfo in inputFilesList)
            {
                string fileFullName = inputFileInfo.FullName.Substring(inputFileInfo.FullName.LastIndexOf(directoryName));
                fileFullName = fileFullName.Remove(0, directoryName.Count() + 1);

                Assert.That(archivedFileZiped.Entries.Any(ae => ae.FullName == fileFullName));
            }
        }
        #endregion
        #region TestingArchivingDirectoryFlats
        [Test]
        public void ArchiveDirectoryFlatesStream_whenCalled_ReturnStream()
        {
            string directoryName = "ArchiveDirectoryFlatesStream";
            string inputPath = @"..\..\..\..\Testing\Input\" + directoryName;
            var archivedFile = ArchivingServicess.ArchiveDirectoryFlatesStream(inputPath);
            MemoryStream archivedFileStream = new MemoryStream(archivedFile.ToArray());
            ZipArchive archivedFileZiped = new ZipArchive(archivedFileStream);
            DirectoryInfo inputDirectoryInfo = new DirectoryInfo(inputPath);
            IEnumerable<FileInfo> inputFilesList = inputDirectoryInfo.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (var item in inputFilesList)
            {
                Assert.That(archivedFileZiped.Entries.Any(f => f.Name == item.Name));
            }
        }
        [Test]
        public async Task ArchiveDirectoryFlatesStreamAsync_whenCalled_ReturnStream()
        {
            string directoryName = "ArchiveDirectoryFlatesStream";
            string inputPath = @"..\..\..\..\Testing\Input\" + directoryName;
            var archivedFile = await ArchivingServicess.ArchiveDirectoryFlatesStreamAsync(inputPath);
            MemoryStream archivedFileStream = new MemoryStream(archivedFile.ToArray());
            ZipArchive archivedFileZiped = new ZipArchive(archivedFileStream);
            DirectoryInfo inputDirectoryInfo = new DirectoryInfo(inputPath);
            IEnumerable<FileInfo> inputFilesList = inputDirectoryInfo.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (var item in inputFilesList)
            {
                Assert.That(archivedFileZiped.Entries.Any(f => f.Name == item.Name));
            }
        }
        #endregion
        #region TestingArchivingDirectorywithPattern
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ArchiveDirectoryWithPatternStream_whenCalled_ReturnStreamWithRegx(bool allowFlates)
        {
            string directoryName = "ArchiveDirectoryWithPatternStream";
            string inputPath = @"..\..\..\..\Testing\Input\" + directoryName;
            string patternRegx = "file[0-9]{2}.txt$";
            Regex patternMatch = new Regex(patternRegx);
            var archivedFile = ArchivingServicess.ArchiveDirectoryWithPatternStream(inputPath, SearchPattern.RegEx, patternRegx, allowFlates);
            MemoryStream archivedFileStream = new MemoryStream(archivedFile.ToArray());
            ZipArchive archivedFileZiped = new ZipArchive(archivedFileStream);
            DirectoryInfo inputDirectoryInfo = new DirectoryInfo(inputPath);
            IEnumerable<FileInfo> inputFilesList = inputDirectoryInfo.GetFiles("*.*", SearchOption.AllDirectories)
                .Where(f => patternMatch.IsMatch(Path.GetFileName(f.ToString())));
            if (allowFlates)
            {
                foreach (var item in inputFilesList)
                {
                    Assert.That(archivedFileZiped.Entries.Any(f => f.Name == item.Name));
                }
            }
            else
            {
                foreach (var inputFileInfo in inputFilesList)
                {
                    string fileFullName = inputFileInfo.FullName.Substring(inputFileInfo.FullName.LastIndexOf(directoryName));
                    fileFullName = fileFullName.Remove(0, directoryName.Count() + 1);

                    Assert.That(archivedFileZiped.Entries.Any(ae => ae.FullName == fileFullName));
                }
            }
        }
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ArchiveDirectoryWithPatternStreamAsync_whenCalled_ReturnStreamWithRegx(bool allowFlates)
        {
            string directoryName = "ArchiveDirectoryWithPatternStream";
            string inputPath = @"..\..\..\..\Testing\Input\" + directoryName;
            string patternRegx = "file[0-9]{2}.txt$";
            Regex patternMatch = new Regex(patternRegx);
            var archivedFile = await ArchivingServicess.ArchiveDirectoryWithPatternStreamAsync(inputPath, SearchPattern.RegEx, patternRegx, allowFlates);
            MemoryStream archivedFileStream = new MemoryStream(archivedFile.ToArray());
            ZipArchive archivedFileZiped = new ZipArchive(archivedFileStream);
            DirectoryInfo inputDirectoryInfo = new DirectoryInfo(inputPath);
            IEnumerable<FileInfo> inputFilesList = inputDirectoryInfo.GetFiles("*.*", SearchOption.AllDirectories)
                .Where(f => patternMatch.IsMatch(Path.GetFileName(f.ToString())));
            if (allowFlates)
            {
                foreach (var item in inputFilesList)
                {
                    Assert.That(archivedFileZiped.Entries.Any(f => f.Name == item.Name));
                }
            }
            else
            {
                foreach (var inputFileInfo in inputFilesList)
                {
                    string fileFullName = inputFileInfo.FullName.Substring(inputFileInfo.FullName.LastIndexOf(directoryName));
                    fileFullName = fileFullName.Remove(0, directoryName.Count() + 1);

                    Assert.That(archivedFileZiped.Entries.Any(ae => ae.FullName == fileFullName));
                }
            }
        }
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ArchiveDirectoryWithPatternStream_whenCalled_ReturnStreamWithWildCard(bool allowFlates)
        {
            string directoryName = "ArchiveDirectoryWithPatternStream";
            string inputPath = @"..\..\..\..\Testing\Input\" + directoryName;
            string patternWild = "?test.*";
            var archivedFile = ArchivingServicess.ArchiveDirectoryWithPatternStream(inputPath, SearchPattern.WildCard, patternWild, allowFlates);
            MemoryStream archivedFileStream = new MemoryStream(archivedFile.ToArray());
            ZipArchive archivedFileZiped = new ZipArchive(archivedFileStream);
            DirectoryInfo inputDirectoryInfo = new DirectoryInfo(inputPath);
            IEnumerable<FileInfo> inputFilesList = inputDirectoryInfo.GetFiles(patternWild, SearchOption.AllDirectories);
            if (allowFlates)
            {
                foreach (var item in inputFilesList)
                {
                    Assert.That(archivedFileZiped.Entries.Any(f => f.Name == item.Name));
                }
            }
            else
            {
                foreach (var inputFileInfo in inputFilesList)
                {
                    string fileFullName = inputFileInfo.FullName.Substring(inputFileInfo.FullName.LastIndexOf(directoryName));
                    fileFullName = fileFullName.Remove(0, directoryName.Count() + 1);

                    Assert.That(archivedFileZiped.Entries.Any(ae => ae.FullName == fileFullName));
                }
            }
        }
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ArchiveDirectoryWithPatternStreamAsync_whenCalled_ReturnStreamWithWildCard(bool allowFlates)
        {
            string directoryName = "ArchiveDirectoryWithPatternStream";
            string inputPath = @"..\..\..\..\Testing\Input\" + directoryName;
            string patternWild = "?test.*";
            var archivedFile = await ArchivingServicess.ArchiveDirectoryWithPatternStreamAsync(inputPath, SearchPattern.WildCard, patternWild, allowFlates);
            MemoryStream archivedFileStream = new MemoryStream(archivedFile.ToArray());
            ZipArchive archivedFileZiped = new ZipArchive(archivedFileStream);
            DirectoryInfo inputDirectoryInfo = new DirectoryInfo(inputPath);
            IEnumerable<FileInfo> inputFilesList = inputDirectoryInfo.GetFiles(patternWild, SearchOption.AllDirectories);
            if (allowFlates)
            {
                foreach (var item in inputFilesList)
                {
                    Assert.That(archivedFileZiped.Entries.Any(f => f.Name == item.Name));
                }
            }
            else
            {
                foreach (var inputFileInfo in inputFilesList)
                {
                    string fileFullName = inputFileInfo.FullName.Substring(inputFileInfo.FullName.LastIndexOf(directoryName));
                    fileFullName = fileFullName.Remove(0, directoryName.Count() + 1);

                    Assert.That(archivedFileZiped.Entries.Any(ae => ae.FullName == fileFullName));
                }
            }
        }
        #endregion
        #region AddFilesToExistingArchive
        [Test]
        public void AddfilesToExistArchive_whenCalled_SavfilesinArchivedfile()
        {
            string filePath = "AddfilesToExistArchive.zip";
            string fileTest1 = "test1.txt";
            string fileTest2 = "test2.txt";
            string inputPath = @"..\..\..\..\Testing\Input\" + filePath;
            List<string> filePaths = new List<string>()
            {
              @"..\..\..\..\Testing\Input\"+ fileTest1,
              @"..\..\..\..\Testing\Input\"+ fileTest2
            };

            MemoryStream streamedFile = ArchivingServicess.AddFilesToExistingArchiveStreamed(inputPath, filePaths);
            var streamedFileArray = new MemoryStream(streamedFile.ToArray());
            ZipArchive archive = new ZipArchive(streamedFileArray);

            foreach (var item in filePaths)
            {
                Assert.That(archive.Entries.Any(f => f.Name == Path.GetFileName(item)));
            }

        }
        #endregion
        #endregion Archiving


        //#region Extract_Rar_Archive

        //[Test]
        //public void AddfilesToExistArchive_whenCalled_SavfilesinArchivedfile()
        //{
        //    var d = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        //    ArchivingServicess.AddfilesToExistArchive(pathZipFile, filePaths);
        //    ZipFile.ExtractToDirectory(pathZipFile, ExtractPathFiles, overwriteFiles: true);
        //    var allFiles = Directory.GetFiles(ExtractPathFiles);
        //    bool result = false;
        //    foreach (var item in allFiles)
        //    {
        //        result = item.EndsWith("hello.txt");
        //        if (result)
        //            break;
        //    }
        //    Assert.That(result, Is.True);
        //}
        //#endregion

        #region metadata
        [Test]
        //[TestCase(@"..\..\..\..\Testing\MetadataTest\NewFolder.zip")]
        public void GetFilesMetadataFromArchive_Working_with_file_contains_one_subfile()
        {
            string inputPath = @"..\..\..\..\Testing\Input\MetadataTest\";
            string fileName = "FileToTestMetaS.zip";

            foreach (var file in ArchivingServicess.GetFilesMetadataFromArchive(inputPath + fileName))
            {
                Assert.NotNull(file.stream);
                Assert.NotNull(file.fileMetadata.FullName);
                Assert.NotNull(file.fileMetadata.Length);
                Assert.NotNull(file.fileMetadata.CompressedLength);
            }

        }
        [Test]
        // [TestCase(@"..\..\..\..\Testing\MetadataTest\NewFolder.zip")]
        public void GetFilesMetadataFromArchive_Working_with_file_contains_multiple_subfiles()
        {
            string inputPath = @"..\..\..\..\Testing\Input\MetadataTest\";
            string fileName = "FileToTestMetaM.zip";
            foreach (var file in ArchivingServicess.GetFilesMetadataFromArchive(inputPath + fileName))
            {
                Assert.NotNull(file.stream);
                Assert.NotNull(file.fileMetadata.FullName);
                Assert.NotNull(file.fileMetadata.Length);
                Assert.NotNull(file.fileMetadata.CompressedLength);
            }
        }
        [Test]
        //  [TestCase(@"..\..\..\..\MetaDataTest\NewFolder.zip")]
        public void GetFilesMetadataFromArchive_Not_Working_with_invalid_path()
        {
            string inputPath = @"..\..\..\..\Testing\MetadataTest\";
            string fileName = "FileToTestMetaM.zip";
            var ex = Assert.Throws<DirectoryNotFoundException>(() =>
            {
                foreach (var file in ArchivingServicess.GetFilesMetadataFromArchive(inputPath + fileName))
                {

                }
            });
            Assert.That(ex.Message, Is.EqualTo(ex.Message));
        }
        [Test]
        // [TestCase(null)]
        public void GetFilesMetadataFromArchive_Not_Working_with_null_path()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                foreach (var file in ArchivingServicess.GetFilesMetadataFromArchive(null))
                {
                }
            });
            Assert.That(ex.Message, Is.EqualTo(ex.Message));

        }


        #endregion Metadata
    }

}