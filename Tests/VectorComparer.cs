using GenericVector;
using NUnit.Framework;

namespace Tests
{
    public static class VectorComparer
    {
        public static void AssertAreEqual(this Vector result, Vector expected)
        {
            // check dimension
            Assert.AreEqual(result.Dimensions, expected.Dimensions);

            // check each axis value
            for (int i = 0; i < result.Dimensions; i++)
                Assert.AreEqual(result[i], expected[i]);
        }
    }
}
