using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class EnvironmentSensor : IComponent {
        public string Name {
            get {
                return "minecraft:environment_sensor";
            }
        }

        public EnvironmentTrigger[] Triggers { get; set; }

        public EnvironmentSensor(params EnvironmentTrigger[] triggers) {
            Triggers = triggers;
        }

        public JProperty Generate() {
            JObject jObject = new JObject();

            if (Triggers != null && Triggers.Length > 0) jObject.Add("triggers", JArray.FromObject(Array.ConvertAll(Triggers, item => (JToken)item)));

            return new JProperty(Name, jObject);
        }
    }
}
