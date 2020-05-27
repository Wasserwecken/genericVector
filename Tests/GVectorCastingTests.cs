using GenericVector;
using NUnit.Framework;
using System;
using System.Numerics;

namespace Tests
{
    [TestFixture]
    public class GVectorCastingTests
    {
        [Test]
        public void ToDimension()
        {
            GVector result;
            GVector expected;


            // to lower
            result = new GVector(1f, 2f).ToDimension(1);
            expected = new GVector(1f);

            result.AssertAreEqual(expected);


            // to higher
            result = new GVector(1f, 2f).ToDimension(3);
            expected = new GVector(1f, 2f, 0f);

            result.AssertAreEqual(expected);
        }

        [Test]
        public void ToDimension_WithDefault()
        {
            GVector result;
            GVector expected;


            // to lower
            result = new GVector(1f, 2f).ToDimension(1, 3f);
            expected = new GVector(1f);

            result.AssertAreEqual(expected);


            // to higher
            result = new GVector(1f, 2f).ToDimension(3, 3f);
            expected = new GVector(1f, 2f, 3f);

            result.AssertAreEqual(expected);
        }

        [Test]
        public void Merge()
        {
            GVector result;
            GVector expected;


            // empty
            result = new GVector(1f, 2f).Merge(new float[] { });
            expected = new GVector(1f, 2f);

            result.AssertAreEqual(expected);


            // with lower
            result = new GVector(1f, 2f).Merge(new GVector(1f));
            expected = new GVector(1f, 2f);

            result.AssertAreEqual(expected);


            // with higher
            result = new GVector(1f, 2f).Merge(new GVector(1f, 2f, 3f));
            expected = new GVector(1f, 2f, 3f);

            result.AssertAreEqual(expected);
        }


        [Test]
        public void AddDimensions()
        {
            GVector result;
            GVector expected;


            // empty
            result = new GVector(1f, 2f).AddDimensions(new float[] { });
            expected = new GVector(1f, 2f);

            result.AssertAreEqual(expected);


            // new axes
            result = new GVector(1f, 2f).AddDimensions(new GVector(3f, 4f));
            expected = new GVector(1f, 2f, 3f, 4f);

            result.AssertAreEqual(expected);
        }



        [Test]
        public void ToVector2()
        {
            GVector source;
            Vector2 result;


            // fits
            source = new GVector(1f, 2f);
            result = (Vector2)source;

            Assert.AreEqual(result.X, source[0]);
            Assert.AreEqual(result.Y, source[1]);


            // less
            source = new GVector(1f);
            result = (Vector2)source;

            Assert.AreEqual(result.X, source[0]);
            Assert.AreEqual(result.Y, 0f);


            // more
            source = new GVector(1f, 2f, 3f);
            result = (Vector2)source;

            Assert.AreEqual(result.X, source[0]);
            Assert.AreEqual(result.Y, source[1]);
        }

        [Test]
        public void ToVector3()
        {
            GVector source;
            Vector3 result;

            // fits
            source = new GVector(1f, 2f, 3f);
            result = (Vector3)source;

            Assert.AreEqual(result.X, source[0]);
            Assert.AreEqual(result.Y, source[1]);
            Assert.AreEqual(result.Z, source[2]);


            // less
            source = new GVector(1f, 2f);
            result = (Vector3)source;

            Assert.AreEqual(result.X, source[0]);
            Assert.AreEqual(result.Y, source[1]);
            Assert.AreEqual(result.Z, 0f);


            // more
            source = new GVector(1f, 2f, 3f, 4f);
            result = (Vector3)source;

            Assert.AreEqual(result.X, source[0]);
            Assert.AreEqual(result.Y, source[1]);
            Assert.AreEqual(result.Z, source[2]);
        }

        [Test]
        public void ToVector4()
        {
            GVector source;
            Vector4 result;

            
            // fits
            source = new GVector(1f, 2f, 3f, 4f);
            result = (Vector4)source;

            Assert.AreEqual(result.X, source[0]);
            Assert.AreEqual(result.Y, source[1]);
            Assert.AreEqual(result.Z, source[2]);
            Assert.AreEqual(result.W, source[3]);


            // less
            source = new GVector(1f, 2f, 3f);
            result = (Vector4)source;

            Assert.AreEqual(result.X, source[0]);
            Assert.AreEqual(result.Y, source[1]);
            Assert.AreEqual(result.Z, source[2]);
            Assert.AreEqual(result.W, 0f);


            // more
            source = new GVector(1f, 2f, 3f, 4f, 5f);
            result = (Vector4)source;

            Assert.AreEqual(result.X, source[0]);
            Assert.AreEqual(result.Y, source[1]);
            Assert.AreEqual(result.Z, source[2]);
            Assert.AreEqual(result.W, source[3]);
        }


        [Test]
        public void FromVector2()
        {
            var source = new Vector2(1f, 2f);
            var result = (GVector)source;

            Assert.AreEqual(result.Dimensions, 2);
            Assert.AreEqual(result[0], source.X);
            Assert.AreEqual(result[1], source.Y);
        }

        [Test]
        public void FromVector3()
        {
            var source = new Vector3(1f, 2f, 3f);
            var result = (GVector)source;

            Assert.AreEqual(result.Dimensions, 3);
            Assert.AreEqual(result[0], source.X);
            Assert.AreEqual(result[1], source.Y);
            Assert.AreEqual(result[2], source.Z);
        }

        [Test]
        public void FromVector4()
        {
            var source = new Vector4(1f, 2f, 3f, 4f);
            var result = (GVector)source;

            Assert.AreEqual(result.Dimensions, 4);
            Assert.AreEqual(result[0], source.X);
            Assert.AreEqual(result[1], source.Y);
            Assert.AreEqual(result[2], source.Z);
            Assert.AreEqual(result[3], source.W);
        }
    }
}
