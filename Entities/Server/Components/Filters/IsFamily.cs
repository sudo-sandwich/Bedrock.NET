using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Bedrock.Entities.Server.Components.Filters {
    public class IsFamily : FilterTest {
        public override string Name {
            get {
                return "is_family";
            }
        }

        public IsFamily(Subject subject, Test op, string value) : base(subject, op, new JValue(value)) { }
    }
}
