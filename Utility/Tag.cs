using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Utility {
    public struct Tag {
        public string Value { get; set; }
        public string Inverse {
            get {
                return "!" + Value;
            }
        }

        internal Tag(string value) {
            Value = value;
        }

        public static implicit operator string(Tag tag) {
            return tag.ToString();
        }

        public override string ToString() {
            return Value;
        }
    }
}
