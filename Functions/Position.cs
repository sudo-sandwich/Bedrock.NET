using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bedrock.Functions {
    public struct Position : IEquatable<Position> {
        public static readonly Position Self = new Position(Coordinate.Tilde, Coordinate.Tilde, Coordinate.Tilde); //"~ ~ ~"
        public static readonly Position LocalOneX = new Position(new Coordinate(1, Offset.Tilde), Coordinate.Tilde, Coordinate.Tilde);
        public static readonly Position LocalOneY = new Position(Coordinate.Tilde, new Coordinate(1, Offset.Tilde), Coordinate.Tilde);
        public static readonly Position LocalOneZ = new Position(Coordinate.Tilde, Coordinate.Tilde, new Coordinate(1, Offset.Tilde));
        public static readonly Position LocalNegativeOneX = new Position(new Coordinate(-1, Offset.Tilde), Coordinate.Tilde, Coordinate.Tilde);
        public static readonly Position LocalNegativeOneY = new Position(Coordinate.Tilde, new Coordinate(-1, Offset.Tilde), Coordinate.Tilde);
        public static readonly Position LocalNegativeOneZ = new Position(Coordinate.Tilde, Coordinate.Tilde, new Coordinate(-1, Offset.Tilde));

        public Coordinate X { get; private set; }
        public Coordinate Y { get; private set; }
        public Coordinate Z { get; private set; }

        public Position(double x, double y, double z) {
            X = new Coordinate(x);
            Y = new Coordinate(y);
            Z = new Coordinate(z);
        }

        public Position(double x, double y, double z, Offset offset) {
            X = new Coordinate(x, offset);
            Y = new Coordinate(y, offset);
            Z = new Coordinate(z, offset);
        }

        public Position(Coordinate x, Coordinate y, Coordinate z) {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString() {
            return string.Join(" ", X, Y, Z);
        }

        public override bool Equals(object obj) {
            if (!(obj is Position)) {
                return false;
            } else {
                return Equals((Position)obj);
            }
        }

        public bool Equals(Position other) {
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

        public static bool operator ==(Position left, Position right) {
            return left.Equals(right);
        }

        public static bool operator !=(Position left, Position right) {
            return !(left == right);
        }
    }
}
