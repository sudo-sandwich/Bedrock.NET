using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class ScoreboardObjectivesAdd : Command {
        public string Name { get; private set; }
        public string DisplayName { get; private set; }

        public ScoreboardObjectivesAdd(string name, string displayName = null) {
            Name = name;
            DisplayName = displayName;
        }

        public override string ToString() => CommandHelper.Build("scoreboard", "objectives", "add", Name, "dummy", DisplayName);
    }
}
