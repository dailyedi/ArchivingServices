using ArchivingServices;
using ArchivingServices.Structure;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace TestProject1
{
    public class Tests
    {

        
        string pattern, pathdir, extract, pathdirplates, extractplates, pathdirPattern, pathdirPattern1, pathdirPatternextract, pathdirPatternextract1;
        Regex rgx;
        [SetUp]
        public void SetUp()
        {
            pathdir = @"C:\Users\Mohamed_Reda\source\repos\ArchivingServices\TestProject1\Testing\TestDir";
            extract = @"C:\Users\Mohamed_Reda\source\repos\ArchivingServices\TestProject1\Testing\Extract";
            pathdirplates = @"C:\Users\Mohamed_Reda\source\repos\ArchivingServices\TestProject1\Testing\TestDirPlates";
            extractplates = @"C:\Users\Mohamed_Reda\source\repos\ArchivingServices\TestProject1\Testing\ExtractPlates";
            pathdirPattern = @"C:\Users\Mohamed_Reda\source\repos\ArchivingServices\TestProject1\Testing\TestDirWithPattern";
            pathdirPattern1 = @"C:\Users\Mohamed_Reda\source\repos\ArchivingServices\TestProject1\Testing\TestDirWithPattern1";
            pathdirPatternextract = @"C:\Users\Mohamed_Reda\source\repos\ArchivingServices\TestProject1\Testing\pathdirPatternextract";
            pathdirPatternextract1 = @"C:\Users\Mohamed_Reda\source\repos\ArchivingServices\TestProject1\Testing\pathdirPatternextract1";
            pattern = "file[0-9]{2}";
        }
        #region ArchiveFilesInRootFolder

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
        [Test]
        public void Test_ArchiveFilesInRootFolder_Memorystream()
        {
            List<string> y = new List<string>() { "D:/New folder{}/test.txt", "D:/test.txt" };
            MemoryStream memoryStream1 = new MemoryStream(ArchivingServicess.ArchiveFilesInRootFolder(y).ToArray());
            ZipArchive Archive1 = new ZipArchive(memoryStream1);
            Assert.AreEqual("test.txt", Archive1.Entries[0].FullName);
            Assert.AreEqual("test - Copy (1).txt", Archive1.Entries[1].FullName);
        }
        #endregion

        #region ArchiveSingleFileInRootFolder
        [Test]
        public void Test_ArchiveSingleFileInRootFolder_MemoryStream()
        {
            MemoryStream memoryStream1 = new MemoryStream(ArchivingServicess.ArchiveSingleFileInRootFolder("D:/New folder{}/test.txt").ToArray());
            ZipArchive Archive1 = new ZipArchive(memoryStream1);
            Assert.AreEqual("test.txt", Archive1.Entries[0].FullName);
        }
        #endregion

        #region ArchiveFiles_List<ZipFileConfig>
        [Test]
        public void Test_ArchiveFiles_MemoryStream()
        {

            List<ZipFileConfig> zipFileConfigss = new List<ZipFileConfig>() { new ZipFileConfig("D:/New folder{}/test.txt", "test.txt") };
            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ArchiveFiles(zipFileConfigss).ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.AreEqual("test.txt", Archive.Entries[0].FullName);
        }
        #endregion

        #region ArchiveSingleFile_ZipFileConfig
        [Test]
        public void Test_ArchiveSingleFile_MemoryStream()
        {
            ZipFileConfig zipFileConfigs = new ZipFileConfig("D:/New folder{}/test.txt", "new/test.txt");
            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ArchiveSingleFile(zipFileConfigs).ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.AreEqual("new/test.txt", Archive.Entries[0].FullName);
        }

        #endregion

        #region ArchiveFiles

        [Test]
        public void Test_ArchiveFile_MemoryStream()
        {
            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ArchiveFile("D:/New folder{}/test.txt", "new/test.txt").ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.AreEqual("new/test.txt", Archive.Entries[0].FullName);
        }
        #endregion

        #region ArchiveStreamFiles
        [Test]
        public void Test_MemoryStream_Dic_MemoryStream()
        {

            Dictionary<string, string> dic = new Dictionary<string, string>() { { "D:/New folder{}/test.txt", "test.txt" } };
            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ArchiveFiles(dic).ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.AreEqual("test.txt", Archive.Entries[0].FullName);
        }

        #endregion

        #region ArchiveFiles
        [Test]
        public void Test_ArchiveFiles_Dic_MemoryStream()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>() { { "D:/New folder{}/test.txt", "test.txt" } };
            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ArchiveFiles(dic).ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.AreEqual("test.txt", Archive.Entries[0].FullName);
        }
        #endregion

        #region ArchiveFiles_List<ZipStreamConfig>

        [Test]
        public void Test_ArchiveFiles_ListZipStreamConfig_MemoryStream()
        {
            byte[] byteArray = Encoding.ASCII.GetBytes("test.txt");
            MemoryStream stream = new MemoryStream(byteArray);
            List<ZipStreamConfig> zipFileConfigs = new List<ZipStreamConfig>() { new ZipStreamConfig(stream, "test.txt") };
            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ArchiveFiles(zipFileConfigs).ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.AreEqual("test.txt", Archive.Entries[0].FullName);
        }
        #endregion

        #region ArchiveFile_ZipStreamConfig
        [Test]
        public void Test_ArchiveFile_ZipStreamConfig_MemoryStream()
        {
            byte[] byteArray = Encoding.ASCII.GetBytes("test.txt");
            MemoryStream stream = new MemoryStream(byteArray);
            ZipStreamConfig zipFileConfigs = new ZipStreamConfig(stream, "test.txt");
            MemoryStream memoryStream2 = new MemoryStream(ArchivingServicess.ArchiveFile(zipFileConfigs).ToArray());
            ZipArchive Archive2 = new ZipArchive(memoryStream2);
            Assert.AreEqual("test.txt", Archive2.Entries[0].FullName);

        }

        #endregion

        #region ArchiveFile_3String
        [Test]
        public void Test_ArchiveFile_3String_MemoryStream()
        {
            byte[] byteArray = Encoding.ASCII.GetBytes("test.txt");
            MemoryStream stream = new MemoryStream(byteArray);
            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ArchiveFile("test.txt", stream).ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.AreEqual("test.txt", Archive.Entries[0].FullName);
        }
        #endregion

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


        //#endregion
        #region ArchiveFilesStream

        [Test]
        public void Test_ArchiveFilesStream_MemoryStream()
        {
            byte[] byteArray = Encoding.ASCII.GetBytes("test.txt");
            MemoryStream stream = new MemoryStream(byteArray);

            Dictionary<string, Stream> dic = new Dictionary<string, Stream>() { };
            dic.Add("test.txt", stream);
            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ArchiveFilesStream(dic).ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.AreEqual("test.txt", Archive.Entries[0].FullName);
        }


        #endregion



        #region TestingArchivingDirectory
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ArchiveDirectory_whenCalled_SavedArchivedDirectory(bool allowedFlates)
        {
            ArchivingServicess.ArchiveDirectory(pathdir, allowedFlates);
            ZipFile.ExtractToDirectory(pathdir + ".zip", extract, overwriteFiles: true);
            var result = Directory.GetFiles(extract);
            Assert.That(Path.GetFileName(result[0]), Is.EqualTo("testFile.txt"));
        }
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ArchiveDirectoryAsync_whenCalled_SavedArchivedDirectory(bool allowedFlates)
        {
            await ArchivingServicess.ArchiveDirectoryAsync(pathdir, allowedFlates);
            ZipFile.ExtractToDirectory(pathdir + ".zip", extract, overwriteFiles: true);
            var result = Directory.GetFiles(extract);
            Assert.That(Path.GetFileName(result[0]), Is.EqualTo("testFile.txt"));
        }
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ArchiveDirectoryStream_whenCalled_ReturnStream(bool allowedFlates)
        {
            var result = ArchivingServicess.ArchiveDirectoryStream(pathdir, allowedFlates);
            MemoryStream memoryStream = new MemoryStream(result.ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.That(Archive.Entries[0].FullName, Is.EqualTo("testFile.txt"));
        }
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ArchiveDirectoryStreamAsync_whenCalled_ReturnStream(bool allowedFlates)
        {
            var result = await ArchivingServicess.ArchiveDirectoryStreamAsync(pathdir, allowedFlates);
            MemoryStream memoryStream = new MemoryStream(result.ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.That(Archive.Entries[0].FullName, Is.EqualTo("testFile.txt"));
        }


        #endregion
        #region TestingArchivingDirectoryFlats
        [Test]
        public void ArchiveDirectoryFlates_whenCalled_SavedArchivedDirectory()
        {
            ArchivingServicess.ArchiveDirectoryFlates(pathdirplates);
            ZipFile.ExtractToDirectory(pathdirplates + ".zip", extractplates, overwriteFiles: true);
            var result = Directory.GetFiles(extractplates);
            Assert.That(Path.GetFileName(result[0]), Is.EqualTo("testFile.txt"));
        }
        [Test]
        public async Task ArchiveDirectoryFlatesAsync_whenCalled_SavedArchivedDirectory()
        {
            await ArchivingServicess.ArchiveDirectoryFlatesAsync(pathdirplates);
            ZipFile.ExtractToDirectory(pathdirplates + ".zip", extractplates, overwriteFiles: true);
            var result = Directory.GetFiles(extractplates);
            Assert.That(Path.GetFileName(result[0]), Is.EqualTo("testFile.txt"));
        }
        [Test]
        public void ArchiveDirectoryFlatesStream_whenCalled_ReturnStream()
        {
            var result = ArchivingServicess.ArchiveDirectoryFlatesStream(pathdirplates);
            MemoryStream memoryStream = new MemoryStream(result.ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.That(Archive.Entries[0].FullName, Is.EqualTo("testFile.txt"));
        }
        [Test]
        public async Task ArchiveDirectoryFlatesStreamAsync_whenCalled_ReturnStream()
        {
            var result = await ArchivingServicess.ArchiveDirectoryFlatesStreamAsync(pathdirplates);
            MemoryStream memoryStream = new MemoryStream(result.ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.That(Archive.Entries[0].FullName, Is.EqualTo("testFile.txt"));
        }
        #endregion
        #region TestingArchivingDirectorywithPattern
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ArchiveDirectoryWithPattern_whenCalled_SavedArchivedDirectoryWithRegEx(bool allowedflates)
        {
            ArchivingServicess.ArchiveDirectoryWithPattern(pathdirPattern1, SearchPattern.RegEx, pattern, allowedflates);
            ZipFile.ExtractToDirectory(pathdirPattern1 + ".zip", pathdirPatternextract, overwriteFiles: true);
            var result = Directory.GetFiles(pathdirPatternextract);
            Assert.That(Path.GetFileName(result[0]), Is.EqualTo("file54.txt"));
        }
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ArchiveDirectoryWithPatternAsync_whenCalled_SavedArchivedDirectoryWithRegEx(bool allowedflates)
        {
            await ArchivingServicess.ArchiveDirectoryWithPatternAsync(pathdirPattern1, SearchPattern.RegEx, pattern, allowedflates);
            ZipFile.ExtractToDirectory(pathdirPattern1 + ".zip", pathdirPatternextract, overwriteFiles: true);
            var result = Directory.GetFiles(pathdirPatternextract);
            Assert.That(Path.GetFileName(result[0]), Is.EqualTo("file54.txt"));
        }
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ArchiveDirectoryWithPattern_whenCalled_SavedArchivedDirectoryWithWildCard(bool allowedflates)
        {
            ArchivingServicess.ArchiveDirectoryWithPattern(pathdirPattern, SearchPattern.WildCard, "?test.*", allowedflates);
            ZipFile.ExtractToDirectory(pathdirPattern + ".zip", pathdirPatternextract1, overwriteFiles: true);
            var result = Directory.GetFiles(pathdirPatternextract1);
            Assert.That(Path.GetFileName(result[0]), Is.EqualTo("dtest.txt"));
        }
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ArchiveDirectoryWithPatternAsync_whenCalled_SavedArchivedDirectoryWithWildCard(bool allowedflates)
        {
            await ArchivingServicess.ArchiveDirectoryWithPatternAsync(pathdirPattern, SearchPattern.WildCard, "?test.*", allowedflates);
            ZipFile.ExtractToDirectory(pathdirPattern + ".zip", pathdirPatternextract1, overwriteFiles: true);
            var result = Directory.GetFiles(pathdirPatternextract1);
            Assert.That(Path.GetFileName(result[0]), Is.EqualTo("dtest.txt"));
        }
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ArchiveDirectoryWithPatternStream_whenCalled_ReturnStreamWithRegx(bool allowedflates)
        {
            var result = ArchivingServicess.ArchiveDirectoryWithPatternStream(pathdirPattern1, SearchPattern.RegEx, pattern, allowedflates);
            MemoryStream memoryStream = new MemoryStream(result.ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.That(Archive.Entries[0].FullName, Is.EqualTo("file56.txt"));
        }
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ArchiveDirectoryWithPatternStreamAsync_whenCalled_ReturnStreamWithRegx(bool allowedflates)
        {
            var result = await ArchivingServicess.ArchiveDirectoryWithPatternStreamAsync(pathdirPattern1, SearchPattern.RegEx, pattern, allowedflates);
            MemoryStream memoryStream = new MemoryStream(result.ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.That(Archive.Entries[0].FullName, Is.EqualTo("file56.txt"));
        }
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ArchiveDirectoryWithPatternStream_whenCalled_ReturnStreamWithWildCard(bool allowedflates)
        {
            var result = ArchivingServicess.ArchiveDirectoryWithPatternStream(pathdirPattern1, SearchPattern.WildCard, "?test.*", allowedflates);
            MemoryStream memoryStream = new MemoryStream(result.ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.That(Archive.Entries[0].FullName, Is.EqualTo("ptest.pptx"));
        }
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ArchiveDirectoryWithPatternStreamAsync_whenCalled_ReturnStreamWithWildCard(bool allowedflates)
        {
            var result = await ArchivingServicess.ArchiveDirectoryWithPatternStreamAsync(pathdirPattern1, SearchPattern.WildCard, "?test.*", allowedflates);
            MemoryStream memoryStream = new MemoryStream(result.ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);
            Assert.That(Archive.Entries[0].FullName, Is.EqualTo("ptest.pptx"));
        }

        #endregion

        #endregion
    }
}
