using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bedrock.Entities.Server.Components.Filters {
    public class FilterGroup : IFilter {
        public IFilter[] Tests { get; set; }
        public Group GroupType { get; set; }

        public FilterGroup(Group groupType, params IFilter[] tests) {
            GroupType = groupType;
            Tests = tests;
        }

        public JToken ToJToken() {
            return ToJObject();
        }

        public JObject ToJObject() {
            JObject jObject = new JObject();

            JArray filters = new JArray();
            jObject.Add(GroupType.GetDescription(), filters);

            foreach (IFilter test in Tests) {
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
