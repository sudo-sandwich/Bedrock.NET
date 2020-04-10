using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class GameRule : Command {
        public string Rule { get; private set; }
        public bool? BoolValue { get; private set; }
        public int? IntValue { get; private set; }

        private string output;

        public GameRule(string rule, bool val) {
            Rule = rule;
            BoolValue = val;
            output = CommandHelper.Build("gamerule", Rule, BoolValue);
        }

        public GameRule(string rule, int val) {
            Rule = rule;
            IntValue = val;
            output = CommandHelper.Build("gamerule", Rule, IntValue);
        }

        public override string ToString() {
            return output;
        }
    }
}
