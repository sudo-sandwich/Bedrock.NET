using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class CameraShakeAdd : Command {
        public TargetSelector Target { get; private set; }
        public double? Intensity { get; private set; }
        public double? Seconds { get; private set; }
        public CameraShakeType? ShakeType { get; private set; }

        public CameraShakeAdd(TargetSelector target, double? intensity = null, double? seconds = null, CameraShakeType? shakeType = null) {
            Target = target;
            Intensity = intensity;
            Seconds = seconds;
            ShakeType = shakeType;
        }

        public override string ToString() => CommandHelper.Build("camerashake", "add", Target, Intensity, Seconds, ShakeType?.GetDescription());
    }

    public enum CameraShakeType {
        [Description("positional")]
        Positional,
        [Description("rotational")]
        Rotational,
    }
}
