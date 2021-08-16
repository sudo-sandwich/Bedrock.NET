using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Filters {
    public class HasAbility : FilterTest {
        public override string Name {
            get {
                return "has_ability";
            }
        }
        public HasAbility(Subject subject, Test op, string value) : base(subject, op, new JValue(value)) { }
    }
}
