using lab1vage;

namespace Labtest
{
    [TestClass]
    public class StringFileHandlerTests
    {
        private const string TestFilePathValues = "test_values.dat";
        private const string TestFilePathLinks = "test_links.dat";
        private const int TestArrayLength = 128;

        private StringFileHandler fileHandler;

        [TestInitialize]
        public void Setup()
        {
            // Удаляем тестовые файлы, если они существуют
            if (File.Exists(TestFilePathValues)) File.Delete(TestFilePathValues);
            if (File.Exists(TestFilePathLinks)) File.Delete(TestFilePathLinks);

            // Создаем экземпляр StringFileHandler
            fileHandler = new StringFileHandler(TestFilePathValues, TestFilePathLinks, TestArrayLength);
        }

        [TestMethod]
        public void TestConstructor_CreatesFiles()
        {
            Assert.IsTrue(File.Exists(TestFilePathValues));
            Assert.IsTrue(File.Exists(TestFilePathLinks));
        }

        [TestMethod]
        public void TestPageWriter_WritesPageSuccessfully()
        {
            IStringPage page = new StringPage
            {
                Number = 1,
                Bitmap = new byte[16], // Пример длины битмапа
                Links = new long[TestArrayLength]
            };

            fileHandler.PageWriter(page);

            // Проверяем, что данные были записаны
            IStringPage readPage = fileHandler.PageReader(1);
            Assert.AreEqual(page.Number, readPage.Number);
            CollectionAssert.AreEqual(page.Bitmap, readPage.Bitmap);
        }

        [TestMethod]
        public void TestPageReader_ValidPageNumber_ReturnsPage()
        {
            IStringPage page = new StringPage
            {
                Number = 1,
                Bitmap = new byte[16],
                Links = new long[TestArrayLength]
            };

            fileHandler.PageWriter(page);

            IStringPage readPage = fileHandler.PageReader(1);
            Assert.IsNotNull(readPage);
            Assert.AreEqual(page.Number, readPage.Number);
        }

        [TestMethod]
        public void TestStringWriter_ValidString_WritesString()
        {
            string testString = "hello";
            long position = fileHandler.String_Writer(testString);

            Assert.IsTrue(position >= 0);
        }

        [TestMethod]
        public void TestStringSelection_ValidLink_ReturnsString()
        {
            string testString = "world";
            long link = fileHandler.String_Writer(testString);

            string result = fileHandler.String_Selection(link);
            Assert.AreEqual(testString, result);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Удаляем тестовые файлы после тестов
            if (File.Exists(TestFilePathValues)) File.Delete(TestFilePathValues);
            if (File.Exists(TestFilePathLinks)) File.Delete(TestFilePathLinks);
        }
    }
    [TestClass]
    public class FileHandlerTests
    {
        private const string TestCharFilePath = "char_testfile.dat";
        private const string TestIntFilePath = "int_testfile.dat";

        [TestCleanup]
        public void Cleanup()
        {
            // Удаление тестовых файлов после каждого теста
            if (File.Exists(TestCharFilePath))
            {
                File.Delete(TestCharFilePath);
            }
            if (File.Exists(TestIntFilePath))
            {
                File.Delete(TestIntFilePath);
            }
        }

        [TestMethod]
        public void TestCharFileHandler_CreatesFile()
        {
            CharFileHandler handler = new CharFileHandler(TestCharFilePath);
            Assert.IsTrue(File.Exists(TestCharFilePath));
        }

        [TestMethod]

        public void TestCharFileHandler_PageCreationIfNotExists()
        {
            CharFileHandler handler = new CharFileHandler(TestCharFilePath);
            ICharPage page = handler.PageReader(1);
            Assert.AreEqual(1, page.Number);
        }

    }
    [TestClass]
    public class IntFileHandlerTests
    {
        private const string TestFilePath = "int_testfile.dat";
        private const int TestArrayLength = 128;

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
        }

        [TestMethod]
        public void TestConstructor_FileDoesNotExist_CreatesFile()
        {
            IntFileHandler intFileHandler = new IntFileHandler(TestFilePath, TestArrayLength);
            Assert.IsTrue(File.Exists(TestFilePath));
        }


        [TestMethod]
        public void TestPageReader_CreateNewPage_ValidPageNumber()
        {
            IntFileHandler intFileHandler = new IntFileHandler(TestFilePath, TestArrayLength);

            IIntPage page = intFileHandler.PageReader(1);
            Assert.IsNotNull(page);
            Assert.AreEqual(1, page.Number);
        }

        [TestMethod]
        public void TestPageWriter_WritePageSuccessfully()
        {
            IntFileHandler intFileHandler = new IntFileHandler(TestFilePath, TestArrayLength);
            IIntPage page = new IntPage
            {
                Number = 1,
                Bitmap = new byte[16],
                Values = new int[128]
            };

            intFileHandler.PageWriter(page);

            IIntPage readPage = intFileHandler.PageReader(1);
            Assert.AreEqual(page.Number, readPage.Number);
            CollectionAssert.AreEqual(page.Bitmap, readPage.Bitmap);
            CollectionAssert.AreEqual(page.Values, readPage.Values);
        }

        [TestMethod]
  

     
        public void TestPageReader_PageDoesNotExist_CreatesNewPage()
        {
            IntFileHandler intFileHandler = new IntFileHandler(TestFilePath, TestArrayLength);
            IIntPage page = intFileHandler.PageReader(2);

            Assert.IsNotNull(page);
            Assert.AreEqual(2, page.Number);
        }
    }
}
