using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class TimerChoice : IJObject {
        public int Weight { get; set; }
        public int Value { get; set; }

        public JObject ToJObject() => new JObject() { { "weight", Weight }, { "value", Value } };

        public JToken ToJToken() => ToJObject();
    }
}
