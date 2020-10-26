using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class EventEntity : Command {
        public TargetSelector Target { get; private set; }
        public string EventName { get; private set; }

        public EventEntity(TargetSelector target, string eventName) {
            Target = target;
            EventName = eventName;
        }

        public override string ToString() {
            return CommandHelper.Build("event", "entity", Target, EventName);
        }
    }
}
