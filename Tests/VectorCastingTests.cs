﻿using GenericVector;
using NUnit.Framework;
using System;
using System.Numerics;

namespace Tests
{
    [TestFixture]
    public class VectorCastingTests
    {
        [Test]
        public void ToDimension()
        {
            GenericVector.Vector result;
            GenericVector.Vector expected;


            // to lower
            result = new GenericVector.Vector(1f, 2f).ToDimension(1);
            expected = new GenericVector.Vector(1f);

            result.AssertAreEqual(expected);


            // to higher
            result = new GenericVector.Vector(1f, 2f).ToDimension(3);
            expected = new GenericVector.Vector(1f, 2f, 0f);

            result.AssertAreEqual(expected);
        }

        [Test]
        public void ToDimension_WithDefault()
        {
            GenericVector.Vector result;
            GenericVector.Vector expected;


            // to lower
            result = new GenericVector.Vector(1f, 2f).ToDimension(1, 3f);
            expected = new GenericVector.Vector(1f);

            result.AssertAreEqual(expected);


            // to higher
            result = new GenericVector.Vector(1f, 2f).ToDimension(3, 3f);
            expected = new GenericVector.Vector(1f, 2f, 3f);

            result.AssertAreEqual(expected);
        }

        [Test]
        public void Merge()
        {
            GenericVector.Vector result;
            GenericVector.Vector expected;


            // empty
            result = new GenericVector.Vector(1f, 2f).Merge(new float[] { });
            expected = new GenericVector.Vector(1f, 2f);

            result.AssertAreEqual(expected);


            // with lower
            result = new GenericVector.Vector(1f, 2f).Merge(new GenericVector.Vector(1f));
            expected = new GenericVector.Vector(1f, 2f);

            result.AssertAreEqual(expected);


            // with higher
            result = new GenericVector.Vector(1f, 2f).Merge(new GenericVector.Vector(1f, 2f, 3f));
            expected = new GenericVector.Vector(1f, 2f, 3f);

            result.AssertAreEqual(expected);
        }


        [Test]
        public void AddDimensions()
        {
            GenericVector.Vector result;
            GenericVector.Vector expected;


            // empty
            result = new GenericVector.Vector(1f, 2f).AddDimensions(new float[] { });
            expected = new GenericVector.Vector(1f, 2f);

            result.AssertAreEqual(expected);


            // new axes
            result = new GenericVector.Vector(1f, 2f).AddDimensions(new GenericVector.Vector(3f, 4f));
            expected = new GenericVector.Vector(1f, 2f, 3f, 4f);

            result.AssertAreEqual(expected);
        }



        [Test]
        public void ToVector2()
        {
            GenericVector.Vector source;
            Vector2 result;


            // fits
            source = new GenericVector.Vector(1f, 2f);
            result = (Vector2)source;

            Assert.AreEqual(source[0], result.X);
            Assert.AreEqual(source[1], result.Y);


            // less
            source = new GenericVector.Vector(1f);
            result = (Vector2)source;

            Assert.AreEqual(source[0], result.X);
            Assert.AreEqual(0f, result.Y);


            // more
            source = new GenericVector.Vector(1f, 2f, 3f);
            result = (Vector2)source;

            Assert.AreEqual(source[0], result.X);
            Assert.AreEqual(source[1], result.Y);
        }

        [Test]
        public void ToVector3()
        {
            GenericVector.Vector source;
            Vector3 result;

            // fits
            source = new GenericVector.Vector(1f, 2f, 3f);
            result = (Vector3)source;

            Assert.AreEqual(source[0], result.X);
            Assert.AreEqual(source[1], result.Y);
            Assert.AreEqual(source[2], result.Z);


            // less
            source = new GenericVector.Vector(1f, 2f);
            result = (Vector3)source;

            Assert.AreEqual(source[0], result.X);
            Assert.AreEqual(source[1], result.Y);
            Assert.AreEqual(0f, result.Z);


            // more
            source = new GenericVector.Vector(1f, 2f, 3f, 4f);
            result = (Vector3)source;

            Assert.AreEqual(source[0], result.X);
            Assert.AreEqual(source[1], result.Y);
            Assert.AreEqual(source[2], result.Z);
        }

        [Test]
        public void ToVector4()
        {
            GenericVector.Vector source;
            Vector4 result;

            
            // fits
            source = new GenericVector.Vector(1f, 2f, 3f, 4f);
            result = (Vector4)source;

            Assert.AreEqual(source[0], result.X);
            Assert.AreEqual(source[1], result.Y);
            Assert.AreEqual(source[2], result.Z);
            Assert.AreEqual(source[3], result.W);


            // less
            source = new GenericVector.Vector(1f, 2f, 3f);
            result = (Vector4)source;

            Assert.AreEqual(source[0], result.X);
            Assert.AreEqual(source[1], result.Y);
            Assert.AreEqual(source[2], result.Z);
            Assert.AreEqual(0f, result.W);


            // more
            source = new GenericVector.Vector(1f, 2f, 3f, 4f, 5f);
            result = (Vector4)source;

            Assert.AreEqual(source[0], result.X);
            Assert.AreEqual(source[1], result.Y);
            Assert.AreEqual(source[2], result.Z);
            Assert.AreEqual(source[3], result.W);
        }


        [Test]
        public void FromVector2()
        {
            var source = new Vector2(1f, 2f);
            var result = (GenericVector.Vector)source;

            Assert.AreEqual(result.Dimensions, 2);
            Assert.AreEqual(source.X, result[0]);
            Assert.AreEqual(source.Y, result[1]);
        }

        [Test]
        public void FromVector3()
        {
            var source = new Vector3(1f, 2f, 3f);
            var result = (GenericVector.Vector)source;

            Assert.AreEqual(result.Dimensions, 3);
            Assert.AreEqual(source.X, result[0]);
            Assert.AreEqual(source.Y, result[1]);
            Assert.AreEqual(source.Z, result[2]);
        }

        [Test]
        public void FromVector4()
        {
            var source = new Vector4(1f, 2f, 3f, 4f);
            var result = (GenericVector.Vector)source;

            Assert.AreEqual(result.Dimensions, 4);
            Assert.AreEqual(source.X, result[0]);
            Assert.AreEqual(source.Y, result[1]);
            Assert.AreEqual(source.Z, result[2]);
            Assert.AreEqual(source.W, result[3]);
        }
    }
}
