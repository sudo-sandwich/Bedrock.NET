using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Filters {
    public class HasComponent : FilterTest {
        public override string Name {
            get {
                return "has_component";
            }
        }
        public HasComponent(Subject subject, Test op, string value) : base(subject, op, new JValue(value)) { }
    }
}
