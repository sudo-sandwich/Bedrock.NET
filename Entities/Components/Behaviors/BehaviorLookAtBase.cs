using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bedrock.Entities.Components.Behaviors {
    public abstract class BehaviorLookAtBase : IBehavior {
        public abstract string Name { get; }
        public int Priority { get; set; }

        public double? LookDistance { get; set; }
        public double? Probability { get; set; }
        public Range<int> LookTime { get; set; }
        public int? AngleOfViewVertical { get; set; }
        public int? AngleOfViewHorizontal { get; set; }

        public virtual JProperty Generate() {
            JObject jObject = new JObject() {
                { "priority", Priority }
            };

            jObject.AddIfNotNull("look_distance", LookDistance);
            jObject.AddIfNotNull("probability", Probability);
            jObject.AddIfNotNull("look_time", LookTime);
            jObject.AddIfNotNull("angle_of_view_vertical", AngleOfViewVertical);
            jObject.AddIfNotNull("angle_of_view_horizontal", AngleOfViewHorizontal);

            return new JProperty(Name, jObject);
        }
    }
}
