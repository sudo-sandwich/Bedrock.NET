using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Filters {
    public class IsMarkVariant : FilterTest {
        public override string Name {
            get {
                return "is_mark_variant";
            }
        }
        public IsMarkVariant(Subject subject, Test op, int value) : base(subject, op, new JValue(value)) { }
    }
}
