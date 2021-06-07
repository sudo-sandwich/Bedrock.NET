using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Components.Filters {
    public interface IFilter : IJToken {
        JObject ToJObject();
        JProperty ToJProperty();
    }
}
