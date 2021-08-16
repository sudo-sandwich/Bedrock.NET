using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Animations {
    public class MoLang : IAnimationControllerEvent, IAnimationTimelineEvent {
        public string Expression { get; set; }

        public JToken AnimationEvent => Expression;

        public MoLang(string expression) {
            Expression = expression;
        }
    }
}
