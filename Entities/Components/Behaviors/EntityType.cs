using Bedrock.Entities.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Behaviors {
    public class EntityType : IJToken {
        public Filter Filter { get; set; }
        public double? MaxDist { get; set; }
        public double? WalkSpeedMultiplier { get; set; }
        public double? SprintSpeedMultiplier { get; set; }
        public bool? MustSee { get; set; }
        public double? MustSeeForgetDuration { get; set; }

        public EntityType(Filter filter) {
            Filter = filter;
        }

        public JObject ToJObject() {
            JObject jObject = new JObject();

            if (Filter != null) jObject.Add(Filter.ToJProperty());
            jObject.AddIfNotNull("max_dist", MaxDist);
            jObject.AddIfNotNull("walk_speed_multiplier", WalkSpeedMultiplier);
            jObject.AddIfNotNull("sprint_speed_multiplier", SprintSpeedMultiplier);
            jObject.AddIfNotNull("must_see", MustSee);
            jObject.AddIfNotNull("must_see_forget_duration", MustSeeForgetDuration);

            return jObject;
        }

        public JToken ToJToken() {
            return ToJObject();
        }

        public static implicit operator JObject(EntityType et) {
            return et?.ToJObject();
        }

        public static implicit operator JToken(EntityType et) {
            return et?.ToJToken();
        }
    }
}
