using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Utility {
    public class Range<T> : IJArray where T : IComparable {
        public T Min { get; private set; }
        public T Max { get; private set; }

        public Range(T min, T max) {
            if (min.CompareTo(max) > 0) {
                throw new ArithmeticException("Max must be greater than min.");
            }
            Min = min;
            Max = max;
        }

        public JArray ToJArray() => new JArray(Min, Max);

        public JToken ToJToken() => ToJArray();
    }
}
