using Bedrock.Entities.Client;
using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bedrock.Entities.Animations {
    public static class AnimationUtil {
        public static ISet<IAnimation> GetNestedAnimations(IAnimation root) => GetNestedAnimations(root, new HashSet<IAnimation>() { root });

        private static ISet<IAnimation> GetNestedAnimations(IAnimation root, ISet<IAnimation> animationsAlreadyFound) {
            if (root is AnimationController ac) {
                foreach (AnimationState state in ac.States) {
                    foreach (AnimationBlend animationBlend in state.Animations) {
                        if (!animationsAlreadyFound.Contains(animationBlend.Animation)) {
                            animationsAlreadyFound.Add(animationBlend.Animation);
                            animationsAlreadyFound.AddRange(GetNestedAnimations(animationBlend.Animation, animationsAlreadyFound));
                        }
                    }
                }
                return animationsAlreadyFound;
            } else {
                return animationsAlreadyFound;
            }
        }

        public static ISet<ParticleDescription> GetNestedParticles(IAnimation root) {
            HashSet<ParticleDescription> particles = new HashSet<ParticleDescription>();
            foreach (IAnimation animation in GetNestedAnimations(root)) {
                if (animation is AnimationController ac) {
                    foreach (AnimationState state in ac.States) {
                        foreach (ParticleEffect pe in state.ParticleEffects) {
                            particles.Add(pe.Particle);
                        }
                    }
                } else if (animation is AnimationTimeline at) {
                    foreach (IList<IAnimationTimelineEvent> events in at.Timeline.Values) {
                        foreach (ParticleEffect pe in events.OfType<ParticleEffect>()) {
                            particles.Add(pe.Particle);
                        }
                    }
                }
            }
            return particles;
        }

        /*
        private static void ValidateParticle(Dictionary<string, ParticleDescription> particles, ParticleEffect pe) {
            if (!particles.ContainsKey(pe.Particle.ShortName)) {
                particles.Add(pe.Particle.ShortName, pe.Particle);
            } else if (particles[pe.Particle.ShortName].LongName != pe.Particle.LongName) {
                throw new Exception($"Particles with short name {pe.Particle.ShortName} refer to different particle effects ({particles[pe.Particle.ShortName].LongName}, {pe.Particle.LongName}).");
            }
        }
        */
    }
}
