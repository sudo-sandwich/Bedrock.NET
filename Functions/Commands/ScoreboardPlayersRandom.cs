using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class ScoreboardPlayersRandom : Command {
        public TargetSelector Target { get; set; }
        public string Objective { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public ScoreboardPlayersRandom(TargetSelector target, string objective, int min, int max) {
            Target = target;
            Objective = objective;
            Min = min;
            Max = max;
        }

        public override string ToString() => CommandHelper.Build("scoreboard", "players", "random", Target, Objective, Min, Max);
    }
}
