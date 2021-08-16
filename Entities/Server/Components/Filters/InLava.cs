using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Filters {
    public class InLava : FilterTest {
        public override string Name {
            get {
                return "in_lava";
            }
        }

        public InLava(Subject subject, Test op, bool value) : base(subject, op, new JValue(value)) { }
    }
}
