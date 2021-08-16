using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server {
    // incomplete implementation
    public class RandomGroup : IJObject {
        public int? Weight { get; set; }

        public IList<ComponentGroup> ComponentsToAdd { get; set; } = new List<ComponentGroup>();
        public IList<ComponentGroup> ComponentsToRemove { get; set; } = new List<ComponentGroup>();

        public JObject ToJObject() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("weight", Weight);

            if (ComponentsToAdd.Count > 0) {
                JObject add = new JObject();
                jObject.Add("add", add);

                JArray componentGroups = new JArray();
                add.Add("component_groups", componentGroups);
                foreach (ComponentGroup componentGroup in ComponentsToAdd) {
                    componentGroups.Add(componentGroup.Name);
                }
            }
            if (ComponentsToRemove.Count > 0) {
                JObject remove = new JObject();
                jObject.Add("remove", remove);

                JArray componentGroups = new JArray();
                remove.Add("component_groups", componentGroups);
                foreach (ComponentGroup componentGroup in ComponentsToRemove) {
                    componentGroups.Add(componentGroup.Name);
                }
            }

            return jObject;
        }

        public JToken ToJToken() => ToJObject();
    }
}
