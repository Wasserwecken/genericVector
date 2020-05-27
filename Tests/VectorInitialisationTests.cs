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

            Assert.AreEqual(vector.Dimensions, 2);
            Assert.AreEqual(vector[0], 0f);
            Assert.AreEqual(vector[1], 0f);


            // invalid
            Assert.Throws<ArgumentException>(() => new Vector(0));
            Assert.Throws<ArgumentException>(() => new Vector(-1));
        }

        [Test]
        public void Init_WithDefault()
        {
            // valid
            var vector = new Vector(2, 1f);

            Assert.AreEqual(vector.Dimensions, 2);
            Assert.AreEqual(vector[0], 1f);
            Assert.AreEqual(vector[1], 1f);

            // invalid
            Assert.Throws<ArgumentException>(() => new Vector(0, 1f));
            Assert.Throws<ArgumentException>(() => new Vector(-1, 1f));
        }


        [Test]
        public void Init_WithValues()
        {
            // valid
            var vector = new Vector(1f, 2f);

            Assert.AreEqual(vector.Dimensions, 2);
            Assert.AreEqual(vector[0], 1f);
            Assert.AreEqual(vector[1], 2f);


            // invalid
            Assert.Throws<ArgumentException>(() => new Vector(new float[] { }));
        }


        [Test]
        public void Init_WithVector()
        {
            var source = new Vector(1f, 2f);
            var vector = new Vector(source);

            Assert.AreEqual(vector.Dimensions, source.Dimensions);
            Assert.AreEqual(vector[0], source[0]);
            Assert.AreEqual(vector[1], source[1]);
        }


        [Test]
        public void Init_WidthDimensionVector()
        {
            Vector source;
            Vector vector;

            // fits
            source = new Vector(1f, 2f);
            vector = new Vector(2, source);

            Assert.AreEqual(vector.Dimensions, source.Dimensions);
            Assert.AreEqual(vector[0], source[0]);
            Assert.AreEqual(vector[1], source[1]);


            // less
            source = new Vector(1f, 2f);
            vector = new Vector(1, source);

            Assert.AreEqual(vector.Dimensions, 1);
            Assert.AreEqual(vector[0], source[0]);


            // more
            source = new Vector(1f, 2f);
            vector = new Vector(3, source);

            Assert.AreEqual(vector.Dimensions, 3);
            Assert.AreEqual(vector[0], source[0]);
            Assert.AreEqual(vector[1], source[1]);
            Assert.AreEqual(vector[2], 0f);
        }

    }
}
