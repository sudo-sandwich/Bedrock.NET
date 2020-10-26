using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Filters {
    public class IsSneaking : FilterTest {
        public override string Name {
            get {
                return "is_sneaking";
            }
        }

        public IsSneaking(Subject subject, Test op, bool value) : base(subject, op, new JValue(value)) { }
    }
}
