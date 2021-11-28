namespace AdventOfCode2021.Utils
{
    public class Vector
    {
        /// <summary>
        /// Gets the X component of this <see cref="Vector"/>.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Gets the Y component of this <see cref="Vector"/>.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Gets the Z component of this <see cref="Vector"/>.
        /// </summary>
        public int Z { get; }

        /// <summary>
        /// Gets the W component of this <see cref="Vector"/>.
        /// </summary>
        public int W { get; }

        public Vector(int x, int y, int z = 0, int w = 0)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Adds the components of two <see cref="Vector"/>s.
        /// </summary>
        /// <param name="a">First <see cref="Vector"/> to use.</param>
        /// <param name="b">Second <see cref="Vector"/> to use.</param>
        /// <returns>A new <see cref="Vector"/> with the added components of the two parameters.</returns>
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X+b.X, a.Y+b.Y, a.Z+b.Z, a.W + b.W);
        }

        /// <summary>
        /// Subtracts the components of two <see cref="Vector"/>s.
        /// </summary>
        /// <param name="a">First <see cref="Vector"/> to use.</param>
        /// <param name="b">Second <see cref="Vector"/> to use.</param>
        /// <returns>A new <see cref="Vector"/> with the subtracted components of the two parameters.</returns>
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
        }

        /// <summary>
        /// Multiplies the components of a <see cref="Vector"/> with a scalar.
        /// </summary>
        /// <param name="vector"><see cref="Vector"/> to use.</param>
        /// <param name="scalar">Scalar to multiply <paramref name="vector"/> with.</param>
        /// <returns>A new <see cref="Vector"/> with the components multiplied with the given scalar.</returns>
        public static Vector operator *(Vector vector, int scalar)
        {
            return new Vector(vector.X * scalar, vector.Y * scalar, vector.Z * scalar, vector.W * scalar);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"({X},{Y},{Z},{W})";
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            var other = (Vector)obj;

            if (other == null)
            {
                return false;
            }

            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode() + W.GetHashCode();
        }

        /// <summary>
        /// Gets a vector representing moving one step north.
        /// </summary>
        public static Vector North => new(0, 1);

        /// <summary>
        /// Gets a vector representing moving one step south.
        /// </summary>
        public static Vector South => new(0, -1);

        /// <summary>
        /// Gets a vector representing moving one step west.
        /// </summary>
        public static Vector West => new(-1, 0);

        /// <summary>
        /// Gets a vector representing moving one step east.
        /// </summary>
        public static Vector East => new(1, 0);

        /// <summary>
        /// Gets a vector representing moving one step up.
        /// </summary>
        public static Vector Up => new(0, 0, 1);

        /// <summary>
        /// Gets a vector representing moving one step down.
        /// </summary>
        public static Vector Down => new(0, 0, -1);

        /// <summary>
        /// Gets a vector representing moving one step "hyper north".
        /// </summary>
        public static Vector HyperNorth => new(0, 0, 0, 1);

        /// <summary>
        /// Gets a vector representing moving one step "hyper south".
        /// </summary>
        public static Vector HyperSouth => new(0, 0, 0, -1);
    }
}
