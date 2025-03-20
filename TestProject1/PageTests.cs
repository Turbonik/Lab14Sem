using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using lab1vage;
namespace labtest
{
    [TestClass]
    public class CharPageTests
    {
        [TestMethod]
        public void CharPage_Constructor_ShouldInitializeProperties()
        {
            // Arrange & Act
            var charPage = new CharPage();

            // Assert
            Assert.AreEqual(0, charPage.Number);
            Assert.AreEqual(0, charPage.Status);
            Assert.IsTrue((DateTime.Now - charPage.Last_Write).TotalSeconds < 1); // ѕроверка, что Last_Write инициализировано недавней датой
            Assert.IsNotNull(charPage.Bitmap);
            Assert.AreEqual(64, charPage.Bitmap.Length);
            Assert.IsNotNull(charPage.Values);
            Assert.AreEqual(512, charPage.Values.Length);
        }

        [TestMethod]
        public void Number_Property_ShouldSetAndGetValue()
        {
            // Arrange
            var charPage = new CharPage();
            long expectedNumber = 123456789;

            // Act
            charPage.Number = expectedNumber;

            // Assert
            Assert.AreEqual(expectedNumber, charPage.Number);
        }

        [TestMethod]
        public void Status_Property_ShouldSetAndGetValue()
        {
            // Arrange
            var charPage = new CharPage();
            byte expectedStatus = 1;

            // Act
            charPage.Status = expectedStatus;

            // Assert
            Assert.AreEqual(expectedStatus, charPage.Status);
        }

        [TestMethod]
        public void Last_Write_Property_ShouldSetAndGetValue()
        {
            // Arrange
            var charPage = new CharPage();
            DateTime expectedDateTime = DateTime.Now;

            // Act
            charPage.Last_Write = expectedDateTime;

            // Assert
            Assert.AreEqual(expectedDateTime, charPage.Last_Write);
        }

        [TestMethod]
        public void Bitmap_Property_ShouldSetAndGetValue()
        {
            // Arrange
            var charPage = new CharPage();
            byte[] expectedBitmap = new byte[64];

            // Act
            charPage.Bitmap = expectedBitmap;

            // Assert
            CollectionAssert.AreEqual(expectedBitmap, charPage.Bitmap);
        }

        [TestMethod]
        public void Values_Property_ShouldSetAndGetValue()
        {
            // Arrange
            var charPage = new CharPage();
            char[] expectedValues = new char[512];

            // Act
            charPage.Values = expectedValues;

            // Assert
            CollectionAssert.AreEqual(expectedValues, charPage.Values);
        }
    }

    [TestClass]
    public class IntPageTests
    {
        [TestMethod]
        public void IntPage_Constructor_ShouldInitializeProperties()
        {
            // Arrange & Act
            var intPage = new IntPage();

            // Assert
            Assert.AreEqual(0, intPage.Number);
            Assert.AreEqual(0, intPage.Status);
            Assert.IsTrue((DateTime.Now - intPage.Last_Write).TotalSeconds < 1); // ѕроверка, что Last_Write инициализировано недавней датой
            Assert.IsNotNull(intPage.Bitmap);
            Assert.AreEqual(16, intPage.Bitmap.Length);
            Assert.IsNotNull(intPage.Values);
            Assert.AreEqual(128, intPage.Values.Length);
        }

        [TestMethod]
        public void Number_Property_ShouldSetAndGetValue()
        {
            // Arrange
            var intPage = new IntPage();
            long expectedNumber = 123456789;

            // Act
            intPage.Number = expectedNumber;

            // Assert
            Assert.AreEqual(expectedNumber, intPage.Number);
        }

        [TestMethod]
        public void Status_Property_ShouldSetAndGetValue()
        {
            // Arrange
            var intPage = new IntPage();
            byte expectedStatus = 1;

            // Act
            intPage.Status = expectedStatus;

            // Assert
            Assert.AreEqual(expectedStatus, intPage.Status);
        }

        [TestMethod]
        public void Last_Write_Property_ShouldSetAndGetValue()
        {
            // Arrange
            var intPage = new IntPage();
            DateTime expectedDateTime = DateTime.Now;

            // Act
            intPage.Last_Write = expectedDateTime;

            // Assert
            Assert.AreEqual(expectedDateTime, intPage.Last_Write);
        }

        [TestMethod]
        public void Bitmap_Property_ShouldSetAndGetValue()
        {
            // Arrange
            var intPage = new IntPage();
            byte[] expectedBitmap = new byte[16];

            // Act
            intPage.Bitmap = expectedBitmap;

            // Assert
            CollectionAssert.AreEqual(expectedBitmap, intPage.Bitmap);
        }

        [TestMethod]
        public void Values_Property_ShouldSetAndGetValue()
        {
            // Arrange
            var intPage = new IntPage();
            int[] expectedValues = new int[128];

            // Act
            intPage.Values = expectedValues;

            // Assert
            CollectionAssert.AreEqual(expectedValues, intPage.Values);
        }

        [TestClass]
        public class StringPageTests
        {
            [TestMethod]
            public void StringPage_Constructor_ShouldInitializeProperties()
            {
                // Arrange & Act
                var stringPage = new StringPage();

                // Assert
                Assert.AreEqual(0, stringPage.Number);
                Assert.AreEqual(0, stringPage.Status);
                Assert.IsTrue((DateTime.Now - stringPage.Last_Write).TotalSeconds < 1); // ѕроверка, что Last_Write инициализировано недавней датой
                Assert.IsNotNull(stringPage.Bitmap);
                Assert.AreEqual(16, stringPage.Bitmap.Length);
                Assert.IsNotNull(stringPage.Links);
                Assert.AreEqual(128, stringPage.Links.Length);
            }

            [TestMethod]
            public void Number_Property_ShouldSetAndGetValue()
            {
                // Arrange
                var stringPage = new StringPage();
                long expectedNumber = 123456789;

                // Act
                stringPage.Number = expectedNumber;

                // Assert
                Assert.AreEqual(expectedNumber, stringPage.Number);
            }

            [TestMethod]
            public void Status_Property_ShouldSetAndGetValue()
            {
                // Arrange
                var stringPage = new StringPage();
                byte expectedStatus = 1;

                // Act
                stringPage.Status = expectedStatus;

                // Assert
                Assert.AreEqual(expectedStatus, stringPage.Status);
            }

            [TestMethod]
            public void Last_Write_Property_ShouldSetAndGetValue()
            {
                // Arrange
                var stringPage = new StringPage();
                DateTime expectedDateTime = DateTime.Now;

                // Act
                stringPage.Last_Write = expectedDateTime;

                // Assert
                Assert.AreEqual(expectedDateTime, stringPage.Last_Write);
            }

            [TestMethod]
            public void Bitmap_Property_ShouldSetAndGetValue()
            {
                // Arrange
                var stringPage = new StringPage();
                byte[] expectedBitmap = new byte[16];

                // Act
                stringPage.Bitmap = expectedBitmap;

                // Assert
                CollectionAssert.AreEqual(expectedBitmap, stringPage.Bitmap);
            }

            [TestMethod]
            public void Links_Property_ShouldSetAndGetValue()
            {
                // Arrange
                var stringPage = new StringPage();
                long[] expectedLinks = new long[128];

                // Act
                stringPage.Links = expectedLinks;

                // Assert
                CollectionAssert.AreEqual(expectedLinks, stringPage.Links);
            }
        }
    }
}