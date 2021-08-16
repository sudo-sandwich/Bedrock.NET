using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Movements {
    public abstract class MovementBase : IComponent {
        public abstract string Name { get; }
        public double? MaxTurn { get; set; }

        public virtual JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("max_turn", MaxTurn);

            return new JProperty(Name, jObject);
        }
    }
}
