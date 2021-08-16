using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Filters {
    public class RiderCount : FilterTest {
        public override string Name {
            get {
                return "rider_count";
            }
        }
        public RiderCount(Subject subject, Test op, int value) : base(subject, op, new JValue(value)) { }
    }
}
