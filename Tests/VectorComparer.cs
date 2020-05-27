using GenericVector;
using NUnit.Framework;

namespace Tests
{
    public static class VectorComparer
    {
        public static void AssertAreEqual(this Vector result, Vector expected)
        {
            // check dimension
            Assert.AreEqual(expected.Dimensions, result.Dimensions);

            // check each axis value
            for (int i = 0; i < result.Dimensions; i++)
                Assert.AreEqual(expected[i], result[i]);
        }
    }
}
