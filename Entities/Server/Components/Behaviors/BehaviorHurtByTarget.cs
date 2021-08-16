using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Behaviors {
    public class BehaviorHurtByTarget : IBehavior {
        public string Name { 
            get {
                return "minecraft:behavior.hurt_by_target";
            } 
        }

        public int Priority { get; set; }
        public IList<EntityType> EntityTypes { get; set; } = new List<EntityType>();
        public bool? AlertSameType { get; set; }
        public bool? HurtOwner { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            if (EntityTypes.Count > 0) jObject.Add("entity_types", EntityTypes.ToJArray());
            jObject.AddIfNotNull("alert_same_type", AlertSameType);
            jObject.AddIfNotNull("hurt_owner", HurtOwner);

            return new JProperty(Name, jObject);
        }
    }
}
