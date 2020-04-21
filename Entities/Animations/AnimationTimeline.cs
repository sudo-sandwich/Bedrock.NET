using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Animations {
    public class AnimationTimeline : IAnimation, IAnimateScript {
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public ISet<IAnimation> Animations {
            get {
                return new HashSet<IAnimation>(new IAnimation[] { this });
            }
        }

        public bool Loop { get; set; }
        public double Length { get; set; } //user must define animation length or the timeline will not work
        public IList<TimelineStep> Timeline { get; } = new List<TimelineStep>();

        public AnimationTimeline(string shortName, string longName, double length = 0, bool loop = false) {
            ShortName = shortName;
            LongName = longName;
            Length = length;
            Loop = loop;
        }

        public JToken GenerateScript() {
            return ShortName;
        }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.Add("loop", Loop);
            jObject.Add("animation_length", Length);

            JObject timeline = new JObject();
            jObject.Add(new JProperty("timeline", timeline));
            foreach (TimelineStep step in Timeline) {
                JArray events = new JArray();
                foreach (IEvent stepEvent in step.Events) {
                    events.Add(stepEvent.Expression);
                }
                timeline.Add(step.Time.ToString(FormatStrings.DoubleFixedPoint), events);
            }

            return new JProperty(LongName, jObject);
        }
    }
}
