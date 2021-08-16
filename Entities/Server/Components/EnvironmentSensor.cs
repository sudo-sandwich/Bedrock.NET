using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class EnvironmentSensor : IComponent {
        public string Name {
            get {
                return "minecraft:environment_sensor";
            }
        }

        public IList<EnvironmentTrigger> Triggers { get; set; } = new List<EnvironmentTrigger>();

        public JProperty Generate() {
            JObject jObject = new JObject();

            if (Triggers != null && Triggers.Count > 0) {
                jObject.Add("triggers", Triggers.ToJArray());
            }

            return new JProperty(Name, jObject);
        }
    }
}
