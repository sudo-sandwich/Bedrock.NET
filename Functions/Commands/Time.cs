using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class Time : Command {
        public TimeAction Action { get; set; }
        public int Value { get; private set; }

        public Time(TimeAction action, int value) {
            Action = action;
            Value = value;
        }

        public override string ToString() {
            return CommandHelper.Build("time", Action.GetDescription(), Value);
        }
    }

    public enum TimeAction {
        [Description("add")]
        Add,
        [Description("set")]
        Set
    }
}
