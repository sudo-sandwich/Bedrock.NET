using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bedrock.Functions.Commands {
    //command for "scoreboard players set|add|remove"
    public class ScoreboardPlayers : Command {
        public ScoreAction Action { get; private set; }
        public TargetSelector Target { get; private set; } //set this to null for "*"
        public string Objective { get; private set; }
        public int Count { get; private set; }

        public ScoreboardPlayers(ScoreAction action, TargetSelector target, string objective, int count) {
            Action = action;
            Target = target;
            Objective = objective;
            Count = count;
        }

        public override string ToString() {
            return CommandHelper.Build("scoreboard", "players", Action.GetDescription(), Target != null ? Target.ToString() : "*", Objective, Count);
        }
    }

    public enum ScoreAction {
        [Description("add")]
        Add,
        [Description("remove")]
        Remove,
        [Description("set")]
        Set
    }
}
