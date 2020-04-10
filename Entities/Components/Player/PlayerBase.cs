using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Player {
    public abstract class PlayerBase : IComponent {
        public abstract string Name { get; }

        public int? Value { get; set; }
        public int? Min { get; set; }
        public int? Max { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("value", Value);
            jObject.AddIfNotNull("min", Min);
            jObject.AddIfNotNull("max", Max);

            return new JProperty(Name, jObject);
        }
    }
}
