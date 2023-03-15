using System;
using Xunit;
using ZebraStreifen;
namespace ZebrastreifenTester
{
    public class minimumWidthTester
    {

        [Fact]
        public void Test1()
        {
            var rand =new Random();
            int[] minWidthTester = new int[4];
            for(int i=0; i<100000; i++)
            {
                minWidthTester[0] = rand.Next(1,1000);
                minWidthTester[2] = rand.Next(1,1000);
                Program.minimumWidth(minWidthTester);
                Assert.True(minWidthTester[3] >= minWidthTester[0] / minWidthTester[2]);
            }

        }
        [Fact]
        public void generateZSLine_Rest0Case_UncroppedNucleusLine()
        {
            //Arrange
            string expectedOutput = "**  **  **  \n";
            string zebraStreifenNucleus = "**  ";
            int[] zebraParams = {12,0,2,6};
            
            //Act
            string actualOutput = Program.generateZebraStreifenLine(zebraStreifenNucleus, zebraParams);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
        [Fact]
        public void generateZSLine_Rest1Case_CroppedNucleusLine()
        {
            //Arrange
            string expectedOutput = "**  **  **  *\n";
            string zebraStreifenNucleus = "**  ";
            int[] zebraParams = { 13, 0, 2, 6 };

            //Act
            string actualOutput = Program.generateZebraStreifenLine(zebraStreifenNucleus, zebraParams);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
        [Fact]
        public void generateZSLine_EmptyStringCase_IllegalArgumentException()
        {
            //Arrange
            string zebraStreifenNucleus = "";
            int[] zebraParams = { 13, 0, 2, 6 };

            //   Act
            //    &&
            //Assert
            Assert.Throws<IllegalArgumentException> (() => Program.generateZebraStreifenLine(zebraStreifenNucleus, zebraParams));
        }
        [Fact]
        public void generateZSLine_UnexpectedNucleusCase_WeiredLine()
        {
            //Arrange
            string expectedOutput = "**+  **+  **+  *\n";
            string zebraStreifenNucleus = "**+  ";
            int[] zebraParams = { 16, 0, 2, 6 };

            //Act
            string actualOutput = Program.generateZebraStreifenLine(zebraStreifenNucleus, zebraParams);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
        [Fact]
        public void generateZSLine_Rest2Case_CroppedNucleusLine()
        {
            //Arrange
            string expectedOutput = "**  **  **\n";
            string zebraStreifenNucleus = "**  ";
            int[] zebraParams = { 10, 0, 2, 6 };

            //Act
            string actualOutput = Program.generateZebraStreifenLine(zebraStreifenNucleus, zebraParams);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}