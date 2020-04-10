using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bedrock.Entities.Components.Filters {
    public abstract class FilterTest {
        public abstract string Name { get; }
        public Subject Subject { get; set; }
        public Test Test { get; set; }
        public JValue Value { get; set; }

        protected FilterTest(Subject subject, Test test, JValue value) {
            Subject = subject;
            Test = test;
            Value = value;
        }

        public static implicit operator JObject(FilterTest filterTest) {
            return filterTest?.ToJObject();
        }

        public virtual JObject ToJObject() {
            JObject jObject = new JObject {
                { "test", Name },
                { "subject", Subject.GetDescription() },
                { "operator", Test.GetDescription() }
            };

            jObject.Add("value", (JToken)Value);

            return jObject;
        }
    }

    public enum Subject {
        [Description("self")]
        Self,
        [Description("other")]
        Other,
        [Description("parent")]
        Parent,
        [Description("player")]
        Player,
        [Description("target")]
        Target
    }

    public enum Test {
        [Description("==")]
        Equal,
        [Description("!=")]
        NotEqual,
        [Description(">")]
        GreaterThan,
        [Description(">=")]
        GreaterThanOrEqual,
        [Description("<")]
        LessThan,
        [Description("<=")]
        LessThanOrEqual
    }
}
