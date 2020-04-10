using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bedrock.Entities.Components {
    public class DamageSensor : IComponent {
        public string Name {
            get {
                return "minecraft:damage_sensor";
            }
        }

        public DamageSensorTrigger[] Triggers { get; set; }

        public DamageSensor(params DamageSensorTrigger[] triggers) {
            Triggers = triggers;
        }

        public JProperty Generate() {
            JObject jObject = new JObject();

            if (Triggers != null && Triggers.Length > 0) jObject.Add("triggers", JArray.FromObject(Array.ConvertAll(Triggers, item => (JObject)item)));

            return new JProperty(Name, jObject);
        }
    }
}
