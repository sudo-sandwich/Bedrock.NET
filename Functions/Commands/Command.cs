using Bedrock.Entities.Animations;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public abstract class Command : IEvent {
        public JToken AnimationEvent {
            get {
                return "/" + ToString();
            }
        }
    }
}
