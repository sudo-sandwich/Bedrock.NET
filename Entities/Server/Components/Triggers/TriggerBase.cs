using Bedrock.Entities.Server.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Triggers {
    public abstract class TriggerBase : IComponent {
        public abstract string Name { get; }

        public string Event { get; set; }
        public string Target { get; set; }
        public IFilter Filter { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            if (Filter != null) jObject.Add(Filter.ToJProperty());
            jObject.AddIfNotNull("event", Event);
            jObject.AddIfNotNull("target", Target);

            return new JProperty(Name, jObject);
        }
    }
}
