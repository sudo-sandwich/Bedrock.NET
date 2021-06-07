using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Filters {
    public class OnGround : FilterTest {
        public override string Name {
            get {
                return "on_ground";
            }
        }

        public OnGround(Subject subject, Test op, bool value) : base(subject, op, new JValue(value)) { }
    }
}
