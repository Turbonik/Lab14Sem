using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using lab1vage;


namespace Labtest
{
    [TestClass]
    public class CharMassiveTests
    {
        private const string TestFilePath = "testfile.txt";
        private const long TestArraySize = 100;

        [TestMethod]
        public void TestConstructor_ValidParameters_CreatesInstance()
        {
            CharMassive charMassive = new CharMassive(TestFilePath, TestArraySize);
            Assert.IsNotNull(charMassive);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructor_ArraySizeTooLarge_ThrowsException()
        {
            CharMassive charMassive = new CharMassive(TestFilePath, 3000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructor_NegativeArraySize_ThrowsException()
        {
            CharMassive charMassive = new CharMassive(TestFilePath, -1);
        }

        [TestMethod]
        public void TestElement_WriteAndDefinition_ValidInputs()
        {
            CharMassive charMassive = new CharMassive(TestFilePath, TestArraySize);

            bool writeResult = charMassive.Element_Write(10, 'A');
            Assert.IsTrue(writeResult);

            char result = charMassive.Element_Definition(10);
            Assert.AreEqual('A', result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestElement_Write_IndexOccupied_ThrowsException()
        {
            CharMassive charMassive = new CharMassive(TestFilePath, TestArraySize);
            charMassive.Element_Write(20, 'B');


            charMassive.Element_Write(20, 'C');
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestElement_Definition_IndexEmpty_ThrowsException()
        {
            CharMassive charMassive = new CharMassive(TestFilePath, TestArraySize);


            charMassive.Element_Definition(30);
        }

        [TestMethod]
        public void TestPage_Number_NewPageLoadsSuccessfully()
        {
            CharMassive charMassive = new CharMassive(TestFilePath, TestArraySize);
            int pageIndex = charMassive.Page_Number(10);

            Assert.IsTrue(pageIndex >= 0 && pageIndex < 5);
        }
    }
    [TestClass]
    public class IntMassiveTests
    {
        private const string TestFilePath = "int_testfile.dat";
        private const long TestArraySize = 100;

        [TestMethod]
        public void TestConstructor_ValidParameters_CreatesInstance()
        {
            IntMassive intMassive = new IntMassive(TestFilePath, TestArraySize);
            Assert.IsNotNull(intMassive);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructor_ArraySizeTooLarge_ThrowsException()
        {
            IntMassive intMassive = new IntMassive(TestFilePath, 700);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructor_NegativeArraySize_ThrowsException()
        {
            IntMassive intMassive = new IntMassive(TestFilePath, -1);
        }

        [TestMethod]
        public void TestElement_WriteAndDefinition_ValidInputs()
        {
            IntMassive intMassive = new IntMassive(TestFilePath, TestArraySize);

            bool writeResult = intMassive.Element_Write(10, 42);
            Assert.IsTrue(writeResult);

            int result = intMassive.Element_Definition(10);
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestElement_Write_IndexOccupied_ThrowsException()
        {
            IntMassive intMassive = new IntMassive(TestFilePath, TestArraySize);
            intMassive.Element_Write(20, 99);


            intMassive.Element_Write(20, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestElement_Definition_IndexEmpty_ThrowsException()
        {
            IntMassive intMassive = new IntMassive(TestFilePath, TestArraySize);


            intMassive.Element_Definition(30);
        }

        [TestMethod]
        public void TestPage_Number_NewPageLoadsSuccessfully()
        {
            IntMassive intMassive = new IntMassive(TestFilePath, TestArraySize);
            int pageIndex = intMassive.Page_Number(10);

            Assert.IsTrue(pageIndex >= 0 && pageIndex < 5);
        }
    }
    [TestClass]
    public class StringMassiveTests
    {
        private const string TestFilePathValues = "string_testfile_values.dat";
        private const string TestFilePathLinks = "string_testfile_links.dat";
        private const long TestArraySize = 100;

        [TestMethod]
        public void TestConstructor_ValidParameters_CreatesInstance()
        {
            StringMassive stringMassive = new StringMassive(TestFilePathValues, TestFilePathLinks, TestArraySize);
            Assert.IsNotNull(stringMassive);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructor_ArraySizeTooLarge_ThrowsException()
        {
            StringMassive stringMassive = new StringMassive(TestFilePathValues, TestFilePathLinks, 700);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructor_NegativeArraySize_ThrowsException()
        {
            StringMassive stringMassive = new StringMassive(TestFilePathValues, TestFilePathLinks, -1);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestElement_Write_IndexOccupied_ThrowsException()
        {
            StringMassive stringMassive = new StringMassive(TestFilePathValues, TestFilePathLinks, TestArraySize);
            stringMassive.Element_Write(20, "test");

            stringMassive.Element_Write(20, "occupied");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestElement_Definition_IndexEmpty_ThrowsException()
        {
            StringMassive stringMassive = new StringMassive(TestFilePathValues, TestFilePathLinks, TestArraySize);

            stringMassive.Element_Definition(30);
        }


        [TestMethod]
        public void TestPage_Number_NewPageLoadsSuccessfully()
        {
            StringMassive stringMassive = new StringMassive(TestFilePathValues, TestFilePathLinks, TestArraySize);
            int pageIndex = stringMassive.Page_Number(10);

            Assert.IsTrue(pageIndex >= 0 && pageIndex < 5);
        }



    }

        

    }

