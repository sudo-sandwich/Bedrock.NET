using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class Effect : Command {
        public TargetSelector Target { get; private set; }
        public string EffectType { get; private set; }
        public int? Duration { get; private set; }
        public int? Amplifier { get; private set; }
        public bool? HideParticles { get; private set; }

        public Effect(TargetSelector target, string effectType, int? duration = null, int? amplifier = null, bool? hideParticles = null) {
            Target = target;
            EffectType = effectType;
            Duration = duration;
            Amplifier = amplifier;
            HideParticles = hideParticles;
        }

        public override string ToString() {
            return CommandHelper.Build("effect", Target, EffectType, Duration, Amplifier, HideParticles);
        }
    }
}
