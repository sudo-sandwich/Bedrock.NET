using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Filters {
    public class DistanceToNearestPlayer : FilterTest {
        public override string Name => "distance_to_nearest_player";

        public DistanceToNearestPlayer(Subject subject, Test op, double value) : base(subject, op, new JValue(value)) { }
    }
}
