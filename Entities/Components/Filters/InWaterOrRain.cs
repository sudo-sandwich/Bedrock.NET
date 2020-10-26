using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Filters {
    public class InWaterOrRain : FilterTest {
        public override string Name {
            get {
                return "in_water_or_rain";
            }
        }

        public InWaterOrRain(Subject subject, Test op, bool value) : base(subject, op, new JValue(value)) { }
    }
}
