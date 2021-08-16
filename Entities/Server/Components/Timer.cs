using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Server.Components {
    //hasn't been thoroughly tested, missing randomInterval
    public class Timer : IComponent {
        public string Name {
            get {
                return "minecraft:timer";
            }
        }

        public bool? Looping { get; set; }
        public double? Time { get; set; }
        public Range<double> TimeRange { get; set; }
        public TimerChoice[] RandomTimeChoices { get; set; }
        public EntityEvent TimeDownEvent { get; set; }

        public JProperty Generate() {
            JObject jObject = new JObject();

            jObject.AddIfNotNull("looping", Looping);
            jObject.AddIfNotNull("time", Time);
            jObject.AddIfNotNull("time", TimeRange);
            if (RandomTimeChoices != null && RandomTimeChoices.Length > 0) jObject.Add("random_time_choices", new JArray(RandomTimeChoices));
            jObject.AddIfNotNull("time_down_event", TimeDownEvent?.GetAttribute());

            return new JProperty(Name, jObject);
        }
    }
}
