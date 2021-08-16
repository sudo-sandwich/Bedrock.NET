using Bedrock.Files;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Animations {
    public class AnimationTimeline : IAnimation {
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public AnimationTimelineFile File { get; set; }

        public bool Loop { get; set; }
        public double Length { get; set; } //user must define animation length or the timeline will not work
        public IDictionary<double, IList<IAnimationTimelineEvent>> Timeline { get; } = new Dictionary<double, IList<IAnimationTimelineEvent>>();

        public AnimationTimeline(string shortName, string longName, double length, bool loop) {
            ShortName = shortName;
            LongName = longName;
            Length = length;
            Loop = loop;
        }

        public void Add(double time, params IAnimationTimelineEvent[] events) {
            if (!Timeline.ContainsKey(time)) {
                Timeline.Add(time, new List<IAnimationTimelineEvent>());
            }

            Timeline[time].AddRange(events);
        }

        public JToken GenerateScript() {
            return ShortName;
        }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.Add("loop", Loop);
            jObject.Add("animation_length", Length);

            JObject timeline = new JObject();
            JObject particlesTimeline = new JObject();
            foreach ((double time, IList<IAnimationTimelineEvent> events) in Timeline) {
                JArray eventsArray = new JArray();
                JArray particlesArray = new JArray();
                foreach (IAnimationTimelineEvent stepEvent in events) {
                    if (stepEvent is ParticleEffect pe) {
                        particlesArray.Add(pe.AnimationEvent);
                    } else {
                        eventsArray.Add(stepEvent.AnimationEvent);
                    }
                }
                if (eventsArray.Count > 0) {
                    timeline.Add(time.ToString(FormatStrings.DoubleFixedPoint), eventsArray);
                }
                if (particlesArray.Count > 0) {
                    particlesTimeline.Add(time.ToString(FormatStrings.DoubleFixedPoint), particlesArray);
                }
            }

            if (timeline.Count > 0) {
                jObject.Add(new JProperty("timeline", timeline));
            }
            if (particlesTimeline.Count > 0) {
                jObject.Add(new JProperty("particle_effects", particlesTimeline));
            }

            return new JProperty(LongName, jObject);
        }
    }
}
