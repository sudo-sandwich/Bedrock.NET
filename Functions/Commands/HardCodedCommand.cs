using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    // class for when you want to hard code a command into an MCFunction
    public class HardCodedCommand : Command {
        public string Value { get; private set; }

        public HardCodedCommand(string value) {
            Value = value;
        }

        public override string ToString() {
            return Value;
        }
    }
}
