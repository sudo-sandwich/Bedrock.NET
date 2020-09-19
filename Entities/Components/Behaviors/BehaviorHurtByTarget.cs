using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Behaviors {
    public class BehaviorHurtByTarget : IBehavior {
        public string Name { 
            get {
                return "minecraft:behavior.hurt_by_target";
            } 
        }

        public int Priority { get; set; }
        public EntityType[] EntityTypes { get; set; }
        public bool? AlertSameType { get; set; }
        public bool? HurtOwner { get; set; }

        public BehaviorHurtByTarget(params EntityType[] entityTypes) {
            EntityTypes = entityTypes;
        }

        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            if (EntityTypes != null && EntityTypes.Length > 0) jObject.Add("entity_types", JArray.FromObject(Array.ConvertAll(EntityTypes, item => (JObject)item)));
            jObject.AddIfNotNull("alert_same_type", AlertSameType);
            jObject.AddIfNotNull("hurt_owner", HurtOwner);

            return new JProperty(Name, jObject);
        }
    }
}
