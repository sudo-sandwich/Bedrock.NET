using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
    public class Say : Command {
        public string Message { get; private set; }

        public Say(string message) {
            Message = message;
        }

        public override string ToString() {
            return CommandHelper.Build("say", Message);
        }
    }
}
