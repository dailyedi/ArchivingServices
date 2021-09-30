using ArchivingServices;
using ArchivingServices.Structure;
using NUnit.Framework;
using SharpCompress.Archives.Rar;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace TestProject1
{
    public class Tests
    {
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
        [Test]
        public void Test_ArchiveFilesInRootFolder_Memorystream()
        {
            string fileName1 = "test.txt", fileName2 = "test - Copy (1).txt";
            List<string> pathsSameName = new() { @"..\..\..\..\Testing\Input\test.txt", @"..\..\..\..\Testing\test.txt" };

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
           string testFilePath = @"..\..\..\..\Testing\Input\test.txt" , fileName = "test.txt";

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
            List<ZipFileConfig> zipFileConfig = new() {new ZipFileConfig(testFilePath, fileName) };

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
            MemoryStream stream = new (byteArray);
            List<ZipStreamConfig> zipFileConfigs = new(){ new ZipStreamConfig(stream, fileName) };

            stream = new (ArchivingServicess.ArchiveFiles(zipFileConfigs).ToArray());
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
            MemoryStream stream = new (byteArray);
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
            string fileName1 = "test.txt" , fileName2 = "test - Copy (1).txt" , archivePath = @"..\..\..\..\Testing\Input\ArchiveFilesInRootFolder_true_1.zip";

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
            string fileName = "test.txt", archivePath = @"..\..\..\..\Testing\Input\ArchiveFilesInRootFolder_true_1.zip";

            MemoryStream memoryStream = new MemoryStream(ArchivingServicess.ExtractParticularFile(archivePath, fileName).ToArray());
            ZipArchive Archive = new ZipArchive(memoryStream);

            Assert.IsNotNull(memoryStream);
            Assert.AreEqual(1, Archive.Entries.Count);
            Assert.AreEqual(fileName, Archive.Entries[0].Name);
        }


        #endregion

        #region Extract_Archive_Flat_Directory
        [Test]
        public void Test_Extract_Archive_Flat_Directory()
        {
            string fileName1 = "test.txt", fileName2 = "test - Copy (1).txt", archivePath = @"..\..\..\..\Testing\Input\ArchiveFilesInRootFolder_true_1.zip";

            MemoryStream memoryStream = new(ArchivingServicess.ExtractArchiveFlatDirectory(archivePath).ToArray());
            ZipArchive Archive = new(memoryStream);

            Assert.IsNotNull(memoryStream);
            Assert.AreEqual(2, Archive.Entries.Count);
            Assert.AreEqual(fileName2, Archive.Entries[1].Name);
            Assert.AreEqual(fileName1, Archive.Entries[0].Name);

        }
        #endregion

        #region test_Archive_Rar

        [Test]
        public void test_Archive_Rar_Files()
        {
            var index = 0;
            var rarPath = "D:/testRAR.rar";
            var filesCollection = new List<string> { "D:/New folder{}/test.txt" , "D:/New folder{}/New folder/test2.txt" };

            Assert.IsTrue(ArchivingServicess.ArchiveRarFiles(rarPath, filesCollection));
            RarArchive archive = RarArchive.Open(rarPath);

            foreach (var item in archive.Entries) { Assert.IsTrue(filesCollection[index].Contains(item.Key));index += 1; }
        }

        #endregion

        #region Extract_Rar_Archive

        [Test]
        public void Exract_Rar_Archivr()
        {
            string rarPath = "D:/testRAR.rar", extractPath = "D:\\extract";
            var index = 0;

            Assert.IsTrue(ArchivingServicess.ExtractRarArchive(rarPath, extractPath));
            RarArchive archive = RarArchive.Open(rarPath);

            foreach (var item in archive.Entries){ Assert.IsTrue(File.Exists($"{extractPath}/{archive.Entries.ElementAt(index).Key}"));index += 1; }

        }
        #endregion

        #region Test_Extract_Rar_Archive_Memorystream
        [Test]
        public void Test_Extract_Rar_Archive_Memorystream()
        {
            string rarPath = "D:/testRAR.rar";
            var index = 0;
            var filesCollection = new List<string> { "D:/New folder{}/test.txt", "D:/New folder{}/New folder/test2.txt" };

            MemoryStream memoryStream = new(ArchivingServicess.ExtractRarArchive(rarPath).ToArray());
            RarArchive archive = RarArchive.Open(memoryStream);

            Assert.IsNotNull(memoryStream);
            Assert.AreEqual(2, archive.Entries.Count);
            foreach (var item in archive.Entries) { Assert.IsTrue(filesCollection[index].Contains(archive.Entries.ElementAt(index).Key)); index += 1; }
        }
        #endregion

        #endregion


    }
}
