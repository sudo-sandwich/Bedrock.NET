using Bedrock.Entities.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class SpawnEntityEntry : IJToken {

        public IFilter Filters { get; set; }
        public int? MaxWaitTime { get; set; }
        public int? MinWaitTime { get; set; }
        public int? NumToSpawn { get; set; }
        public bool? ShouldLeash { get; set; }
        public bool? SingleUse { get; set; }
        public string Entity { get; set; }
        public string SpawnEvent { get; set; }
        public string SpawnItem { get; set; }
        public string SpawnMethod { get; set; }
        public string SpawnSound { get; set; }

        public JToken ToJToken() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("filters", Filters);
            jObject.AddIfNotNull("max_wait_time", MaxWaitTime);
            jObject.AddIfNotNull("min_wait_time", MinWaitTime);
            jObject.AddIfNotNull("num_to_spawn", NumToSpawn);
            jObject.AddIfNotNull("should_leash", ShouldLeash);
            jObject.AddIfNotNull("single_use", SingleUse);
            jObject.AddIfNotNull("spawn_entity", Entity);
            jObject.AddIfNotNull("spawn_event", SpawnEvent);
            jObject.AddIfNotNull("spawn_item", SpawnItem);
            jObject.AddIfNotNull("spawn_method", SpawnMethod);
            jObject.AddIfNotNull("spawn_sound", SpawnSound);

            return jObject;
        }
    }
}
