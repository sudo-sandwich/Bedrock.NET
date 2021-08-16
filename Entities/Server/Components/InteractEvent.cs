using Bedrock.Entities.Server.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class InteractEvent : IJObject {
        public IFilter Filters { get; set; }
        public EntityEvent Event { get; set; }
        public string Target { get; set; }

        public JObject ToJObject() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull(Filters);
            jObject.AddIfNotNull("event", Event?.Name);
            jObject.AddIfNotNull("target", Target);

            return jObject;
        }

        public JToken ToJToken() => ToJObject();
    }
}
