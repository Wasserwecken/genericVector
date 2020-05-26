using GenericVector;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private GVector vector5;
        private GVector vector4;

        [SetUp]
        public void Setup()
        {
            vector5 = new GVector(5);
            vector4 = new GVector(4);
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(128)]
        public void Create_Gevector_By_Dimension(int value)
        {
            var vector = new GVector(value);
            Assert.AreEqual(value, vector.Dimensions);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Create_Gevector_By_Dimension_Invalid(int value)
        {
            Assert.Throws<ArgumentException>(() => new GVector(value));
        }
    }
}