using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Filters {
    public class HasDamage : FilterTest {
        public override string Name {
            get {
                return "has_damage";
            }
        }
        public HasDamage(Subject subject, Test op, string value) : base(subject, op, new JValue(value)) { }
    }
}
