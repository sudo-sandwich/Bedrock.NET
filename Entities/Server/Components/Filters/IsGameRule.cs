using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components.Filters {
    public class IsGameRule : FilterTest {
        public override string Name {
            get {
                return "is_game_rule";
            }
        }

        public string GameRule { get; set; }

        public IsGameRule(Subject subject, string gameRule, Test op, bool value) : base(subject, op, new JValue(value)) {
            GameRule = gameRule;
        }

        public override JObject ToJObject() {
            JObject jObject = new JObject {
                { "test", Name },
                { "domain", GameRule },
                { "subject", Subject.GetDescription() },
                { "operator", Test.GetDescription() }
            };

            jObject.Add("value", Value);

            return jObject;
        }
    }
}
