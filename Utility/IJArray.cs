using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Utility {
    public interface IJArray : IJToken {
        JArray ToJArray();
    }
}
