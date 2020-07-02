using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bedrock.Entities.Components.Filters {
    public class HasEquipment : FilterTest {
        public override string Name {
            get {
                return "has_equipment";
            }
        }

        public Domain Domain { get; set; }

        public HasEquipment(Subject subject, Domain domain, Test op, string value) : base(subject, op, new JValue(value)) {
            Domain = domain;
        }

        public override JObject ToJObject() {
            JObject jObject = new JObject {
                { "test", Name },
                { "domain", Domain.GetDescription() },
                { "subject", Subject.GetDescription() },
                { "operator", Test.GetDescription() }
            };

            jObject.Add("value", (JToken)Value);

            return jObject;
        }
    }

    public enum Domain {
        [Description("any")]
        Any,
        [Description("feet")]
        Feet,
        [Description("hand")]
        Hand,
        [Description("armor")]
        Armor,
        [Description("torso")]
        Torso,
        [Description("head")]
        Head,
        [Description("leg")]
        Leg
    }
}
