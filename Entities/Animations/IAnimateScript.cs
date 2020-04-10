using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Animations {
    public interface IAnimateScript {
        ISet<IAnimation> Animations { get; } //gets a set of all animations associated with this script so that it can be added to the entity's list of animation definitions
        JToken GenerateScript();
    }
}
