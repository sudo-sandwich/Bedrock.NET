using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Filters {
    public class IsTarget : FilterTest {
        public override string Name {
            get {
                return "is_target";
            }
        }

        public IsTarget(Subject subject, Test op, bool value) : base(subject, op, new JValue(value)) { }
    }
}
