using Bedrock.Entities.Animations;
using Bedrock.Entities.Server;
using Bedrock.Entities.Server.Components;
using Bedrock.Entities.Utility;
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

        public static EventGroup CreateEventGroupSingle(this ServerEntity se, string eventName, string groupName, params IComponent[] components) {
            ComponentGroup cg = se.CreateComponentGroup(groupName, components);
            EntityEvent addEvent = se.CreateEvent(eventName, cg);
            return new EventGroup(addEvent, null, cg);
        }

        public static EventGroup CreateEventGroupSingle(this ServerEntity se, string eventName, params IComponent[] components) => CreateEventGroupSingle(se, eventName, $"{eventName}_group", components);

        public static EventGroup CreateEventGroupDouble(this ServerEntity se, string addEventName, string removeEventName, string groupName, params IComponent[] components) {
            ComponentGroup cg = se.CreateComponentGroup(groupName, components);
            EntityEvent add = se.CreateEvent(addEventName, cg);
            EntityEvent remove = se.CreateEvent(removeEventName);
            remove.ComponentsToRemove.Add(cg);
            return new EventGroup(add, remove, cg);
        }

        public static EventGroup CreateEventGroupDouble(this ServerEntity se, string eventName, params IComponent[] components) => CreateEventGroupDouble(se, eventName, $"{eventName}_remove", $"{eventName}_group", components);
    }
}
