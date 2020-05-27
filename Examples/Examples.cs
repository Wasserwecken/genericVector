using GenericVector;
using System;
using System.Numerics;

namespace Examples
{
    public class Examples
    {
        static void Main()
        {
            Inits();
            BasicArithmetics();
            FloatMath();
            VectorMath();
            Casting();

            Console.ReadKey();
        }

        private static void Inits()
        {
            Console.WriteLine("\nInitialisations");

            var vector5 = new GenericVector.Vector(5);
            Console.WriteLine(vector5);

            var vector4 = new GenericVector.Vector(3f, 5f, 7f, 2f);
            Console.WriteLine(vector4);

            var vector3 = new GenericVector.Vector(3, 2f);
            Console.WriteLine(vector3);
        }

        private static void BasicArithmetics()
        {
            Console.WriteLine("\nBasic arithmetics");

            var vector3 = new GenericVector.Vector(1f, 2f, 3f);
            var vector2 = new GenericVector.Vector(4f, 5f);

            var resultA = vector2 + vector3;
            Console.WriteLine(resultA);

            var resultB = vector3 - vector2;
            Console.WriteLine(resultB);

            var resultC = vector2 % vector3;
            Console.WriteLine(resultC);
        }

        private static void FloatMath()
        {
            Console.WriteLine("\nFloat math");

            var vector = new GenericVector.Vector(3f, -5f, 7f, -11f, 13f);
            GenericVector.Vector result;

            result = GenericVector.Vector.Sin(vector);
            Console.WriteLine(result);

            result = GenericVector.Vector.Sign(vector);
            Console.WriteLine(result);

            result = GenericVector.Vector.Min(vector, 0f);
            Console.WriteLine(result);
        }

        private static void VectorMath()
        {
            Console.WriteLine("\nVector math");

            var vector2 = new GenericVector.Vector(new float[] { 1f, 2f });
            var vector4 = new GenericVector.Vector(new float[] { 3f, 4f, 5f, 6f });
            GenericVector.Vector resultVector;
            float resultFloat;

            resultVector = GenericVector.Vector.ClampToMagnitude(vector2, 0.5f);
            Console.WriteLine(resultVector);

            resultVector = GenericVector.Vector.Lerp(vector4, vector2, 0.5f);
            Console.WriteLine(resultVector);

            resultFloat = GenericVector.Vector.Dot(vector2, vector4);
            Console.WriteLine(resultFloat);

            resultFloat = GenericVector.Vector.Distance(vector4, vector2);
            Console.WriteLine(resultFloat);
        }

        private static void Casting()
        {
            Console.WriteLine("\nCasting");

            var vector3 = new GenericVector.Vector(3f, 5f, 7f);
            var vector2 = new GenericVector.Vector(1f, 2f);
            GenericVector.Vector resultVector;
            float resultFloat;

            // excludes the third dimension, distance of a 2D perspective
            resultFloat = GenericVector.Vector.Distance(vector2, vector3);
            Console.WriteLine(resultFloat);

            // includes the third dimension, distance of a 3D perspective
            resultFloat = GenericVector.Vector.Distance(vector2.ToDimension(3), vector3);
            Console.WriteLine(resultFloat);


            // AddDimensions recovers lost dimensions
            resultVector = GenericVector.Vector.Lerp(vector2, vector3, 0.5f).IncludeDimensions(vector3);
            Console.WriteLine(resultVector);

            // downcast to a lower dimension
            resultVector = vector3.ToDimension(2);
            Console.WriteLine(resultVector);


            // cast from System.Numerics.Vector2
            GenericVector.Vector vectorFrom = (GenericVector.Vector)new Vector2();
            Console.WriteLine(vectorFrom);

            // cast to System.Numerics.Vector4
            Vector4 vectorTo = (Vector4)new GenericVector.Vector(4);
            Console.WriteLine(vectorTo);
        }
    }
}
