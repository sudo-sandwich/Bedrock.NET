using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class PlaySound : Command {
        public string Sound { get; private set; }
        public TargetSelector Target { get; private set; }
        public Position? Position { get; private set; }
        public double? Volume { get; private set; } //must be between 0 and 1, inclusive
        public double? Pitch { get; private set; } //must be between 0 and 2, inclusive
        public double? MinimumVolume { get; private set; } //must be between 0 and 1, inclusive

        public PlaySound(string sound, TargetSelector target = null, Position? position = null, double? volume = null, double? pitch = null, double? minimumVolume = null) {
            Sound = sound;
            Target = target;
            Position = position;
            Volume = volume;
            Pitch = pitch;
            MinimumVolume = minimumVolume;
        }

        public override string ToString() {
            return CommandHelper.Build("playsound", Sound, Target, Position, Volume, Pitch, MinimumVolume);
        }
    }
}
