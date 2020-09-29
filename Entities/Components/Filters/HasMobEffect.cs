using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Filters {
    public class HasMobEffect : FilterTest {
        public override string Name => "has_mob_effect";
        public HasMobEffect(Subject subject, Test op, string value) : base(subject, op, new JValue(value)) { }
    }
}
