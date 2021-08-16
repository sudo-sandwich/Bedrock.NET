using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Animations {
    public interface IAnimationEvent {
        JToken AnimationEvent { get; }
    }
}
