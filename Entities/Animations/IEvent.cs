using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Animations {
    public interface IEvent {
        JToken AnimationEvent { get; }
    }
}
