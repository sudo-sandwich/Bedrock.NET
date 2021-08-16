using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    // obviously, avoid using this, but sometimes you just need it, yknow?
    public class HardCodedComponent : IComponent {
        public string Name { get; set; }

        public JObject Content { get; set; }

        public HardCodedComponent() { }

        public HardCodedComponent(string name, JObject content) {
            Name = name;
            Content = content;
        }

        public JProperty Generate() {
            return new JProperty(Name, Content);
        }
    }
}
