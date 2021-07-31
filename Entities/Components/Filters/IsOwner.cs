using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Filters {
    public class IsOwner : FilterTest {
        public override string Name {
            get {
                return "is_owner";
            }
        }

        public IsOwner(Subject subject, Test op, bool value) : base(subject, op, new JValue(value)) { }
    }
}
