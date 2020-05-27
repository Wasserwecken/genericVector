using System;
using System.Numerics;
using System.Globalization;
using System.Diagnostics;

namespace GenericVector
{
    [Serializable]
    [DebuggerDisplay("{ToString()}")]
    public struct Vector : IFormattable, IEquatable<Vector>
    {
        #region Properties
        public int Dimensions => Axes.Length;
        public float[] Axes { get; }
        public Vector One => new Vector(Dimensions, 1f);
        public Vector Zero => new Vector(Dimensions, 0f);
        public Vector Normalized => this / Magnitude;
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
        private void CheckAxisIndex(int selected)
        {
            if (selected < 0)
                throw new IndexOutOfRangeException("Selected axis cannot be negativ");

            if (selected >= Dimensions)
                throw new IndexOutOfRangeException("Selected axis has a higher dimension than the vector");
        }

        private void CheckAxisIndizes(int[] indizes)
        {
            if (indizes.Length > Dimensions)
                throw new IndexOutOfRangeException("More dimensions selected than the vector has");
        }

        public float this[int index]
        {
            get
            {
                CheckAxisIndex(index);
                return Axes[index];
            }
            set
            {
                CheckAxisIndex(index);
                Axes[index] = value;
            }
        }

        public Vector this[params int[] indizes]
        {
            get
            {
                CheckAxisIndizes(indizes);

                var result = new Vector(indizes.Length);
                for (int i = 0; i < indizes.Length; i++)
                    result[i] = Axes[indizes[i]];
                return result;
            }
            set
            {
                CheckAxisIndizes(indizes);

                var minDimension = Math.Min(indizes.Length, value.Dimensions);
                for (int i = 0; i < minDimension; i++)
                    Axes[indizes[i]] = value[i];
            }
        }
        #endregion


        #region Constructors
        public Vector(int dimensions)
        {
            if (dimensions <= 0)
                throw new ArgumentException("A vector needs at least one dimenson");

            Axes = new float[dimensions];
        }

        public Vector(params float[] values) : this(values.Length)
        {
            values.CopyTo(Axes, 0);
        }

        public Vector(Vector vector) : this(vector.Axes)
        {

        }

        public Vector(int dimensions, float value) : this(dimensions)
        {
            for (int i = 0; i < Dimensions; i++)
                Axes[i] = value;
        }

        public Vector(int dimensions, Vector values) : this(dimensions)
        {
            var minDimensions = Math.Min(Dimensions, values.Dimensions);
            for (int i = 0; i < minDimensions; i++)
                Axes[i] = values[i];
        }
        #endregion


        #region Arithmetic
        public static Vector operator +(Vector vectorA, Vector vectorB)
            => ForEachAxis(vectorA, vectorB, (axisA, axisB) => axisA + axisB);

        public static Vector operator +(Vector vector, float value)
            => ForEachAxis(vector, axis => axis + value);

        public static Vector operator +(float value, Vector vector)
            => ForEachAxis(vector, axis => value + axis);


        public static Vector operator -(Vector vectorA, Vector vectorB)
            => ForEachAxis(vectorA, vectorB, (axisA, axisB) => axisA - axisB);

        public static Vector operator -(Vector vector, float value)
            => ForEachAxis(vector, axis => axis - value);

        public static Vector operator -(float value, Vector vector)
            => ForEachAxis(vector, axis => value - axis);


        public static Vector operator *(Vector vectorA, Vector vectorB)
            => ForEachAxis(vectorA, vectorB, (axisA, axisB) => axisA * axisB);

        public static Vector operator *(Vector vector, float value)
            => ForEachAxis(vector, axis => axis * value);

        public static Vector operator *(float value, Vector vector)
            => ForEachAxis(vector, axis => value * axis);


        public static Vector operator /(Vector vectorA, Vector vectorB)
            => ForEachAxis(vectorA, vectorB, (axisA, axisB) => axisA / axisB);

        public static Vector operator /(Vector vector, float value)
            => ForEachAxis(vector, axis => axis / value);

        public static Vector operator /(float value, Vector vector)
            => ForEachAxis(vector, axis => value / axis);


        public static Vector operator %(Vector vectorA, Vector vectorB)
            => ForEachAxis(vectorA, vectorB, (axisA, axisB) => axisA % axisB);

        public static Vector operator %(Vector vector, float value)
            => ForEachAxis(vector, axis => axis % value);

        public static Vector operator %(float value, Vector vector)
            => ForEachAxis(vector, axis => value % axis);


        public static Vector operator -(Vector vector)
            => -1f * vector;

        public static Vector operator ++(Vector vector)
            => ForEachAxis(vector, axis => axis++);

        public static Vector operator --(Vector vector)
            => ForEachAxis(vector, axis => axis--);


        public static bool operator ==(Vector left, Vector right)
            => left.Equals(right);

        public static bool operator !=(Vector left, Vector right)
            => !(left == right);
        #endregion


        #region Float math
        public static Vector Abs(Vector vector)
            => ForEachAxis(vector, value => Math.Abs(value));

        public static Vector Ceil(Vector vector)
            => ForEachAxis(vector, value => (float)Math.Ceiling(value));

        public static Vector Clamp(Vector vector, Vector min, Vector max)
            => ForEachAxis(vector, (i, value) => Math.Max(min[i], Math.Min(max[i], value)));

        public static Vector Clamp(Vector vector, float min, float max)
            => ForEachAxis(vector, value => Math.Max(min, Math.Min(max, value)));

        public static Vector Exp(Vector vector, float ePower)
            => ForEachAxis(vector, value => (float)Math.Exp(ePower));

        public static Vector Floor(Vector vector)
            => ForEachAxis(vector, value => (float)Math.Floor(value));

        public static Vector Log(Vector vector)
            => ForEachAxis(vector, value => (float)Math.Log(value));

        public static Vector Log(Vector vector, Vector newBase)
            => ForEachAxis(vector, (i, value) => (float)Math.Log(value, newBase[i]));

        public static Vector Log(Vector vector, float newBase)
            => ForEachAxis(vector, value => (float)Math.Log(value, newBase));

        public static Vector Min(Vector vector, float min)
            => ForEachAxis(vector, value => Math.Min(value, min));

        public static Vector Min(Vector vector, Vector min)
            => ForEachAxis(vector, (i, value) => Math.Min(value, min[i]));

        public static Vector Max(Vector vector, float max)
            => ForEachAxis(vector, value => Math.Max(value, max));

        public static Vector Max(Vector vector, Vector max)
            => ForEachAxis(vector, (i, value) => Math.Min(value, max[i]));

        public static Vector Pow(Vector vector, Vector power)
            => ForEachAxis(vector, (i, value) => (float)Math.Pow(value, power[i]));

        public static Vector Pow(Vector vector, float power)
            => ForEachAxis(vector, value => (float)Math.Pow(value, power));

        public static Vector Sign(Vector vector)
            => ForEachAxis(vector, value => Math.Sign(value));

        public static Vector Sqrt(Vector vector)
            => ForEachAxis(vector, value => (float)Math.Sqrt(value));

        public static Vector Truncate(Vector vector)
            => ForEachAxis(vector, value => (float)Math.Truncate(value));

        #region Trigonometry
        public static Vector Sin(Vector vector)
            => ForEachAxis(vector, value => (float)Math.Sin(value));

        public static Vector Cos(Vector vector)
            => ForEachAxis(vector, value => (float)Math.Cos(value));

        public static Vector Tan(Vector vector)
            => ForEachAxis(vector, value => (float)Math.Tan(value));

        public static Vector Asin(Vector vector)
            => ForEachAxis(vector, value => (float)Math.Asin(value));

        public static Vector Acos(Vector vector)
            => ForEachAxis(vector, value => (float)Math.Acos(value));

        public static Vector Atan(Vector vector)
            => ForEachAxis(vector, value => (float)Math.Atan(value));

        public static Vector Atan2(Vector vector, Vector other)
            => ForEachAxis(vector, (i, value) => (float)Math.Atan2(value, other[i]));

        public static Vector Atan2(Vector vector, float other)
            => ForEachAxis(vector, value => (float)Math.Atan2(value, other));
        #endregion
        #endregion


        #region Vector math
        public static Vector ClampToMagnitude(Vector vector, float max)
            => vector.MagnitudeSquared > max * max ? vector.Normalized * max : new Vector(vector);

        public static float Distance(Vector vectorA, Vector vectorB)
            => (vectorA - vectorB).Magnitude;

        public static float DistanceSquared(Vector vectorA, Vector vectorB)
            => (vectorA - vectorB).MagnitudeSquared;

        public static Vector Lerp(Vector vectorA, Vector vectorB, Vector t)
        {
            var minDimensions = Math.Min(t.Dimensions, Math.Min(vectorA.Dimensions, vectorB.Dimensions));
            var result = new Vector(minDimensions);
            for (int i = 0; i < minDimensions; i++)
                result[i] = (1f - t[i]) * vectorA[i] + t[i] * vectorB[i];

            return result;
        }

        public static Vector Lerp(Vector vectorA, Vector vectorB, float t)
            => ForEachAxis(vectorA, vectorB, (i, valueA, valueB) => (1f - t) * valueA + t * valueB);

        public static Vector Reflect(Vector vector, Vector normal)
            => vector - normal * 2f * Dot(normal, vector);

        public static float Dot(Vector vectorA, Vector vectorB)
        {
            var minDimensions = Math.Min(vectorA.Dimensions, vectorB.Dimensions);
            var result = vectorA[0] * vectorB[0];
            for (int i = 1; i < minDimensions; i++)
                result += vectorA[i] * vectorB[i];

            return result;
        }

        public Vector MoveTowards(Vector target, float delta)
        {
            var diff = -this + target;
            float magnitude = diff.Magnitude;
            if (magnitude <= delta || delta == 0)
                return new Vector(target);
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


        #region Casting
        public Vector ToDimension(int newDimension)
        {
            return new Vector(newDimension, this);
        }

        public Vector ToDimension(int newDimension, float defaultValue)
        {
            var result = ToDimension(newDimension);

            for (int i = Dimensions; i < result.Dimensions; i++)
                result[i] = defaultValue;

            return result;
        }

        public Vector Merge(Vector vector)
        {
            return Merge(vector.Axes);
        }

        public Vector Merge(params float[] axes)
        {
            if (axes.Length <= Dimensions)
                return new Vector(this);

            var result = new Vector(axes.Length, this);
            for (int i = Dimensions; i < axes.Length; i++)
                result[i] = axes[i];

            return result;
        }

        public Vector AddDimensions(Vector vector)
        {
            return AddDimensions(vector.Axes);
        }

        public Vector AddDimensions(params float[] values)
        {
            var result = new Vector(Dimensions + values.Length, this);
            for (int i = Dimensions; i < result.Dimensions; i++)
                result[i] = values[i - Dimensions];

            return result;
        }

        public static explicit operator Vector2(Vector vector)
        {
            var casted = vector.ToDimension(2);
            return new Vector2(casted[0], casted[1]);
        }

        public static explicit operator Vector(Vector2 vector)
        {
            return new Vector(vector.X, vector.Y);
        }

        public static explicit operator Vector3(Vector vector)
        {
            var casted = vector.ToDimension(3);
            return new Vector3(casted[0], casted[1], casted[2]);
        }

        public static explicit operator Vector(Vector3 vector)
        {
            return new Vector(vector.X, vector.Y, vector.Z);
        }

        public static explicit operator Vector4(Vector vector)
        {
            var casted = vector.ToDimension(4);
            return new Vector4(casted[0], casted[1], casted[2], casted[3]);
        }

        public static explicit operator Vector(Vector4 vector)
        {
            return new Vector(vector.X, vector.Y, vector.Z, vector.W);
        }
        #endregion


        #region Comparision
        public override int GetHashCode()
        {
            return Axes.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector)
                return Equals((Vector)obj);
            else
                return false;
        }

        public bool Equals(Vector other)
        {
            if (other == null || Dimensions != other.Dimensions)
                return false;

            if ((this - other).MagnitudeSquared >= float.Epsilon + float.Epsilon)
                return false;
            else
                return true;
        }
        #endregion


        #region Helper
        public static Vector ForEachAxis(Vector vector, Func<float, float> operation)
        {
            return ForEachAxis(vector, (i, axis) => operation(axis));
        }

        public static Vector ForEachAxis(Vector vector, Func<int, float, float> operation)
        {
            var result = new Vector(vector);
            for (int i = 0; i < result.Dimensions; i++)
                result[i] = operation(i, result[i]);

            return result;
        }

        public static Vector ForEachAxis(Vector vectorA, Vector vectorB, Func<float, float, float> operation)
        {
            return ForEachAxis(vectorA, vectorB, (i, axisA, axisB) => operation(axisA, axisB));
        }

        public static Vector ForEachAxis(Vector vectorA, Vector vectorB, Func<int, float, float, float> operation)
        {
            var minDimensions = Math.Min(vectorA.Dimensions, vectorB.Dimensions);
            var result = new Vector(minDimensions);
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
