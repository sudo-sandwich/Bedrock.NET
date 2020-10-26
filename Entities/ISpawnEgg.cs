using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities {
    public interface ISpawnEgg : IJToken {
        JObject ToJObject();
    }
}
