using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Utility {
    public class RawText {
        public string Text { get; set; }
        public string Translate { get; set; }
        public IList<string> With { get; private set; } = new List<string>();

        public override string ToString() {
            JObject jObject = new JObject();

            JObject rawText = new JObject();
            jObject.Add("rawtext", new JArray(rawText));

            if (Text != null) rawText.Add("text", Text);
            if (Translate != null) rawText.Add("translate", Translate);
            if (With.Count > 0) rawText.Add("with", new JArray(With));

            return jObject.ToString(Formatting.None);
        }
    }
}
