using Bedrock.Entities.Animations;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities {
    public static class EntityUtil {
        // returns the scripts object if it was created
        public static JObject AddAnimations(JObject description, IList<IAnimation> animations, IList<AnimationBlend> animationScripts) {
            if (animations.Count > 0) {
                JObject animationsJObject = new JObject();
                description.Add(new JProperty("animations", animationsJObject));

                HashSet<IAnimation> allAnimations = new HashSet<IAnimation>();
                foreach (IAnimation animation in animations) {
                    allAnimations.AddRange(AnimationUtil.GetNestedAnimations(animation));
                }
                foreach (IAnimation animation in allAnimations) {
                    animationsJObject.Add(animation.ShortName, animation.LongName);
                }
            }

            JObject scripts = null;
            if (animationScripts.Count > 0) {
                scripts = new JObject();
                description.Add(new JProperty("scripts", scripts));

                JArray animate = new JArray();
                scripts.Add("animate", animate);

                foreach (AnimationBlend animationBlend in animationScripts) {
                    animate.Add(animationBlend.ToJToken());
                }
            }

            return scripts;
        }
    }
}
