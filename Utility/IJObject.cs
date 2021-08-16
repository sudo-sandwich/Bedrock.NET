using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Utility {
    public interface IJObject : IJToken {
        JObject ToJObject();
    }
}
