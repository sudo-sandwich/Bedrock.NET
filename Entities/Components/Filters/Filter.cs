using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bedrock.Entities.Components.Filters {
    public class Filter : IJToken {
        public FilterTest[] Tests { get; set; }
        public Group GroupType { get; set; }

        public Filter(Group groupType, params FilterTest[] tests) {
            GroupType = groupType;
            Tests = tests;
        }

        public static implicit operator JToken(Filter filter) {
            return filter?.ToJToken();
        }

        public static implicit operator JObject(Filter filter) {
            return filter?.ToJObject();
        }

        public static implicit operator JProperty(Filter filter) {
            return filter?.ToJProperty();
        }

        public JToken ToJToken() {
            return ToJObject();
        }

        public JObject ToJObject() {
            JObject jObject = new JObject();

            JArray filters = new JArray();
            jObject.Add(GroupType.GetDescription(), filters);

            foreach (FilterTest test in Tests) {
                filters.Add(test.ToJObject());
            }

            return jObject;
        }

        public JProperty ToJProperty() {
            return new JProperty("filters", ToJObject());
        }
    }

    public enum Group {
        [Description("all_of")]
        AllOf,
        [Description("any_of")]
        AnyOf,
        [Description("none_of")]
        NoneOf
    }
}
