using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Utility {
    public class Tag {
        public string Value { get; set; }
        internal Tag(string value) {
            Value = value;
        }

        public static implicit operator string(Tag tag) {
            return tag?.ToString();
        }

        public override string ToString() {
            return Value;
        }
    }
}
