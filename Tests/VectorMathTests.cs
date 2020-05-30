using GenericVector;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;

namespace Tests
{
    [TestFixture]
    public class VectorMathTests
    {
        [Test]
        public void ForEachAxis()
        {
            Vector vector;

            vector = Vector.ForEachAxis(new Vector(1f, 2f), (i, axis) => i + axis);

            Assert.AreEqual(2, vector.Dimensions);
            Assert.AreEqual(1f, vector[0]);
            Assert.AreEqual(3f, vector[1]);


            vector = Vector.ForEachAxis(new Vector(1f, 2f), new Vector(3f, 4f), (i, axisA, axisB) => i + axisA + axisB);

            Assert.AreEqual(2, vector.Dimensions);
            Assert.AreEqual(4f, vector[0]);
            Assert.AreEqual(7f, vector[1]);
        }

        [Test]
        public void Magnitude()
        {
            Assert.AreEqual(5f, new Vector(3f, 4f).Magnitude);
            Assert.AreEqual(25f, new Vector(3f, 4f).MagnitudeSquared);
            Assert.AreEqual(7f, new Vector(3f, 4f).MagnitudeManhattan);
        }

        [Test]
        public void Dot()
        {
            Assert.AreEqual(0f, Vector.Dot(new Vector(1f, 0f), new Vector(0f, 1f)));
            Assert.AreEqual(1f, Vector.Dot(new Vector(1f, 0f), new Vector(1f, 0f)));
            Assert.AreEqual(-1f, Vector.Dot(new Vector(1f, 0f), new Vector(-1f, 0f)));
            Assert.AreEqual(4f, Vector.Dot(new Vector(2f, 0f), new Vector(2f, 0f)));
        }

        [Test]
        public void Normalize()
        {
            var vector = new Vector(1f, 1f).Normalized;

            var sqrt2 = ((float)Math.Sqrt(2))/ 2f;
            Assert.AreEqual(sqrt2, vector[0]);
            Assert.AreEqual(sqrt2, vector[1]);
        }

        [Test]
        public void Lerp()
        {
            Vector vector;

            vector = Vector.Lerp(new Vector(1f, 2f), new Vector(3f, 2f, 1f), 0.5f);

            Assert.AreEqual(2, vector.Dimensions);
            Assert.AreEqual(2f, vector[0]);
            Assert.AreEqual(2f, vector[1]);


            vector = Vector.Lerp(new Vector(1f, 2f), new Vector(3f, 2f, 1f), new Vector(1f, 0f, 1f));

            Assert.AreEqual(2, vector.Dimensions);
            Assert.AreEqual(3f, vector[0]);
            Assert.AreEqual(2f, vector[1]);
        }

        [Test]
        public void ClampToMagnitude()
        {
            var vector = Vector.ClampToMagnitude(new Vector(6f, 8f), 5f);

            Assert.AreEqual(2, vector.Dimensions);
            Assert.AreEqual(3f, vector[0]);
            Assert.AreEqual(4f, vector[1]);
        }

        [Test]
        public void MoveTowards()
        {
            Vector vector;

            vector = Vector.MoveTowards(new Vector(1f, 1f, 1f), new Vector(0f, 0f), 2f);

            Assert.AreEqual(2, vector.Dimensions);
            Assert.AreEqual(0f, vector[0]);
            Assert.AreEqual(0f, vector[1]);


            vector = Vector.MoveTowards(new Vector(1f, 1f, 1f), new Vector(0f, 0f), -1);

            var sqrt2 = ((float)Math.Sqrt(2)) / 2f;
            Assert.AreEqual(2, vector.Dimensions);
            Assert.AreEqual(1 + sqrt2, vector[0]);
            Assert.AreEqual(1 + sqrt2, vector[1]);
        }

        [Test]
        public void Distance()
        {
            Assert.AreEqual(5f, Vector.Distance(new Vector(3f, 0f), new Vector(0f, 4f)));
            Assert.AreEqual(25f, Vector.DistanceSquared(new Vector(3f, 0f), new Vector(0f, 4f)));
            Assert.AreEqual(7f, Vector.DistanceManhattan(new Vector(3f, 0f), new Vector(0f, 4f)));
        }

        [Test]
        public void Reflect()
        {
            Vector vector;

            vector = Vector.Reflect(new Vector(1f, -1f, 1f), new Vector(0f, 1f));

            Assert.AreEqual(2, vector.Dimensions);
            Assert.AreEqual(1f, vector[0]);
            Assert.AreEqual(1f, vector[1]);
        }

        [Test]
        public void MinDimension()
        {
            Assert.AreEqual(2, Vector.MinDimension(new Vector(2), new Vector(16), new Vector(5)));
        }
    }
}
