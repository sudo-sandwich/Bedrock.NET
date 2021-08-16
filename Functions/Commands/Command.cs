using Bedrock.Entities.Animations;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public abstract class Command : IAnimationControllerEvent, IAnimationTimelineEvent {
        public JToken AnimationEvent {
            get {
                return "/" + ToString();
            }
        }
    }
}
