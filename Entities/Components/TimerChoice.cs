using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class TimerChoice : IJToken {
        public int Weight { get; set; }
        public int Value { get; set; }

        public static implicit operator JObject(TimerChoice tc) {
            return tc?.ToJObject();
        }

        public static implicit operator JToken(TimerChoice tc) {
            return tc?.ToJToken();
        }

        public JObject ToJObject() {
            return new JObject() { { "weight", Weight }, { "value", Value } };
        }

        public JToken ToJToken() {
            return ToJObject();
        }
    }
}
