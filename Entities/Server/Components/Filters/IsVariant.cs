using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Filters {
    public class IsVariant : FilterTest {
        public override string Name {
            get {
                return "is_variant";
            }
        }
        public IsVariant(Subject subject, Test op, int value) : base(subject, op, new JValue(value)) { }
    }
}
