using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Client {
    public abstract class ClientAsset : IJProperty {
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public abstract string ArrayEntry { get; }

        public ClientAsset(string shortName, string longName) {
            ShortName = shortName;
            LongName = longName;
        }

        public JProperty ToJProperty() => new JProperty(ShortName, LongName);
        public JToken ToJToken() => ToJProperty();
    }
}
