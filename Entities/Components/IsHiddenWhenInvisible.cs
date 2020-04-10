using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components {
    public class IsHiddenWhenInvisible : IComponent {
        public string Name {
            get {
                return "minecraft:is_hidden_when_invisible";
            }
        }

        public JProperty Generate() {
            return new JProperty(Name, new JObject());
        }
    }
}
