using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bedrock.Entities.Components.Filters {
    public class Filter {
        public FilterTest[] Tests { get; set; }
        public Group GroupType { get; set; }

        public Filter(Group groupType, params FilterTest[] tests) {
            GroupType = groupType;
            Tests = tests;
        }

        public static implicit operator JProperty(Filter filter) {
            return filter?.ToJProperty();
        }

        public JProperty ToJProperty() {
            JObject jObject = new JObject();

            JArray filters = new JArray();
            jObject.Add(GroupType.GetDescription(), filters);

            foreach (FilterTest test in Tests) {
                filters.Add(test.ToJObject());
            }

            return new JProperty("filters", jObject);
        }
    }

    public enum Group {
        [Description("all_of")]
        AllOf,
        [Description("any_of")]
        AnyOf
    }
}
