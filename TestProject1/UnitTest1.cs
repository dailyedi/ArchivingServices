using ArchivingServices;
using ArchivingServices.Structure;
using NUnit.Framework;
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

        [SetUp]
        public void SetUp()
        {
            testFilePath = @"..\..\..\..\testFolder\New folder\test.txt";
            fileName = "test.txt";
            archivePath = @"..\..\..\..\testFolder\ArchiveFilesInRootFolder_true_1.zip";

            filePathsSameNames = new List<string> { @"..\..\..\..\testFolder\New folder\test.txt", @"..\..\..\..\testFolder\test.txt" };
        }

        #region ArchiveFilesInRootFolder
        string testFilePath , archivePath, fileName;
        List<string>  filePathsSameNames = new List<string>();
        #endregion

        #region commented

        //#region ArchiveFilesInRootFolder

        //[Test]
        //public void Test_ArchiveFilesInRootFolder_true()
        //{
        //    List<string> y = new List<string>() { "D:/New folder{}/test.txt", "D:/test.txt" };

        //    //MemoryStream memoryStream1 = new MemoryStream(ArchivingServicess.ArchiveFilesInRootFolder(y).ToArray());
        //    //ZipArchive Archive1 = new ZipArchive(memoryStream1);

        //    //Assert.AreEqual("test.txt", Archive1.Entries[0].FullName);

        //    Assert.IsTrue(ArchivingServicess.ArchiveFilesInRootFolder(y, "D:/ArchiveFilesInRootFolder_true_1.zip"));
        //    //Assert.That(ArchivingServicess.ArchiveFilesInRootFolder(y, "D:/ArchiveFilesInRootFolder_true_2.zip"));

        //    //string zipPath = @"D:/ArchiveFilesInRootFolder_true_1.zip";
        //    //string extractPath = @"D:/extract";

        //    //Assert.IsTrue(File.Exists("D:/ArchiveFilesInRootFolder_true_1.zip") && File.Exists("D:/ArchiveFilesInRootFolder_true_2.zip"));

        //    //using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
        //    //Assert.IsTrue(File.Exists("D:/extract/test2.txt") && File.Exists("D:/extract/test.txt"));
        //}

        //[Test]
        //public void Test_ArchiveFilesInRootFolder_false()
        //{
        //    List<string> y = new List<string>() { "D:/New folder{}/", "D:/New folder{}/test2" };

        //    Assert.False(ArchivingServicess.ArchiveFilesInRootFolder(y, "E:/Newfolder"));

        //    Assert.False(ArchivingServicess.ArchiveFilesInRootFolder(new List<string> { "D:/New folder{}/test.txt", "D:/New folder{}/test2.txt" }, "E:/Newfolder"));
        //    Assert.False(File.Exists("E:/Newfolder"));

        //    Assert.NotNull(ArchivingServicess.ArchiveFilesInRootFolder(y, "Newfolder"));
        //    Assert.That(ArchivingServicess.ArchiveFilesInRootFolder(y, "Newfolder"), Is.Not.Null);
        //    Assert.AreEqual(false, ArchivingServicess.ArchiveFilesInRootFolder(y, "Newfolder"));
        //    Assert.That(!ArchivingServicess.ArchiveFilesInRootFolder(y, "DNewfolder"));

        //    Assert.False(File.Exists("D:/ArchiveFilesInRootFolder_true_1.zip") && File.Exists("D:/ArchiveFilesInRootFolder_true_2.zip"));
        //    Assert.False(File.Exists("D:/extract/test2.txt") && File.Exists("D:/extract/test.txt"));


        //}

        //#endregion

        //#region ArchiveSingleFileInRootFolder

        //[Test]
        //public void Test_ArchiveSingleFileInRootFolder_true()
        //{
        //    Assert.IsTrue(ArchivingServicess.ArchiveSingleFileInRootFolder("D:/New folder{}/test.txt", "D:/ArchiveSingleFileInRootFolder_true_1.zip"));
        //    Assert.That(ArchivingServicess.ArchiveSingleFileInRootFolder("D:/New folder{}/test.txt", "D:/ArchiveSingleFileInRootFolder_true_2.zip"));

        //    string zipPath = @"D:/ArchiveSingleFileInRootFolder_true_1.zip";
        //    string extractPath = @"D:/extract";

        //    Assert.IsTrue(File.Exists("D:/ArchiveSingleFileInRootFolder_true_1.zip") && File.Exists("D:/ArchiveSingleFileInRootFolder_true_2.zip"));

        //    using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
        //    Assert.IsTrue(File.Exists("D:/extract/test.txt"));

        //}

        //[Test]
        //public void Test_ArchiveSingleFileInRootFolder_false()
        //{
        //    Assert.False(ArchivingServicess.ArchiveSingleFileInRootFolder("D:/New folder{}/test.txt", "D:/"));
        //    Assert.False(ArchivingServicess.ArchiveSingleFileInRootFolder("D:/New folder{}/test.xyz", "D:/"));
        //    Assert.NotNull(ArchivingServicess.ArchiveSingleFileInRootFolder("D:/", "D:/"));
        //    Assert.AreNotEqual(true, ArchivingServicess.ArchiveSingleFileInRootFolder("D:/", "D:/"));

        //    Assert.That(!ArchivingServicess.ArchiveSingleFileInRootFolder("D:/", "D:/"));

        //    Assert.False(File.Exists("D:/ArchiveSingleFileInRootFolder_true_1.zip") && File.Exists("D:/ArchiveSingleFileInRootFolder_true_2.zip"));
        //    Assert.False(File.Exists("D:/extract/test.txt"));

        //}

        //#endregion

        //#region ArchiveFiles_List<ZipFileConfig>

        //[Test]
        //public void Test_ArchiveFiles_true()
        //{

        //    List<ZipFileConfig> zipFileConfigss = new List<ZipFileConfig>() {
        //        new ZipFileConfig("D:/New folder{}/test.txt","test.txt")
        //    };

        //    Assert.IsTrue(ArchivingServicess.ArchiveFiles(zipFileConfigss, "D:/ArchiveFiles_true_1.zip"));
        //    Assert.That(ArchivingServicess.ArchiveFiles(zipFileConfigss, "D:/ArchiveFiles_true_2.zip"));

        //    string zipPath = @"D:/ArchiveFiles_true_1.zip";
        //    string extractPath = @"D:/extract";

        //    Assert.True(File.Exists("D:/ArchiveFiles_true_1.zip") && File.Exists("D:/ArchiveFiles_true_2.zip"));

        //    using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
        //    Assert.True(File.Exists("D:/extract/test.txt"));

        //}

        //[Test]
        //public void Test_ArchiveFiles_false()
        //{
        //    List<ZipFileConfig> zipFileConfigs = new List<ZipFileConfig>() { new ZipFileConfig("D:/New folder{}/.", "test.txt") };

        //    Assert.False(ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/"));
        //    Assert.NotNull(ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/"));

        //    Assert.That(ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/"), Is.Not.Null);
        //    Assert.That(!ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/"));

        //    Assert.False(File.Exists("D:/ArchiveFiles_true_1.zip") && File.Exists("D:/ArchiveFiles_true_2.zip"));
        //    Assert.False(File.Exists("D:/extract/test.txt"));
        //}

        //#endregion

        //#region ArchiveSingleFile_ZipFileConfig

        //[Test]
        //public void Test_ArchiveSingleFile_true()
        //{

        //    ZipFileConfig zipFileConfigs = new ZipFileConfig("D:/New folder{}/test.txt", "new/test.txt");

        //    Assert.IsTrue(ArchivingServicess.ArchiveSingleFile(zipFileConfigs, "D:/ArchiveSingleFile_true_1.zip"));
        //    Assert.That(ArchivingServicess.ArchiveSingleFile(zipFileConfigs, "D:/ArchiveSingleFile_true_2.zip"));

        //    string zipPath = @"D:/ArchiveSingleFile_true_1.zip";
        //    string extractPath = @"D:/extract";

        //    Assert.True(File.Exists("D:ArchiveSingleFile_true_1.zip") && File.Exists("D:/ArchiveSingleFile_true_2.zip"));

        //    using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
        //    Assert.True(File.Exists("D:/extract/new/test.txt"));

        //}

        //[Test]
        //public void Test_ArchiveSingleFile_false()
        //{
        //    ZipFileConfig zipFileConfigs = new ZipFileConfig("D:/New folder{}/test.txt", "test.txt");

        //    Assert.False(ArchivingServicess.ArchiveSingleFile(zipFileConfigs, "D:/"));
        //    Assert.NotNull(ArchivingServicess.ArchiveSingleFile(zipFileConfigs, "D:/"));

        //    Assert.That(ArchivingServicess.ArchiveSingleFile(zipFileConfigs, "D:/"), Is.Not.Null);

        //    Assert.False(File.Exists("D:ArchiveSingleFile_true_1.zip") && File.Exists("D:/ArchiveSingleFile_true_2.zip"));
        //    Assert.False(File.Exists("D:/extract/test.txt"));
        //}

        //#endregion

        //#region ArchiveFiles

        //[Test]
        //public void Test_ArchiveFile_true()
        //{

        //    Assert.IsTrue(ArchivingServicess.ArchiveFile("D:/New folder{}/test.txt", "new/test.txt", "D:/ArchiveFile_true_1.zip"));
        //    Assert.That(ArchivingServicess.ArchiveFile("D:/New folder{}/test.txt", "test.txt", "D:/ArchiveFile_true_2.zip"));

        //    string zipPath = @"D:/ArchiveFile_true_1.zip";
        //    string extractPath = @"D:/extract";

        //    Assert.True(File.Exists("D:ArchiveFile_true_1.zip") && File.Exists("D:/ArchiveFile_true_2.zip"));

        //    using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
        //    Assert.True(File.Exists("D:/extract/new/test.txt"));

        //}

        //[Test]
        //public void Test_ArchiveFile_false()
        //{

        //    Assert.False(ArchivingServicess.ArchiveFile("D:/New folder{}/test.txt", "test.txt", "D:/"));
        //    Assert.NotNull(ArchivingServicess.ArchiveFile("D:/New folder{}/test.txt", "test.txt", "D:/"));
        //    Assert.That(ArchivingServicess.ArchiveFile("D:/New folder{}/test.txt", "test.txt", "D:/"), Is.Not.Null);
        //    Assert.That(!ArchivingServicess.ArchiveFile("D:/New folder{}/test.txt", "test.txt", "D:/"));

        //    Assert.False(File.Exists("D:ArchiveFile_true_1.zip") && File.Exists("D:/ArchiveFile_true_2.zip"));
        //    Assert.False(File.Exists("D:/extract/test.txt"));
        //}

        //#endregion

        //#region ArchiveStreamFiles

        //[Test]
        //public void Test_MemoryStream_Dic_true()
        //{
        //    //Dictionary<string, string> dic = new Dictionary<string, string>() { };
        //    //dic.Add("D:/New folder{}/test.txt", "test.txt");

        //    //MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ArchiveFiles(dic).ToArray());
        //    //ZipArchive Archive = new ZipArchive(memoryStream);

        //    //Assert.AreEqual("test.txt", Archive.Entries[0].Name);
        //    //Assert.AreEqual("test.txt", Archive.Entries[0].FullName);



        //    //MemoryStream memoryStream1 = new MemoryStream(ArchivingServicess.ArchiveFile("D:/New folder{}/test.txt", "new/test.txt").ToArray());
        //    //ZipArchive Archive1 = new ZipArchive(memoryStream1);

        //    //Assert.AreEqual("new/test.txt", Archive1.Entries[0].FullName);



        //    byte[] byteArray = Encoding.ASCII.GetBytes("test.txt");
        //    MemoryStream stream2 = new MemoryStream(byteArray);

        //    Dictionary<string, Stream> dic2 = new Dictionary<string, Stream>() { };
        //    dic2.Add("D:/New folder{}/test.txt", stream2);

        //    //MemoryStream memoryStream2 = new MemoryStream(ArchivingServicess.ArchiveFilesStreamAsync(dic2).ToArray());
        //    //ZipArchive Archive2 = new ZipArchive(memoryStream2);

        //    //Assert.AreEqual("test.txt", Archive2.Entries[0].FullName);
        //}

        //#endregion

        //#region ArchiveFiles

        //[Test]
        //public void Test_ArchiveFiles_Dic_true()
        //{
        //    Dictionary<string, string> dic = new Dictionary<string, string>() { };
        //    dic.Add("D:/New folder{}/test.txt", "test.txt");

        //    Assert.IsTrue(ArchivingServicess.ArchiveFiles(dic, "D:/ArchiveFiles_true_1.zip"));

        //    string zipPath = @"D:/ArchiveFiles_true_1.zip";
        //    string extractPath = @"D:/extract";

        //    Assert.True(File.Exists("D:/ArchiveFiles_true_1.zip"));

        //    using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
        //    Assert.True(File.Exists("D:/extract/test.txt"));

        //}

        //[Test]
        //public void Test_ArchiveFiles_Dic_false()
        //{
        //    Dictionary<string, string> dic = new Dictionary<string, string>() { };
        //    dic.Add("D:/New folder{}/test.txt", "test.txt");

        //    Assert.False(ArchivingServicess.ArchiveFiles(dic, "D:/"));
        //    Assert.NotNull(ArchivingServicess.ArchiveFiles(dic, "D:/"));
        //    Assert.That(ArchivingServicess.ArchiveFiles(dic, "D:/"), Is.Not.Null);
        //    Assert.That(!ArchivingServicess.ArchiveFiles(dic, "D:/"));

        //    Assert.False(File.Exists("D:ArchiveFile_true_1.zip") && File.Exists("D:/ArchiveFile_true_2.zip"));
        //    Assert.False(File.Exists("D:/extract/test.txt"));
        //}

        //#endregion

        //#region ArchiveFiles_List<ZipStreamConfig>

        //[Test]
        //public void Test_ArchiveFiles_ListZipStreamConfig_true()
        //{
        //    var fileStream = File.Create("D:/New folder{}/test.txt");

        //    List<ZipStreamConfig> zipFileConfigs = new List<ZipStreamConfig>() {
        //        new ZipStreamConfig(fileStream,"test.txt")
        //    };

        //    Assert.IsTrue(ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/ArchiveFiles_ListZipStreamConfig_true_1.zip"));
        //    Assert.That(ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/ArchiveFiles_ListZipStreamConfig_true_2.zip"));

        //    string zipPath = @"D:/ArchiveFiles_ListZipStreamConfig_true_1.zip";
        //    string extractPath = @"D:/extract";

        //    Assert.True(File.Exists("D:ArchiveFiles_ListZipStreamConfig_true_1.zip") && File.Exists("D:/ArchiveFiles_ListZipStreamConfig_true_2.zip"));

        //    using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
        //    Assert.True(File.Exists("D:/extract/test.txt"));


        //}

        //[Test]
        //public void Test_ArchiveFiles_ListZipStreamConfig_false()
        //{
        //    var fileStream = File.Create("D:/New folder{}/test.txt");

        //    List<ZipStreamConfig> zipFileConfigs = new List<ZipStreamConfig>() { new ZipStreamConfig(fileStream, "test.txt") };

        //    Assert.False(ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/"));
        //    Assert.NotNull(ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/"));

        //    Assert.That(ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/"), Is.Not.Null);
        //    Assert.That(!ArchivingServicess.ArchiveFiles(zipFileConfigs, "D:/"));

        //    Assert.False(File.Exists("D:ArchiveFiles_ListZipStreamConfig_true_1.zip") && File.Exists("D:/ArchiveFiles_ListZipStreamConfig_true_2.zip"));
        //    Assert.False(File.Exists("D:/extract/test.txt"));

        //}

        //#endregion

        //#region ArchiveFile_ZipStreamConfig
        //[Test]
        //public void Test_ArchiveFile_ZipStreamConfig_true()
        //{
        //    var fileStream = File.Create("D:/New folder{}/test.txt");

        //    ZipStreamConfig zipFileConfigs = new ZipStreamConfig(fileStream, "test.txt");

        //    Assert.IsTrue(ArchivingServicess.ArchiveFile(zipFileConfigs, "D:/ArchiveFile_ZipStreamConfig_true_1.zip"));
        //    Assert.That(ArchivingServicess.ArchiveFile(zipFileConfigs, "D:/ArchiveFile_ZipStreamConfig_true_2.zip"));

        //    string zipPath = @"D:/ArchiveFile_ZipStreamConfig_true_1.zip";
        //    string extractPath = @"D:/extract";

        //    Assert.True(File.Exists("D:/ArchiveFile_ZipStreamConfig_true_1.zip") && File.Exists("D:/ArchiveFile_ZipStreamConfig_true_2.zip"));

        //    using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
        //    Assert.True(File.Exists("D:/extract/test.txt"));
        //}

        //[Test]
        //public void Test_ArchiveFile_ZipStreamConfig_false()
        //{
        //    var fileStream = File.Create("D:/New folder{}/test.txt");

        //    ZipStreamConfig zipFileConfigs = new ZipStreamConfig(fileStream, "test.txt");

        //    Assert.False(ArchivingServicess.ArchiveFile(zipFileConfigs, "D:/"));
        //    Assert.NotNull(ArchivingServicess.ArchiveFile(zipFileConfigs, "D:/"));

        //    Assert.That(ArchivingServicess.ArchiveFile(zipFileConfigs, "D:/"), Is.Not.Null);
        //    Assert.That(!ArchivingServicess.ArchiveFile(zipFileConfigs, "D:/"));

        //    Assert.False(File.Exists("D:/ArchiveFile_ZipStreamConfig_true_1.zip") && File.Exists("D:/ArchiveFile_ZipStreamConfig_true_2.zip"));
        //    Assert.False(File.Exists("D:/extract/test.txt"));
        //}

        //#endregion

        //#region ArchiveFile_3String

        //[Test]
        //public void Test_ArchiveFile_3String_true()
        //{
        //    var fileStream = File.Create("D:/New folder{}/test.txt");

        //    Assert.IsTrue(ArchivingServicess.ArchiveFile("test2.txt", fileStream, "D:/ArchiveFile_3String_true_1.zip"));
        //    Assert.That(ArchivingServicess.ArchiveFile("test2.txt", fileStream, "D:/ArchiveFile_3String_true_2.zip"));

        //    string zipPath = @"D:/ArchiveFile_3String_true_1.zip";
        //    string extractPath = @"D:/extract";

        //    Assert.True(File.Exists("D:/ArchiveFile_3String_true_1.zip") && File.Exists("D:/ArchiveFile_3String_true_2.zip"));

        //    using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
        //    Assert.True(File.Exists("D:/extract/test2.txt"));

        //}

        //[Test]
        //public void Test_ArchiveFile_3String_false()
        //{
        //    var fileStream = File.Create("D:/New folder{}/test.txt");

        //    Assert.False(ArchivingServicess.ArchiveFile("", fileStream, "D:/"));
        //    Assert.NotNull(ArchivingServicess.ArchiveFile("", fileStream, "D:/"));

        //    Assert.That(ArchivingServicess.ArchiveFile("", fileStream, "D:/"), Is.Not.Null);
        //    Assert.That(!ArchivingServicess.ArchiveFile("", fileStream, "D:/"));

        //    Assert.False(File.Exists("D:/ArchiveFile_3String_true_1.zip") && File.Exists("D:/ArchiveFile_3String_true_2.zip"));
        //    Assert.False(File.Exists("D:/extract/test2.txt"));
        //}

        //#endregion

        //#region ArchiveFilesAsync

        //[Test]
        //public async Task Test_ArchiveFilesAsync_true()
        //{
        //    var fileStream = File.Create("D:/New folder{}/test.txt");

        //    List<ZipStreamConfig> zipFileConfigs = new List<ZipStreamConfig>() { new ZipStreamConfig(fileStream, "test.txt") };

        //    Assert.IsTrue(await ArchivingServicess.ArchiveFilesAsync(zipFileConfigs, "D:/Test_ArchiveFilesAsync_true_1.zip"));
        //    Assert.That(await ArchivingServicess.ArchiveFilesAsync(zipFileConfigs, "D:/Test_ArchiveFilesAsync_true_2.zip"));

        //    string zipPath = @"D:/Test_ArchiveFilesAsync_true_1.zip";
        //    string extractPath = @"D:/extract";

        //    Assert.True(File.Exists("D:/Test_ArchiveFilesAsync_true_1.zip") && File.Exists("D:/Test_ArchiveFilesAsync_true_2.zip"));

        //    using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
        //    Assert.True(File.Exists("D:/extract/test.txt"));
        //}

        //[Test]
        //public async Task Test_ArchiveFilesAsync_false()
        //{
        //    var fileStream = File.Create("D:/New folder{}/test.txt");

        //    List<ZipStreamConfig> zipFileConfigs = new List<ZipStreamConfig>() { new ZipStreamConfig(fileStream, "test.txt") };

        //    Assert.False(await ArchivingServicess.ArchiveFilesAsync(zipFileConfigs, "D:/"));
        //    Assert.NotNull(await ArchivingServicess.ArchiveFilesAsync(zipFileConfigs, "D:/"));

        //    Assert.That(await ArchivingServicess.ArchiveFilesAsync(zipFileConfigs, "D:/"), Is.Not.Null);
        //    Assert.That(!await ArchivingServicess.ArchiveFilesAsync(zipFileConfigs, "D:/"));

        //    Assert.False(File.Exists("D:/Test_ArchiveFilesAsync_true_1.zip") && File.Exists("D:/Test_ArchiveFilesAsync_true_2.zip"));
        //    Assert.False(File.Exists("D:/extract/test.txt"));
        //}

        //#endregion

        //#region ArchiveFilesAsync
        //[Test]
        //public async Task Test_ArchiveFilesAsync_class_true()
        //{
        //    var fileStream = File.Create("D:/New folder{}/test.txt");

        //    ZipStreamConfig zipFileConfigs = new ZipStreamConfig(fileStream, "test.txt");

        //    Assert.IsTrue(await ArchivingServicess.ArchiveFileAsync(zipFileConfigs, "D:/Test_ArchiveFilesAsync_class_true_1.zip"));
        //    Assert.That(await ArchivingServicess.ArchiveFileAsync(zipFileConfigs, "D:/Test_ArchiveFilesAsync_class_true_2.zip"));

        //    string zipPath = @"D:/Test_ArchiveFilesAsync_class_true_1.zip";
        //    string extractPath = @"D:/extract";

        //    Assert.True(File.Exists("D:/Test_ArchiveFilesAsync_class_true_1.zip") && File.Exists("D:/Test_ArchiveFilesAsync_class_true_2.zip"));

        //    using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
        //    Assert.True(File.Exists("D:/extract/test.txt"));

        //}

        //[Test]
        //public async Task Test_ArchiveFilesAsync_class_false()
        //{
        //    var fileStream = File.Create("D:/New folder{}/test.txt");

        //    ZipStreamConfig zipFileConfigs = new ZipStreamConfig(fileStream, "test.txt");

        //    Assert.False(await ArchivingServicess.ArchiveFileAsync(zipFileConfigs, "D:/"));
        //    Assert.NotNull(await ArchivingServicess.ArchiveFileAsync(zipFileConfigs, "D:/"));

        //    Assert.That(await ArchivingServicess.ArchiveFileAsync(zipFileConfigs, "D:/"), Is.Not.Null);
        //    Assert.That(!await ArchivingServicess.ArchiveFileAsync(zipFileConfigs, "D:/"));

        //    Assert.False(File.Exists("D:/Test_ArchiveFilesAsync_class_true_1.zip") && File.Exists("D:/Test_ArchiveFilesAsync_class_true_2.zip"));
        //    Assert.False(File.Exists("D:/extract/test.txt"));
        //}
        //#endregion

        //#region ArchiveFilesAsync
        //[Test]
        //public async Task Test_ArchiveFilesAsync_3string_true()
        //{
        //    var fileStream = File.Create("D:/New folder{}/test.txt");

        //    Assert.IsTrue(await ArchivingServicess.ArchiveFileAsync("test.txt", fileStream, "D:/Test_ArchiveFilesAsync_3string_true_1.zip"));
        //    Assert.That(await ArchivingServicess.ArchiveFileAsync("test.txt", fileStream, "D:/Test_ArchiveFilesAsync_3string_true_2.zip"));

        //    string zipPath = @"D:/Test_ArchiveFilesAsync_3string_true_1.zip";
        //    string extractPath = @"D:/extract";

        //    Assert.True(File.Exists("D:/Test_ArchiveFilesAsync_3string_true_1.zip") && File.Exists("D:/Test_ArchiveFilesAsync_3string_true_2.zip"));

        //    using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
        //    Assert.True(File.Exists("D:/extract/test.txt"));

        //}

        //[Test]
        //public async Task Test_ArchiveFilesAsync_3string_false()
        //{
        //    var fileStream = File.Create("D:/New folder{}/test.txt");

        //    Assert.False(await ArchivingServicess.ArchiveFileAsync("test.txt", fileStream, "D:/"));
        //    Assert.NotNull(await ArchivingServicess.ArchiveFileAsync("test.txt", fileStream, "D:/"));

        //    Assert.That(await ArchivingServicess.ArchiveFileAsync("test.txt", fileStream, "D:/"), Is.Not.Null);
        //    Assert.That(!await ArchivingServicess.ArchiveFileAsync("test.txt", fileStream, "D:/"));

        //    Assert.False(File.Exists("D:/Test_ArchiveFilesAsync_3string_true_1.zip") && File.Exists("D:/Test_ArchiveFilesAsync_3string_true_2.zip"));
        //    Assert.False(File.Exists("D:/extract/test.txt"));
        //}
        //#endregion

        //#region ArchiveFilesStream

        //[Test]
        //public void Test_ArchiveFilesStream_true()
        //{
        //    byte[] byteArray = Encoding.ASCII.GetBytes("test.txt");
        //    MemoryStream stream = new MemoryStream(byteArray);

        //    Dictionary<string, Stream> dic = new Dictionary<string, Stream>() { };
        //    dic.Add("test.txt", stream);

        //    Assert.IsTrue(ArchivingServicess.ArchiveFilesStream(dic, "D:/ArchiveFilesStream_true_1.zip"));

        //    string zipPath = @"D:/ArchiveFilesStream_true_1.zip";
        //    string extractPath = @"D:/extract";

        //    Assert.True(File.Exists("D:/ArchiveFilesStream_true_1.zip"));

        //    using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
        //    Assert.True(File.Exists("D:/extract/test.txt"));

        //}

        //[Test]
        //public void Test_ArchiveFilesStream_false()
        //{
        //    var fileStream = File.Create("D:/New folder{}/.txt");

        //    Dictionary<string, Stream> dic = new Dictionary<string, Stream>() { };
        //    dic.Add("test.txt", fileStream);

        //    Assert.False(ArchivingServicess.ArchiveFilesStream(dic, "D:/"));
        //    Assert.NotNull(ArchivingServicess.ArchiveFilesStream(dic, "D:/"));

        //    Assert.That(ArchivingServicess.ArchiveFilesStream(dic, "D:/"), Is.Not.Null);
        //    Assert.That(!ArchivingServicess.ArchiveFilesStream(dic, "D:/"));

        //    Assert.False(File.Exists("D:/ArchiveFilesStream_true_1.zip") && File.Exists("D:/ArchiveFilesStream_true_2.zip"));
        //    Assert.False(File.Exists("D:/extract/test.txt"));
        //}


        //#endregion

        //#region ArchiveFilesStreamAsync

        //[Test]
        //public async Task Test_ArchiveFilesStreamAsync_true()
        //{

        //    byte[] byteArray = Encoding.ASCII.GetBytes("test.txt");
        //    MemoryStream stream = new MemoryStream(byteArray);

        //    Dictionary<string, Stream> dic = new Dictionary<string, Stream>() { };
        //    dic.Add("test.txt", stream);

        //    Assert.IsTrue(await ArchivingServicess.ArchiveFilesStreamAsync(dic, "D:/ArchiveFilesStream_true_1.zip"));

        //    string zipPath = @"D:/ArchiveFilesStream_true_1.zip";
        //    string extractPath = @"D:/extract";

        //    Assert.True(File.Exists("D:/ArchiveFilesStream_true_1.zip"));

        //    using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)) { archive.ExtractToDirectory(extractPath); }
        //    Assert.True(File.Exists("D:/extract/test.txt"));

        //}

        //[Test]
        //public async Task Test_ArchiveFilesStreamAsync_false()
        //{
        //    var fileStream = File.Create("D:/New folder{}/.txt");

        //    Dictionary<string, Stream> dic = new Dictionary<string, Stream>() { };
        //    dic.Add("test.txt", fileStream);

        //    Assert.False(await ArchivingServicess.ArchiveFilesStreamAsync(dic, "D:/"));
        //    Assert.NotNull(await ArchivingServicess.ArchiveFilesStreamAsync(dic, "D:/"));

        //    Assert.That(await ArchivingServicess.ArchiveFilesStreamAsync(dic, "D:/"), Is.Not.Null);
        //    Assert.That(!await ArchivingServicess.ArchiveFilesStreamAsync(dic, "D:/"));

        //    Assert.False(File.Exists("D:/ArchiveFilesStream_true_1.zip") && File.Exists("D:/ArchiveFilesStream_true_2.zip"));
        //    Assert.False(File.Exists("D:/extract/test.txt"));
        //}

        //#endregion 

        #endregion

        #region Stream

        #region ArchiveFilesInRootFolder

        string testFile1Name = "testFile1.txt";
        string testFile2Name = "testFile2.txt";

        [Test]
        public void Test_ArchiveFilesInRootFolder_Memorystream()
        {
            MemoryStream memoryStream1 = new MemoryStream(ArchivingServicess.ArchiveFilesInRootFolder(filePathsSameNames).ToArray());
            ZipArchive Archive1 = new ZipArchive(memoryStream1);
            Assert.AreEqual(fileName, Archive1.Entries[0].FullName);
            Assert.AreEqual("test - Copy (1).txt", Archive1.Entries[1].FullName);
        }
        #endregion

        #region ArchiveSingleFileInRootFolder
        [Test]
        public void Test_ArchiveSingleFileInRootFolder_MemoryStream()
        {
            MemoryStream memoryStream1 = new MemoryStream(ArchivingServicess.ArchiveSingleFileInRootFolder(testFilePath).ToArray());
            ZipArchive Archive1 = new ZipArchive(memoryStream1);
            Assert.AreEqual(fileName, Archive1.Entries[0].FullName);
        }
        #endregion

        #region ArchiveFiles_List<ZipFileConfig>
        [Test]
        public void Test_ArchiveFiles_MemoryStream()
        {

            List<ZipFileConfig> zipFileConfigss = new List<ZipFileConfig>() {new ZipFileConfig(testFilePath, fileName) };
            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ArchiveFiles(zipFileConfigss).ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.AreEqual(fileName, Archive.Entries[0].FullName);
        }
        #endregion

        #region ArchiveSingleFile_ZipFileConfig
        [Test]
        public void Test_ArchiveSingleFile_MemoryStream()
        {
            ZipFileConfig zipFileConfigs = new ZipFileConfig(testFilePath, "new/test.txt");
            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ArchiveSingleFile(zipFileConfigs).ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.AreEqual("new/test.txt", Archive.Entries[0].FullName);
        }

        #endregion

        #region ArchiveFiles

        [Test]
        public void Test_ArchiveFile_MemoryStream()
        {
            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ArchiveFile(testFilePath, "new/test.txt").ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.AreEqual("new/test.txt", Archive.Entries[0].FullName);
        }
        #endregion

        #region ArchiveStreamFiles
        [Test]
        public void Test_MemoryStream_Dic_MemoryStream()
        {

            Dictionary<string, string> dic = new Dictionary<string, string>() { { testFilePath, fileName } };
            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ArchiveFiles(dic).ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.AreEqual(fileName, Archive.Entries[0].FullName);
        }

        #endregion

        #region ArchiveFiles
        [Test]
        public void Test_ArchiveFiles_Dic_MemoryStream()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>() { { testFilePath, fileName } };
            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ArchiveFiles(dic).ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.AreEqual("test.txt", Archive.Entries[0].FullName);
        }
        #endregion

        #region ArchiveFiles_List<ZipStreamConfig>

        [Test]
        public void Test_ArchiveFiles_ListZipStreamConfig_MemoryStream()
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(fileName);
            MemoryStream stream = new MemoryStream(byteArray);
            List<ZipStreamConfig> zipFileConfigs = new List<ZipStreamConfig>() { new ZipStreamConfig(stream, fileName) };
            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ArchiveFiles(zipFileConfigs).ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.AreEqual(fileName, Archive.Entries[0].FullName);
        }
        #endregion

        #region ArchiveFile_ZipStreamConfig
        [Test]
        public void Test_ArchiveFile_ZipStreamConfig_MemoryStream()
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(fileName);
            MemoryStream stream = new MemoryStream(byteArray);
            ZipStreamConfig zipFileConfigs = new ZipStreamConfig(stream, fileName);
            MemoryStream memoryStream2 = new MemoryStream(ArchivingServicess.ArchiveFile(zipFileConfigs).ToArray());
            ZipArchive Archive2 = new ZipArchive(memoryStream2);
            Assert.AreEqual(fileName, Archive2.Entries[0].FullName);

        }

        #endregion

        #region ArchiveFile_3String
        [Test]
        public void Test_ArchiveFile_3String_MemoryStream()
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(fileName);
            MemoryStream stream = new MemoryStream(byteArray);
            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ArchiveFile(fileName, stream).ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.AreEqual(fileName, Archive.Entries[0].FullName);
        }
        #endregion

        #region ExtractArchive

        [Test]
        public void Test_Extract_Archive() 
        {
            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ExtractArchive(archivePath).ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.AreEqual(fileName, Archive.Entries[0].FullName);
            Assert.AreEqual("test - Copy (1).txt", Archive.Entries[1].FullName);
        }


        #endregion

        #region ExtractParticularFileFromArchive

        [Test]
        public void Test_Extract_Particular_File()
        {
            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ExtractParticularFile(archivePath, fileName).ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.AreEqual(fileName, Archive.Entries[0].FullName);
        }


        #endregion



        #region Mohamed
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
            ArchivingServicess.AddfilesToExistArchive(inputPath, filePaths);
            FileStream fileArchived = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            MemoryStream archivedFileStream = new MemoryStream();
            fileArchived.CopyTo(archivedFileStream);
            ZipArchive archive = new ZipArchive(archivedFileStream);
            foreach (var item in filePaths)
            {
                Assert.That(archive.Entries.Any(f => f.Name == Path.GetFileName(item)));
            }
        }
        #endregion
        #region DeflateCompression
        [Test]
        public void DecompressMemoryStreamWithDeflate_WhenCalled_returnCompressedStream()
        {
            string fileTest1 = "test1.txt";
            string filename = @"..\..\..\..\Testing\Input\" + fileTest1;
            var filestream = File.Open(filename, FileMode.Open);
            var fileMemStream = new MemoryStream();
            filestream.CopyTo(fileMemStream);
            var CompressedStream = ArchivingServicess.CompressMemoryStreamWithDeflate(fileMemStream);
            var DecompressedStream = ArchivingServicess.DecompressMemoryStreamWithDeflate(CompressedStream);
            var DecomStream = new MemoryStream(DecompressedStream.ToArray());
            bool test=false;
            if (fileMemStream.Length== DecomStream.Length)
            {
                var physicalBytesForFile = fileMemStream.ToArray();
                var BytesForStream = DecomStream.ToArray();
                for (int i = 0; i < physicalBytesForFile?.Length; i++)
                {
                    if (physicalBytesForFile[i] == BytesForStream[i])
                        test = true;
                    else
                    {
                        test = false;
                        break;
                    }
                }
            }
            Assert.That(test, Is.True);
        }
        #endregion
        #endregion



        #endregion

        #region FileComparer

        private bool FileCompare(string file1, string file2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            // Determine if the same file was referenced two times.
            if (file1 == file2)
            {
                // Return true to indicate that the files are the same.
                return true;
            }

            // Open the two files.
            fs1 = new FileStream(file1, FileMode.Open);
            fs2 = new FileStream(file2, FileMode.Open);

            // Check the file sizes. If they are not the same, the files
            // are not the same.
            if (fs1.Length != fs2.Length)
            {
                // Close the file
                fs1.Close();
                fs2.Close();

                // Return false to indicate files are different
                return false;
            }

            // Read and compare a byte from each file until either a
            // non-matching set of bytes is found or until the end of
            // file1 is reached.
            do
            {
                // Read one byte from each file.
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            // Close the files.
            fs1.Close();
            fs2.Close();

            // Return the success of the comparison. "file1byte" is
            // equal to "file2byte" at this point only if the files are
            // the same.
            return ((file1byte - file2byte) == 0);
        }
        #region Extract_Archive_Flat_Directory
        [Test]
        public void Test_Extract_Archive_Flat_Directory()
        {
            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.extractArchiveFlatDirectory(archivePath).ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);

            Assert.AreEqual("test - Copy (1).txt", Archive.Entries[1].Name);
            Assert.AreEqual(fileName, Archive.Entries[0].Name);

        } 
        #endregion
        #endregion
    }

}
