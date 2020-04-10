using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Filters {
    public class HasTag : FilterTest {
        public override string Name {
            get {
                return "has_tag";
            }
        }
        public HasTag(Subject subject, Test op, string value) : base(subject, op, new JValue(value)) { }
    }
}
