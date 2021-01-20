using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class ScoreboardObjectivesRemove : Command {
        public string Name { get; private set; }

        public ScoreboardObjectivesRemove(string name) {
            Name = name;
        }

        public override string ToString() => CommandHelper.Build("scoreboard", "objectives", "remove", Name);
    }
}
