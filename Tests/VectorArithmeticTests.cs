using GenericVector;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class VectorArithmeticTests
    {
        [Test]
        public void Add()
        {
            var resultA = new Vector(1f, 2f, 3f) + new Vector(1f, 2f);

            Assert.AreEqual(2, resultA.Dimensions);
            Assert.AreEqual(2f, resultA[0]);
            Assert.AreEqual(4f, resultA[1]);


            var resultB = new Vector(1f, 2f) + new Vector(1f, 2f, 3f);

            Assert.AreEqual(resultA.Dimensions, resultB.Dimensions);
            Assert.AreEqual(resultA[0], resultB[0]);
            Assert.AreEqual(resultA[1], resultB[1]);
        }

        [Test]
        public void Add_Float()
        {
            var resultA = new Vector(1f, 2f) + 1f;

            Assert.AreEqual(2, resultA.Dimensions);
            Assert.AreEqual(2f, resultA[0]);
            Assert.AreEqual(3f, resultA[1]);


            var resultB = 1f + new Vector(1f, 2f);

            Assert.AreEqual(resultA.Dimensions, resultB.Dimensions);
            Assert.AreEqual(resultA[0], resultB[0]);
            Assert.AreEqual(resultA[1], resultB[1]);
        }


        [Test]
        public void Substract()
        {
            var resultA = new Vector(1f, 2f, 3f) - new Vector(2f, 4f);

            Assert.AreEqual(2, resultA.Dimensions);
            Assert.AreEqual(-1f, resultA[0]);
            Assert.AreEqual(-2f, resultA[1]);


            var resultB = new Vector(2f, 4f) - new Vector(1f, 2f, 3f);

            Assert.AreEqual(resultA.Dimensions, resultB.Dimensions);
            Assert.AreEqual(1f, resultB[0]);
            Assert.AreEqual(2f, resultB[1]);
        }

        [Test]
        public void Substract_Float()
        {
            var resultA = new Vector(1f, 2f) - 4f;

            Assert.AreEqual(2, resultA.Dimensions);
            Assert.AreEqual(-3f, resultA[0]);
            Assert.AreEqual(-2f, resultA[1]);


            var resultB = 4f - new Vector(1f, 2f);

            Assert.AreEqual(resultA.Dimensions, resultB.Dimensions);
            Assert.AreEqual(3f, resultB[0]);
            Assert.AreEqual(2f, resultB[1]);
        }


        [Test]
        public void Mulitply()
        {
            var resultA = new Vector(1f, 2f, 3f) * new Vector(2f, 4f);

            Assert.AreEqual(2, resultA.Dimensions);
            Assert.AreEqual(2f, resultA[0]);
            Assert.AreEqual(8f, resultA[1]);


            var resultB = new Vector(2f, 4f) * new Vector(1f, 2f, 3f);

            Assert.AreEqual(resultA.Dimensions, resultB.Dimensions);
            Assert.AreEqual(resultA[0], resultB[0]);
            Assert.AreEqual(resultA[1], resultB[1]);
        }

        [Test]
        public void Mulitply_Float()
        {
            var resultA = new Vector(1f, 2f) * 2f;

            Assert.AreEqual(2, resultA.Dimensions);
            Assert.AreEqual(2f, resultA[0]);
            Assert.AreEqual(4f, resultA[1]);


            var resultB = 2f * new Vector(1f, 2f);

            Assert.AreEqual(resultA.Dimensions, resultB.Dimensions);
            Assert.AreEqual(resultA[0], resultB[0]);
            Assert.AreEqual(resultA[1], resultB[1]);
        }


        [Test]
        public void Divide()
        {
            var resultA = new Vector(1f, 2f, 3f) / new Vector(2f, 4f);

            Assert.AreEqual(2, resultA.Dimensions);
            Assert.AreEqual(0.5f, resultA[0]);
            Assert.AreEqual(0.5f, resultA[1]);


            var resultB = new Vector(2f, 4f) / new Vector(1f, 2f, 3f);

            Assert.AreEqual(resultA.Dimensions, resultB.Dimensions);
            Assert.AreEqual(2f, resultB[0]);
            Assert.AreEqual(2f, resultB[1]);
        }

        [Test]
        public void Divide_Float()
        {
            var resultA = new Vector(1f, 2f) / 2f;

            Assert.AreEqual(2, resultA.Dimensions);
            Assert.AreEqual(0.5f, resultA[0]);
            Assert.AreEqual(1f, resultA[1]);


            var resultB = 2f / new Vector(1f, 2f);

            Assert.AreEqual(resultA.Dimensions, resultB.Dimensions);
            Assert.AreEqual(2f, resultB[0]);
            Assert.AreEqual(1f, resultB[1]);
        }
        [Test]
        public void Modulo()
        {
            var resultA = new Vector(5f, 4f, 3f) % new Vector(2f, 3f);

            Assert.AreEqual(2, resultA.Dimensions);
            Assert.AreEqual(1f, resultA[0]);
            Assert.AreEqual(1f, resultA[1]);


            var resultB = new Vector(2f, 3f) % new Vector(5f, 4f, 3f);

            Assert.AreEqual(resultA.Dimensions, resultB.Dimensions);
            Assert.AreEqual(2f, resultB[0]);
            Assert.AreEqual(3f, resultB[1]);
        }


        [Test]
        public void Modulo_Float()
        {
            var resultA = new Vector(4f, 3f) % 2f;

            Assert.AreEqual(2, resultA.Dimensions);
            Assert.AreEqual(0f, resultA[0]);
            Assert.AreEqual(1f, resultA[1]);


            var resultB = 2f % new Vector(4f, 3f);

            Assert.AreEqual(resultA.Dimensions, resultB.Dimensions);
            Assert.AreEqual(2f, resultB[0]);
            Assert.AreEqual(2f, resultB[1]);
        }
    }
}
