using GenericVector;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class Initialisation
    {
        private GVector testVector3;

        [SetUp]
        public void SetUp()
        {
            testVector3 = new GVector(3f, 5f, 7f);
        }

        [Test]
        [TestCase(1)]
        [TestCase(4096)]
        public void Init_By_Dimension(int value)
        {
            var vector = new GVector(value);
            Assert.AreEqual(value, vector.Dimensions);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Init_By_Dimension_Invalid(int value)
        {
            Assert.Throws<ArgumentException>(() => new GVector(value));
        }


        [Test]
        [TestCase(new float[] { 1f })]
        [TestCase(new float[] { 1f, 2f, 3f , 4f, 5f })]
        public void Init_By_Values(params float[] values)
        {
            var vector = new GVector(values);

            Assert.AreEqual(values.Length, vector.Dimensions);
            for (int i = 0; i < values.Length; i++)
                Assert.AreEqual(values[i], vector[i]);

        }


        [Test]
        public void Init_By_Vector()
        {
            var vector = new GVector(testVector3);

            Assert.AreEqual(vector.Dimensions, testVector3.Dimensions);
            for (int i = 0; i < testVector3.Dimensions; i++)
                Assert.AreEqual(vector[i], testVector3[i]);
        }


        [Test]
        [TestCase(3, 2f)]
        public void Init_By_DefaultValue(int dimensions, float defautValue)
        {
            var vector = new GVector(dimensions, defautValue);

            Assert.AreEqual(vector.Dimensions, dimensions);
            for (int i = 0; i < vector.Dimensions; i++)
                Assert.AreEqual(vector[i], defautValue);
        }


        [Test]
        [TestCase(2)]
        public void Init_By_Dimension_and_Vector(int dimensions)
        {
            var vector = new GVector(dimensions, testVector3);

            Assert.AreEqual(vector.Dimensions, dimensions);
            for (int i = 0; i < vector.Dimensions; i++)
                Assert.AreEqual(vector[i], testVector3[i]);
        }

    }
}
