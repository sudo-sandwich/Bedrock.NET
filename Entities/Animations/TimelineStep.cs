using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Animations {
    public class TimelineStep {
        public double Time { get; set; }
        public IList<IEvent> Events { get; } = new List<IEvent>();

        public TimelineStep(double time, params IEvent[] events) {
            Time = time;
            Events.AddRange(events);
        }
    }
}
