using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Animations {
    public class AnimationStateTransition {
        public AnimationState State { get; set; }
        public string Expression { get; set; }

        public AnimationStateTransition(AnimationState state, string expression) {
            State = state;
            Expression = expression;
        }

        public JObject Generate() {
            return new JObject() { { State.Name, Expression } };
        }
    }
}
