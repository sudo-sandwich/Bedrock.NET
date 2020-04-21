using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Utility {
    public class Tag {
        public string Value { get; private set; }
        public Tag Inverse { get; private set; } //myTag.Inverse will return a tag with "!" prefix. myTag.Inverse.Inverse will return null.

        internal Tag(string value, bool createInverse) {
            Value = value;
            if (createInverse) {
                Inverse = new Tag("!" + value, false);
            }
        }

        public static implicit operator string(Tag tag) {
            return tag?.ToString();
        }

        public override string ToString() {
            return Value;
        }
    }
}
