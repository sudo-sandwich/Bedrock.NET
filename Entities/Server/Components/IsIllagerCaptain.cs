using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    public class IsIllagerCaptain : IComponent {
        public string Name => "minecraft:is_illager_captain";

        public JProperty Generate() {
            return new JProperty(Name, new JObject());
        }
    }
}
