using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bedrock.Functions {
    public struct Coordinate : IEquatable<Coordinate> {
        public static readonly Coordinate Tilde = new Coordinate(0, Offset.World); //set Value to null to produce nothing but a tilde.
        public static readonly Coordinate Carat = new Coordinate(0, Offset.Local);

        public double Value { get; private set; }
        public Offset Offset { get; private set; }

        public Coordinate(double val, Offset offset = Offset.None) {
            Value = val;
            Offset = offset;
        }

        public override string ToString() {
            if (Offset == Offset.None) {
                return Value.ToString();
            } else if (Value < 0) {
                return Offset.GetDescription() + Value;
            } else if (Value > 0) {
                return Offset.GetDescription() + "+" + Value;
            } else {
                return Offset.GetDescription();
            }
        }

        public override bool Equals(object obj) {
            if (!(obj is Coordinate)) {
                return false;
            } else {
                return Equals((Coordinate)obj);
            }
        }

        public bool Equals(Coordinate other) {
            return Value == other.Value && Offset == other.Offset;
        }

        //stolen from here: https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode/263416#263416
        public override int GetHashCode() {
            unchecked {
                int hash = 97;
                hash = hash * 113 + Value.GetHashCode();
                hash = hash * 113 + Offset.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Coordinate left, Coordinate right) {
            return left.Equals(right);
        }

        public static bool operator !=(Coordinate left, Coordinate right) {
            return !(left == right);
        }
    }

    public enum Offset {
        [Description("")]
        None,
        [Description("~")]
        World,
        [Description("^")]
        Local
    }
}