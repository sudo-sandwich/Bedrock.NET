using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Animations {
    //TODO: modify animation controller to split between resource pack (client side) and behavior pack (server side) animation controllers, make this file an abstract class
    public class AnimationController : IAnimation, IAnimateScript {
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public AnimationState InitialState { get; set; }
        public IList<AnimationState> States { get; } = new List<AnimationState>();

        public ISet<IAnimation> Animations {
            get {
                ISet<IAnimation> animations = new HashSet<IAnimation>();
                animations.Add(this);
                foreach (AnimationState state in States) {
                    foreach (AnimationBlend animationBlend in state.Animations) {
                        animations.Add(animationBlend.Animation);
                    }
                }
                return animations;
            }
        }

        public AnimationController(string shortName, string longName) {
            ShortName = shortName;
            LongName = longName;
        }

        public AnimationState CreateState(string name, double? blendTransition = null) {
            AnimationState animationState = new AnimationState(name, blendTransition);
            States.Add(animationState);
            return animationState;
        }

        public JToken GenerateScript() {
            return ShortName;
        }

        public JProperty Generate() {
            JObject jObject = new JObject();

            if (InitialState != null) jObject.Add("initial_state", InitialState.Name);
            JObject states = new JObject();
            jObject.Add(new JProperty("states", states));

            foreach (AnimationState state in States) {
                states.Add(state.Generate());
            }

            return new JProperty(LongName, jObject);
        }
    }
}
