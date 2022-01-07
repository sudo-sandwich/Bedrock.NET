using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class GameMode : Command {
        public Mode Mode { get; private set; }
        public TargetSelector Target { get; private set; }
        public GameMode(Mode mode, TargetSelector target = null) {
            Mode = mode;
            Target = target;
        }

        public override string ToString() {
            return CommandHelper.Build("gamemode", Mode.GetDescription(), Target);
        }
    }

    public enum Mode {
        [Description("survival")]
        Survival,
        [Description("creative")]
        Creative,
        [Description("adventure")]
        Adventure
    }
}
