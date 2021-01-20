using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class ScoreboardPlayersOperation : Command {
        public TargetSelector Target { get; private set; }
        public string TargetString { get; private set; }
        public string Objective { get; private set; }
        public Operation Operation { get; private set; }
        public TargetSelector Source { get; private set; }
        public string SourceString { get; private set; }
        public string SourceObjective { get; private set; }

        public ScoreboardPlayersOperation(TargetSelector target, string objective, Operation operation, TargetSelector source, string sourceObjective) {
            Target = target;
            Objective = objective;
            Operation = operation;
            Source = source;
            SourceObjective = sourceObjective;
        }

        public ScoreboardPlayersOperation(string targetString, string objective, Operation operation, string sourceString, string sourceObjective) {
            TargetString = targetString;
            Objective = objective;
            Operation = operation;
            SourceString = sourceString;
            SourceObjective = sourceObjective;
        }

        public override string ToString() {
            return CommandHelper.Build("scoreboard", "players", "operation", Target?.ToString() ?? TargetString, Objective, Operation.GetDescription(), Source?.ToString() ?? SourceString, SourceObjective);
        }
    }

    public enum Operation {
        [Description("+=")]
        Addition,
        [Description("-=")]
        Subtraction,
        [Description("*=")]
        Multiplication,
        [Description("/=")]
        Division,
        [Description("%=")]
        Modulus,
        [Description("=")]
        Assign,
        [Description("<")]
        Min,
        [Description(">")]
        Max,
        [Description("><")]
        Swap
    }
}
