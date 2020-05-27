using GenericVector;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class VectorCastingTests
    {
        [Test]
        public void ToDimension()
        {
            Vector result;

            // to lower
            result = new Vector(1f, 2f).ToDimension(1);

            Assert.AreEqual(1, result.Dimensions);
            Assert.AreEqual(1f, result[0]);


            // to higher
            result = new Vector(1f, 2f).ToDimension(3);

            Assert.AreEqual(3, result.Dimensions);
            Assert.AreEqual(1f, result[0]);
            Assert.AreEqual(2f, result[1]);
            Assert.AreEqual(0f, result[2]);
        }

        [Test]
        public void ToDimension_WithDefault()
        {
            Vector result;

            // to lower
            result = new Vector(1f, 2f).ToDimension(1, 3f);

            Assert.AreEqual(1, result.Dimensions);
            Assert.AreEqual(1f, result[0]);


            // to higher
            result = new Vector(1f, 2f).ToDimension(3, 3f);

            Assert.AreEqual(3, result.Dimensions);
            Assert.AreEqual(1f, result[0]);
            Assert.AreEqual(2f, result[1]);
            Assert.AreEqual(3f, result[2]);
        }

        [Test]
        public void Merge()
        {
            Vector result;

            // empty
            result = new Vector(1f, 2f).Merge(new float[] { });

            Assert.AreEqual(2, result.Dimensions);
            Assert.AreEqual(1f, result[0]);
            Assert.AreEqual(2f, result[1]);


            // with lower
            result = new Vector(1f, 2f).Merge(new Vector(3f));

            Assert.AreEqual(2, result.Dimensions);
            Assert.AreEqual(1f, result[0]);
            Assert.AreEqual(2f, result[1]);


            // with higher
            result = new Vector(1f, 2f).Merge(new Vector(5f, 4f, 3f));

            Assert.AreEqual(3, result.Dimensions);
            Assert.AreEqual(1f, result[0]);
            Assert.AreEqual(2f, result[1]);
            Assert.AreEqual(3f, result[2]);
        }


        [Test]
        public void AddDimensions()
        {
            Vector result;


            // empty
            result = new Vector(1f, 2f).AddDimensions(new float[] { });

            Assert.AreEqual(2, result.Dimensions);
            Assert.AreEqual(1f, result[0]);
            Assert.AreEqual(2f, result[1]);


            // new axes
            result = new Vector(1f, 2f).AddDimensions(new Vector(3f));

            Assert.AreEqual(3, result.Dimensions);
            Assert.AreEqual(1f, result[0]);
            Assert.AreEqual(2f, result[1]);
            Assert.AreEqual(3f, result[2]);
        }



        [Test]
        public void ToVector2()
        {
            System.Numerics.Vector2 result;

            // fits
            result = (System.Numerics.Vector2)new Vector(1f, 2f);

            Assert.AreEqual(1f, result.X);
            Assert.AreEqual(2f, result.Y);


            // less
            result = (System.Numerics.Vector2)new Vector(1f);

            Assert.AreEqual(1f, result.X);
            Assert.AreEqual(0f, result.Y);


            // more
            result = (System.Numerics.Vector2)new Vector(1f, 2f, 3f);

            Assert.AreEqual(1f, result.X);
            Assert.AreEqual(2f, result.Y);
        }

        [Test]
        public void ToVector3()
        {
            System.Numerics.Vector3 result;

            // fits
            result = (System.Numerics.Vector3)new Vector(1f, 2f, 3f);

            Assert.AreEqual(1f, result.X);
            Assert.AreEqual(2f, result.Y);
            Assert.AreEqual(3f, result.Z);


            // less
            result = (System.Numerics.Vector3)new Vector(1f, 2f);

            Assert.AreEqual(1f, result.X);
            Assert.AreEqual(2f, result.Y);
            Assert.AreEqual(0f, result.Z);


            // more
            result = (System.Numerics.Vector3)new Vector(1f, 2f, 3f, 4f);

            Assert.AreEqual(1f, result.X);
            Assert.AreEqual(2f, result.Y);
            Assert.AreEqual(3f, result.Z);
        }

        [Test]
        public void ToVector4()
        {
            System.Numerics.Vector4 result;
            
            // fits
            result = (System.Numerics.Vector4)new Vector(1f, 2f, 3f, 4f);

            Assert.AreEqual(1f, result.X);
            Assert.AreEqual(2f, result.Y);
            Assert.AreEqual(3f, result.Z);
            Assert.AreEqual(4f, result.W);


            // less
            result = (System.Numerics.Vector4)new Vector(1f, 2f, 3f);

            Assert.AreEqual(1f, result.X);
            Assert.AreEqual(2f, result.Y);
            Assert.AreEqual(3f, result.Z);
            Assert.AreEqual(0f, result.W);


            // more
            result = (System.Numerics.Vector4)new Vector(1f, 2f, 3f, 4f, 5f);

            Assert.AreEqual(1f, result.X);
            Assert.AreEqual(2f, result.Y);
            Assert.AreEqual(3f, result.Z);
            Assert.AreEqual(4f, result.W);
        }


        [Test]
        public void FromVector2()
        {
            var result = (Vector)new System.Numerics.Vector2(1f, 2f);

            Assert.AreEqual(result.Dimensions, 2);
            Assert.AreEqual(1f, result[0]);
            Assert.AreEqual(2f, result[1]);
        }

        [Test]
        public void FromVector3()
        {
            var result = (Vector)new System.Numerics.Vector3(1f, 2f, 3f);

            Assert.AreEqual(result.Dimensions, 3);
            Assert.AreEqual(1f, result[0]);
            Assert.AreEqual(2f, result[1]);
            Assert.AreEqual(3f, result[2]);
        }

        [Test]
        public void FromVector4()
        {
            var result = (Vector)new System.Numerics.Vector4(1f, 2f, 3f, 4f);

            Assert.AreEqual(result.Dimensions, 4);
            Assert.AreEqual(1f, result[0]);
            Assert.AreEqual(2f, result[1]);
            Assert.AreEqual(3f, result[2]);
            Assert.AreEqual(4f, result[3]);
        }
    }
}