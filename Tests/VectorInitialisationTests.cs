using GenericVector;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class VectorInitialisationTests
    {
        [Test]
        public void Init_WithDimension()
        {
            // valid
            var vector = new Vector(2);

            Assert.AreEqual(2, vector.Dimensions);
            Assert.AreEqual(0f, vector[0]);
            Assert.AreEqual(0f, vector[1]);


            // invalid
            Assert.Throws<ArgumentException>(() => new Vector(0));
            Assert.Throws<ArgumentException>(() => new Vector(-1));
        }

        [Test]
        public void Init_WithDefault()
        {
            // valid
            var vector = new Vector(2, 1f);

            Assert.AreEqual(2, vector.Dimensions);
            Assert.AreEqual(1f, vector[0]);
            Assert.AreEqual(1f, vector[1]);

            // invalid
            Assert.Throws<ArgumentException>(() => new Vector(0, 1f));
            Assert.Throws<ArgumentException>(() => new Vector(-1, 1f));
        }


        [Test]
        public void Init_WithValues()
        {
            // valid
            var vector = new Vector(1f, 2f);

            Assert.AreEqual(2, vector.Dimensions);
            Assert.AreEqual(1f, vector[0]);
            Assert.AreEqual(2f, vector[1]);


            // invalid
            Assert.Throws<ArgumentException>(() => new Vector(new float[] { }));
        }


        [Test]
        public void Init_WithVector()
        {
            var source = new Vector(1f, 2f);
            var vector = new Vector(source);

            Assert.AreEqual(2, vector.Dimensions);
            Assert.AreEqual(1f, vector[0]);
            Assert.AreEqual(2f, vector[1]);
        }


        [Test]
        public void Init_WidthDimensionVector()
        {
            Vector source;
            Vector vector;

            // fits
            source = new Vector(1f, 2f);
            vector = new Vector(2, source);

            Assert.AreEqual(2, vector.Dimensions);
            Assert.AreEqual(1f, vector[0]);
            Assert.AreEqual(2f, vector[1]);


            // less
            source = new Vector(1f, 2f);
            vector = new Vector(1, source);

            Assert.AreEqual(1, vector.Dimensions);
            Assert.AreEqual(1f, vector[0]);


            // more
            source = new Vector(1f, 2f);
            vector = new Vector(3, source);

            Assert.AreEqual(3, vector.Dimensions);
            Assert.AreEqual(1f, vector[0]);
            Assert.AreEqual(2f, vector[1]);
            Assert.AreEqual(0f, vector[2]);
        }

    }
}
