using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Client {
    public class OverlayColorMolang : IJObject {
        public string Red { get; set; }
        public string Green { get; set; }
        public string Blue { get; set; }
        public string Alpha { get; set; }

        public OverlayColorMolang(string red, string green, string blue, string alpha) {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        public JObject ToJObject() {
            return new JObject() {
                { "r", Red },
                { "g", Green },
                { "b", Blue },
                { "a", Alpha }
            };
        }

        public JToken ToJToken() => ToJObject();
    }
}
