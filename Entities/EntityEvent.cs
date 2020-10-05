using Bedrock.Entities.Animations;
using Bedrock.Entities.Components;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bedrock.Entities {
    public class EntityEvent : IEvent {
        public string Name { get; set; }
        public JToken AnimationEvent {
            get {
                return "@s " + Name;
            }
        }
        public IList<ComponentGroup> ComponentsToAdd { get; set; } = new List<ComponentGroup>();
        public IList<ComponentGroup> ComponentsToRemove { get; set; } = new List<ComponentGroup>();
        public IList<RandomGroup> Randomize { get; set; } = new List<RandomGroup>();

        public EntityEvent(string name) {
            Name = name;
        }

        public EntityEvent(string name, ComponentGroup groupToAdd) {
            Name = name;
            ComponentsToAdd.Add(groupToAdd);
        }

        public EntityEvent(string name, ComponentGroup groupToAdd, ComponentGroup groupToRemove) {
            Name = name;
            ComponentsToAdd.Add(groupToAdd);
            ComponentsToRemove.Add(groupToRemove);
        }

        //always uses self as target, needs to be expanded to allow more options
        public JObject GetAttribute() {
            return new JObject() {
                { "event", Name },
                { "target", "self" }
            };
        }

        public JProperty Generate() {
            JObject jObject = new JObject();

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
            if (Randomize.Count > 0) {
                jObject.Add("randomize", Randomize.ToJArray());
            }

            return new JProperty(Name, jObject);
        }
    }
}
