using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions {
    public struct Vector3 {
        public static readonly Vector3 One = new Vector3(1, 1, 1);
        public static readonly Vector3 OneX = new Vector3(1, 0, 0);
        public static readonly Vector3 OneY = new Vector3(0, 1, 0);
        public static readonly Vector3 OneZ = new Vector3(0, 0, 1);
        public static readonly Vector3 Zero = new Vector3(0, 0, 0);

        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Vector3(double x, double y, double z) {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString() {
            return string.Join(" ", X, Y, Z);
        }

        public Position ToPosition() {
            return new Position(X, Y, Z);
        }

        public JArray ToJArray() {
            return new JArray(X, Y, Z);
        }

        public Vector3 Add(Vector3 other) {
            return new Vector3(X + other.X, Y + other.Y, Z + other.Z);
        }

        public Vector3 Subtract(Vector3 other) {
            return new Vector3(X - other.X, Y - other.Y, Z - other.Z);
        }

        public Vector3 Multiply(double amount) {
            return new Vector3(X * amount, Y * amount, Z * amount);
        }

        public override bool Equals(object obj) {
            if (!(obj is Vector3)) {
                return false;
            } else {
                return Equals((Vector3)obj);
            }
        }

        public bool Equals(Vector3 other) {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        //stolen from here: https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode/263416#263416
        public override int GetHashCode() {
            unchecked {
                int hash = 97;
                hash = hash * 113 + X.GetHashCode();
                hash = hash * 113 + Y.GetHashCode();
                hash = hash * 113 + Z.GetHashCode();
                return hash;
            }
        }

        public static Vector3 operator +(Vector3 left, Vector3 right) {
            return left.Add(right);
        }

        public static Vector3 operator -(Vector3 left, Vector3 right) {
            return left.Subtract(right);
        }
        public static Vector3 operator *(Vector3 left, double amount) {
            return left.Multiply(amount);
        }

        public static bool operator ==(Vector3 left, Vector3 right) {
            return left.Equals(right);
        }

        public static bool operator !=(Vector3 left, Vector3 right) {
            return !(left == right);
        }

        public static implicit operator Position(Vector3 v3) {
            return v3.ToPosition();
        }

        public static implicit operator JArray(Vector3 v3) {
            return v3.ToJArray();
        }
    }
}
