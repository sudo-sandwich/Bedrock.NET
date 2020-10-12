using Bedrock.Functions;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class CustomHitbox : IJToken {
        public double? Width { get; set; }
        public double? Height { get; set; }
        public Vector3? Pivot { get; set; }

        public CustomHitbox(double width, double height, Vector3 pivot) {
            Width = width;
            Height = height;
            Pivot = pivot;
        }

        public JToken ToJToken() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("width", Width);
            jObject.AddIfNotNull("height", Height);
            jObject.AddIfNotNull("pivot", Pivot?.ToJArray());

            return jObject;
        }
    }
}
