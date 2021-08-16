using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Filters {
    public class HasTarget : FilterTest {
        public override string Name {
            get {
                return "has_target";
            }
        }
        public HasTarget(Subject subject, Test op, bool value) : base(subject, op, new JValue(value)) { }
    }
}
