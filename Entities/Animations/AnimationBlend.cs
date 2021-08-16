using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Animations {
    public class AnimationBlend : IJToken {
        public IAnimation Animation { get; set; }
        public string Expression { get; set; }

        public ISet<IAnimation> Animations {
            get {
                return new HashSet<IAnimation>(new IAnimation[] { Animation });
            }
        }

        public AnimationBlend(IAnimation animation, string expression = null) {
            Animation = animation;
            Expression = expression;
        }

        public JToken ToJToken() {
            if (Expression == null) {
                return Animation.ShortName;
            } else {
                return new JObject() {
                    { Animation.ShortName, Expression }
                };
            }
        }
    }
}
