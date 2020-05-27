using GenericVector;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class GVectorInitialisationTests
    {
        private GVector testVector3;

        [SetUp]
        public void Setup()
        {
            testVector3 = new GVector(3f, 5f, 7f);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4096)]
        public void InitByDimension(int value)
        {
            if (value > 0)
            {
                Assert.AreEqual(value, new GVector(value).Dimensions);
            }
            else
                Assert.Throws<ArgumentException>(() => new GVector(value));




            Assert.AreEqual(1, new GVector(1).Dimensions);
            Assert.AreEqual(4096, new GVector(4096).Dimensions);
            Assert.Throws<ArgumentException>(() => new GVector(0));
            Assert.Throws<ArgumentException>(() => new GVector(-1));
        }


        [Test]
        [TestCase(new float[] { 1f })]
        [TestCase(new float[] { 1f, 2f, 3f, 4f, 5f })]
        public void InitByValues(params float[] values)
        {
            var vector = new GVector(values);

            Assert.AreEqual(values.Length, vector.Dimensions);
            for (int i = 0; i < values.Length; i++)
                Assert.AreEqual(values[i], vector[i]);
        }


        [Test]
        public void InitByVector()
        {
            var vector = new GVector(testVector3);

            Assert.AreEqual(vector.Dimensions, testVector3.Dimensions);
            for (int i = 0; i < testVector3.Dimensions; i++)
                Assert.AreEqual(vector[i], testVector3[i]);
        }


        [Test]
        [TestCase(3, 2f)]
        public void InitByDefaultValue(int dimensions, float defautValue)
        {
            var vector = new GVector(dimensions, defautValue);

            Assert.AreEqual(vector.Dimensions, dimensions);
            for (int i = 0; i < vector.Dimensions; i++)
                Assert.AreEqual(vector[i], defautValue);
        }


        [Test]
        [TestCase(2)]
        public void InitByDimensionandVector(int dimensions)
        {
            var vector = new GVector(dimensions, testVector3);

            Assert.AreEqual(vector.Dimensions, dimensions);
            for (int i = 0; i < vector.Dimensions; i++)
                Assert.AreEqual(vector[i], testVector3[i]);
        }

    }
}
