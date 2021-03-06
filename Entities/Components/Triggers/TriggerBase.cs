﻿using Bedrock.Entities.Components.Filters;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Triggers {
    public abstract class TriggerBase : IComponent {
        public abstract string Name { get; }

        public EntityEvent Event { get; set; }
        public string Target { get; set; }
        public Filter Filter { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            if (Filter != null) jObject.Add(Filter.ToJProperty());
            jObject.AddIfNotNull("event", Event.Name);
            jObject.AddIfNotNull("target", Target);

            return new JProperty(Name, jObject);
        }
    }
}
