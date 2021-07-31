using Bedrock.Entities.Animations;
using Bedrock.Functions.Commands;
using Bedrock.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bedrock.Functions {
    public class MCFunction : IEvent {
        public string Name { get; set; }
        public IList<Command> Commands { get; } = new List<Command>();

        //this value should be assigned by AddonContent only
        internal string FunctionName { get; set; }

        public JToken AnimationEvent {
            get {
                return "/" + ToCommand().ToString();
            }
        }

        public MCFunction(string name) {
            Name = name;
        }

        public MCFunction(string name, IEnumerable<Command> commands) : this(name) {
            Commands.AddRange(commands);
        }

        public MCFunction(string name, params Command[] commands) : this(name, (IEnumerable<Command>)commands) { }

        public void Add(Command command) {
            Commands.Add(command);
        }

        public void AddRange(params Command[] commands) {
            AddRange(commands);
        }

        public void AddRange(IEnumerable<Command> commands) {
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
            public MCFunction function { get; private set; }

            public Function(MCFunction mcFunction) {
                function = mcFunction;
            }

            public override string ToString() {
                return CommandHelper.Build("function", function.FunctionName);
            }
        }
    }
}
