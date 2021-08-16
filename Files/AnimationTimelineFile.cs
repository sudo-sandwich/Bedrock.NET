using Bedrock.Entities.Animations;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Files {
    public class AnimationTimelineFile {
        public string Name { get; set; }
        public IReadOnlyDictionary<string, AnimationTimeline> Timelines => _timelines;
        private Dictionary<string, AnimationTimeline> _timelines { get; set; } = new Dictionary<string, AnimationTimeline>();

        public AnimationTimelineFile(string name) {
            Name = name;
        }

        public void Add(AnimationTimeline at) {
            if (Timelines.ContainsKey(at.LongName)) {
                throw new ArgumentException($"Animation timeline with long name {at.LongName} already exists in this file.");
            }

            _timelines.Add(at.LongName, at);
        }

        public bool Remove(AnimationTimeline ac) => Remove(ac.LongName);

        public bool Remove(string longName) => _timelines.Remove(longName);

        public JObject Generate() {
            JObject jObject = new JObject() {
                { "format_version", "1.8.0" }
            };

            JObject animations = new JObject();
            jObject.Add(new JProperty("animations", animations));

            foreach (AnimationTimeline animation in Timelines.Values) {
                animations.Add(animation.Generate());
            }

            return jObject;
        }
    }
}
