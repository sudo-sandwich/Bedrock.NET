using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class ExperienceReward : IComponent {
        public string Name => "minecraft:experience_reward";

        public string OnDeath { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("on_death", OnDeath);

            return new JProperty(Name, jObject);
        }
    }
}
