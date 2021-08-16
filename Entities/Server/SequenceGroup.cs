using Bedrock.Entities.Server.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bedrock.Entities.Server {
    public class SequenceGroup : IJObject {
        public IFilter Filters { get; set; }
        public IList<SequenceGroup> Sequence { get; set; } = new List<SequenceGroup>();
        public IList<ComponentGroup> ComponentsToAdd { get; set; } = new List<ComponentGroup>();
        public IList<ComponentGroup> ComponentsToRemove { get; set; } = new List<ComponentGroup>();

        public JObject ToJObject() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("filters", Filters?.ToJObject());

            if (Sequence.Count > 0) {
                jObject.Add(new JProperty("sequence", Sequence.ToJArray()));
            }
            if (ComponentsToAdd.Count > 0) {
                jObject.Add(new JProperty("add", new JObject() { { "component_groups", new JArray(ComponentsToAdd.Select(cg => cg.Name)) } }));
            }
            if (ComponentsToRemove.Count > 0) {
                jObject.Add(new JProperty("remove", new JObject() { { "component_groups", new JArray(ComponentsToRemove.Select(cg => cg.Name)) } }));
            }

            return jObject;
        }

        public JToken ToJToken() => ToJObject();
    }
}
