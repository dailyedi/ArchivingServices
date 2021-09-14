using ArchivingServices;
using ArchivingServices.Structure;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Principal;
using System.Threading.Tasks;

namespace TestProject1
{
    public class Tests
    {

        #region ArchiveFilesInRootFolder

        [Test]
        public void Test_ArchiveFilesInRootFolder_true()
        {
            List<string> y = new List<string>() { "D:/New folder{}/test.txt", "D:/New folder{}/test2.txt" };

            Assert.IsTrue(ArchivingServicess.ArchiveFilesInRootFolder(y, "D:/ArchiveFilesInRootFolder_true_1.zip"));
            Assert.That(ArchivingServicess.ArchiveFilesInRootFolder(y, "D:/ArchiveFilesInRootFolder_true_2.zip"));

            string zipPath = @"D:/ArchiveFilesInRootFolder_true_1.zip";
            string extractPath = @"D:/extract";

            Assert.IsTrue(File.Exists("D:/ArchiveFilesInRootFolder_true_1.zip") && File.Exists("D:/ArchiveFilesInRootFolder_true_2.zip"));

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
            Assert.IsTrue(File.Exists("D:/extract/test2.txt")&& File.Exists("D:/extract/test.txt"));
        }

        [Test]
        public void Test_ArchiveFilesInRootFolder_false()
        {
            List<string> y = new List<string>() { "D:/New folder{}/", "D:/New folder{}/test2" };

            Assert.False(ArchivingServicess.ArchiveFilesInRootFolder(y, "E:/Newfolder"));
            
            Assert.False(ArchivingServicess.ArchiveFilesInRootFolder(new List<string> { "D:/New folder{}/test.txt", "D:/New folder{}/test2.txt" }, "E:/Newfolder"));
            Assert.False(File.Exists("E:/Newfolder"));

            Assert.NotNull(ArchivingServicess.ArchiveFilesInRootFolder(y, "Newfolder"));
            Assert.That(ArchivingServicess.ArchiveFilesInRootFolder(y, "Newfolder"), Is.Not.Null);
            Assert.AreEqual(false, ArchivingServicess.ArchiveFilesInRootFolder(y, "Newfolder"));
            Assert.That(!ArchivingServicess.ArchiveFilesInRootFolder(y, "DNewfolder"));

            Assert.False(File.Exists("D:/ArchiveFilesInRootFolder_true_1.zip") && File.Exists("D:/ArchiveFilesInRootFolder_true_2.zip"));
            Assert.False(File.Exists("D:/extract/test2.txt") && File.Exists("D:/extract/test.txt"));


        }

        #endregion

        #region ArchiveSingleFileInRootFolder

        [Test]
        public void Test_ArchiveSingleFileInRootFolder_true()
        {
            Assert.IsTrue(ArchivingServicess.ArchiveSingleFileInRootFolder("D:/New folder{}/test.txt", "D:/ArchiveSingleFileInRootFolder_true_1.zip"));
            Assert.That(ArchivingServicess.ArchiveSingleFileInRootFolder("D:/New folder{}/test.txt", "D:/ArchiveSingleFileInRootFolder_true_2.zip"));

            string zipPath = @"D:/ArchiveSingleFileInRootFolder_true_1.zip";
            string extractPath = @"D:/extract";

            Assert.IsTrue(File.Exists("D:/ArchiveSingleFileInRootFolder_true_1.zip") && File.Exists("D:/ArchiveSingleFileInRootFolder_true_2.zip"));

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
            Assert.IsTrue(File.Exists("D:/extract/test.txt"));

        }

        [Test]
        public void Test_ArchiveSingleFileInRootFolder_false()
        {
            Assert.False(ArchivingServicess.ArchiveSingleFileInRootFolder("D:/New folder{}/test.txt", "D:/"));
            Assert.False(ArchivingServicess.ArchiveSingleFileInRootFolder("D:/New folder{}/test.xyz", "D:/"));
            Assert.NotNull(ArchivingServicess.ArchiveSingleFileInRootFolder("D:/", "D:/"));
            Assert.AreNotEqual(true, ArchivingServicess.ArchiveSingleFileInRootFolder("D:/", "D:/"));

            Assert.That(!ArchivingServicess.ArchiveSingleFileInRootFolder("D:/", "D:/"));

            Assert.False(File.Exists("D:/ArchiveSingleFileInRootFolder_true_1.zip") && File.Exists("D:/ArchiveSingleFileInRootFolder_true_2.zip"));
            Assert.False(File.Exists("D:/extract/test.txt"));

        }

        #endregion

        #region ArchiveFiles_List<ZipFileConfig>

        [Test]
        public void Test_ArchiveFiles_true()
        {

            List<ZipFileConfig> zipFileConfigss = new List<ZipFileConfig>() {
                new ZipFileConfig("D:/New folder{}/test.txt","test.txt")
            };

            Assert.IsTrue(ArchivingServicess.ArchiveFiles(zipFileConfigss, "D:/ArchiveFiles_true_1.zip"));
            Assert.That(ArchivingServicess.ArchiveFiles(zipFileConfigss, "D:/ArchiveFiles_true_2.zip"));

            string zipPath = @"D:/ArchiveFiles_true_1.zip";
            string extractPath = @"D:/extract";

            Assert.True(File.Exists("D:/ArchiveFiles_true_1.zip") && File.Exists("D:/ArchiveFiles_true_2.zip"));

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
            Assert.True(File.Exists("D:/extract/test.txt"));

        }

        [Test]
        public void Test_ArchiveFiles_false()
        {
            List<ZipFileConfig> zipFileConfigs = new List<ZipFileConfig>() { new ZipFileConfig("D:/New folder{}/.","test.txt")};

            Assert.False(ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/"));
            Assert.NotNull(ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/"));

            Assert.That(ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/"), Is.Not.Null);
            Assert.That(!ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/"));

            Assert.False(File.Exists("D:/ArchiveFiles_true_1.zip") && File.Exists("D:/ArchiveFiles_true_2.zip"));
            Assert.False(File.Exists("D:/extract/test.txt"));
        }

        #endregion

        #region ArchiveSingleFile_ZipFileConfig

        [Test]
        public void Test_ArchiveSingleFile_true()
        {

            ZipFileConfig zipFileConfigs = new ZipFileConfig("D:/New folder{}/test.txt", "new/test.txt");

            Assert.IsTrue(ArchivingServicess.ArchiveSingleFile(zipFileConfigs, "D:/ArchiveSingleFile_true_1.zip"));
            Assert.That(ArchivingServicess.ArchiveSingleFile(zipFileConfigs, "D:/ArchiveSingleFile_true_2.zip"));

            string zipPath = @"D:/ArchiveSingleFile_true_1.zip";
            string extractPath = @"D:/extract";

            Assert.True(File.Exists("D:ArchiveSingleFile_true_1.zip") && File.Exists("D:/ArchiveSingleFile_true_2.zip"));

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
            Assert.True(File.Exists("D:/extract/new/test.txt"));

        }

        [Test]
        public void Test_ArchiveSingleFile_false()
        {
            ZipFileConfig zipFileConfigs = new ZipFileConfig("D:/New folder{}/test.txt", "test.txt");

            Assert.False(ArchivingServicess.ArchiveSingleFile(zipFileConfigs, "D:/"));
            Assert.NotNull(ArchivingServicess.ArchiveSingleFile(zipFileConfigs, "D:/"));

            Assert.That(ArchivingServicess.ArchiveSingleFile(zipFileConfigs, "D:/"), Is.Not.Null);

            Assert.False(File.Exists("D:ArchiveSingleFile_true_1.zip") && File.Exists("D:/ArchiveSingleFile_true_2.zip"));
            Assert.False(File.Exists("D:/extract/test.txt"));
        }

        #endregion

        #region ArchiveFiles

        [Test]
        public void Test_ArchiveFile_true()
        {

            Assert.IsTrue(ArchivingServicess.ArchiveFile("D:/New folder{}/test.txt", "new/test.txt", "D:/ArchiveFile_true_1.zip"));
            Assert.That(ArchivingServicess.ArchiveFile("D:/New folder{}/test.txt", "test.txt", "D:/ArchiveFile_true_2.zip"));

            string zipPath = @"D:/ArchiveFile_true_1.zip";
            string extractPath = @"D:/extract";

            Assert.True(File.Exists("D:ArchiveFile_true_1.zip") && File.Exists("D:/ArchiveFile_true_2.zip"));

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
            Assert.True(File.Exists("D:/extract/new/test.txt"));

        }

        [Test]
        public void Test_ArchiveFile_false()
        {

            Assert.False(ArchivingServicess.ArchiveFile("D:/New folder{}/test.txt", "test.txt", "D:/"));
            Assert.NotNull(ArchivingServicess.ArchiveFile("D:/New folder{}/test.txt", "test.txt", "D:/"));
            Assert.That(ArchivingServicess.ArchiveFile("D:/New folder{}/test.txt", "test.txt", "D:/"), Is.Not.Null);
            Assert.That(!ArchivingServicess.ArchiveFile("D:/New folder{}/test.txt", "test.txt", "D:/"));

            Assert.False(File.Exists("D:ArchiveFile_true_1.zip") && File.Exists("D:/ArchiveFile_true_2.zip"));
            Assert.False(File.Exists("D:/extract/test.txt"));
        }

        #endregion

        #region ArchiveFiles

        [Test]
        public void Test_ArchiveFiles_Dic_true()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>() { };
            dic.Add("D:/New folder{}/test.txt", "test.txt");

            Assert.IsTrue(ArchivingServicess.ArchiveFiles(dic, "D:/ArchiveFiles_true_1.zip"));
            Assert.That(ArchivingServicess.ArchiveFiles(dic, "D:/ArchiveFiles_true_2.zip"));

            string zipPath = @"D:/ArchiveFiles_true_1.zip";
            string extractPath = @"D:/extract";

            Assert.True(File.Exists("D:/ArchiveFiles_true_1.zip") && File.Exists("D:/ArchiveFiles_true_2.zip"));

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
            Assert.True(File.Exists("D:/extract/test.txt"));

        }

        [Test]
        public void Test_ArchiveFiles_Dic_false()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>() { };
            dic.Add("D:/New folder{}/test.txt", "test.txt");

            Assert.False(ArchivingServicess.ArchiveFiles(dic, "D:/"));
            Assert.NotNull(ArchivingServicess.ArchiveFiles(dic, "D:/"));
            Assert.That(ArchivingServicess.ArchiveFiles(dic, "D:/"), Is.Not.Null);
            Assert.That(!ArchivingServicess.ArchiveFiles(dic, "D:/"));

            Assert.False(File.Exists("D:ArchiveFile_true_1.zip") && File.Exists("D:/ArchiveFile_true_2.zip"));
            Assert.False(File.Exists("D:/extract/test.txt"));
        }

        #endregion

        #region ArchiveFiles_List<ZipStreamConfig>

        [Test]
        public void Test_ArchiveFiles_ListZipStreamConfig_true()
        {
            var fileStream = File.Create("D:/New folder{}/test.txt");

            List<ZipStreamConfig> zipFileConfigs = new List<ZipStreamConfig>() {
                new ZipStreamConfig(fileStream,"test.txt")
            };

            Assert.IsTrue(ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/ArchiveFiles_ListZipStreamConfig_true_1.zip"));
            Assert.That(ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/ArchiveFiles_ListZipStreamConfig_true_2.zip"));

            string zipPath = @"D:/ArchiveFiles_ListZipStreamConfig_true_1.zip";
            string extractPath = @"D:/extract";

            Assert.True(File.Exists("D:ArchiveFiles_ListZipStreamConfig_true_1.zip") && File.Exists("D:/ArchiveFiles_ListZipStreamConfig_true_2.zip"));

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
            Assert.True(File.Exists("D:/extract/test.txt"));


        }

        [Test]
        public void Test_ArchiveFiles_ListZipStreamConfig_false()
        {
            var fileStream = File.Create("D:/New folder{}/test.txt");

            List<ZipStreamConfig> zipFileConfigs = new List<ZipStreamConfig>() { new ZipStreamConfig(fileStream,"test.txt") };

            Assert.False(ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/"));
            Assert.NotNull(ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/"));

            Assert.That(ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/"), Is.Not.Null);
            Assert.That(!ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/"));

            Assert.False(File.Exists("D:ArchiveFiles_ListZipStreamConfig_true_1.zip") && File.Exists("D:/ArchiveFiles_ListZipStreamConfig_true_2.zip"));
            Assert.False(File.Exists("D:/extract/test.txt"));

        }

        #endregion

        #region ArchiveFile_ZipStreamConfig
        [Test]
        public void Test_ArchiveFile_ZipStreamConfig_true()
        {
            var fileStream = File.Create("D:/New folder{}/test.txt");

            ZipStreamConfig zipFileConfigs = new ZipStreamConfig(fileStream, "test.txt");

            Assert.IsTrue(ArchivingServicess.ArchiveFile(zipFileConfigs, "D:/ArchiveFile_ZipStreamConfig_true_1.zip"));
            Assert.That(ArchivingServicess.ArchiveFile(zipFileConfigs, "D:/ArchiveFile_ZipStreamConfig_true_2.zip"));


            string zipPath = @"D:/ArchiveFile_ZipStreamConfig_true_1.zip";
            string extractPath = @"D:/extract";

            Assert.True(File.Exists("D:/ArchiveFile_ZipStreamConfig_true_1.zip") && File.Exists("D:/ArchiveFile_ZipStreamConfig_true_2.zip"));

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
            Assert.True(File.Exists("D:/extract/test.txt"));


        }

        [Test]
        public void Test_ArchiveFile_ZipStreamConfig_false()
        {
            var fileStream = File.Create("D:/New folder{}/test.txt");

            ZipStreamConfig zipFileConfigs = new ZipStreamConfig(fileStream, "test.txt");

            Assert.False(ArchivingServicess.ArchiveFile(zipFileConfigs, "D:/"));
            Assert.NotNull(ArchivingServicess.ArchiveFile(zipFileConfigs, "D:/"));

            Assert.That(ArchivingServicess.ArchiveFile(zipFileConfigs, "D:/"), Is.Not.Null);
            Assert.That(!ArchivingServicess.ArchiveFile(zipFileConfigs, "D:/"));

            Assert.False(File.Exists("D:/ArchiveFile_ZipStreamConfig_true_1.zip") && File.Exists("D:/ArchiveFile_ZipStreamConfig_true_2.zip"));
            Assert.False(File.Exists("D:/extract/test.txt"));
        }

        #endregion

        #region ArchiveFile_3String

        [Test]
        public void Test_ArchiveFile_3String_true()
        {
            var fileStream = File.Create("D:/New folder{}/test.txt");

            Assert.IsTrue(ArchivingServicess.ArchiveFile("test2.txt", fileStream, "D:/ArchiveFile_3String_true_1.zip"));
            Assert.That(ArchivingServicess.ArchiveFile("test2.txt", fileStream, "D:/ArchiveFile_3String_true_2.zip"));

            string zipPath = @"D:/ArchiveFile_3String_true_1.zip";
            string extractPath = @"D:/extract";

            Assert.True(File.Exists("D:/ArchiveFile_3String_true_1.zip") && File.Exists("D:/ArchiveFile_3String_true_2.zip"));

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
            Assert.True(File.Exists("D:/extract/test2.txt"));

        }

        [Test]
        public void Test_ArchiveFile_3String_false()
        {
            var fileStream = File.Create("D:/New folder{}/test.txt");

            Assert.False(ArchivingServicess.ArchiveFile("",fileStream, "D:/"));
            Assert.NotNull(ArchivingServicess.ArchiveFile("",fileStream, "D:/"));

            Assert.That(ArchivingServicess.ArchiveFile("", fileStream, "D:/"), Is.Not.Null);
            Assert.That(!ArchivingServicess.ArchiveFile("", fileStream, "D:/"));

            Assert.False(File.Exists("D:/ArchiveFile_3String_true_1.zip") && File.Exists("D:/ArchiveFile_3String_true_2.zip"));
            Assert.False(File.Exists("D:/extract/test2.txt"));
        }

        #endregion

        #region ArchiveFilesAsync

        [Test]
        public async Task Test_ArchiveFilesAsync_true()
        {
            var fileStream = File.Create("D:/New folder{}/test.txt");

            List<ZipStreamConfig> zipFileConfigs = new List<ZipStreamConfig>() { new ZipStreamConfig(fileStream,"test.txt") };

            Assert.IsTrue(await ArchivingServicess.ArchiveFilesAsync(zipFileConfigs, "D:/Test_ArchiveFilesAsync_true_1.zip"));
            Assert.That(await ArchivingServicess.ArchiveFilesAsync(zipFileConfigs, "D:/Test_ArchiveFilesAsync_true_2.zip"));

            string zipPath = @"D:/Test_ArchiveFilesAsync_true_1.zip";
            string extractPath = @"D:/extract";

            Assert.True(File.Exists("D:/Test_ArchiveFilesAsync_true_1.zip") && File.Exists("D:/Test_ArchiveFilesAsync_true_2.zip"));

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
            Assert.True(File.Exists("D:/extract/test.txt"));
        }

        [Test]
        public async Task Test_ArchiveFilesAsync_false()
        {
            var fileStream = File.Create("D:/New folder{}/test.txt");

            List<ZipStreamConfig> zipFileConfigs = new List<ZipStreamConfig>() { new ZipStreamConfig(fileStream,"test.txt")};

            Assert.False(await ArchivingServicess.ArchiveFilesAsync(zipFileConfigs, "D:/"));
            Assert.NotNull(await ArchivingServicess.ArchiveFilesAsync(zipFileConfigs, "D:/"));

            Assert.That(await ArchivingServicess.ArchiveFilesAsync(zipFileConfigs, "D:/"), Is.Not.Null);
            Assert.That(!await ArchivingServicess.ArchiveFilesAsync(zipFileConfigs, "D:/"));

            Assert.False(File.Exists("D:/Test_ArchiveFilesAsync_true_1.zip") && File.Exists("D:/Test_ArchiveFilesAsync_true_2.zip"));
            Assert.False(File.Exists("D:/extract/test.txt"));
        }

        #endregion

        #region ArchiveFilesAsync
        [Test]
        public async Task Test_ArchiveFilesAsync_class_true()
        {
            var fileStream = File.Create("D:/New folder{}/test.txt");

            ZipStreamConfig zipFileConfigs =new ZipStreamConfig(fileStream, "test.txt" );

            Assert.IsTrue(await ArchivingServicess.ArchiveFileAsync(zipFileConfigs, "D:/Test_ArchiveFilesAsync_class_true_1.zip"));
            Assert.That(await ArchivingServicess.ArchiveFileAsync(zipFileConfigs, "D:/Test_ArchiveFilesAsync_class_true_2.zip"));

            string zipPath = @"D:/Test_ArchiveFilesAsync_class_true_1.zip";
            string extractPath = @"D:/extract";

            Assert.True(File.Exists("D:/Test_ArchiveFilesAsync_class_true_1.zip") && File.Exists("D:/Test_ArchiveFilesAsync_class_true_2.zip"));

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
            Assert.True(File.Exists("D:/extract/test.txt"));

        }

        [Test]
        public async Task Test_ArchiveFilesAsync_class_false()
        {
            var fileStream = File.Create("D:/New folder{}/test.txt");

            ZipStreamConfig zipFileConfigs = new ZipStreamConfig (fileStream,"test.txt");

            Assert.False(await ArchivingServicess.ArchiveFileAsync(zipFileConfigs, "D:/"));
            Assert.NotNull(await ArchivingServicess.ArchiveFileAsync(zipFileConfigs, "D:/"));

            Assert.That(await ArchivingServicess.ArchiveFileAsync(zipFileConfigs, "D:/"), Is.Not.Null);
            Assert.That(!await ArchivingServicess.ArchiveFileAsync(zipFileConfigs, "D:/"));

            Assert.False(File.Exists("D:/Test_ArchiveFilesAsync_class_true_1.zip") && File.Exists("D:/Test_ArchiveFilesAsync_class_true_2.zip"));
            Assert.False(File.Exists("D:/extract/test.txt"));
        }
        #endregion

        #region ArchiveFilesAsync
        [Test]
        public async Task Test_ArchiveFilesAsync_3string_true()
        {
            var fileStream = File.Create("D:/New folder{}/test.txt");

            Assert.IsTrue(await ArchivingServicess.ArchiveFileAsync("test.txt", fileStream, "D:/Test_ArchiveFilesAsync_3string_true_1.zip"));
            Assert.That(await ArchivingServicess.ArchiveFileAsync("test.txt", fileStream, "D:/Test_ArchiveFilesAsync_3string_true_2.zip"));

            string zipPath = @"D:/Test_ArchiveFilesAsync_3string_true_1.zip";
            string extractPath = @"D:/extract";

            Assert.True(File.Exists("D:/Test_ArchiveFilesAsync_3string_true_1.zip") && File.Exists("D:/Test_ArchiveFilesAsync_3string_true_2.zip"));

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
            Assert.True(File.Exists("D:/extract/test.txt"));

        }

        [Test]
        public async Task Test_ArchiveFilesAsync_3string_false()
        {
            var fileStream = File.Create("D:/New folder{}/test.txt");

            Assert.False(await ArchivingServicess.ArchiveFileAsync("test.txt", fileStream, "D:/"));
            Assert.NotNull(await ArchivingServicess.ArchiveFileAsync("test.txt", fileStream, "D:/"));

            Assert.That(await ArchivingServicess.ArchiveFileAsync("test.txt", fileStream, "D:/"), Is.Not.Null);
            Assert.That(!await ArchivingServicess.ArchiveFileAsync("test.txt", fileStream, "D:/"));

            Assert.False(File.Exists("D:/Test_ArchiveFilesAsync_3string_true_1.zip") && File.Exists("D:/Test_ArchiveFilesAsync_3string_true_2.zip"));
            Assert.False(File.Exists("D:/extract/test.txt"));
        }
        #endregion

        #region ArchiveFilesStream

        [Test]
        public void Test_ArchiveFilesStream_true()
        {
            var fileStream = File.Create("D:/New folder{}/test.txt");

            Dictionary<string, Stream> dic = new Dictionary<string, Stream>() { };
            dic.Add("test.txt", fileStream);

            Assert.IsTrue(ArchivingServicess.ArchiveFilesStream(dic, "D:/ArchiveFilesStream_true_1.zip"));
            Assert.That(ArchivingServicess.ArchiveFilesStream(dic, "D:/ArchiveFilesStream_true_2.zip"));

            string zipPath = @"D:/ArchiveFilesStream_true_1.zip";
            string extractPath = @"D:/extract";

            Assert.True(File.Exists("D:/ArchiveFilesStream_true_1.zip") && File.Exists("D:/ArchiveFilesStream_true_2.zip"));

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
            Assert.True(File.Exists("D:/extract/test.txt"));

        }

        [Test]
        public void Test_ArchiveFilesStream_false()
        {
            var fileStream = File.Create("D:/New folder{}/.txt");

            Dictionary<string, Stream> dic = new Dictionary<string, Stream>() { };
            dic.Add("test.txt", fileStream);

            Assert.False(ArchivingServicess.ArchiveFilesStream(dic, "D:/"));
            Assert.NotNull(ArchivingServicess.ArchiveFilesStream(dic ,"D:/"));

            Assert.That(ArchivingServicess.ArchiveFilesStream(dic, "D:/"), Is.Not.Null);
            Assert.That(!ArchivingServicess.ArchiveFilesStream(dic, "D:/"));

            Assert.False(File.Exists("D:/ArchiveFilesStream_true_1.zip") && File.Exists("D:/ArchiveFilesStream_true_2.zip"));
            Assert.False(File.Exists("D:/extract/test.txt"));
        }


        #endregion

        #region ArchiveFilesStreamAsync

        [Test]
        public async Task Test_ArchiveFilesStreamAsync_true()
        {
            var fileStream = File.Create("D:/New folder{}/test.txt");

            Dictionary<string, Stream> dic = new Dictionary<string, Stream>() { };
            dic.Add("test.txt", fileStream);
               
            Assert.IsTrue(await ArchivingServicess.ArchiveFilesStreamAsync(dic, "D:/ArchiveFilesStream_true_1.zip"));
            Assert.That(await ArchivingServicess.ArchiveFilesStreamAsync(dic, "D:/ArchiveFilesStream_true_2.zip"));

            string zipPath = @"D:/ArchiveFilesStream_true_1.zip";
            string extractPath = @"D:/extract";

            Assert.True(File.Exists("D:/ArchiveFilesStream_true_1.zip") && File.Exists("D:/ArchiveFilesStream_true_2.zip"));

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
            Assert.True(File.Exists("D:/extract/test.txt"));

        }

        [Test]
        public async Task Test_ArchiveFilesStreamAsync_false()
        {
            var fileStream = File.Create("D:/New folder{}/.txt");

            Dictionary<string, Stream> dic = new Dictionary<string, Stream>() { };
            dic.Add("test.txt", fileStream);

            Assert.False(await ArchivingServicess.ArchiveFilesStreamAsync(dic, "D:/"));
            Assert.NotNull(await ArchivingServicess.ArchiveFilesStreamAsync(dic, "D:/"));

            Assert.That(await ArchivingServicess.ArchiveFilesStreamAsync(dic, "D:/"), Is.Not.Null);
            Assert.That(!await ArchivingServicess.ArchiveFilesStreamAsync(dic, "D:/"));

            Assert.False(File.Exists("D:/ArchiveFilesStream_true_1.zip") && File.Exists("D:/ArchiveFilesStream_true_2.zip"));
            Assert.False(File.Exists("D:/extract/test.txt"));
        }

        #endregion
    }
}