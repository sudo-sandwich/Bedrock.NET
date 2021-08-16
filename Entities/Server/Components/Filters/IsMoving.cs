using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Filters {
    public class IsMoving : FilterTest {
        public override string Name {
            get {
                return "is_moving";
            }
        }

        public IsMoving(Subject subject, Test op, bool value) : base(subject, op, new JValue(value)) { }
    }
}
