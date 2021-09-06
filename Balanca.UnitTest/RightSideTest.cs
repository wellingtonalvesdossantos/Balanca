using Balanca.RightSide;
using Balanca.RightSide.ExtensionMethods;
using NUnit.Framework;

namespace Balanca.UnitTest
{
    public class RightSideTest
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
            var cpf = new CPF();

            //Act
            actual = cpf.IsValid("69559157035");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CpfTest_Fail()
        {
            //Arrange
            bool expected = false;
            bool actual;
            var cpf = new CPF();

            //Act
            actual = cpf.IsValid("6955915703X");

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}