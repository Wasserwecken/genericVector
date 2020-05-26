using System;
using System.Globalization;

namespace GenericVector
{
    [Serializable]
    public struct GVector : IFormattable, IEquatable<GVector>
    {
        #region Properties
        public int Dimensions => Axes.Length;
        public float[] Axes { get; }
        public GVector One => new GVector(Dimensions, 1f);
        public GVector Zero => new GVector(Dimensions, 0f);
        public GVector Normalized => this / Magnitude;
        public float Magnitude => (float)Math.Sqrt(MagnitudeSquared);
        public float MagnitudeSquared
        {
            get
            {
                var length = Axes[0];
                for (int i = 1; i < Dimensions; i++)
                    length += Axes[i] * Axes[i];

                return length;
            }
        }
        public float MagnitudeManhattan
        {
            get
            {
                var length = Axes[0];
                for (int i = 1; i < Dimensions; i++)
                    length += Math.Abs(Axes[i]);

                return length;
            }
        }
        #endregion


        #region Indexer
        public float this[int selected]
        {
            get { return Axes[selected]; }
            set { Axes[selected] = value; }
        }
        public GVector this[params int[] selected]
        {
            get
            {
                if (selected.Length > Dimensions)
                    throw new IndexOutOfRangeException("More dimensions selected than the vector has");

                var result = new GVector(selected.Length);
                for (int i = 0; i < selected.Length; i++)
                    result[i] = Axes[selected[i]];
                return result;
            }
            set
            {
                if (selected.Length > Dimensions)
                    throw new IndexOutOfRangeException("More dimensions selected than the vector has");

                for (int i = 0; i < selected.Length; i++)
                    Axes[selected[i]] = value[i];
            }
        }
        #endregion


        #region Constructors
        public GVector(params float[] values)
        {
            Axes = new float[values.Length];
            values.CopyTo(Axes, 0);
        }

        public GVector(GVector vector) : this(vector.Axes)
        {

        }

        public GVector(int dimensions) : this(new float[dimensions])
        {

        }

        public GVector(int dimensions, float value) : this(dimensions)
        {
            for (int i = 0; i < Dimensions; i++)
                Axes[i] = value;
        }

        public GVector(int dimensions, GVector values) : this(dimensions)
        {
            dimensions = Math.Min(Dimensions, values.Dimensions);
            for (int i = 0; i < dimensions; i++)
                Axes[i] = values[i];
        }
        #endregion


        #region Arithmetic
        public static GVector operator +(GVector vectorA, GVector vectorB)
            => ForEachAxis(vectorA, vectorB, (axisA, axisB) => axisA + axisB);

        public static GVector operator +(GVector vector, float value)
            => ForEachAxis(vector, axis => axis + value);

        public static GVector operator +(float value, GVector vector)
            => ForEachAxis(vector, axis => value + axis);


        public static GVector operator -(GVector vectorA, GVector vectorB)
            => ForEachAxis(vectorA, vectorB, (axisA, axisB) => axisA - axisB);

        public static GVector operator -(GVector vector, float value)
            => ForEachAxis(vector, axis => axis - value);

        public static GVector operator -(float value, GVector vector)
            => ForEachAxis(vector, axis => value - axis);


        public static GVector operator *(GVector vectorA, GVector vectorB)
            => ForEachAxis(vectorA, vectorB, (axisA, axisB) => axisA * axisB);

        public static GVector operator *(GVector vector, float value)
            => ForEachAxis(vector, axis => axis * value);

        public static GVector operator *(float value, GVector vector)
            => ForEachAxis(vector, axis => value * axis);


        public static GVector operator /(GVector vectorA, GVector vectorB)
            => ForEachAxis(vectorA, vectorB, (axisA, axisB) => axisA / axisB);

        public static GVector operator /(GVector vector, float value)
            => ForEachAxis(vector, axis => axis / value);

        public static GVector operator /(float value, GVector vector)
            => ForEachAxis(vector, axis => value / axis);


        public static GVector operator %(GVector vectorA, GVector vectorB)
            => ForEachAxis(vectorA, vectorB, (axisA, axisB) => axisA % axisB);

        public static GVector operator %(GVector vector, float value)
            => ForEachAxis(vector, axis => axis % value);

        public static GVector operator %(float value, GVector vector)
            => ForEachAxis(vector, axis => value % axis);


        public static GVector operator -(GVector vector)
            => -1f * vector;

        public static GVector operator ++(GVector vector)
            => ForEachAxis(vector, axis => axis++);

        public static GVector operator --(GVector vector)
            => ForEachAxis(vector, axis => axis--);


        public static bool operator ==(GVector left, GVector right)
            => left.Equals(right);

        public static bool operator !=(GVector left, GVector right)
            => !(left == right);
        #endregion


        #region Float math
        public static GVector Abs(GVector vector)
            => ForEachAxis(vector, value => Math.Abs(value));

        public static GVector Ceil(GVector vector)
            => ForEachAxis(vector, value => (float)Math.Ceiling(value));

        public static GVector Clamp(GVector vector, GVector min, GVector max)
            => ForEachAxis(vector, (i, value) => Math.Max(min[i], Math.Min(max[i], value)));

        public static GVector Clamp(GVector vector, float min, float max)
            => ForEachAxis(vector, value => Math.Max(min, Math.Min(max, value)));

        public static GVector Exp(GVector vector, float ePower)
            => ForEachAxis(vector, value => (float)Math.Exp(ePower));

        public static GVector Floor(GVector vector)
            => ForEachAxis(vector, value => (float)Math.Floor(value));

        public static GVector Log(GVector vector)
            => ForEachAxis(vector, value => (float)Math.Log(value));

        public static GVector Log(GVector vector, GVector newBase)
            => ForEachAxis(vector, (i, value) => (float)Math.Log(value, newBase[i]));

        public static GVector Log(GVector vector, float newBase)
            => ForEachAxis(vector, value => (float)Math.Log(value, newBase));

        public static GVector Min(GVector vector, float min)
            => ForEachAxis(vector, value => Math.Min(value, min));

        public static GVector Min(GVector vector, GVector min)
            => ForEachAxis(vector, (i, value) => Math.Min(value, min[i]));

        public static GVector Max(GVector vector, float max)
            => ForEachAxis(vector, value => Math.Max(value, max));

        public static GVector Max(GVector vector, GVector max)
            => ForEachAxis(vector, (i, value) => Math.Min(value, max[i]));

        public static GVector Pow(GVector vector, GVector power)
            => ForEachAxis(vector, (i, value) => (float)Math.Pow(value, power[i]));

        public static GVector Pow(GVector vector, float power)
            => ForEachAxis(vector, value => (float)Math.Pow(value, power));

        public static GVector Sign(GVector vector)
            => ForEachAxis(vector, value => Math.Sign(value));

        public static GVector Sqrt(GVector vector)
            => ForEachAxis(vector, value => (float)Math.Sqrt(value));

        public static GVector Truncate(GVector vector)
            => ForEachAxis(vector, value => (float)Math.Truncate(value));

        #region Trigonometry
        public static GVector Sin(GVector vector)
            => ForEachAxis(vector, value => (float)Math.Sin(value));

        public static GVector Cos(GVector vector)
            => ForEachAxis(vector, value => (float)Math.Cos(value));

        public static GVector Tan(GVector vector)
            => ForEachAxis(vector, value => (float)Math.Tan(value));

        public static GVector Asin(GVector vector)
            => ForEachAxis(vector, value => (float)Math.Asin(value));

        public static GVector Acos(GVector vector)
            => ForEachAxis(vector, value => (float)Math.Acos(value));

        public static GVector Atan(GVector vector)
            => ForEachAxis(vector, value => (float)Math.Atan(value));

        public static GVector Atan2(GVector vector, GVector other)
            => ForEachAxis(vector, (i, value) => (float)Math.Atan2(value, other[i]));

        public static GVector Atan2(GVector vector, float other)
            => ForEachAxis(vector, value => (float)Math.Atan2(value, other));
        #endregion
        #endregion


        #region Vector math
        public static GVector ClampMagnitude(GVector vector, float max)
            => vector.MagnitudeSquared > max * max ? vector.Normalized * max : new GVector(vector);

        public static float Distance(GVector vectorA, GVector vectorB)
            => (vectorA - vectorB).Magnitude;

        public static float DistanceSquared(GVector vectorA, GVector vectorB)
            => (vectorA - vectorB).MagnitudeSquared;

        public static GVector Lerp(GVector vectorA, GVector vectorB, GVector t)
        {
            var result = new GVector(vectorA);
            var dimensions = Math.Min(t.Dimensions, Math.Min(vectorA.Dimensions, vectorB.Dimensions));
            for (int i = 0; i < dimensions; i++)
                result[i] = (1f - t[i]) * vectorA[i] + t[i] * vectorB[i];

            return result;
        }

        public static GVector Lerp(GVector vectorA, GVector vectorB, float t)
            => ForEachAxis(vectorA, vectorB, (i, valueA, valueB) => (1f - t) * valueA + t * valueB);

        public static GVector Reflect(GVector vector, GVector normal)
            => vector - normal * 2f * Dot(normal, vector);

        public static float Dot(GVector vectorA, GVector vectorB)
        {
            var result = vectorA[0] * vectorB[0];
            var dimensions = Math.Min(vectorA.Dimensions, vectorB.Dimensions);
            for (int i = 1; i < dimensions; i++)
                result += vectorA[i] * vectorB[i];

            return result;
        }

        public GVector MoveTowards(GVector target, float delta)
        {
            var diff = -this + target;
            float magnitude = diff.Magnitude;
            if (magnitude <= delta || delta == 0)
                return new GVector(target);
            return this + diff / magnitude * delta;
        }
        #endregion


        #region ToString
        public override string ToString()
        {
            return ToString(value => value.ToString(CultureInfo.InvariantCulture));
        }

        public string ToString(string format)
        {
            return ToString(value => value.ToString(format));
        }

        public string ToString(IFormatProvider formatProvider)
        {
            return ToString(value => value.ToString(formatProvider));
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return ToString(value => value.ToString(format, formatProvider));
        }
        #endregion


        #region Comparision
        public override int GetHashCode()
        {
            return Axes.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is GVector)
                return Equals((GVector)obj);
            else
                return false;
        }

        public bool Equals(GVector other)
        {
            if (other == null || Dimensions != other.Dimensions)
                return false;

            if ((this - other).MagnitudeSquared >= float.Epsilon * float.Epsilon)
                return false;
            else
                return true;
        }
        #endregion


        #region Helper
        public static GVector ForEachAxis(GVector vector, Func<float, float> operation)
        {
            return ForEachAxis(vector, (i, axis) => operation(axis));
        }

        public static GVector ForEachAxis(GVector vector, Func<int, float, float> operation)
        {
            var result = new GVector(vector);
            for (int i = 0; i < result.Dimensions; i++)
                result[i] = operation(i, result[i]);

            return result;
        }

        public static GVector ForEachAxis(GVector vectorA, GVector vectorB, Func<float, float, float> operation)
        {
            return ForEachAxis(vectorA, vectorB, (i, axisA, axisB) => operation(axisA, axisB));
        }

        public static GVector ForEachAxis(GVector vectorA, GVector vectorB, Func<int, float, float, float> operation)
        {
            var minDimensions = Math.Min(vectorA.Dimensions, vectorB.Dimensions);
            var result = new GVector(minDimensions);
            for (int i = 0; i < minDimensions; i++)
                result[i] = operation(i, vectorA[i], vectorB[i]);

            return result;
        }

        public string ToString(Func<float, string> converter)
        {
            var values = new string[Axes.Length];
            for (int i = 0; i < Axes.Length; i++)
                values[i] = converter(Axes[i]);

            return $"({string.Join(", ", values)})";
        }
        #endregion
    }
}
