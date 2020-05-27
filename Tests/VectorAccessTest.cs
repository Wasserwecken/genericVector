using GenericVector;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class VectorAccessTest
    {
        [Test]
        public void Indexer_Get()
        {
            var vector = new Vector(1f, 2f, 3f);

            // valid
            Assert.AreEqual(1f, vector[0]);
            Assert.AreEqual(2f, vector[1]);
            Assert.AreEqual(3f, vector[2]);


            // invalid
            Assert.Throws<IndexOutOfRangeException>(() => _ = vector[-1]);
            Assert.Throws<IndexOutOfRangeException>(() => _ = vector[3]);
        }

        [Test]
        public void Indexer_Set()
        {
            var vector = new Vector(1f, 2f, 3f);
            vector[1] = -1f;

            // valid
            Assert.AreEqual(1f, vector[0]);
            Assert.AreEqual(-1f, vector[1]);
            Assert.AreEqual(3f, vector[2]);


            // invalid
            Assert.Throws<IndexOutOfRangeException>(() => vector[-1] = 0f);
            Assert.Throws<IndexOutOfRangeException>(() => vector[3] = 0f);
        }


        [Test]
        public void Indexer_Get_Multidimensional()
        {
            var vector = new Vector(1f, 2f, 3f);

            // valid
            var result = vector[2, 1];
            Assert.AreEqual(2, result.Dimensions);
            Assert.AreEqual(3f, result[0]);
            Assert.AreEqual(2f, vector[1]);


            // invalid
            Assert.Throws<IndexOutOfRangeException>(() => _ = vector[0, 1, 2, 3]);
        }

        [Test]
        public void Indexer_Set_Multidimensional()
        {
            Vector vector;

            // valid
            vector = new Vector(1f, 2f, 3f);
            vector[1, 0] = new Vector(4f, 5f, 6f);

            Assert.AreEqual(3, vector.Dimensions);
            Assert.AreEqual(5f, vector[0]);
            Assert.AreEqual(4f, vector[1]);
            Assert.AreEqual(3f, vector[2]);


            // less
            vector = new Vector(1f, 2f, 3f);
            vector[1, 0] = new Vector(4f);

            Assert.AreEqual(3, vector.Dimensions);
            Assert.AreEqual(1f, vector[0]);
            Assert.AreEqual(4f, vector[1]);
            Assert.AreEqual(3f, vector[2]);


            // invalid
            vector = new Vector(1f, 2f, 3f);
            Assert.Throws<IndexOutOfRangeException>(() => vector[2, 1, 0, 4] = new Vector(1f, 2f, 3f, 4f));
        }
    }
}
