using Bedrock.Entities.Server.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Behaviors {
    public class BehaviorLookAtEntity : BehaviorLookAtBase {
        public override string Name {
            get {
                return "minecraft:behavior.look_at_entity";
            }
        }

        public IFilter Filter { get; set; }

        public override JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            jObject.AddIfNotNull((JProperty)Filter);
            jObject.AddIfNotNull("look_distance", LookDistance);
            jObject.AddIfNotNull("probability", Probability);
            jObject.AddIfNotNull("look_time", LookTime);
            jObject.AddIfNotNull("angle_of_view_vertical", AngleOfViewVertical);
            jObject.AddIfNotNull("angle_of_view_horizontal", AngleOfViewHorizontal);

            return new JProperty(Name, jObject);
        }
    }
}
