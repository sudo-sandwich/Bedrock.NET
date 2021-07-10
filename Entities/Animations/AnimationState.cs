using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Entities.Animations {
    public class AnimationState {
        public string Name { get; set; }
        public IList<AnimationBlend> Animations { get; } = new List<AnimationBlend>();
        public IList<IEvent> OnEntry { get; } = new List<IEvent>();
        public IList<IEvent> OnExit { get; } = new List<IEvent>();
        public IList<ParticleEffect> ParticleEffects { get; } = new List<ParticleEffect>();
        public IList<AnimationStateTransition> Transitions { get; } = new List<AnimationStateTransition>();
        public double? BlendTransition { get; set; }

        public AnimationState(string name, double? blendTransition = null) {
            Name = name;
            BlendTransition = blendTransition;
        }

        public void AddTransition(AnimationState transitionTo, string query) {
            Transitions.Add(new AnimationStateTransition(transitionTo, query));
        }

        public JProperty Generate() {
            JObject jObject = new JObject();

            if (Animations.Count > 0) {
                JArray animations = new JArray();
                jObject.Add("animations", animations);

                foreach (AnimationBlend animation in Animations) {
                    animations.Add(animation.GenerateScript());
                }
            }

            if (OnEntry.Count > 0) {
                JArray onEntry = new JArray();
                jObject.Add("on_entry", onEntry);

                foreach (IEvent e in OnEntry) {
                    onEntry.Add(e.AnimationEvent);
                }
            }

            if (OnExit.Count > 0) {
                JArray onExit = new JArray();
                jObject.Add("on_exit", onExit);

                foreach (IEvent e in OnExit) {
                    onExit.Add(e.AnimationEvent);
                }
            }

            if (ParticleEffects.Count > 0) {
                JArray particleEffects = new JArray();
                jObject.Add("particle_effects", particleEffects);

                foreach (ParticleEffect effect in ParticleEffects) {
                    particleEffects.Add(effect.Expression);
                }
            }

            if (Transitions.Count > 0) {
                JArray transitions = new JArray();
                jObject.Add("transitions", transitions);

                foreach (AnimationStateTransition transition in Transitions) {
                    transitions.Add(transition.Generate());
                }
            }

            if (BlendTransition != null) jObject.Add("blend_transition", BlendTransition);

            return new JProperty(Name, jObject);
        }
    }
}
