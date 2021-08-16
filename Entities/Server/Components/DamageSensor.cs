using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bedrock.Entities.Server.Components {
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

            if (Triggers.Count > 0) jObject.Add("triggers", Triggers.ToJArray());

            return new JProperty(Name, jObject);
        }
    }
}
