using Balanca.LeftSide.ExtensionMethods;
using NUnit.Framework;

namespace Balanca.UnitTest
{
    public class LeftSideTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CpfTest_Sucess()
        {
            //Arrange
            bool expected = true;
            bool actual;
            var cpf = "69559157035";

            //Act
            actual = cpf.IsCpfValid();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CpfTest_Fail()
        {
            //Arrange
            bool expected = false;
            bool actual;
            var cpf = "6955915703X";

            //Act
            actual = cpf.IsCpfValid();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}