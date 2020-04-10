using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class ScoreSelector {
        public string Name { get; set; }
        public int Value { get; set; }
        public Range<int> ValueRange { get; set; }
        public Equality RangeType { get; set; }

        public ScoreSelector(string name, int value, Equality rangeType = Equality.Equal) {
            Name = name;
            Value = value;
            RangeType = rangeType;
        }

        public ScoreSelector(string name, int min, int max) {
            Name = name;
            ValueRange = new Range<int>(min, max);
            RangeType = Equality.Range;
        }

        public static implicit operator ScoreSelector[](ScoreSelector s) {
            return s?.To();
        }

        public ScoreSelector[] To() {
            return new ScoreSelector[] { this };
        }

        public override string ToString() {
            string toReturn = Name + " = ";
            switch (RangeType) {
                case Equality.Equal:
                    return toReturn + Value;
                case Equality.NotEqual:
                    return toReturn + "!" + Value;
                case Equality.LessThan:
                    return toReturn + ".." + Value;
                case Equality.GreaterThan:
                    return toReturn + Value + "..";
                case Equality.Range:
                    return toReturn + ValueRange.Min + ".." + ValueRange.Max;
                default:
                    throw new Exception("should never get here.");
            }
        }
    }

    public enum Equality {
        Equal,
        NotEqual,
        LessThan,
        GreaterThan,
        Range
    }
}
