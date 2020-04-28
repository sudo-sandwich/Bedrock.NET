using Bedrock.Utility;
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

        public IList<DamageSensorTrigger> Triggers { get; set; } = new List<DamageSensorTrigger>();

        public DamageSensor(params DamageSensorTrigger[] triggers) {
            Triggers.AddRange(triggers);
        }

        public JProperty Generate() {
            JObject jObject = new JObject();

            JArray triggers = new JArray();
            jObject.Add("triggers", triggers);

            foreach (DamageSensorTrigger trigger in Triggers) {
                triggers.Add(trigger);
            }

            return new JProperty(Name, jObject);
        }
    }
}
