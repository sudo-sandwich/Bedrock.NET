using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bedrock.Entities.Client {
    public class RCArray<T> : IJProperty where T : ClientAsset {
        public string Name { get; set; }
        IList<T> Entries { get; set; }

        public RCArray(string name) {
            Name = name;
            Entries = new List<T>();
        }

        public RCArray(string name, params T[] assets) {
            Name = name;
            Entries = new List<T>(assets);
        }

        public RCArray(string name, IEnumerable<T> assets) {
            Name = name;
            Entries = new List<T>(assets);
        }

        public void Add(T asset) => Entries.Add(asset);

        public JProperty ToJProperty() => new JProperty(Name, new JArray(Entries.Select(e => e.ArrayEntry)));
        public JToken ToJToken() => ToJProperty();
    }
}
