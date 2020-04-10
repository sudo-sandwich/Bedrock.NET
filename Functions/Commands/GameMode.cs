using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class GameMode : Command {
        public Mode Mode { get; private set; }

        public GameMode(Mode mode) {
            Mode = mode;
        }

        public override string ToString() {
            return CommandHelper.Build("gamemode", Mode.GetDescription());
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
