using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Filters {
    public class InContactWithWater : FilterTest {
        public override string Name {
            get {
                return "in_contact_with_water";
            }
        }

        public InContactWithWater(Subject subject, Test op, bool value) : base(subject, op, new JValue(value)) { }
    }
}
