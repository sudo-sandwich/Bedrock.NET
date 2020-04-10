using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bedrock.Functions.Commands {
#pragma warning disable CA1716 // Identifiers should not match keywords
    public class Function : Command {
#pragma warning restore CA1716 // Identifiers should not match keywords
        public MCFunction MCFunction { get; private set; }

        public Function(MCFunction mcFunction) {
            MCFunction = mcFunction;
        }

        public override string ToString() {
            return CommandHelper.Build("function", MCFunction.Name);
        }
    }
}
