using Bedrock.Entities.Animations;
using Bedrock.Functions.Commands;
using Bedrock.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bedrock.Functions {
    public class MCFunction : IEvent {
        public string Name { get; set; }
        public IList<Command> Commands { get; } = new List<Command>();

        internal string FunctionName { get; set; }

        public string Expression {
            get {
                return "/function " + Name;
            }
        }

        public MCFunction(string name, params Command[] commands) {
            Name = name;
            Commands.AddRange(commands);
        }

        public override string ToString() {
            IList<string> commands = Commands.Select(c => c.ToString()).ToList();
            return string.Join("\n", commands);
        }

        public static implicit operator Command(MCFunction mcf) {
            return mcf?.ToCommand();
        }
        
        public Command ToCommand() {
            return new Function(this);
        }

        private class Function : Command {
            public MCFunction MCFunction { get; private set; }

            public Function(MCFunction mcFunction) {
                MCFunction = mcFunction;
            }

            public override string ToString() {
                return CommandHelper.Build("function", MCFunction.FunctionName);
            }
        }
    }
}
