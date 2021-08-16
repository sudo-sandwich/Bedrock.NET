using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class CustomHitTest : IComponent {
        public string Name => "minecraft:custom_hit_test";

        public IList<CustomHitbox> Hitboxes { get; set; } = new List<CustomHitbox>();

        public JProperty Generate() {
            JObject jObject = new JObject();

            if (Hitboxes.Count > 0) jObject.Add("hitboxes", Hitboxes.ToJArray());

            return new JProperty(Name, jObject);
        }
    }
}
